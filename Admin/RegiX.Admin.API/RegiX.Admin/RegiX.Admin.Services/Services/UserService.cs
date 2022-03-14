using System;
using System.Collections.Generic;
using TechnoLogica.API.Services;
using TechnoLogica.RegiX.Admin.API.DataContracts.DTO.User;
using TechnoLogica.RegiX.Admin.Infrastructure.Models;
using TechnoLogica.RegiX.Admin.Repositories.Contracts;
using TechnoLogica.RegiX.Admin.Services.Contracts;
using TechnoLogica.RegiX.Admin.Services.QueryValidators;

namespace TechnoLogica.RegiX.Admin.Services
{
    /// <summary>
    ///     Defines the <see cref="UserService" />
    /// </summary>
    public class UserService : ABaseService<UserInDto, UserOutDto, Users, decimal, RegiXContext>, IUserService
    {
        public UserService(IUsersRepository aBaseRepository)
            : base(aBaseRepository, new UsersQueryValidator())
        {
        }


        public override UserOutDto Update(decimal aId, UserInDto aInDto)
        {
            var userEditInDto = new UserEditInDto
            {
                Name = aInDto.Name,
                UserName = aInDto.UserName,
                Email = aInDto.Email,
                AdministrationId = aInDto.AdministrationId,
                IsActive = aInDto.IsActive,
                IsAdmin = aInDto.IsAdmin
            };
            var repoObj = _baseRepository.Select(aId);
            if (repoObj == null) throw new Exception("Object with id [" + aId + "] not found!");

            ValidateUpdate(repoObj, aInDto);

            repoObj = MappingTools.MapTo(userEditInDto, repoObj);
            repoObj = _baseRepository.Update(repoObj);
            _baseRepository.GetDbContext().SaveChanges();

            return MappingTools.MapTo<Users, UserOutDto>(repoObj);
        }

        //TODO: Validate administration -> insert delete ...

        /// <summary>
        ///     The PopulateDtoToEntityFieldsMapping
        /// </summary>
        protected override void PopulateDtoToEntityFieldsMapping()
        {
            dtoFieldsToEntityFields.Add("administration.id", "Administration/AdministrationId");
            dtoFieldsToEntityFields.Add("administration.displayName", "Administration/Name");
            dtoFieldsToEntityFields.Add("id", "UserId");
        }

        protected override bool IsChildRecord(decimal aId, List<string> aParentsList)
        {
            return false;
        }
    }
}