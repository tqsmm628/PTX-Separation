using System;
using System.Collections.Generic;
using System.Linq;
using Separation.DataSource;
using Separation.Models;
using Separation.POCO;
using Separation.Services;

namespace Separation.ServiceValues {
    public class GtfsService {
        #region helpers
        private static Func<string> IdGen(string format, int initial = 1) 
            => () => string.Format(format, initial++);
        private static Func<string> GtfsCityBusId = IdGen("GtfsCityBus_02{0:D3}");
        private static Func<string> GtfsThsrId = IdGen("GtfsThsr_02{0:D3}");
        private static Func<string> GtfsTraId = IdGen("GtfsTra_02{0:D3}");
        private static IEnumerable<BaseServiceDetail> GetDetails_CityBus()
            => BaseCity.GetCities().Select(c => new BaseServiceDetail {
                ID = GtfsCityBusId(),
                FK_BaseAuthority = c.FK_BaseAuthority,
                Parameter = c.NameEn,
                ParamDescription = c.Name
            });
        private static BaseServiceDetail GetDetail_THSR()
            => new BaseServiceDetail {
                ID = GtfsThsrId(),
                FK_BaseAuthority = BaseAuthority.臺灣高速鐵路股份有限公司
            };
        private static BaseServiceDetail GetDetail_TRA()
            => new BaseServiceDetail {
                ID = GtfsTraId(),
                FK_BaseAuthority = BaseAuthority.交通部臺灣鐵路管理局
            };
        #endregion

        private static IEnumerable<ServiceData> GenerateData() {
            #region GTFS 2370~2399
            yield return new ServiceData {
                Service = new BaseService {
                    NameZh_tw = "公車靜態GTFS資料轉製",
                    FK_BaseCategory = BaseCategory.GTFS,
                    FK_BaseSubCategory = BaseSubCategory.CityBus,
					SwaggerOperationID = "GTFSBusApi_Static",
					URL = "{0}/v2/Bus/GTFS/Static/File/City/{1}",
                    EnumID = 2370
                }, Details = GetDetails_CityBus()
            };
            yield return new ServiceData {
                Service = new BaseService {
                    NameZh_tw = "公車動態GTFS資料轉製",
                    FK_BaseCategory = BaseCategory.GTFS,
                    FK_BaseSubCategory = BaseSubCategory.CityBus,
					SwaggerOperationID = "GTFSBusApi_RealTime",
					URL = "{0}/v2/Bus/GTFS/RealTime/File/City/{1}",
                    EnumID = 2371
                }, Details = GetDetails_CityBus()
            };
            yield return new ServiceData {
                Service = new BaseService {
                    NameZh_tw = "高鐵靜態GTFS資料轉製",
                    FK_BaseCategory = BaseCategory.GTFS,
                    FK_BaseSubCategory = BaseSubCategory.THSR,
					SwaggerOperationID = "GTFSTHSRApi_Static",
					URL = "{0}/v2/THSR/GTFS/Static/File",
                    EnumID = 2372
                }, Detail = GetDetail_THSR()
            };
            yield return new ServiceData {
                Service = new BaseService {
                    NameZh_tw = "台鐵靜態GTFS資料轉製",
                    FK_BaseCategory = BaseCategory.GTFS,
                    FK_BaseSubCategory = BaseSubCategory.TRA,
					SwaggerOperationID = "GTFSTRAApi_Static",
					URL = "{0}/v2/TRA/GTFS/Static/File",
                    EnumID = 2374
                }, Detail = GetDetail_TRA()
            };
            yield return new ServiceData {
                Service = new BaseService {
                    NameZh_tw = "台鐵動態GTFS資料轉製",
                    FK_BaseCategory = BaseCategory.GTFS,
                    FK_BaseSubCategory = BaseSubCategory.TRA,
					SwaggerOperationID = "GTFSTRAApi_RealTime",
					URL = "{0}/v2/TRA/GTFS/RealTime/File",
                    EnumID = 2375
                }, Detail = GetDetail_TRA()
            };
            #endregion
        }
        public static IEnumerable<string> Insert() {
            foreach (var item in GenerateData()) {
                item.Service.PK_BaseService = Guid.NewGuid();
                item.Service.Version = 2;
                item.Service.URL_Web = item.Service.URL_Web ?? item.Service.URL;
                item.Service.SpecPublishStatus = true;
                item.Service.APIPublishStatus = 1;
                yield return SqlSL.Insert("BaseService", item.Service);

                foreach (var d in item.Details) {
                    d.PK_BaseServiceDetail = Guid.NewGuid();
                    d.FK_BaseService = item.Service.PK_BaseService;
                    d.NameZh_tw = d.NameZh_tw ?? $"{d.ParamDescription}{item.Service.NameZh_tw}";
                    d.DataUpdateInterval = -1;
                    d.PublishTime = Time.Execution;
                    d.UpdateTime = Time.Execution;
                    d.SpecPublishStatus = true;
                    d.APIPublishStatus = 1;
                    if (new [] {2370, 2371}.Contains(item.Service.EnumID)) {
                        if (new [] {"Taipei", "KinmenCounty"}.Contains(d.Parameter)) {
                            d.SpecPublishStatus = false;
                            d.APIPublishStatus = 0;
                        }
                    }
                    yield return SqlSL.Insert("BaseServiceDetail", d);
                }

                yield return string.Empty;
            }
        }
    }
}
