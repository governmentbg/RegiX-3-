using System.Collections.Generic;
using TechnoLogica.API.Repositories.Contracts;
using TechnoLogica.API.Services;
using TechnoLogica.RegiX.Client.API.DataContracts.DTO.AdapterOperations;
using TechnoLogica.RegiX.Client.API.DataContracts.DTO.AuditExceptions;
using TechnoLogica.RegiX.Client.Infrastructure.Models;
using TechnoLogica.RegiX.Client.Repositories.Contracts;
using TechnoLogica.RegiX.Client.Services.Contracts;

using System.Linq;
using System;

namespace TechnoLogica.RegiX.Client.Services.Services
{
    public class AsyncReportExecutionsService :
        ABaseService<AsyncReportExecutionsInDto, AsyncReportExecutionsOutDto, AsyncReportExecutions, int,RegiXClientContext> ,
        IAsyncReportExecutionsService
    {
        public AsyncReportExecutionsService(IAsyncReportExecutionsRepository aBaseRepository) 
            : base(aBaseRepository)
        {
        }

        protected override void PopulateDtoToEntityFieldsMapping()
        {
        }

        protected override bool IsChildRecord(int aId, List<string> aParentsList)
        {
            return false;
        }

        public AsyncReportExecutionsOutDto UpdateRequest(decimal apiServiceCallId, string verificationCode, string data)
        {
            var asyncRequest =
                (this._baseRepository as IAsyncReportExecutionsRepository)
                    .FindByServiceCallId(apiServiceCallId, verificationCode);
            asyncRequest.Result = data;
            asyncRequest.ReceivedOn = DateTime.Now;
            var updated = this._baseRepository.Update(asyncRequest);
            this._baseRepository.GetDbContext().SaveChanges();
            return MappingTools.MapTo<AsyncReportExecutions, AsyncReportExecutionsOutDto>(updated);
        }
    }
}