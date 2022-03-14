using System;
using System.Collections.Generic;
using System.Linq;
using TechnoLogica.API.Services;
using TechnoLogica.RegiX.Admin.API.DataContracts.DTO.ConsumerAccessRequests;
using TechnoLogica.RegiX.Admin.Infrastructure;
using TechnoLogica.RegiX.Admin.Infrastructure.Models;
using TechnoLogica.RegiX.Admin.Repositories.Contracts;
using TechnoLogica.RegiX.Admin.Services.Contracts;
using TechnoLogica.RegiX.Admin.Services.Enums;
using TechnoLogica.RegiX.Admin.Services.QueryValidators;

namespace TechnoLogica.RegiX.Admin.Services.Services
{
    public class ConsumerAccessRequestsService :
        ABaseService<ConsumerAccessRequestsInDto, ConsumerAccessRequestsOutDto, ConsumerAccessRequests, decimal,
            RegiXContext>,
        IConsumerAccessRequestsService
    {

        private readonly IConsumerAccessRequestsStatusRepository consumerAccessRequestsStatusRepository;
        private readonly IApprovedRequestElementsRepository approvedRequestElementsRepository;
        private readonly IConsumerSystemCertificatesRepository consumerSystemCertificatesRepository;
        private readonly IConsumerCertificatesRepository consumerCertificatesRepository;
        private readonly ICertificateOperationAccessRepository certificateOperationAccessRepository;
        private readonly IRegisterObjectElementsRepository registerObjectElementsRepository;
        private readonly ICertificateElementAccessRepository certificateElementAccessRepository;
        private readonly IUserContext userContext;

        public ConsumerAccessRequestsService(IConsumerAccessRequestsRepository aBaseRepository
            , IConsumerAccessRequestsStatusRepository consumerAccessRequestsStatusRepository,
            IApprovedRequestElementsRepository approvedRequestElementsRepository,
            IConsumerSystemCertificatesRepository consumerSystemCertificatesRepository,
            IConsumerCertificatesRepository consumerCertificatesRepository,
            ICertificateOperationAccessRepository certificateOperationAccessRepository,
            IRegisterObjectElementsRepository registerObjectElementsRepository,
            ICertificateElementAccessRepository certificateElementAccessRepository,
            IUserContext userContext)
            : base(aBaseRepository, new ConsumerAccessRequestsQueryValidator())
        {
            this.consumerAccessRequestsStatusRepository = consumerAccessRequestsStatusRepository;
            this.approvedRequestElementsRepository = approvedRequestElementsRepository;
            this.consumerSystemCertificatesRepository = consumerSystemCertificatesRepository;
            this.consumerCertificatesRepository = consumerCertificatesRepository;
            this.certificateOperationAccessRepository = certificateOperationAccessRepository;
            this.registerObjectElementsRepository = registerObjectElementsRepository;
            this.certificateElementAccessRepository = certificateElementAccessRepository;
            this.userContext = userContext;
        }

        public override ConsumerAccessRequestsOutDto Update(decimal aId, ConsumerAccessRequestsInDto aInDto)
        {
            try
            {
                var currentStatus =
                    consumerAccessRequestsStatusRepository
                        .SelectAll()
                        .Where(x => x.ConsumerAccessRequestId == aInDto.Id)
                        .OrderByDescending(x => x.Date)
                        .FirstOrDefault();
                if (currentStatus == null)
                {
                    throw new Exception("Object with ConsumerAccessRequestId [" + aInDto.Id + "] not found!");
                }

                //Inserting into status table for ConsumerAccessRequests
                var consumerAccessRequestsStatus = new ConsumerAccessRequestsStatus
                {
                    OldStatus = currentStatus.NewStatus,
                    NewStatus = aInDto.Status,
                    Comment = aInDto.Comment,
                    Date = DateTime.Now,
                    ConsumerAccessRequestId = aInDto.Id
                };
                this.consumerAccessRequestsStatusRepository.Insert(consumerAccessRequestsStatus);

                InsertApprovedRequestElements(aInDto);//when status is Approved (3)

                InsertRequestToApplication(aInDto);//when status is Accepted (4)

                var repoObj = this._baseRepository.Select(aId);
                if (repoObj == null)
                {
                    throw new Exception("Object with id [" + aId + "] not found!");
                }

                repoObj.Status = aInDto.Status;
                this._baseRepository.GetDbContext().SaveChanges();
                return MappingTools.MapTo<ConsumerAccessRequests, ConsumerAccessRequestsOutDto>(repoObj);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }


        protected override void PopulateDtoToEntityFieldsMapping()
        {
            dtoFieldsToEntityFields.Add("adapterOperation.id", "AdapterOperation/AdapterOperationId");
            dtoFieldsToEntityFields.Add("adapterOperation.displayName", "AdapterOperation/Name");
            dtoFieldsToEntityFields.Add("adapterOperation.registerObjectId", "AdapterOperation/RegisterObjectId");
            dtoFieldsToEntityFields.Add("adapterOperation.description", "AdapterOperation/Description");
            dtoFieldsToEntityFields.Add("consumerSystemCertificate.id", "ConsumerSystemCertificate/ConsumerSystemCertificateId");
            dtoFieldsToEntityFields.Add("consumerSystemCertificate.displayName", "ConsumerSystemCertificate/Name");
            dtoFieldsToEntityFields.Add("consumerRequest.id", "ConsumerRequest/ConsumerRequestId");
            dtoFieldsToEntityFields.Add("consumerRequest.displayName", "ConsumerRequest/Name");
            dtoFieldsToEntityFields.Add("id", "ConsumerAccessRequestId");
        }

        protected override bool IsChildRecord(decimal aId, List<string> aParentsList)
        {
            return false;
        }

        private void InsertApprovedRequestElements(ConsumerAccessRequestsInDto aInDto)
        {
            if (aInDto.Status == (int)RequestStatus.Аpproved && this.userContext.Role == Roles.ADMIN.ToString())
            {
                //gets all approvedRequestElements for specific ConsumerAccessRequestId
                var approvedRequestElements =
                    this.approvedRequestElementsRepository
                        .SelectAll()
                        .Where(x => x.ConsumerAccessRequestId == aInDto.Id).ToArray();

                var registerObjectsElementsToDelete =
                    approvedRequestElements
                        .Select(x => x.RegisterObjectElementId)
                        .Except(aInDto.ApprovedRequestElementIds);

                var elementsToDelete =
                    approvedRequestElements
                        .Where(x => registerObjectsElementsToDelete.Contains(x.RegisterObjectElementId))
                        .Select(x => x.Id);

                foreach (var element in elementsToDelete)
                {
                    this.approvedRequestElementsRepository.Delete(element);
                }

                var elementsToInsert =
                    aInDto.ApprovedRequestElementIds
                        .Except(approvedRequestElements
                            .Select(x => x.RegisterObjectElementId));


                foreach (var approvedRequestElementId in elementsToInsert)
                {
                    this.approvedRequestElementsRepository
                        .Insert(new ApprovedRequestElements()
                        {
                            RegisterObjectElementId = approvedRequestElementId,
                            ConsumerAccessRequestId = aInDto.Id
                        });
                }
            }
        }

        private void InsertRequestToApplication(ConsumerAccessRequestsInDto aInDto)
        {
            if (aInDto.Status == (int)RequestStatus.Accepted && this.userContext.Role == Roles.GLOBAL_ADMIN.ToString())
            {
                //get consumerSystemCertificate
                var consumerSystemCertificate =
                    this.consumerSystemCertificatesRepository.Select(aInDto.ConsumerSystemCertificate.Id);

                //get consumerCertificate
                var consumerCertificate =
                    this.consumerCertificatesRepository
                        .Select((decimal)consumerSystemCertificate.ConsumerCertificateId);

                //get all operations for that certificate
                var certificateOperationAccess =
                    this.certificateOperationAccessRepository
                        .SelectAll()
                        .Where(x => x.ConsumerCertificateId == consumerCertificate.ConsumerCertificateId);

                //adding operation to certificate if it doesn't have access to that operation 
                if (!certificateOperationAccess.Select(x => x.AdapterOperationId).Contains(aInDto.AdapterOperation.Id))
                {
                    var newCertificateOperationAccess = new CertificateOperationAccess()
                    {
                        ConsumerCertificateId = consumerCertificate.ConsumerCertificateId,
                        AdapterOperationId = aInDto.AdapterOperation.Id,
                        HasAccess = true
                    };
                    this.certificateOperationAccessRepository.Insert(newCertificateOperationAccess);
                }

                //gets all elements for specific operation
                var getAllElementsForOperation =
                    this.registerObjectElementsRepository
                        .SelectAll()
                        .Where(x => x.RegisterObjectId == aInDto.AdapterOperation.RegisterObjectId)
                        .Select(x => x.RegisterObjectElementId);

                //get all elements that certificate have access
                var certificateElementAccess = this.certificateElementAccessRepository
                    .SelectAll()
                    .Where(x => x.ConsumerCertificateId == consumerCertificate.ConsumerCertificateId &&
                                getAllElementsForOperation.Contains(x.RegisterObjectElementId));

                //delete only elements missing in ApprovedRequestElementIds
                var elementsToDelete = certificateElementAccess
                    .Where(x => !aInDto.ApprovedRequestElementIds.Contains(x.RegisterObjectElementId))
                    .Select(x => x.Id);

                foreach (var elementId in elementsToDelete)
                {
                    this.certificateElementAccessRepository.Delete(elementId);
                }

                //insert only new elements
                var elementsToInsert =
                    aInDto.ApprovedRequestElementIds.Except(
                        certificateElementAccess.Select(x => x.RegisterObjectElementId));

                //insert approved elements
                foreach (var elementId in elementsToInsert)
                {
                    this.certificateElementAccessRepository.Insert(new CertificateElementAccess()
                    {
                        ConsumerCertificateId = consumerCertificate.ConsumerCertificateId,
                        RegisterObjectElementId = elementId,
                        HasAccess = true
                    });
                }
            }
        }
    }
}