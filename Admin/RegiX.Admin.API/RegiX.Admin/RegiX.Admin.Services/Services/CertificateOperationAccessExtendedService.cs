using System;
using System.Collections.Generic;
using TechnoLogica.API.Repositories.Contracts;
using TechnoLogica.API.Services;
using TechnoLogica.RegiX.Admin.API.DataContracts.DTO.ElementConsumers;
using TechnoLogica.RegiX.Admin.Infrastructure.Models;
using TechnoLogica.RegiX.Admin.Repositories;
using TechnoLogica.RegiX.Admin.Services.Contracts;

namespace TechnoLogica.RegiX.Admin.Services.Services
{
    public class CertificateOperationAccessExtendedService : ABaseService<CertificateOperationAccessExtendedInDto,
            CertificateOperationAccessExtendedOutDto, CertificateOperationAccessExtended, decimal, RegiXContext>,
        ICertificateOperationAccessExtendedService
    {
        public CertificateOperationAccessExtendedService(
            ICertificateOperationAccessExtendedRepository aBaseRepository)
            : base(aBaseRepository)
        {
        }

        protected override void PopulateDtoToEntityFieldsMapping()
        {
        }

        protected override bool IsChildRecord(decimal aId, List<string> aParentsList)
        {
            throw new NotImplementedException();
        }
    }
}