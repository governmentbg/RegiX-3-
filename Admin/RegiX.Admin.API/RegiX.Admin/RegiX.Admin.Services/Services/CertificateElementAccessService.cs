using System;
using System.Collections.Generic;
using System.Linq;
using TechnoLogica.API.Services;
using TechnoLogica.RegiX.Admin.API.DataContracts.DTO.CertificateElementAccess;
using TechnoLogica.RegiX.Admin.Infrastructure.Models;
using TechnoLogica.RegiX.Admin.Repositories.Contracts;
using TechnoLogica.RegiX.Admin.Services.Contracts;
using TechnoLogica.RegiX.Admin.Services.QueryValidators;

namespace TechnoLogica.RegiX.Admin.Services.Services
{
    /// <summary>
    ///   Defines the <see cref="CertificateElementAccessService" />
    /// </summary>
    public class CertificateElementAccessService :
        ABaseService<CertificateElementAccessInDto, CertificateElementAccessOutDto, CertificateElementAccess, decimal,
            RegiXContext>,
        ICertificateElementAccessService
    {
        /// <summary>
        ///   Defines the accessCommentsRepository
        /// </summary>
        private readonly ICertificateAccessCommentsRepository accessCommentsRepository;

        private readonly IAdapterOperationsRepository adapterOperationsRepository;

        private readonly IRegisterObjectElementsRepository registerObjectElementsRepository;

        /// <summary>
        ///   Defines the operationAccessRepository
        /// </summary>
        private readonly ICertificateOperationAccessRepository operationAccessRepository;

        public CertificateElementAccessService
        (
            ICertificateElementAccessRepository aBaseRepository,
            ICertificateAccessCommentsRepository aAccessCommentsRepository,
            ICertificateOperationAccessRepository aOperationAccessRepository,
            IAdapterOperationsRepository aAdapterOperationsRepository,
            IRegisterObjectElementsRepository aRegisterObjectElementsRepository
        )
            : base(aBaseRepository, new CertificateElementAccessQueryValidator())
        {
            accessCommentsRepository = aAccessCommentsRepository;
            operationAccessRepository = aOperationAccessRepository;
            adapterOperationsRepository = aAdapterOperationsRepository;
            registerObjectElementsRepository = aRegisterObjectElementsRepository;
        }


        /// <summary>
        ///   The Insert
        /// </summary>
        /// <param name="aInDto">The aInDto<see cref="CertificateElementAccessInDto" /></param>
        /// <returns>The <see cref="CertificateElementAccessOutDto" /></returns>
        public override CertificateElementAccessOutDto Insert(CertificateElementAccessInDto aInDto)
        {
            try
            {
                var accessComments = new CertificateAccessComments();
                accessComments.AdapterOperationId = aInDto.AdapterOperationId;
                accessComments.ConsumerCertificateId = aInDto.ConsumerCertificateId;
                accessComments.EditAccessComment = aInDto.EditAccessComment;
                accessComments.CreatedTime = DateTime.Now;
                accessComments.UserId = aInDto.UserId;


                accessComments = accessCommentsRepository.Insert(accessComments);
                // TODO set the identifier of resultCertificate in the CROSS-TABLE (CertificateElementAccess)
                // decimal commentId = resultComment.Id;

                var registerObjectId =
                    adapterOperationsRepository.Select(aInDto.AdapterOperationId).RegisterObjectId.Value;

                var elements = _baseRepository
                    .SelectAll()
                    .Where(elem => elem.ConsumerCertificateId == aInDto.ConsumerCertificateId &&
                                   elem.RegisterObjectElement.RegisterObjectId == registerObjectId)
                    .ToList();

                if (elements.Count == 0)
                {
                    var elementIDs = registerObjectElementsRepository.SelectAll().Where(roe => roe.RegisterObjectId == registerObjectId).Select(roe => roe.RegisterObjectElementId).ToList();
                    foreach(var elementID in elementIDs)
                    {
                        var elem = new CertificateElementAccess();
                        elem.RegisterObjectElementId = elementID;
                        elem.ConsumerCertificateId = aInDto.ConsumerCertificateId;
                        elem.HasAccess = aInDto.HasAccess && aInDto.RegisterObjectElementIds.Contains(elementID);
                        //elem.ConsumerAccessCommentsId = commentId;

                        _baseRepository.Insert(elem);
                    }
                }
                else
                {
                    foreach(var element in elements)
                    {
                        element.HasAccess = aInDto.RegisterObjectElementIds.Contains(element.RegisterObjectElementId);
                    }
                }

                // find if there is already given access for the current operation and certificate
                var access = operationAccessRepository
                    .SelectAll()
                    .Where(elem => elem.AdapterOperationId == aInDto.AdapterOperationId &&
                                   elem.ConsumerCertificateId == aInDto.ConsumerCertificateId)
                    .SingleOrDefault();

                if (access == null)
                {
                    var operationAccess = new CertificateOperationAccess();
                    operationAccess.AdapterOperationId = aInDto.AdapterOperationId;
                    operationAccess.HasAccess = aInDto.HasAccess && aInDto.RegisterObjectElementIds.Length > 0;
                    operationAccess.ConsumerCertificateId = aInDto.ConsumerCertificateId;
                    operationAccessRepository.Insert(operationAccess);
                }
                else
                {
                    access.HasAccess = aInDto.HasAccess && aInDto.RegisterObjectElementIds.Length > 0;
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

        /// <summary>
        ///   The PopulateDtoToEntityFieldsMapping
        /// </summary>
        protected override void PopulateDtoToEntityFieldsMapping()
        {
            dtoFieldsToEntityFields.Add("consumerCertificate.id", "ConsumerCertificate/ConsumerCertificateId");
            dtoFieldsToEntityFields.Add("consumerCertificate.displayName", "ConsumerCertificate/Name");
            dtoFieldsToEntityFields.Add("registerObjectElement.id", "RegisterObjectElement/RegisterObjectElementId");
            dtoFieldsToEntityFields.Add("registerObjectElement.displayName", "RegisterObjectElement/Name");
        }

        protected override bool IsChildRecord(decimal aId, List<string> aParentsList)
        {
            throw new NotImplementedException();
        }


        public List<CertificateElementAccessOutDto> SelectAllByCertificateId(decimal certificateId)
        {
            return SelectAllByCertificateId(certificateId);
        }
    }
}