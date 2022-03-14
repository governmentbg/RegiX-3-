using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using Microsoft.AspNet.OData.Query.Validators;
using Microsoft.Extensions.Configuration;
using TechnoLogica.API.Services;
using TechnoLogica.Common;
using TechnoLogica.Mail;
using TechnoLogica.RegiX.Admin.API.DataContracts.DTO.ConsumerSystems;
using TechnoLogica.RegiX.Admin.Infrastructure.Models;
using TechnoLogica.RegiX.Admin.Repositories.Contracts;
using TechnoLogica.RegiX.Admin.Services.Contracts;

namespace TechnoLogica.RegiX.Admin.Services.Services
{
    public class ConsumerSystemsService :
        ABaseService<ConsumerSystemsInDto, ConsumerSystemsOutDto, ConsumerSystems, decimal,
            RegiXContext>,
        IConsumerSystemsService
    {
        private readonly IConsumerProfilesRepository consumerProfilesRepository;
        private readonly IConsumerProfileUsersRepository consumerProfileUsersRepository;
        private readonly IMailService emailService;
        private readonly SMTPSettings smtpSettings;

        public ConsumerSystemsService(IConsumerSystemsRepository aBaseRepository,
            IMailService emailService,
            IConsumerProfilesRepository consumerProfilesRepository,
            IConsumerProfileUsersRepository consumerProfileUsersRepository,
            IConfiguration configuration,
            FilterQueryValidator aQueryValidator = null)
            : base(aBaseRepository, aQueryValidator)
        {
            this.emailService = emailService;
            this.consumerProfilesRepository = consumerProfilesRepository;
            this.consumerProfileUsersRepository = consumerProfileUsersRepository;
            smtpSettings = configuration.GetSettings<SMTPSettings>();
        }

        public override ConsumerSystemsOutDto Update(decimal aId, ConsumerSystemsInDto aInDto)
        {
            var repoObj = _baseRepository.Select(aId);
            if (repoObj == null) throw new Exception("Object with id [" + aId + "] not found!");

            //sent mail notification only when api_service_consumer is changed 
            if (repoObj.ApiServiceConsumerId != aInDto.ApiServiceConsumer.Id)
            {
                var consumerProfileUsersEmails = FindConsumerProfileUsersEmails(aInDto);
                SendConsumerSystemsNotificationMessage(consumerProfileUsersEmails, aInDto.Name, aInDto.ConsumerProfile.DisplayName);
            }

            ValidateUpdate(repoObj, aInDto);

            repoObj = MappingTools.MapTo(aInDto, repoObj);
            repoObj = _baseRepository.Update(repoObj);
            _baseRepository.GetDbContext().SaveChanges();
            return MappingTools.MapTo<ConsumerSystems, ConsumerSystemsOutDto>(repoObj);
        }

        private void SendConsumerSystemsNotificationMessage(string[] profileUserMail, string systemName, string consumerProfileName)
        {
            var message = new MailMessage();
            message.From = new MailAddress(smtpSettings.From);
            foreach (var email in profileUserMail)
            {
                message.To.Add(email);
            }
            message.Subject = string.Format(Resources.ConsumerSystemsNotificationSubject);
            MailUtil.PrepareBody(message, Resources.ConsumerSystemsNotificationBody, systemName, consumerProfileName);
            emailService.SendMail(message);
        }

        protected override void PopulateDtoToEntityFieldsMapping()
        {
            dtoFieldsToEntityFields.Add("apiServiceConsumer.id", "ApiServiceConsumer/ApiServiceConsumerId");
            dtoFieldsToEntityFields.Add("apiServiceConsumer.displayName", "AdministrationType/Name");
            dtoFieldsToEntityFields.Add("consumerProfile.id", "ConsumerProfile/ConsumerProfileId");
            dtoFieldsToEntityFields.Add("consumerProfile.displayName", "ConsumerProfile/Name");
            dtoFieldsToEntityFields.Add("id", "ConsumerSystemId"); //Must be last.The order matters
        }

        protected override bool IsChildRecord(decimal aId, List<string> aParentsList)
        {
            return false;
        }

        private string[] FindConsumerProfileUsersEmails(ConsumerSystemsInDto aInDto)
        {
            var consumerProfile =
                consumerProfilesRepository
                    .Select(aInDto.ConsumerProfile.Id);

            var consumerProfileUsersEmails =
                this.consumerProfileUsersRepository
                    .SelectAll()
                    .Where(x => x.ConsumerProfileId == consumerProfile.ConsumerProfileId)
                    .Select(e => e.Email)
                    .ToArray();
            return consumerProfileUsersEmails;
        }
    }
}