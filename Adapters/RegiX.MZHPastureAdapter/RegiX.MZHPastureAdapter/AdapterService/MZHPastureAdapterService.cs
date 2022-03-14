using FirebirdSql.Data.FirebirdClient;
using TechnoLogica.RegiX.FirebirdSqlAdapterService;
using System;
using System.ComponentModel.Composition;
using System.Linq;
using TechnoLogica.RegiX.Common.DataContracts;
using TechnoLogica.RegiX.Common.ObjectMapping;
using TechnoLogica.RegiX.Common.Utils;
using TechnoLogica.RegiX.Common;
using System.Data;
using System.ServiceModel;
using TechnoLogica.RegiX.Adapters.Common.ExportExtension;
using TechnoLogica.RegiX.Adapters.Common.DataContracts;
using TechnoLogica.RegiX.Common.DataContracts.Parameter;
using TechnoLogica.RegiX.Adapters.Common.ObjectMapping;

namespace TechnoLogica.RegiX.MZHPastureAdapter.AdapterService
{
    [Export(typeof(IAdapterService))]
    [ExportFullName(typeof(MZHPastureAdapterService), typeof(IAdapterService))]
    [ExportSimpleName(typeof(MZHPastureAdapterService), typeof(IAdapterService))]
    public class MZHPastureAdapterService : FirebirdSqlBaseAdapterService, IMZHPastureAdapterService, IAdapterService
    {
        [Export(typeof(ParameterInfo))]
        [ExportFullName(typeof(MZHPastureAdapterService), typeof(ParameterInfo))]
        public static ParameterInfo<string> ConnectionString =
            new ParameterInfo<string>(@"initial catalog=C:\DataBase\DOG_PML.FDB;data source=172.16.69.13;user id=sysdba;password=masterkey")
            {
                Key = Constants.ConnectionStringParameterKeyName,
                Description = "Connection string",
                OwnerAssembly = typeof(MZHPastureAdapterService).Assembly
            };

        public CommonSignedResponse<PastureMeadowLandRequestType, PastureMeadowLandResponse> GetPastureMeadowLand(PastureMeadowLandRequestType argument, AccessMatrix accessMatrix, AdapterAdditionalParameters aditionalParameters)
        {
            Guid id = Guid.NewGuid();
            LogData(aditionalParameters, new { Request = argument.XmlSerialize(), Guid = id });
            try
            {   
                if (argument == null || string.IsNullOrEmpty(argument.BeneficiaryIdentifier))
                {
                    //TODO: "Попълването на стойност на входния параметър Идентификатор(BeneficiaryIdentifier) е задължително!"
                    FaultReason reason = new FaultReason("Попълването на стойност на входния параметър Идентификатор(BeneficiaryIdentifier) е задължително!");
                    throw new FaultException(reason, null, null);
                }
                string argumentIdentifier = argument.BeneficiaryIdentifier;
                argumentIdentifier = argumentIdentifier.Trim();
                if (argumentIdentifier.Length > 14)
                {
                    //TODO: "Дължината на входния параметър Идентификатор(BeneficiaryIdentifier) е ограничена до 14 символа!"
                    FaultReason reason = new FaultReason("Дължината на входния параметър Идентификатор(BeneficiaryIdentifier) е ограничена до 14 символа!");
                    throw new FaultException(reason, null, null);
                }
                PastureMeadowLandResponse searchResults = null;
                FbConnection connection = new FbConnection(ConnectionString.Value);
                FbCommand command = new FbCommand
                    (@"select BeneficiaryIdentifier,
                              BeneficiaryName,
                              BeneficiaryType,
                              District,
                              Municipality,
                              SettlementType || ' ' || Settlement as Settlement,
                              Acreage,
                              ReportDate
                        from RegiX_AreaDetails 
                       where BeneficiaryIdentifier = @parameter
                        order by RecordId", connection);
                command.Parameters.Add("@parameter", argumentIdentifier);
                command.CommandType = System.Data.CommandType.Text;
                FbDataAdapter da = new FbDataAdapter(command);
                DataSet ds = new DataSet();
                ds.Tables.Add("PastureLands");

                try
                {
                    connection.Open();
                    da.Fill(ds.Tables["PastureLands"]);
                }
                finally
                {
                    connection.Close();
                }

                DataSetMapper<PastureMeadowLandResponse> mapper = CreatePastureMeadowLandResponseMapper(accessMatrix);
                searchResults = new PastureMeadowLandResponse();
                if (ds.Tables[0].Rows.Count > 0)
                {
                    mapper.Map(ds, searchResults);
                }
                else
                {
                    searchResults.PastureLands = null;
                }

                return
                   SigningUtils.CreateAndSign(
                       argument,
                       searchResults,
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

        private static DataSetMapper<PastureMeadowLandResponse> CreatePastureMeadowLandResponseMapper(AccessMatrix accessMatrix)
        {
            DataSetMapper<PastureMeadowLandResponse> mapper = new DataSetMapper<PastureMeadowLandResponse>(accessMatrix);

            mapper.AddDataSetObjectInitializer((ds) => (ds.Tables["PastureLands"].Rows.Count >= 1) ? ds.Tables["PastureLands"].Rows[0] : null);
            mapper.AddDataColumnMap((r) => r.BeneficiaryIdentifier, "BeneficiaryIdentifier");
            mapper.AddDataColumnMap((r) => r.BeneficiaryName, "BeneficiaryName");
            mapper.AddDataColumnMap((r) => r.BeneficiaryType, "BeneficiaryType");

            mapper.AddDataRowMap((r) => r.PastureLands.PastureLand, (d) => d.Table.Rows);
            mapper.AddDataColumnMap((r) => r.PastureLands.PastureLand[0].District, "District");
            mapper.AddDataColumnMap((r) => r.PastureLands.PastureLand[0].Municipality, "Municipality");
            mapper.AddDataColumnMap((r) => r.PastureLands.PastureLand[0].Territory, "Settlement");
            mapper.AddDataColumnMap((r) => r.PastureLands.PastureLand[0].ReportDate, "ReportDate");
            mapper.AddDataColumnMap((r) => r.PastureLands.PastureLand[0].Acreage, "Acreage");

            return mapper;
        }

        
        public CommonSignedResponse<PastureMeadowLandDetailRequestType, PastureMeadowLandDetailResponse> GetPastureMeadowLandDetail(PastureMeadowLandDetailRequestType argument, AccessMatrix accessMatrix, AdapterAdditionalParameters aditionalParameters)
        {
            Guid id = Guid.NewGuid();
            LogData(aditionalParameters, new { Request = argument.XmlSerialize(), Guid = id });
            try
            {
                if (argument == null || string.IsNullOrEmpty(argument.BeneficiaryIdentifier))
                {
                    //TODO: "Попълването на стойност на входния параметър Идентификатор(BeneficiaryIdentifier) е задължително!"
                    FaultReason reason = new FaultReason("Попълването на стойност на входния параметър Идентификатор(BeneficiaryIdentifier) е задължително!");
                    throw new FaultException(reason, null, null);
                }
                string argumentIdentifier = argument.BeneficiaryIdentifier;
                argumentIdentifier = argumentIdentifier.Trim();
                if (argumentIdentifier.Length > 14)
                {
                    //TODO: "Дължината на входния параметър Идентификатор(BeneficiaryIdentifier) е ограничена до 14 символа!"
                    FaultReason reason = new FaultReason("Дължината на входния параметър Идентификатор(BeneficiaryIdentifier) е ограничена до 14 символа!");
                    throw new FaultException(reason, null, null);
                }
                PastureMeadowLandDetailResponse searchResults = null;
                FbConnection connection = new FbConnection(ConnectionString.Value);
                FbCommand command = new FbCommand
                    (@"select BeneficiaryIdentifier,
                              BeneficiaryName,
                              BeneficiaryType,
                              DistrictCode,
                              District,
                              MunicipalityCode,
                              Municipality,
                              Ekatte,
                              SettlementType,
                              Settlement,
                              Acreage,
                              Area_1_7,
                              Area_8_10,
                              Area_DPF,
                              Area_OPF,
                              Area_PRIV,
                              Area_CONT,
                              Area_PERS,
                              ReportDate
                        from RegiX_AreaDetails 
                       where BeneficiaryIdentifier = @parameter
                        order by RecordId", connection);
                command.Parameters.Add("@parameter", argumentIdentifier);
                command.CommandType = System.Data.CommandType.Text;
                FbDataAdapter da = new FbDataAdapter(command);
                DataSet ds = new DataSet();
                ds.Tables.Add("PastureLands");

                try
                {
                    connection.Open();
                    da.Fill(ds.Tables["PastureLands"]);
                }
                finally
                {
                    connection.Close();
                }

                DataSetMapper<PastureMeadowLandDetailResponse> mapper = CreatePastureMeadowLandDetailMap(accessMatrix);
                searchResults = new PastureMeadowLandDetailResponse();
                if (ds.Tables[0].Rows.Count > 0)
                {
                    mapper.Map(ds, searchResults);
                }
                else
                {
                    searchResults.PastureLands = null;
                }
                
                return
                   SigningUtils.CreateAndSign(
                       argument,
                       searchResults,
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

        private static DataSetMapper<PastureMeadowLandDetailResponse> CreatePastureMeadowLandDetailMap(AccessMatrix accessMatrix)
        {
            DataSetMapper<PastureMeadowLandDetailResponse> mapper = new DataSetMapper<PastureMeadowLandDetailResponse>(accessMatrix);

            mapper.AddDataSetObjectInitializer((ds) => (ds.Tables["PastureLands"].Rows.Count >= 1) ? ds.Tables["PastureLands"].Rows[0] : null);
            mapper.AddDataColumnMap((r) => r.BeneficiaryIdentifier, "BeneficiaryIdentifier");

            mapper.AddDataRowMap((r) => r.PastureLands.PastureLand, (d) => d.Table.Rows);
            mapper.AddDataColumnMap((r) => r.PastureLands.PastureLand[0].BeneficiaryName, "BeneficiaryName");
            mapper.AddDataColumnMap((r) => r.PastureLands.PastureLand[0].BeneficiaryType, "BeneficiaryType");
            mapper.AddDataColumnMap((r) => r.PastureLands.PastureLand[0].District, "District");
            mapper.AddDataColumnMap((r) => r.PastureLands.PastureLand[0].DistrictCode, "DistrictCode");
            mapper.AddDataColumnMap((r) => r.PastureLands.PastureLand[0].Municipality, "Municipality");
            mapper.AddDataColumnMap((r) => r.PastureLands.PastureLand[0].MunicipalityCode, "MunicipalityCode");
            mapper.AddDataColumnMap((r) => r.PastureLands.PastureLand[0].Ekatte, "Ekatte");
            mapper.AddDataColumnMap((r) => r.PastureLands.PastureLand[0].Settlement, "Settlement");
            mapper.AddDataColumnMap((r) => r.PastureLands.PastureLand[0].SettlementType, "SettlementType");
            mapper.AddDataColumnMap((r) => r.PastureLands.PastureLand[0].ReportDate, "ReportDate");

            mapper.AddDataColumnMap((r) => r.PastureLands.PastureLand[0].AreaDetails.Acreage, "Acreage");
            mapper.AddDataColumnMap((r) => r.PastureLands.PastureLand[0].AreaDetails.CategoryBreakdown.Area_1_7, "Area_1_7");
            mapper.AddDataColumnMap((r) => r.PastureLands.PastureLand[0].AreaDetails.CategoryBreakdown.Area_8_10, "Area_8_10");
            mapper.AddDataColumnMap((r) => r.PastureLands.PastureLand[0].AreaDetails.LandRightsBreakdown.Area_CONT, "Area_CONT");
            mapper.AddDataColumnMap((r) => r.PastureLands.PastureLand[0].AreaDetails.LandRightsBreakdown.Area_PERS, "Area_PERS");
            mapper.AddDataColumnMap((r) => r.PastureLands.PastureLand[0].AreaDetails.OwnershipBreakdown.Area_OPF, "Area_OPF");
            mapper.AddDataColumnMap((r) => r.PastureLands.PastureLand[0].AreaDetails.OwnershipBreakdown.Area_DPF, "Area_DPF");
            mapper.AddDataColumnMap((r) => r.PastureLands.PastureLand[0].AreaDetails.OwnershipBreakdown.Area_PRIV, "Area_PRIV");
            
            return mapper;
        }
    }
}
