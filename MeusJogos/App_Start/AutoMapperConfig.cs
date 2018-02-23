using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;

namespace MeusJogos.App_Start
{
    public class AutoMapperConfig
    {
        public static void InicializarAutoMapper()
        {
            var profileType = typeof(Profile);

            var profiles = Assembly.GetExecutingAssembly().GetTypes()
                .Where(t => profileType.IsAssignableFrom(t)
                    && t.GetConstructor(Type.EmptyTypes) != null)
                .Select(Activator.CreateInstance)
                .Cast<Profile>();

            Mapper.Initialize(a => profiles.ToList().ForEach(x => a.AddProfile(x)));
        }
    }
}