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

        // GET: monitor_log/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            monitor_log monitor_log = db.monitor_log.Find(id);
            if (monitor_log == null)
            {
                return HttpNotFound();
            }
            return View(monitor_log);
        }

        // GET: monitor_log/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: monitor_log/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "time,ictag,manu,monitor_ID,serial,size,resou,model")] monitor_log monitor_log)
        {
            if (ModelState.IsValid)
            {
                db.monitor_log.Add(monitor_log);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(monitor_log);
        }

        // GET: monitor_log/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            monitor_log monitor_log = db.monitor_log.Find(id);
            if (monitor_log == null)
            {
                return HttpNotFound();
            }
            return View(monitor_log);
        }

        // POST: monitor_log/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "time,ictag,manu,monitor_ID,serial,size,resou,model")] monitor_log monitor_log)
        {
            if (ModelState.IsValid)
            {
                db.Entry(monitor_log).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(monitor_log);
        }

        // GET: monitor_log/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            monitor_log monitor_log = db.monitor_log.Find(id);
            if (monitor_log == null)
            {
                return HttpNotFound();
            }
            return View(monitor_log);
        }

        // POST: monitor_log/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            monitor_log monitor_log = db.monitor_log.Find(id);
            db.monitor_log.Remove(monitor_log);
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

        public JsonResult search_record(string search_string, string search_cat)
        {
            var result = new List<monitor_log>();
            switch (search_cat)
            {

                case "ictag":
                    result = (from t in db.monitor_log where t.ictag.ToString().Contains(search_string) select t).ToList();
                    break;
                case "manu":
                    result = (from t in db.monitor_log where t.manu.Contains(search_string) select t).ToList();
                    break;
                case "model":
                    result = (from t in db.monitor_log where t.model.Contains(search_string) select t).ToList();
                    break;
                case "size":
                    result = (from t in db.monitor_log where t.size.ToString().Contains(search_string) select t).ToList();
                    break;
                default:
                    break;
            }



            return Json(result, JsonRequestBehavior.AllowGet);
        }


        public JsonResult get_monitor_log_data()
        {


            var result = (from t in db.monitor_log orderby t.time descending select t).ToList();

            return Json(result, JsonRequestBehavior.AllowGet);
        }


        public JsonResult delete_record(string ictag)
        {
            string message = "";
            try
            {
                using (var remove = new db_a094d4_demoEntities1())
                {
                    remove.Database.ExecuteSqlCommand(
                    "Delete from monitor_log where ictags = '" + ictag + "'");
                }


                message = ictag + " Has Been Deleted";
            }
            catch (Exception e)
            {
                message = e.Message;
            }


            return Json(message, JsonRequestBehavior.AllowGet);
        }
    }
}
