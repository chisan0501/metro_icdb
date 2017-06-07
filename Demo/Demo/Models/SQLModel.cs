using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Demo.Models
{
    public class SQLModel
    {

        public class RefrubHistoryObj
        {
            public string is_ssd { get; set; }
            public int asset_tag { get; set; }
            public DateTime time { get; set; }
            public string refurbisher { get; set; }
            public string sku { get; set; }
            public string hdd { get; set; }
            public string ram { get; set; }
            public string model { get; set; }
            public string made { get; set; }
            public string cpu { get; set; }
            public string serial { get; set; }

            public string channel { get; set; }
            public string selected_printer { get; set; }
            public string type { get; set; }
            public string grade { get; set; }
            public string desc { get; set; }
            public string short_desc { get; set; }
            public string create_date { get; set; }
            public string brand { get; set; }
            public string optical_drive { get; set; }
            public string pallet { get; set; }
            //public string asst_tag { get; set; }
            public string pre_coa { get; set; }
            public string software { get; set; }
            public string accessories { get; set; }
            public string soft_desc { get; set; }
            public string ic_cert { get; set; }
            public string cpu_desc { get; set; }
            public string hdd_desc { get; set; }
            public string ram_desc { get; set; }
            public string brand_dropdown { get; set; }
            public string cpu_dropdown { get; set; }
            public string memory_dropdown { get; set; }
            public string hdd_dropdown { get; set; }
            public string listing_title { get; set; }
            public string meta_title { get; set; }
            public string meta_desc { get; set; }
            public string wireless { get; set; }

            //public string grade_string { get; set; }
        }

        public class ProductionLevelByHour
        {
            public string hours { get; set; }
            public int num { get; set; }

        }

        public class LevelByWeek
        {
            public string date { get; set; }
            public string num { get; set; }
        }

        public class PalletData
        {
            public string pallet_name { get; set; }
            public string num { get; set; }
        }

    }


}