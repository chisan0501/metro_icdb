using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Demo.Models
{
    public class SQLModel
    {

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