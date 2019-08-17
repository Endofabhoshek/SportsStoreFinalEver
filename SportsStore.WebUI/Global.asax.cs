using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Domain.Entities;
using SimpleInjector;
using SimpleInjector.Integration.Web;
using SimpleInjector.Integration.Web.Mvc;
using SportsStore.WebUI.Infrastructure;
using SportsStore.WebUI.Infrastructure.Binders;

namespace SportsStore.WebUI
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {

            System.Web.Mvc.DependencyResolver.SetResolver(new SimpleInjectorDependencyResolver(CustomSimpleInjectorDependencyResolver.CreateContainer()));

            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            ModelBinders.Binders.Add(typeof(Cart), new CartModelBinder());
        }
    }
}
