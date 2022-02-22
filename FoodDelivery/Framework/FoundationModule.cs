using Autofac;
using Framework.Contexts;
using Framework.Repositories;
using Framework.Services;
using Framework.UnitOfworks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Framework
{
    public class FoundationModule : Module
    {
        private readonly string _connectionString;
        private readonly string _migrationAssemblyName;

        public FoundationModule(string connectionString, string migrationAssemblyName)
        {
            _connectionString = connectionString;
            _migrationAssemblyName = migrationAssemblyName;
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ShopingContext>()
                .WithParameter("connectionString", _connectionString)
                .WithParameter("migrationAssemblyName", _migrationAssemblyName)
                .InstancePerLifetimeScope();

            builder.RegisterType<CartRepository>().As<ICartRepository>()
                .InstancePerLifetimeScope();
            builder.RegisterType<CategoryRepository>().As<ICategoryRepository>()
                .InstancePerLifetimeScope();
            builder.RegisterType<ShoppingUnitOfWork>().As<IShoppingUnitOfWork>()
                .InstancePerLifetimeScope();
            builder.RegisterType<ItemRepository>().As<IItemRepository>()
                .InstancePerLifetimeScope();
            builder.RegisterType<ItemTypeRepository>().As<IItemTypeRepository>()
                .InstancePerLifetimeScope();
            builder.RegisterType<OrderRepository>().As<IOrderRepository>()
              .InstancePerLifetimeScope();
            builder.RegisterType<CatalogueServices>().As<ICatalogueServices>()
             .InstancePerLifetimeScope();

            base.Load(builder);
        }
    }
}
