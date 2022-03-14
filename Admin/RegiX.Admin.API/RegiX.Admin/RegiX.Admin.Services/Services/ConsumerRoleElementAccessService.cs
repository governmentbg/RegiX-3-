using System;
using System.Collections.Generic;
using System.Linq;
using TechnoLogica.API.Repositories.Contracts;
using TechnoLogica.API.Services;
using TechnoLogica.RegiX.Admin.API.DataContracts.DTO.CertificateElementAccess;
using TechnoLogica.RegiX.Admin.API.DataContracts.DTO.ConsumerRoleElementAccess;
using TechnoLogica.RegiX.Admin.Infrastructure.Models;
using TechnoLogica.RegiX.Admin.Repositories.Contracts;
using TechnoLogica.RegiX.Admin.Services.Contracts;
using TechnoLogica.RegiX.Admin.Services.QueryValidators;

namespace TechnoLogica.RegiX.Admin.Services.Services
{
    public class ConsumerRoleElementAccessService : 
        ABaseService<ConsumerRoleElementAccessInDto, ConsumerRoleElementAccessOutDto, ConsumerRoleElementAccess, decimal,
            RegiXContext>,
        IConsumerRoleElementAccessService
    {
        private readonly IConsumerRoleOperationAccessRepository consumerRoleOperationAccessRepository;
        private readonly IAdapterOperationsRepository adapterOperationsRepository;

        public ConsumerRoleElementAccessService
        (
            IBaseRepository<ConsumerRoleElementAccess, decimal, RegiXContext> aBaseRepository,
            
            IConsumerRoleOperationAccessRepository consumerRoleOperationAccessRepository,
            IAdapterOperationsRepository adapterOperationsRepository
        ) 
            : base(aBaseRepository, new ConsumerRoleElementAccessQueryValidator())
        {
            this.consumerRoleOperationAccessRepository = consumerRoleOperationAccessRepository;
            this.adapterOperationsRepository = adapterOperationsRepository;
        }

        /// <summary>
        ///     The Insert
        /// </summary>
        /// <param name="aInDto">The aInDto<see cref="CertificateElementAccessInDto" /></param>
        /// <returns>The <see cref="CertificateElementAccessOutDto" /></returns>
        public override ConsumerRoleElementAccessOutDto Insert(ConsumerRoleElementAccessInDto aInDto)
        {
            try
            {
                decimal registerObjectId =
                    this.adapterOperationsRepository.Select(aInDto.AdapterOperationId).RegisterObjectId.Value;

                
                var elements = _baseRepository
                    .SelectAll()
                    .Where(elem => elem.ConsumerRoleId == aInDto.ConsumerRoleId &&
                                   elem.RegisterObjectElement.RegisterObjectId == registerObjectId)
                    .ToList();

                //remove only those that are not present in aInDto.RegisterObjectElementIds
                var elementsToDelete = elements
                    .Where(x => !aInDto.RegisterObjectElementIds.Contains(x.RegisterObjectElementId))
                    .ToList();

                elementsToDelete.ForEach(elem => { _baseRepository.Delete(elem.Id); });

                // find if there is already given access for the current operation and role
                var accesses = consumerRoleOperationAccessRepository
                    .SelectAll()
                    .Where(elem => elem.AdapterOperationId == aInDto.AdapterOperationId &&
                                   elem.ConsumerRoleId == aInDto.ConsumerRoleId)
                    .ToList();
                if (accesses.Count == 0)
                {
                    var operationAccess = new ConsumerRoleOperationAccess();
                    operationAccess.AdapterOperationId = aInDto.AdapterOperationId;
                    operationAccess.HasAccess = aInDto.HasAccess;
                    operationAccess.ConsumerRoleId = aInDto.ConsumerRoleId;
                    consumerRoleOperationAccessRepository.Insert(operationAccess);
                }


                //Add only new elements to DB 
                var elementIdsToAdd = aInDto.RegisterObjectElementIds
                    .Where(x => !elements.Select(y => y.RegisterObjectElementId).Contains(x)).ToList();

                // insert element identifiers
                foreach (var element in elementIdsToAdd)
                {
                    var elem = new ConsumerRoleElementAccess();
                    elem.RegisterObjectElementId = element;
                    elem.ConsumerRoleId = aInDto.ConsumerRoleId;
                    elem.HasAccess = aInDto.HasAccess;

                    _baseRepository.Insert(elem);
                }

                _baseRepository.GetDbContext().SaveChanges();
            }
            catch (Exception e)
            {
                throw e;
            }

            // TODO fix return?
            return null;
        }

        protected override void PopulateDtoToEntityFieldsMapping()
        {
            dtoFieldsToEntityFields.Add("consumerRole.id", "ConsumerRole/Id");
            dtoFieldsToEntityFields.Add("consumerRole.displayName", "ConsumerRole/Name");
            dtoFieldsToEntityFields.Add("registerObjectElement.id", "RegisterObjectElement/RegisterObjectElementId");
            dtoFieldsToEntityFields.Add("registerObjectElement.displayName", "RegisterObjectElement/Name");
        }

        protected override bool IsChildRecord(decimal aId, List<string> aParentsList)
        {
            return false;
        }
    }
}