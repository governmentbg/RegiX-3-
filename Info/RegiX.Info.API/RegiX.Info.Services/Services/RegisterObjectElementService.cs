using RegiX.Info.DataContracts.DTO.RegisterObjectElement;
using RegiX.Info.Infrastructure.Models;
using RegiX.Info.Repositories.Contracts;
using RegiX.Info.Services.Contracts;
using RegiX.Info.Services.QueryValidators;
using System;
using System.Collections.Generic;
using TechnoLogica.API.Services;

namespace RegiX.Info.Services.Services
{
    /// <summary>
    ///     Defines the <see cref="RegisterObjectElementService" />
    /// </summary>
    public class RegisterObjectElementService :
        ABaseService<RegisterObjectElementInDto, RegisterObjectElementOutDto, RegisterObjectElements, decimal,
            RegiXContext>,
        IRegisterObjectElementService
    {
        //private readonly ICertificateElementAccessRepository certificateElementAccessRepository;
        //private readonly IConsumerRoleElementAccessRepository consumerRoleElementAccessRepository;
        private readonly IRegisterObjectElementsRepository aBaseRepository;

        public RegisterObjectElementService(
            IRegisterObjectElementsRepository aBaseRepository 
            //,ICertificateElementAccessRepository certificateElementAccessRepository, 
            //IConsumerRoleElementAccessRepository consumerRoleElementAccessRepository
            )
            : base(aBaseRepository, new RegisterObjectElementQueryValidator())
        {
            this.aBaseRepository = aBaseRepository;
            //this.certificateElementAccessRepository = certificateElementAccessRepository;
            //this.consumerRoleElementAccessRepository = consumerRoleElementAccessRepository;
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

        ///// <summary>
        ///// Gets selected elements from table [CERTIFICATE_ELEMENT_ACCESS]
        ///// </summary>
        ///// <param name="registerObjectId"></param>
        ///// <param name="certificateId"></param>
        ///// <returns></returns>
        //public IEnumerable<decimal> GetSelectedElements(decimal registerObjectId, decimal certificateId)
        //{
        //    var allElementsForOperation =
        //        this.aBaseRepository.SelectAllByRegisterObjectId(registerObjectId);
        //    var selectedElementsForOperation =
        //        this.certificateElementAccessRepository
        //        .SelectAllByCertificateId(certificateId)
        //        .Select(x => x.RegisterObjectElementId)
        //        .ToArray();

        //    var result = allElementsForOperation
        //        .Where(x => selectedElementsForOperation.Contains(x.RegisterObjectElementId)).Select(x => x.RegisterObjectElementId).ToList();

        //    return result;
        //}

        ///// <summary>
        ///// Gets selected elements from table [CONSUMER_ROLE_ELEMENT_ACCESS]
        ///// </summary>
        ///// <param name="registerObjectId"></param>
        ///// <param name="consumerRoleId"></param>
        ///// <returns></returns>
        //public IEnumerable<decimal> GetSelectedConsumerRoleElements(decimal registerObjectId, decimal consumerRoleId)
        //{
        //    var allElementsForOperation =
        //        this.aBaseRepository.SelectAllByRegisterObjectId(registerObjectId);
        //    var selectedElementsForOperation =
        //        this.consumerRoleElementAccessRepository
        //            .SelectAllByConsumerRole(consumerRoleId)
        //            .Select(x => x.RegisterObjectElementId)
        //            .ToArray();

        //    var result = allElementsForOperation
        //        .Where(x => selectedElementsForOperation.Contains(x.RegisterObjectElementId)).Select(x => x.RegisterObjectElementId).ToList();

        //    return result;
        //}
    }
}
