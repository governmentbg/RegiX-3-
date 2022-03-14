using System.Collections.Generic;
using TechnoLogica.API.Repositories.Contracts;
using TechnoLogica.API.Services;
using TechnoLogica.RegiX.Admin.API.Controllers.V1.DatabaseOperationsControllers;
using TechnoLogica.RegiX.Admin.API.DataContracts.DTO.ConsumerSystemCertificates;
using TechnoLogica.RegiX.Admin.Infrastructure.Models;
using TechnoLogica.RegiX.Admin.Services.Contracts;

namespace TechnoLogica.RegiX.Admin.Services.Services
{
    public class ConsumerSystemCertificatesService :
        ABaseService<ConsumerSystemCertificatesInDto, ConsumerSystemCertificatesOutDto, ConsumerSystemCertificates, decimal,
            RegiXContext>,
        IConsumerSystemCertificatesService
    {
        public ConsumerSystemCertificatesService(IBaseRepository<ConsumerSystemCertificates, decimal, RegiXContext> aBaseRepository) 
            : base(aBaseRepository, new ConsumerSystemCertificatesQueryValidator())
        {
        }

        protected override void PopulateDtoToEntityFieldsMapping()
        {
            dtoFieldsToEntityFields.Add("consumerCertificate.id", "ConsumerCertificate/ConsumerCertificateId");
            dtoFieldsToEntityFields.Add("consumerCertificate.displayName", "ConsumerCertificate/Name");
            dtoFieldsToEntityFields.Add("consumerSystem.id", "ConsumerSystem/ConsumerSystemId");
            dtoFieldsToEntityFields.Add("consumerSystem.displayName", "ConsumerSystem/Name");
            dtoFieldsToEntityFields.Add("id", "ConsumerSystemCertificateId");
        }

        protected override bool IsChildRecord(decimal aId, List<string> aParentsList)
        {
            return false;
        }
    }
}