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

        // GET: discoveries/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            discovery discovery = db.discovery.Find(id);
            if (discovery == null)
            {
                return HttpNotFound();
            }
            return View(discovery);
        }

        // GET: discoveries/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: discoveries/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ictag,time,serial,brand,model,cpu,hdd,ram,optical_drive,location")] discovery discovery)
        {
            if (ModelState.IsValid)
            {
                db.discovery.Add(discovery);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(discovery);
        }

        

        public JsonResult edit_form(string asset ,string time, string serial, string make,string cpu,string ram, string hdd,string model) {
            List<string> message = new List<string>();
            using (var db = new db_a094d4_demoEntities1()) {

                try
                {

                    var discovery = new discovery();
                    discovery.serial = serial;
                    discovery.brand = make;
                    discovery.cpu = cpu;
                    discovery.ram = ram;
                    discovery.hdd = hdd;
                    discovery.model = model;
                    discovery.ictag = int.Parse(asset);
                    db.discovery.Attach(discovery);
                    var entry = db.Entry(discovery);
                    entry.Property(e => e.serial).IsModified = true;
                    entry.Property(e => e.brand).IsModified = true;
                    entry.Property(e => e.cpu).IsModified = true;
                    entry.Property(e => e.ram).IsModified = true;
                    entry.Property(e => e.hdd).IsModified = true;
                    entry.Property(e => e.model).IsModified = true;
                    
                    // other changed properties
                    db.SaveChanges();

                    
                    message.Add("Info Has Updated for Asset ");
                }
                catch (Exception e) {

                    message.Add(e.InnerException.InnerException.Message);

                }

               



            }



            return Json(new { message = message},JsonRequestBehavior.AllowGet);
        }

        // GET: discoveries/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            discovery discovery = db.discovery.Find(id);
            if (discovery == null)
            {
                return HttpNotFound();
            }
            return View(discovery);
        }

        // POST: discoveries/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ictag,time,serial,brand,model,cpu,hdd,ram,optical_drive,location")] discovery discovery)
        {
            if (ModelState.IsValid)
            {
                db.Entry(discovery).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(discovery);
        }

        // GET: discoveries/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            discovery discovery = db.discovery.Find(id);
            if (discovery == null)
            {
                return HttpNotFound();
            }
            return View(discovery);
        }

        // POST: discoveries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        
       
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        public JsonResult search_record(string search_string,string search_cat,string is_raw)
        {
            var result = new List<discovery>();
            switch (search_cat) {
                case "brand":
                    result = (from t in db.discovery where t.brand.Contains(search_string) select t).ToList();
                    break;
                case "model":
                    result = (from t in db.discovery where t.model.Contains(search_string) select t).ToList();
                    break;
                case "hdd":
                    result = (from t in db.discovery where t.hdd.Contains(search_string) select t).ToList();
                    break;
                case "ram":
                    result = (from t in db.discovery where t.ram.Contains(search_string) select t).ToList();
                    break;
                case "cpu":
                   result = (from t in db.discovery where t.cpu.Contains(search_string) select t).ToList();
                    break;
                default:
                    break;
            }
            
            if(is_raw == "true")
            {
                var result_ictag = (from t in result select t.ictag);
                var rediscovery_inv = (from d in db.rediscovery select d.ictag).ToList();
                var raw = result_ictag.Except(rediscovery_inv).ToList();
                result = (from d in db.discovery where raw.Contains(d.ictag) select d).ToList();
            }

            return Json(result,JsonRequestBehavior.AllowGet);
        }

        public JsonResult delete_record(string ictag)
        {
            string message = "";
            try
            {
                using (var remove = new db_a094d4_demoEntities1())
                {
                    remove.Database.ExecuteSqlCommand(
                    "Delete from discovery where ictag = '" + ictag + "'");
                }


                message = ictag + " Has Been Deleted";
            }
            catch (Exception e)
            {
                message = e.Message;
            }


            return Json(message,JsonRequestBehavior.AllowGet);
        }

        public JsonResult get_discovery_data ()
        {


            var result = (from t in db.discovery orderby t.time descending select t).ToList();

            return Json(result,JsonRequestBehavior.AllowGet);
        }
    }
}
