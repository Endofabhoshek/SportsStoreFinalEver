using Domain.Abstract;
using Domain.Concrete;
using SimpleInjector;
using SimpleInjector.Integration.Web;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

namespace SportsStore.WebUI.Infrastructure
{
    public static class CustomSimpleInjectorDependencyResolver 
    {
        
        public static Container CreateContainer()
        {
            var container = new Container();
            EmailSettings emailSettings = new EmailSettings { WriteAsFile = bool.Parse(ConfigurationManager.AppSettings["Email.WriteAsFile"] ?? "false") };
            container.Options.DefaultScopedLifestyle = new WebRequestLifestyle();
            //Add Bindings
            container.Register<IProductRepository, EFProductRepository>();
            //container.Register<IOrderProcessor, EmailOrderProcessor>();

            container.Register<IOrderProcessor>(() => new EmailOrderProcessor(emailSettings));

            return container;
        }
    }
}