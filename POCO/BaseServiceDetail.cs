using System;

namespace Separation.POCO {
    public class BaseServiceDetail {
        public Guid PK_BaseServiceDetail;
        public string ID;
        public Guid FK_BaseService, FK_BaseAuthority;
        public string Parameter, ParamDescription, NameZh_tw;
        public int DataUpdateInterval;
        public int? LatestDataVersion;
        public DateTime? LastDataUpdateTime;
        public DateTime PublishTime, UpdateTime;
        public bool SpecPublishStatus;
        public int APIPublishStatus;
    }
}