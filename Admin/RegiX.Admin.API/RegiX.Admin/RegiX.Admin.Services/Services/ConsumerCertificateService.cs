using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography.X509Certificates;
using TechnoLogica.API.Repositories.Contracts;
using TechnoLogica.API.Services;
using TechnoLogica.RegiX.Admin.API.DataContracts.DTO.ConsumerCertificate;
using TechnoLogica.RegiX.Admin.Infrastructure;
using TechnoLogica.RegiX.Admin.Infrastructure.Models;
using TechnoLogica.RegiX.Admin.Repositories.Contracts;
using TechnoLogica.RegiX.Admin.Services.Contracts;
using TechnoLogica.RegiX.Admin.Services.QueryValidators;

namespace TechnoLogica.RegiX.Admin.Services.Services
{
    /// <summary>
    ///     Defines the <see cref="ConsumerCertificateService" />
    /// </summary>
    public class ConsumerCertificateService :
        ABaseService<ConsumerCertificateInDto, ConsumerCertificateOutDto, ConsumerCertificates, decimal, RegiXContext>,
        IConsumerCertificateService
    {
        private readonly ICertificateAccessCommentsRepository certificateAccessCommentsRepository;
        private readonly ICertificateConsumerRoleRepository certificateConsumerRoleRepository;
        private readonly ICertificateElementAccessRepository certificateElementAccessRepository;
        private readonly ICertificateOperationAccessRepository certificateOperationAccessRepository;
        private readonly IConsumerSystemCertificatesRepository consumerSystemCertificatesRepository;
        private readonly IConsumerCertificatesReportsRepository consumerCertificatesReportsRepository;
        private readonly IApiServiceCallsRepository apiServiceCallsRepository;
        private readonly IUserContext userContext;
        public ConsumerCertificateService(
            ICertificateAccessCommentsRepository certificateAccessCommentsRepository,
            IConsumerCertificatesRepository aBaseRepository,
            ICertificateConsumerRoleRepository certificateConsumerRoleRepository,
            ICertificateElementAccessRepository certificateElementAccessRepository,
            ICertificateOperationAccessRepository certificateOperationAccessRepository,
            IConsumerSystemCertificatesRepository consumerSystemCertificatesRepository,
            IConsumerCertificatesReportsRepository consumerCertificatesReportsRepository,
            IApiServiceCallsRepository apiServiceCallsRepository,
            IUserContext userContext)
            : base(aBaseRepository, new ConsumerCertificateQueryValidator())
        {
            this.certificateAccessCommentsRepository = certificateAccessCommentsRepository;
            this.certificateConsumerRoleRepository = certificateConsumerRoleRepository;
            this.certificateElementAccessRepository = certificateElementAccessRepository;
            this.certificateOperationAccessRepository = certificateOperationAccessRepository;
            this.consumerSystemCertificatesRepository = consumerSystemCertificatesRepository;
            this.consumerCertificatesReportsRepository = consumerCertificatesReportsRepository;
            this.apiServiceCallsRepository = apiServiceCallsRepository;
            this.userContext = userContext;
        }

        /// <summary>
        ///     The Update
        /// </summary>
        /// <param name="aId">The aId<see cref="decimal" /></param>
        /// <param name="aInDto">The aInDto<see cref="ConsumerCertificateInDto" /></param>
        /// <returns>The <see cref="ConsumerCertificateOutDto" /></returns>
        public override ConsumerCertificateOutDto Update(decimal aId, ConsumerCertificateInDto aInDto)
        {
            if (!userContext.UserId.HasValue)
            {
                throw new ApplicationException("UserId should be provided");
            }
            var repoObj = _baseRepository.Select(aId);
            if (repoObj == null) throw new Exception("Object with id [" + aId + "] not found!");

            if (repoObj.ApiServiceConsumerId != aInDto.ApiServiceConsumerId)
                throw new Exception("ApiServiceConsumerId cannot be modified!");

            repoObj = MappingTools.MapTo(aInDto, repoObj);
            FillConsumerCertificate(repoObj.Content, repoObj);
            var result = _baseRepository.Update(repoObj);

            var certificatesToConsumerRoles = certificateConsumerRoleRepository
                .SelectAll()
                .Where(elem => elem.ConsumerCertificateId == aId)
                .ToList();

            certificatesToConsumerRoles.ForEach(
                elem => { 
                    if (!aInDto.consumerRoleIds.Any( cri => cri.Id == elem.ConsumerRoleId))
                    {
                        //delete not existing roles for current certificate
                        certificateConsumerRoleRepository.Delete(elem.Id);
                    }
                    else
                    {
                        //Update comment for existing roles for current certificate
                        elem.EditAccessComment = 
                            aInDto.consumerRoleIds.First(cri => cri.Id == elem.ConsumerRoleId).DisplayName;
                        certificateConsumerRoleRepository.Update(elem);
                    }
                }
            );

            foreach (var consumerRole in aInDto.consumerRoleIds)
            {
                if (!certificatesToConsumerRoles.Any( cri => cri.ConsumerRoleId == consumerRole.Id))
                {
                    //insert not existing roles for certificate  
                    var certificateConsumerRole = new CertificateConsumerRole
                    {
                        ConsumerCertificateId = aId,
                        ConsumerRoleId = consumerRole.Id,
                        CreatedTime = DateTime.Now,
                        EditAccessComment = consumerRole.DisplayName,
                        UserId = userContext.UserId.Value
                    };
                    certificateConsumerRoleRepository.Insert(certificateConsumerRole);
                }
            }

            _baseRepository.GetDbContext().SaveChanges();
            return MappingTools.MapTo<ConsumerCertificates, ConsumerCertificateOutDto>(result);
        }

        /// <summary>
        ///     The Insert
        /// </summary>
        /// <param name="aInDto">The aInDto<see cref="ConsumerCertificateInDto" /></param>
        /// <returns>The <see cref="ConsumerCertificateOutDto" /></returns>
        public override ConsumerCertificateOutDto Insert(ConsumerCertificateInDto aInDto)
        {
            if (!userContext.UserId.HasValue)
            {
                throw new ApplicationException("UserId should be provided");
            }
            var consumerCertificate = MappingTools.MapTo<ConsumerCertificateInDto, ConsumerCertificates>(aInDto);
            FillConsumerCertificate(aInDto.Content, consumerCertificate);
            var resultCertificate = _baseRepository.Insert(consumerCertificate);
            // Insert associated roles
            foreach (var consumerRole in aInDto.consumerRoleIds)
            {
                //insert not existing roles for certificate  
                var certificateConsumerRole = new CertificateConsumerRole
                {
                    ConsumerCertificate = resultCertificate,
                    ConsumerRoleId = consumerRole.Id,
                    CreatedTime = DateTime.Now,
                    EditAccessComment = consumerRole.DisplayName,
                    UserId = userContext.UserId.Value
                };
                certificateConsumerRoleRepository.Insert(certificateConsumerRole);
            }

            _baseRepository.GetDbContext().SaveChanges();
            resultCertificate = _baseRepository.Select(consumerCertificate.ConsumerCertificateId);

            var mappedCertificate = MappingTools
                .MapTo<ConsumerCertificates, ConsumerCertificateOutDto>(resultCertificate);

            return mappedCertificate;
        }


        public ConsumerCertificateOutDto SwapCertificates(decimal sourceId, decimal destinationId)
        {
            var sourceCertificate = _baseRepository.Select(sourceId);
            var destinationCertificate = _baseRepository.Select(destinationId);

            if (destinationCertificate.CertificateOperationAccess.Count > 0)
            {
                throw new InvalidOperationException("Не успешно прехвърляне на правата!");
            }

            var exchangeCertificate = new ConsumerCertificates()
            {
                ConsumerCertificateId = destinationCertificate.ConsumerCertificateId,
                Name = destinationCertificate.Name,
                Description = destinationCertificate.Description,
                Thumbprint = destinationCertificate.Thumbprint,
                Content = destinationCertificate.Content,
                IssuedFrom = destinationCertificate.IssuedFrom,
                IssuedTo = destinationCertificate.IssuedTo,
                ValidFrom = destinationCertificate.ValidFrom,
                ValidTo = destinationCertificate.ValidTo,
            };

            //source to destination 
            destinationCertificate.Name = sourceCertificate.Name;
            destinationCertificate.Description = sourceCertificate.Description;
            destinationCertificate.Thumbprint = sourceCertificate.Thumbprint;
            destinationCertificate.Content = sourceCertificate.Content;
            destinationCertificate.IssuedFrom = sourceCertificate.IssuedFrom;
            destinationCertificate.IssuedTo = sourceCertificate.IssuedTo;
            destinationCertificate.ValidFrom = sourceCertificate.ValidFrom;
            destinationCertificate.ValidTo = sourceCertificate.ValidTo;
            destinationCertificate.Active = false;

            swapConsumerCertificate<CertificateConsumerRole>(sourceId, destinationId, certificateConsumerRoleRepository);
            swapConsumerCertificate<CertificateAccessComments>(sourceId, destinationId, certificateAccessCommentsRepository);
            swapConsumerCertificate<CertificateElementAccess>(sourceId, destinationId, certificateElementAccessRepository);
            swapConsumerCertificate<CertificateOperationAccess>(sourceId, destinationId, certificateOperationAccessRepository);
            swapConsumerCertificate<ConsumerSystemCertificates>(sourceId, destinationId, consumerSystemCertificatesRepository);//
            swapConsumerCertificate<ConsumerCertificatesReports>(sourceId, destinationId, consumerCertificatesReportsRepository);
            swapConsumerCertificate<ApiServiceCalls>(sourceId, destinationId, apiServiceCallsRepository);

            
            //destination to source
            sourceCertificate.Name = exchangeCertificate.Name;
            sourceCertificate.Description = exchangeCertificate.Description;
            sourceCertificate.Thumbprint = exchangeCertificate.Thumbprint;
            sourceCertificate.Content = exchangeCertificate.Content;
            sourceCertificate.IssuedFrom = exchangeCertificate.IssuedFrom;
            sourceCertificate.IssuedTo = exchangeCertificate.IssuedTo;
            sourceCertificate.ValidFrom = exchangeCertificate.ValidFrom;
            sourceCertificate.ValidTo = exchangeCertificate.ValidTo;

            _baseRepository.Update(destinationCertificate);
            _baseRepository.Update(sourceCertificate);

            this._baseRepository.GetDbContext().SaveChanges();

            var mappedCertificate = MappingTools
                .MapTo<ConsumerCertificates, ConsumerCertificateOutDto>(destinationCertificate);

            return mappedCertificate;
        }

        /// <summary>
        ///     The PopulateDtoToEntityFieldsMapping
        /// </summary>
        protected override void PopulateDtoToEntityFieldsMapping()
        {
            dtoFieldsToEntityFields.Add("apiServiceConsumer.id", "ApiServiceConsumer/ApiServiceConsumerId");
            dtoFieldsToEntityFields.Add("apiServiceConsumer.displayName", "ApiServiceConsumer/Name");
            dtoFieldsToEntityFields.Add("apiServiceConsumer.oid", "ApiServiceConsumer/Oid");
            dtoFieldsToEntityFields.Add("id", "ConsumerCertificateId");
        }

        protected override bool IsChildRecord(decimal aId, List<string> aParentsList)
        {
            return false;
        }

        /// <summary>
        ///     The FillConsumerCertificate
        /// </summary>
        /// <param name="content">The content<see cref="byte[]" /></param>
        /// <param name="consumerCertificate">The consumerCertificate<see cref="ConsumerCertificates" /></param>
        private void FillConsumerCertificate(byte[] content, ConsumerCertificates consumerCertificate)
        {
            var uploadedCert = new X509Certificate2(content);
            consumerCertificate.Thumbprint = uploadedCert.Thumbprint;
            consumerCertificate.IssuedFrom = uploadedCert.Issuer;
            consumerCertificate.IssuedTo = uploadedCert.GetNameInfo(X509NameType.SimpleName, true);
            consumerCertificate.ValidFrom = uploadedCert.NotBefore;
            consumerCertificate.ValidTo = uploadedCert.NotAfter;
        }

        private void swapConsumerCertificate<T>(decimal sourceId, decimal destinationId, IBaseRepository<T, decimal, RegiXContext> repository) where T : class
        {
            var source = repository.SelectAll();
            var idName = "ConsumerCertificateId";

            var param = Expression.Parameter(typeof(T));
            var condition =
                Expression.Lambda<Func<T, bool>>(
                    Expression.Equal(
                        Expression.Property(param, idName),
                        Expression.Constant(
                            (Expression.Property(param, idName).Type is decimal?) ? (decimal?)sourceId : sourceId, 
                            Expression.Property(param, idName).Type)
                    ),
                    param
                );

            var sourceCertificateConsumerRole = source
                .Where(condition);

            foreach (var certificateConsumerRole in sourceCertificateConsumerRole)
            {
                certificateConsumerRole.GetType().GetProperty("ConsumerCertificateId").SetValue(certificateConsumerRole, destinationId, null);
                repository.Update(certificateConsumerRole);
            }

            var conditionDestination =
                Expression.Lambda<Func<T, bool>>(
                    Expression.Equal(
                        Expression.Property(param, idName),
                        Expression.Constant(
                            (Expression.Property(param, idName).Type is decimal?) ? (decimal?)destinationId : destinationId,
                            Expression.Property(param, idName).Type)
                    ),
                    param
                );

            var destinationCertificateConsumerRole = source
                .Where(conditionDestination);

            foreach (var certificateConsumerRole in destinationCertificateConsumerRole)
            {
                certificateConsumerRole.GetType().GetProperty("ConsumerCertificateId").SetValue(certificateConsumerRole, sourceId, null);
                repository.Update(certificateConsumerRole);
            }
        }
    }
}