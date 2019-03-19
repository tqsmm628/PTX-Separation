using System;

namespace Separation.DataSource
{
    /// <remark>
    /// select concat("public static readonly Guid ", NameZh_tw, " = Guid.Parse(\"", PK_BaseAuthority, "\");")
    /// from BaseAuthority
    /// order by ID;
    /// </remark>
    public static class BaseAuthority
    {
        public static readonly Guid 交通部臺灣鐵路管理局 = Guid.Parse("c5303b58-793c-46c1-a260-e118a39b2d44");
        public static readonly Guid 臺灣高速鐵路股份有限公司 = Guid.Parse("6751a49b-a928-4fd3-afb0-80505c878793");
        public static readonly Guid 交通部民用航空局 = Guid.Parse("258b3f53-3be8-479f-88dc-9218ed1c4d43");
        public static readonly Guid 臺北市政府交通局 = Guid.Parse("d3738578-aa7a-4cfe-bd59-6f7ff78d3e6a");
        public static readonly Guid 新北市政府交通局 = Guid.Parse("43cdd072-3a52-11e7-b355-00155d63e605");
        public static readonly Guid 桃園市政府交通局 = Guid.Parse("cdf55b08-4d03-451e-b1cf-baeff2642da7");
        public static readonly Guid 臺中市政府交通局 = Guid.Parse("11c147a2-adf2-46bd-a0c5-92151eb7084f");
        public static readonly Guid 臺南市政府交通局 = Guid.Parse("f3c42b48-a4d6-4d12-9cd9-65afe2c5ecf4");
        public static readonly Guid 高雄市政府交通局 = Guid.Parse("e9dc2cc3-1863-4438-92ac-de2dcc4a98c4");
        public static readonly Guid 交通部公路總局 = Guid.Parse("8e251599-5f93-4a2e-8bd7-5f288d749567");
        public static readonly Guid 基隆市政府交通旅遊處 = Guid.Parse("2279f9da-d9e3-11e5-ad02-00155d63e605");
        public static readonly Guid 新竹市政府交通處 = Guid.Parse("2da628a0-d9e3-11e5-ad02-00155d63e605");
        public static readonly Guid 新竹縣政府交通旅遊處 = Guid.Parse("35571388-d9e3-11e5-ad02-00155d63e605");
        public static readonly Guid 苗栗縣政府工務處 = Guid.Parse("3d9694e3-d9e3-11e5-ad02-00155d63e605");
        public static readonly Guid 彰化縣政府工務處 = Guid.Parse("4385eae8-d9e3-11e5-ad02-00155d63e605");
        public static readonly Guid 南投縣政府工務處 = Guid.Parse("4ac2ba5d-d9e3-11e5-ad02-00155d63e605");
        public static readonly Guid 雲林縣政府工務處 = Guid.Parse("51eef66a-d9e3-11e5-ad02-00155d63e605");
        public static readonly Guid 嘉義縣政府建設處 = Guid.Parse("58addf6f-d9e3-11e5-ad02-00155d63e605");
        public static readonly Guid 嘉義市政府交通觀光處 = Guid.Parse("5fb9c6e3-d9e3-11e5-ad02-00155d63e605");
        public static readonly Guid 屏東縣政府城鄉發展處 = Guid.Parse("66af4d8c-d9e3-11e5-ad02-00155d63e605");
        public static readonly Guid 宜蘭縣政府建設處 = Guid.Parse("6dda40f6-d9e3-11e5-ad02-00155d63e605");
        public static readonly Guid 花蓮縣政府建設處 = Guid.Parse("748f0ba1-d9e3-11e5-ad02-00155d63e605");
        public static readonly Guid 臺東縣政府建設處 = Guid.Parse("7b6e49f9-d9e3-11e5-ad02-00155d63e605");
        public static readonly Guid 金門縣政府觀光處 = Guid.Parse("8287b18f-d9e3-11e5-ad02-00155d63e605");
        public static readonly Guid 澎湖縣政府旅遊處 = Guid.Parse("8932efa4-d9e3-11e5-ad02-00155d63e605");
        public static readonly Guid 連江縣政府交通旅遊局 = Guid.Parse("901e00f4-d9e3-11e5-ad02-00155d63e605");
        public static readonly Guid 臺北市政府捷運工程局 = Guid.Parse("969c6323-d9e3-11e5-ad02-00155d63e605");
        public static readonly Guid 高雄市政府捷運工程局 = Guid.Parse("9da9afd6-d9e3-11e5-ad02-00155d63e605");
        public static readonly Guid 交通部公路總局高雄市區監理所 = Guid.Parse("2eaf334e-0b89-11e6-9b45-00155d63e605");
        public static readonly Guid 交通部公路總局高雄區監理所 = Guid.Parse("38928a3e-0b89-11e6-9b45-00155d63e605");
        public static readonly Guid 交通部公路總局新竹區監理所 = Guid.Parse("3d51701b-0b89-11e6-9b45-00155d63e605");
        public static readonly Guid 交通部公路總局嘉義區監理所 = Guid.Parse("4242deb3-0b89-11e6-9b45-00155d63e605");
        public static readonly Guid 交通部公路總局臺中區監理所 = Guid.Parse("488d5156-0b89-11e6-9b45-00155d63e605");
        public static readonly Guid 交通部公路總局臺北市區監理所 = Guid.Parse("4d7fcd3c-0b89-11e6-9b45-00155d63e605");
        public static readonly Guid 交通部公路總局臺北區監理所 = Guid.Parse("52338e16-0b89-11e6-9b45-00155d63e605");
        public static readonly Guid 交通部中央氣象局 = Guid.Parse("44b0521f-8a00-11e6-8987-00155d63e605");
        public static readonly Guid 行政院環境保護署 = Guid.Parse("44c3f16e-8a00-11e6-8987-00155d63e605");
        public static readonly Guid 交通部觀光局 = Guid.Parse("44c64346-8a00-11e6-8987-00155d63e605");
        public static readonly Guid 交通部 = Guid.Parse("1b770dab-94b5-11e8-be8b-00155d63e605");
        public static readonly Guid 桃園市政府捷運工程處 = Guid.Parse("e10b8473-0ad8-11e7-bc59-00155d63e605");
    }
}