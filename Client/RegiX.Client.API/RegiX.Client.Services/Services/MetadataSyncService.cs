using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using TechnoLogica.RegiX.Client.API.DataContracts.DTO.MetadataSyncServiceDtos;
using TechnoLogica.RegiX.Client.Infrastructure.Models;
using TechnoLogica.RegiX.Client.Repositories.Contracts;
using TechnoLogica.RegiX.Client.Services.Contracts;

namespace TechnoLogica.RegiX.Client.Services.Services
{
    public class MetadataSyncService : IMetadataSyncService
    {
        public static string  REGIX_INFO_URL = "";
        private const string PATH_URL = "api/administrations/GetWithOperations";

        private readonly IRegistersRepository registersRepository;
        private readonly IAuthoritiesRepository authoritiesRepository;
        private readonly IAdapterOperationsRepository adapterOperationsRepository;
        private readonly ILogger<MetadataSyncService> logger;

        public MetadataSyncService(
            IRegistersRepository registersRepository,
            IAuthoritiesRepository authoritiesRepository,
            IAdapterOperationsRepository adapterOperationsRepository,
            ILogger<MetadataSyncService> logger)
        {
            this.registersRepository = registersRepository;
            this.authoritiesRepository = authoritiesRepository;
            this.adapterOperationsRepository = adapterOperationsRepository;
            this.logger = logger;
        }

        public void UpdateMetadata()
        {
            //Makes http request to RegiX.Info.API and gets the authorities
            IEnumerable<AuthoritiesDto> authorities = GetAllAuthorities();

            foreach (var authority in authorities)
            {
                Authorities authorityDB = this.authoritiesRepository.SelectByCode(authority.Code);

                if (authorityDB == null)
                {
                    authorityDB = new Authorities();
                    UpdateAuthorityProperties(authority, authorityDB);
                    authorityDB.DisplayName = authority.Name;
                    authorityDB = this.authoritiesRepository.Insert(authorityDB);
                }
                else
                {
                    UpdateAuthorityProperties(authority, authorityDB);
                    this.authoritiesRepository.Update(authorityDB);
                }   
                this.authoritiesRepository.GetDbContext().SaveChanges();

                foreach (var register in authority.Registers)
                {
                    foreach( var adapter in register.Adapters)
                    {
                        var registerDB = this.registersRepository.SelectByCode(adapter.Name);
                        if (registerDB == null)
                        {
                            registerDB = new Registers();
                            registerDB.Code = adapter.Name;
                            registerDB.Name = register.Name;
                            registerDB.AuthorityId = authorityDB.Id;
                            registerDB = this.registersRepository.Insert(registerDB);
                            this.registersRepository.GetDbContext().SaveChanges();
                        }
                        else
                        {
                            registerDB.Code = adapter.Name;
                            registerDB.Name = register.Name;
                        }

                        if (registerDB.Version == null)
                        {
                            UpdateAdapterOperations(register, registerDB, adapter);
                        }
                        else
                        {
                            var registerDBVersion = new Version(registerDB.Version);
                            var registerVersion = new Version(adapter.Version);

                            if (registerDBVersion < registerVersion)
                            {
                                UpdateAdapterOperations(register, registerDB, adapter);
                            }
                            else if (registerDB.Version != null && registerDBVersion > registerVersion)
                            {
                                this.logger.LogWarning($"Adapter with newer version found ! {register.Code}");
                            }
                            else
                            {
                                this.logger.LogDebug("No update needed!");
                            }
                        }
                    }
                }
            }
        }

        private static void UpdateAuthorityProperties(AuthoritiesDto authority, Authorities authorityDB)
        {
            authorityDB.Name = authority.Name;
            authorityDB.Acronym = authority.Acronym;
            authorityDB.Code = authority.Code;
            authorityDB.Oid = authority.OID;
        }

        private void UpdateAdapterOperations(RegisterDto register, Registers registerDB, AdapterDto adapter)
        {
            registerDB.Version = adapter.Version;
            this.registersRepository.Update(registerDB);
            this.registersRepository.GetDbContext().SaveChanges();


            if (adapter.Operations == null)
            {
                return;
            }

            foreach (var operation in adapter.Operations)
            {
                //Unique name => Example:(TechnoLogica.RegiX.AZJobsAdapter.APIService.IAZJobsAPI.GetEmployerFreeJobPositions)
                var operationDB =
                    this.adapterOperationsRepository.SelectByOperationName(
                        adapter.Interface + '.' + operation.FullName);
                //update
                if (operationDB != null)
                {
                    this.logger.LogInformation($"Updating adapter operation {adapter.Interface}.{operation.FullName}");
                    operationDB.DisplayOperationName = operation.Description;
                    operationDB.MetadataXml = operation.MetaDataXML;
                    operationDB.RequestXslt = operation.RequestXslt;
                    operationDB.ResponseXslt = operation.ResponseXslt;


                    this.adapterOperationsRepository.Update(operationDB);
                    this.adapterOperationsRepository.GetDbContext().SaveChanges();
                }
                else
                {
                    this.logger.LogInformation($"Creating adapter operation {adapter.Interface}.{operation.FullName}");
                    operationDB = new AdapterOperations();
                    operationDB.OperationName = adapter.Interface + '.' + operation.FullName;
                    operationDB.DisplayOperationName = operation.Description;
                    operationDB.MetadataXml = operation.MetaDataXML;
                    operationDB.RequestXslt = operation.RequestXslt;
                    operationDB.ResponseXslt = operation.ResponseXslt;
                    operationDB.RegisterId = registerDB.Id;
                    operationDB.IsActive = true;
                    operationDB.Code = operation.FullName;
                    operationDB.Namespace = "-";
                    operationDB.RequestObjectName = "-";
                    operationDB.CreatedOn = DateTime.Now;
                    operationDB.ControllerName = "APIS";
                    this.adapterOperationsRepository.Insert(operationDB);
                    this.adapterOperationsRepository.GetDbContext().SaveChanges();

                }
            }

        }

        private IEnumerable<AuthoritiesDto> GetAllAuthorities()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(REGIX_INFO_URL);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                // HTTP GET
                var response = client.GetAsync(PATH_URL).GetAwaiter().GetResult();
                if (response.IsSuccessStatusCode)
                {
                    var authoritiesDtos = response.Content.ReadAsAsync<IEnumerable<AuthoritiesDto>>().GetAwaiter().GetResult();
                    return authoritiesDtos;
                }
                else
                {
                    this.logger.LogError($"Error code returned shile retrieving authorities: {response.StatusCode}");
                    return new List<AuthoritiesDto>();
                }
            }
        }
    }
}