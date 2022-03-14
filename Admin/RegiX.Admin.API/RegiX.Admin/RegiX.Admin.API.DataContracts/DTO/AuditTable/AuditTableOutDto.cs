using System;

namespace TechnoLogica.RegiX.Admin.API.DataContracts.DTO.AuditTable
{
    public class AuditTableOutDto
    {
        public decimal Id { get; set; }
        public decimal? UserId { get; set; }
        public string UserName { get; set; }
        public DateTime AuditDate { get; set; }
        public string Action { get; set; }
        public string TableName { get; set; }
        public decimal TableId { get; set; }
        public string IpAddress { get; set; }
        public string AppName { get; set; }
        public string Description { get; set; }
    }
}