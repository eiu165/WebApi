using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tailspin.Web.Infastructure.Insataller
{
    using Castle.MicroKernel.Registration;
    using Castle.MicroKernel.SubSystems.Configuration;
    using Castle.Windsor;
    using System.Configuration;
    using System.Web.Mvc;
    using Tailspin.Business;
    using Tailspin.Data;

    public class WebInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Classes.FromThisAssembly()
                                .BasedOn<IController>()
                                .LifestyleTransient());

            container.Register(Component.For<IToyService>().ImplementedBy<ToyService>());
            //container.Register(Component.For<IToyRepository>().ImplementedBy<ToyRepository>());

            //            .WithService.DefaultInterface()
            //            .Configure(c => c.LifeStyle.Transient
            //            .DependsOn(new { databaseName = "MyDatabaseName" }))); 
            //);

            container.Register( Component.For<IToyRepository>().ImplementedBy<ToyRepository>()
                .DependsOn(Dependency.OnValue("connectionString", ConfigurationManager.ConnectionStrings["ApplicationConnectionString"].ConnectionString)) //ConfigurationManager.ConnectionStrings["ApplicationConnectionString"].ConnectionString))
                .LifeStyle.PerWebRequest);
        }
    }
}