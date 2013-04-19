using Castle.Core.Logging;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Castle.Windsor.Installer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;
using Tailspin.Data;
using Tailspin.Web.Infastructure.IocContainer;
using Tailspin.Web.Infastructure.IocContainer.Insataller;

namespace Tailspin.Web
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801
    public class MvcApplication : System.Web.HttpApplication
    {

        private static IWindsorContainer container;

        private static void BootstrapContainer()
        {
            container = new WindsorContainer();             //   .Install(FromAssembly.This());
            var controllerFactory = new WindsorControllerFactory(container.Kernel);
            ControllerBuilder.Current.SetControllerFactory(controllerFactory);

            container.Install(
                //new CommonInstaller(),
                //new DataInstaller(),
                //new ServiceInstaller(),
                new LogInstaller(),
                new WebInstaller()
                );
        }

        void Application_Error(Object sender, EventArgs e)
        {
            Exception ex = Server.GetLastError().GetBaseException(); 
            var logger =  container.Resolve<ILogger>();
            logger.Error("App_Error", ex);
            container.Release(logger);
        } 

        protected void Application_End()
        { 
            var logger = container.Resolve<ILogger>();
            logger.Info("Application_End " );
            container.Release(logger);
        }

        protected void Application_Start()
        {
            BootstrapContainer();

            var logger = container.Resolve<ILogger>();
            logger.Info("Application Start");
            logger.Warn("This is a warning message.");
            logger.Debug("This is a debug message");
            container.Release(logger);

            AreaRegistration.RegisterAllAreas();
            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }
    }
}