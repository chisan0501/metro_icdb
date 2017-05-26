using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Demo.Controllers
{
    public class ReportController : Controller
    {
        db_a094d4_demoEntities1 db = new db_a094d4_demoEntities1();
        // GET: Report
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult home()
        {
            return View();
        }
        public JsonResult gen_report(DateTime from_time, DateTime to_time)
        {
            
            var discovery = (from d in db.discovery where d.time >=from_time && d.time <= to_time orderby d.time select new {d.time,d.ictag,d.serial,d.brand,d.model,d.cpu,d.ram,d.hdd }).ToList();
            var discovery_ictag = (from d in db.discovery where d.time >= from_time && d.time <= to_time orderby d.time select d.ictag).ToList();

            var rediscovery = (from d in db.rediscovery where d.time >= from_time && d.time <= to_time orderby d.time select d).ToList();
            var imaging = (from d in db.production_log where d.time >= from_time && d.time <= to_time orderby d.time select d).ToList();
            var rediscovery_inv = (from d in db.rediscovery select d.ictag).ToList();
            var raw = discovery_ictag.Except(rediscovery_inv).ToList();
            var raw_inventory = (from d in db.discovery where raw.Contains(d.ictag) select d).ToList();
            var wcoa_count = (from d in db.production_log where d.time >= from_time && d.time <= to_time select d.wcoa).Count();
            
            var ocoa_count = (from d in db.production_log where d.time >= from_time && d.time <= to_time select d.ocoa).Count();

            var sku_count = from l in db.rediscovery where l.time >= from_time && l.time <= to_time group l by l.pallet into g select new { SKU = g.Key, Count = (from l in g select l.pallet).Count() };
            return Json(new { wcoa_count = wcoa_count,ocoa_count = ocoa_count,sku_count = sku_count,raw = raw_inventory, date_from = from_time, date_to = to_time,discovery = discovery,rediscovery = rediscovery,imaging = imaging},JsonRequestBehavior.AllowGet);
        }
    }
}