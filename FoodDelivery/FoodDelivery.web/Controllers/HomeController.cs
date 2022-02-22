using FoodDelivery.web.Models;
using Framework.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace FoodDelivery.web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        ICatalogueServices _catalogueServices;
        public HomeController(ILogger<HomeController> logger, ICatalogueServices catalogueServices)
        {
            _logger = logger;
            _catalogueServices = catalogueServices;
        }

        public IActionResult Index()
        {
            var items = _catalogueServices.GetItems();
            return View(items);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
