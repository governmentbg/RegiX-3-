using Microsoft.AspNet.OData.Query;
using Microsoft.AspNetCore.Mvc;

namespace TechnoLogica.API.Common.Controllers
{
    public interface IBaseApiController<S, U, V, P>
        where P: struct
    {
        IActionResult GetAll(ODataQueryOptions<V> aQueryOptions);

        IActionResult Get(P aId);

        IActionResult Post(S aInDto);

        IActionResult Put(P aId, S aInDto);

        IActionResult Delete(P aId);
    }
}
