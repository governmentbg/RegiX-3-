using System;
using System.Collections.Generic;
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

namespace TechnoLogica.RegiX.GitPenalProvisionsAdapter.AdapterService
{
    [Export(typeof(IAdapterService))]
    [ExportFullName(typeof(GitPenalProvisionsAdapter), typeof(IAdapterService))]
    [ExportSimpleName(typeof(GitPenalProvisionsAdapter), typeof(IAdapterService))]
    public class GitPenalProvisionsAdapter : SQLServerAdapterService.SQLServerAdapterService, IGitPenalProvisionsAdapter, IAdapterService
    {
        [Export(typeof(ParameterInfo))]
        [ExportFullName(typeof(GitPenalProvisionsAdapter), typeof(ParameterInfo))]
        public static ParameterInfo<string> ConnectionString =
            new ParameterInfo<string>(@"data source=;initial catalog=regix2MockDb;user id=;password=;")
            {
                Key = Constants.ConnectionStringParameterKeyName,
                Description = "Connection string",
                OwnerAssembly = typeof(GitPenalProvisionsAdapter).Assembly
            };

        [Export(typeof(ParameterInfo))]
        [ExportFullName(typeof(GitPenalProvisionsAdapter), typeof(ParameterInfo))]
        public static ParameterInfo<string> ViewNameForPeriod =
            new ParameterInfo<string>(@"v_NP_VIEW1")
            {
                Key = "View name for method GetPenalProvisionForPeriod",
                Description = "database view name",
                OwnerAssembly = typeof(GitPenalProvisionsAdapter).Assembly
            };

        [Export(typeof(ParameterInfo))]
        [ExportFullName(typeof(GitPenalProvisionsAdapter), typeof(ParameterInfo))]
        public static ParameterInfo<string> ViewNameMediatorAct =
            new ParameterInfo<string>(@"v_NP_VIEW2")
            {
                Key = "View name for method GetPenalProvisionMediatorAct",
                Description = "database view name",
                OwnerAssembly = typeof(GitPenalProvisionsAdapter).Assembly
            };

        [Export(typeof(ParameterInfo))]
        [ExportFullName(typeof(GitPenalProvisionsAdapter), typeof(ParameterInfo))]
        public static ParameterInfo<string> ViewNameUnpaidFee =
            new ParameterInfo<string>(@"v_NP_VIEW3")
            {
                Key = "View name for method GetPenalProvisionUnpaidFee",
                Description = "database view name",
                OwnerAssembly = typeof(GitPenalProvisionsAdapter).Assembly
            };

        public CommonSignedResponse<PenalProvisionForPeriodRequest, PenalProvisionForPeriodResponse> GetPenalProvisionForPeriod(PenalProvisionForPeriodRequest argument, AccessMatrix accessMatrix, AdapterAdditionalParameters aditionalParameters)
        {
            Guid id = Guid.NewGuid();
            LogData(aditionalParameters, new { Request = argument.Serialize(), Guid = id });
            try
            {
                PenalProvisionForPeriodResponse result = new PenalProvisionForPeriodResponse();
                result.PenalProvisions = GetDataForPeriod(accessMatrix, argument.IntruderIdentifier, argument.DateFrom, argument.DateTo, ViewNameForPeriod.Value);
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

        public CommonSignedResponse<PenalProvisionMediatorActType, PenalProvisionMediatorActResponse> GetPenalProvisionMediatorAct(PenalProvisionMediatorActType argument, AccessMatrix accessMatrix, AdapterAdditionalParameters aditionalParameters)
        {
            Guid id = Guid.NewGuid();
            LogData(aditionalParameters, new { Request = argument.Serialize(), Guid = id });
            try
            {
                PenalProvisionMediatorActResponse result = new PenalProvisionMediatorActResponse();
                result.PenalProvisions = GetDataForMediatorAct(accessMatrix, argument.IntruderIdentifier, argument.DateFrom, argument.DateTo, argument.PenalProvisionRelation, ViewNameMediatorAct.Value);
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

        public CommonSignedResponse<PenalProvisionUnpaidFeeType, PenalProvisionUnpaidFeeResponse> GetPenalProvisionUnpaidFee(PenalProvisionUnpaidFeeType argument, AccessMatrix accessMatrix, AdapterAdditionalParameters aditionalParameters)
        {
            Guid id = Guid.NewGuid();
            LogData(aditionalParameters, new { Request = argument.Serialize(), Guid = id });
            try
            {
                PenalProvisionUnpaidFeeResponse result = new PenalProvisionUnpaidFeeResponse();
                result.PenalProvisions = GetDataForInpaidFee(accessMatrix, argument.IntruderIdentifier, argument.DateFrom, argument.DateTo, ViewNameUnpaidFee.Value);
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

        private List<PenalProvision> GetDataForPeriod(AccessMatrix accessMatrix, string eik, DateTime dateFrom, DateTime dateTo, string viewName)
        {
            SqlConnection connection = new SqlConnection(ConnectionString.Value);
            DataSet ds = new DataSet();

            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandType = CommandType.Text;

            command.CommandText = @"SELECT * 
                                    FROM " + viewName +
                                    " WHERE IntruderID LIKE @Identifier and [PenalProvisionEnforcementDate] BETWEEN @DateFrom and @DateTo";

            command.Parameters.AddWithValue("@Identifier", eik);
            command.Parameters.AddWithValue("@DateFrom", dateFrom);
            command.Parameters.AddWithValue("@DateTo", dateTo);

            SqlDataAdapter resultDataSet = new SqlDataAdapter(command);
            ds.Tables.Add("PenalProvisions");
            try
            {
                connection.Open();
                resultDataSet.Fill(ds.Tables["PenalProvisions"]);

            }
            finally
            {
                connection.Close();
            }

            DataSetMapper<PenalProvisionForPeriodResponse> mapper = CreateMap(accessMatrix);
            PenalProvisionForPeriodResponse result = new PenalProvisionForPeriodResponse();
            mapper.Map(ds, result);
            return result.PenalProvisions;
        }

        private List<PenalProvision> GetDataForMediatorAct(AccessMatrix accessMatrix, string eik, DateTime dateFrom, DateTime dateTo, string penalProvisionRelation, string viewName)
        {
            SqlConnection connection = new SqlConnection(ConnectionString.Value);
            DataSet ds = new DataSet();

            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandType = CommandType.Text;

            //Todo: add filter for the penalProvisionRelation
            command.CommandText = @"SELECT * 
                                    FROM " + viewName +
                                    " WHERE IntruderID LIKE @Identifier and [PenalProvisionEnforcementDate] BETWEEN @DateFrom and @DateTo";

            command.Parameters.AddWithValue("@Identifier", eik);
            command.Parameters.AddWithValue("@DateFrom", dateFrom);
            command.Parameters.AddWithValue("@DateTo", dateTo);
            //command.Parameters.AddWithValue("@PenalProvisionRelation", penalProvisionRelation);

            SqlDataAdapter resultDataSet = new SqlDataAdapter(command);
            ds.Tables.Add("PenalProvisions");
            try
            {
                connection.Open();
                resultDataSet.Fill(ds.Tables["PenalProvisions"]);

            }
            finally
            {
                connection.Close();
            }

            DataSetMapper<PenalProvisionForPeriodResponse> mapper = CreateMap(accessMatrix);
            PenalProvisionForPeriodResponse result = new PenalProvisionForPeriodResponse();
            mapper.Map(ds, result);
            return result.PenalProvisions;
        }

        private List<PenalProvision> GetDataForInpaidFee(AccessMatrix accessMatrix, string eik, DateTime dateFrom, DateTime dateTo, string viewName)
        {
            SqlConnection connection = new SqlConnection(ConnectionString.Value);
            DataSet ds = new DataSet();

            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandType = CommandType.Text;

            //Add another filter: основание неплатени трудови възнаграждения
            command.CommandText = @"SELECT * 
                                    FROM " + viewName +
                                    " WHERE IntruderID LIKE @Identifier and [PenalProvisionEnforcementDate] BETWEEN @DateFrom and @DateTo";

            command.Parameters.AddWithValue("@Identifier", eik);
            command.Parameters.AddWithValue("@DateFrom", dateFrom);
            command.Parameters.AddWithValue("@DateTo", dateTo);

            SqlDataAdapter resultDataSet = new SqlDataAdapter(command);
            ds.Tables.Add("PenalProvisions");
            try
            {
                connection.Open();
                resultDataSet.Fill(ds.Tables["PenalProvisions"]);

            }
            finally
            {
                connection.Close();
            }

            DataSetMapper<PenalProvisionForPeriodResponse> mapper = CreateMap(accessMatrix);
            PenalProvisionForPeriodResponse result = new PenalProvisionForPeriodResponse();
            mapper.Map(ds, result);
            return result.PenalProvisions;
        }

        private DataSetMapper<PenalProvisionForPeriodResponse> CreateMap(AccessMatrix accessMatrix)
        {
            DataSetMapper<PenalProvisionForPeriodResponse> mapper = new DataSetMapper<PenalProvisionForPeriodResponse>(accessMatrix);

            mapper.AddDataSetMap((r) => r.PenalProvisions, (d) => d.Tables["PenalProvisions"].Rows);
            mapper.AddDataColumnMap((r) => r.PenalProvisions[0].DocumentIssuer, "DocumentIssuer");
            mapper.AddDataColumnMap((r) => r.PenalProvisions[0].Intruder.Identifier, "IntruderID");
            mapper.AddDataColumnMap((r) => r.PenalProvisions[0].Intruder.Name, "IntruderName");
            mapper.AddDataColumnMap((r) => r.PenalProvisions[0].IssueDate, "IssueDate");
            mapper.AddDataColumnMap((r) => r.PenalProvisions[0].PenalProvisionEnforcementDate, "PenalProvisionEnforcementDate");
            mapper.AddDataColumnMap((r) => r.PenalProvisions[0].PenalProvisionNumber, "PenalProvisionNumber");
            mapper.AddDataColumnMap((r) => r.PenalProvisions[0].SanctionSize, "SanctionSize");
            mapper.AddDataColumnMap((r) => r.PenalProvisions[0].SanctionSizeChanged, "SantionSizeChanged");
            mapper.AddDataColumnMap((r) => r.PenalProvisions[0].SanctionSizeText, "SanctionSizeText");
            mapper.AddDataColumnMap((r) => r.PenalProvisions[0].SanctionType, "SanctionType");
            mapper.AddDataColumnMap((r) => r.PenalProvisions[0].ViolationChapter, "Violation_Chapter");
            mapper.AddDataColumnMap((r) => r.PenalProvisions[0].ViolationPart, "Violation_Part");
            mapper.AddDataColumnMap((r) => r.PenalProvisions[0].ViolationSection, "Violation_Section");
            mapper.AddDataColumnMap((r) => r.PenalProvisions[0].ViolationText, "Violation_Text");

            return mapper;
        }
    }
}
