using Demo.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Data;
using Accord;
using System.Reflection;

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

        public Dictionary<String, string> sku_brand()
        {
           
            var result = (from t in db.magento_sku_brand select t).ToDictionary(x => x.name,x=> x.sku_name);

          return result;
        }
        public LabelModel.magento_hdd get_hdd(string size)
        {
            var result = new LabelModel.magento_hdd();

          //  String cmdText = "select * from magento_html where type = 'hdd' and name ='" + size + "'";
            var q = (from t in db.magento_html where t.type == "hdd" && t.name == size select t).FirstOrDefault();

                    result.html = q.html;
                    result.drop_down_value = q.drop_down_value;
               
            return result;
        }

        public LabelModel.magento_ram get_ram(string size)
        {
            var result = new LabelModel.magento_ram();

          //  String cmdText = "select * from magento_html where type = 'ram' and name ='" + size + "'";

            var query = (from q in db.magento_html where q.type == "ram" && q.name == size select q).FirstOrDefault();
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
      

        public DataTable training_dt() {

            var result = new DataTable("Train");
            result.Columns.Add("Case", "CPU", "RAM", "HDD", "Grade", "Channel", "Type", "Price");


            var data = (from t in db.training_data select t).ToList();
            foreach (var item in data) {

                result.Rows.Add(item.row_id, item.cpu, item.ram, item.hdd, item.grade, item.channel, item.type, item.price);
            }
            

            return result;

        }

        public bool insert(RefrubHistoryObj input)
        {
            bool sucess = false;

            var exisit = (from t in db.rediscovery where t.ictag == input.asset_tag select t);

            var redis = new rediscovery();

            redis.ictag = input.asset_tag;
            redis.serial = input.serial;
            redis.brand = input.brand;
            redis.model = input.model;
            redis.cpu = input.cpu;
            redis.hdd = input.hdd;
            redis.ram = input.ram;
            redis.location = input.channel;
            redis.pallet = input.sku;
            redis.pre_coa = input.pre_coa;
            redis.refurbisher = input.refurbisher;

            if (exisit.Count() == 0) {

                

                using (db = new db_a094d4_demoEntities1())
                {

                    

                    db.rediscovery.Add(redis);
                    db.SaveChanges();

                  //  String cmdText = "Insert into rediscovery(ictag,time,serial,brand,model,cpu,hdd,ram,optical_drive,location,pallet,pre_coa,refurbisher)VALUES ('" + input.asset_tag + "','" + "" + "','" + input.serial + "','" + input.brand + "','" + input.model + "','" + input.cpu + "','" + input.hdd + "','" + input.ram + "','','" + input.channel + "','" + input.sku + "','" + input.pre_coa + "','" + input.refurbisher + "') on Duplicate KEY update hdd='" + input.hdd + "',ram='" + input.ram + "',location='" + input.channel + "',pallet='" + input.sku + "',pre_coa = '" + input.pre_coa + "',refurbisher = '" + input.refurbisher + "'";
                   

                    sucess = true;
                }
               
            }
            else
            {
                db.Entry(redis).State = EntityState.Modified;
                db.SaveChanges();

            }








            return sucess;
        }
    }
}