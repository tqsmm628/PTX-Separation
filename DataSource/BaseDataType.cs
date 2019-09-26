using System;

namespace Separation.DataSource {
    /// <remark>
    /// select concat("public static readonly Guid ", NameEn_us, " = Guid.Parse(\"", PK_BaseDataType, "\");")
    /// from BaseDataType;
    /// </remark>
    public static class BaseDataType {
        public static readonly Guid Network = Guid.Parse("30dc2fe6-b996-11e8-be8b-00155d63e605");
        public static readonly Guid Stop = Guid.Parse("30dc3333-b996-11e8-be8b-00155d63e605");
        public static readonly Guid Route = Guid.Parse("30dc3448-b996-11e8-be8b-00155d63e605");
        public static readonly Guid Schedule = Guid.Parse("30dc3575-b996-11e8-be8b-00155d63e605");
        public static readonly Guid StopOfRoute = Guid.Parse("30dc36be-b996-11e8-be8b-00155d63e605");
        public static readonly Guid Fare = Guid.Parse("30dc37a9-b996-11e8-be8b-00155d63e605");
        public static readonly Guid Operator = Guid.Parse("30dc38ef-b996-11e8-be8b-00155d63e605");
        public static readonly Guid Vehicle = Guid.Parse("30dc3a1c-b996-11e8-be8b-00155d63e605");
        public static readonly Guid Exit = Guid.Parse("30dc3b19-b996-11e8-be8b-00155d63e605");
        public static readonly Guid Facility = Guid.Parse("30dc3c17-b996-11e8-be8b-00155d63e605");
        public static readonly Guid Alert = Guid.Parse("30dc3cbd-b996-11e8-be8b-00155d63e605");
        public static readonly Guid News = Guid.Parse("30dc3d47-b996-11e8-be8b-00155d63e605");
        public static readonly Guid LivePosition = Guid.Parse("30dc3dc8-b996-11e8-be8b-00155d63e605");
        public static readonly Guid LiveBoard = Guid.Parse("30dc3e4f-b996-11e8-be8b-00155d63e605");
        public static readonly Guid Transfer = Guid.Parse("30dc3ecc-b996-11e8-be8b-00155d63e605");
        public static readonly Guid S2TravelTime = Guid.Parse("30dc3f47-b996-11e8-be8b-00155d63e605");
        public static readonly Guid AvailableSeatStatus = Guid.Parse("30dc3fd2-b996-11e8-be8b-00155d63e605");
        public static readonly Guid StoppingPattern = Guid.Parse("30dc405d-b996-11e8-be8b-00155d63e605");
        public static readonly Guid METAR = Guid.Parse("b87323d3-aeb9-11e9-93f4-005056c00001");
        public static readonly Guid LineNetwork = Guid.Parse("30dc4153-b996-11e8-be8b-00155d63e605");
        public static readonly Guid Provider = Guid.Parse("c4e45ed5-aeb9-11e9-93f4-005056c00001");
        public static readonly Guid Authority = Guid.Parse("c8dda2c3-aeb9-11e9-93f4-005056c00001");
        public static readonly Guid DataVersion = Guid.Parse("ccfdc1c1-aeb9-11e9-93f4-005056c00001");
        public static readonly Guid ScenicSpot = Guid.Parse("d1b0e07d-aeb9-11e9-93f4-005056c00001");
        public static readonly Guid Repast = Guid.Parse("d6b7a7d6-aeb9-11e9-93f4-005056c00001");
        public static readonly Guid Hotel = Guid.Parse("db82f4a3-aeb9-11e9-93f4-005056c00001");
        public static readonly Guid Activity = Guid.Parse("e0a5f48b-aeb9-11e9-93f4-005056c00001");
    }
}