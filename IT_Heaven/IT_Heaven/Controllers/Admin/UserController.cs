using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IT_Heaven.Data.Services;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System.Threading.Tasks;

namespace IT_Heaven.Controllers.Admin
{
    [Authorize(Roles = "Admin")]
    public class UserController : Controller
    {
        private ApplicationUserManager _userManager;
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

        SpecialUserService service = new SpecialUserService();
        [HttpGet]
        public ActionResult Users(string id)
        {
            ViewBag.AccountType = service.UserIsInRole(User);
            var model = service.GetUsersViewModel();
            return View(model);
        }

        [HttpPost]
        public ActionResult ChangeRole(string id)
        {
            var result = UserManager.IsInRole(id, "Helper");
            if (result)
            {
                UserManager.RemoveFromRoles(id, "Helper");
                UserManager.AddToRole(id, "User");
                return Json("User", JsonRequestBehavior.AllowGet);
            }
            else
            {
                UserManager.RemoveFromRoles(id, "User");
                UserManager.AddToRole(id, "Helper");
                return Json("Helper", JsonRequestBehavior.AllowGet);
            }

        }
        [HttpPost]
        public ActionResult Delete(string id)
        {
            if (service.DeleteUser(id))
                return Json("1", JsonRequestBehavior.AllowGet);
            return Json("0", JsonRequestBehavior.AllowGet);
        }
    }
}