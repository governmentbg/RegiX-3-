using System;
using System.ComponentModel.Composition;
using Microsoft.AspNetCore.Mvc;
using RegiX.Info.API.Services;

namespace RegiX.Info.API.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/download-info")]
    [Route("api/v{version:apiVersion}/download-info")]
    [ApiController]
    public class DownloadAdaptersInfoController : ControllerBase
    {
        //private const string CONTENT_DISPOSITION_HEADER = "attachment";

        private readonly DownloadAdaptersInfoService downloadService;

        public DownloadAdaptersInfoController(DownloadAdaptersInfoService downloadAdaptersInfoService)
        {
            downloadService = downloadAdaptersInfoService;
        }

        [HttpGet("adapters/samples/{id}")]
        public IActionResult DownloadSamplesByAdapterName(string id)
        {
            try
            {
                var result = downloadService.DownloadSamplesByAdapterName(id);
                Response.Headers.Add("Content-Disposition", "attachment; filename=SamplesByAdapter.zip");
                return File(result, "application/zip");
            }
            catch (ImportCardinalityMismatchException e)
            {
                return NotFound();
            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }

        [Route("adapters/xsd/{id}")]
        [HttpGet]
        public IActionResult DownloadXSDByAdapterName(string id)
        {
            try
            {
                var result = downloadService.DownloadXSDByAdapterName(id);
                Response.Headers.Add("Content-Disposition", "attachment; filename=XSDsByAdapter.zip");
                return File(result, "application/zip");
            }
            catch (ImportCardinalityMismatchException e)
            {
                return NotFound();
            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }

        [Route("operations/samples/{id}")]
        [HttpGet]
        public IActionResult DownloadSamplesByOperationName(string id)
        {
            try
            {
                var result = downloadService.DownloadSamplesByOperationName(id);
                Response.Headers.Add("Content-Disposition", "attachment; filename=SamplesByOperation.zip");
                return File(result, "application/zip");
            }
            catch (Exception e) when (e is ImportCardinalityMismatchException || e is ArgumentOutOfRangeException)
            {
                return NotFound();
            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }

        [Route("operations/xsd/{id}")]
        [HttpGet]
        public IActionResult DownloadXSDByOperationName(string id)
        {
            try
            {
                var result = downloadService.DownloadXSDByOperationName(id);
                Response.Headers.Add("Content-Disposition", "attachment; filename=XSDsByOperation.zip");
                return File(result, "application/zip");
            }
            catch (Exception e) when (e is ImportCardinalityMismatchException || e is ArgumentOutOfRangeException)
            {
                return NotFound();
            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }
    }
}