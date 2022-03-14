using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Data;
using TechnoLogica.RegiX.Adapters.Common.DataContracts;
using TechnoLogica.RegiX.Common;
using TechnoLogica.RegiX.Common.DataContracts;
using TechnoLogica.RegiX.Common.ObjectMapping;
using TechnoLogica.RegiX.Common.Utils;
using TechnoLogica.RegiX.OracleAdapterService;
using TechnoLogica.RegiX.Common.DataContracts.Parameter;
using TechnoLogica.RegiX.Adapters.Common.ObjectMapping;
using TechnoLogica.RegiX.Adapters.Common.ExportExtension;

namespace TechnoLogica.RegiX.ASPFosterParentsAdapter.AdapterService
{
    [Export(typeof(IAdapterService))]
    [ExportFullName(typeof(ASPFosterParentsAdapter), typeof(IAdapterService))]
    [ExportSimpleName(typeof(ASPFosterParentsAdapter), typeof(IAdapterService))]
    public class ASPFosterParentsAdapter : OracleBaseAdapterService, IASPFosterParentsAdapter
    {
        [Export(typeof(ParameterInfo))]
        [ExportFullName(typeof(ASPFosterParentsAdapter), typeof(ParameterInfo))]
        public static ParameterInfo<string> ConnectionString =
            new ParameterInfo<string>(@"Data Source=IP:PORT/PATH;User ID=;Password=;")
            {
                Key = Constants.ConnectionStringParameterKeyName,
                Description = "Connection string",
                OwnerAssembly = typeof(ASPFosterParentsAdapter).Assembly
            };

        [Export(typeof(ParameterInfo))]
        [ExportFullName(typeof(ASPFosterParentsAdapter), typeof(ParameterInfo))]
        public static ParameterInfo<string> SendRequestForFosterParentsProcedureName =
            new ParameterInfo<string>("regix_foster_parents.send_and_save_request")
            {
                Key = "SendRequestForFosterParentsProcedureName",
                Description = "the procedure which is called by SendRequestForFosterParents()",
                OwnerAssembly = typeof(ASPFosterParentsAdapter).Assembly
            };

        public CommonSignedResponse<AspFosterParentsRequest, AspFosterParentsResponse> SendRequestForFosterParents(AspFosterParentsRequest argument, AccessMatrix accessMatrix, AdapterAdditionalParameters additionalParameters)
        {
            Guid id = Guid.NewGuid();
            LogData(additionalParameters, new { Request = argument.Header.XmlSerialize(), Guid = id });
            try
            {
                // Init objects
                ObjectMapper<AspFosterParentsResponse, AspFosterParentsResponse> mapper = CreateSelfMapper(accessMatrix);
                AspFosterParentsResponse result = new AspFosterParentsResponse();
                AspFosterParentsResponse beforeMapResult = new AspFosterParentsResponse();

                string errors = this.ValidateRequest(argument);
                if (!string.IsNullOrEmpty(errors))
                {
                    beforeMapResult.Error = errors;
                    mapper.Map(beforeMapResult, result);

                    return SigningUtils.CreateAndSign(
                        argument,
                        result,
                        accessMatrix,
                        additionalParameters
                    );
                }


                OracleConnection connection = new OracleConnection(ConnectionString.Value);
                
                OracleCommand command = new OracleCommand();
                command.Connection = connection;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = SendRequestForFosterParentsProcedureName.Value;

                string userText = this.CreateUserText(additionalParameters);

                // Bind in parameters
                command.Parameters.Add(new OracleParameter("p_header_req_from", OracleDbType.Date, argument.Header.StartDate, ParameterDirection.Input));
                command.Parameters.Add(new OracleParameter("p_header_req_to", OracleDbType.Date, argument.Header.EndDate, ParameterDirection.Input));
                command.Parameters.Add(new OracleParameter("p_header_req_rows", OracleDbType.Int32, argument.Header.RequestSize, ParameterDirection.Input));
                command.Parameters.Add(new OracleParameter("p_header_req_project", OracleDbType.Varchar2, argument.Header.IsunCode, ParameterDirection.Input));
                command.Parameters.Add(new OracleParameter("p_header_req_user", OracleDbType.Varchar2, userText, ParameterDirection.Input));
                command.Parameters.Add(new OracleParameter("p_data_req", OracleDbType.Clob, argument.Data.XmlSerialize(), ParameterDirection.Input));

                // Bind out parameters
                var requestIdParameter = new OracleParameter();
                requestIdParameter.ParameterName = "v_req_id";
                requestIdParameter.OracleDbType = OracleDbType.Int32;
                requestIdParameter.Direction = ParameterDirection.Output;
                command.Parameters.Add(requestIdParameter);

                var requestNoParameter = new OracleParameter();
                requestNoParameter.ParameterName = "v_req_no";
                requestNoParameter.OracleDbType = OracleDbType.Int32;
                requestNoParameter.Direction = ParameterDirection.Output;
                command.Parameters.Add(requestNoParameter);

                OracleDataAdapter resultDataSet = new OracleDataAdapter(command);
                
                try
                {
                    connection.Open();
                    DataSet ds = new DataSet();

                    // Execute stored procedure
                    // In this case ds should be empty
                    resultDataSet.Fill(ds); 

                    // Get data from out parameter
                    beforeMapResult.RequestNumber = int.Parse(requestNoParameter.Value.ToString());
                }
                catch (Exception ex)
                {
                    LogError(additionalParameters, ex, new { Guid = id });
                    beforeMapResult.Error = ex.Message;
                }
                finally
                {
                    connection.Close();
                }

                mapper.Map(beforeMapResult, result);
                argument.Data = null;
                return
                    SigningUtils.CreateAndSign(
                        argument,
                        result,
                        accessMatrix,
                        additionalParameters
                    );
            }
            catch (Exception ex)
            {
                LogError(additionalParameters, ex, new { Guid = id });
                throw ex;
            }
        }

        private static ObjectMapper<AspFosterParentsResponse, AspFosterParentsResponse> CreateSelfMapper(AccessMatrix accessMatrix)
        {
            ObjectMapper<AspFosterParentsResponse, AspFosterParentsResponse> mapper = new ObjectMapper<AspFosterParentsResponse, AspFosterParentsResponse>(accessMatrix);

            mapper.AddObjectMap((o) => o, (c) => c);
            mapper.AddPropertyMap((o) => o.RequestNumber, (c) => c.RequestNumber);
            mapper.AddPropertyMap((o) => o.Error, (c) => c.Error);

            return mapper;
        }

        private string ValidateRequest(AspFosterParentsRequest argument)
        {
            if (argument.Header.StartDate >= argument.Header.EndDate)
            {
                return "'Start date' should be before 'End date'";
            }

            if (argument.Data.DataItem == null || argument.Data.DataItem.Count == 0)
            {
                return "The array of data cannot be null or empty";
            }

            List<string> errors = new List<string>();
            foreach (var item in argument.Data.DataItem)
            {
                if (string.IsNullOrEmpty(item.IdentificatorChild) && string.IsNullOrEmpty(item.IdentificatorParent))
                {
                    string message = string.Format("The parent and child identifier cannot be both empty! Row: {0}", item.Row);
                    errors.Add(message);
                }

                if (item.IdentificatorParent != null && item.IdentificatorParent.Length != 10)
                {
                    string message = string.Format("The parent identifier '{0}' should be 10 symbols long", item.IdentificatorParent);
                    errors.Add(message);
                }

                if (item.IdentificatorChild != null && item.IdentificatorChild.Length != 10)
                {
                    string message = string.Format("The child identifier '{0}' should be 10 symbols long", item.IdentificatorChild);
                    errors.Add(message);
                }
            }

            return string.Join(Environment.NewLine, errors);
        }

        private string CreateUserText(AdapterAdditionalParameters additionalParameters)
        {
            string userValue = null;
            if (additionalParameters != null && additionalParameters.CallContext != null)
            {
                string identifier = additionalParameters.CallContext.EmployeeIdentifier;
                string names = additionalParameters.CallContext.EmployeeNames;
                userValue = string.Format("{0}-{1}", identifier, names);
            }

            return userValue;
        }
    }
}