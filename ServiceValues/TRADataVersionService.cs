using System;
using System.Collections.Generic;
using System.Linq;
using Separation.DataSource;
using Separation.Models;
using Separation.POCO;
using Separation.Services;

namespace Separation.ServiceValues {
    public class TRADataVersionService {
        #region helpers
        private static Func<string> IdGen(string format, int initial = 1)
            => () => string.Format(format, initial++);

        private static Func<string> TRAId = IdGen("TRA_02{0:D3}", 16);

        private static BaseServiceDetail GetDetail_TRA()
            => new BaseServiceDetail {
                ID = TRAId(),
                FK_BaseAuthority = BaseAuthority.交通部臺灣鐵路管理局
            };
        #endregion

        private static IEnumerable<ServiceData> GenerateData() {
            yield return new ServiceData {
                Service = new BaseService {
                    FK_BaseDataType = BaseDataType.DataVersion,
                    NameZh_tw = "臺鐵車次資料版本歷史資料",
                    FK_BaseCategory = BaseCategory.Rail,
                    FK_BaseSubCategory = BaseSubCategory.TRA,
					SwaggerOperationID = "TRAApi_GeneralDataVersionAll",
					URL = "v{Version}/Rail/TRA/GeneralDataVersion/All",
                    EnumID = 2155
                }, Detail = GetDetail_TRA()
            };
            yield return new ServiceData {
                Service = new BaseService {
                    FK_BaseDataType = BaseDataType.DataVersion,
                    NameZh_tw = "臺鐵票價資料版本歷史資料",
                    FK_BaseCategory = BaseCategory.Rail,
                    FK_BaseSubCategory = BaseSubCategory.TRA,
					SwaggerOperationID = "TRAApi_ODFareDataVersionAll",
					URL = "v{Version}/Rail/TRA/ODFareDataVersion/All",
                    EnumID = 2156
                }, Detail = GetDetail_TRA()
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
