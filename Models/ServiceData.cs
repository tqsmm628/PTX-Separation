using System.Collections.Generic;
using Separation.POCO;

namespace Separation.Models {
    public class ServiceData {
        public BaseService Service;
        public IEnumerable<BaseServiceDetail> Details;

        public BaseServiceDetail Detail {
            set => Details = new [] {value};
        }
    }
}