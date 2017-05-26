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

        // GET: production_log/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            production_log production_log = db.production_log.Find(id);
            if (production_log == null)
            {
                return HttpNotFound();
            }
            return View(production_log);
        }

        // GET: production_log/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: production_log/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "time,ictags,wcoa,ocoa,Manufacture,Model,CPU,RAM,HDD,serial,channel,pre_coa,location,video_card,screen_size")] production_log production_log)
        {
            if (ModelState.IsValid)
            {
                db.production_log.Add(production_log);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(production_log);
        }



        // GET: production_log/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            production_log production_log = db.production_log.Find(id);
            if (production_log == null)
            {
                return HttpNotFound();
            }
            return View(production_log);
        }

        public JsonResult edit_form(string asset, string wcoa, string ocoa)
        {
            List<string> message = new List<string>();
            using (var db = new db_a094d4_demoEntities1())
            {

                try
                {

                    var production = new production_log();
                    production.wcoa = wcoa;
                    production.ocoa = ocoa;
                    production.ictags = asset;
                    db.production_log.Attach(production);
                    var entry = db.Entry(production);
                    entry.Property(e => e.ictags).IsModified = true;
                    
                    entry.Property(e => e.ocoa).IsModified = true;


                    // other changed properties
                    db.SaveChanges();

                    
                    message.Add("Info Has Updated for Asset ");
                }
                catch (Exception e)
                {

                    message.Add(e.InnerException.InnerException.Message);

                }





            }



            return Json(new { message = message }, JsonRequestBehavior.AllowGet);
        }

        // POST: production_log/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "time,ictags,wcoa,ocoa,Manufacture,Model,CPU,RAM,HDD,serial,channel,pre_coa,location,video_card,screen_size")] production_log production_log)
        {
            if (ModelState.IsValid)
            {
                db.Entry(production_log).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(production_log);
        }

        public JsonResult get_production_log_data()
        {

            

            var result = (from t in db.production_log orderby t.time descending select t).Take(100).ToList();

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public JsonResult search_record(string search_string, string search_cat)
        {
            var result = new List<production_log>();
            switch (search_cat)
            {

                case "ictags":
                    result = (from t in db.production_log where t.ictags.Contains(search_string) select t).ToList();
                    break;
                case "wcoa":
                    result = (from t in db.production_log where t.wcoa.Contains(search_string) select t).ToList();
                    break;
                case "ocoa":
                    result = (from t in db.production_log where t.ocoa.Contains(search_string) select t).ToList();
                    break;
                default:
                    break;
            }



            return Json(result, JsonRequestBehavior.AllowGet);
        }


        // GET: production_log/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            production_log production_log = db.production_log.Find(id);
            if (production_log == null)
            {
                return HttpNotFound();
            }
            return View(production_log);
        }

        public JsonResult delete_record(string ictag)
        {
            string message = "";
            try
            {
                using (var remove = new db_a094d4_demoEntities1())
                {
                    remove.Database.ExecuteSqlCommand(
                    "Delete from production_log where ictags = '" + ictag + "'");
                }


                message = ictag + " Has Been Deleted";
            }
            catch (Exception e)
            {
                message = e.Message;
            }


            return Json(message, JsonRequestBehavior.AllowGet);
        }

        // POST: production_log/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            production_log production_log = db.production_log.Find(id);
            db.production_log.Remove(production_log);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
