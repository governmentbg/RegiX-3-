using Microsoft.AspNet.OData.Query;
using Microsoft.AspNetCore.Mvc;
using System;
using TechnoLogica.API.Services;

namespace TechnoLogica.API.Common.Controllers
{
    public abstract class ABaseProtectiveController<S, U, V, P> : ControllerBase
        where P : struct
    {
        protected IBaseService<S, U, V, P> baseService;

        protected ABaseProtectiveController(IBaseService<S, U, V, P> aBaseService)
        {
            this.baseService = aBaseService;
        }

        protected virtual IActionResult GetAll(ODataQueryOptions<V> aQueryOptions)
        {
            var result = this.baseService.SelectAllWithPagination(aQueryOptions);
            return Ok(result);
        }

        protected virtual IActionResult Get(P aId)
        {
            var result = this.baseService.Select(aId);
            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        protected virtual IActionResult Post([FromBody] S aInDto)
        {
            try
            {
                U value = this.baseService.Insert(aInDto);
                return Ok(value);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        protected virtual IActionResult Put(P aId, [FromBody] S aInDto)
        {
            try
            {
                U value = this.baseService.Update(aId, aInDto);
                return Ok(value);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        protected virtual IActionResult Delete(P aId)
        {
            try
            {
                U value = this.baseService.Delete(aId);
                return Ok(value);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
