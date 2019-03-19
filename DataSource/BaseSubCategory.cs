using System;

namespace Separation.DataSource
{
    /// <remark>
    /// select concat("public static readonly Guid ", Code, " = Guid.Parse(\"", PK_BaseSubCategory, "\");")
    /// from BaseSubCategory;
    /// </remark>
    public static class BaseSubCategory
    {
        public static readonly Guid AirQuality = Guid.Parse("376ddd68-9275-11e8-be8b-00155d63e605");
        public static readonly Guid Weather = Guid.Parse("376de11c-9275-11e8-be8b-00155d63e605");
        public static readonly Guid Tourism = Guid.Parse("376de20d-9275-11e8-be8b-00155d63e605");
        public static readonly Guid TaiwanTripBus = Guid.Parse("376de300-9275-11e8-be8b-00155d63e605");
        public static readonly Guid KeelungTransport = Guid.Parse("376de406-9275-11e8-be8b-00155d63e605");
        public static readonly Guid YilanTransport = Guid.Parse("376de4dd-9275-11e8-be8b-00155d63e605");
        public static readonly Guid CityBus = Guid.Parse("f91d93c0-7def-11e8-be8b-00155d63e605");
        public static readonly Guid InterCityBus = Guid.Parse("f920dcd7-7def-11e8-be8b-00155d63e605");
        public static readonly Guid TRA = Guid.Parse("f9242759-7def-11e8-be8b-00155d63e605");
        public static readonly Guid THSR = Guid.Parse("f928c388-7def-11e8-be8b-00155d63e605");
        public static readonly Guid Metro = Guid.Parse("f92bea9a-7def-11e8-be8b-00155d63e605");
    }
}