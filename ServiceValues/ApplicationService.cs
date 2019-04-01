using System;
using System.Collections.Generic;
using System.Linq;
using Separation.DataSource;
using Separation.Models;
using Separation.POCO;
using Separation.Services;

namespace Separation.ServiceValues {
    public class ApplicationService {
        #region helpers
        private static Func<string> IdGen(string format, int initial = 1) 
            => () => string.Format(format, initial++);
        private static Func<string> AirQualityId = IdGen("AirQuality_02{0:D3}");
        private static Func<string> WeatherId = IdGen("Weather_02{0:D3}");
        private static Func<string> TourismId = IdGen("Tourism_02{0:D3}");
        private static Func<string> TaiwanTripBusId = IdGen("TaiwanTripBus_02{0:D3}");
        private static BaseServiceDetail GetDetail(string ID, Guid FK_BaseAuthority) => new BaseServiceDetail{
            ID = ID, FK_BaseAuthority = FK_BaseAuthority
        };
        private static BaseServiceDetail GetDetail_AirQuality() => GetDetail(AirQualityId(), BaseAuthority.行政院環境保護署);
        private static BaseServiceDetail GetDetail_Weather() => GetDetail(WeatherId(), BaseAuthority.交通部中央氣象局);
        private static BaseServiceDetail GetDetail_Tourism() => GetDetail(TourismId(), BaseAuthority.交通部觀光局);
        private static BaseServiceDetail GetDetail_TaiwanTripBus() => GetDetail(TaiwanTripBusId(), BaseAuthority.交通部觀光局);
        private static IEnumerable<BaseServiceDetail> GetDetails_Tourism(string appendName)
            => BaseCity.GetCities().Select(c => new BaseServiceDetail {
                ID = TourismId(),
                FK_BaseAuthority = BaseAuthority.交通部觀光局,
                Parameter = c.NameEn,
                ParamDescription = c.Name,
                NameZh_tw = $"{c.Name}{appendName}"
            });
        #endregion

        private static IEnumerable<ServiceData> GenerateData() {
            #region PsiInfo 2200~2219
            yield return new ServiceData {
                Service = new BaseService {
                    NameZh_tw = "機場空氣品質資料服務",
                    FK_BaseCategory = BaseCategory.Environment,
                    FK_BaseSubCategory = BaseSubCategory.AirQuality,
                    IsLiveData = true,
                    SpecificationURL = "{0}?area=application#!/PsiInfoApi/PsiInfoApi_Air",
                    URL = "{0}/v2/AirQuality/PsiInfo/Air/Airport",
                    EnumID = 2200
                }, Detail = GetDetail_AirQuality()
            };
            yield return new ServiceData {
                Service = new BaseService {
                    NameZh_tw = "高鐵車站空氣品質資料服務",
                    FK_BaseCategory = BaseCategory.Environment,
                    FK_BaseSubCategory = BaseSubCategory.AirQuality,
                    IsLiveData = true,
                    SpecificationURL = "{0}?area=application#!/PsiInfoApi/PsiInfoApi_THSR",
                    URL = "{0}/v2/AirQuality/PsiInfo/Rail/THSR/Station",
                    EnumID = 2201
                }, Detail = GetDetail_AirQuality()
            };
            yield return new ServiceData {
                Service = new BaseService {
                    NameZh_tw = "臺鐵車站空氣品質資料服務",
                    FK_BaseCategory = BaseCategory.Environment,
                    FK_BaseSubCategory = BaseSubCategory.AirQuality,
                    IsLiveData = true,
                    SpecificationURL = "{0}/v2/AirQuality/PsiInfo/Rail/TRA/Station",
                    URL = "{0}/v2/AirQuality/PsiInfo/Rail/TRA/Station",
                    EnumID = 2202
                }, Detail = GetDetail_AirQuality()
            };
            #endregion
            #region RainInfo 2220~2239
            yield return new ServiceData {
                Service = new BaseService {
                    NameZh_tw = "機場過去1小時雷達定量降雨估計資料服務",
                    FK_BaseCategory = BaseCategory.Environment,
                    FK_BaseSubCategory = BaseSubCategory.Weather,
                    IsLiveData = true,
                    SpecificationURL = "{0}?area=application#!/RainInfoApi/RainInfoApi_AirQPE",
                    URL = "{0}/v2/Weather/RainInfo/QPE/Air/Airport",
                    EnumID = 2220
                }, Detail = GetDetail_Weather()
            };
            yield return new ServiceData {
                Service = new BaseService {
                    NameZh_tw = "高鐵車站過去1小時雷達定量降雨估計資料服務",
                    FK_BaseCategory = BaseCategory.Environment,
                    FK_BaseSubCategory = BaseSubCategory.Weather,
                    IsLiveData = true,
                    SpecificationURL = "{0}?area=application#!/RainInfoApi/RainInfoApi_THSRQPE",
                    URL = "{0}/v2/Weather/RainInfo/QPE/Rail/THSR/Station",
                    EnumID = 2221
                }, Detail = GetDetail_Weather()
            };
            yield return new ServiceData {
                Service = new BaseService {
                    NameZh_tw = "臺鐵車站過去1小時雷達定量降雨估計資料服務",
                    FK_BaseCategory = BaseCategory.Environment,
                    FK_BaseSubCategory = BaseSubCategory.Weather,
                    IsLiveData = true,
                    SpecificationURL = "{0}/v2/Weather/RainInfo/QPE/Rail/TRA/Station",
                    URL = "{0}/v2/Weather/RainInfo/QPE/Rail/TRA/Station",
                    EnumID = 2222
                }, Detail = GetDetail_Weather()
            };
            yield return new ServiceData {
                Service = new BaseService {
                    NameZh_tw = "機場未來1小時雷達定量降雨預報資料服務",
                    FK_BaseCategory = BaseCategory.Environment,
                    FK_BaseSubCategory = BaseSubCategory.Weather,
                    IsLiveData = true,
                    SpecificationURL = "{0}?area=application#!/RainInfoApi/RainInfoApi_AirQPF",
                    URL = "{0}/v2/Weather/RainInfo/QPF/Air/Airport",
                    EnumID = 2223
                }, Detail = GetDetail_Weather()
            };
            yield return new ServiceData {
                Service = new BaseService {
                    NameZh_tw = "高鐵車站未來1小時雷達定量降雨預報資料服務",
                    FK_BaseCategory = BaseCategory.Environment,
                    FK_BaseSubCategory = BaseSubCategory.Weather,
                    IsLiveData = true,
                    SpecificationURL = "{0}?area=application#!/RainInfoApi/RainInfoApi_THSRQPF",
                    URL = "{0}/v2/Weather/RainInfo/QPF/Rail/THSR/Station",
                    EnumID = 2224
                }, Detail = GetDetail_Weather()
            };
            yield return new ServiceData {
                Service = new BaseService {
                    NameZh_tw = "臺鐵車站未來1小時雷達定量降雨預報資料服務",
                    FK_BaseCategory = BaseCategory.Environment,
                    FK_BaseSubCategory = BaseSubCategory.Weather,
                    IsLiveData = true,
                    SpecificationURL = "{0}?area=application#!/RainInfoApi/RainInfoApi_TRAQPF",
                    URL = "{0}/v2/Weather/RainInfo/QPF/Rail/TRA/Station",
                    EnumID = 2225
                }, Detail = GetDetail_Weather()
            };
            #endregion
            #region Tourism 2240~2259
            yield return new ServiceData {
                Service = new BaseService {
                    NameZh_tw = "觀光景點資料服務",
                    FK_BaseCategory = BaseCategory.Travel,
                    FK_BaseSubCategory = BaseSubCategory.Tourism,
                    SpecificationURL = "{0}?area=application#!/TourismApi/TourismApi_ScenicSpot",
                    URL = "{0}/v2/Tourism/ScenicSpot",
                    EnumID = 2240
                }, Detail = GetDetail_Tourism()
            };
            yield return new ServiceData {
                Service = new BaseService {
                    NameZh_tw = "指定縣市觀光景點資料服務",
                    FK_BaseCategory = BaseCategory.Travel,
                    FK_BaseSubCategory = BaseSubCategory.Tourism,
                    SpecificationURL = "{0}?area=application#!/TourismApi/TourismApi_ScenicSpot_0",
                    URL = "{0}/v2/Tourism/ScenicSpot/{1}",
                    EnumID = 2241
                }, Details = GetDetails_Tourism("觀光景點資料服務")
            };
            yield return new ServiceData {
                Service = new BaseService {
                    NameZh_tw = "觀光餐飲資料服務",
                    FK_BaseCategory = BaseCategory.Travel,
                    FK_BaseSubCategory = BaseSubCategory.Tourism,
                    SpecificationURL = "{0}?area=application#!/TourismApi/TourismApi_Restaurant",
                    URL = "{0}/v2/Tourism/Restaurant",
                    EnumID = 2242
                }, Detail = GetDetail_Tourism()
            };
            yield return new ServiceData {
                Service = new BaseService {
                    NameZh_tw = "觀光餐飲資料服務",
                    FK_BaseCategory = BaseCategory.Travel,
                    FK_BaseSubCategory = BaseSubCategory.Tourism,
                    SpecificationURL = "{0}?area=application#!/TourismApi/TourismApi_Restaurant_0",
                    URL = "{0}/v2/Tourism/Restaurant/{1}",
                    EnumID = 2243
                }, Details = GetDetails_Tourism("觀光餐飲資料服務")
            };
            yield return new ServiceData {
                Service = new BaseService {
                    NameZh_tw = "觀光旅宿資料服務",
                    FK_BaseCategory = BaseCategory.Travel,
                    FK_BaseSubCategory = BaseSubCategory.Tourism,
                    SpecificationURL = "{0}?area=application#!/TourismApi/TourismApi_Hotel",
                    URL = "{0}/v2/Tourism/Hotel",
                    EnumID = 2244
                }, Detail = GetDetail_Tourism()
            };
            yield return new ServiceData {
                Service = new BaseService {
                    NameZh_tw = "觀光旅宿資料服務",
                    FK_BaseCategory = BaseCategory.Travel,
                    FK_BaseSubCategory = BaseSubCategory.Tourism,
                    SpecificationURL = "{0}?area=application#!/TourismApi/TourismApi_Hotel_0",
                    URL = "{0}/v2/Tourism/Hotel/{1}",
                    EnumID = 2245
                }, Details = GetDetails_Tourism("觀光旅宿資料服務")
            };
            yield return new ServiceData {
                Service = new BaseService {
                    NameZh_tw = "觀光活動資料服務",
                    FK_BaseCategory = BaseCategory.Travel,
                    FK_BaseSubCategory = BaseSubCategory.Tourism,
                    SpecificationURL = "{0}?area=application#!/TourismApi/TourismApi_Activity",
                    URL = "{0}/v2/Tourism/Activity",
                    EnumID = 2246
                }, Detail = GetDetail_Tourism()
            };
            yield return new ServiceData {
                Service = new BaseService {
                    NameZh_tw = "觀光活動資料服務",
                    FK_BaseCategory = BaseCategory.Travel,
                    FK_BaseSubCategory = BaseSubCategory.Tourism,
                    SpecificationURL = "{0}?area=application#!/TourismApi/TourismApi_Activity_0",
                    URL = "{0}/v2/Tourism/Activity/{1}",
                    EnumID = 2247
                }, Details = GetDetails_Tourism("觀光活動資料服務")
            };
            #endregion
            #region TaiwanTripBus 2260~2289
            yield return new ServiceData {
                Service = new BaseService {
                    FK_BaseDataType = BaseDataType.LivePosition,
                    NameZh_tw = "臺灣好行公車動態定時資料服務(A1)",
                    FK_BaseCategory = BaseCategory.Travel,
                    FK_BaseSubCategory = BaseSubCategory.TaiwanTripBus,
                    IsLiveData = true,
                    SpecificationURL = "{0}?area=application#!/TaiwanTripBusApi/TaiwanTripBusApi_RealTimeByFrequency",
                    URL = "{0}/v2/Bus/RealTimeByFrequency/TaiwanTrip",
                    EnumID = 2260
                }, Detail = GetDetail_TaiwanTripBus()
            };
            yield return new ServiceData {
                Service = new BaseService {
                    FK_BaseDataType = BaseDataType.LiveBoard,
                    NameZh_tw = "臺灣好行公車動態定點資料服務(A2)",
                    FK_BaseCategory = BaseCategory.Travel,
                    FK_BaseSubCategory = BaseSubCategory.TaiwanTripBus,
                    IsLiveData = true,
                    SpecificationURL = "{0}?area=application#!/TaiwanTripBusApi/TaiwanTripBusApi_RealTimeNearStop",
                    URL = "{0}/v2/Bus/RealTimeNearStop/TaiwanTrip",
                    EnumID = 2261
                }, Detail = GetDetail_TaiwanTripBus()
            };
            yield return new ServiceData {
                Service = new BaseService {
                    FK_BaseDataType = BaseDataType.LiveBoard,
                    NameZh_tw = "臺灣好行公車預估到站資料服務(N1)",
                    FK_BaseCategory = BaseCategory.Travel,
                    FK_BaseSubCategory = BaseSubCategory.TaiwanTripBus,
                    IsLiveData = true,
                    SpecificationURL = "{0}?area=application#!/TaiwanTripBusApi/TaiwanTripBusApi_EstimatedTimeOfArrival",
                    URL = "{0}/v2/Bus/EstimatedTimeOfArrival/TaiwanTrip",
                    EnumID = 2262
                }, Detail = GetDetail_TaiwanTripBus()
            };
            yield return new ServiceData {
                Service = new BaseService {
                    FK_BaseDataType = BaseDataType.Route,
                    NameZh_tw = "臺灣好行公車路線資料服務",
                    FK_BaseCategory = BaseCategory.Travel,
                    FK_BaseSubCategory = BaseSubCategory.TaiwanTripBus,
                    SpecificationURL = "{0}?area=application#!/TaiwanTripBusApi/TaiwanTripBusApi_Route",
                    URL = "{0}/v2/Bus/Route/TaiwanTrip",
                    EnumID = 2263
                }, Detail = GetDetail_TaiwanTripBus()
            };
            yield return new ServiceData {
                Service = new BaseService {
                    FK_BaseDataType = BaseDataType.StopOfRoute,
                    NameZh_tw = "臺灣好行公車路線資料服務",
                    FK_BaseCategory = BaseCategory.Travel,
                    FK_BaseSubCategory = BaseSubCategory.TaiwanTripBus,
                    SpecificationURL = "{0}?area=application#!/TaiwanTripBusApi/TaiwanTripBusApi_StopOfRoute",
                    URL = "{0}/v2/Bus/StopOfRoute/TaiwanTrip",
                    EnumID = 2264
                }, Detail = GetDetail_TaiwanTripBus()
            };
            yield return new ServiceData {
                Service = new BaseService {
                    FK_BaseDataType = BaseDataType.Schedule,
                    NameZh_tw = "臺灣好行公車路線班表資料服務",
                    FK_BaseCategory = BaseCategory.Travel,
                    FK_BaseSubCategory = BaseSubCategory.TaiwanTripBus,
                    SpecificationURL = "{0}?area=application#!/TaiwanTripBusApi/TaiwanTripBusApi_Schedule",
                    URL = "{0}/v2/Bus/Schedule/TaiwanTrip",
                    EnumID = 2265
                }, Detail = GetDetail_TaiwanTripBus()
            };
            yield return new ServiceData {
                Service = new BaseService {
                    FK_BaseDataType = BaseDataType.Shape,
                    NameZh_tw = "臺灣好行空間線型資料服務",
                    FK_BaseCategory = BaseCategory.Travel,
                    FK_BaseSubCategory = BaseSubCategory.TaiwanTripBus,
                    SpecificationURL = "{0}?area=application#!/TaiwanTripBusApi/TaiwanTripBusApi_Shape",
                    URL = "{0}/v2/Bus/Shape/TaiwanTrip",
                    EnumID = 2266
                }, Detail = GetDetail_TaiwanTripBus()
            };
            yield return new ServiceData {
                Service = new BaseService {
                    FK_BaseDataType = BaseDataType.S2TravelTime,
                    NameZh_tw = "臺灣好行路線站間旅行時間資料",
                    FK_BaseCategory = BaseCategory.Travel,
                    FK_BaseSubCategory = BaseSubCategory.TaiwanTripBus,
                    SpecificationURL = "{0}?area=application#!/TaiwanTripBusApi/TaiwanTripBusApi_S2TravelTime",
                    URL = "{0}/v2/Bus/S2TravelTime/TaiwanTrip",
                    EnumID = 2267
                }, Detail = GetDetail_TaiwanTripBus()
            };
            yield return new ServiceData {
                Service = new BaseService {
                    FK_BaseDataType = BaseDataType.News,
                    NameZh_tw = "臺灣好行最新消息資料",
                    IsLiveData = true,
                    FK_BaseCategory = BaseCategory.Travel,
                    FK_BaseSubCategory = BaseSubCategory.TaiwanTripBus,
                    SpecificationURL = "{0}?area=application#!/TaiwanTripBusApi/TaiwanTripBusApi_News",
                    URL = "{0}/v2/Bus/News/TaiwanTrip",
                    EnumID = 2268
                }, Detail = GetDetail_TaiwanTripBus()
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
                    yield return SqlSL.Insert("BaseServiceDetail", d);
                }

                yield return string.Empty;
            }
        }
    }
}
