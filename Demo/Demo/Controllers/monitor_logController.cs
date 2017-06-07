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
    public class monitor_logController : Controller
    {
        private db_a094d4_demoEntities1 db = new db_a094d4_demoEntities1();

        // GET: monitor_log
        public ActionResult Index()
        {
            return View(db.monitor_log.ToList());
        }



        public JsonResult lv2detail_Model_dropdown(string input, string brand)
        {

          
            var size_result = (from t in db.monitor_log where t.manu == brand && t.model == input select t.size).Distinct().ToList();

            size_result.Sort();
            
            return Json(new { size = size_result }, JsonRequestBehavior.AllowGet);
        }


        public JsonResult detail_Model_dropdown(string input)
        {

            var Model_result = (from t in db.monitor_log where t.manu == input select t.model).Distinct().ToList();


            Model_result.Sort();

            return Json(Model_result, JsonRequestBehavior.AllowGet);
        }


        public JsonResult Manufacture_dropdown()
        {


            var manu_result = (from t in db.monitor_log select t.manu).Distinct().ToList();

            manu_result.Sort();

            return Json(new { manu = manu_result }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult get_monitor_log_data(int jtStartIndex, int jtPageSize, string jtSorting = null, string asset = "", string Model = "", string size = "", string manu = "", bool search = false)
        {


            if (search == true)
            {

                IQueryable<monitor_log> result = null;


                if (!string.IsNullOrEmpty(asset))
                {
                    int int_asset = int.Parse(asset);
                    result = (from d in db.monitor_log where d.ictag == int_asset select d);
                    return Json(new { Result = "OK", Records = result, TotalRecordCount = result.Count() }, JsonRequestBehavior.AllowGet);
                }
                if (manu != "Select a Manufacture")
                {
                    result = (from d in db.monitor_log where d.manu == manu select d);

                }
                if (Model != "Select a Model")
                {
                    result = (from d in result where d.model == Model select d);
                }
                if (size != "Select Size" && size != "")
                {
                    int int_size = int.Parse(size);
                    result = (from d in result where d.size == int_size select d);
                }
               

                return Json(new { Result = "OK", Records = result, TotalRecordCount = result.Count() }, JsonRequestBehavior.AllowGet);
            }




            try
            {

                var count = (from d in db.monitor_log select d).Count();

                var result = db.monitor_log.SqlQuery(
                "Select * from monitor_log order by " + jtSorting + " Limit " + jtStartIndex + "," + jtPageSize);

                return Json(new { Result = "OK", Records = result, TotalRecordCount = count }, JsonRequestBehavior.AllowGet);

            }

            catch (Exception ex)
            {

                return Json(new { Result = "ERROR", Message = ex.Message });
            }






            //default entry

        }

        public JsonResult update_monitor_log_data(monitor_log monitor_log)
        {


            try
            {
                if (!ModelState.IsValid)
                {
                    return Json(new { Result = "ERROR", Message = "Form is not valid! Please correct it and try again." });
                }


                db.Entry(monitor_log).State = EntityState.Modified;
                db.SaveChanges();



                return Json(new { Result = "OK" }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR", Message = ex.Message }, JsonRequestBehavior.AllowGet);
            }

        }

        public JsonResult delete_monitor_log_data(monitor_log monitor_log)
        {
            try
            {


                monitor_log = db.monitor_log.Find(monitor_log.ictag);
                db.monitor_log.Remove(monitor_log);
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
