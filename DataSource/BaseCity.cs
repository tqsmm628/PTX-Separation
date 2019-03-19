using System;

namespace Separation.DataSource {
    /// <remark>
    /// select concat("(\"", c.NameZh_tw, "\", \"", c.NameEn_us, "\", Guid.Parse(\"", a.PK_BaseAuthority, "\")), ")
    /// from BaseCity c
    /// join BaseAuthority a on c.`Code` = a.`Code`
    /// order by c.EnumID;
    /// </remark>
    public static class BaseCity {
        public static(string Name, string NameEn, Guid FK_BaseAuthority) [] GetCities() => new [] {
            ("臺北市", "Taipei", Guid.Parse("d3738578-aa7a-4cfe-bd59-6f7ff78d3e6a")), 
            ("新北市", "NewTaipei", Guid.Parse("43cdd072-3a52-11e7-b355-00155d63e605")), 
            ("桃園市", "Taoyuan", Guid.Parse("cdf55b08-4d03-451e-b1cf-baeff2642da7")), 
            ("臺中市", "Taichung", Guid.Parse("11c147a2-adf2-46bd-a0c5-92151eb7084f")), 
            ("臺南市", "Tainan", Guid.Parse("f3c42b48-a4d6-4d12-9cd9-65afe2c5ecf4")), 
            ("高雄市", "Kaohsiung", Guid.Parse("e9dc2cc3-1863-4438-92ac-de2dcc4a98c4")), 
            ("基隆市", "Keelung", Guid.Parse("2279f9da-d9e3-11e5-ad02-00155d63e605")), 
            ("新竹市", "Hsinchu", Guid.Parse("2da628a0-d9e3-11e5-ad02-00155d63e605")), 
            ("新竹縣", "HsinchuCounty", Guid.Parse("35571388-d9e3-11e5-ad02-00155d63e605")), 
            ("苗栗縣", "MiaoliCounty", Guid.Parse("3d9694e3-d9e3-11e5-ad02-00155d63e605")), 
            ("彰化縣", "ChanghuaCounty", Guid.Parse("4385eae8-d9e3-11e5-ad02-00155d63e605")), 
            ("南投縣", "NantouCounty", Guid.Parse("4ac2ba5d-d9e3-11e5-ad02-00155d63e605")), 
            ("雲林縣", "YunlinCounty", Guid.Parse("51eef66a-d9e3-11e5-ad02-00155d63e605")), 
            ("嘉義縣", "ChiayiCounty", Guid.Parse("58addf6f-d9e3-11e5-ad02-00155d63e605")), 
            ("嘉義市", "Chiayi", Guid.Parse("5fb9c6e3-d9e3-11e5-ad02-00155d63e605")), 
            ("屏東縣", "PingtungCounty", Guid.Parse("66af4d8c-d9e3-11e5-ad02-00155d63e605")), 
            ("宜蘭縣", "YilanCounty", Guid.Parse("6dda40f6-d9e3-11e5-ad02-00155d63e605")), 
            ("花蓮縣", "HualienCounty", Guid.Parse("748f0ba1-d9e3-11e5-ad02-00155d63e605")), 
            ("臺東縣", "TaitungCounty", Guid.Parse("7b6e49f9-d9e3-11e5-ad02-00155d63e605")), 
            ("金門縣", "KinmenCounty", Guid.Parse("8287b18f-d9e3-11e5-ad02-00155d63e605")), 
            ("澎湖縣", "PenghuCounty", Guid.Parse("8932efa4-d9e3-11e5-ad02-00155d63e605")), 
            ("連江縣", "LienchiangCounty", Guid.Parse("901e00f4-d9e3-11e5-ad02-00155d63e605"))
        };
    }
}