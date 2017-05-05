using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IT_Heaven.Data.Services;
using IT_Heaven.Resources.Helpers;

namespace IT_Heaven.Controllers
{
    public enum MessageIds
    {
        None,
        DeletionSuccess,
        DeletionFailure,
        EditSuccess,
        EditFailure,
        AddSuccess,
        AddFailure
    }
    public class HomeController : Controller
    {
        Service service = new Service();

        public ActionResult Index()
        {
            ViewBag.Active = "home";
            ViewBag.Bagged = false;
            if(StaticResources.Message != MessageIds.None)
            {
                ViewBag.Bagged = true;
                ViewBag.Message = GetMessage(StaticResources.Message);
                ViewBag.MessageClass = GetMessageClass(StaticResources.Message);
                StaticResources.Message = MessageIds.None;
            }
           
            var model = service.GetHomeModel();
            return View(model);
        }
     

        public ActionResult About()
        {
            ViewBag.Active = "about";
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Active = "contact";
            return View();
        }

        private string GetMessage(MessageIds msg)
        {
  
            switch (msg)
            {
                case MessageIds.AddFailure: return "Article failed to add!";
                case MessageIds.AddSuccess: return "Article added successfuly!";
                case MessageIds.DeletionFailure: return "Cannot delete article!";
                case MessageIds.DeletionSuccess: return "Article deleted successfuly!";
                case MessageIds.EditFailure: return "Article failed to edit!";
                case MessageIds.EditSuccess: return "Article edited successfuly!";
                default: return "";
            }


        }
        private string GetMessageClass(MessageIds msg)
        {
            switch (msg)
            {
                case MessageIds.AddSuccess:
                case MessageIds.DeletionSuccess: 
                case MessageIds.EditSuccess: return "alert alert-success alert-dismissible";
           
                case MessageIds.AddFailure: 
                case MessageIds.DeletionFailure:              
                case MessageIds.EditFailure: return "alert alert-danger alert-dismissible";
                default: return "";
            }
        }
    }
}