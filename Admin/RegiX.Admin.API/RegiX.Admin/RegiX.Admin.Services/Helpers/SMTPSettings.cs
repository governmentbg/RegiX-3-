namespace TechnoLogica.RegiX.Admin.API.RegiXInfo
{
    public class SMTPSettings
    {
        public string SMTPSERVER { get; set; }
        public int SMTPPORT { get; set; }
        public bool SMTPSSL { get; set; }
        public string FROMMAIL { get; set; }
        public string SMTPUSERNAME { get; set; }
        public string SMTPPASSWORD { get; set; }
    }
}