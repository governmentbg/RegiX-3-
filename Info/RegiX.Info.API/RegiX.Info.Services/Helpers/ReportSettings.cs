namespace RegiX.Info.Services.Helpers
{
    public class ReportSettings
    {
        public ActiveDirectoryCredentials ActiveDirectoryCredentials { get; set; }
        public string Endpoint { get; set; }
    }

    public class ActiveDirectoryCredentials
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Domain { get; set; }
    }
}