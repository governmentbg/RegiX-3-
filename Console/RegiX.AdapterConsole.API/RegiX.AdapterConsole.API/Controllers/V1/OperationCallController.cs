using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Threading.Tasks;
using TechnoLogica.API.Common.Controllers;
using TechnoLogica.API.DataContracts;
using TechnoLogica.RegiX.AdapterConsole.API.Controllers.Helpers;
using TechnoLogica.RegiX.AdapterConsole.DataContracts.OperationCalls;
using TechnoLogica.RegiX.AdapterConsole.Infrastructure.Models;
using TechnoLogica.RegiX.AdapterConsole.Repositories;
using TechnoLogica.RegiX.AdapterConsole.Services.Contracts;
using TechnoLogica.RegiX.Common.Utils;

namespace TechnoLogica.RegiX.AdapterConsole.API.Controllers.V1
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/operation-calls")] //required for default versioning
    [Route("api/v{version:apiVersion}/operation-calls")]
    [Authorize]
    public class
        OperationCallController : ABaseGetAllController<OperationCallsInDto, OperationCallsOutDto, OperationCalls, int>
    {
        private readonly IOperationCallsService _aBaseService;
        private readonly IAdapterOperationsService _adapterOperationsService;
        private readonly IUserContext _userContext;

        public OperationCallController(
            IOperationCallsService aBaseService,
            IAdapterOperationsService adapterOperationsService, 
            IUserContext userContext)
            : base(aBaseService)
        {
            _aBaseService = aBaseService;
            _adapterOperationsService = adapterOperationsService;
            _userContext = userContext;
        }

        public override IActionResult Get(int aId)
        {
            var result = ((IOperationCallsService) baseService).Select(aId);
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

        [HttpPost("updateAssignedTo")]
        public virtual async Task<IActionResult> updateAssignedTo([FromBody] JObject requestWithMeta)
        {
            updateAssignedToId(requestWithMeta);
            return Ok();
        }

        private void updateAssignedToId(JObject requestWithMeta)
        {
            var opName = requestWithMeta.GetValue("operationCallName").ToString();
            var opId = int.Parse(requestWithMeta.GetValue("operationId").ToString());
            int? assignedToId = null;
            try
            {
                var id = requestWithMeta.GetValue("assignedToId");
                assignedToId = int.Parse(id.ToString());
            }
            catch (Exception e)
            {
            }

            _aBaseService.Update(opId, assignedToId);
        }

        private void UpdateOperationCallParameters(JObject requestWithMeta)
        {
            var opName = requestWithMeta.GetValue("operationCallName").ToString();
            var opId = int.Parse(requestWithMeta.GetValue("operationId").ToString());
            var requstData = (JObject)requestWithMeta.GetValue("requestData");

            //TODO: Is startTime changing update assignedName
            var startTime = requstData.GetValue("startTime").ToString();
            var assignedName = requstData.GetValue("assignedToName").ToString();

            var assignedTo = JsonConvert.DeserializeObject<DisplayValue>(assignedName);
            requstData.Remove("startTime");
            requstData.Remove("assignedToName");

            var adapterOperationID = _aBaseService.Select(opId).AdapterOperation.Id;
            var adapterOperation = _adapterOperationsService.Select(Convert.ToInt32(adapterOperationID));
            var responseMetadataXML = adapterOperation.MetadataResponseXml;
            var xmlResult =
                Common.Metadata.MetadataUtils.CreateXML(
                    (JObject)requestWithMeta["requestData"],
                    responseMetadataXML.XmlDeserialize<Common.Metadata.AdapterOperations.AdapterOperation>()
                );

            _aBaseService.Update(opId, assignedTo != null ? (int?)assignedTo.Id : null, xmlResult.OuterXml);
        }

        private void SaveToReturnedCalls(JObject requestWithMeta)
        {
            var opName = requestWithMeta.GetValue("operationCallName").ToString();
            var opId = int.Parse(requestWithMeta.GetValue("operationId").ToString());
            var requstData = (JObject)requestWithMeta.GetValue("requestData");

            //TODO: Is startTime changing, update assignedName
            var startTime = requstData.GetValue("startTime").ToString();
            var assignedName = requstData.GetValue("assignedToName").ToString();

            DisplayValue assignedTo = new DisplayValue();
            if (string.IsNullOrEmpty(assignedName))
            {
                assignedTo.Id = _userContext.UserId.Value;
            }
            else
            {
                assignedTo = JsonConvert.DeserializeObject<DisplayValue>(assignedName);
            }

            requstData.Remove("startTime");
            requstData.Remove("assignedToName");

            var adapterOperationID = _aBaseService.Select(opId).AdapterOperation.Id;
            var adapterOperation = _adapterOperationsService.Select(Convert.ToInt32(adapterOperationID));
            var responseMetadataXML = adapterOperation.MetadataResponseXml;
            var xmlResult =
                Common.Metadata.MetadataUtils.CreateXML(
                    (JObject)requestWithMeta["requestData"],
                    responseMetadataXML.XmlDeserialize<Common.Metadata.AdapterOperations.AdapterOperation>()
                );

            //TODO:turn the parameters into xml and update them
            // Need to add xmlns and xml version ?
            _aBaseService.SaveToReturnedCalls(opId, (int)assignedTo.Id, xmlResult.OuterXml);
        }
    }
}