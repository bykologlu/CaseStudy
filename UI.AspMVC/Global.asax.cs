using Autofac;
using Autofac.Integration.Mvc;
using Core.Utilities.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using UI.AspMVC.ApiService.Abstract;
using UI.AspMVC.ApiService.Concrete;

namespace UI.AspMVC
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {

            IoCInit();

            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            new PassengerApiV1().CreateDummyData();
        }

        public void IoCInit()
        {
            var builder = new ContainerBuilder();

            builder.RegisterControllers(Assembly.GetExecutingAssembly());

            builder.RegisterType<PassengerApiV1>().As<IPassengerApi>();

            IContainer container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}
