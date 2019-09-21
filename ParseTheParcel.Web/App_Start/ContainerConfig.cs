using Autofac;
using Autofac.Integration.Mvc;
using ParseTheParcel.Business.Logic;
using System.Web.Mvc;
using ParseTheParcel.Data.Services;

namespace ParseTheParcel.Web
{
    public class ContainerConfig
    {
        internal static void RegisterContainer()
        {
            var builder = new ContainerBuilder();
            builder.RegisterControllers(typeof(MvcApplication).Assembly);
            builder.RegisterType<ParcelCalculator>()
                .As<IParcelCalculator>()
                .SingleInstance();

            builder.RegisterType<ParcelTypeDictionary>()
                .As<IParcelTypeDictionary>()
                .SingleInstance();

            builder.RegisterType<ParcelConfiguration>()
               .As<IParcelConfiguration>()
               .SingleInstance();

            builder.RegisterType<ParcelValidation>()
                .As<IParcelValidation>()
                .SingleInstance();

            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}