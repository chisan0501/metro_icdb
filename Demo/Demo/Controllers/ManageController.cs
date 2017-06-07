﻿using System;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Demo.Models;
using System.Collections.Generic;
using System.Transactions;
using System.Data.Entity;

namespace Demo.Controllers
{
    [Authorize]
    public class ManageController : Controller
    {

        db_a094d4_demoEntities1 db = new db_a094d4_demoEntities1();
        private ApplicationSignInManager _signInManager;
        private ApplicationUserManager _userManager;

        public ManageController()
        {
        }

        public ManageController(ApplicationUserManager userManager, ApplicationSignInManager signInManager)
        {
            UserManager = userManager;
            SignInManager = signInManager;
        }

        public ApplicationSignInManager SignInManager
        {
            get
            {
                return _signInManager ?? HttpContext.GetOwinContext().Get<ApplicationSignInManager>();
            }
            private set 
            { 
                _signInManager = value; 
            }
        }

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        //
        // GET: /Manage/Index
        public async Task<ActionResult> Index(ManageMessageId? message)
        {
            ViewBag.StatusMessage =
                message == ManageMessageId.ChangePasswordSuccess ? "Your password has been changed."
                : message == ManageMessageId.SetPasswordSuccess ? "Your password has been set."
                : message == ManageMessageId.SetTwoFactorSuccess ? "Your two-factor authentication provider has been set."
                : message == ManageMessageId.Error ? "An error has occurred."
                : message == ManageMessageId.AddPhoneSuccess ? "Your phone number was added."
                : message == ManageMessageId.RemovePhoneSuccess ? "Your phone number was removed."
                : "";

            var userId = User.Identity.GetUserId();
            var model = new IndexViewModel
            {
                HasPassword = HasPassword(),
                PhoneNumber = await UserManager.GetPhoneNumberAsync(userId),
                TwoFactor = await UserManager.GetTwoFactorEnabledAsync(userId),
                Logins = await UserManager.GetLoginsAsync(userId),
                BrowserRemembered = await AuthenticationManager.TwoFactorBrowserRememberedAsync(userId)
            };
            return View(model);
        }

        //
        // POST: /Manage/RemoveLogin
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> RemoveLogin(string loginProvider, string providerKey)
        {
            ManageMessageId? message;
            var result = await UserManager.RemoveLoginAsync(User.Identity.GetUserId(), new UserLoginInfo(loginProvider, providerKey));
            if (result.Succeeded)
            {
                var user = await UserManager.FindByIdAsync(User.Identity.GetUserId());
                if (user != null)
                {
                    await SignInManager.SignInAsync(user, isPersistent: false, rememberBrowser: false);
                }
                message = ManageMessageId.RemoveLoginSuccess;
            }
            else
            {
                message = ManageMessageId.Error;
            }
            return RedirectToAction("ManageLogins", new { Message = message });
        }

        //
        // GET: /Manage/AddPhoneNumber
        public ActionResult AddPhoneNumber()
        {
            return View();
        }

        [HttpPost]
       
        public ActionResult gen_server_url(string server_address, string user_name,string password, string db_name)
        {
          var content =  gen_config.gen_file(server_address, user_name, password, db_name);
            Response.Clear();
            Response.ClearContent();
            Response.ClearHeaders();
            Response.AddHeader("content-disposition", "attachment;filename=query.exe.config");
            Response.ContentType = "text/csv";
            Response.Write(content);
            Response.End();


            return View();

        }

        //
        // POST: /Manage/AddPhoneNumber
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> AddPhoneNumber(AddPhoneNumberViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            // Generate the token and send it
            var code = await UserManager.GenerateChangePhoneNumberTokenAsync(User.Identity.GetUserId(), model.Number);
            if (UserManager.SmsService != null)
            {
                var message = new IdentityMessage
                {
                    Destination = model.Number,
                    Body = "Your security code is: " + code
                };
                await UserManager.SmsService.SendAsync(message);
            }
            return RedirectToAction("VerifyPhoneNumber", new { PhoneNumber = model.Number });
        }

        //
        // POST: /Manage/EnableTwoFactorAuthentication
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EnableTwoFactorAuthentication()
        {
            await UserManager.SetTwoFactorEnabledAsync(User.Identity.GetUserId(), true);
            var user = await UserManager.FindByIdAsync(User.Identity.GetUserId());
            if (user != null)
            {
                await SignInManager.SignInAsync(user, isPersistent: false, rememberBrowser: false);
            }
            return RedirectToAction("Index", "Manage");
        }

        //
        // POST: /Manage/DisableTwoFactorAuthentication
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DisableTwoFactorAuthentication()
        {
            await UserManager.SetTwoFactorEnabledAsync(User.Identity.GetUserId(), false);
            var user = await UserManager.FindByIdAsync(User.Identity.GetUserId());
            if (user != null)
            {
                await SignInManager.SignInAsync(user, isPersistent: false, rememberBrowser: false);
            }
            return RedirectToAction("Index", "Manage");
        }

        //
        // GET: /Manage/VerifyPhoneNumber
        public async Task<ActionResult> VerifyPhoneNumber(string phoneNumber)
        {
            var code = await UserManager.GenerateChangePhoneNumberTokenAsync(User.Identity.GetUserId(), phoneNumber);
            // Send an SMS through the SMS provider to verify the phone number
            return phoneNumber == null ? View("Error") : View(new VerifyPhoneNumberViewModel { PhoneNumber = phoneNumber });
        }

        //
        // POST: /Manage/VerifyPhoneNumber
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> VerifyPhoneNumber(VerifyPhoneNumberViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var result = await UserManager.ChangePhoneNumberAsync(User.Identity.GetUserId(), model.PhoneNumber, model.Code);
            if (result.Succeeded)
            {
                var user = await UserManager.FindByIdAsync(User.Identity.GetUserId());
                if (user != null)
                {
                    await SignInManager.SignInAsync(user, isPersistent: false, rememberBrowser: false);
                }
                return RedirectToAction("Index", new { Message = ManageMessageId.AddPhoneSuccess });
            }
            // If we got this far, something failed, redisplay form
            ModelState.AddModelError("", "Failed to verify phone");
            return View(model);
        }

        //
        // POST: /Manage/RemovePhoneNumber
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> RemovePhoneNumber()
        {
            var result = await UserManager.SetPhoneNumberAsync(User.Identity.GetUserId(), null);
            if (!result.Succeeded)
            {
                return RedirectToAction("Index", new { Message = ManageMessageId.Error });
            }
            var user = await UserManager.FindByIdAsync(User.Identity.GetUserId());
            if (user != null)
            {
                await SignInManager.SignInAsync(user, isPersistent: false, rememberBrowser: false);
            }
            return RedirectToAction("Index", new { Message = ManageMessageId.RemovePhoneSuccess });
        }

        //
        // GET: /Manage/ChangePassword
        public ActionResult ChangePassword()
        {
            return View();
        }

        //
        // POST: /Manage/ChangePassword
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ChangePassword(ChangePasswordViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var result = await UserManager.ChangePasswordAsync(User.Identity.GetUserId(), model.OldPassword, model.NewPassword);
            if (result.Succeeded)
            {
                var user = await UserManager.FindByIdAsync(User.Identity.GetUserId());
                if (user != null)
                {
                    await SignInManager.SignInAsync(user, isPersistent: false, rememberBrowser: false);
                }
                return RedirectToAction("Index", new { Message = ManageMessageId.ChangePasswordSuccess });
            }
            AddErrors(result);
            return View(model);
        }

        //
        // GET: /Manage/SetPassword
        public ActionResult SetPassword()
        {
            return View();
        }

        //
        // POST: /Manage/SetPassword
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> SetPassword(SetPasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await UserManager.AddPasswordAsync(User.Identity.GetUserId(), model.NewPassword);
                if (result.Succeeded)
                {
                    var user = await UserManager.FindByIdAsync(User.Identity.GetUserId());
                    if (user != null)
                    {
                        await SignInManager.SignInAsync(user, isPersistent: false, rememberBrowser: false);
                    }
                    return RedirectToAction("Index", new { Message = ManageMessageId.SetPasswordSuccess });
                }
                AddErrors(result);
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        //
        // GET: /Manage/ManageLogins
        public async Task<ActionResult> ManageLogins(ManageMessageId? message)
        {
            ViewBag.StatusMessage =
                message == ManageMessageId.RemoveLoginSuccess ? "The external login was removed."
                : message == ManageMessageId.Error ? "An error has occurred."
                : "";
            var user = await UserManager.FindByIdAsync(User.Identity.GetUserId());
            if (user == null)
            {
                return View("Error");
            }
            var userLogins = await UserManager.GetLoginsAsync(User.Identity.GetUserId());
            var otherLogins = AuthenticationManager.GetExternalAuthenticationTypes().Where(auth => userLogins.All(ul => auth.AuthenticationType != ul.LoginProvider)).ToList();
            ViewBag.ShowRemoveButton = user.PasswordHash != null || userLogins.Count > 1;
            return View(new ManageLoginsViewModel
            {
                CurrentLogins = userLogins,
                OtherLogins = otherLogins
            });
        }

        public string add_station_db(string prefix,string station_name) {

            string message = "";

            try
            {
                using (db = new db_a094d4_demoEntities1())
                {
                    var station = new station_setting();
                    station.station_name = station_name;
                    station.station_dropdown_value = prefix + station_name;
                    db.station_setting.Add(station);
                    db.SaveChanges();

                    message =(prefix + station_name + " has been added to station list");

                }
            }
            catch (Exception e)
            {
                message = (e.InnerException.InnerException.Message);
            }

            return message;
            
        }

        public ActionResult station() {


            return View();
        }

        [HttpPost]
        public JsonResult create_station_data(station_setting station)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return Json(new { Result = "ERROR", Message = "Form is not valid! Please correct it and try again." });
                }

                station_setting addstation = db.station_setting.Add(station);
                return Json(new { Result = "OK", Record = addstation });
            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR", Message = ex.Message });
            }
        }

        public ActionResult assetTag()
        {

            return View();

        }

        public ActionResult dymo_label() {

            return View();
        }
        public JsonResult update_station_data(station_setting station) {

            try
            {
                if (!ModelState.IsValid)
                {
                    return Json(new { Result = "ERROR", Message = "Form is not valid! Please correct it and try again." });
                }

                
                db.Entry(station).State = EntityState.Modified;
                db.SaveChanges();



                return Json(new { Result = "OK" }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR", Message = ex.Message }, JsonRequestBehavior.AllowGet);
            }


            
        }


        public string process_sku(string input) {
            string result = "";

            

            return result;
        }

        public JsonResult get_coas_station()
        {

            var result = (from t in db.station_setting select t.station_dropdown_value).ToList();

            return Json(result, JsonRequestBehavior.AllowGet);
        }
        public JsonResult get_sub_channel(string sub) {

            var result = (from t in db.label_menu where t.name == sub select t.product).ToList();

            return Json(result,JsonRequestBehavior.AllowGet);
        }

        public JsonResult get_channel() {

            var result = (from t in db.label_menu select t.name).ToList().Distinct();


            return Json(result,JsonRequestBehavior.AllowGet);
        }

        public JsonResult get_dymo (string asset_tag, string sub, string channel,string grade) {


            SQLModel.RefrubHistoryObj RefrubHistoryObj = new SQLModel.RefrubHistoryObj();
            int Intasset_tag = int.Parse(asset_tag);
            var hardware_result = (from t in db.rediscovery where t.ictag == Intasset_tag select t).FirstOrDefault();

            switch (channel)
            {
                case "Tableau (Laptop)":
                case "Tableau (Desktop)":
                case "NGO":
                case "OEM (Desktop)":
                case "OEM (Laptop)":
                case "Mar (Desktop)":
                case "Mar (Laptop)":
                    //format the sku before passing on
                    string temp_cpu;
                    //create the temp variable to hold the sku construct info 
                    var brand_name = magento_sku.brand_name();
                    foreach (var brand in brand_name)
                    {
                        if (hardware_result.brand.Equals(brand.Key, StringComparison.InvariantCultureIgnoreCase))
                        {
                            RefrubHistoryObj.brand = brand.Key;
                        }
                        else
                        {
                            RefrubHistoryObj.brand = "Generic";
                        }
                    }


                    //  var temp_brand = magento_sku.compute_difference(RefrubHistoryObj.made, magento_sku.brand_name());

                    if (channel == "NGO")
                    {
                        temp_cpu = magento_sku.ngo_title(RefrubHistoryObj);
                    }
                    else
                    {
                        temp_cpu = magento_sku.comput_title(RefrubHistoryObj);
                    }

                    RefrubHistoryObj.ram = magento_sku.ram_format(RefrubHistoryObj, false);
                    RefrubHistoryObj.hdd = magento_sku.hdd_format(false, RefrubHistoryObj);
                    RefrubHistoryObj.grade = grade;

                    var magento_listing = listing.listing_info(RefrubHistoryObj);
                    RefrubHistoryObj = magento_sku.format_sku(RefrubHistoryObj);

                    RefrubHistoryObj.sku = RefrubHistoryObj.brand + "_" + RefrubHistoryObj.model + "_" + temp_cpu + "_" + RefrubHistoryObj.ram + "_" + RefrubHistoryObj.hdd + RefrubHistoryObj.type + RefrubHistoryObj.grade;


                    break;
                case "Online Order":
                    await _dialogCoordinator.ShowInputAsync(this, "Online Order", "Please Enter Order #").ContinueWith(t => sku = (t.Result));
                    RefrubHistoryObj.sku = sku;
                    break;
                case "My Channel is not Listed":
                    await _dialogCoordinator.ShowInputAsync(this, "Custom Channel", "Please Enter Channel Name").ContinueWith(t => sku = (t.Result));
                    RefrubHistoryObj.sku = sku;

                    break;
                default:
                    RefrubHistoryObj.sku = sub + grade;

                    break;

            }




            RefrubHistoryObj.asset_tag = Intasset_tag;
            RefrubHistoryObj.cpu = hardware_result.cpu;
            RefrubHistoryObj.hdd = hardware_result.hdd;
            RefrubHistoryObj.ram = hardware_result.ram;
            RefrubHistoryObj.serial = hardware_result.serial;
            
            return Json(RefrubHistoryObj, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult delete_station_data(station_setting station)
        {
            try
            {
                db.station_setting.Remove(station);
                return Json(new { Result = "OK" });
            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR", Message = ex.Message });
            }
        }

        public JsonResult get_station_data(int jtStartIndex, int jtPageSize, string jtSorting = null) {
            var count = (from d in db.station_setting select d).Count();
            var result = (from t in db.station_setting select t).ToList();
            return Json(new { Result = "OK", Records = result, TotalRecordCount = count }, JsonRequestBehavior.AllowGet);
        }



        public JsonResult import_coa(List<COAs_model.Class1> input) {

            List<string> message = new List<string>();
            using (db = new db_a094d4_demoEntities1())
            {

                    foreach (var item in input)
                    {
                        try {
                            var coas = new coas();
                            coas.COA_ID = item.COAID;
                            coas.License_Type = item.LicenseType;
                            coas.PDF_language = item.PDFlanguage;
                            coas.Pre_existing_COA_ID = item.PreexistingCOAID;
                            coas.PK = item.ProductKey;
                            coas.Product_Name = item.ProductName;
                            coas.Recipient_City = item.RecipientCity;
                            coas.Recipient_Country___Region = item.RecipientCountryRegion;
                            coas.Recipient_Organization_Name = item.RecipientOrganizationName;
                            coas.Recipient_Type = item.RecipientType;
                            coas.Request_ID = item.RequestID;

                            db.coas.Add(coas);
                            db.SaveChanges();
                            message.Add(item.COAID + " Has Added to Database");

                        }
                        catch (Exception e) {
                            message.Add(e.InnerException.InnerException.Message);
                        }
                    }

                
            }



            return Json(new { message = message },JsonRequestBehavior.AllowGet);
        }

        public JsonResult reset_asset(string asset) {

            string message = "";
            try
            {
                using (var db = new db_a094d4_demoEntities1())
                {
                    db.Database.ExecuteSqlCommand(
                    "Update asset_tag_counter set count = '" + asset + "'");
                }


                message = "Asset Tag Has Been Reset to " + asset;
            }
            catch (Exception e)
            {
                message = e.Message;
            }




            return Json(message,JsonRequestBehavior.AllowGet);
        }





        public JsonResult Get_role() {


            var role = (from r in db.aspnetroles select r.Name).ToList();
            var name = (from n in db.aspnetusers select n.Email).ToList();

            return Json(new { role = role,name = name},JsonRequestBehavior.AllowGet);
        }

        public JsonResult RoleAddToUser(string UserName, string RoleName) {



            var message = "";
            try {

                var context = new ApplicationDbContext();
                ApplicationUser user = context.Users.Where(u => u.Email.Equals(UserName, StringComparison.CurrentCultureIgnoreCase)).FirstOrDefault();
                var oldRoleId = user.Roles.SingleOrDefault().RoleId;
                var oldRoleName = context.Roles.SingleOrDefault(r => r.Id == oldRoleId).Name;
                var account = new AccountController();
                if (user != null)
                {
                    UserManager.RemoveFromRole(user.Id, oldRoleName);
                    UserManager.AddToRole(user.Id, RoleName);

                    message = "Role created successfully, Please Relogin to see the changes";

                }

            }
            catch(Exception e)
            {
                message = e.Message;
            }
            
           




            return Json(message,JsonRequestBehavior.AllowGet);
        }

        public JsonResult get_counter_number()
        {

            var result = (from t in db.asset_tag_counter select t.count).FirstOrDefault();


            return Json(result,JsonRequestBehavior.AllowGet);
        }

        //
        // POST: /Manage/LinkLogin
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LinkLogin(string provider)
        {
            // Request a redirect to the external login provider to link a login for the current user
            return new AccountController.ChallengeResult(provider, Url.Action("LinkLoginCallback", "Manage"), User.Identity.GetUserId());
        }

        

        //
        // GET: /Manage/LinkLoginCallback
        public async Task<ActionResult> LinkLoginCallback()
        {
            var loginInfo = await AuthenticationManager.GetExternalLoginInfoAsync(XsrfKey, User.Identity.GetUserId());
            if (loginInfo == null)
            {
                return RedirectToAction("ManageLogins", new { Message = ManageMessageId.Error });
            }
            var result = await UserManager.AddLoginAsync(User.Identity.GetUserId(), loginInfo.Login);
            return result.Succeeded ? RedirectToAction("ManageLogins") : RedirectToAction("ManageLogins", new { Message = ManageMessageId.Error });
        }

        public ActionResult users (){


            return View();
        }

        public ActionResult coas() {

            return View();
        }

        [HttpPost]
        public JsonResult create_user(RegisterViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return Json(new { Result = "ERROR", Message = "Form is not valid! Please correct it and try again." });
                }

                model.UserName = model.Email;
                var user = new ApplicationUser { UserName = model.Email };
                user.Email = user.UserName;
                var result = UserManager.CreateAsync(user, model.Password);
                return Json(new { Result = "OK", Record = result });
            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR", Message = ex.Message });
            }
        }

        public JsonResult update_user_data(aspnetusers user,string Roles) {

            Roles = (from t in db.aspnetroles where t.Name == Roles select t.Id).FirstOrDefault();

            try
            {
                if (!ModelState.IsValid)
                {
                    return Json(new { Result = "ERROR", Message = "Form is not valid! Please correct it and try again." });
                }

                db.Database.ExecuteSqlCommand(
        "UPDATE aspnetuserroles SET RoleID = '" + Roles + "' WHERE UserID = '"+user.Id+"'");
                db.Entry(user).State = EntityState.Modified;
                db.SaveChanges();



                return Json(new { Result = "OK" }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR", Message = ex.Message }, JsonRequestBehavior.AllowGet);
            }


        }
        public JsonResult get_user_data(int jtStartIndex, int jtPageSize, string jtSorting = null)
        {
            var count = (from d in db.aspnetusers select d).Count();

            var result   = from u in db.aspnetusers
                        from ur in u.aspnetroles
                        join r in db.aspnetroles on ur.Id equals r.Id
                        select new
                        {
                            Id = u.Id,
                            Email = u.Email,
                            UserName = u.UserName,
                            Roles = r.Name,
                        };




            return Json(new { Result = "OK", Records = result, TotalRecordCount = count }, JsonRequestBehavior.AllowGet);

        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && _userManager != null)
            {
                _userManager.Dispose();
                _userManager = null;
            }

            base.Dispose(disposing);
        }

#region Helpers
        // Used for XSRF protection when adding external logins
        private const string XsrfKey = "XsrfId";

        private IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }

        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
        }

        private bool HasPassword()
        {
            var user = UserManager.FindById(User.Identity.GetUserId());
            if (user != null)
            {
                return user.PasswordHash != null;
            }
            return false;
        }

      

        public enum ManageMessageId
        {
            AddPhoneSuccess,
            ChangePasswordSuccess,
            SetTwoFactorSuccess,
            SetPasswordSuccess,
            RemoveLoginSuccess,
            RemovePhoneSuccess,
            Error
        }

#endregion
    }
}