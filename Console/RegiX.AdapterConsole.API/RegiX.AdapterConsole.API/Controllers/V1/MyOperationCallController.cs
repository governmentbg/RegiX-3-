using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Threading.Tasks;
using System.Xml;
using TechnoLogica.API.Common.Controllers;
using TechnoLogica.API.DataContracts;
using TechnoLogica.RegiX.AdapterConsole.API.Controllers.Helpers;
using TechnoLogica.RegiX.AdapterConsole.DataContracts.OperationCalls;
using TechnoLogica.RegiX.AdapterConsole.Infrastructure.Models;
using TechnoLogica.RegiX.AdapterConsole.Services.Contracts;
using TechnoLogica.RegiX.Common.Utils;

namespace TechnoLogica.RegiX.AdapterConsole.API.Controllers.V1
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/my-operation-calls")] //required for default versioning
    [Route("api/v{version:apiVersion}/my-operation-calls")]
    [Authorize]
    public class MyOperationCallController : ABaseGetAllController<MyOperationCallsInDto, MyOperationCallsOutDto,
        OperationCalls, int>
    {
        private readonly IMyOperationCallsService _aBaseService;
        private readonly IAdapterOperationsService _adapterOperationsService;

        public MyOperationCallController(IMyOperationCallsService aBaseService,
            IAdapterOperationsService adapterOperationsService)
            : base(aBaseService)
        {
            _aBaseService = aBaseService;
            _adapterOperationsService = adapterOperationsService;
        }

        public override IActionResult Get(int aId)
        {
            var result = ((IMyOperationCallsService) baseService).Select(aId);
            if (result != null)
            {
                var withParams = new OperationCallsOutDto
                {
                    Id = result.Id,
                    AdapterOperation = result.AdapterOperation,
                    ApiServiceCallId = result.ApiServiceCallId,
                    StartTime = result.StartTime,
                    AssignedTo = result.AssignedTo,
                    RequestParamsValues = XmlToDic.ConvertXmlToDic(result.RequestXML),
                    ResponseParamsValues = XmlToDic.ConvertXmlToDic(result.ResponseXML)
                };
                return Ok(withParams);
            }

            return NotFound();
        }

        [HttpPost("executeRequest")]
        public virtual async Task<IActionResult> ExecuteRequest([FromBody] JObject requestWithMeta)
        {
            SaveToReturnedCalls(requestWithMeta);
            return Ok();
        }

        [HttpPost("updateParameters")]
        public virtual async Task<IActionResult> updateParameters([FromBody] JObject requestWithMeta)
        {
            UpdateOperationCallParameters(requestWithMeta);
            return Ok();
        }

        private void UpdateOperationCallParameters(JObject requestWithMeta)
        {
            RetrieveRequestXML(requestWithMeta, out int opId, out DisplayValue assignedTo, out XmlElement xmlResult);
            _aBaseService.Update(opId, (int)assignedTo.Id, xmlResult.OuterXml);
        }

        private void SaveToReturnedCalls(JObject requestWithMeta)
        {
            RetrieveRequestXML(requestWithMeta, out int opId, out DisplayValue assignedTo, out XmlElement xmlResult);
            _aBaseService.SaveToReturnedCalls(opId, (int)assignedTo.Id, xmlResult.OuterXml);
        }

        private void RetrieveRequestXML(JObject requestWithMeta, out int opId, out DisplayValue assignedTo, out XmlElement xmlResult)
        {
            var opName = requestWithMeta.GetValue("operationCallName").ToString();
            opId = int.Parse(requestWithMeta.GetValue("operationId").ToString());
            var requstData = (JObject)requestWithMeta.GetValue("requestData");

            //TODO: Is startTime changing update assignedName
            var startTime = requstData.GetValue("startTime").ToString();
            var assignedName = requstData.GetValue("assignedToName").ToString();

            assignedTo = JsonConvert.DeserializeObject<DisplayValue>(assignedName);
            requstData.Remove("startTime");
            requstData.Remove("assignedToName");


            var adapterOperationID = _aBaseService.Select(opId).AdapterOperation.Id;
            var adapterOperation = _adapterOperationsService.Select(Convert.ToInt32(adapterOperationID));
            var responseMetadataXML = adapterOperation.MetadataResponseXml;
            xmlResult = Common.Metadata.MetadataUtils.CreateXML(
                    (JObject)requestWithMeta["requestData"],
                    responseMetadataXML.XmlDeserialize<Common.Metadata.AdapterOperations.AdapterOperation>()
                );
        }

    }
}