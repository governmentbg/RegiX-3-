using Microsoft.AspNet.OData.Query;
using Microsoft.AspNet.OData.Query.Validators;
using Microsoft.OData;
using Microsoft.OData.UriParser;
using System.Collections.Generic;

namespace TechnoLogica.API.Services.QueryValidators
{
    public abstract class AFilterByPropertyQueryValidator : FilterQueryValidator, IFilterQueryValidator
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AFilterByPropertyQueryValidator"/> class.
        /// </summary>
        public AFilterByPropertyQueryValidator() : base(new DefaultQuerySettings())
        {
        }

        /// <summary>
        /// The ValidateSingleValuePropertyAccessNode
        /// </summary>
        /// <param name="aPropertyAccessNode">The propertyAccessNode<see cref="SingleValuePropertyAccessNode"/></param>
        /// <param name="aSettings">The settings<see cref="ODataValidationSettings"/></param>
        public override void ValidateSingleValuePropertyAccessNode(
            SingleValuePropertyAccessNode aPropertyAccessNode,
            ODataValidationSettings aSettings)
        {

            string propertyName = null;
            if (aPropertyAccessNode != null)
            {

                if (aPropertyAccessNode.Source.GetType() == typeof(SingleNavigationNode))
                {
                    var source = ((SingleNavigationNode)aPropertyAccessNode.Source);
                    string navigationPropertyName = "";
                    int count = 0;
                    foreach (var segment in source.NavigationSource.Path.PathSegments)
                    {
                        if (count > 0)
                        {
                            navigationPropertyName += (segment + '/');
                        }

                        count++;
                    }

                    propertyName = navigationPropertyName + aPropertyAccessNode.Property.Name;
                }
                else
                {
                    propertyName = aPropertyAccessNode.Property.Name;
                }
            }

            HashSet<string> allowedProps = this.GetAllowedProperties();
            if (propertyName != null && !allowedProps.Contains(propertyName))
            {
                string allowedPropsAsStr = string.Join(", ", allowedProps);
                throw new ODataException(
                    string.Format("Filter on {0} is not allowed. Allowed columns: {1}", propertyName, allowedPropsAsStr));
            }
        }

        /// <summary>
        /// The GetAllowedProperties
        /// </summary>
        /// <returns>The <see cref="HashSet{T}"/></returns>
        public abstract HashSet<string> GetAllowedProperties();
    }
}
