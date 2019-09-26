using System;
using System.Collections.Generic;
using System.Linq;
using Separation.DataSource;
using Separation.Models;
using Separation.POCO;
using Separation.Services;

namespace Separation.ServiceValues {
    public class BusDataVersionService {
        #region helpers
        private static Func<string> IdGen(string format, int initial = 1)
            => () => string.Format(format, initial++);

        private static Func<string> CityBusId = IdGen("CityBus_02{0:D3}", 365);
        private static Func<string> InterCityBusId = IdGen("InterCityBus_02{0:D3}", 18);

        private static IEnumerable<BaseServiceDetail> GetDetails_CityBus()
            => BaseCity.GetCities().Select(c => new BaseServiceDetail {
                ID = CityBusId(),
                FK_BaseAuthority = c.FK_BaseAuthority,
                Parameter = c.NameEn,
                ParamDescription = c.Name
            });
        private static BaseServiceDetail GetDetail_InterCityBus()
            => new BaseServiceDetail {
                ID = InterCityBusId(),
                FK_BaseAuthority = BaseAuthority.交通部公路總局
            };
        #endregion

        private static IEnumerable<ServiceData> GenerateData() {
            yield return new ServiceData {
                Service = new BaseService {
                    FK_BaseDataType = BaseDataType.DataVersion,
                    NameZh_tw = "市區公車資料版本歷史資料",
                    FK_BaseCategory = BaseCategory.Bus,
                    FK_BaseSubCategory = BaseSubCategory.CityBus,
					SwaggerOperationID = "CityBusApi_DataVersionAll",
                    ParamName = "City",
					URL = "v{Version}/Bus/DataVersion/All/City/{City}",
                    EnumID = 2049
                }, Details = GetDetails_CityBus()
            };
            yield return new ServiceData {
                Service = new BaseService {
                    FK_BaseDataType = BaseDataType.DataVersion,
                    NameZh_tw = "公路客運資料版本歷史資料",
                    FK_BaseCategory = BaseCategory.Bus,
                    FK_BaseSubCategory = BaseSubCategory.InterCityBus,
					SwaggerOperationID = "InterCityBusApi_DataVersionAll",
					URL = "v{Version}/Bus/DataVersion/All/InterCity",
                    EnumID = 2074
                }, Detail = GetDetail_InterCityBus()
            };
        }
        public static IEnumerable<string> Insert() {
            foreach (var item in GenerateData()) {
                item.Service.PK_BaseService = Guid.NewGuid();
                item.Service.Version = 2;
                item.Service.IsLiveData = false;
                item.Service.IsHistoricalData = false;
                item.Service.SpecPublishStatus = false;
                item.Service.APIPublishStatus = 1;
                item.Service.URL_Web = item.Service.URL_Web ?? item.Service.URL;
                yield return SqlSL.Insert("BaseService", item.Service);

                foreach (var d in item.Details) {
                    d.PK_BaseServiceDetail = Guid.NewGuid();
                    d.FK_BaseService = item.Service.PK_BaseService;
                    d.NameZh_tw = d.NameZh_tw ?? $"{d.ParamDescription}{item.Service.NameZh_tw}";
                    d.DataUpdateInterval = -1;
                    d.PublishTime = Time.Execution;
                    d.UpdateTime = Time.Execution;
                    d.SpecPublishStatus = false;
                    d.APIPublishStatus = 1;
                    yield return SqlSL.Insert("BaseServiceDetail", d);
                }

                yield return string.Empty;
            }
        }
    }
}
