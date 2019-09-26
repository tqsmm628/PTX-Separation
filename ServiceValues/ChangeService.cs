using System;
using System.Collections.Generic;
using System.Linq;
using Separation.DataSource;
using Separation.Models;
using Separation.POCO;
using Separation.Services;

namespace Separation.ServiceValues {
    public class ChangeService {
        #region helpers
        private static Func<string> IdGen(string format, int initial = 1)
            => () => string.Format(format, initial++);
        private static Func<string> CityBusId = IdGen("ChangeCityBus_02{0:D3}");
        private static Func<string> InterCityBusId = IdGen("ChangeInterCityBus_02{0:D3}");
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
            #region CityBus 2800~2819
            yield return new ServiceData {
                Service = new BaseService {
                    NameZh_tw = "近期市區公車所有版本資訊",
                    FK_BaseCategory = BaseCategory.Bus,
                    FK_BaseSubCategory = BaseSubCategory.CityBus,
					SwaggerOperationID = "RecentChangeCityBusApi_DataVersion", 
					URL = "{0}/v2/Bus/DataVersion/tRecent/to/tLatest/City/{1}",
                    EnumID = 2800
                }, Details = GetDetails_CityBus()
            };
            yield return new ServiceData {
                Service = new BaseService {
                    NameZh_tw = "近期市區公車版本異動資訊",
                    FK_BaseCategory = BaseCategory.Bus,
                    FK_BaseSubCategory = BaseSubCategory.CityBus,
					SwaggerOperationID = "RecentChangeCityBusApi_DiffLog", 
					URL = "{0}/v2/Bus/Change/Compare/DiffLog",
                    EnumID = 2801
                }, Details = GetDetails_CityBus()
            };
            yield return new ServiceData {
                Service = new BaseService {
                    NameZh_tw = "近期市區公車路線異動資料",
                    FK_BaseCategory = BaseCategory.Bus,
                    FK_BaseSubCategory = BaseSubCategory.CityBus,
					SwaggerOperationID = "RecentChangeCityBusApi_Route", 
					URL = "{0}/v2/Bus/Change/Compare/Route",
                    EnumID = 2802
                }, Details = GetDetails_CityBus()
            };
            yield return new ServiceData {
                Service = new BaseService {
                    NameZh_tw = "近期市區公車站位異動資料",
                    FK_BaseCategory = BaseCategory.Bus,
                    FK_BaseSubCategory = BaseSubCategory.CityBus,
					SwaggerOperationID = "RecentChangeCityBusApi_Station", 
					URL = "{0}/v2/Bus/Change/Compare/Station",
                    EnumID = 2803
                }, Details = GetDetails_CityBus()
            };
            yield return new ServiceData {
                Service = new BaseService {
                    NameZh_tw = "近期市區公車站牌異動資料",
                    FK_BaseCategory = BaseCategory.Bus,
                    FK_BaseSubCategory = BaseSubCategory.CityBus,
					SwaggerOperationID = "RecentChangeCityBusApi_Stop", 
					URL = "{0}/v2/Bus/Change/Compare/Stop",
                    EnumID = 2804
                }, Details = GetDetails_CityBus()
            };
            yield return new ServiceData {
                Service = new BaseService {
                    NameZh_tw = "近期市區公車路線站序異動資料",
                    FK_BaseCategory = BaseCategory.Bus,
                    FK_BaseSubCategory = BaseSubCategory.CityBus,
					SwaggerOperationID = "RecentChangeCityBusApi_StopOfRoute", 
					URL = "{0}/v2/Bus/Change/Compare/StopOfRoute",
                    EnumID = 2805
                }, Details = GetDetails_CityBus()
            };
            yield return new ServiceData {
                Service = new BaseService {
                    NameZh_tw = "近期市區公車顯示用路線站序異動資料",
                    FK_BaseCategory = BaseCategory.Bus,
                    FK_BaseSubCategory = BaseSubCategory.CityBus,
					SwaggerOperationID = "RecentChangeCityBusApi_DisplayStopOfRoute", 
					URL = "{0}/v2/Bus/Change/Compare/DisplayStopOfRoute",
                    EnumID = 2806
                }, Details = GetDetails_CityBus()
            };
            yield return new ServiceData {
                Service = new BaseService {
                    NameZh_tw = "近期市區公車路線班表異動資料",
                    FK_BaseCategory = BaseCategory.Bus,
                    FK_BaseSubCategory = BaseSubCategory.CityBus,
					SwaggerOperationID = "RecentChangeCityBusApi_Schedule", 
					URL = "{0}/v2/Bus/Change/Compare/Schedule",
                    EnumID = 2807
                }, Details = GetDetails_CityBus()
            };
            yield return new ServiceData {
                Service = new BaseService {
                    NameZh_tw = "近期市區公車線型異動資料",
                    FK_BaseCategory = BaseCategory.Bus,
                    FK_BaseSubCategory = BaseSubCategory.CityBus,
					SwaggerOperationID = "RecentChangeCityBusApi_Shape", 
					URL = "{0}/v2/Bus/Change/Compare/Shape",
                    EnumID = 2808
                }, Details = GetDetails_CityBus()
            };
            #endregion

            #region InterCityBus 2820~2839
            yield return new ServiceData {
                Service = new BaseService {
                    NameZh_tw = "近期公路客運所有版本資訊",
                    FK_BaseCategory = BaseCategory.Bus,
                    FK_BaseSubCategory = BaseSubCategory.InterCityBus,
					SwaggerOperationID = "RecentChangeInterCityBusApi_DataVersion", 
					URL = "{0}/v2/Bus/DataVersion/tRecent/to/tLatest/InterCity",
                    EnumID = 2820
                }, Detail = GetDetail_InterCityBus()
            };
            yield return new ServiceData {
                Service = new BaseService {
                    NameZh_tw = "近期公路客運版本異動資訊",
                    FK_BaseCategory = BaseCategory.Bus,
                    FK_BaseSubCategory = BaseSubCategory.InterCityBus,
					SwaggerOperationID = "RecentChangeInterCityBusApi_DiffLog", 
					URL = "{0}/v2/Bus/Change/Compare/DiffLog",
                    EnumID = 2821
                }, Detail = GetDetail_InterCityBus()
            };
            yield return new ServiceData {
                Service = new BaseService {
                    NameZh_tw = "近期公路客運路線異動資料",
                    FK_BaseCategory = BaseCategory.Bus,
                    FK_BaseSubCategory = BaseSubCategory.InterCityBus,
					SwaggerOperationID = "RecentChangeInterCityBusApi_Route", 
					URL = "{0}/v2/Bus/Change/Compare/Route",
                    EnumID = 2822
                }, Detail = GetDetail_InterCityBus()
            };
            yield return new ServiceData {
                Service = new BaseService {
                    NameZh_tw = "近期公路客運站牌異動資料",
                    FK_BaseCategory = BaseCategory.Bus,
                    FK_BaseSubCategory = BaseSubCategory.InterCityBus,
					SwaggerOperationID = "RecentChangeInterCityBusApi_Stop", 
					URL = "{0}/v2/Bus/Change/Compare/Stop",
                    EnumID = 2823
                }, Detail = GetDetail_InterCityBus()
            };
            yield return new ServiceData {
                Service = new BaseService {
                    NameZh_tw = "近期公路客運路線站序異動資料",
                    FK_BaseCategory = BaseCategory.Bus,
                    FK_BaseSubCategory = BaseSubCategory.InterCityBus,
					SwaggerOperationID = "RecentChangeInterCityBusApi_StopOfRoute", 
					URL = "{0}/v2/Bus/Change/Compare/StopOfRoute",
                    EnumID = 2824
                }, Detail = GetDetail_InterCityBus()
            };
            yield return new ServiceData {
                Service = new BaseService {
                    NameZh_tw = "近期公路客運路線班表異動資料",
                    FK_BaseCategory = BaseCategory.Bus,
                    FK_BaseSubCategory = BaseSubCategory.InterCityBus,
					SwaggerOperationID = "RecentChangeInterCityBusApi_Schedule", 
					URL = "{0}/v2/Bus/Change/Compare/Schedule",
                    EnumID = 2825
                }, Detail = GetDetail_InterCityBus()
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
                    switch (item.Service.EnumID) {
                        case 2803 when new [] {"Taoyuan", "Taichung", "Tainan", "Keelung", "KinmenCounty", "LienchiangCounty"}.Contains(d.Parameter): {
                            d.SpecPublishStatus = false;
                            d.APIPublishStatus = 0;
                            break;
                        }
                        case 2806 when !new [] {"Taipei", "NewTaipei", "Tainan"}.Contains(d.Parameter): {
                            d.SpecPublishStatus = false;
                            d.APIPublishStatus = 0;
                            break;
                        }
                        case 2807 when new [] {"Taoyuan", "Taichung", "Kaohsiung"}.Contains(d.Parameter): {
                            d.SpecPublishStatus = false;
                            d.APIPublishStatus = 0;
                            break;
                        }
                        case 2808 when !new [] {"Taipei", "NewTaipei", "Taoyuan", "Taichung", "Tainan", "Kaohsiung", "Keelung", "KinmenCounty"}.Contains(d.Parameter): {
                            d.SpecPublishStatus = false;
                            d.APIPublishStatus = 0;
                            break;
                        }
                    }
                    yield return SqlSL.Insert("BaseServiceDetail", d);
                }

                yield return string.Empty;
            }
        }
    }
}
