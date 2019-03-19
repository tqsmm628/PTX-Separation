using System;

namespace Separation.DataSource
{
    /// <remark>
    /// select concat("public static readonly Guid ", Code, " = Guid.Parse(\"", PK_BaseCategory, "\");")
    /// from BaseCategory;
    /// </remark>
    public static class BaseCategory
    {
        public static readonly Guid GTFS = Guid.Parse("500df378-c81f-11e8-be8b-00155d63e605");
        public static readonly Guid Bus = Guid.Parse("539cec2d-7def-11e8-be8b-00155d63e605");
        public static readonly Guid Rail = Guid.Parse("53a0a81a-7def-11e8-be8b-00155d63e605");
        public static readonly Guid Air = Guid.Parse("53a4a65b-7def-11e8-be8b-00155d63e605");
        public static readonly Guid Bike = Guid.Parse("53a83881-7def-11e8-be8b-00155d63e605");
        public static readonly Guid Travel = Guid.Parse("53ab7830-7def-11e8-be8b-00155d63e605");
        public static readonly Guid Environment = Guid.Parse("53af78c8-7def-11e8-be8b-00155d63e605");
        public static readonly Guid Ferry = Guid.Parse("53b2ef11-7def-11e8-be8b-00155d63e605");
        public static readonly Guid Basic = Guid.Parse("c3b27583-9275-11e8-be8b-00155d63e605");
    }
}