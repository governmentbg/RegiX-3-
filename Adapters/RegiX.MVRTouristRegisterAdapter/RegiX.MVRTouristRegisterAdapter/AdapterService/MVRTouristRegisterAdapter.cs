using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Linq;
using TechnoLogica.RegiX.Adapters.Common.DataContracts;
using TechnoLogica.RegiX.Adapters.Common.ExportExtension;
using TechnoLogica.RegiX.Common;
using TechnoLogica.RegiX.Common.DataContracts;
using TechnoLogica.RegiX.Common.DataContracts.Parameter;
using TechnoLogica.RegiX.Common.ObjectMapping;
using TechnoLogica.RegiX.Common.Utils;
using TechnoLogica.RegiX.OracleAdapterService;

namespace TechnoLogica.RegiX.MVRTouristRegisterAdapter.AdapterService
{
    [Export(typeof(IAdapterService))]
    [ExportFullName(typeof(MVRTouristRegisterAdapter), typeof(IAdapterService))]
    [ExportSimpleName(typeof(MVRTouristRegisterAdapter), typeof(IAdapterService))]
    public class MVRTouristRegisterAdapter : OracleBaseAdapterService, IMVRTouristRegisterAdapter, IAdapterService
    {
        private Dictionary<string, List<Nomenclature>> _nomenclatures;

        [Export(typeof(ParameterInfo))]
        [ExportFullName(typeof(MVRTouristRegisterAdapter), typeof(ParameterInfo))]
        public static ParameterInfo<string> ConnectionString =
            new ParameterInfo<string>(@"Data Source=(DESCRIPTION = (ADDRESS = (PROTOCOL = TCP)(HOST = giswmrdb)(PORT = 1521))(CONNECT_DATA = (SERVER = DEDICATED)(SERVICE_NAME = giswmr)));User ID=ESTIMVR;Password=ESTIMVR;")
            {
                Key = Constants.ConnectionStringParameterKeyName,
                Description = "Connection String",
                OwnerAssembly = typeof(MVRTouristRegisterAdapter).Assembly
            };

        [Export(typeof(ParameterInfo))]
        [ExportFullName(typeof(MVRTouristRegisterAdapter), typeof(ParameterInfo))]
        public static ParameterInfo<string> PackageName =
            new ParameterInfo<string>(@"accomodation_utils")
            {
                Key = "PackageName",
                Description = "PackageName",
                OwnerAssembly = typeof(MVRTouristRegisterAdapter).Assembly
            };

        public CommonSignedResponse<MvrAccomodationPlaceRequestType, MvrAccomodationPlaceResponseType> SendInfoForEstiAccomodationPlace(MvrAccomodationPlaceRequestType argument, AccessMatrix accessMatrix, AdapterAdditionalParameters additionalParameters)
        {
            bool shouldLogFullRequest = Convert.ToBoolean(ConfigurationManager.AppSettings["LogFullEstiAccomodationPlaceRequest"]);
            var request = shouldLogFullRequest ? argument.XmlSerialize() : argument.UIN.XmlSerialize();

            Guid id = Guid.NewGuid();
            DateTime executionStart = DateTime.Now;
            LogData(additionalParameters, new { Request = request, Guid = id });
            //MVR Wants to be sure that certain CallContext fields are not null. They will be always not null when request is made using RegiXClient
            //but if external system integrates with the adapter and send empty required field in CallContext, we should throw an axception
            // and not allow the operation to continue.
            try
            {
                ValidateCallContext(additionalParameters);
            }
            catch (ArgumentException ex)
            {
                LogError(additionalParameters, ex, new { Request = argument.XmlSerialize(), Guid = id });
                throw ex;
            }
            try
            {
                DbConnection connection = CreateDbConnection(ConnectionString.Value);

                int responseCode = 0;
                try
                {
                    connection.Open();
                    responseCode = this.InsertUpdateAccomodationPlace(connection, argument);
                }
                finally
                {
                    connection.Close();
                }

                var result = new MvrAccomodationPlaceResponseType();
                result.ResponseCode = responseCode;

                LogData(additionalParameters, new { Result = "Success", ExecutionTime = (DateTime.Now - executionStart), Guid = id });
                return SigningUtils.CreateAndSign(
                    argument,
                    result,
                    accessMatrix,
                    additionalParameters
                );
            }
            catch (Exception ex)
            {
                LogError(additionalParameters, ex, new { Guid = id });
                throw;
            }
        }

        public CommonSignedResponse<TouristRegisterRequestType, TouristRegisterResponseType> SendInfoForTouristRegister(TouristRegisterRequestType argument, AccessMatrix accessMatrix, AdapterAdditionalParameters additionalParameters)
        {
            bool shouldLogFullRequest = Convert.ToBoolean(ConfigurationManager.AppSettings["LogFullEstiTouristRegisterRequest"]);
            var request = shouldLogFullRequest ? argument.XmlSerialize() : "";

            Guid id = Guid.NewGuid();
            DateTime executionStart = DateTime.Now;
            LogData(additionalParameters, request);
            //MVR Wants to be sure that certain CallContext fields are not null. They will be always not null when request is made using RegiXClient
            //but if external system integrates with the adapter and send empty required field in CallContext, we should throw an axception
            // and not allow the operation to continue.
            try
            {
                ValidateCallContext(additionalParameters);
            }
            catch (ArgumentException ex)
            {
                LogError(additionalParameters, ex, new { Request = argument.XmlSerialize(), Guid = id });
                throw ex;
            }
            try
            {
                DbConnection connection = CreateDbConnection(ConnectionString.Value);

                int responseCode = 0;
                try
                {
                    connection.Open();
                    responseCode = this.InsertUpdateAccomodationRegister(connection, argument);
                }
                finally
                {
                    connection.Close();
                }

                var result = new TouristRegisterResponseType();
                result.ResponseCode = responseCode;

                LogData(additionalParameters, new { Result = "Success", ExecutionTime = (DateTime.Now - executionStart) });
                return SigningUtils.CreateAndSign(
                    argument,
                    result,
                    accessMatrix,
                    additionalParameters
                );
            }
            catch (Exception ex)
            {
                LogError(additionalParameters, ex, new { Guid = id });
                throw;
            }
        }

        private void InsertUpdateAddress(DbConnection connection, AddressType address, long addressId, string addressProcedureName)
        {
            DbCommand command = new OracleCommand();
            command.Connection = connection;
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = PackageName.Value + addressProcedureName;

            AddParameter(command, "p_id", OracleDbType.Decimal, address.Id);
            AddParameter(command, "p_country_code", OracleDbType.Varchar2, address.GetValueOrNull(x => x.CountryCode));
            AddParameter(command, "p_ekatte", OracleDbType.Varchar2, address.GetValueOrNull(x => x.EKATTE));
            AddParameter(command, "p_post_code", OracleDbType.Varchar2, address.GetValueOrNull(x => x.PostCode));
            AddParameter(command, "p_city_area", OracleDbType.Varchar2, address.GetValueOrNull(x => x.CityArea));
            AddParameter(command, "p_district", OracleDbType.Varchar2, address.GetValueOrNull(x => x.District));
            AddParameter(command, "p_street", OracleDbType.Varchar2, address.GetValueOrNull(x => x.StreetName));
            AddParameter(command, "p_street_number", OracleDbType.Varchar2, address.GetValueOrNull(x => x.StreetNumber));
            AddParameter(command, "p_building_number", OracleDbType.Varchar2, address.GetValueOrNull(x => x.BuildingNumber));
            AddParameter(command, "p_entrance", OracleDbType.Varchar2, address.GetValueOrNull(x => x.Entrance));
            AddParameter(command, "p_floor", OracleDbType.Varchar2, address.GetValueOrNull(x => x.Floor));
            AddParameter(command, "p_apartment", OracleDbType.Varchar2, address.GetValueOrNull(x => x.Apartment));
            AddParameter(command, "p_description", OracleDbType.Varchar2, address.GetValueOrNull(x => x.Description));
            AddParameter(command, "p_street_type", OracleDbType.Varchar2, address.GetValueOrNull(x => x.StreetType));

            var p_successful = AddParameter(command, "p_successful", OracleDbType.Decimal, direction: ParameterDirection.Output);

            command.ExecuteNonQuery();

            var isOperationExecuted = IsOperationExecuted(p_successful);
            if (!isOperationExecuted)
            {
                string message = string.Format("Error occurred while calling procedure {0}", command.CommandText);
                throw new ArgumentException(message);
            }
        }

        private int InsertUpdateAccomodationPlace(DbConnection connection, MvrAccomodationPlaceRequestType argument)
        {
            if (string.IsNullOrEmpty(argument.UIN))
            {
                throw new ArgumentException("Accomodation place uin cannot be null or empty");
            }

            var accomodationPlace = GetAccomodationPlaceByUin(connection, argument.UIN);
            var isAdd = accomodationPlace.Rows.Count == 0;
            var accomodationPlaceId = isAdd ? argument.Id : Convert.ToInt64(accomodationPlace.Rows[0]["id"]);
            var procedureName = isAdd ? ".new_accomodation_place" : ".update_accomodation_place";

            var address = GetAddressById(connection, argument.Address.Id);
            var isAddAddress = address.Rows.Count == 0;
            var addressId = isAddAddress ? argument.Address.Id : Convert.ToInt64(address.Rows[0]["id"]);
            var addressProcedureName = isAddAddress ? ".new_address" : ".update_address";

            this.InsertUpdateAddress(connection, argument.Address, addressId, addressProcedureName);

            DbCommand command = new OracleCommand();
            command.Connection = connection;
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = PackageName.Value + procedureName;

            object accTypeCode = argument.AccomodationPlaceTypeCode;
            object accomodationPlaceTypeId = this.GetIdFromNomenclature(connection, "accomodation_place_type", accTypeCode.ToString());

            object accSubTypeCode = argument.AccomodationPlaceSubTypeCode;
            object accomodationPlaceSubTypeId = DBNull.Value;
            if (accSubTypeCode != null && accSubTypeCode.ToString() != "")
            {
                accomodationPlaceSubTypeId = this.GetIdFromNomenclature(connection, "accomodation_place_subtype", accSubTypeCode.ToString());
            }

            object classType;
            if (argument.ClassSpecified)
            {
                classType = argument.Class.ToString();
            }
            else
            {
                classType = DBNull.Value;
            }

            AddParameter(command, "p_id", OracleDbType.Decimal, accomodationPlaceId);
            AddParameter(command, "p_uin", OracleDbType.Varchar2, argument.UIN);
            AddParameter(command, "p_name", OracleDbType.Varchar2, argument.Name);
            AddParameter(command, "p_accomodation_place_type_id", OracleDbType.Decimal, accomodationPlaceTypeId);
            AddParameter(command, "p_address_id", OracleDbType.Decimal, addressId);
            AddParameter(command, "p_class_type", OracleDbType.Varchar2, classType);
            AddParameter(command, "p_capacity", OracleDbType.Decimal, argument.GetValueOrNull(x => x.Capacity));
            AddParameter(command, "p_rooms", OracleDbType.Decimal, argument.GetValueOrNull(x => x.Rooms));
            AddParameter(command, "p_beds", OracleDbType.Decimal, argument.GetValueOrNull(x => x.Beds));
            AddParameter(command, "p_category_sertificate_number", OracleDbType.Varchar2, argument.GetValueOrNull(x => x.CategorySertificateNumber));
            AddParameter(command, "p_category_sertificate_date", OracleDbType.Date, argument.GetValueOrNull(x => x.CategorySertificateDate));
            AddParameter(command, "p_issue_order_number", OracleDbType.Varchar2, argument.GetValueOrNull(x => x.IssueOrderNumber));
            AddParameter(command, "p_issue_change_number", OracleDbType.Varchar2, argument.GetValueOrNull(x => x.IssueChangeNumber));
            AddParameter(command, "p_issue_cancel_number", OracleDbType.Varchar2, argument.GetValueOrNull(x => x.IssueCancelNumber));
            AddParameter(command, "p_certificate_blocking_date", OracleDbType.Date, argument.GetValueOrNull(x => x.CertificateBlockingDate));
            AddParameter(command, "p_certificate_blocking_period", OracleDbType.Date, argument.GetValueOrNull(x => x.CertificateBlockingPeriod));
            AddParameter(command, "p_web_site", OracleDbType.Varchar2, argument.GetValueOrNull(x => x.WebSite));
            AddParameter(command, "p_email", OracleDbType.Varchar2, argument.GetValueOrNull(x => x.Email));
            AddParameter(command, "p_phone_number", OracleDbType.Varchar2, argument.GetValueOrNull(x => x.Phone));
            AddParameter(command, "p_outdoor_location", OracleDbType.Varchar2, DBNull.Value);
            AddParameter(command, "p_category_code", OracleDbType.Varchar2, argument.GetValueOrNull(x => x.Category));
            AddParameter(command, "p_issue_order_date", OracleDbType.Date, argument.GetValueOrNull(x => x.IssueOrderDate));
            AddParameter(command, "p_issue_change_date", OracleDbType.Date, argument.GetValueOrNull(x => x.IssueChangeDate));
            AddParameter(command, "p_issue_cancel_date", OracleDbType.Date, argument.GetValueOrNull(x => x.IssueCancelDate));
            AddParameter(command, "p_acc_place_subtype_id", OracleDbType.Decimal, accomodationPlaceSubTypeId);
            AddParameter(command, "p_category_sert_valid_date", OracleDbType.Date, argument.GetValueOrNull(x => x.CategoryValidityPeriod));
            AddParameter(command, "p_active_seasion_descr", OracleDbType.Varchar2, argument.GetValueOrNull(x => x.Description));
            AddParameter(command, "p_is_active", OracleDbType.Decimal, argument.IsActive);
            AddParameter(command, "p_lido_id_number", OracleDbType.Varchar2, argument.GetValueOrNull(x => x.LidoNumber));
            AddParameter(command, "p_lido_names", OracleDbType.Varchar2, argument.GetValueOrNull(x => x.LidoNames));
            AddParameter(command, "p_lido_type", OracleDbType.Varchar2, argument.GetValueOrNull(x => x.LidoType));

            var p_successful = AddParameter(command, "p_successful", OracleDbType.Decimal, direction: ParameterDirection.Output);

            command.ExecuteNonQuery();

            var isOperationExecuted = IsOperationExecuted(p_successful);
            if (!isOperationExecuted)
            {
                string message = string.Format("Error occurred while calling procedure {0}", command.CommandText);
                throw new ArgumentException(message);
            }

            var result = isAdd ? 1 : 2;
            return result;
        }

        private int InsertUpdateAccomodationRegister(DbConnection connection, TouristRegisterRequestType argument)
        {
            if (string.IsNullOrEmpty(argument.AccomodationPlaceUIN))
            {
                throw new ArgumentException("Accomodation place uin cannot be null or empty");
            }

            var accomodationPlace = GetAccomodationPlaceByUin(connection, argument.AccomodationPlaceUIN);
            if (accomodationPlace.Rows.Count == 0)
            {
                string message = string.Format("Accomodation place with uin '{0}' was not found in db", argument.AccomodationPlaceUIN);
                throw new ArgumentException(message);
            }

            var accomodationPlaceId = Convert.ToInt64(accomodationPlace.Rows[0]["id"]);

            DbCommand command = new OracleCommand();
            command.Connection = connection;
            command.CommandType = CommandType.StoredProcedure;

            var person = argument.Person;
            var registration = argument.Registration;

            var registrationExists = RegistrationExists(connection, registration.RegistrationUID, accomodationPlaceId);
            var procedureName = registrationExists ? ".update_accomodation" : ".new_accomodation";
            command.CommandText = PackageName.Value + procedureName;

            AddParameter(command, "p_registration_uid", OracleDbType.Varchar2, registration.RegistrationUID);
            AddParameter(command, "p_accomodation_place_id", OracleDbType.Decimal, accomodationPlaceId);
            AddParameter(command, "p_registration_date", OracleDbType.Date, registration.RegistrationDate);
            AddParameter(command, "p_first_name", OracleDbType.Varchar2, person.FirstName);
            AddParameter(command, "p_middle_name", OracleDbType.Varchar2, person.MiddleName);
            AddParameter(command, "p_last_name", OracleDbType.Varchar2, person.FamilyName);
            AddParameter(command, "p_gender_type_code", OracleDbType.Varchar2, person.Sex.ToString());
            AddParameter(command, "p_identity_document_type_code", OracleDbType.Varchar2, person.GetValueOrNull(x => x.IdentityDocumentTypeCode));
            AddParameter(command, "p_identity_document_number", OracleDbType.Varchar2, person.IdentityDocumentNumber);
            AddParameter(command, "p_identity_doc_country_code", OracleDbType.Varchar2, person.IdentityDocumentCountryCode);
            AddParameter(command, "p_egn", OracleDbType.Varchar2, person.Egn);
            AddParameter(command, "p_foreign_number", OracleDbType.Varchar2, person.ForeignNumber);
            AddParameter(command, "p_birth_date", OracleDbType.Date, person.BirthDate);
            AddParameter(command, "p_floor", OracleDbType.Varchar2, registration.Floor);
            AddParameter(command, "p_room", OracleDbType.Varchar2, registration.Room);
            AddParameter(command, "p_check_in_date", OracleDbType.Date, registration.CheckInDate);
            AddParameter(command, "p_check_out_date", OracleDbType.Date, registration.CheckOutDate);
            AddParameter(command, "p_nights_count", OracleDbType.Decimal, registration.NightsCount);
            AddParameter(command, "p_tourist_package", OracleDbType.Decimal, registration.TouristPackage);
            AddParameter(command, "p_avg_night_price", OracleDbType.Decimal, registration.AveragePrice);
            AddParameter(command, "p_is_canceled", OracleDbType.Decimal, registration.GetValueOrNull(r => r.IsCanceled));
            var p_successful = AddParameter(command, "p_successful", OracleDbType.Decimal, direction: ParameterDirection.Output);

            command.ExecuteNonQuery();

            var isOperationExecuted = IsOperationExecuted(p_successful);
            if (!isOperationExecuted)
            {
                string message = string.Format("Error occurred while calling procedure {0}", command.CommandText);
                throw new ArgumentException(message);
            }

            var result = registrationExists ? 2 : 1;
            return result;
        }

        private DataTable GetAccomodationPlaceByUin(DbConnection connection, string accomodationPlaceUin)
        {
            // Винаги ще търси по subUin - частта която е уникална
            DbCommand command = CreateCommand(dbConnection: connection);
            command.CommandType = CommandType.Text;
            command.CommandText = @"select id, address_id from accomodation_place where substr(uin, 0, 6) = :p_uin";

            var subUin = accomodationPlaceUin.Trim().Substring(0, 6);
            this.AddParameter(command, "p_uin", OracleDbType.Varchar2, subUin);

            var adapter = CreateDataAdapter(command);
            var table = new DataTable();
            adapter.Fill(table);

            return table;
        }

        private DataTable GetAddressById(DbConnection connection, long addressId)
        {
            DbCommand command = CreateCommand(dbConnection: connection);
            command.CommandType = CommandType.Text;
            command.CommandText = @"select id from address where id = :p_id";

            this.AddParameter(command, "p_id", OracleDbType.Decimal, addressId);

            var adapter = CreateDataAdapter(command);
            var table = new DataTable();
            adapter.Fill(table);

            return table;
        }

        private bool RegistrationExists(
            DbConnection connection,
            string accomodationRegisterUid,
            long accomodationPlaceId)
        {
            DbCommand command = CreateCommand(dbConnection: connection);
            command.CommandType = CommandType.Text;
            command.CommandText =
            @"
                select registration_uid 
                from accomodation_register 
                where registration_uid = :p_registration_uid and accomodation_place_id = :p_accomodation_place_id
            ";

            this.AddParameter(command, "p_registration_uid", OracleDbType.Varchar2, accomodationRegisterUid);
            this.AddParameter(command, "p_accomodation_place_id", OracleDbType.Decimal, accomodationPlaceId);

            var adapter = CreateDataAdapter(command);
            var table = new DataTable();
            adapter.Fill(table);

            var exists = table.Rows.Count != 0;
            return exists;
        }

        private bool IsOperationExecuted(DbParameter parameter)
        {
            var isExecuted = parameter.Value.ToString() == "1";
            return isExecuted;
        }

        private DbConnection CreateDbConnection(string connectionString)
        {
            DbConnection dbConnection = new OracleConnection(connectionString);
            return dbConnection;
        }

        private DbCommand CreateCommand(string text = null, DbConnection dbConnection = null)
        {
            DbCommand command = new OracleCommand();
            if (text != null)
            {
                command.CommandText = text;
            }

            if (dbConnection != null)
            {
                command.Connection = dbConnection;
            }

            return command;
        }

        private DbDataAdapter CreateDataAdapter(DbCommand command)
        {
            DbDataAdapter dataAdapter = new OracleDataAdapter();
            dataAdapter.SelectCommand = command;
            return dataAdapter;
        }

        private DbParameter CreateParameter(string parameterName, OracleDbType parameterType, object value = null, ParameterDirection direction = ParameterDirection.Input)
        {
            var parameter = new OracleParameter(parameterName, oraType: parameterType)
            {
                Direction = direction
            };

            if (value != null)
            {
                parameter.Value = value;
            }

            return parameter;
        }

        private DbParameter AddParameter(DbCommand command, string parameterName, OracleDbType parameterType, object value = null, ParameterDirection direction = ParameterDirection.Input)
        {
            var parameter = this.CreateParameter(parameterName, parameterType, value, direction);
            command.Parameters.Add(parameter);
            return parameter;
        }

        private long GetIdFromNomenclature(DbConnection connection, string table, string code)
        {
            var nomenclatures = GetNomenclatures(connection, table);
            var result = nomenclatures[table].FirstOrDefault(x => x.Code == code);
            return result.Id;
        }

        // Singleton pattern: ако номенклатурите са празни ги попълва, иначе ги връща
        private Dictionary<string, List<Nomenclature>> GetNomenclatures(DbConnection connection, string tableName)
        {
            if (this._nomenclatures == null)
            {
                this._nomenclatures = new Dictionary<string, List<Nomenclature>>();
            }

            if (this._nomenclatures.ContainsKey(tableName))
            {
                return this._nomenclatures;
            }

            string sql = "select id, code from " + tableName;
            DbCommand command = CreateCommand(sql, connection);
            DataTable table = new DataTable();
            CreateDataAdapter(command).Fill(table);
            var list = GetDataFromTable(table);
            this._nomenclatures.Add(tableName, list);

            return this._nomenclatures;
        }

        private List<Nomenclature> GetDataFromTable(DataTable table)
        {
            var result = table.Rows.Cast<DataRow>().Select(x => new Nomenclature
            {
                Id = Convert.ToInt64(x.ItemArray[0]),
                Code = x.ItemArray[1].ToString(),
            }).ToList();

            return result;
        }

        internal class Nomenclature
        {
            public long Id { get; set; }

            public string Code { get; set; }
        }

        private void ValidateCallContext(AdapterAdditionalParameters additionalParameters)
        {
            if (string.IsNullOrEmpty(additionalParameters.CallContext.EmployeeIdentifier))
            {
                Exception ex = new ArgumentException("EmployeeIdentifier parameter is required in CallContext");
                throw ex;
            }
            if (string.IsNullOrEmpty(additionalParameters.CallContext.EmployeeNames))
            {
                Exception ex = new ArgumentException("EmployeeNames parameter is required in CallContext");
                throw ex;
            }
            if (string.IsNullOrEmpty(additionalParameters.CallContext.ServiceURI))
            {
                Exception ex = new ArgumentException("ServiceURI parameter is required in CallContext");
                throw ex;
            }
            if (string.IsNullOrEmpty(additionalParameters.CallContext.ServiceType))
            {
                Exception ex = new ArgumentException("ServiceType parameter is required in CallContext");
                throw ex;
            }
            if (string.IsNullOrEmpty(additionalParameters.CallContext.LawReason))
            {
                Exception ex = new ArgumentException("LawReason parameter is required in CallContext");
                throw ex;
            }
        }
    }
}
