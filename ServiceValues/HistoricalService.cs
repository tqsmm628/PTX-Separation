using System;
using System.Collections.Generic;
using System.Linq;
using Separation.DataSource;
using Separation.Models;
using Separation.POCO;
using Separation.Services;

namespace Separation.ServiceValues {
    public class HistoricalService {
        #region helpers
        private static Func<string> IdGen(string format, int initial = 1)
            => () => string.Format(format, initial++);
        private static Func<string> AviationId = IdGen("HistoricalAviation_02{0:D3}");
        private static Func<string> CityBusId = IdGen("HistoricalCityBus_02{0:D3}");
        private static Func<string> InterCityBusId = IdGen("HistoricalInterCityBus_02{0:D3}");
        private static Func<string> THSRId = IdGen("HistoricalTHSR_02{0:D3}");
        private static Func<string> TRAId = IdGen("HistoricalTRA_02{0:D3}");
        private static BaseServiceDetail GetDetail_Air()
            => new BaseServiceDetail {
                ID = AviationId(),
                FK_BaseAuthority = BaseAuthority.交通部民用航空局
            };
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
        private static BaseServiceDetail GetDetail_THSR()
            => new BaseServiceDetail {
                ID = THSRId(),
                FK_BaseAuthority = BaseAuthority.臺灣高速鐵路股份有限公司
            };
        private static BaseServiceDetail GetDetail_TRA()
            => new BaseServiceDetail {
                ID = TRAId(),
                FK_BaseAuthority = BaseAuthority.交通部臺灣鐵路管理局
            };
        #endregion

        private static IEnumerable<ServiceData> GenerateData() {
            #region historical 2400~2420
            yield return new ServiceData {
                Service = new BaseService {
                    FK_BaseDataType = BaseDataType.Schedule,
                    NameZh_tw = "機場航班歷史資料服務",
                    FK_BaseCategory = BaseCategory.Air,
                    SpecificationURL = "{0}?area=historical#!/HistoricalAirApi/HistoricalAirApi_Airport",
                    URL = "{0}/v2/Air/Historical/FIDS/Airport",
                    EnumID = 2400
                }, Detail = GetDetail_Air()
            };
            yield return new ServiceData {
                Service = new BaseService {
                    FK_BaseDataType = BaseDataType.LiveBoard,
                    NameZh_tw = "航班歷史資料服務",
                    FK_BaseCategory = BaseCategory.Air,
                    SpecificationURL = "{0}?area=historical#!/HistoricalAirApi/HistoricalAirApi_Flight",
                    URL = "{0}/v2/Air/Historical/FIDS/Flight",
                    EnumID = 2401
                }, Detail = GetDetail_Air()
            };
            yield return new ServiceData {
                Service = new BaseService {
                    FK_BaseDataType = BaseDataType.LivePosition,
                    NameZh_tw = "公車動態定時歷史檔案清單(A1)",
                    FK_BaseCategory = BaseCategory.Bus,
                    FK_BaseSubCategory = BaseSubCategory.CityBus,
                    SpecificationURL = "{0}?area=historical#!/HistoricalCityBusApi/HistoricalCityBusApi_RealTimeByFrequency",
                    URL = "{0}/v2/Bus/Historical/RealTimeByFrequency/City/{1}",
                    EnumID = 2402
                }, Details = GetDetails_CityBus()
            };
            yield return new ServiceData {
                Service = new BaseService {
                    FK_BaseDataType = BaseDataType.LiveBoard,
                    NameZh_tw = "公車動態定點歷史檔案清單(A2)",
                    FK_BaseCategory = BaseCategory.Bus,
                    FK_BaseSubCategory = BaseSubCategory.CityBus,
                    SpecificationURL = "{0}?area=historical#!/HistoricalCityBusApi/HistoricalCityBusApi_RealTimeNearStop",
                    URL = "{0}/v2/Bus/Historical/RealTimeNearStop/City/{1}",
                    EnumID = 2403
                }, Details = GetDetails_CityBus()
            };
            yield return new ServiceData {
                Service = new BaseService {
                    FK_BaseDataType = BaseDataType.LivePosition,
                    NameZh_tw = "公路客運動態定時歷史檔案清單(A1)",
                    FK_BaseCategory = BaseCategory.Bus,
                    FK_BaseSubCategory = BaseSubCategory.InterCityBus,
                    SpecificationURL = "{0}?area=historical#!/HistoricalInterCityBusApi/HistoricalInterCityBusApi_RealTimeByFrequency",
                    URL = "{0}/v2/Bus/Historical/RealTimeByFrequency/InterCity",
                    EnumID = 2404
                }, Detail = GetDetail_InterCityBus()
            };
            yield return new ServiceData {
                Service = new BaseService {
                    FK_BaseDataType = BaseDataType.LiveBoard,
                    NameZh_tw = "公路客運動態定點歷史檔案清單(A2)",
                    FK_BaseCategory = BaseCategory.Bus,
                    FK_BaseSubCategory = BaseSubCategory.InterCityBus,
                    SpecificationURL = "{0}?area=historical#!/HistoricalInterCityBusApi/HistoricalInterCityBusApi_RealTimeNearStop",
                    URL = "{0}/v2/Bus/Historical/RealTimeNearStop/InterCity",
                    EnumID = 2405
                }, Detail = GetDetail_InterCityBus()
            };
            yield return new ServiceData {
                Service = new BaseService {
                    FK_BaseDataType = BaseDataType.Alert,
                    NameZh_tw = "高鐵即時通阻事件歷史資料",
                    FK_BaseCategory = BaseCategory.Rail,
                    FK_BaseSubCategory = BaseSubCategory.THSR,
                    SpecificationURL = "{0}?area=historical#!/HistoricalTHSRApi/HistoricalTHSRApi_AlertInfo",
                    URL = "{0}/v2/Rail/Historical/THSR/AlertInfo",
                    EnumID = 2406
                }, Detail = GetDetail_THSR()
            };
            yield return new ServiceData {
                Service = new BaseService {
                    FK_BaseDataType = BaseDataType.AvailableSeatStatus,
                    NameZh_tw = "高鐵對號座剩餘座位資訊看板歷史資料",
                    FK_BaseCategory = BaseCategory.Rail,
                    FK_BaseSubCategory = BaseSubCategory.THSR,
                    SpecificationURL = "{0}?area=historical#!/HistoricalTHSRApi/HistoricalTHSRApi_AvailableSeatStatusList",
                    URL = "{0}/v2/Rail/Historical/THSR/AvailableSeatStatusList",
                    EnumID = 2407
                }, Detail = GetDetail_THSR()
            };
            yield return new ServiceData {
                Service = new BaseService {
                    FK_BaseDataType = BaseDataType.LiveBoard,
                    NameZh_tw = "臺鐵列車到離站電子看板歷史資料",
                    FK_BaseCategory = BaseCategory.Rail,
                    FK_BaseSubCategory = BaseSubCategory.TRA,
                    SpecificationURL = "{0}?area=historical#!/HistoricalTRAApi/HistoricalTRAApi_LiveBoard",
                    URL = "{0}/v2/Rail/Historical/TRA/LiveBoard",
                    EnumID = 2408
                }, Detail = GetDetail_TRA()
            };
            yield return new ServiceData {
                Service = new BaseService {
                    FK_BaseDataType = BaseDataType.LiveBoard,
                    NameZh_tw = "臺鐵列車即時準點/延誤時間歷史資料",
                    FK_BaseCategory = BaseCategory.Rail,
                    FK_BaseSubCategory = BaseSubCategory.TRA,
                    SpecificationURL = "{0}?area=historical#!/HistoricalTRAApi/HistoricalTRAApi_LiveTrainDelay",
                    URL = "{0}/v2/Rail/Historical/TRA/LiveTrainDelay",
                    EnumID = 2409
                }, Detail = GetDetail_TRA()
            };
            yield return new ServiceData {
                Service = new BaseService {
                    FK_BaseDataType = BaseDataType.Route,
                    NameZh_tw = "市區公車之路線歷史資料",
                    FK_BaseCategory = BaseCategory.Bus,
                    FK_BaseSubCategory = BaseSubCategory.CityBus,
                    SpecificationURL = "{0}?area=historical#!/HistoricalCityBus/HistoricalCityBus_Route",
                    URL = "{0}/v2/Bus/Historical/Route",
                    EnumID = 2410
                }, Details = GetDetails_CityBus()
            };
            yield return new ServiceData {
                Service = new BaseService {
                    FK_BaseDataType = BaseDataType.Stop,
                    NameZh_tw = "市區公車之站牌歷史資料",
                    FK_BaseCategory = BaseCategory.Bus,
                    FK_BaseSubCategory = BaseSubCategory.CityBus,
                    SpecificationURL = "{0}?area=historical#!/HistoricalCityBus/HistoricalCityBus_Stop",
                    URL = "{0}/v2/Bus/Historical/Stop",
                    EnumID = 2411
                }, Details = GetDetails_CityBus()
            };
            yield return new ServiceData {
                Service = new BaseService {
                    FK_BaseDataType = BaseDataType.Stop,
                    NameZh_tw = "市區公車之站位歷史資料",
                    FK_BaseCategory = BaseCategory.Bus,
                    FK_BaseSubCategory = BaseSubCategory.CityBus,
                    SpecificationURL = "{0}?area=historical#!/HistoricalCityBus/HistoricalCityBus_Station",
                    URL = "{0}/v2/Bus/Historical/Station",
                    EnumID = 2412
                }, Details = GetDetails_CityBus()
            };
            yield return new ServiceData {
                Service = new BaseService {
                    FK_BaseDataType = BaseDataType.StopOfRoute,
                    NameZh_tw = "市區公車之顯示用路線站序歷史資料",
                    FK_BaseCategory = BaseCategory.Bus,
                    FK_BaseSubCategory = BaseSubCategory.CityBus,
                    SpecificationURL = "{0}?area=historical#!/HistoricalCityBus/HistoricalCityBus_DisplayStopOfRoute",
                    URL = "{0}/v2/Bus/Historical/DisplayStopOfRoute",
                    EnumID = 2413
                }, Details = GetDetails_CityBus()
            };
            yield return new ServiceData {
                Service = new BaseService {
                    FK_BaseDataType = BaseDataType.StopOfRoute,
                    NameZh_tw = "市區公車之路線站序歷史資料",
                    FK_BaseCategory = BaseCategory.Bus,
                    FK_BaseSubCategory = BaseSubCategory.CityBus,
                    SpecificationURL = "{0}?area=historical#!/HistoricalCityBus/HistoricalCityBus_StopOfRoute",
                    URL = "{0}/v2/Bus/Historical/StopOfRoute",
                    EnumID = 2414
                }, Details = GetDetails_CityBus()
            };
            yield return new ServiceData {
                Service = new BaseService {
                    FK_BaseDataType = BaseDataType.Schedule,
                    NameZh_tw = "市區公車之路線班表歷史資料",
                    FK_BaseCategory = BaseCategory.Bus,
                    FK_BaseSubCategory = BaseSubCategory.CityBus,
                    SpecificationURL = "{0}?area=historical#!/HistoricalCityBus/HistoricalCityBus_Schedule",
                    URL = "{0}/v2/Bus/Historical/Schedule",
                    EnumID = 2415
                }, Details = GetDetails_CityBus()
            };
            yield return new ServiceData {
                Service = new BaseService {
                    FK_BaseDataType = BaseDataType.Shape,
                    NameZh_tw = "市區公車之線型歷史資料",
                    FK_BaseCategory = BaseCategory.Bus,
                    FK_BaseSubCategory = BaseSubCategory.CityBus,
                    SpecificationURL = "{0}?area=historical#!/HistoricalCityBus/HistoricalCityBus_Shape",
                    URL = "{0}/v2/Bus/Historical/Shape",
                    EnumID = 2416
                }, Details = GetDetails_CityBus()
            };
            #endregion
        }
        public static IEnumerable<string> Insert() {
            foreach (var item in GenerateData()) {
                item.Service.PK_BaseService = Guid.NewGuid();
                item.Service.Version = 2;
                item.Service.IsLiveData = true;
                item.Service.IsHistoricalData = true;
                item.Service.SpecPublishStatus = true;
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
                    d.SpecPublishStatus = true;
                    d.APIPublishStatus = 1;
                    if (item.Service.EnumID == 2413 && !(d.Parameter == "Taipei" || d.Parameter == "NewTaipei")) {
                        d.SpecPublishStatus = false;
                        d.APIPublishStatus = 0;
                    }
                    yield return SqlSL.Insert("BaseServiceDetail", d);
                }

                yield return string.Empty;
            }
        }
    }
}
