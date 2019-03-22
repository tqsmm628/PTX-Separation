using System;
using System.Collections.Generic;
using System.Linq;
using Separation.DataSource;
using Separation.Models;
using Separation.POCO;
using Separation.Services;

namespace Separation.ServiceValues {
    public class AdvancedService {
        #region helpers
        private static Func<string> IdGen(string format, int initial = 1) 
            => () => string.Format(format, initial++);
        private static Func<string> AdvCityBusId = IdGen("AdvancedCityBus_02{0:D3}");
        private static Func<string> AdvInterCityBusId = IdGen("AdvancedInterCityBus_02{0:D3}");
        private static IEnumerable<BaseServiceDetail> GetDetailsFromCities(Func<string> Ig) 
            => BaseCity.GetCities().Select(c => new BaseServiceDetail {
                ID = Ig(),
                FK_BaseAuthority = c.FK_BaseAuthority,
                Parameter = c.NameEn,
                ParamDescription = c.Name,
            });
        private static BaseServiceDetail GetDetailFromMOTC(Func<string> Ig)
            => new BaseServiceDetail {
                ID = Ig(),
                FK_BaseAuthority = BaseAuthority.交通部
            };
        private static BaseServiceDetail GetDetailFromTHB()
            => new BaseServiceDetail {
                ID = AdvInterCityBusId(),
                FK_BaseAuthority = BaseAuthority.交通部公路總局
            };
        private static IEnumerable<BaseServiceDetail> GetDetailsForGeoCity() 
            => BaseCity.GetCities().Select(c => new BaseServiceDetail {
                ID = AdvInterCityBusId(),
                FK_BaseAuthority = BaseAuthority.交通部公路總局,
                Parameter = c.NameEn,
                ParamDescription = c.Name
            });
        #endregion

        private static IEnumerable<ServiceData> GenerateData() {
            #region CityBus 2700 ~ 
            #region CityBus, Operator 2700 ~ 2709
            yield return new ServiceData {
                Service = new BaseService {
                    FK_BaseDataType = BaseDataType.LivePosition,
                    NameZh_tw = "特定業者的市區公車動態定時資料(A1)",
                    FK_BaseCategory = BaseCategory.Bus,
                    FK_BaseSubCategory = BaseSubCategory.CityBus,
                    IsLiveData = true,
                    SpecificationURL = "{0}#!/CityBusApi95ByOperatorName/CityBusApi_ByOperatorName_RealTimeByFrequency",
                    URL = "{0}/v2/Bus/RealTimeByFrequency/City/{1}",
                    EnumID = 2700
                }, Details = GetDetailsFromCities(AdvCityBusId)
            };
            yield return new ServiceData {
                Service = new BaseService {
                    FK_BaseDataType = BaseDataType.LiveBoard,
                    NameZh_tw = "特定業者的市區公車動態定點資料(A2)",
                    FK_BaseCategory = BaseCategory.Bus,
                    FK_BaseSubCategory = BaseSubCategory.CityBus,
                    IsLiveData = true,
                    SpecificationURL = "{0}#!/CityBusApi95ByOperatorName/CityBusApi_ByOperatorName_RealTimeNearStop",
                    URL = "{0}/v2/Bus/RealTimeNearStop/City/{1}",
                    EnumID = 2701
                }, Details = GetDetailsFromCities(AdvCityBusId)
            };
            yield return new ServiceData {
                Service = new BaseService {
                    FK_BaseDataType = BaseDataType.LiveBoard,
                    NameZh_tw = "特定業者的市區公車預估到站資料(N1)",
                    FK_BaseCategory = BaseCategory.Bus,
                    FK_BaseSubCategory = BaseSubCategory.CityBus,
                    IsLiveData = true,
                    SpecificationURL = "{0}#!/CityBusApi95ByOperatorName/CityBusApi_ByOperatorName_EstimatedTimeOfArrival",
                    URL = "{0}/v2/Bus/EstimatedTimeOfArrival/City/{1}",
                    EnumID = 2702
                }, Details = GetDetailsFromCities(AdvCityBusId)
            };
            yield return new ServiceData {
                Service = new BaseService {
                    FK_BaseDataType = BaseDataType.Route,
                    NameZh_tw = "特定業者的市區公車路線資料",
                    FK_BaseCategory = BaseCategory.Bus,
                    FK_BaseSubCategory = BaseSubCategory.CityBus,
                    SpecificationURL = "{0}#!/CityBusApi95ByOperatorName/CityBusApi_ByOperatorName_Route",
                    URL = "{0}/v2/Bus/Route/City/{1}",
                    EnumID = 2703
                }, Details = GetDetailsFromCities(AdvCityBusId)
            };
            yield return new ServiceData {
                Service = new BaseService {
                    FK_BaseDataType = BaseDataType.Stop,
                    NameZh_tw = "特定業者的市區公車站牌資料",
                    FK_BaseCategory = BaseCategory.Bus,
                    FK_BaseSubCategory = BaseSubCategory.CityBus,
                    SpecificationURL = "{0}#!/CityBusApi95ByOperatorName/CityBusApi_ByOperatorName_Stop",
                    URL = "{0}/v2/Bus/Stop/City/{1}",
                    EnumID = 2704
                }, Details = GetDetailsFromCities(AdvCityBusId)
            };
            yield return new ServiceData {
                Service = new BaseService {
                    FK_BaseDataType = BaseDataType.Stop,
                    NameZh_tw = "特定業者的市區公車站位資料",
                    FK_BaseCategory = BaseCategory.Bus,
                    FK_BaseSubCategory = BaseSubCategory.CityBus,
                    SpecificationURL = "{0}#!/CityBusApi95ByOperatorName/CityBusApi_ByOperatorName_Station",
                    URL = "{0}/v2/Bus/Station/City/{1}",
                    EnumID = 2705
                }, Details = GetDetailsFromCities(AdvCityBusId)
            };
            yield return new ServiceData {
                Service = new BaseService {
                    FK_BaseDataType = BaseDataType.StopOfRoute,
                    NameZh_tw = "特定業者的市區公車路線站序資料",
                    FK_BaseCategory = BaseCategory.Bus,
                    FK_BaseSubCategory = BaseSubCategory.CityBus,
                    SpecificationURL = "{0}#!/CityBusApi95ByOperatorName/CityBusApi_ByOperatorName_StopOfRoute",
                    URL = "{0}/v2/Bus/StopOfRoute/City/{1}",
                    EnumID = 2706
                }, Details = GetDetailsFromCities(AdvCityBusId)
            };
            yield return new ServiceData {
                Service = new BaseService {
                    FK_BaseDataType = BaseDataType.Schedule,
                    NameZh_tw = "特定業者的市區公車班表資料",
                    FK_BaseCategory = BaseCategory.Bus,
                    FK_BaseSubCategory = BaseSubCategory.CityBus,
                    SpecificationURL = "{0}#!/CityBusApi95ByOperatorName/CityBusApi_ByOperatorName_Schedule",
                    URL = "{0}/v2/Bus/Schedule/City/{1}",
                    EnumID = 2707
                }, Details = GetDetailsFromCities(AdvCityBusId)
            };
            yield return new ServiceData {
                Service = new BaseService {
                    FK_BaseDataType = BaseDataType.Shape,
                    NameZh_tw = "特定業者的市區公車線型資料",
                    FK_BaseCategory = BaseCategory.Bus,
                    FK_BaseSubCategory = BaseSubCategory.CityBus,
                    SpecificationURL = "{0}#!/CityBusApi95ByOperatorName/CityBusApi_ByOperatorName_Shape",
                    URL = "{0}/v2/Bus/Shape/City/{1}",
                    EnumID = 2708
                }, Details = GetDetailsFromCities(AdvCityBusId)
            };
            yield return new ServiceData {
                Service = new BaseService {
                    FK_BaseDataType = BaseDataType.Fare,
                    NameZh_tw = "特定業者的市區公車路線票價資料",
                    FK_BaseCategory = BaseCategory.Bus,
                    FK_BaseSubCategory = BaseSubCategory.CityBus,
                    SpecificationURL = "{0}#!/CityBusApi95ByOperatorName/CityBusApi_ByOperatorName_RouteFare",
                    URL = "{0}/v2/Bus/RouteFare/City/{1}",
                    EnumID = 2709
                }, Details = GetDetailsFromCities(AdvCityBusId)
            };
            #endregion
            #region CityBus, Operator, All 2710 ~ 2719
            yield return new ServiceData {
                Service = new BaseService {
                    FK_BaseDataType = BaseDataType.LivePosition,
                    NameZh_tw = "特定業者的全台市區公車動態定時資料(A1)",
                    FK_BaseCategory = BaseCategory.Bus,
                    FK_BaseSubCategory = BaseSubCategory.CityBus,
                    IsLiveData = true,
                    SpecificationURL = "{0}#!/CityBusApi95ByOperatorName/CityBusApi_ByOperatorName_RealTimeByFrequency_0",
                    URL = "{0}/v2/Bus/RealTimeByFrequency/City",
                    EnumID = 2710
                }, Detail = GetDetailFromMOTC(AdvCityBusId)
            };
            yield return new ServiceData {
                Service = new BaseService {
                    FK_BaseDataType = BaseDataType.LiveBoard,
                    NameZh_tw = "特定業者的全台市區公車動態定點資料(A2)",
                    FK_BaseCategory = BaseCategory.Bus,
                    FK_BaseSubCategory = BaseSubCategory.CityBus,
                    IsLiveData = true,
                    SpecificationURL = "{0}#!/CityBusApi95ByOperatorName/CityBusApi_ByOperatorName_RealTimeNearStop_0",
                    URL = "{0}/v2/Bus/RealTimeNearStop/City",
                    EnumID = 2711
                }, Detail = GetDetailFromMOTC(AdvCityBusId)
            };
            yield return new ServiceData {
                Service = new BaseService {
                    FK_BaseDataType = BaseDataType.LiveBoard,
                    NameZh_tw = "特定業者的全台市區公車預估到站資料(N1)",
                    FK_BaseCategory = BaseCategory.Bus,
                    FK_BaseSubCategory = BaseSubCategory.CityBus,
                    IsLiveData = true,
                    SpecificationURL = "{0}#!/CityBusApi95ByOperatorName/CityBusApi_ByOperatorName_EstimatedTimeOfArrival_0",
                    URL = "{0}/v2/Bus/EstimatedTimeOfArrival/City",
                    EnumID = 2712
                }, Detail = GetDetailFromMOTC(AdvCityBusId)
            };
            yield return new ServiceData {
                Service = new BaseService {
                    FK_BaseDataType = BaseDataType.Route,
                    NameZh_tw = "特定業者的全台市區公車路線資料",
                    FK_BaseCategory = BaseCategory.Bus,
                    FK_BaseSubCategory = BaseSubCategory.CityBus,
                    SpecificationURL = "{0}#!/CityBusApi95ByOperatorName/CityBusApi_ByOperatorName_Route_0",
                    URL = "{0}/v2/Bus/Route/City",
                    EnumID = 2713
                }, Detail = GetDetailFromMOTC(AdvCityBusId)
            };
            yield return new ServiceData {
                Service = new BaseService {
                    FK_BaseDataType = BaseDataType.Stop,
                    NameZh_tw = "特定業者的全台市區公車站牌資料",
                    FK_BaseCategory = BaseCategory.Bus,
                    FK_BaseSubCategory = BaseSubCategory.CityBus,
                    SpecificationURL = "{0}#!/CityBusApi95ByOperatorName/CityBusApi_ByOperatorName_Stop_0",
                    URL = "{0}/v2/Bus/Stop/City",
                    EnumID = 2714
                }, Detail = GetDetailFromMOTC(AdvCityBusId)
            };
            yield return new ServiceData {
                Service = new BaseService {
                    FK_BaseDataType = BaseDataType.Stop,
                    NameZh_tw = "特定業者的全台市區公車站位資料",
                    FK_BaseCategory = BaseCategory.Bus,
                    FK_BaseSubCategory = BaseSubCategory.CityBus,
                    SpecificationURL = "{0}#!/CityBusApi95ByOperatorName/CityBusApi_ByOperatorName_Station_0",
                    URL = "{0}/v2/Bus/Station/City",
                    EnumID = 2715
                }, Detail = GetDetailFromMOTC(AdvCityBusId)
            };
            yield return new ServiceData {
                Service = new BaseService {
                    FK_BaseDataType = BaseDataType.StopOfRoute,
                    NameZh_tw = "特定業者的全台市區公車路線站序資料",
                    FK_BaseCategory = BaseCategory.Bus,
                    FK_BaseSubCategory = BaseSubCategory.CityBus,
                    SpecificationURL = "{0}#!/CityBusApi95ByOperatorName/CityBusApi_ByOperatorName_StopOfRoute_0",
                    URL = "{0}/v2/Bus/StopOfRoute/City",
                    EnumID = 2716
                }, Detail = GetDetailFromMOTC(AdvCityBusId)
            };
            yield return new ServiceData {
                Service = new BaseService {
                    FK_BaseDataType = BaseDataType.Schedule,
                    NameZh_tw = "特定業者的全台市區公車班表資料",
                    FK_BaseCategory = BaseCategory.Bus,
                    FK_BaseSubCategory = BaseSubCategory.CityBus,
                    SpecificationURL = "{0}#!/CityBusApi95ByOperatorName/CityBusApi_ByOperatorName_Schedule_0",
                    URL = "{0}/v2/Bus/Schedule/City",
                    EnumID = 2717
                }, Detail = GetDetailFromMOTC(AdvCityBusId)
            };
            yield return new ServiceData {
                Service = new BaseService {
                    FK_BaseDataType = BaseDataType.Shape,
                    NameZh_tw = "特定業者的全台市區公車線型資料",
                    FK_BaseCategory = BaseCategory.Bus,
                    FK_BaseSubCategory = BaseSubCategory.CityBus,
                    SpecificationURL = "{0}#!/CityBusApi95ByOperatorName/CityBusApi_ByOperatorName_Shape_0",
                    URL = "{0}/v2/Bus/Shape/City",
                    EnumID = 2718
                }, Detail = GetDetailFromMOTC(AdvCityBusId)
            };
            yield return new ServiceData {
                Service = new BaseService {
                    FK_BaseDataType = BaseDataType.Fare,
                    NameZh_tw = "特定業者的全台市區公車路線票價資料",
                    FK_BaseCategory = BaseCategory.Bus,
                    FK_BaseSubCategory = BaseSubCategory.CityBus,
                    SpecificationURL = "{0}#!/CityBusApi95ByOperatorName/CityBusApi_ByOperatorName_RouteFare_0",
                    URL = "{0}/v2/Bus/RouteFare/City",
                    EnumID = 2719
                }, Detail = GetDetailFromMOTC(AdvCityBusId)
            };
            #endregion
            #region CityBus, AtStation 2720 ~ 2727
            yield return new ServiceData {
                Service = new BaseService {
                    FK_BaseDataType = BaseDataType.LivePosition,
                    NameZh_tw = "特定業者的市區公車行經站位動態定時資料(A1)",
                    FK_BaseCategory = BaseCategory.Bus,
                    FK_BaseSubCategory = BaseSubCategory.CityBus,
                    IsLiveData = true,
                    SpecificationURL = "{0}#!/CityBusApi95PassStation/CityBusApi_PassStation_GetRealTimeByFrequency",
                    URL = "{0}/v2/Bus/RealTimeByFrequency/City/{1}",
                    EnumID = 2720
                }, Details = GetDetailsFromCities(AdvCityBusId)
            };
            yield return new ServiceData {
                Service = new BaseService {
                    FK_BaseDataType = BaseDataType.LiveBoard,
                    NameZh_tw = "特定業者的市區公車行經站位動態定點資料(A2)",
                    FK_BaseCategory = BaseCategory.Bus,
                    FK_BaseSubCategory = BaseSubCategory.CityBus,
                    IsLiveData = true,
                    SpecificationURL = "{0}#!/CityBusApi95PassStation/CityBusApi_PassStation_RealTimeNearStop",
                    URL = "{0}/v2/Bus/RealTimeNearStop/City/{1}",
                    EnumID = 2721
                }, Details = GetDetailsFromCities(AdvCityBusId)
            };
            yield return new ServiceData {
                Service = new BaseService {
                    FK_BaseDataType = BaseDataType.LiveBoard,
                    NameZh_tw = "特定業者的市區公車行經站位預估到站資料(N1)",
                    FK_BaseCategory = BaseCategory.Bus,
                    FK_BaseSubCategory = BaseSubCategory.CityBus,
                    IsLiveData = true,
                    SpecificationURL = "{0}#!/CityBusApi95PassStation/CityBusApi_PassStation_EstimatedTimeOfArrival",
                    URL = "{0}/v2/Bus/EstimatedTimeOfArrival/City/{1}",
                    EnumID = 2722
                }, Details = GetDetailsFromCities(AdvCityBusId)
            };
            yield return new ServiceData {
                Service = new BaseService {
                    FK_BaseDataType = BaseDataType.Route,
                    NameZh_tw = "特定業者的市區公車行經站位路線資料",
                    FK_BaseCategory = BaseCategory.Bus,
                    FK_BaseSubCategory = BaseSubCategory.CityBus,
                    SpecificationURL = "{0}#!/CityBusApi95PassStation/CityBusApi_PassStation_Route",
                    URL = "{0}/v2/Bus/Route/City/{1}",
                    EnumID = 2723
                }, Details = GetDetailsFromCities(AdvCityBusId)
            };
            yield return new ServiceData {
                Service = new BaseService {
                    FK_BaseDataType = BaseDataType.Stop,
                    NameZh_tw = "特定業者的市區公車行經站位站牌資料",
                    FK_BaseCategory = BaseCategory.Bus,
                    FK_BaseSubCategory = BaseSubCategory.CityBus,
                    SpecificationURL = "{0}#!/CityBusApi95PassStation/CityBusApi_PassStation_Stop",
                    URL = "{0}/v2/Bus/Stop/City/{1}",
                    EnumID = 2724
                }, Details = GetDetailsFromCities(AdvCityBusId)
            };
            yield return new ServiceData {
                Service = new BaseService {
                    FK_BaseDataType = BaseDataType.StopOfRoute,
                    NameZh_tw = "特定業者的市區公車行經站位路線站序資料",
                    FK_BaseCategory = BaseCategory.Bus,
                    FK_BaseSubCategory = BaseSubCategory.CityBus,
                    SpecificationURL = "{0}#!/CityBusApi95PassStation/CityBusApi_PassStation_StopOfRoute",
                    URL = "{0}/v2/Bus/StopOfRoute/City/{1}",
                    EnumID = 2725
                }, Details = GetDetailsFromCities(AdvCityBusId)
            };
            yield return new ServiceData {
                Service = new BaseService {
                    FK_BaseDataType = BaseDataType.Schedule,
                    NameZh_tw = "特定業者的市區公車行經站位班表資料",
                    FK_BaseCategory = BaseCategory.Bus,
                    FK_BaseSubCategory = BaseSubCategory.CityBus,
                    SpecificationURL = "{0}#!/CityBusApi95PassStation/CityBusApi_PassStation_Schedule",
                    URL = "{0}/v2/Bus/Schedule/City/{1}",
                    EnumID = 2726
                }, Details = GetDetailsFromCities(AdvCityBusId)
            };
            yield return new ServiceData {
                Service = new BaseService {
                    FK_BaseDataType = BaseDataType.Shape,
                    NameZh_tw = "特定業者的市區公車行經站位線型資料",
                    FK_BaseCategory = BaseCategory.Bus,
                    FK_BaseSubCategory = BaseSubCategory.CityBus,
                    SpecificationURL = "{0}#!/CityBusApi95PassStation/CityBusApi_PassStation_Shape",
                    URL = "{0}/v2/Bus/Shape/City/{1}",
                    EnumID = 2727
                }, Details = GetDetailsFromCities(AdvCityBusId)
            };
            #endregion
            #endregion

            #region InterCityBus 2750 ~ 
            #region InterCityBus, Operator 2750 ~ 2758
            yield return new ServiceData {
                Service = new BaseService {
                    FK_BaseDataType = BaseDataType.LivePosition,
                    NameZh_tw = "特定業者的公路客運A1公車定時訊息資料",
                    FK_BaseCategory = BaseCategory.Bus,
                    FK_BaseSubCategory = BaseSubCategory.InterCityBus,
                    IsLiveData = true,
                    SpecificationURL = "{0}#!/InterCityBusApi95ByOperatorName/InterCityBusApi_ByOperatorName_RealTimeByFrequency",
                    URL = "{0}/v2/Bus/RealTimeByFrequency/InterCity",
                    EnumID = 2750
                }, Detail = GetDetailFromTHB()
            };
            yield return new ServiceData {
                Service = new BaseService {
                    FK_BaseDataType = BaseDataType.LiveBoard,
                    NameZh_tw = "特定業者的公路客運A2公車定點訊息資料",
                    FK_BaseCategory = BaseCategory.Bus,
                    FK_BaseSubCategory = BaseSubCategory.InterCityBus,
                    IsLiveData = true,
                    SpecificationURL = "{0}#!/InterCityBusApi95ByOperatorName/InterCityBusApi_ByOperatorName_RealTimeNearStop",
                    URL = "{0}/v2/Bus/RealTimeNearStop/InterCity",
                    EnumID = 2751
                }, Detail = GetDetailFromTHB()
            };
            yield return new ServiceData {
                Service = new BaseService {
                    FK_BaseDataType = BaseDataType.LiveBoard,
                    NameZh_tw = "特定業者的公路客運N1公車動態到站預估時間資料",
                    FK_BaseCategory = BaseCategory.Bus,
                    FK_BaseSubCategory = BaseSubCategory.InterCityBus,
                    IsLiveData = true,
                    SpecificationURL = "{0}#!/InterCityBusApi95ByOperatorName/InterCityBusApi_ByOperatorName_EstimatedTimeOfArrival",
                    URL = "{0}/v2/Bus/EstimatedTimeOfArrival/InterCity",
                    EnumID = 2752
                }, Detail = GetDetailFromTHB()
            };
            yield return new ServiceData {
                Service = new BaseService {
                    FK_BaseDataType = BaseDataType.Route,
                    NameZh_tw = "特定業者的公路客運路線資料",
                    FK_BaseCategory = BaseCategory.Bus,
                    FK_BaseSubCategory = BaseSubCategory.InterCityBus,
                    SpecificationURL = "{0}#!/InterCityBusApi95ByOperatorName/InterCityBusApi_ByOperatorName_Route",
                    URL = "{0}/v2/Bus/Route/InterCity",
                    EnumID = 2753
                }, Detail = GetDetailFromTHB()
            };
            yield return new ServiceData {
                Service = new BaseService {
                    FK_BaseDataType = BaseDataType.Stop,
                    NameZh_tw = "特定業者的公路客運站牌資料",
                    FK_BaseCategory = BaseCategory.Bus,
                    FK_BaseSubCategory = BaseSubCategory.InterCityBus,
                    SpecificationURL = "{0}#!/InterCityBusApi95ByOperatorName/InterCityBusApi_ByOperatorName_Stop",
                    URL = "{0}/v2/Bus/Stop/InterCity",
                    EnumID = 2754
                }, Detail = GetDetailFromTHB()
            };
            yield return new ServiceData {
                Service = new BaseService {
                    FK_BaseDataType = BaseDataType.Stop,
                    NameZh_tw = "特定業者的市區公車站位資料",
                    FK_BaseCategory = BaseCategory.Bus,
                    FK_BaseSubCategory = BaseSubCategory.InterCityBus,
                    SpecificationURL = "{0}#!/InterCityBusApi95ByOperatorName/InterCityBusApi_ByOperatorName_Station",
                    URL = "{0}/v2/Bus/Station/InterCity",
                    EnumID = 2755
                }, Detail = GetDetailFromTHB()
            };
            yield return new ServiceData {
                Service = new BaseService {
                    FK_BaseDataType = BaseDataType.StopOfRoute,
                    NameZh_tw = "特定業者的公路客運路線站序資料",
                    FK_BaseCategory = BaseCategory.Bus,
                    FK_BaseSubCategory = BaseSubCategory.InterCityBus,
                    SpecificationURL = "{0}#!/InterCityBusApi95ByOperatorName/InterCityBusApi_ByOperatorName_StopOfRoute",
                    URL = "{0}/v2/Bus/StopOfRoute/InterCity",
                    EnumID = 2756
                }, Detail = GetDetailFromTHB()
            };
            yield return new ServiceData {
                Service = new BaseService {
                    FK_BaseDataType = BaseDataType.Schedule,
                    NameZh_tw = "特定業者的公路客運時刻表資料",
                    FK_BaseCategory = BaseCategory.Bus,
                    FK_BaseSubCategory = BaseSubCategory.InterCityBus,
                    SpecificationURL = "{0}#!/InterCityBusApi95ByOperatorName/InterCityBusApi_ByOperatorName_Schedule",
                    URL = "{0}/v2/Bus/Schedule/InterCity",
                    EnumID = 2757
                }, Detail = GetDetailFromTHB()
            };
            yield return new ServiceData {
                Service = new BaseService {
                    FK_BaseDataType = BaseDataType.Fare,
                    NameZh_tw = "特定業者的公路客運路線票價資料",
                    FK_BaseCategory = BaseCategory.Bus,
                    FK_BaseSubCategory = BaseSubCategory.InterCityBus,
                    SpecificationURL = "{0}#!/InterCityBusApi95ByOperatorName/InterCityBusApi_ByOperatorName_RouteFare",
                    URL = "{0}/v2/Bus/RouteFare/InterCity",
                    EnumID = 2758
                }, Detail = GetDetailFromTHB()
            };
            #endregion
            #region InterCityBus, GeoCity 2759 ~ 2767
            yield return new ServiceData {
                Service = new BaseService {
                    FK_BaseDataType = BaseDataType.LivePosition,
                    NameZh_tw = "特定行政區域空間範圍內的公路客運A1公車定時訊息資料",
                    FK_BaseCategory = BaseCategory.Bus,
                    FK_BaseSubCategory = BaseSubCategory.InterCityBus,
                    IsLiveData = true,
                    SpecificationURL = "{0}#!/InterCityBusApi95PassCity/InterCityBusApi_PassCity_RealTimeByFrequency",
                    URL = "{0}/v2/Bus/RealTimeByFrequency/GeoCity/{1}",
                    EnumID = 2759
                }, Details = GetDetailsForGeoCity()
            };
            yield return new ServiceData {
                Service = new BaseService {
                    FK_BaseDataType = BaseDataType.LiveBoard,
                    NameZh_tw = "特定行政區域空間範圍內的公路客運A2公車定點訊息資料",
                    FK_BaseCategory = BaseCategory.Bus,
                    FK_BaseSubCategory = BaseSubCategory.InterCityBus,
                    IsLiveData = true,
                    SpecificationURL = "{0}#!/InterCityBusApi95PassCity/InterCityBusApi_PassCity_RealTimeNearStop",
                    URL = "{0}/v2/Bus/RealTimeNearStop/GeoCity/{1}",
                    EnumID = 2760
                }, Details = GetDetailsForGeoCity()
            };
            yield return new ServiceData {
                Service = new BaseService {
                    FK_BaseDataType = BaseDataType.LiveBoard,
                    NameZh_tw = "特定行政區域空間範圍內的公路客運N1公車動態到站預估時間資料",
                    FK_BaseCategory = BaseCategory.Bus,
                    FK_BaseSubCategory = BaseSubCategory.InterCityBus,
                    IsLiveData = true,
                    SpecificationURL = "{0}#!/InterCityBusApi95PassCity/InterCityBusApi_PassCity_EstimatedTimeOfArrival",
                    URL = "{0}/v2/Bus/EstimatedTimeOfArrival/GeoCity/{1}",
                    EnumID = 2761
                }, Details = GetDetailsForGeoCity()
            };
            yield return new ServiceData {
                Service = new BaseService {
                    FK_BaseDataType = BaseDataType.Route,
                    NameZh_tw = "特定行政區域空間範圍內的公路客運路線資料",
                    FK_BaseCategory = BaseCategory.Bus,
                    FK_BaseSubCategory = BaseSubCategory.InterCityBus,
                    SpecificationURL = "{0}#!/InterCityBusApi95PassCity/InterCityBusApi_PassCity_Route",
                    URL = "{0}/v2/Bus/Route/GeoCity/{1}",
                    EnumID = 2762
                }, Details = GetDetailsForGeoCity()
            };
            yield return new ServiceData {
                Service = new BaseService {
                    FK_BaseDataType = BaseDataType.Stop,
                    NameZh_tw = "特定行政區域空間範圍內的公路客運站牌資料",
                    FK_BaseCategory = BaseCategory.Bus,
                    FK_BaseSubCategory = BaseSubCategory.InterCityBus,
                    SpecificationURL = "{0}#!/InterCityBusApi95PassCity/InterCityBusApi_PassCity_Stop",
                    URL = "{0}/v2/Bus/Stop/GeoCity/{1}",
                    EnumID = 2763
                }, Details = GetDetailsForGeoCity()
            };
            yield return new ServiceData {
                Service = new BaseService {
                    FK_BaseDataType = BaseDataType.Stop,
                    NameZh_tw = "特定行政區域空間範圍內的公路客運站位資料",
                    FK_BaseCategory = BaseCategory.Bus,
                    FK_BaseSubCategory = BaseSubCategory.InterCityBus,
                    SpecificationURL = "{0}#!/InterCityBusApi95PassCity/InterCityBusApi_PassCity_Station",
                    URL = "{0}/v2/Bus/Station/GeoCity/{1}",
                    EnumID = 2764
                }, Details = GetDetailsForGeoCity()
            };
            yield return new ServiceData {
                Service = new BaseService {
                    FK_BaseDataType = BaseDataType.StopOfRoute,
                    NameZh_tw = "特定行政區域空間範圍內的公路客運路線站序資料",
                    FK_BaseCategory = BaseCategory.Bus,
                    FK_BaseSubCategory = BaseSubCategory.InterCityBus,
                    SpecificationURL = "{0}#!/InterCityBusApi95PassCity/InterCityBusApi_PassCity_StopOfRoute",
                    URL = "{0}/v2/Bus/StopOfRoute/GeoCity/{1}",
                    EnumID = 2765
                }, Details = GetDetailsForGeoCity()
            };
            yield return new ServiceData {
                Service = new BaseService {
                    FK_BaseDataType = BaseDataType.Schedule,
                    NameZh_tw = "特定行政區域空間範圍內的公路客運時刻表資料",
                    FK_BaseCategory = BaseCategory.Bus,
                    FK_BaseSubCategory = BaseSubCategory.InterCityBus,
                    SpecificationURL = "{0}#!/InterCityBusApi95PassCity/InterCityBusApi_PassCity_Schedule",
                    URL = "{0}/v2/Bus/Schedule/GeoCity/{1}",
                    EnumID = 2766
                }, Details = GetDetailsForGeoCity()
            };
            yield return new ServiceData {
                Service = new BaseService {
                    FK_BaseDataType = BaseDataType.Fare,
                    NameZh_tw = "特定行政區域空間範圍內的公路客運路線票價資料",
                    FK_BaseCategory = BaseCategory.Bus,
                    FK_BaseSubCategory = BaseSubCategory.InterCityBus,
                    SpecificationURL = "{0}#!/InterCityBusApi95PassCity/InterCityBusApi_PassCity_RouteFare",
                    URL = "{0}/v2/Bus/RouteFare/GeoCity/{1}",
                    EnumID = 2767
                }, Details = GetDetailsForGeoCity()
            };
            #endregion
            #region InterCityBus, AtStation 2768 ~ 2775
            yield return new ServiceData {
                Service = new BaseService {
                    FK_BaseDataType = BaseDataType.LivePosition,
                    NameZh_tw = "特定站位的公路客運A1公車定時訊息資料",
                    FK_BaseCategory = BaseCategory.Bus,
                    FK_BaseSubCategory = BaseSubCategory.InterCityBus,
                    IsLiveData = true,
                    SpecificationURL = "{0}#!/InterCityBusApi95PassStation/InterCityBusApi_PassStation_RealTimeByFrequency",
                    URL = "{0}/v2/Bus/RealTimeByFrequency/InterCity",
                    EnumID = 2768
                }, Detail = GetDetailFromTHB()
            };
            yield return new ServiceData {
                Service = new BaseService {
                    FK_BaseDataType = BaseDataType.LiveBoard,
                    NameZh_tw = "特定站位的公路客運A2公車定點訊息資料",
                    FK_BaseCategory = BaseCategory.Bus,
                    FK_BaseSubCategory = BaseSubCategory.InterCityBus,
                    IsLiveData = true,
                    SpecificationURL = "{0}#!/InterCityBusApi95PassStation/InterCityBusApi_PassStation_GetRealTimeNearStop",
                    URL = "{0}/v2/Bus/RealTimeNearStop/InterCity",
                    EnumID = 2769
                }, Detail = GetDetailFromTHB()
            };
            yield return new ServiceData {
                Service = new BaseService {
                    FK_BaseDataType = BaseDataType.LiveBoard,
                    NameZh_tw = "特定站位的公路客運N1公車動態到站預估時間資料",
                    FK_BaseCategory = BaseCategory.Bus,
                    FK_BaseSubCategory = BaseSubCategory.InterCityBus,
                    IsLiveData = true,
                    SpecificationURL = "{0}#!/InterCityBusApi95PassStation/InterCityBusApi_PassStation_EstimatedTimeOfArrival",
                    URL = "{0}/v2/Bus/EstimatedTimeOfArrival/InterCity",
                    EnumID = 2770
                }, Detail = GetDetailFromTHB()
            };
            yield return new ServiceData {
                Service = new BaseService {
                    FK_BaseDataType = BaseDataType.Route,
                    NameZh_tw = "特定站位的公路客運路線資料",
                    FK_BaseCategory = BaseCategory.Bus,
                    FK_BaseSubCategory = BaseSubCategory.InterCityBus,
                    SpecificationURL = "{0}#!/InterCityBusApi95PassStation/InterCityBusApi_PassStation_Route",
                    URL = "{0}/v2/Bus/Route/InterCity",
                    EnumID = 2771
                }, Detail = GetDetailFromTHB()
            };
            yield return new ServiceData {
                Service = new BaseService {
                    FK_BaseDataType = BaseDataType.Stop,
                    NameZh_tw = "特定站位的公路客運站牌資料",
                    FK_BaseCategory = BaseCategory.Bus,
                    FK_BaseSubCategory = BaseSubCategory.InterCityBus,
                    SpecificationURL = "{0}#!/InterCityBusApi95PassStation/InterCityBusApi_PassStation_Stop",
                    URL = "{0}/v2/Bus/Stop/InterCity",
                    EnumID = 2772
                }, Detail = GetDetailFromTHB()
            };
            yield return new ServiceData {
                Service = new BaseService {
                    FK_BaseDataType = BaseDataType.StopOfRoute,
                    NameZh_tw = "特定站位的公路客運路線站序資料",
                    FK_BaseCategory = BaseCategory.Bus,
                    FK_BaseSubCategory = BaseSubCategory.InterCityBus,
                    SpecificationURL = "{0}#!/InterCityBusApi95PassStation/InterCityBusApi_PassStation_StopOfRoute",
                    URL = "{0}/v2/Bus/StopOfRoute/InterCity",
                    EnumID = 2773
                }, Detail = GetDetailFromTHB()
            };
            yield return new ServiceData {
                Service = new BaseService {
                    FK_BaseDataType = BaseDataType.Schedule,
                    NameZh_tw = "特定站位的公路客運時刻表資料",
                    FK_BaseCategory = BaseCategory.Bus,
                    FK_BaseSubCategory = BaseSubCategory.InterCityBus,
                    SpecificationURL = "{0}#!/InterCityBusApi95PassStation/InterCityBusApi_PassStation_Schedule",
                    URL = "{0}/v2/Bus/Schedule/InterCity",
                    EnumID = 2774
                }, Detail = GetDetailFromTHB()
            };
            yield return new ServiceData {
                Service = new BaseService {
                    FK_BaseDataType = BaseDataType.Shape,
                    NameZh_tw = "特定站位的公路客運線型資料",
                    FK_BaseCategory = BaseCategory.Bus,
                    FK_BaseSubCategory = BaseSubCategory.InterCityBus,
                    SpecificationURL = "{0}#!/InterCityBusApi95PassStation/InterCityBusApi_PassStation_Shape",
                    URL = "{0}/v2/Bus/Shape/InterCity",
                    EnumID = 2775
                }, Detail = GetDetailFromTHB()
            };
            #endregion
            #endregion
        }
        public static IEnumerable<string> Insert() {
            foreach (var item in GenerateData()) {
                item.Service.PK_BaseService = Guid.NewGuid();
                item.Service.Version = 2;
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
