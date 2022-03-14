using Microsoft.AspNet.OData.Query;
using System.Collections.Generic;
using TechnoLogica.API.DataContracts;

namespace TechnoLogica.API.Services
{
    public interface IBaseService<S, U, V, P>
    {
        List<U> SelectAll(ODataQueryOptions<V> aOptions);

        CustomPageResult<U> SelectAllWithPagination(ODataQueryOptions<V> aOptions);

        U Select(P aId);

        U Insert(S aInDto);

        U Update(P aId, S aInDto);

        U Delete(P aId);
    }
}
