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
        public static readonly Guid Shape = Guid.Parse("30dc40da-b996-11e8-be8b-00155d63e605");
        public static readonly Guid LineNetwork = Guid.Parse("30dc4153-b996-11e8-be8b-00155d63e605");
    }
}