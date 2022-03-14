using System;
using System.Collections.Generic;
using System.Text;

namespace TechnoLogica.RegiX.MFANotariesAdapter.Helpers
{
    public class CallResult
    {
        public int Id { get; set; }
        public string Response { get; set; }
        public string RawRequest { get; set; }
        public string RawResult { get; set; }
        public string CallbackUrl { get; set; }
        public string VerificationCode { get; set; }
        public decimal ApiServiceCallId { get; set; }
    }
}
