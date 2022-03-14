using Microsoft.AspNet.OData.Query;
using Microsoft.OData.UriParser;
using System.Collections.Generic;

namespace TechnoLogica.API.Services.QueryValidators
{
    public interface IFilterQueryValidator
    {
        /// <summary>
        /// The ValidateSingleValuePropertyAccessNode
        /// </summary>
        /// <param name="propertyAccessNode">The propertyAccessNode<see cref="SingleValuePropertyAccessNode"/></param>
        /// <param name="settings">The settings<see cref="ODataValidationSettings"/></param>
        void ValidateSingleValuePropertyAccessNode(
            SingleValuePropertyAccessNode aPropertyAccessNode,
            ODataValidationSettings aSettings);

        /// <summary>
        /// The GetAllowedProperties
        /// </summary>
        /// <returns>The <see cref="HashSet{T}"/></returns>
        HashSet<string> GetAllowedProperties();
    }
}
