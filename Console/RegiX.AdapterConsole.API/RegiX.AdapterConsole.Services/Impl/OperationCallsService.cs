using System;
using System.Collections.Generic;
using Microsoft.AspNet.OData.Query;
using TechnoLogica.API.Services;
using TechnoLogica.RegiX.AdapterConsole.DataContracts.OperationCalls;
using TechnoLogica.RegiX.AdapterConsole.Infrastructure.Models;
using TechnoLogica.RegiX.AdapterConsole.Repositories.Contracts;
using TechnoLogica.RegiX.AdapterConsole.Services.Contracts;
using TechnoLogica.RegiX.AdapterConsole.Services.QueryValidators;

namespace TechnoLogica.RegiX.AdapterConsole.Services.Impl
{
    public class OperationCallsService :
        ABaseService<OperationCallsInDto, OperationCallsOutDto, OperationCalls, int, RegiXAdapterConsoleContext>,
        IOperationCallsService
    {
        private readonly IOperationCallsRepository _aBaseRepository;
        private readonly IReturnedCallsRepository _returnedCallsRepository;

        public OperationCallsService(IOperationCallsRepository aBaseRepository,
            IReturnedCallsRepository returnedCallsRepository)
            : base(aBaseRepository, new OperationCallsQueryValidator())
        {
            _aBaseRepository = aBaseRepository;
            _returnedCallsRepository = returnedCallsRepository;
        }

        public override List<OperationCallsOutDto> SelectAll(ODataQueryOptions<OperationCalls> aOptions)
        {
            var result = base.SelectAll(aOptions);
            return result;
        }

        public void Update(int aId, int? assignedToId)
        {
            try
            {
                var repoObj = _aBaseRepository.Select(aId);
                if (repoObj == null) throw new Exception("Object with id [" + aId + "] not found!");
                repoObj.AssignedTo = assignedToId;
                var resultObj = _baseRepository.Update(repoObj);
                _baseRepository.GetDbContext().SaveChanges();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void Update(int aId, int? assignedToId, string xmlParams)
        {
            try
            {
                var repoObj = _baseRepository.Select(aId);
                if (repoObj == null) throw new Exception("Object with id [" + aId + "] not found!");
                repoObj.ResponseXML = xmlParams;
                repoObj.AssignedTo = assignedToId;
                var resultObj = _baseRepository.Update(repoObj);
                _baseRepository.GetDbContext().SaveChanges();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void SaveToReturnedCalls(int aId, int assignedToId, string xmlParams)
        {
            try
            {
                //get operation call
                var repoObj = _baseRepository.Select(aId);
                if (repoObj == null) throw new Exception("Object with id [" + aId + "] not found!");

                _baseRepository.Delete(aId);

                //update 
                repoObj.ResponseXML = xmlParams;
                repoObj.AssignedTo = assignedToId;

                var obj = new ReturnedCalls
                {
                    AdapterOperationId = repoObj.AdapterOperationId,
                    AdapterOperation = repoObj.AdapterOperation,
                    ApiServiceCallId = repoObj.ApiServiceCallId,
                    StartTime = repoObj.StartTime,
                    Request = repoObj.RequestXML,
                    Response = repoObj.ResponseXML,
                    ReturnedBy = (int) repoObj.AssignedTo,
                    ReturnedByNavigation = repoObj.AssignedToNavigation
                };

                _returnedCallsRepository.Insert(obj);
                _returnedCallsRepository.GetDbContext().SaveChanges();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        ///   The PopulateDtoToEntityFieldsMapping
        /// </summary>
        protected override void PopulateDtoToEntityFieldsMapping()
        {
            dtoFieldsToEntityFields.Add("adapterOperation.id", "AdapterOperation/Id");
            dtoFieldsToEntityFields.Add("adapterOperation.displayName", "AdapterOperation/Description");
            dtoFieldsToEntityFields.Add("assignedTo.id", "AssignedToNavigation/Id");
            dtoFieldsToEntityFields.Add("assignedTo.displayName", "AssignedToNavigation/Name");
        }

        protected override bool IsChildRecord(int aId, List<string> aParentsList)
        {
            return false;
        }
    }
}