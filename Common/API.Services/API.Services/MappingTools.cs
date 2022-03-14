using System.Collections.Generic;

namespace TechnoLogica.API.Services
{
    public static class MappingTools
    {
        public static TDestination MapTo<TSource, TDestination>(TSource aSource)
        {
            return BaseMappingConfigurationsHelper.Mapper.Map<TSource, TDestination>(aSource);
        }

        public static TDestination MapTo<TSource, TDestination>(TSource aSource, TDestination aDestination)
        {
            return BaseMappingConfigurationsHelper.Mapper.Map(aSource, aDestination);
        }

        public static List<TDestination> MapToList<TSource, TDestination>(List<TSource> aSourceList)
        {
            List<TDestination> result = new List<TDestination>();
            for (int i = 0; i < aSourceList.Count; i++)
            {
                result.Add(MapTo<TSource, TDestination>(aSourceList[i]));
            }

            return result;
        }
    }
}
