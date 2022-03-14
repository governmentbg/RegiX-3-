using System;
using TechnoLogica.API.DataContracts;

namespace TechnoLogica.RegiX.Admin.API.DataContracts.DTO.ParametersValuesLog
{
    public class ParametersValuesLogOutDto
    {
        public decimal Id { get; set; }
        public string Key { get; set; }

        public string OldValue { get; set; }
        public string NewValue { get; set; }
        public DateTime EditedTime { get; set; }
        public DisplayValue RegisterAdapter { get; set; }
        public DisplayValue User { get; set; }
    }
}