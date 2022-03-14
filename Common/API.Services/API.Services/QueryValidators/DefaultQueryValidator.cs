using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace TechnoLogica.API.Services.QueryValidators
{
    /// <summary>
    /// Default query validator allowing all properties
    /// </summary>
    /// <typeparam name="V">Filter object</typeparam>
    public class DefaultQueryValidator<V> : AFilterByPropertyQueryValidator
    {
        /// <summary>
        /// Gets the allowed properties
        /// </summary>
        /// <returns>Allowed properties</returns>
        public override HashSet<string> GetAllowedProperties()
        {
            var allProperties = typeof(V).GetProperties().Select(v => v.Name).ToList();
            return new HashSet<string>(allProperties);
        }
    }
}
