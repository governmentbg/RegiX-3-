using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading;

namespace TechnoLogica.RegiX.DataAccess
{
    public partial class RegiXContext
    {
        //public RegiXContext(bool stupid_val)
            
        //{
        //  (new RegiXContext()).AfterConstructorSetContextInfo();
        //}
        private bool _disposed = false;
        public string UserName { get; set; }
        protected override void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _disposed = true;
                    if (this.Database.Connection != null && this.Database.Connection.State == System.Data.ConnectionState.Open)
                    {
                        this.Database.Connection.Close();
                    }
                }
            }
            base.Dispose(disposing);
        }
        
        public void AfterConstructorSetContextInfo()
        {

            //UserId = (from c in (Thread.CurrentPrincipal as ClaimsPrincipal).Claims
            //          where c.Type == Constants.UserIdClaimType
            //          select Convert.ToInt32(c.Value)).FirstOrDefault();
            //if (UserId == 0)
            //{
            //    var administration = this.WEB_ADM_INFORMATIONS.FirstOrDefault();
            //    if (administration != null)
            //    {
            //        UserId = administration.USER_ID;
            //    }
            //}
            UserName = Thread.CurrentPrincipal.Identity.Name;
            if (!String.IsNullOrEmpty(UserName))
            {
                this.Database.Connection.StateChange += Connection_StateChange;
            }
          //  return this;

        }

        private void Connection_StateChange(object sender, StateChangeEventArgs e)
        {
            // only do this when we first open the connection
            if (//e.OriginalState == ConnectionState.Open ||
                e.CurrentState != ConnectionState.Open)
                return;

            // use the existing opened connection to set the context info
            var connection = (DbConnection)sender;
            SetContext(connection);

        }

        private void SetContext(DbConnection connection)
        {
            var command = connection.CreateCommand();

            command.CommandText = "SET_CONTEXT_INFO";
            command.CommandType = CommandType.StoredProcedure;

            var userParam = command.CreateParameter();
            userParam.DbType = DbType.String;
            userParam.Direction = ParameterDirection.Input;
            userParam.ParameterName = "P_USER_NAME";
            userParam.Value = UserName;
            command.Parameters.Add(userParam);

            command.ExecuteNonQuery();
        }

    }
}
