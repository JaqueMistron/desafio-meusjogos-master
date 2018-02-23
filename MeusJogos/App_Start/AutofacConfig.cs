using MeusJogos.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using System.Web.Mvc;
using MeusJogos.Bootstrapper;
using Autofac;
using Autofac.Integration.Mvc;

namespace MeusJogos.App_Start
{
    public class AutofacConfig
    {
        public static void InicializarContainer()
        {
            var builder = BootStrapperContainer.InicializarContainer();

            var controllers = typeof(HomeController).Assembly;
            builder.RegisterAssemblyTypes(controllers)
                    .Where(t => t.Namespace == "MeusJogos.Controllers")
                    .AsSelf()
                    .PropertiesAutowired();

            builder.RegisterInstance(Mapper.Configuration.CreateMapper());

            var container = builder.Build();

            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
            HttpContext.Current.Application["DependencyResolver"] = DependencyResolver.Current;
        }
    }
}