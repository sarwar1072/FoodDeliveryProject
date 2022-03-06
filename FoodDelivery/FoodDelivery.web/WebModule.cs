using Autofac;
using FoodDelivery.web.Areas.Admin.Models;
using FoodDelivery.web.Models;
using Framework.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace FoodDelivery.web
{
    public class WebModule : Module
    {
        private readonly string _connectionString;
        private readonly string _migrationAssemblyName;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public WebModule(string connectionString, string migrationAssemblyName
            , IWebHostEnvironment webHostEnvironment
         )
        {
            _connectionString = connectionString;
            _migrationAssemblyName = migrationAssemblyName;
            _webHostEnvironment = webHostEnvironment;   
        }

        protected override void Load(ContainerBuilder builder)
        {
            //    builder.RegisterType<ProductUpdateModel>().AsSelf();
              builder.RegisterType<ItemModel>().AsSelf();
            builder.RegisterType<AuthenticationService>().As<IAuthenticationService>()
                     .InstancePerLifetimeScope();
            builder.RegisterType<UserAccessor>().As<IUserAccessor>()
                 .InstancePerLifetimeScope();
            builder.RegisterType<FileHelper>().As<IFileHelper>()
                .InstancePerLifetimeScope();

            builder.RegisterType<CartService>().As<ICartService>()
              .InstancePerLifetimeScope();

            base.Load(builder);
        }
    }
}
