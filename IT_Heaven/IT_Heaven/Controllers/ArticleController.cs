using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IT_Heaven.Models.Models.BindingModels;
using IT_Heaven.Data.Services;
using System.Web.Routing;
using IT_Heaven.Resources.Helpers;

namespace IT_Heaven.Controllers
{
    
    public class ArticleController : Controller
    {
        SpecialUserService service = new SpecialUserService();

        [Authorize(Roles = "Admin, Helper")]
        [HttpGet]
        public ActionResult Add()
        {
            ViewBag.AccountType = service.UserIsInRole(User);
            return View(service.GetArticleBindingModel());
        }

        [Authorize(Roles = "Admin, Helper")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(AddArticleBindingModel model, HttpPostedFileBase file)
        {
            if (!ModelState.IsValid && file != null)
            {
                ViewBag.AccountType = service.UserIsInRole(User);
                ViewBag.Error = true;
                return View(service.GetArticleBindingModel());
            }
            else
            {
                bool result = service.AddArticle(model, file);
                if (result)
                    return RedirectToAction("Index", "Home");
                else
                {
                    ViewBag.AccountType = service.UserIsInRole(User);
                    ViewBag.Error = true;
                    return View(service.GetArticleBindingModel());
                }

            }
        }
  
        [Authorize(Roles = "Admin, Helper")]
        [HttpGet]
        public ActionResult Edit(string id)
        {
            if(id == null)
                return View("InvadersError");
            try
            {
                if(!id.Contains("GetInfoJS"))
                {
                    var model = service.GetEditModel(int.Parse(id));
                    if (model != null)
                        return View(model);

                    StaticResources.Message = MessageIds.EditFailure;
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    return GetInfoJS(int.Parse(id.Split('=')[1]));
                }
             
            }
            catch { return View("InvadersError"); }
        }

        [Authorize(Roles = "Admin, Helper")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(EditBindingModel model, HttpPostedFileBase file)
        {
            if (!ModelState.IsValid )
            {
                ViewBag.Error = true;
                model = service.GetEditModel(model.Id);
                if (model != null)
               return View(model);
            }
            else if(service.EditArticle(model, file))
            {
                StaticResources.Message = MessageIds.EditSuccess;
                return RedirectToAction("Index", "Home");
            }
            StaticResources.Message = MessageIds.EditFailure;
            return RedirectToAction("Index", "Home");
        }         

        [HttpGet]
       
        public ActionResult Details(string id)
        {
            if(id == null)
            {
                return View("InvadersError");
            }
            if (id.Contains("AddToCart"))
            {
                return AddToCart(int
                    .Parse(id.Split('=')[1]));
            }
            else
            {
                ViewBag.AccountType = service.UserIsInRole(User);
                var model = service.GetArticleViewModel(int.Parse(id));
                if(model == null) return View("InvadersError");
                return View(model);
            }
           
        }

        [HttpGet]
        [Authorize(Roles = "Admin, Helper")]
        public ActionResult Delete(int id)
        {
            if (service.DeleteArticle(id))
            {
                StaticResources.Message = MessageIds.DeletionSuccess;
                return RedirectToAction("Index", "Home");
            }
            StaticResources.Message = MessageIds.DeletionFailure;
            return RedirectToAction("Index", "Home");

        }
       
        [Authorize(Roles = "Admin, Helper")]
        [HttpGet]
        public ActionResult GetInfoJS(int? q)
        {          
            
                try
                {
                    return Json(service.JsonString(q),JsonRequestBehavior.AllowGet);
                }
                catch { }
                           
           
            return Json(0,JsonRequestBehavior.AllowGet);


        }             
        private ActionResult AddToCart(int id)
        {
            if(User != null)
            {
                try
                {
                    if (service.Add_or_RemoveToCart(User.Identity.Name, id))
                        return Json("1", JsonRequestBehavior.AllowGet);
                    
                }
                catch { } 
            }
            return Json("0", JsonRequestBehavior.AllowGet);
        }
    }
}