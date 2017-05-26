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
    public class rediscoveriesController : Controller
    {
        private db_a094d4_demoEntities1 db = new db_a094d4_demoEntities1();

        // GET: rediscoveries
        public ActionResult Index()
        {
            return View(db.rediscovery.ToList());
        }

        public JsonResult get_rediscovery_data()
        {


            var result = (from t in db.rediscovery orderby t.time descending select t).ToList();

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        // GET: rediscoveries/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            rediscovery rediscovery = db.rediscovery.Find(id);
            if (rediscovery == null)
            {
                return HttpNotFound();
            }
            return View(rediscovery);
        }

        // GET: rediscoveries/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: rediscoveries/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ictag,time,serial,brand,model,cpu,hdd,ram,optical_drive,location,pallet,pre_coa,refurbisher,status,orderNum,has_SSD")] rediscovery rediscovery)
        {
            if (ModelState.IsValid)
            {
                db.rediscovery.Add(rediscovery);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(rediscovery);
        }

        // GET: rediscoveries/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            rediscovery rediscovery = db.rediscovery.Find(id);
            if (rediscovery == null)
            {
                return HttpNotFound();
            }
            return View(rediscovery);
        }

        public JsonResult edit_form(int asset, string serial, string model, string refurbisher, string sku)
        {
            List<string> message = new List<string>();
            using (var db = new db_a094d4_demoEntities1())
            {

                try
                {

                    var redis = new rediscovery();
                    redis.ictag = asset;
                    redis.pallet = sku;
                    redis.serial = serial;
                    redis.model = model;
                    redis.refurbisher = refurbisher;
                    db.rediscovery.Attach(redis);
                    var entry = db.Entry(redis);
                    entry.Property(e => e.pallet).IsModified = true;
                    entry.Property(e => e.model).IsModified = true;
                    entry.Property(e => e.serial).IsModified = true;
                    entry.Property(e => e.refurbisher).IsModified = true;

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


        // POST: rediscoveries/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ictag,time,serial,brand,model,cpu,hdd,ram,optical_drive,location,pallet,pre_coa,refurbisher,status,orderNum,has_SSD")] rediscovery rediscovery)
        {
            if (ModelState.IsValid)
            {
                db.Entry(rediscovery).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(rediscovery);
        }


        public JsonResult search_record(string search_string, string search_cat)
        {
            var result = new List<rediscovery>();
            switch (search_cat)
            {
             
                case "model":
                    result = (from t in db.rediscovery where t.model.Contains(search_string) select t).ToList();
                    break;
                case "sku":
                    result = (from t in db.rediscovery where t.pallet.Contains(search_string) select t).ToList();
                    break;
                case "refurbisher":
                    result = (from t in db.rediscovery where t.refurbisher.Contains(search_string) select t).ToList();
                    break;
                default:
                    break;
            }

            

            return Json(result, JsonRequestBehavior.AllowGet);
        }


        // GET: rediscoveries/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            rediscovery rediscovery = db.rediscovery.Find(id);
            if (rediscovery == null)
            {
                return HttpNotFound();
            }
            return View(rediscovery);
        }

        // POST: rediscoveries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            rediscovery rediscovery = db.rediscovery.Find(id);
            db.rediscovery.Remove(rediscovery);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public JsonResult delete_record(string ictag)
        {
            string message = "";
            try
            {
                using (var remove = new db_a094d4_demoEntities1())
                {
                    remove.Database.ExecuteSqlCommand(
                    "Delete from rediscovery where ictag = '" + ictag + "'");
                }


                message = ictag + " Has Been Deleted";
            }
            catch (Exception e)
            {
                message = e.Message;
            }


            return Json(message, JsonRequestBehavior.AllowGet);
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
