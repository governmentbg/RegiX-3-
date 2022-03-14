using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using TechnoLogica.Common.Settings;

namespace TechnoLogica.API.Common.Settings
{
    public class AppSettings
    {
        [Required]
        public API API { get; set; }
        [Required]
        public Swagger Swagger { get; set; }
        [Required]
        public CORS CORS { get; set; }

        [Required]
        public PascalCaseOutput PascalCaseOutput { get; set; }

        public CertificateSettings SigningCredential { get; set; }

        public NullValueHandling? NullValueHandling { get; set; }

        public Authentication Authentication { get; set; }

        public OAuthSecurity OAuthSecurity { get; set; }

        public int? MaxPageSize { get; set; }

    }

    public class API
    {
        [Required] public string Title { get; set; }

        public string Description { get; set; }
    }

    public class Swagger
    {
        [Required] public bool Enabled { get; set; }
    }

    public class CORS
    {
        [Required] public bool Enabled { get; set; }
        [Required] public string[] Origins { get; set; }
        [Required] public string Method { get; set; }
        [Required] public string Header { get; set; }
    }

    public class PascalCaseOutput
    {
        [Required]
        public bool Enabled { get; set; }
    }
    public class Authentication
    {
        public bool Enabled { get; set; }
        public string TokenIssuer { get; set; }
        public string APIName { get; set; }
        public string APISecret { get; set; }
    }

    public class OAuthSecurity
    {
        [Required] 
        public bool Enabled { get; set; }
        [Required]
        public string AudienceId { get; set; }
        [Required]
        public string Issuer { get; set; }
        [Required]
        public string AudienceSecret { get; set; }
    }
}
