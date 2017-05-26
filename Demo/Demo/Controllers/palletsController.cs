using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Demo;
using System.Transactions;
using System.Net.Http;

namespace Demo.Controllers
{
    public class palletsController : Controller
    {
        private db_a094d4_demoEntities1 db = new db_a094d4_demoEntities1();

        // GET: pallets
        public ActionResult Index()
        {
            return View(db.pallet.ToList());
        }

        [HttpPost]
       
        public JsonResult create(string pallet_name,string assets,string note ) {

            List<string> message = new List<string>();

            var current_pallet = (from d in db.pallet where d.pallet_name == pallet_name select d).ToList();

            if (current_pallet.Count > 0)
            {
                message.Add("Pallet Name Exisited");
            }
            else {
                List<string> list = new List<string>(
                            assets.Split(new string[] { "\r\n" },
                            StringSplitOptions.RemoveEmptyEntries));
                foreach (var asset in list) {
                    try
                    {

                        using (var add = new db_a094d4_demoEntities1())
                        {
                            add.Database.ExecuteSqlCommand(
                            "INSERT INTO pallet (ictags, pallet_name,note) VALUES('" + asset + "','" + pallet_name + "','"+note+"') ON DUPLICATE KEY UPDATE ictags = '" + asset + "', pallet_name = '" + pallet_name + "', note = '"+note+"'");
                            message.Add(asset + " has been added to " + pallet_name);
                        }
                        
                    }
                    catch (Exception e)
                    {

                        message.Add(e.InnerException.InnerException.Message);

                    }


                }
            }



            return Json(message,JsonRequestBehavior.AllowGet);
        }

        
        

        public JsonResult add_asset(string pallet_name, string asset) {
            var message = "";

            try
            {

                using (var add = new db_a094d4_demoEntities1())
                {
                    add.Database.ExecuteSqlCommand(
                    "INSERT INTO pallet (ictags, pallet_name) VALUES('" + asset + "','" + pallet_name + "') ON DUPLICATE KEY UPDATE ictags = '" + asset + "', pallet_name = '" + pallet_name + "'");
                }
                message = asset + " has been added to " + pallet_name;
            }
            catch (Exception e) {

                message = e.Message;

            }


            return Json(message,JsonRequestBehavior.AllowGet);
        }
      
        public JsonResult validate(int[] input, string pallet_name)
        {
         
            bool valid = false;
            List<string> message = new List<string>();
            var validate_pallet_name = (from t in db.pallet where t.pallet_name == pallet_name select t).Count();
            if(validate_pallet_name != 0)
            {
                message.Add("Pallet Name Already Exist");
            }
            var server_asset = (from t in db.pallet select t.ictags).ToArray();
            var client_asset = input;
            var duplicate = server_asset.Intersect(client_asset).ToList();
            
            
            if (duplicate.Count() == 0 && validate_pallet_name == 0)
            {
                valid = true;
            }
            else
            {
                for(int i= 0; i< duplicate.Count(); i++)
                {
                    message.Add("Asset " +duplicate[i].ToString() + " Already Exist");
                }
            }
        
            

            return Json(new { valid = valid, duplicate = duplicate ,message = message}, JsonRequestBehavior.AllowGet);
        }

        public JsonResult get_pallet_data(string pallet) {

            var result = (from p in db.pallet where p.pallet_name == pallet select p.ictags).ToList();

            return Json(new { pallet= result},JsonRequestBehavior.AllowGet);
        }

        

        public JsonResult edit_pallet(string pallet) {

            var result = (from d in db.pallet where d.pallet_name == pallet select d).ToList();
            


            return Json(result,JsonRequestBehavior.AllowGet);
        }
        public JsonResult get_pallet_detail(string pallet_name) {

            var result = (from o in db.pallet where o.pallet_name == pallet_name from h in db.discovery where h.ictag == o.ictags select new { ictags = o.ictags, pallet_name = o.pallet_name, note = o.note, brand = h.brand, model = h.model, cpu = h.cpu, ram = h.ram, hdd = h.hdd, optical_drive = h.optical_drive }).ToList();

            //get cpu data for generateing graph in detail
            //var cpu = (from p in db.pallet where p.pallet_name == pallet_name join h in db.discovery on p.ictags equals h.ictag  select  new {cpu = h.cpu}).ToList().GroupBy(x=>x.cpu).Select(g=>g.First());
            var cpu_count = from l in result group l by l.cpu into g select new { cpu = g.Key, Count = (from l in g select l.cpu).Count() };
            var model_count = from l in result group l by l.model into g select new { model = g.Key, Count = (from l in g select l.model).Count() };
            var brand_count = from l in result group l by l.brand into g select new { brand = g.Key, Count = (from l in g select l.brand).Count() };
            var note = (from n in db.pallet where n.pallet_name == pallet_name select n.note).FirstOrDefault();
            return Json(new { note=note,cpu_count = cpu_count,model_count = model_count, brand_count=brand_count },JsonRequestBehavior.AllowGet);
        }


        public JsonResult remove_asset(string asset) {

            string message = "";
            //remove any pallet name from para
            try
            {
                using (var remove = new db_a094d4_demoEntities1())
                {
                    remove.Database.ExecuteSqlCommand(
                    "Delete from pallet where ictags = '" + asset + "'");
                }

                
                message = asset + " Has Been Deleted";
            }
            catch (Exception e)
            {
                message = e.Message;
            }

            return Json(message,JsonRequestBehavior.AllowGet);
        }

        public JsonResult remove_pallet(string pallet_name)
        {
            string message = "";
            //remove any pallet name from para
            try
            {
                using (var remove = new db_a094d4_demoEntities1())
                {
                    remove.Database.ExecuteSqlCommand(
                    "Delete from pallet where pallet_name = '" + pallet_name + "'");
                }


               message = pallet_name + " Has Been Deleted";
            }
            catch(Exception e)
            {
               message = e.Message;
            }

            return Json(message,JsonRequestBehavior.AllowGet);

        }


        public JsonResult submit_data(int[] input, string pallet_name)
        {
            List<string> message = new List<string>();

            for (int i = 0; i < input.Length; i++)
            {
                try
                {
                    using (var tran = new TransactionScope())
                    {
                        var entry = new pallet();

                        entry.ictags = input[i];
                        entry.pallet_name = pallet_name;
                       
                        db.pallet.Add(entry);
                        tran.Complete();
                        message.Add(input[i] + "Successfully Added to Pallet: " + pallet_name);

                    }

                    db.SaveChanges();
                }
                catch (Exception e)
                {
                    message.Add( input[i] + ":" + e.InnerException.InnerException.Message );
                    continue;
                }
            }
            

            return Json(new { message = message }, JsonRequestBehavior.AllowGet);
        }


       public JsonResult get_pallet(string pallet_name)
        {

            var result = (from t in db.pallet join h in db.discovery on t.ictags equals h.ictag where pallet_name == t.pallet_name select new { t.ictags,h.model,h.brand,h.serial, h.cpu, h.ram, h.hdd, h.optical_drive}).ToList();


           // var result = (from t in db.pallet where t.pallet_name == pallet_name select new { t.ictags, t.pallet_name }).ToList();

           
           
            return Json(result, JsonRequestBehavior.AllowGet);
        }


        public JsonResult mark_pallet(string pallet_name) {


            string message = "";
            //remove any pallet name from para
            try
            {
                using (var remove = new db_a094d4_demoEntities1())
                {
                    remove.Database.ExecuteSqlCommand(
                    "Update pallet set type = 'shipped' where pallet_name = '" + pallet_name + "'");
                }


                message = pallet_name + " Has Been Mark as Shipped You can View it at Shipped Tab";
            }
            catch (Exception e)
            {
                message = e.Message;
            }

            return Json(message, JsonRequestBehavior.AllowGet);


           
        }

        public JsonResult get_data ()
        {
            //gather all pallet infomation for the pallet index page
            var not_shipped = db.Database.SqlQuery<Models.SQLModel.PalletData>("select pallet_name, count(*) as num from pallet where type != 'shipped' or type is null group by pallet_name").ToList<Models.SQLModel.PalletData>();
            var shipped = db.Database.SqlQuery<Models.SQLModel.PalletData>("select pallet_name, count(*) as num from pallet where type = 'shipped' group by pallet_name").ToList<Models.SQLModel.PalletData>();

            return Json(new { not_shipped= not_shipped , shipped = shipped },JsonRequestBehavior.AllowGet);
        }



        // POST: pallets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            pallet pallet = db.pallet.Find(id);
            db.pallet.Remove(pallet);
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
