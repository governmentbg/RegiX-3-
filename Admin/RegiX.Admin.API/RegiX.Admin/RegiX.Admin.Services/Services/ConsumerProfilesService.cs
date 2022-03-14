using Microsoft.AspNet.OData.Query.Validators;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;
using TechnoLogica.API.Services;
using TechnoLogica.Common;
using TechnoLogica.Mail;
using TechnoLogica.RegiX.Admin.API.DataContracts.DTO.ConsumerProfiles;
using TechnoLogica.RegiX.Admin.Infrastructure.Models;
using TechnoLogica.RegiX.Admin.Repositories.Contracts;
using TechnoLogica.RegiX.Admin.Services.Contracts;

namespace TechnoLogica.RegiX.Admin.Services.Services
{

    public class ConsumerProfilesService :
        ABaseService<ConsumerProfilesInDto, ConsumerProfilesOutDto, ConsumerProfiles, decimal,
            RegiXContext>,
        IConsumerProfilesService
    {
        private readonly IConsumerProfileStatusRepository consumerProfileStatusRepository;
        private readonly IConsumerProfileUsersRepository consumerProfileUsersRepository;
        private readonly IMailService emailService;
        private readonly SMTPSettings smtpSettings;

        private readonly string[] profileStatus = { "Нов", "Отхвърлен", "Одобрен" };

        public ConsumerProfilesService(IConsumerProfilesRepository aBaseRepository,
            IConsumerProfileStatusRepository consumerProfileStatusRepository,
            IConsumerProfileUsersRepository consumerProfileUsersRepository,
            IMailService emailService,
            IConfiguration configuration,
            FilterQueryValidator aQueryValidator = null) 
            : base(aBaseRepository, aQueryValidator)
        {
            this.consumerProfileStatusRepository = consumerProfileStatusRepository;
            this.consumerProfileUsersRepository = consumerProfileUsersRepository;
            this.emailService = emailService;
            smtpSettings = configuration.GetSettings<SMTPSettings>();
        }

        public override ConsumerProfilesOutDto Update(decimal aId, ConsumerProfilesInDto aInDto)
        {
            try
            {
                var currentStatus =
                    consumerProfileStatusRepository
                        .SelectAll()
                        .Where(x => x.ConsumerProfileId == aInDto.Id)
                        .OrderByDescending(x => x.Date)
                        .FirstOrDefault();
                if (currentStatus == null)
                {
                    throw new Exception("Object with id [" + aId + "] not found!");
                }

                if (aInDto.Status != currentStatus.NewStatus)
                {
                    var newStatus = new ConsumerProfileStatus
                    {
                        ConsumerProfileId = currentStatus.ConsumerProfileId,
                        Comment = (aInDto.Comment ?? (aInDto.Comment = String.Empty)),
                        OldStatus = currentStatus.NewStatus,
                        NewStatus = aInDto.Status,
                        Date = DateTime.Now
                    };
                    this.consumerProfileStatusRepository.Insert(newStatus);
                    var consumerProfileEmails = FindConsumerProfileUsersEmails(aId);
                    if (consumerProfileEmails.Length > 0)
                    {
                        SendConsumerProfileStatusChangeMessage(consumerProfileEmails, aInDto.Name, profileStatus[aInDto.Status]);
                    }
                     
                }
                var repoObj = this._baseRepository.Select(aId);
                if (repoObj == null)
                {
                    throw new Exception("Object with id [" + aId + "] not found!");
                }

                this.ValidateUpdate(repoObj, aInDto);

                repoObj = MappingTools.MapTo(aInDto, repoObj);
                repoObj = this._baseRepository.Update(repoObj);
                this._baseRepository.GetDbContext().SaveChanges();
                return MappingTools.MapTo<ConsumerProfiles, ConsumerProfilesOutDto>(repoObj);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        private void SendConsumerProfileStatusChangeMessage(string[] consumerProfileEmails, string profileName, string profileStatus)
        {
            var message = new MailMessage();
            message.From = new MailAddress(smtpSettings.From);
            foreach (var email in consumerProfileEmails)
            {
                message.To.Add(email);
            }
            message.Subject = string.Format(Resources.ConsumerProfileStatusChangeSubject);
            MailUtil.PrepareBody(message, Resources.ConsumerProfileStatusChangeBody, profileName, profileStatus);
            emailService.SendMail(message);
        }

        protected override void PopulateDtoToEntityFieldsMapping()
        {
            dtoFieldsToEntityFields.Add("administration.id", "Administration/AdministrationId");
            dtoFieldsToEntityFields.Add("administration.displayName", "Administration/Name");
            dtoFieldsToEntityFields.Add("id", "ConsumerProfileId");//should be last 
        }

        protected override bool IsChildRecord(decimal aId, List<string> aParentsList)
        {
            return false;
        }

        private string[] FindConsumerProfileUsersEmails(decimal aId)
        {
            var consumerProfileUsersEmails =
                this.consumerProfileUsersRepository
                    .SelectAll()
                    .Where(x => x.ConsumerProfileId == aId)
                    .Select(e => e.Email)
                    .ToArray();
            return consumerProfileUsersEmails;
        }
    }
}