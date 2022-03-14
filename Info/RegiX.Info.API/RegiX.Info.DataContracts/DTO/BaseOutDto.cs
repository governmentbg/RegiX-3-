using System;

namespace RegiX.Info.DataContracts.DTO
{
    public class BaseOutDto
    {
        public decimal Id { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public string UpdatedBy { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}