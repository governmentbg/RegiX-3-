using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Net.Mail;
using TechnoLogica.API.Services;
using TechnoLogica.Common;
using TechnoLogica.Mail;
using TechnoLogica.RegiX.Admin.API.DataContracts.DTO.ConsumerProfileUsers;
using TechnoLogica.RegiX.Admin.Infrastructure.Models;
using TechnoLogica.RegiX.Admin.Repositories.Contracts;
using TechnoLogica.RegiX.Admin.Services.Contracts;
using TechnoLogica.RegiX.Admin.Services.QueryValidators;

namespace TechnoLogica.RegiX.Admin.Services.Services
{
    public class ConsumerProfileUsersService :
        ABaseService<ConsumerProfileUsersInDto, ConsumerProfileUsersOutDto, ConsumerProfileUsers, decimal,
            RegiXContext>,
        IConsumerProfileUsersService
    {
        private readonly IMailService mailService;
        private readonly SMTPSettings smtpSettings;

        public ConsumerProfileUsersService(IConsumerProfileUsersRepository aBaseRepository, IMailService mailService,
            IConfiguration configuration) 
            : base(aBaseRepository, new ConsumersProfileUsersQueryValidator())
        {
            this.mailService = mailService;
            smtpSettings = configuration.GetSettings<SMTPSettings>();
        }

        public override ConsumerProfileUsersOutDto Update(decimal aId, ConsumerProfileUsersInDto aInDto)
        {
            ConsumerProfileUsers repoObj = this._baseRepository.Select(aId);
            if (repoObj == null)
            {
                throw new Exception("Object with id [" + aId + "] not found!");
            }

            this.ValidateUpdate(repoObj, aInDto);

            //send notification for profile activation
            if (!repoObj.IsActive && aInDto.IsActive)
            {
                SendConsumerProfileUserStatusChangeMessage(aInDto.Email);
            }

            repoObj = MappingTools.MapTo(aInDto, repoObj);
            repoObj = this._baseRepository.Update(repoObj);
            this._baseRepository.GetDbContext().SaveChanges();
            return MappingTools.MapTo<ConsumerProfileUsers, ConsumerProfileUsersOutDto>(repoObj);
        }


        private void SendConsumerProfileUserStatusChangeMessage(string profileUserMail)
        {
            var message = new MailMessage(smtpSettings.From, profileUserMail);
            message.Subject = string.Format(Resources.ConsumerProfileUserStatusChangeSubject);
            MailUtil.PrepareBody(message, Resources.ConsumerProfileUserStatusChangeBody, profileUserMail);
            mailService.SendMail(message);
        }

        protected override void PopulateDtoToEntityFieldsMapping()
        {
            
            dtoFieldsToEntityFields.Add("consumerProfile.id", "ConsumerProfile/ConsumerProfileId");
            dtoFieldsToEntityFields.Add("consumerProfile.displayName", "ConsumerProfile/Name");
        }

        protected override bool IsChildRecord(decimal aId, List<string> aParentsList)
        {
            return false;
        }
    }
}