using Autofac;
using RestaurantApp.Business.Concreate;
using RestaurantApp.Business.Mapping;
using RestaurantApp.Core.DAL.UnitOfWork;
using RestaurantApp.DAL.Concreate.EntityFramework.DbContexts;
using RestaurantApp.DAL.Concreate.EntityFramework.UnitOfWork;
using System.Reflection;
using Module = Autofac.Module;
namespace RestaurantApp.WebApi.Modules
{
    public class ServiceModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>();

            var apiAssembly = Assembly.GetExecutingAssembly();
            var repoAssembly = Assembly.GetAssembly(typeof(AppDbContext));
            var serviceAssembly = Assembly.GetAssembly(typeof(MapProfile));

            builder.RegisterAssemblyTypes(apiAssembly,repoAssembly, serviceAssembly).Where(x => x.Name.EndsWith
            ("Repository")).AsImplementedInterfaces().InstancePerLifetimeScope();
            
            builder.RegisterAssemblyTypes(apiAssembly,repoAssembly, serviceAssembly).Where(x => x.Name.EndsWith
            ("Service")).AsImplementedInterfaces().InstancePerLifetimeScope();
        }
    }
}
