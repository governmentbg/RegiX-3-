using System;
using TechnoLogica.RegiX.Common;
using TechnoLogica.RegiX.Common.ObjectMapping;
using TechnoLogica.RegiX.Common.Utils;
using System.Data;
using System.ComponentModel.Composition;
using System.Data.SqlClient;
using TechnoLogica.RegiX.Common.DataContracts;
using TechnoLogica.RegiX.Adapters.Common.DataContracts;
using TechnoLogica.RegiX.Common.DataContracts.Parameter;
using TechnoLogica.RegiX.Adapters.Common.ObjectMapping;
using TechnoLogica.RegiX.Adapters.Common.ExportExtension;

namespace TechnoLogica.RegiX.GitExplosivesAdapter.AdapterService
{
    [Export(typeof(IAdapterService))]
    [ExportFullName(typeof(GitExplosivesAdapter), typeof(IAdapterService))]
    [ExportSimpleName(typeof(GitExplosivesAdapter), typeof(IAdapterService))]
    public class GitExplosivesAdapter : SQLServerAdapterService.SQLServerAdapterService, IGitExplosivesAdapter, IAdapterService
    {
        //public GitExplosivesAdapter()
        //{
        //    ConnectionString =
        //        new ParameterInfo<string>(@"data source=;initial catalog=regix2MockDb;user id=;password=;")
        //        {
        //            Key = "ConnectionString",
        //            Description = "Connection string",
        //            OwnerAssembly = typeof(GitExplosivesAdapter).Assembly
        //        };
        //}

        [Export(typeof(ParameterInfo))]
        [ExportFullName(typeof(GitExplosivesAdapter), typeof(ParameterInfo))]
        public static ParameterInfo<string> ConnectionString =
            new ParameterInfo<string>(@"data source=;initial catalog=regix2MockDb;user id=;password=;")
            {
                Key = Constants.ConnectionStringParameterKeyName,
                Description = "Connection string",
                OwnerAssembly = typeof(GitExplosivesAdapter).Assembly
            };
        
        [Export(typeof(ParameterInfo))]
        [ExportFullName(typeof(GitExplosivesAdapter), typeof(ParameterInfo))]
        public static ParameterInfo<string> ProcedureName =
            new ParameterInfo<string>("regix.usp_EMLicenses")
            {
                Key = "ProcedureName",
                Description = "The name of the procedure",
                OwnerAssembly = typeof(GitExplosivesAdapter).Assembly
            };

        public CommonSignedResponse<AuthenticityExplosivesRequestType, ValidExplosivesCertificateResponse> GetAuthenticityExplosivesCertificate(AuthenticityExplosivesRequestType argument, AccessMatrix accessMatrix, AdapterAdditionalParameters aditionalParameters)
        {
            Guid id = Guid.NewGuid();
            LogData(aditionalParameters, new { Request = argument.Serialize(), Guid = id });
            try
            {
                var result = GetData(accessMatrix, argument.Identifier, argument.CertificateNumber);
                return
                    SigningUtils.CreateAndSign(
                        argument,
                        result,
                        accessMatrix,
                        aditionalParameters
                    );
            }
            catch (Exception ex)
            {
                LogError(aditionalParameters, ex, new { Guid = id });
                throw ex;
            }
        }

        public CommonSignedResponse<ValidExplosivesRequestType, ValidExplosivesCertificateResponse> GetValidExplosivesCertificate(ValidExplosivesRequestType argument, AccessMatrix accessMatrix, AdapterAdditionalParameters aditionalParameters)
        {
            Guid id = Guid.NewGuid();
            LogData(aditionalParameters, new { Request = argument.Serialize(), Guid = id });
            try
            {
                var result = GetData(accessMatrix, argument.Identifier, ""); 
                return
                     SigningUtils.CreateAndSign(
                         argument,
                         result,
                         accessMatrix,
                         aditionalParameters
                     );

            }
            catch (Exception ex)
            {
                LogError(aditionalParameters, ex, new { Guid = id });
                throw ex;
            }
        }

        private ValidExplosivesCertificateResponse GetData(AccessMatrix accessMatrix, string id, string certID)
        {

            SqlConnection connection = new SqlConnection(ConnectionString.Value);
            DataSet ds = new DataSet();

            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandType = CommandType.Text;
            command.CommandText = @"exec " + ProcedureName.CurrentValue + " @CertificateNumber,  @Identifier";


            if (String.IsNullOrEmpty(id))
            {
                command.Parameters.AddWithValue("@Identifier", DBNull.Value);

            }
            else
            {
                command.Parameters.AddWithValue("@Identifier", id);
            }
            if (String.IsNullOrEmpty(certID))
            {

                command.Parameters.AddWithValue("@CertificateNumber", DBNull.Value);
            }
            else
            {
                command.Parameters.AddWithValue("@CertificateNumber", certID);
            }


            SqlDataAdapter resultDataSet = new SqlDataAdapter(command);
            ds.Tables.Add("ExplosivesCertificates");
            try
            {
                connection.Open();
                resultDataSet.Fill(ds.Tables["ExplosivesCertificates"]);

            }
            finally
            {
                connection.Close();
            }

            DataSetMapper<ValidExplosivesCertificateResponse> mapper = CreateMapValidExplosivesCertificate(accessMatrix);
            ValidExplosivesCertificateResponse result = new ValidExplosivesCertificateResponse();
            mapper.Map(ds, result);
            return result;

        }

        private DataSetMapper<ValidExplosivesCertificateResponse> CreateMapValidExplosivesCertificate(AccessMatrix accessMatrix)
        {
            DataSetMapper<ValidExplosivesCertificateResponse> mapper = new DataSetMapper<ValidExplosivesCertificateResponse>(accessMatrix);

            mapper.AddDataSetMap((r) => r.ValidExplosivesCertificate, (d) => d.Tables["ExplosivesCertificates"].Rows);
            mapper.AddDataColumnMap((r) => r.ValidExplosivesCertificate[0].CertificateNumber, "CertificateNumber");
            mapper.AddDataColumnMap((r) => r.ValidExplosivesCertificate[0].CertificateStatus, "CertificateStatus");
            mapper.AddDataColumnMap((r) => r.ValidExplosivesCertificate[0].EmployerIdentifier, "EmployerID");
            mapper.AddDataColumnMap((r) => r.ValidExplosivesCertificate[0].EmployerName, "EmployerName");
            mapper.AddDataColumnMap((r) => r.ValidExplosivesCertificate[0].ExamProtocolDate, "ExamProtocolDate");
            mapper.AddDataColumnMap((r) => r.ValidExplosivesCertificate[0].ExamProtocolNumber, "ExamProtocolNumber");
            mapper.AddDataColumnMap((r) => r.ValidExplosivesCertificate[0].ExpiryDate, "ExpiryDate");
            mapper.AddDataColumnMap((r) => r.ValidExplosivesCertificate[0].Identifier, "OwnerID");
            mapper.AddDataColumnMap((r) => r.ValidExplosivesCertificate[0].Owner.CellPhoneNumber, "CellPhone");
            mapper.AddDataColumnMap((r) => r.ValidExplosivesCertificate[0].Owner.EmailAddress, "EmailAddress");
            mapper.AddDataColumnMap((r) => r.ValidExplosivesCertificate[0].Owner.FaxNumber, "Fax");
            mapper.AddDataColumnMap((r) => r.ValidExplosivesCertificate[0].Owner.FirstName, "OwnerFirstName");
            mapper.AddDataColumnMap((r) => r.ValidExplosivesCertificate[0].Owner.LastName, "OwnerLastName");
            mapper.AddDataColumnMap((r) => r.ValidExplosivesCertificate[0].Owner.PhoneNumber, "Phone");
            mapper.AddDataColumnMap((r) => r.ValidExplosivesCertificate[0].Owner.SecondName, "OwnerMiddleName");
            mapper.AddDataColumnMap((r) => r.ValidExplosivesCertificate[0].OwnerIdentifierType, "OwnerIDType");
            mapper.AddDataColumnMap((r) => r.ValidExplosivesCertificate[0].OwnerType, "OwnerType");
            mapper.AddDataColumnMap((r) => r.ValidExplosivesCertificate[0].Qualification, "Qualification");
            mapper.AddDataColumnMap((r) => r.ValidExplosivesCertificate[0].TrainingOrganizationName, "TrainingOrganizationName");

            return mapper;
        }
    }
}
