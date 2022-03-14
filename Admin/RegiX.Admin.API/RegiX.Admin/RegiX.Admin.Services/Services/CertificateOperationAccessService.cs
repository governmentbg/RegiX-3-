using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNet.OData.Query;
using TechnoLogica.API.DataContracts;
using TechnoLogica.API.Services;
using TechnoLogica.RegiX.Admin.API.DataContracts.DTO.CertificateOperationAccess;
using TechnoLogica.RegiX.Admin.Infrastructure.Models;
using TechnoLogica.RegiX.Admin.Repositories.Contracts;
using TechnoLogica.RegiX.Admin.Services.Contracts;
using TechnoLogica.RegiX.Admin.Services.QueryValidators;

namespace TechnoLogica.RegiX.Admin.Services.Services
{
    /// <summary>
    ///     Defines the <see cref="CertificateOperationAccessService" />
    /// </summary>
    public class CertificateOperationAccessService :
        ABaseService<CertificateOperationAccessInDto, CertificateOperationAccessOutDto, CertificateOperationAccess,
            decimal, RegiXContext>, ICertificateOperationAccessService
    {
        public CertificateOperationAccessService(
            ICertificateOperationAccessRepository aBaseRepository)
            : base(aBaseRepository, new CertificateOperationAccessQueryValidator())
        {
        }

        /// <summary>
        ///     The PopulateDtoToEntityFieldsMapping
        /// </summary>
        protected override void PopulateDtoToEntityFieldsMapping()
        {
            dtoFieldsToEntityFields.Add("adapterOperation.id", "AdapterOperation/AdapterOperationId");
            dtoFieldsToEntityFields.Add("adapterOperation.displayName", "AdapterOperation/Name");
            dtoFieldsToEntityFields.Add("adapterOperation.description", "AdapterOperation/Description");
            dtoFieldsToEntityFields.Add("consumerCertificate.id", "ConsumerCertificate/ConsumerCertificateId");
            dtoFieldsToEntityFields.Add("consumerCertificate.displayName", "ConsumerCertificate/Name");
            dtoFieldsToEntityFields.Add("consumerCertificate.description", "ConsumerCertificate/Description");
            //dtoFieldsToEntityFields.Add("editComment", "AdapterOperation/Description"); TODO:
        }

        protected override bool IsChildRecord(decimal aId, List<string> aParentsList)
        {
            throw new NotImplementedException();
        }
    }
}