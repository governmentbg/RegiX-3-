using System;
using System.Collections.Generic;
using System.Linq;
using TechnoLogica.RegiX.Common.Utils;
using TechnoLogica.RegiX.Common;
using TechnoLogica.RegiX.Common.ObjectMapping;
using System.ComponentModel.Composition;
using System.Data;
using Npgsql;
using TechnoLogica.RegiX.Common.DataContracts;
using TechnoLogica.RegiX.Adapters.Common.ExportExtension;
using TechnoLogica.RegiX.Adapters.Common.DataContracts;
using TechnoLogica.RegiX.Common.DataContracts.Parameter;
using TechnoLogica.RegiX.Adapters.Common.ObjectMapping;

namespace TechnoLogica.RegiX.PDVOAdapter.AdapterService
{
    [Export(typeof(IAdapterService))]
    [ExportFullName(typeof(PDVOAdapter), typeof(IAdapterService))]
    [ExportSimpleName(typeof(PDVOAdapter), typeof(IAdapterService))]
    public class PDVOAdapter : NpgsqlAdapterService.NpgsqlBaseAdapterService, IPDVOAdapter, IAdapterService
    {
        [Export(typeof(ParameterInfo))]
        [ExportFullName(typeof(PDVOAdapter), typeof(ParameterInfo))]
        public static ParameterInfo<string> ConnectionString =
            new ParameterInfo<string>("Server=egov;Port=5432;Database=drive;UserId=;Password=;Timeout=1024")
            {
                Key = Constants.ConnectionStringParameterKeyName,
                Description = "Connection string",
                OwnerAssembly = typeof(PDVOAdapter).Assembly
            };

        [Export(typeof(ParameterInfo))]
        [ExportFullName(typeof(PDVOAdapter), typeof(ParameterInfo))]
        public static ParameterInfo<string> SchemaName =
            new ParameterInfo<string>("PDVO")
            {
                Key = "SchemaName",
                Description = "Name of the schema in database",
                OwnerAssembly = typeof(PDVOAdapter).Assembly
            };

        public CommonSignedResponse<AcademicRecognitionRequestType, AcademicRecognitionResponseType> GetAcademicRecognition(AcademicRecognitionRequestType argument, AccessMatrix accessMatrix, AdapterAdditionalParameters aditionalParameters)
        {
            Guid id = Guid.NewGuid();
            LogData(aditionalParameters, new { Request = argument.XmlSerialize(), Guid = id });
            try
            {
                AcademicRecognitionResponseType result = new AcademicRecognitionResponseType();

                NpgsqlConnection connection = new NpgsqlConnection(ConnectionString.Value);
                //основни данни за призната диплома
                string mainCommandText = @"select app_num,
                                                app_date,
                                                application_recognition_status,
                                                legal_reason,
                                                fname,
                                                sname,
                                                lname,
                                                civil_id_type,
                                                civil_id,
                                                recognized_edu_level,
                                                recognized_qualification_name,
                                                university_original_name,
                                                university_bg_name,
                                                university_country_name,
                                                university_city,
                                                university_address_details,
                                                certificate_numbers,
                                                recognized_specialities
                                           from """ + SchemaName.Value + @""".vw_regix_applications
                                          where app_num = :pInternalAppNum
                                            and app_date = :pInternalAppDate";
                NpgsqlCommand command = CreateCommand(connection, mainCommandText, argument);
                DataSet ds = new DataSet();
                ds.Tables.Add("AcademicRecognition");

                NpgsqlDataAdapter mainDA = new NpgsqlDataAdapter(command);

                try
                {
                    connection.Open();
                    mainDA.Fill(ds.Tables["AcademicRecognition"]);

                    if (ds.Tables["AcademicRecognition"].Rows.Count > 1)
                    {
                        //TODO: "Съществува повче от едно удoстверение/отказ за подадените деловодни номер и дата!"
                        throw new System.ServiceModel.FaultException();
                    }

                }
                finally
                {
                    connection.Close();
                }
                if (ds.Tables["AcademicRecognition"].Rows.Count == 0)
                {
                    result.CertificateNums = null;
                    result.RecognizedSpecialities = null;
                }
                else
                {
                    DataSetMapper<AcademicRecognitionResponseType> mapper = CreateMap(accessMatrix);
                    mapper.Map(ds, result);
                }
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

        private void FillTableFromArray(DataTable table, NpgsqlCommand command)
        {
            table.Columns.Add("Name", typeof(string));
            var objs = command.ExecuteScalar();
            if (objs != null && objs != System.DBNull.Value)
            {
                foreach (string item in (objs as IEnumerable<string>))
                {
                    table.Rows.Add(item);
                }
            }
        }


        private NpgsqlCommand CreateCommand(NpgsqlConnection connection, string commandText, AcademicRecognitionRequestType argument)
        {
            NpgsqlCommand command = new Npgsql.NpgsqlCommand();
            command.Connection = connection;
            command.CommandType = System.Data.CommandType.Text;
            command.CommandText = commandText;
            command.Parameters.AddWithValue("@pInternalAppNum", argument.InternalAppNum);
            command.Parameters.AddWithValue("@pInternalAppDate", argument.InternalAppDate);

            return command;
        }

        private DataSetMapper<AcademicRecognitionResponseType> CreateMap(AccessMatrix accessMatrix)
        {
            DataSetMapper<AcademicRecognitionResponseType> mapper = new DataSetMapper<AcademicRecognitionResponseType>(accessMatrix);

            mapper.AddDataSetObjectInitializer((ds) => (ds.Tables["AcademicRecognition"].Rows.Count == 1) ? ds.Tables["AcademicRecognition"].Rows[0] : null);
            mapper.AddDataColumnMap(r => r.InternalAppNum, "app_num");
            mapper.AddDataColumnMap(r => r.InternalAppDate, "app_date");
            mapper.AddDataColumnMap(r => r.AcademicRecognitionStatus, "application_recognition_status");
            mapper.AddDataColumnMap(r => r.RecognitionRefusal, "legal_reason");
            mapper.AddDataColumnMap(r => r.FirstName, "fname");
            mapper.AddDataColumnMap(r => r.MiddleName, "sname");
            mapper.AddDataColumnMap(r => r.LastName, "lname");
            mapper.AddDataColumnMap(r => r.IdentificatorType, "civil_id_type");
            mapper.AddDataColumnMap(r => r.IdentificatorTypeName, "civil_id_type", (o) =>
            {
                if (o != null && o != System.DBNull.Value)
                {
                    string result;
                    switch (o.ToString())
                    {
                        case "1":
                            result = "ЕГН";
                            break;
                        case "2":
                            result = "ЛНЧ";
                            break;
                        case "3":
                            result = "личен документ";
                            break;
                        default:
                            result = null;
                            break;
                    }
                    return result;
                }
                else
                {
                    return o;
                }
            });
            mapper.AddDataColumnMap(r => r.Identificator, "civil_id");
            mapper.AddDataColumnMap(r => r.RecognizedEduLevel, "recognized_edu_level");
            mapper.AddDataColumnMap(r => r.RecognizedProfQualName, "recognized_qualification_name");
            mapper.AddDataColumnMap(r => r.UniversityOriginalName, "university_original_name");
            mapper.AddDataColumnMap(r => r.UniversityNameCyrillic, "university_bg_name");
            mapper.AddDataColumnMap(r => r.CountryNameCyrillic, "university_country_name");
            mapper.AddDataColumnMap(r => r.SettlementAbroadName, "university_city");
            mapper.AddDataColumnMap(r => r.AddressDescriptionAbroad, "university_address_details");

            mapper.AddFunctionMap<AcademicRecognitionResponseType, List<string>>(r => r.CertificateNums,
                (r) =>
                {
                    var objs = r.Table.DataSet.Tables["AcademicRecognition"].Rows[0]["certificate_numbers"];
                    if (objs != null && objs != System.DBNull.Value)
                    {
                        return (objs as IEnumerable<string>).ToList();
                    }
                    else
                    {
                        return new List<string>();
                    }
                });
            mapper.AddFunctionMap<AcademicRecognitionResponseType, List<string>>(r => r.RecognizedSpecialities, (r) =>
            {
                var objs = r.Table.DataSet.Tables["AcademicRecognition"].Rows[0]["recognized_specialities"];
                if (objs != null && objs != System.DBNull.Value)
                {
                    return (objs as IEnumerable<string>).ToList();
                }
                else
                {
                    return new List<string>();
                }
            });


            return mapper;
        }
    }
}
