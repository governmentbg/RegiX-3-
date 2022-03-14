using AutoMapper;
using System;
using System.Linq;
using System.Reflection;
using TechnoLogica.API.Services;

namespace TechnoLogica.RegiX.AdapterConsole.AutoMapper
{
    public class MappingConfigurationsHelper : BaseMappingConfigurationsHelper
    {
        private static bool IsTypeAssignableFrom(Type t, Type baseType)
        {
            var result = baseType.IsAssignableFrom(t) && !t.IsAbstract && t.IsPublic;
            return result;
        }

        protected override MapperConfiguration GetMapperConfiguration()
        {
            return new MapperConfiguration(cfg =>
            {
                Assembly.Load("RegiX.AdapterConsole.IoC.Configuration")
                    .GetTypes()
                    .Where(t => IsTypeAssignableFrom(t, typeof(Profile)))
                    .ToList()
                    .ForEach(p =>
                    {
                        cfg.AddProfile((Profile)Activator.CreateInstance(p));
                    });
            });
        }
    }
}
