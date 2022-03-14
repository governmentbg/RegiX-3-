using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using TechnoLogica.API.Services;
using TechnoLogica.RegiX.Admin.API.DataContracts.DTO.MyProfile;
using TechnoLogica.RegiX.Admin.Infrastructure.Models;
using TechnoLogica.RegiX.Admin.Repositories.Contracts;
using TechnoLogica.RegiX.Admin.Services.Contracts;

namespace TechnoLogica.RegiX.Admin.Services.Services
{
    public class MyProfileService : ABaseService<MyProfileInDto, MyProfileOutDto, Users, decimal, RegiXContext>,
            IMyProfileService
    {
        private readonly IUsersRepository aUsersRepository;
        private readonly IUsersEauthRepository aUsersEauthRepository;

        public MyProfileService(
            IMyProfileRepository aBaseRepository,
            IUsersRepository aUsersRepository,
            IUsersEauthRepository aUsersEauthRepository)
            : base(aBaseRepository)
        {
            this.aUsersRepository = aUsersRepository;
            this.aUsersEauthRepository = aUsersEauthRepository;
        }


        public override MyProfileOutDto Update(decimal aId, MyProfileInDto aInDto)
        {
            if (aInDto.UsersEauth?.Id == null)
            {
                InsertUsersEauth(aId, aInDto);
            }
            else
            {
                if (!string.IsNullOrEmpty(aInDto.UsersEauth.IdentifierType) && !string.IsNullOrWhiteSpace(aInDto.UsersEauth.Identifier))
                {
                    UpdateUsersEauth(aId, aInDto);
                }
                else if (string.IsNullOrWhiteSpace(aInDto.UsersEauth.Identifier) && aInDto.UsersEauth.IdentifierType == null)
                {
                    this.aUsersEauthRepository.Delete(aId);
                }
            }
            try
            {
                return base.Update(aId, aInDto);
            }
            catch (DbUpdateException)
            {
                throw new ApplicationException("Потребител с този 'Идентификатор' вече съществува.");
            }
        }

        protected override void PopulateDtoToEntityFieldsMapping()
        {
        }


        private void UpdateUsersEauth(decimal aId, MyProfileInDto aInDto)
        {
            var currEntity = this.aUsersEauthRepository.Select(aId);
            currEntity.Identifier = aInDto.UsersEauth.Identifier;
            currEntity.IdentifierType = aInDto.UsersEauth.IdentifierType;
            this.aUsersEauthRepository.Update(currEntity);
        }

        private void InsertUsersEauth(decimal aId, MyProfileInDto aInDto)
        {
            var currEntity = new UsersEAuth();
            currEntity.UserId = aInDto.Id;
            currEntity.Identifier = aInDto.UsersEauth.Identifier;
            currEntity.IdentifierType = aInDto.UsersEauth.IdentifierType;
            this.aUsersEauthRepository.Insert(currEntity);
        }

        protected override bool IsChildRecord(decimal aId, List<string> aParentsList)
        {
            return false;
        }
    }
}
