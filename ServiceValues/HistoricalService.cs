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
        private static Func<string> BikeId = IdGen("HistoricalBike_02{0:D3}");
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

        private static IEnumerable<BaseServiceDetail> GetDetails_Bike()
            => BaseCity.GetCities().Where(city => BikeCities.Contains(city.NameEn))
            .Select(c => new BaseServiceDetail {
                ID = BikeId(),
                FK_BaseAuthority = c.FK_BaseAuthority,
                Parameter = c.NameEn,
                ParamDescription = c.Name
            });
    
        private static string[] BikeCities = {
            "ChanghuaCounty", "Hsinchu", "Kaohsiung", "MiaoliCounty", "NewTaipei",
            "PingtungCounty", "Taichung", "Tainan", "Taipei", "Taoyuan"
        };
        #endregion

        private static IEnumerable<ServiceData> GenerateData() {
            #region historical 2400~2420
            yield return new ServiceData {
                Service = new BaseService {
                    FK_BaseDataType = BaseDataType.Schedule,
                    NameZh_tw = "機場航班歷史資料服務",
                    FK_BaseCategory = BaseCategory.Air,
					SwaggerOperationID = "HistoricalAirApi_Airport",
					URL = "v{Version}/Historical/Air/FIDS/Airport",
                    EnumID = 2400
                }, Detail = GetDetail_Air()
            };
            yield return new ServiceData {
                Service = new BaseService {
                    FK_BaseDataType = BaseDataType.LiveBoard,
                    NameZh_tw = "航班歷史資料服務",
                    FK_BaseCategory = BaseCategory.Air,
					SwaggerOperationID = "HistoricalAirApi_Flight",
					URL = "v{Version}/Historical/Air/FIDS/Flight",
                    EnumID = 2401
                }, Detail = GetDetail_Air()
            };
            yield return new ServiceData {
                Service = new BaseService {
                    FK_BaseDataType = BaseDataType.LivePosition,
                    NameZh_tw = "公車動態定時歷史檔案清單(A1)",
                    FK_BaseCategory = BaseCategory.Bus,
                    FK_BaseSubCategory = BaseSubCategory.CityBus,
					SwaggerOperationID = "HistoricalCityBusApi_RealTimeByFrequency",
                    ParamName = "City",
					URL = "v{Version}/Historical/Bus/RealTimeByFrequency/City/{City}",
                    EnumID = 2402
                }, Details = GetDetails_CityBus()
            };
            yield return new ServiceData {
                Service = new BaseService {
                    FK_BaseDataType = BaseDataType.LiveBoard,
                    NameZh_tw = "公車動態定點歷史檔案清單(A2)",
                    FK_BaseCategory = BaseCategory.Bus,
                    FK_BaseSubCategory = BaseSubCategory.CityBus,
					SwaggerOperationID = "HistoricalCityBusApi_RealTimeNearStop",
                    ParamName = "City",
					URL = "v{Version}/Historical/Bus/RealTimeNearStop/City/{City}",
                    EnumID = 2403
                }, Details = GetDetails_CityBus()
            };
            yield return new ServiceData {
                Service = new BaseService {
                    FK_BaseDataType = BaseDataType.LivePosition,
                    NameZh_tw = "公路客運動態定時歷史檔案清單(A1)",
                    FK_BaseCategory = BaseCategory.Bus,
                    FK_BaseSubCategory = BaseSubCategory.InterCityBus,
					SwaggerOperationID = "HistoricalInterCityBusApi_RealTimeByFrequency",
					URL = "v{Version}/Historical/Bus/RealTimeByFrequency/InterCity",
                    EnumID = 2404
                }, Detail = GetDetail_InterCityBus()
            };
            yield return new ServiceData {
                Service = new BaseService {
                    FK_BaseDataType = BaseDataType.LiveBoard,
                    NameZh_tw = "公路客運動態定點歷史檔案清單(A2)",
                    FK_BaseCategory = BaseCategory.Bus,
                    FK_BaseSubCategory = BaseSubCategory.InterCityBus,
					SwaggerOperationID = "HistoricalInterCityBusApi_RealTimeNearStop",
					URL = "v{Version}/Historical/Bus/RealTimeNearStop/InterCity",
                    EnumID = 2405
                }, Detail = GetDetail_InterCityBus()
            };
            yield return new ServiceData {
                Service = new BaseService {
                    FK_BaseDataType = BaseDataType.Alert,
                    NameZh_tw = "高鐵即時通阻事件歷史資料",
                    FK_BaseCategory = BaseCategory.Rail,
                    FK_BaseSubCategory = BaseSubCategory.THSR,
					SwaggerOperationID = "HistoricalTHSRApi_AlertInfo",
					URL = "v{Version}/Historical/Rail/THSR/AlertInfo",
                    EnumID = 2406
                }, Detail = GetDetail_THSR()
            };
            yield return new ServiceData {
                Service = new BaseService {
                    FK_BaseDataType = BaseDataType.AvailableSeatStatus,
                    NameZh_tw = "高鐵對號座剩餘座位資訊看板歷史資料",
                    FK_BaseCategory = BaseCategory.Rail,
                    FK_BaseSubCategory = BaseSubCategory.THSR,
					SwaggerOperationID = "HistoricalTHSRApi_AvailableSeatStatusList",
					URL = "v{Version}/Historical/Rail/THSR/AvailableSeatStatusList",
                    EnumID = 2407
                }, Detail = GetDetail_THSR()
            };
            yield return new ServiceData {
                Service = new BaseService {
                    FK_BaseDataType = BaseDataType.LiveBoard,
                    NameZh_tw = "臺鐵列車到離站電子看板歷史資料",
                    FK_BaseCategory = BaseCategory.Rail,
                    FK_BaseSubCategory = BaseSubCategory.TRA,
					SwaggerOperationID = "HistoricalTRAApi_LiveBoard",
					URL = "v{Version}/Historical/Rail/TRA/LiveBoard",
                    EnumID = 2408
                }, Detail = GetDetail_TRA()
            };
            yield return new ServiceData {
                Service = new BaseService {
                    FK_BaseDataType = BaseDataType.LiveBoard,
                    NameZh_tw = "臺鐵列車即時準點/延誤時間歷史資料",
                    FK_BaseCategory = BaseCategory.Rail,
                    FK_BaseSubCategory = BaseSubCategory.TRA,
					SwaggerOperationID = "HistoricalTRAApi_LiveTrainDelay",
					URL = "v{Version}/Historical/Rail/TRA/LiveTrainDelay",
                    EnumID = 2409
                }, Detail = GetDetail_TRA()
            };
            yield return new ServiceData {
                Service = new BaseService {
                    FK_BaseDataType = BaseDataType.DataVersion,
                    NameZh_tw = "市區公車版本資訊歷史資料",
                    FK_BaseCategory = BaseCategory.Bus,
                    FK_BaseSubCategory = BaseSubCategory.CityBus,
					SwaggerOperationID = "HistoricalCityBusApi_DataVersion",
                    ParamName = "City",
					URL = "v{Version}/Historical/Bus/DataVersion/All/City/{City}",
                    EnumID = 2410
                }, Details = GetDetails_CityBus()
            };
            yield return new ServiceData {
                Service = new BaseService {
                    FK_BaseDataType = BaseDataType.DataVersion,
                    NameZh_tw = "市區公車版本資訊歷史資料(月)",
                    FK_BaseCategory = BaseCategory.Bus,
                    FK_BaseSubCategory = BaseSubCategory.CityBus,
					SwaggerOperationID = "HistoricalCityBusApi_DataVersion_Month",
                    ParamName = "City",
					URL = "v{Version}/Historical/Bus/DataVersion/YearMonth/{YearMonth}/City/{City}",
                    EnumID = 2411
                }, Details = GetDetails_CityBus()
            };
            yield return new ServiceData {
                Service = new BaseService {
                    FK_BaseDataType = BaseDataType.DataVersion,
                    NameZh_tw = "市區公車版本資訊歷史資料(日)",
                    FK_BaseCategory = BaseCategory.Bus,
                    FK_BaseSubCategory = BaseSubCategory.CityBus,
					SwaggerOperationID = "HistoricalCityBusApi_DataVersion_Date",
                    ParamName = "City",
					URL = "v{Version}/Historical/Bus/DataVersion/Date/{Date}/City/{City}",
                    EnumID = 2412
                }, Details = GetDetails_CityBus()
            };
            yield return new ServiceData {
                Service = new BaseService {
                    FK_BaseDataType = BaseDataType.Operator,
                    NameZh_tw = "市區公車營運業者歷史資料",
                    FK_BaseCategory = BaseCategory.Bus,
                    FK_BaseSubCategory = BaseSubCategory.CityBus,
					SwaggerOperationID = "HistoricalCityBusApi_Operator",
                    ParamName = "City",
					URL = "v{Version}/Historical/Bus/Operator/v{DataVersion}/City/{City}",
                    EnumID = 2413
                }, Details = GetDetails_CityBus()
            };
            yield return new ServiceData {
                Service = new BaseService {
                    FK_BaseDataType = BaseDataType.Route,
                    NameZh_tw = "市區公車路線歷史資料",
                    FK_BaseCategory = BaseCategory.Bus,
                    FK_BaseSubCategory = BaseSubCategory.CityBus,
					SwaggerOperationID = "HistoricalCityBusApi_Route",
                    ParamName = "City",
					URL = "v{Version}/Historical/Bus/Route/v{DataVersion}/City/{City}",
                    EnumID = 2414
                }, Details = GetDetails_CityBus()
            };
            yield return new ServiceData {
                Service = new BaseService {
                    FK_BaseDataType = BaseDataType.Stop,
                    NameZh_tw = "市區公車站牌歷史資料",
                    FK_BaseCategory = BaseCategory.Bus,
                    FK_BaseSubCategory = BaseSubCategory.CityBus,
					SwaggerOperationID = "HistoricalCityBusApi_Stop",
                    ParamName = "City",
					URL = "v{Version}/Historical/Bus/Stop/v{DataVersion}/City/{City}",
                    EnumID = 2415
                }, Details = GetDetails_CityBus()
            };
            yield return new ServiceData {
                Service = new BaseService {
                    FK_BaseDataType = BaseDataType.Stop,
                    NameZh_tw = "市區公車站位歷史資料",
                    FK_BaseCategory = BaseCategory.Bus,
                    FK_BaseSubCategory = BaseSubCategory.CityBus,
					SwaggerOperationID = "HistoricalCityBusApi_Station",
                    ParamName = "City",
					URL = "v{Version}/Historical/Bus/Station/v{DataVersion}/City/{City}",
                    EnumID = 2416
                }, Details = GetDetails_CityBus()
            };
            yield return new ServiceData {
                Service = new BaseService {
                    FK_BaseDataType = BaseDataType.Stop,
                    NameZh_tw = "市區公車站名碼歷史資料",
                    FK_BaseCategory = BaseCategory.Bus,
                    FK_BaseSubCategory = BaseSubCategory.CityBus,
					SwaggerOperationID = "HistoricalCityBusApi_StationName",
                    ParamName = "City",
					URL = "v{Version}/Historical/Bus/StationName/v{DataVersion}/City/{City}",
                    EnumID = 2417
                }, Details = GetDetails_CityBus()
            };
            yield return new ServiceData {
                Service = new BaseService {
                    FK_BaseDataType = BaseDataType.StopOfRoute,
                    NameZh_tw = "市區公車顯示用路線站序歷史資料",
                    FK_BaseCategory = BaseCategory.Bus,
                    FK_BaseSubCategory = BaseSubCategory.CityBus,
					SwaggerOperationID = "HistoricalCityBusApi_DisplayStopOfRoute",
                    ParamName = "City",
					URL = "v{Version}/Historical/Bus/DisplayStopOfRoute/v{DataVersion}/City/{City}",
                    EnumID = 2418
                }, Details = GetDetails_CityBus()
            };
            yield return new ServiceData {
                Service = new BaseService {
                    FK_BaseDataType = BaseDataType.StopOfRoute,
                    NameZh_tw = "市區公車路線站序歷史資料",
                    FK_BaseCategory = BaseCategory.Bus,
                    FK_BaseSubCategory = BaseSubCategory.CityBus,
					SwaggerOperationID = "HistoricalCityBusApi_StopOfRoute",
                    ParamName = "City",
					URL = "v{Version}/Historical/Bus/StopOfRoute/v{DataVersion}/City/{City}",
                    EnumID = 2419
                }, Details = GetDetails_CityBus()
            };
            yield return new ServiceData {
                Service = new BaseService {
                    FK_BaseDataType = BaseDataType.Schedule,
                    NameZh_tw = "市區公車路線班表歷史資料",
                    FK_BaseCategory = BaseCategory.Bus,
                    FK_BaseSubCategory = BaseSubCategory.CityBus,
					SwaggerOperationID = "HistoricalCityBusApi_Schedule",
                    ParamName = "City",
					URL = "v{Version}/Historical/Bus/Schedule/v{DataVersion}/City/{City}",
                    EnumID = 2420
                }, Details = GetDetails_CityBus()
            };
            yield return new ServiceData {
                Service = new BaseService {
                    FK_BaseDataType = BaseDataType.Route,
                    NameZh_tw = "市區公車線型歷史資料",
                    FK_BaseCategory = BaseCategory.Bus,
                    FK_BaseSubCategory = BaseSubCategory.CityBus,
					SwaggerOperationID = "HistoricalCityBusApi_Shape",
                    ParamName = "City",
					URL = "v{Version}/Historical/Bus/Shape/v{DataVersion}/City/{City}",
                    EnumID = 2421
                }, Details = GetDetails_CityBus()
            };
            yield return new ServiceData {
                Service = new BaseService {
                    FK_BaseDataType = BaseDataType.Fare,
                    NameZh_tw = "市區公車路線票價歷史資料",
                    FK_BaseCategory = BaseCategory.Bus,
                    FK_BaseSubCategory = BaseSubCategory.CityBus,
					SwaggerOperationID = "HistoricalCityBusApi_RouteFare",
                    ParamName = "City",
					URL = "v{Version}/Historical/Bus/RouteFare/v{DataVersion}/City/{City}",
                    EnumID = 2422
                }, Details = GetDetails_CityBus()
            };
            yield return new ServiceData {
                Service = new BaseService {
                    FK_BaseDataType = BaseDataType.DataVersion,
                    NameZh_tw = "公路客運版本資訊歷史資料",
                    FK_BaseCategory = BaseCategory.Bus,
                    FK_BaseSubCategory = BaseSubCategory.InterCityBus,
					SwaggerOperationID = "HistoricalInterCityBusApi_DataVersion",
					URL = "v{Version}/Historical/Bus/DataVersion/All/InterCity",
                    EnumID = 2423
                }, Detail = GetDetail_InterCityBus()
            };
            yield return new ServiceData {
                Service = new BaseService {
                    FK_BaseDataType = BaseDataType.DataVersion,
                    NameZh_tw = "公路客運版本資訊歷史資料(月)",
                    FK_BaseCategory = BaseCategory.Bus,
                    FK_BaseSubCategory = BaseSubCategory.InterCityBus,
					SwaggerOperationID = "HistoricalInterCityBusApi_DataVersion_Month",
					URL = "v{Version}/Historical/Bus/DataVersion/YearMonth/{YearMonth}/InterCity",
                    EnumID = 2424
                }, Detail = GetDetail_InterCityBus()
            };
            yield return new ServiceData {
                Service = new BaseService {
                    FK_BaseDataType = BaseDataType.DataVersion,
                    NameZh_tw = "公路客運版本資訊歷史資料(日)",
                    FK_BaseCategory = BaseCategory.Bus,
                    FK_BaseSubCategory = BaseSubCategory.InterCityBus,
					SwaggerOperationID = "HistoricalInterCityBusApi_DataVersion_Date",
					URL = "v{Version}/Historical/Bus/DataVersion/Date/{Date}/InterCity",
                    EnumID = 2425
                }, Detail = GetDetail_InterCityBus()
            };
            yield return new ServiceData {
                Service = new BaseService {
                    FK_BaseDataType = BaseDataType.Operator,
                    NameZh_tw = "公路客運營運業者歷史資料",
                    FK_BaseCategory = BaseCategory.Bus,
                    FK_BaseSubCategory = BaseSubCategory.InterCityBus,
					SwaggerOperationID = "HistoricalInterCityBusApi_Operator",
					URL = "v{Version}/Historical/Bus/Operator/v{DataVersion}/InterCity",
                    EnumID = 2426
                }, Detail = GetDetail_InterCityBus()
            };
            yield return new ServiceData {
                Service = new BaseService {
                    FK_BaseDataType = BaseDataType.Route,
                    NameZh_tw = "公路客運路線歷史資料",
                    FK_BaseCategory = BaseCategory.Bus,
                    FK_BaseSubCategory = BaseSubCategory.InterCityBus,
					SwaggerOperationID = "HistoricalInterCityBusApi_Route",
					URL = "v{Version}/Historical/Bus/Route/v{DataVersion}/InterCity",
                    EnumID = 2427
                }, Detail = GetDetail_InterCityBus()
            };
            yield return new ServiceData {
                Service = new BaseService {
                    FK_BaseDataType = BaseDataType.Stop,
                    NameZh_tw = "公路客運站牌歷史資料",
                    FK_BaseCategory = BaseCategory.Bus,
                    FK_BaseSubCategory = BaseSubCategory.InterCityBus,
					SwaggerOperationID = "HistoricalInterCityBusApi_Stop",
					URL = "v{Version}/Historical/Bus/Stop/v{DataVersion}/InterCity",
                    EnumID = 2428
                }, Detail = GetDetail_InterCityBus()
            };
            yield return new ServiceData {
                Service = new BaseService {
                    FK_BaseDataType = BaseDataType.Stop,
                    NameZh_tw = "公路客運站位歷史資料",
                    FK_BaseCategory = BaseCategory.Bus,
                    FK_BaseSubCategory = BaseSubCategory.InterCityBus,
					SwaggerOperationID = "HistoricalInterCityBusApi_Station",
					URL = "v{Version}/Historical/Bus/Station/v{DataVersion}/InterCity",
                    EnumID = 2429
                }, Detail = GetDetail_InterCityBus()
            };
            yield return new ServiceData {
                Service = new BaseService {
                    FK_BaseDataType = BaseDataType.Stop,
                    NameZh_tw = "公路客運站名碼歷史資料",
                    FK_BaseCategory = BaseCategory.Bus,
                    FK_BaseSubCategory = BaseSubCategory.InterCityBus,
					SwaggerOperationID = "HistoricalInterCityBusApi_StationName",
					URL = "v{Version}/Historical/Bus/StationName/v{DataVersion}/InterCity",
                    EnumID = 2430
                }, Detail = GetDetail_InterCityBus()
            };
            yield return new ServiceData {
                Service = new BaseService {
                    FK_BaseDataType = BaseDataType.StopOfRoute,
                    NameZh_tw = "公路客運路線站牌歷史資料",
                    FK_BaseCategory = BaseCategory.Bus,
                    FK_BaseSubCategory = BaseSubCategory.InterCityBus,
					SwaggerOperationID = "HistoricalInterCityBusApi_StopOfRoute",
					URL = "v{Version}/Historical/Bus/StopOfRoute/v{DataVersion}/InterCity",
                    EnumID = 2431
                }, Detail = GetDetail_InterCityBus()
            };
            yield return new ServiceData {
                Service = new BaseService {
                    FK_BaseDataType = BaseDataType.Schedule,
                    NameZh_tw = "公路客運路線班表歷史資料",
                    FK_BaseCategory = BaseCategory.Bus,
                    FK_BaseSubCategory = BaseSubCategory.InterCityBus,
					SwaggerOperationID = "HistoricalInterCityBusApi_Schedule",
					URL = "v{Version}/Historical/Bus/Schedule/v{DataVersion}/InterCity",
                    EnumID = 2432
                }, Detail = GetDetail_InterCityBus()
            };
            yield return new ServiceData {
                Service = new BaseService {
                    FK_BaseDataType = BaseDataType.Fare,
                    NameZh_tw = "公路客運路線票價歷史資料",
                    FK_BaseCategory = BaseCategory.Bus,
                    FK_BaseSubCategory = BaseSubCategory.InterCityBus,
					SwaggerOperationID = "HistoricalInterCityBusApi_RouteFare",
					URL = "v{Version}/Historical/Bus/RouteFare/v{DataVersion}/InterCity",
                    EnumID = 2433
                }, Detail = GetDetail_InterCityBus()
            };
            #endregion
        }
        public static IEnumerable<string> Insert() {
            foreach (var item in GenerateData().ToList().Where(x => 2400 <= x.Service.EnumID && x.Service.EnumID <= 2449)) {
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
                    // if (item.Service.EnumID == 2413 && !(d.Parameter == "Taipei" || d.Parameter == "NewTaipei")) {
                    //     d.SpecPublishStatus = false;
                    //     d.APIPublishStatus = 0;
                    // }
                    yield return SqlSL.Insert("BaseServiceDetail", d);
                }

                yield return string.Empty;
            }
        }
    }
}
