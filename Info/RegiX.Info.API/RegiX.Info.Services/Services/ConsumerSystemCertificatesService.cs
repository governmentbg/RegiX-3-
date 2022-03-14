using RegiX.Info.DataContracts.DTO.ConsumerSystemCertificates;
using RegiX.Info.Infrastructure.Models;
using RegiX.Info.Services.Contracts;
using RegiX.Info.Services.QueryValidators;
using System;
using System.Collections.Generic;
using TechnoLogica.API.Repositories.Contracts;
using TechnoLogica.API.Services;

namespace RegiX.Info.Services.Services
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

        public override ConsumerSystemCertificatesOutDto Insert(ConsumerSystemCertificatesInDto aInDto)
        {
            ConsumerSystemCertificates mappedObj = MappingTools.MapTo<ConsumerSystemCertificatesInDto, ConsumerSystemCertificates>(aInDto);
           
            mappedObj.RequestDate = DateTime.Now;
            ConsumerSystemCertificates resultObj = this._baseRepository.Insert(mappedObj);
            this._baseRepository.GetDbContext().SaveChanges();
            return MappingTools.MapTo<ConsumerSystemCertificates, ConsumerSystemCertificatesOutDto>(resultObj);
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
