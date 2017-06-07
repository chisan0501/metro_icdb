using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Demo;

namespace Demo.Controllers
{
    public class production_logController : Controller
    {
        private db_a094d4_demoEntities1 db = new db_a094d4_demoEntities1();

        // GET: production_log
        public ActionResult Index()
        {
            return View();
        }

        

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }


        public JsonResult lv2detail_Model_dropdown(string input, string brand)
        {

            var RAM_result = (from t in db.production_log where t.Manufacture == brand && t.Model == input select t.RAM).Distinct().ToList();
            var HDD_result = (from t in db.production_log where t.Manufacture == brand && t.Model == input select t.HDD).Distinct().ToList();


            RAM_result.Sort();
            HDD_result.Sort();
            return Json(new { ram = RAM_result, hdd = HDD_result }, JsonRequestBehavior.AllowGet);
        }


        public JsonResult detail_Model_dropdown(string input)
        {

            var Model_result = (from t in db.production_log where t.Manufacture == input select t.Model).Distinct().ToList();


            Model_result.Sort();

            return Json(Model_result, JsonRequestBehavior.AllowGet);
        }


        public JsonResult Manufacture_dropdown()
        {


            var manu_result = (from t in db.production_log select t.Manufacture).Distinct().ToList();

            manu_result.Sort();

            return Json(new { manu = manu_result }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult get_production_log_data(int jtStartIndex, int jtPageSize, string jtSorting = null, string asset = "", string Model = "", string RAM = "", string HDD = "", string manu = "", string raw = "", bool search = false)
        {


            if (search == true)
            {

                IQueryable<production_log> result = null;


                if (!string.IsNullOrEmpty(asset))
                {
                   
                    result = (from d in db.production_log where d.ictags == asset select d);
                    return Json(new { Result = "OK", Records = result, TotalRecordCount = result.Count() }, JsonRequestBehavior.AllowGet);
                }
                if (manu != "Select a Manufacture")
                {
                    result = (from d in db.production_log where d.Manufacture == manu select d);

                }
                if (Model != "Select a Model")
                {
                    result = (from d in result where d.Model == Model select d);
                }
                if (RAM != "Select RAM" && RAM != "")
                {
                    result = (from d in result where d.RAM == RAM select d);
                }
                if (HDD != "Select HDD" && HDD != "")
                {
                    result = (from d in result where d.HDD == HDD select d);
                }

                return Json(new { Result = "OK", Records = result, TotalRecordCount = result.Count() }, JsonRequestBehavior.AllowGet);
            }




            try
            {

                var count = (from d in db.production_log select d).Count();

                var result = db.production_log.SqlQuery(
                "Select * from production_log order by " + jtSorting + " Limit " + jtStartIndex + "," + jtPageSize);

                return Json(new { Result = "OK", Records = result, TotalRecordCount = count }, JsonRequestBehavior.AllowGet);

            }

            catch (Exception ex)
            {

                return Json(new { Result = "ERROR", Message = ex.Message });
            }






            //default entry

        }

        public JsonResult update_production_log_data(production_log production_log)
        {


            try
            {
                if (!ModelState.IsValid)
                {
                    return Json(new { Result = "ERROR", Message = "Form is not valid! Please correct it and try again." });
                }


                db.Entry(production_log).State = EntityState.Modified;
                db.SaveChanges();



                return Json(new { Result = "OK" }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR", Message = ex.Message }, JsonRequestBehavior.AllowGet);
            }

        }

        public JsonResult delete_production_log_data(production_log production_log)
        {
            try
            {


                production_log = db.production_log.Find(production_log.ictags);
                db.production_log.Remove(production_log);
                db.SaveChanges();
                return Json(new { Result = "OK" });
            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR", Message = ex.Message });

            }



        }
    }
}
