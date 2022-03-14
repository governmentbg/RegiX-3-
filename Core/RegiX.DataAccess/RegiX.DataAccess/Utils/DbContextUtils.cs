using System.Configuration;

namespace TechnoLogica.RegiX.DataAccess.Utils
{
    public static class DbContextUtils
    {
        private static string _connectionString = ConfigurationManager.ConnectionStrings["RegiXContext"].ConnectionString;

        public static RegiXContext GetDbContext()
        {
           // EntityConnection connection = new EntityConnection(_connectionString);
            RegiXContext context = new RegiXContext();
            context.AfterConstructorSetContextInfo();          
          
            context.Database.Connection.Open();
            //context.SetContextUser(username);
            return context;
        }
    }
}
