using System;
using System.Collections.Generic;
using System.Linq;
using TechnoLogica.API.Services;
using TechnoLogica.RegiX.Admin.API.DataContracts.DTO.RegisterObjectElement;
using TechnoLogica.RegiX.Admin.Infrastructure.Models;
using TechnoLogica.RegiX.Admin.Repositories.Contracts;
using TechnoLogica.RegiX.Admin.Services.Contracts;
using TechnoLogica.RegiX.Admin.Services.QueryValidators;

namespace TechnoLogica.RegiX.Admin.Services.Services
{
    /// <summary>
    ///     Defines the <see cref="RegisterObjectElementService" />
    /// </summary>
    public class RegisterObjectElementService :
        ABaseService<RegisterObjectElementInDto, RegisterObjectElementOutDto, RegisterObjectElements, decimal,
            RegiXContext>,
        IRegisterObjectElementService
    {
        private readonly ICertificateElementAccessRepository certificateElementAccessRepository;
        private readonly IConsumerRoleElementAccessRepository consumerRoleElementAccessRepository;
        private readonly IRegisterObjectElementsRepository aBaseRepository;

        public RegisterObjectElementService(
            IRegisterObjectElementsRepository aBaseRepository, ICertificateElementAccessRepository certificateElementAccessRepository,IConsumerRoleElementAccessRepository consumerRoleElementAccessRepository)
            : base(aBaseRepository, new RegisterObjectElementQueryValidator())
        {
            this.aBaseRepository = aBaseRepository;
            this.certificateElementAccessRepository = certificateElementAccessRepository;
            this.consumerRoleElementAccessRepository = consumerRoleElementAccessRepository;
        }

        /// <summary>
        ///     The PopulateDtoToEntityFieldsMapping
        /// </summary>
        protected override void PopulateDtoToEntityFieldsMapping()
        {
            dtoFieldsToEntityFields.Add("registerObject.id", "RegisterObject/RegisterObjectId");
            dtoFieldsToEntityFields.Add("registerObject.displayName", "RegisterObject/Name");
            dtoFieldsToEntityFields.Add("id", "RegisterObjectElementId");
        }

        protected override bool IsChildRecord(decimal aId, List<string> aParentsList)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets selected elements from table [CERTIFICATE_ELEMENT_ACCESS]
        /// </summary>
        /// <param name="registerObjectId"></param>
        /// <param name="certificateId"></param>
        /// <returns></returns>
        public IEnumerable<decimal> GetSelectedElements(decimal registerObjectId, decimal certificateId)
        {
            var allElementsForOperation =
                this.aBaseRepository.SelectAllByRegisterObjectId(registerObjectId);
            var selectedElementsForOperation =
                this.certificateElementAccessRepository
                .SelectAllByCertificateId(certificateId)
                .Where( x => x.HasAccess)
                .Select(x => x.RegisterObjectElementId)
                .ToArray();

            var result = allElementsForOperation
                .Where(x => selectedElementsForOperation.Contains(x.RegisterObjectElementId)).Select(x => x.RegisterObjectElementId).ToList();

            return result;
        }

        /// <summary>
        /// Gets selected elements from table [CONSUMER_ROLE_ELEMENT_ACCESS]
        /// </summary>
        /// <param name="registerObjectId"></param>
        /// <param name="consumerRoleId"></param>
        /// <returns></returns>
        public IEnumerable<decimal> GetSelectedConsumerRoleElements(decimal registerObjectId, decimal consumerRoleId)
        {
            var allElementsForOperation =
                this.aBaseRepository.SelectAllByRegisterObjectId(registerObjectId);
            var selectedElementsForOperation =
                this.consumerRoleElementAccessRepository
                    .SelectAllByConsumerRole(consumerRoleId)
                    .Where(x => x.HasAccess)
                    .Select(x => x.RegisterObjectElementId)
                    .ToArray();

            var result = allElementsForOperation
                .Where(x => selectedElementsForOperation.Contains(x.RegisterObjectElementId)).Select(x => x.RegisterObjectElementId).ToList();

            return result;
        }
    }

}