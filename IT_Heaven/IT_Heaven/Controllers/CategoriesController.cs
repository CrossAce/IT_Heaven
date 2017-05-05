using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IT_Heaven.Models.Models.ViewModels;
using System.ComponentModel.DataAnnotations;
using IT_Heaven.Data.Services;
using IT_Heaven.Models.Models.BindingModels;
using IT_Heaven.Models.CategoriesSemiModels;
using IT_Heaven.Resources.Helpers;

namespace IT_Heaven.Controllers
{
    [AllowAnonymous]
    public class CategoriesController : Controller
    {
        Service service = new Service();

        #region MainCategory

        public ActionResult SmartPhones_Tablets_Acessories()
        {
            var navViewModel = service.GetNavModel(0,
                CategoriesInformation.CategoriesEnum.Smartphones, CategoriesInformation.CategoriesEnum.Tablets,
                CategoriesInformation.CategoriesEnum.Smartphone_Accessories, CategoriesInformation.CategoriesEnum.Tablet_Accessories
                );
            return View("Categories", navViewModel);
        }
        public ActionResult Computers_Gaming_Peripherals()
        {
            var navViewModel = service.GetNavModel(1,
                CategoriesInformation.CategoriesEnum.Computers, CategoriesInformation.CategoriesEnum.PC_Components,
                CategoriesInformation.CategoriesEnum.Consoles, CategoriesInformation.CategoriesEnum.Peripherals);
            return View("Categories", navViewModel);
        }
        public ActionResult TV_Audio()
        {
            var navViewModel = service.GetNavModel(2, CategoriesInformation.CategoriesEnum.TVs, CategoriesInformation.CategoriesEnum.Audio_systems);
            return View("Categories", navViewModel);
        }
        public ActionResult CarNavigations()
        {
            return View();
        }
        public ActionResult BikeComputers()
        {
            return View();
        }
        public ActionResult Microcontrollers()
        {
            var navViewModel = service.GetNavModel(3,
                CategoriesInformation.CategoriesEnum.Rasberry_PI, 
                CategoriesInformation.CategoriesEnum.Arduino, CategoriesInformation.CategoriesEnum.Components);
            return View("Categories", navViewModel);
        }
        public ActionResult Software()
        {
            var navViewModel = service.GetNavModel(4,
                CategoriesInformation.CategoriesEnum.Windows_software,
                CategoriesInformation.CategoriesEnum.Mac_software, CategoriesInformation.CategoriesEnum.Games);
            return View("Categories", navViewModel);
        }
        #endregion

        [HttpGet]        
        //error handle view
        public ActionResult SingleCategory(int categoryId)
        {
            var model = service.GetCategoryArticleModel((CategoriesInformation.CategoriesEnum)categoryId);
            StaticResources.CurrentCategory = categoryId;
            return View("Articles", model);
        }
        [HttpPost]
        //error handle view
        public ActionResult SingleCategory(CategoryArticleViewModel model)
        {
            if (StaticResources.CurrentCategory == 0)
                RedirectToAction("Index", "Home");
            if(ModelState.IsValid)
            {
                var sortedModel = service.GetSorted_CAM((CategoriesInformation.CategoriesEnum)StaticResources.CurrentCategory, model.SortBar);
                return View("Articles", sortedModel);
            }
            return SingleCategory(StaticResources.CurrentCategory);
        }
  
    }
}