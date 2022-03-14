using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechnoLogica.RegiX.DataAccess.DataClasses
{
    public class TreeObject
    {
        public int Id { get; set; }
        public int? ParentId { get; set; }
        public string Name { get; set; }
        public string Acronym { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }

        public IList<TreeObject> Children { get; set; }
        public List<TreeObject> PossibleParents { get; set; }

        public TreeObject()
        {
            Children = new List<TreeObject>();
        }
    }
}
