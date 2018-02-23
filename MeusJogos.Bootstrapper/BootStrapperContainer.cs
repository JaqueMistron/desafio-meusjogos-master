using Autofac;
using MeusJogos.Business;
using MeusJogos.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeusJogos.Bootstrapper
{
    public class BootStrapperContainer
    {
        public static ContainerBuilder InicializarContainer()
        {
            var builder = new ContainerBuilder();

            var business = typeof(UsuarioBusiness).Assembly;
            builder.RegisterAssemblyTypes(business)
                .Where(x => x.Name.EndsWith("Business") && x.Namespace == "MeusJogos.Business")
                .AsImplementedInterfaces()
                .PropertiesAutowired();

            var dataAccess = typeof(MeusJogosContext).Assembly;
            builder.RegisterAssemblyTypes(dataAccess)
                .Where(x => x.Namespace == "MeusJogos.DataAccess")
                .AsSelf();

            return builder;
        }
    }
}
