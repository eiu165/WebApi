﻿ 
namespace Tailspin.Web.Infastructure.IocContainer.Insataller
{
    using Castle.Facilities.Logging;
    using Castle.MicroKernel.Registration;
    using Castle.MicroKernel.SubSystems.Configuration;
    using Castle.Windsor;

    public class LogInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.AddFacility<LoggingFacility>(f => f.UseLog4Net()); 
            log4net.Config.XmlConfigurator.Configure();
        }
    }


}