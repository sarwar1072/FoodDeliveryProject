using Framework.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace FoodDelivery.web.ViewComponentForMenu
{
    public class MenuViewComponent:ViewComponent
    {
        ICatalogueServices _catalogueService;
        
        public MenuViewComponent(ICatalogueServices catalogueService)
        {
            _catalogueService = catalogueService;
        }
        public IViewComponentResult Invoke()
        {
            var items = _catalogueService.GetItems();
            return View("~/Views/Shared/_PizzaMenu.cshtml", items);
        }
        //public IViewComponentResult Invoke1()
        //{
        //    var items = _catalogueService.GetItems();
        //    return View("~/Views/Shared/_PizzaMenu.cshtml", items);
        //}
    }
}
