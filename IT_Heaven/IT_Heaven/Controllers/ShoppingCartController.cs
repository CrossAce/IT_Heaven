using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IT_Heaven.Data.Services;


namespace IT_Heaven.Controllers
{
    [Authorize]
    public class ShoppingCartController : Controller
    {
        Service service = new Service();

        // GET: ShoppingCart
        [Route("/ShoppingCart")]
        public ActionResult Cart()
        {
            var model = service.GetShopingNodes(User.Identity.Name);
            return View(model);
        }

        [HttpGet]
        public ActionResult Remove(int id)
        {
            if (service.RemoveShoppingNodes(id))
            {
                return Json("1", JsonRequestBehavior.AllowGet);
            }
            return Json("0", JsonRequestBehavior.AllowGet);
        }
    }
}