using TechnoLogica.API.Services;
using Microsoft.AspNet.OData.Query;
using Microsoft.AspNetCore.Mvc;

namespace TechnoLogica.API.Common.Controllers
{
    /// <summary>
    /// Defines the <see cref="ABaseGetAllController{S, U, V, P}" />
    /// </summary>
    /// <typeparam name="S"></typeparam>
    /// <typeparam name="U"></typeparam>
    /// <typeparam name="V"></typeparam>
    /// <typeparam name="P"></typeparam>
    public abstract class ABaseGetAllController<S, U, V, P> : ABaseController<S, U, V, P>
        where P: struct
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ABaseGetAllController{S, U, V}"/> class.
        /// </summary>
        /// <param name="aBaseService">The aBaseService<see cref="IBaseService{S, U, V}"/></param>
        protected ABaseGetAllController(IBaseService<S, U, V, P> aBaseService) : base(aBaseService)
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns>The IActionResult</returns>
        [HttpGet("getAll")]
        public virtual IActionResult GetAllNoWrap(ODataQueryOptions<V> aOptions)
        {
            var result = this.baseService.SelectAll(aOptions);
            return Ok(result);
        }
    }
}
