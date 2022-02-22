using Autofac;
using Framework.Entities;
using Framework.Services;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FoodDelivery.web.Areas.Admin.Models
{
    public class ItemModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please Enter Name")]
        public string Name { get; set; }
        public IFormFile File { get; set; }

        [Required(ErrorMessage = "Please Enter Description")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Please Enter UnitPrice")]
        public decimal UnitPrice { get; set; }
        public string ImageUrl { get; set; }

        [Required(ErrorMessage = "Please Select Category")]
        public int CategoryId { get; set; }

        //[Required(ErrorMessage = "Please Select Item")]
        public int ItemTypeId { get; set; }

        protected readonly ICatalogueServices _catatalogueservices;
        public ItemModel(ICatalogueServices catatalogueservices)
        {
            _catatalogueservices = catatalogueservices;
        }

        public ItemModel()
        {
            _catatalogueservices = Startup.AutofacContainer.Resolve<ICatalogueServices>();
        }


        //public IEnumerable<Item> get()
        //{
        //    var data = _catatalogueservices.GetItems().ToList();
        //    return data;
        //}

    }
}
