using AutoMapper;
using TechnoLogica.API.DataContracts;
using TechnoLogica.RegiX.Admin.API.DataContracts.DTO.User;
using TechnoLogica.RegiX.Admin.Infrastructure.Models;

namespace RegiX.Admin.IoC.Configuration.Profiles
{
    public class UsersProfile : Profile
    {
        public UsersProfile()
        {
            // Configuration for Users
            CreateMap<UserInDto, Users>()
                .ForMember(uid => uid.Active, u => u.MapFrom(m => m.IsActive))
                .ForMember(uid => uid.CreateDate, u => u.MapFrom(m => m.CreatedOn));

            CreateMap<UserEditInDto, Users>()
                .ForMember(uid => uid.Active, u => u.MapFrom(m => m.IsActive));

            CreateMap<Users, UserOutDto>()
                .ForMember(u => u.Id, ud => ud.MapFrom(m => m.UserId))
                .ForMember(u => u.Administration, ud => ud.MapFrom(m => new DisplayValue()
                {
                    Id = m.Administration.AdministrationId,
                    DisplayName = m.Administration.Name
                }));
        }
        
    }
}