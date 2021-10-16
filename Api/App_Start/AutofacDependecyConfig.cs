using Autofac;
using Autofac.Integration.WebApi;
using Business.DependencyResolvers.Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;

namespace Api.App_Start
{
    public class AutofacDependecyConfig
    {
        public static void DependencyBuilder()
        {
            var builder = new ContainerBuilder();

            builder.RegisterModule(new BusinessModule());
            builder.RegisterModule(new AutoMapperModule());
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            builder.RegisterWebApiFilterProvider(GlobalConfiguration.Configuration);

            var container = builder.Build();

            var resolver = new AutofacWebApiDependencyResolver(container);

            GlobalConfiguration.Configuration.DependencyResolver = resolver;

        }
    }
}