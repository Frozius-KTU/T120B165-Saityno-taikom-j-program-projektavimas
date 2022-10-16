using Autofac;
using CarPartsShop.Core.Interfaces;
using CarPartsShop.Core.Services;

namespace CarPartsShop.Core;

public class CoreDIModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterType<CarBrandService>()
               .As<ICarBrandService>()
               .InstancePerLifetimeScope();
        builder.RegisterType<CarModelService>()
               .As<ICarModelService>()
               .InstancePerLifetimeScope();
        builder.RegisterType<CarPartService>()
               .As<ICarPartService>()
               .InstancePerLifetimeScope();
    }
}
