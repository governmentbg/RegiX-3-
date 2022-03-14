using RegiX.Info.DataContracts.DTO.CertificateOperationAccess;
using RegiX.Info.Infrastructure.Models;
using RegiX.Info.Repositories.Contracts;
using RegiX.Info.Services.Contracts;
using RegiX.Info.Services.QueryValidators;
using System.Collections.Generic;
using TechnoLogica.API.Services;

namespace RegiX.Info.Services.Services
{
    public class CertificateOperationAccessService : ABaseService<CertificateOperationAccessInDto, CertificateOperationAccessOutDto, CertificateOperationAccess, decimal, RegiXContext>,
    ICertificateOperationAccessService
    {
        public CertificateOperationAccessService(ICertificateOperationAccessRepository
            aBaseRepository) : base(aBaseRepository, new CertificateOperationAccessQueryValidator())
        {
        }

        protected override void PopulateDtoToEntityFieldsMapping()
        {
            dtoFieldsToEntityFields.Add("consumerCertificate.id", "ConsumerCertificate/ConsumerCertificateId");
            dtoFieldsToEntityFields.Add("consumerCertificate.displayName", "ConsumerCertificate/Name");
            dtoFieldsToEntityFields.Add("adapterOperation.id", "AdapterOperation/AdapterOperationId");
            dtoFieldsToEntityFields.Add("adapterOperation.displayName", "AdapterOperation/Name");
        }

        protected override bool IsChildRecord(decimal aId, List<string> aParentsList)
        {
            return false;
        }
    }
}