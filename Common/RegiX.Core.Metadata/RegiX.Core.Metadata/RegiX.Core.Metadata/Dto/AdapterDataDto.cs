using System.Collections.Generic;
using RegiX.Core.Metadata.Dto;

namespace RegiX.Core.Metadata.Models
{
    public class AdapterDataDto
    {
        public AdapterDto NotRegisterAdapterInfo { get; set; }

        public ApiServicesDto NotRegisterApiService { get; set; }

        public IEnumerable<ApiServiceAdapterOperationDto> NotRegisterApiServiceAdapterOperations { get; set; }

        //public List<RegisterObjectDto> RegisterObjects { get; set; }
    }
}
