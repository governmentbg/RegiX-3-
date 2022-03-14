using Microsoft.Extensions.Configuration;
using RegiX.Info.DataContracts.DTO.ConsumerProfileUsersApproved;
using RegiX.Info.Infrastructure.Models;
using RegiX.Info.Repositories.Contracts;
using RegiX.Info.Services.Contracts;
using System.Collections.Generic;
using System.Net.Mail;
using TechnoLogica.API.Services;
using TechnoLogica.Common;
using TechnoLogica.Mail;

namespace RegiX.Info.Services.Services
{
    public class ConsumerProfileUsersApprovedService : ABaseService<ConsumerProfileUsersApprovedInDto, ConsumerProfileUsersApprovedOutDto, ConsumerProfileUsers, decimal, RegiXContext>,
        IConsumerProfileUsersApprovedService
    {
        private IMailService _mailService;
        private readonly SMTPSettings smtpSettings;

        public ConsumerProfileUsersApprovedService(IConsumerProfileUsersApprovedRepository aBaseRepository, IMailService mailService, IConfiguration configuration) 
            : base(aBaseRepository)
        {
            _mailService = mailService;
            smtpSettings = configuration.GetSettings<SMTPSettings>();
        }

        public override ConsumerProfileUsersApprovedOutDto Update(decimal aId, ConsumerProfileUsersApprovedInDto aInDto)
        {
            var result = base.Update(aId, aInDto);
            if (result.IsActive)
            {
                var message = new MailMessage(smtpSettings.From, result.Email);
                message.Subject = string.Format(Resources.ConsumerProfileUserStatusChangeSubject);
                MailUtil.PrepareBody(message, Resources.ConsumerProfileUserStatusChangeBody, result.Email);
                _mailService.SendMail(message);
            }
            return result;
        }

        protected override void PopulateDtoToEntityFieldsMapping()
        {
            dtoFieldsToEntityFields.Add("id", "ConsumerProfileUserId");
        }

        protected override bool IsChildRecord(decimal aId, List<string> aParentsList)
        {
            return false;
        }
    }
}