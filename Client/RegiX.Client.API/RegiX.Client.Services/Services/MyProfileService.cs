using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using TechnoLogica.API.Services;
using TechnoLogica.RegiX.Client.API.DataContracts.DTO.MyProfileDtos;
using TechnoLogica.RegiX.Client.Infrastructure.Models;
using TechnoLogica.RegiX.Client.Repositories.Contracts;
using TechnoLogica.RegiX.Client.Services.Contracts;

namespace TechnoLogica.RegiX.Client.Services.Services
{
    public class MyProfileService : ABaseService<MyProfileInDto, MyProfileOutDto, Users, int, RegiXClientContext>,
        IMyProfileService
    {
        private readonly IFederationUsersRepository aFederationUsersRepository;
        private readonly IUsersEauthRepository aUsersEauthRepository;

        public MyProfileService(IMyProfileRepository aBaseRepository,
            IFederationUsersRepository aFederationUsersRepository, IUsersEauthRepository aUsersEauthRepository) 
            : base(aBaseRepository)
        {
            this.aFederationUsersRepository = aFederationUsersRepository;
            this.aUsersEauthRepository = aUsersEauthRepository;
        }


        public override MyProfileOutDto Update(int aId, MyProfileInDto aInDto)
        {
            UpdateFederationUser(aId, aInDto);
            
            if (aInDto.UsersEauth.Id == null)
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

        protected override bool IsChildRecord(int aId, List<string> aParentsList)
        {
            return false;
        }
        private void UpdateFederationUser(int aId, MyProfileInDto aInDto)
        {
            var currFederationUser = this.aFederationUsersRepository.Select(aId);
            currFederationUser.Position = aInDto.Position;
            this.aFederationUsersRepository.Update(currFederationUser);
        }

        private void UpdateUsersEauth(int aId, MyProfileInDto aInDto)
        {
            var currEntity = this.aUsersEauthRepository.Select(aId);
            currEntity.Identifier = aInDto.UsersEauth.Identifier;
            currEntity.IdentifierType = aInDto.UsersEauth.IdentifierType;
            this.aUsersEauthRepository.Update(currEntity);
        }

        private void InsertUsersEauth(int aId, MyProfileInDto aInDto)
        {
            var currEntity = new UsersEauth();
            currEntity.Id = aInDto.Id;
            currEntity.Identifier = aInDto.UsersEauth.Identifier;
            currEntity.IdentifierType = aInDto.UsersEauth.IdentifierType;
            this.aUsersEauthRepository.Insert(currEntity);
        }

    }
}