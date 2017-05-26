using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Demo.Controllers
{
    public class HomeController : Controller
    {
        db_a094d4_demoEntities1 db = new db_a094d4_demoEntities1();
        public ActionResult Index()
        {
            
            
            return View();
        }

        public JsonResult get_data (DateTime from, DateTime to)
        {

            DateTime date_from;
            DateTime date_to;
            
                date_from = from;
                date_to = to;

            

            var imaging_data = (from d in db.production_log where d.time >= date_from && d.time <= date_to select d).Count();
            var discovery_data = (from d in db.discovery where d.time >= date_from && d.time < date_to select d).Count();
            var rediscovery_data = (from d in db.rediscovery where d.time >= date_from && d.time < date_to select d).Count();
            var monitor_data = (from d in db.monitor_log where d.time >= date_from && d.time <= date_to select d).Count();
            var ts_wcoa_s1 = (from m in db.coas where (m.Recipient_Organization_Name == "TechSoup.org" && m.location == "wcoa_s1") select m).Count();
            var ts_ocoa_s1 = (from m in db.coas where (m.Recipient_Organization_Name == "TechSoup.org" && m.location == "ocoa_s1") select m).Count();
            var mar_wcoa_s1 = (from m in db.coas where (m.Recipient_Organization_Name == "Interconnection" && m.location == "wcoa_s1") select m).Count();
            var mar_ocoa_s1 = (from m in db.coas where (m.Recipient_Organization_Name == "Interconnection" && m.location == "ocoa_s1") select m).Count();
            var g360_wcoa_s1 = (from m in db.coas where (m.Recipient_Organization_Name == "Good360" && m.location == "wcoa_s1") select m).Count();
            var g360_ocoa_s1 = (from m in db.coas where (m.Recipient_Organization_Name == "Good360" && m.location == "ocoa_s1") select m).Count();
            var ts_wcoa_s2 = (from m in db.coas where (m.Recipient_Organization_Name == "TechSoup.org" && m.location == "wcoa_s2") select m).Count();
            var ts_ocoa_s2 = (from m in db.coas where (m.Recipient_Organization_Name == "TechSoup.org" && m.location == "ocoa_s2") select m).Count();
            var mar_wcoa_s2 = (from m in db.coas where (m.Recipient_Organization_Name == "Interconnection" && m.location == "wcoa_s2") select m).Count();
            var mar_ocoa_s2 = (from m in db.coas where (m.Recipient_Organization_Name == "Interconnection" && m.location == "ocoa_s2") select m).Count();
            var g360_wcoa_s2 = (from m in db.coas where (m.Recipient_Organization_Name == "Good360" && m.location == "wcoa_s2") select m).Count();
            var g360_ocoa_s2 = (from m in db.coas where (m.Recipient_Organization_Name == "Good360" && m.location == "ocoa_s2") select m).Count();

            var hourly_from =  date_from.ToString("yyyy-MM-dd");
            var hourly_to = date_to.ToString("yyyy-MM-dd");
            var today_production_level = db.Database.SqlQuery<Models.SQLModel.ProductionLevelByHour>("SELECT hour(time) as hours, count(time) as num FROM production_log where time >= '"+hourly_from+"' AND time < '"+hourly_to+"' + INTERVAL 1 DAY GROUP BY hour(time)").ToList<Models.SQLModel.ProductionLevelByHour>();

          
            var pass7_production_level = db.Database.SqlQuery<Models.SQLModel.LevelByWeek>("SELECT DATE_FORMAT(time, '%Y-%m-%d') as date, count(time) as num FROM production_log where time >= DATE_SUB(CURDATE(), INTERVAL 7 DAY) AND time <= DATE_ADD(CURDATE(), INTERVAL 2 DAY) GROUP BY day(time)").ToList<Models.SQLModel.LevelByWeek>();
            var pass7_discovery_level = db.Database.SqlQuery<Models.SQLModel.LevelByWeek>("SELECT DATE_FORMAT(time, '%Y-%m-%d') as date, count(time) as num FROM discovery where time >= DATE_SUB(CURDATE(), INTERVAL 7 DAY) AND time <= DATE_ADD(CURDATE(), INTERVAL 2 DAY) GROUP BY day(time)").ToList<Models.SQLModel.LevelByWeek>();
            var pass7_rediscovery_level = db.Database.SqlQuery<Models.SQLModel.LevelByWeek>("SELECT DATE_FORMAT(time, '%Y-%m-%d') as date, count(time) as num FROM rediscovery where time >= DATE_SUB(CURDATE(), INTERVAL 7 DAY) AND time <= DATE_ADD(CURDATE(), INTERVAL 2 DAY) GROUP BY day(time)").ToList<Models.SQLModel.LevelByWeek>();


            return Json(new { pass7_production_level= pass7_production_level, pass7_discovery_level= pass7_discovery_level, pass7_rediscovery_level= pass7_rediscovery_level, today_production_level = today_production_level,tswcoas1 = ts_wcoa_s1, tsocoas1 = ts_ocoa_s1, tswcoas2 = ts_wcoa_s2, tsocoas2 = ts_ocoa_s2, marwcoas1 = mar_wcoa_s1, marocoas1 = mar_ocoa_s1, marwcoas2 = mar_wcoa_s2, marocoas2 = mar_ocoa_s2, g360wcoas1 = g360_wcoa_s1, g360ocoas1 = g360_ocoa_s1, g360wcoas2 = g360_wcoa_s2, g360ocoas2 = g360_ocoa_s2 ,discovery =discovery_data,rediscovery = rediscovery_data,imaging = imaging_data,monitor_data = monitor_data},JsonRequestBehavior.AllowGet);
            

        }


        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
     
        public ActionResult search_result(string asset_tag)
        {
            ViewData["asset"] = asset_tag;


            return View();
        }


        public JsonResult search_result_json(string asset_tag)
        {

            int asset_tag_int = int.Parse(asset_tag);

            var discovery_data = (from d in db.discovery where d.ictag == asset_tag_int select d).FirstOrDefault();
           
            var rediscovery_data = (from r in db.rediscovery where r.ictag == asset_tag_int select r).FirstOrDefault();
            var imaging = (from i in db.production_log where i.ictags == asset_tag select i).FirstOrDefault();

            return Json(new { discovery = discovery_data,rediscovery = rediscovery_data,imaging =imaging},JsonRequestBehavior.AllowGet);
        }


    }
}