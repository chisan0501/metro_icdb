using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Demo;

namespace Demo.Views
{
    public class discoveriesController : Controller
    {
        private db_a094d4_demoEntities1 db = new db_a094d4_demoEntities1();

        // GET: discoveries
        public ActionResult Index()
        {
            return View(db.discovery.ToList());
        }

        

       

      

      

      

        
        
       
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }


       

        public JsonResult lv2detail_model_dropdown(string input,string brand)
        {

            var ram_result = (from t in db.discovery where t.brand == brand && t.model == input select t.ram).Distinct().ToList();
            var hdd_result = (from t in db.discovery where t.brand == brand && t.model == input select t.hdd).Distinct().ToList();


            ram_result.Sort();
            hdd_result.Sort();
            return Json(new { ram = ram_result, hdd = hdd_result}, JsonRequestBehavior.AllowGet);
        }


        public JsonResult detail_model_dropdown(string input)
        {

            var model_result = (from t in db.discovery where t.brand == input select t.model).Distinct().ToList();
            

            model_result.Sort();
            
            return Json(model_result, JsonRequestBehavior.AllowGet);
        }


        public JsonResult brand_dropdown()
        {

           
            var manu_result = (from t in db.discovery select t.brand).Distinct().ToList();

            manu_result.Sort();
           
            return Json(new { manu = manu_result},JsonRequestBehavior.AllowGet);
        }

        public JsonResult get_discovery_data (int jtStartIndex, int jtPageSize, string jtSorting = null, string asset = "",string model = "", string ram = "",string hdd="",string manu = "",string  raw = "", bool search = false)
        {


            if (search == true)  {

                IQueryable<discovery> result = null;
               

                if (!string.IsNullOrEmpty(asset))
                {
                    int int_asset = int.Parse(asset);
                    result = (from d in db.discovery where d.ictag == int_asset select d);
                    return Json(new { Result = "OK", Records = result, TotalRecordCount = result.Count() }, JsonRequestBehavior.AllowGet);
                }
                if (manu != "Select a Manufacture")
                {
                    result = (from d in db.discovery where d.brand == manu select d);

                }
                if (model != "Select a Model" ) {
                    result = (from d in result where d.model == model select d);
                }
                if (ram != "Select RAM" && ram != "")
                {
                    result = (from d in result where d.ram == ram select d);
                }
                if (hdd != "Select HDD" && hdd !="")
                {
                    result = (from d in result where d.hdd == hdd select d);
                }

                return Json(new { Result = "OK", Records = result, TotalRecordCount = result.Count() }, JsonRequestBehavior.AllowGet);
            }
             

           

                try
                {

                    var count = (from d in db.discovery select d).Count();

                    var result = db.discovery.SqlQuery(
                    "Select * from discovery order by " + jtSorting + " Limit " + jtStartIndex + "," + jtPageSize);

                    return Json(new { Result = "OK", Records = result, TotalRecordCount = count }, JsonRequestBehavior.AllowGet);

                }

                catch (Exception ex)
                {

                    return Json(new { Result = "ERROR", Message = ex.Message });
                }

            
           
            


            //default entry
           
        }

        public JsonResult update_discovery_data(discovery discovery) {


            try
            {
                if (!ModelState.IsValid)
                {
                    return Json(new { Result = "ERROR", Message = "Form is not valid! Please correct it and try again." });
                }

                
                    db.Entry(discovery).State = EntityState.Modified;
                    db.SaveChanges();
                   
                

                return Json(new { Result = "OK" },JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR", Message = ex.Message }, JsonRequestBehavior.AllowGet);
            }

        }

        public JsonResult delete_discovery_data(discovery discovery) {
            try
            {


                discovery = db.discovery.Find(discovery.ictag);
                db.discovery.Remove(discovery);
                db.SaveChanges();
                return Json(new { Result = "OK" });
            }
            catch (Exception ex){
                return Json(new { Result = "ERROR", Message = ex.Message });

            }



        }

    }
}
