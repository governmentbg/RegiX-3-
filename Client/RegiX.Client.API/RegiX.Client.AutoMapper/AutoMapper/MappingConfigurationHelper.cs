namespace TechnoLogica.RegiX.Client.AutoMapper.AutoMapper
{
    using API.DataContracts.DTO.User;
    using global::AutoMapper;
    using Infrastructure.Models;
    using System;
    using System.Linq;
    using System.Reflection;
    using TechnoLogica.API.Services;

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
                // Configuration for Reports
                Assembly.Load("RegiX.Client.IoC.Configuration")
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
