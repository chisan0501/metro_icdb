using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Demo.Models
{
    public class LabelModel
    {



      
        public class magento_brand
        {
            public string name { get; set; }
            public string dropdown_value { get; set; }

        }

        public class grade
        {
            public string value { get; set; }
            public string name { get; set; }
        }

        public class magento_cpu
        {
            public string html { get; set; }
            public string dropdown_value { get; set; }
        }
        public class magento_misc
        {
            public string software_desc { get; set; }
            public string ic_certified { get; set; }
            public string oem_software_desc { get; set; }
            public string meta_desc { get; set; }


        }
        public class magento_ram
        {
            public string name { get; set; }
            public string drop_down_value { get; set; }
            public string html { get; set; }
        }

        public class magento_hdd
        {
            public string name { get; set; }
            public string drop_down_value { get; set; }
            public string html { get; set; }
        }

        public List<grade> grade_list
        {
            get
            {
                List<grade> newlist = new List<grade>();
                newlist.Add(new grade() { name = "A", value = "" });
                newlist.Add(new grade() { name = "B", value = "_GradeB" });
                newlist.Add(new grade() { name = "C", value = "_GradeC" });
                return newlist;
            }
            set { }

        }

        public List<string> users { get; set; }


        public class computer_type
        {
            public string name { get; set; }
            public string value { get; set; }

        }
        public List<computer_type> computer_dropdown
        {

            get
            {
                List<computer_type> temp = new List<computer_type>();
                temp.Add(new computer_type() { name = "Desktop", value = "_DK" });
                temp.Add(new computer_type() { name = "Laptop", value = "_LP" });
                return temp;
            }


            set { }

        }




        public List<string> db_select
        {

            get
            {
                var temp = new List<string>();

                temp.Add("Online DB");
                temp.Add("Local DB");
                return temp;
            }
            set { }
        }
        public bool is_mysql_open { get; set; }
        public string mysql_status { get; set; }
        public bool is_sqlite_open { get; set; }
        public string sqlite_status { get; set; }
        public int refurb_machine { get; set; }



    }



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

    public class Lenovo
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Serial { get; set; }
        public string Type { get; set; }
        public string ParentID { get; set; }
        public int Popularity { get; set; }

        public static implicit operator List<object>(Lenovo v)
        {
            throw new NotImplementedException();
        }
    }

    public class Discovery_result
    {

        public string search_cpu { get; set; }
        public string search_manu { get; set; }
        public long search_ram { get; set; }
        public long search_hdd { get; set; }
        public string search_serial { get; set; }
        public string search_optical_drive { get; set; }
        public string search_model { get; set; }


    }

    class Submit_data
    {
        public int submit_asset { get; set; }
        public string submit_preCOA { get; set; }




    }

    class Search_result
    {
        public string is_SSD { get; set; }
        public string search_cpu { get; set; }
        public string search_manu { get; set; }
        public long search_ram { get; set; }
        public long search_hdd { get; set; }
        public string search_serial { get; set; }
        public string search_optical_drive { get; set; }
        public string search_model { get; set; }
        public string search_sku { get; set; }
    }
    class Imaging_search_result
    {

        public string imaging_search_wcoa { get; set; }
        public string imaging_search_ocoa { get; set; }
        public string imaging_search_ram { get; set; }
        public string imaging_search_hdd { get; set; }

        public string imaging_search_video { get; set; }

        public string imaging_search_sku { get; set; }

    }
}
