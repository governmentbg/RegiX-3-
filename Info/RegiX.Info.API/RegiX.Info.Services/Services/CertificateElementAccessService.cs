using RegiX.Info.DataContracts.DTO.CertificateElementAccess;
using RegiX.Info.Infrastructure.Models;
using RegiX.Info.Repositories.Contracts;
using RegiX.Info.Services.Contracts;
using RegiX.Info.Services.QueryValidators;
using System.Collections.Generic;
using System.Linq;
using TechnoLogica.API.Services;

namespace RegiX.Info.Services.Services
{
    public class CertificateElementAccessService : ABaseService<CertificateElementAccessInDto, CertificateElementAccessOutDto, CertificateElementAccess, decimal,
            RegiXContext>,
        ICertificateElementAccessService
    {
        private readonly IConsumerSystemCertificatesRepository consumerSystemCertificatesRepository;
        private readonly IRegisterObjectElementsRepository registerObjectElementsRepository;
        private readonly IAdapterOperationsRepository adapterOperationsRepository;

        public CertificateElementAccessService
            (
                ICertificateElementAccessRepository aBaseRepository,
                IConsumerSystemCertificatesRepository consumerSystemCertificatesRepository,
                IRegisterObjectElementsRepository registerObjectElementsRepository,
                IAdapterOperationsRepository adapterOperationsRepository
            )
            : base(aBaseRepository, new CertificateElementAccessQueryValidator())
        {
            this.consumerSystemCertificatesRepository = consumerSystemCertificatesRepository;
            this.registerObjectElementsRepository = registerObjectElementsRepository; 
            this.adapterOperationsRepository = adapterOperationsRepository;
        }

        protected override void PopulateDtoToEntityFieldsMapping()
        {
            dtoFieldsToEntityFields.Add("consumerCertificate.id", "ConsumerCertificate/ConsumerCertificateId");
            dtoFieldsToEntityFields.Add("consumerCertificate.displayName", "ConsumerCertificate/Name");
            dtoFieldsToEntityFields.Add("registerObjectElement.id", "RegisterObjectElement/RegisterObjectElementId");
            dtoFieldsToEntityFields.Add("registerObjectElement.displayName", "RegisterObjectElement/Name");
        }

        protected override bool IsChildRecord(decimal aId, List<string> aParentsList)
        {
            return false;
        }

        public List<CertificateElementAccessOutDto> GetElementsByAdapterOperation(decimal consumerSystemCertificateId, decimal adapterOperationId)
        {
            var registerObjectId = this.adapterOperationsRepository.Select(adapterOperationId).RegisterObjectId;

            var registerObjectElementsIds =
                this.registerObjectElementsRepository
                    .SelectAllByRegisterObjectId((decimal)registerObjectId)
                    .Select(x => x.RegisterObjectElementId);

            var consumerCertificatesId = 
                this.consumerSystemCertificatesRepository
                    .Select(consumerSystemCertificateId)
                    .ConsumerCertificateId;

            var certificateElementAccess =
                this._baseRepository
                    .SelectAll()
                    .Where
                    (
                        x => x.ConsumerCertificateId == consumerCertificatesId &&
                             registerObjectElementsIds.Contains(x.RegisterObjectElementId)
                    )
                    .ToList();

            return MappingTools.MapToList<CertificateElementAccess, CertificateElementAccessOutDto>(
                certificateElementAccess);
        }
    }
}