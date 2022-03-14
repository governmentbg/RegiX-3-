using System;
using System.Collections.Generic;
using System.Text;

namespace TechnoLogica.API.DataContracts
{
    public class CustomPageResult<T>
    {
        public int Total { get; set; }

        public int PerPage { get; set; }

        public int CurrentPage { get; set; }

        public int LastPage { get; set; }

        public IEnumerable<T> Data { get; set; }
    }
}
