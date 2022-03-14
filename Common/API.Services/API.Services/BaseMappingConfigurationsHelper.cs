using AutoMapper;

namespace TechnoLogica.API.Services
{
    public abstract class BaseMappingConfigurationsHelper
    {
        protected abstract MapperConfiguration GetMapperConfiguration();

        public void ConfigureMapper()
        {
            Mapper = GetMapperConfiguration().CreateMapper();
        }

        public static IMapper Mapper { get; private set; }
    }
}
