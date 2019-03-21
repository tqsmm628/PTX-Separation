using System;
using System.Collections.Generic;
using System.Linq;
using Separation.DataSource;
using Separation.Models;
using Separation.POCO;
using Separation.Services;

namespace Separation.ServiceValues {
    public class HistoricalService {
        private static IEnumerable<ServiceData> GenerateData() {
            yield return new ServiceData {
                Service = new BaseService {
                    FK_BaseDataType = BaseDataType.Schedule,
                    NameZh_tw = "機場航班歷史資料服務",
                    FK_BaseCategory = BaseCategory.Air,
                    SpecificationURL = "{0}#!/HistoricalAirApi/HistoricalAirApi_Airport",
                    URL = "{0}/v2/Air/Historical/FIDS/Airport",
                    EnumID = 2400
                }, Detail = new BaseServiceDetail {
                    ID = "HistoricalAviation_02001",
                    FK_BaseAuthority = BaseAuthority.交通部民用航空局
                }
            };
            yield return new ServiceData {
                Service = new BaseService {
                    FK_BaseDataType = BaseDataType.LiveBoard,
                    NameZh_tw = "航班歷史資料服務",
                    FK_BaseCategory = BaseCategory.Air,
                    SpecificationURL = "{0}#!/HistoricalAirApi/HistoricalAirApi_Flight",
                    URL = "{0}/v2/Air/Historical/FIDS/Flight",
                    EnumID = 2401
                }, Detail = new BaseServiceDetail {
                    ID = "HistoricalAviation_02002",
                    FK_BaseAuthority = BaseAuthority.交通部民用航空局
                }
            };
            yield return new ServiceData {
                Service = new BaseService {
                    FK_BaseDataType = BaseDataType.LivePosition,
                    NameZh_tw = "公車動態定時歷史檔案清單(A1)",
                    FK_BaseCategory = BaseCategory.Bus,
                    SpecificationURL = "{0}#!/HistoricalCityBusApi/HistoricalCityBusApi_RealTimeByFrequency",
                    URL = "{0}/v2/Bus/Historical/RealTimeByFrequency/City/{1}",
                    EnumID = 2402
                }, Details = BaseCity.GetCities().Select((c, i) => new BaseServiceDetail {
                    ID = $"HistoricalCityBus_020{(i+1):D2}",
                    FK_BaseAuthority = c.FK_BaseAuthority,
                    Parameter = c.NameEn,
                    ParamDescription = c.Name,
                })
            };
            yield return new ServiceData {
                Service = new BaseService {
                    FK_BaseDataType = BaseDataType.LiveBoard,
                    NameZh_tw = "公車動態定點歷史檔案清單(A2)",
                    FK_BaseCategory = BaseCategory.Bus,
                    SpecificationURL = "{0}#!/HistoricalCityBusApi/HistoricalCityBusApi_RealTimeNearStop",
                    URL = "{0}/v2/Bus/Historical/RealTimeNearStop/City/{1}",
                    EnumID = 2403
                }, Details = BaseCity.GetCities().Select((c, i) => new BaseServiceDetail {
                    ID = $"HistoricalCityBus_020{(i+23):D2}",
                    FK_BaseAuthority = c.FK_BaseAuthority,
                    Parameter = c.NameEn,
                    ParamDescription = c.Name,
                })
            };
            yield return new ServiceData {
                Service = new BaseService {
                    FK_BaseDataType = BaseDataType.LivePosition,
                    NameZh_tw = "公路客運動態定時歷史檔案清單(A1)",
                    FK_BaseCategory = BaseCategory.Bus,
                    SpecificationURL = "{0}#!/HistoricalInterCityBusApi/HistoricalInterCityBusApi_RealTimeByFrequency",
                    URL = "{0}/v2/Bus/Historical/RealTimeByFrequency/InterCity",
                    EnumID = 2404
                }, Detail = new BaseServiceDetail {
                    ID = "HistoricalInterCityBus_02001",
                    FK_BaseAuthority = BaseAuthority.交通部公路總局
                }
            };
            yield return new ServiceData {
                Service = new BaseService {
                    FK_BaseDataType = BaseDataType.LiveBoard,
                    NameZh_tw = "公路客運動態定點歷史檔案清單(A2)",
                    FK_BaseCategory = BaseCategory.Bus,
                    SpecificationURL = "{0}#!/HistoricalInterCityBusApi/HistoricalInterCityBusApi_RealTimeNearStop",
                    URL = "{0}/v2/Bus/Historical/RealTimeNearStop/InterCity",
                    EnumID = 2405
                }, Detail = new BaseServiceDetail {
                    ID = "HistoricalInterCityBus_02002",
                    FK_BaseAuthority = BaseAuthority.交通部公路總局
                }
            };
            yield return new ServiceData {
                Service = new BaseService {
                    FK_BaseDataType = BaseDataType.Alert,
                    NameZh_tw = "高鐵即時通阻事件歷史資料",
                    FK_BaseCategory = BaseCategory.Rail,
                    FK_BaseSubCategory = BaseSubCategory.THSR,
                    SpecificationURL = "{0}#!/HistoricalTHSRApi/HistoricalTHSRApi_AlertInfo",
                    URL = "{0}/v2/Rail/Historical/THSR/AlertInfo",
                    EnumID = 2406
                }, Detail = new BaseServiceDetail {
                    ID = "HistoricalTHSR_02001",
                    FK_BaseAuthority = BaseAuthority.臺灣高速鐵路股份有限公司
                }
            };
            yield return new ServiceData {
                Service = new BaseService {
                    FK_BaseDataType = BaseDataType.AvailableSeatStatus,
                    NameZh_tw = "高鐵對號座剩餘座位資訊看板歷史資料",
                    FK_BaseCategory = BaseCategory.Rail,
                    FK_BaseSubCategory = BaseSubCategory.THSR,
                    SpecificationURL = "{0}#!/HistoricalTHSRApi/HistoricalTHSRApi_AvailableSeatStatusList",
                    URL = "{0}/v2/Rail/Historical/THSR/AvailableSeatStatusList",
                    EnumID = 2407
                }, Detail = new BaseServiceDetail {
                    ID = "HistoricalTHSR_02002",
                    FK_BaseAuthority = BaseAuthority.臺灣高速鐵路股份有限公司
                }
            };
            yield return new ServiceData {
                Service = new BaseService {
                    FK_BaseDataType = BaseDataType.LiveBoard,
                    NameZh_tw = "臺鐵列車到離站電子看板歷史資料",
                    FK_BaseCategory = BaseCategory.Rail,
                    FK_BaseSubCategory = BaseSubCategory.TRA,
                    SpecificationURL = "{0}#!/HistoricalTRAApi/HistoricalTRAApi_LiveBoard",
                    URL = "{0}/v2/Rail/Historical/TRA/LiveBoard",
                    EnumID = 2408
                }, Detail = new BaseServiceDetail {
                    ID = "HistoricalTRA_02001",
                    FK_BaseAuthority = BaseAuthority.交通部臺灣鐵路管理局
                }
            };
            yield return new ServiceData {
                Service = new BaseService {
                    FK_BaseDataType = BaseDataType.LiveBoard,
                    NameZh_tw = "臺鐵列車即時準點/延誤時間歷史資料",
                    FK_BaseCategory = BaseCategory.Rail,
                    FK_BaseSubCategory = BaseSubCategory.TRA,
                    SpecificationURL = "{0}#!/HistoricalTRAApi/HistoricalTRAApi_LiveTrainDelay",
                    URL = "{0}/v2/Rail/Historical/TRA/LiveTrainDelay",
                    EnumID = 2409
                }, Detail = new BaseServiceDetail {
                    ID = "HistoricalTRA_02002",
                    FK_BaseAuthority = BaseAuthority.交通部臺灣鐵路管理局
                }
            };
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
                    yield return SqlSL.Insert("BaseServiceDetail", d);
                }

                yield return string.Empty;
            }
        }
    }
}
