using System;

namespace Separation.POCO {
    public class BaseService {
        public Guid PK_BaseService;
        public Guid? FK_BaseDataType;
        public int Version;
        public string NameZh_tw;
        public Guid FK_BaseCategory;
        public Guid? FK_BaseSubCategory;
        public bool IsLiveData, IsHistoricalData;
        public string SwaggerOperationID, ParamName, URL, URL_Web;
        public int EnumID;
        public bool SpecPublishStatus;
        public int APIPublishStatus;
    }
}