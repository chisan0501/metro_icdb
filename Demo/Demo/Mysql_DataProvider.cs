using Demo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Demo
{
    public class Mysql_DataProvider
    {
        db_a094d4_demoEntities1 db = new db_a094d4_demoEntities1();
        public LabelModel.magento_cpu get_cpu(string condition)
        {
            var result = new LabelModel.magento_cpu();
            var q = (from t in db.magento_html where t.name == condition select t).FirstOrDefault();

            result.html = q.html;
            result.dropdown_value = q.drop_down_value;

            return result;
        }

        public Dictionary<String, int> sku_brand()
        {
           
            var result = (from t in db.magento_sku_brand select t).ToDictionary(x => x.name,x=> x.index);

          return result;
        }
        public LabelModel.magento_hdd get_hdd(string size)
        {
            var result = new LabelModel.magento_hdd();

            String cmdText = "select * from magento_html where type = 'hdd' and name ='" + size + "'";
            var q = (from t in db.magento_html where t.type == "hdd" && t.name == size select t).FirstOrDefault();

                    result.html = q.html;
                    result.drop_down_value = q.drop_down_value;
               
            return result;
        }

        public LabelModel.magento_ram get_ram(string size)
        {
            var result = new LabelModel.magento_ram();

            String cmdText = "select * from magento_html where type = 'ram' and name ='" + size + "'";

            var query = (from q in db.magento_html where q.type == "ram" && q.name == "size" select q).FirstOrDefault();
            result.html = query.html;
                    result.drop_down_value = query.drop_down_value;


            return result;
        }

        public string get_misc(string condition)
        {

            string result = "";


            String cmdText = "select html from magento_html where name = '" + condition + "'";
            var q = (from t in db.magento_html where t.name == condition select t.html).FirstOrDefault();

            result = q;
           

            return result;
        }

    }
}