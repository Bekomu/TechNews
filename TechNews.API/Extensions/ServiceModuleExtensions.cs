using Autofac;
using System.Reflection;
using TechNews.Business.Abstract;
using TechNews.Business.AutoMapper.Profiles;
using TechNews.Business.Concrete;
using TechNews.DataAccess.EntityFrameWork.Context;
using Module = Autofac.Module;

namespace TechNews.API.Extensions
{
    public class ServiceModuleExtensions : Module
    {
        protected override void Load(Autofac.ContainerBuilder builder)
        {
            var apiAssembly = Assembly.GetEntryAssembly();
            var repoAssembly = Assembly.GetAssembly(typeof(TechNewsDbContext));
            var serviceAssembly = Assembly.GetAssembly(typeof(AdminProfile));

            builder.RegisterAssemblyTypes(apiAssembly, repoAssembly, serviceAssembly).Where(x => x.Name.EndsWith("Repository")).AsImplementedInterfaces().InstancePerLifetimeScope();

            builder.RegisterAssemblyTypes(apiAssembly, repoAssembly, serviceAssembly).Where(x => x.Name.EndsWith("Service")).AsImplementedInterfaces().InstancePerLifetimeScope();

            builder.RegisterType<AdminService>().As<IAdminService>();


            base.Load(builder);
        }
    }
}
