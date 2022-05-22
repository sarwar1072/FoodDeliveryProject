using Autofac;
using FoodDelivery.web.Areas.Admin.Models;
using FoodDelivery.web.Models;
using Framework.Entities;
using Framework.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodDelivery.web.Areas.Admin.Controllers
{
    public class ItemController : BaseController
    {
        IFileHelper _fileHelper;
        ICatalogueServices _catalogueServices;
        public ItemController(ICatalogueServices catalogueServices, IFileHelper fileHelper)
        {
            _catalogueServices = catalogueServices;
            _fileHelper = fileHelper;

        }

        public IActionResult Index()
        {
            var data = _catalogueServices.GetItems();
            return View(data);
        }

        public IActionResult Create()
        {
            ViewBag.Categories = _catalogueServices.GetCategories();
            ViewBag.ItemTypes = _catalogueServices.GetItemTypes();
            return View();
        }
        [HttpPost]
        public IActionResult Create(ItemModel model)
        {
            try
            {
                model.ImageUrl = _fileHelper.UploadFile(model.File);
                Item data = new Item
                {
                    Name = model.Name,
                    UnitPrice = model.UnitPrice,
                    CategoryId = model.CategoryId,
                    ItemTypeId = model.ItemTypeId,
                    Description = model.Description,
                    ImageUrl = model.ImageUrl
                };
                _catalogueServices.AddItem(data);
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
            }
            ViewBag.Categories = _catalogueServices.GetCategories();
            ViewBag.ItemTypes = _catalogueServices.GetItemTypes();
            return View();
        }
        public IActionResult Edit(int id)
        {
            ViewBag.Categories = _catalogueServices.GetCategories();
            ViewBag.ItemTypes = _catalogueServices.GetItemTypes();
            var data = _catalogueServices.GetItem(id);
            var model = new ItemModel()
            {
                Id = data.Id,
                Name = data.Name,
                UnitPrice = data.UnitPrice,
                CategoryId = data.CategoryId,
                ItemTypeId = data.ItemTypeId,
                Description = data.Description,
                ImageUrl = data.ImageUrl

            };
            return View("Create", model);
        }
        [HttpPost]
        public IActionResult Edit(ItemModel model)
        {
            try
            {
                if (model.File != null)
                { 
                    _fileHelper.DeleteFile(model.ImageUrl);
                    model.ImageUrl = _fileHelper.UploadFile(model.File);
                }
                Item data = new Item
                {
                    Id = model.Id,
                    Name = model.Name,
                    UnitPrice = model.UnitPrice,
                    CategoryId = model.CategoryId,
                    ItemTypeId = model.ItemTypeId,
                    Description = model.Description,
                    ImageUrl = model.ImageUrl
                };
                _catalogueServices.UpdateItem(data);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
            }
            ViewBag.Categories = _catalogueServices.GetCategories();
            ViewBag.ItemTypes = _catalogueServices.GetItemTypes();
            return View("Create", model);
        }

        [Route("~/Admin/Item/Delete/{id}/{url}")]
        public IActionResult Delete(int id, string url)
        {
            url = url.Replace("%2F", "/"); //replace to find the file

            _catalogueServices.DeleteItem(id);
            _fileHelper.DeleteFile(url);
            return RedirectToAction("Index");
        }
    }
}
