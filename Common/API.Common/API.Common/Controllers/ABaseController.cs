using Microsoft.AspNet.OData.Query;
using Microsoft.AspNetCore.Mvc;
using TechnoLogica.API.Services;

namespace TechnoLogica.API.Common.Controllers
{
#pragma warning disable CS0114
    public abstract class ABaseController<S, U, V, P> : ABaseProtectiveController<S, U, V, P>, IBaseApiController<S, U, V, P>
        where P : struct
    {
        protected ABaseController(IBaseService<S, U, V, P> aBaseService) : base(aBaseService)
        {
        }

        [HttpGet("")]
        public virtual IActionResult GetAll(ODataQueryOptions<V> aQueryOptions)
        {
            return base.GetAll(aQueryOptions);
        }

        [HttpGet("{aId}")]
        public virtual IActionResult Get(P aId)
        {
            return base.Get(aId);
        }

        [HttpPost("")]
        public virtual IActionResult Post([FromBody] S aInDto)
        {
            return base.Post(aInDto);
        }

        [HttpPut("{aId}")]
        public virtual IActionResult Put(P aId, [FromBody] S aInDto)
        {
            return base.Put(aId, aInDto);
        }

        [HttpDelete("{aId}")]
        public virtual IActionResult Delete(P aId)
        {
            return base.Delete(aId);
        }
    }
}
