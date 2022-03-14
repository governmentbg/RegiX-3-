using System;
using System.ComponentModel.Composition;
using System.Data;
using System.Data.SqlClient;
using System.ServiceModel;
using TechnoLogica.RegiX.Adapters.Common.DataContracts;
using TechnoLogica.RegiX.Adapters.Common.ExportExtension;
using TechnoLogica.RegiX.Adapters.Common.ObjectMapping;
using TechnoLogica.RegiX.Common;
using TechnoLogica.RegiX.Common.DataContracts;
using TechnoLogica.RegiX.Common.DataContracts.Parameter;
using TechnoLogica.RegiX.Common.ObjectMapping;
using TechnoLogica.RegiX.Common.Utils;
using TechnoLogica.RegiX.GraoCivilStatusActsAdapter.XMLSchemas;
using TechnoLogica.RegiX.GraoCommon;

namespace TechnoLogica.RegiX.GraoCivilStatusActsAdapter.AdapterService
{
    [Export(typeof(IAdapterService))]
    [ExportFullName(typeof(GraoCivilStatusActsAdapter), typeof(IAdapterService))]
    [ExportSimpleName(typeof(GraoCivilStatusActsAdapter), typeof(IAdapterService))]
    public class GraoCivilStatusActsAdapter : SQLServerAdapterService.SQLServerAdapterService, IGraoCivilStatusActsAdapter, IAdapterService
    {
        [Export(typeof(ParameterInfo))]
        [ExportFullName(typeof(GraoCivilStatusActsAdapter), typeof(ParameterInfo))]
        public static ParameterInfo<string> ProcedureName =
          new ParameterInfo<string>("[GetMarriageCertData]")
          {
              Key = "ProcedureName",
              Description = "Name of the procedure which is executed for GetMarriageCertificate",
              OwnerAssembly = typeof(GraoCivilStatusActsAdapter).Assembly
          };

        [Export(typeof(ParameterInfo))]
        [ExportFullName(typeof(GraoCivilStatusActsAdapter), typeof(ParameterInfo))]
        public static ParameterInfo<string> DbSchema =
            new ParameterInfo<string>("[dbo]")
            {
                Key = "DbSchema",
                Description = "Name of Schema where the procedure is",
                OwnerAssembly = typeof(GraoCivilStatusActsAdapter).Assembly
            };

        [Export(typeof(ParameterInfo))]
        [ExportFullName(typeof(GraoCivilStatusActsAdapter), typeof(ParameterInfo))]
        public static ParameterInfo<string> ConnectionString =
            new ParameterInfo<string>(@"data source=REGIX2-sql.regix.tlogica.com;initial catalog=grao;user id=;password=;")
            {
                Key = "ConnectionString",
                Description = "Connection string",
                OwnerAssembly = typeof(GraoCivilStatusActsAdapter).Assembly
            };

        public CommonSignedResponse<MarriageCertificateRequestType, MarriageCertificateResponseType> GetMarriageCertificate(MarriageCertificateRequestType argument, AccessMatrix accessMatrix, AdapterAdditionalParameters aditionalParameters)
        {
            Guid id = Guid.NewGuid();
            LogData(aditionalParameters, new { Request = argument.XmlSerialize(), Guid = id });
            try
            {
                if (argument == null)//Валидиране!!! || (string.IsNullOrEmpty(argument.MSN) && string.IsNullOrEmpty(argument.RegMark)))
                {
                    //TODO: Add "Валидиране!"
                    throw new FaultException();
                }
                SqlCommand command = new SqlCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = DbSchema.Value + "." + ProcedureName.CurrentValue;
                command.Parameters.AddWithValue("@Egn", argument.Egn);
                command.Parameters.AddWithValue("@MarriageDate", argument.SearchDate);

                SqlConnection connection = new SqlConnection(ConnectionString.Value);
                DataSet ds = new DataSet();
                command.Connection = connection;

                SqlDataAdapter resultDataSet = new SqlDataAdapter(command);

                try
                {
                    connection.Open();
                    resultDataSet.Fill(ds);
                }
                finally
                {
                    connection.Close();
                }

                DataSetMapper<MarriageCertificateResponseType> mapper = CreateMapForMarriageCertificateResponseType(accessMatrix, DateTime.Now);
                MarriageCertificateResponseType result = new MarriageCertificateResponseType();
                mapper.Map(ds, result);

                if(result.SignatureInvalidatedSpecified && result.SignatureInvalidated == false && ds.Tables[0].Rows.Count == 1)
                {
                    result.SignatureInvalidated = !(NRGS.MainSite.Inter.CheckS(ds.Tables[0].Rows[0]["MarriageActID"].ToString()));
                    result.SignatureInvalidatedSpecified = true;
                }

                LogWarn(Utils.GetLogMessageForSuccessOperation(argument.Egn, aditionalParameters, argument.SearchDate.ToString()));

                return SigningUtils.CreateAndSign(
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

        private DataSetMapper<MarriageCertificateResponseType> CreateMapForMarriageCertificateResponseType(AccessMatrix accessMatrix, DateTime reportDate)
        {
            DataSetMapper<MarriageCertificateResponseType> mapper = new DataSetMapper<MarriageCertificateResponseType>(accessMatrix);

            //Aircraft
            mapper.AddDataSetObjectInitializer((ds) => (ds.Tables[0].Rows.Count == 1) ? ds.Tables[0].Rows[0] : null);

            mapper.AddConstantMap(r => r.ReportDate, reportDate);
            mapper.AddDataColumnMap((r) => r.ManData.FirstName, "ManFirstName");
            mapper.AddDataColumnMap((r) => r.ManData.MiddleName, "ManMiddleName");
            mapper.AddDataColumnMap((r) => r.ManData.LastName, "ManLastName");
            mapper.AddDataColumnMap((r) => r.ManData.PostMarriageLastName, "ManPostMrgLastName");
            mapper.AddDataColumnMap((r) => r.ManData.Egn, "ManEgn");
            mapper.AddDataColumnMap((r) => r.ManData.BirthDate, "ManBirthDate");

            mapper.AddDataColumnMap((r) => r.WomanData.FirstName, "WomanFirstName");
            mapper.AddDataColumnMap((r) => r.WomanData.MiddleName, "WomanMiddleName");
            mapper.AddDataColumnMap((r) => r.WomanData.LastName, "WomanLastName");
            mapper.AddDataColumnMap((r) => r.WomanData.PostMarriageLastName, "WomanPostMrgLastName");
            mapper.AddDataColumnMap((r) => r.WomanData.Egn, "WomanEgn");
            mapper.AddDataColumnMap((r) => r.WomanData.BirthDate, "WomanBirthDate");

            mapper.AddDataColumnMap((r) => r.MarriageData.MarriageDate, "MarriageDate");
            mapper.AddDataColumnMap((r) => r.MarriageData.MarriagePlace.DistrictCode, "MPlaceOblastCode");
            mapper.AddDataColumnMap((r) => r.MarriageData.MarriagePlace.DistrictName, "MPlaceOblastName");
            mapper.AddDataColumnMap((r) => r.MarriageData.MarriagePlace.MunicipalityCode, "MPlaceObstinaCode");
            mapper.AddDataColumnMap((r) => r.MarriageData.MarriagePlace.MunicipalityName, "MPlaceObstinaName");
            mapper.AddDataColumnMap((r) => r.MarriageData.MarriagePlace.CityCode, "MarriagePlace");
            mapper.AddDataColumnMap((r) => r.MarriageData.MarriagePlace.CityName, "MPlaceName");
            mapper.AddDataColumnMap((r) => r.MarriageData.ForeignMarriageCity, "ForeignMarriageCity");

            mapper.AddDataColumnMap((r) => r.MarriageActData.FullActNumber, "FullActNumber"); 
            mapper.AddDataColumnMap((r) => r.MarriageActData.ActDate, "MActDate");
            mapper.AddDataColumnMap((r) => r.MarriageActData.ActPlace.DistrictCode, "MActOblastCode");
            mapper.AddDataColumnMap((r) => r.MarriageActData.ActPlace.DistrictName, "MActOblastName");
            mapper.AddDataColumnMap((r) => r.MarriageActData.ActPlace.MunicipalityCode, "MActObstinaCode");
            mapper.AddDataColumnMap((r) => r.MarriageActData.ActPlace.MunicipalityName, "MActObstinaName");
            mapper.AddDataColumnMap((r) => r.MarriageActData.ActPlace.CityCode, "MActPlace");
            mapper.AddDataColumnMap((r) => r.MarriageActData.ActPlace.CityName, "MActNmName");

            mapper.AddDataColumnMap((r) => r.SignatureInvalidated, "SignatureInvalidated", (o) =>
            {
                if (o != null)
                {
                    if (o.ToString() == "1")
                    {
                        return true;
                    }
                    if (o.ToString() == "0")
                    {
                        return false;
                    }
                }
                return null;
            });

            return mapper;

        }
    }
}
