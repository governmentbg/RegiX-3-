using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using TechnoLogica.RegiX.AdapterConsole.DataContracts.DTO.OperationsPersistance;
using TechnoLogica.RegiX.AdapterConsole.Infrastructure.Models;

namespace RegiX.AdapterConsole.IoC.Configuration.Profiles
{
    public class OperationsPersistanceProfile : Profile
    {
        public OperationsPersistanceProfile()
        {

            //Configuration for  OperationsToRoles
            CreateMap<OperationsPersistanceInDto, OperationsPersistance>();
            CreateMap<OperationsPersistance, OperationsPersistanceOutDto>()
                .ForMember( a => a.AdapterOperationName, ad => ad.MapFrom( m => m.AdapterOperation.Description));
        }
    }
}
