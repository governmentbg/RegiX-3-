using System;
using System.Collections.Generic;
using Microsoft.AspNet.OData.Query;
using TechnoLogica.API.Services;
using TechnoLogica.RegiX.AdapterConsole.DataContracts.OperationCalls;
using TechnoLogica.RegiX.AdapterConsole.Infrastructure.Models;
using TechnoLogica.RegiX.AdapterConsole.Repositories.Contracts;
using TechnoLogica.RegiX.AdapterConsole.Services.Contracts;

namespace TechnoLogica.RegiX.AdapterConsole.Services.Impl
{
    public class MyOperationCallsService :
        ABaseService<MyOperationCallsInDto, MyOperationCallsOutDto, OperationCalls, int, RegiXAdapterConsoleContext>,
        IMyOperationCallsService
    {
        private readonly IReturnedCallsRepository _returnedCallsRepository;

        public MyOperationCallsService(IMyOperationCallsRepository aBaseRepository,
            IReturnedCallsRepository returnedCallsRepository)
            : base(aBaseRepository)
        {
            _returnedCallsRepository = returnedCallsRepository;
        }

        public override List<MyOperationCallsOutDto> SelectAll(ODataQueryOptions<OperationCalls> aOptions)
        {
            var result = base.SelectAll(aOptions);
            return result;
        }

        public void Update(int aId, int assignedToId, string xmlParams)
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
                if (repoObj == null){
                    throw new Exception("Object with id [" + aId + "] not found!");
                }
                _baseRepository.Delete(aId);

                var obj = new ReturnedCalls
                {
                    AdapterOperationId = repoObj.AdapterOperationId,
                    ApiServiceCallId = repoObj.ApiServiceCallId,
                    StartTime = repoObj.StartTime,
                    Request = repoObj.RequestXML,
                    Response = xmlParams,
                    ReturnedBy = assignedToId
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
            dtoFieldsToEntityFields.Add("adapterOperation.id", "adapterOperation/Id");
            dtoFieldsToEntityFields.Add("adapterOperation.displayName", "adapterOperation/Name");
            dtoFieldsToEntityFields.Add("AssignedTo.id", "AssignedToNavigation/Id");
            dtoFieldsToEntityFields.Add("AssignedTo.displayName", "AssignedToNavigation/Name");
        }

        protected override bool IsChildRecord(int aId, List<string> aParentsList)
        {
            return false;
        }
    }
}