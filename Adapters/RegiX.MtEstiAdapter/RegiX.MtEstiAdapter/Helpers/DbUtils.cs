using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Xml;
using System.Xml.Serialization;
using TechnoLogica.RegiX.Common.DataContracts;
using TechnoLogica.RegiX.Common.Utils;

namespace TechnoLogica.RegiX.MtEstiAdapter.Helpers
{
    // Общ за RegiX.MtEstiAdapter и RegiX.MVRTouristRegisterAdapter
    public abstract class DbUtils
    {
        private const string MissingEkatte = "00000";
        private Dictionary<string, List<Nomenclature>> _nomenclatures;
        private List<string> _countriesWithOnlyStatisticalData;
        private const string NotExistingForeignKey = "{0} \"{1}\" doesn't exist in database";
        private const string NoDataFoundForTable = "No data found for \"{0}\" in table \"{1}\"";
        private const string LidoRequestStatusTypeCode = "SystemGenerated";
        private const long SystemUserId = 0;
        private const long LidoRelationTypeId = 2; // Hardcoded lido type
        private const string BgNationalityCode = "BG";
        private const string MnAdminRole = "MNADMIN";

        protected readonly string connectionString;
        protected readonly bool shouldGenerateEmail;
        protected readonly string estiUrl;
        protected readonly string emailSubject;
        protected readonly string emailBody;
        protected readonly bool shouldInsertLidoRequest;

        public DbUtils(string connectionString, bool shouldGenerateEmail, string estiUrl, string emailSubject, string emailBody, bool shouldInsertLidoRequest)
        {
            this.connectionString = connectionString;
            this.shouldGenerateEmail = shouldGenerateEmail;
            this.estiUrl = estiUrl;
            this.emailSubject = emailSubject;
            this.emailBody = emailBody;
            this.shouldInsertLidoRequest = shouldInsertLidoRequest;
        }

        public abstract DbConnection CreateDbConnection();

        public abstract DbCommand CreateCommand(string text = null, DbConnection dbConnection = null);

        public abstract DbDataAdapter CreateDataAdapter(DbCommand command);

        public abstract DbParameter CreateParameter(string parameterName, CustomDbType parameterType, object value = null, ParameterDirection direction = ParameterDirection.Input);

        public DbParameter AddParameter(DbCommand command, string parameterName, CustomDbType parameterType, object value = null, ParameterDirection direction = ParameterDirection.Input)
        {
            var parameter = this.CreateParameter(parameterName, parameterType, value, direction);
            command.Parameters.Add(parameter);

            // Текущите sql-и са с npgsql параметри (пример @p_test -> :p_test) - В случай че се поддържа и за Oracle:
            //if (this.DatabaseType == DatabaseType.Oracle)
            //{
            //    command.CommandText = command.CommandText.Replace("@" + parameterName, ":" + parameterName);
            //}

            return parameter;
        }

        public object ExtractScalarValue(DbCommand command)
        {
            var result = command.ExecuteScalar();
            return result;

            // В случай че се поддържат и други провайдъри (Oracle примерно)
            //if (this.DatabaseType == DatabaseType.Npgsql)
            //{
            //    var result = command.ExecuteScalar();
            //    return result;
            //}
            //else if (this.DatabaseType == DatabaseType.Oracle)
            //{
            //    var paramId = this.CreateParameter("v_result_id", CustomDbType.Numeric, direction: ParameterDirection.Output);
            //    command.Parameters.Add(paramId);

            //    command.CommandText = command.CommandText += " into :v_result_id";
            //    command.ExecuteNonQuery();

            //    var oracleDecimal = paramId.Value;
            //    var result = oracleDecimal.GetType().GetProperty("Value").GetValue(oracleDecimal);
            //    return result;
            //}
            //else
            //{
            //    throw new ArgumentException(this.DatabaseType.ToString() + " has no implementation for ExecuteScalar");
            //}
        }

        // 1. Главен метод за SendInfoForAccomodationPlace
        public void CompleteOperationAccmodationPlace(
            DbConnection connection,
            AccomodationPlaceRequestType argument,
            out long accomodationPlaceId,
            out int responseCode)
        {
            DbCommand command = this.CreateCommand();
            command.Connection = connection;
            command.CommandType = CommandType.Text;
            command.CommandText =
            @"
                select id, uin, name, address_id, is_active from accomodation_place where uin like @p_uin
            ";

            var argumentUIN = argument.UIN.Trim();
            var parts = argumentUIN.Split('-');
            var startPart = string.Join("-", parts.Take(2)) + '%';
            this.AddParameter(command, "p_uin", CustomDbType.Varchar, startPart);

            var resultDataSet = this.CreateDataAdapter(command);
            DataSet ds = new DataSet();

            resultDataSet.Fill(ds);
            var majorTable = ds.Tables[0];
            var rows = majorTable.Rows.Cast<DataRow>().ToList();
            if (rows.Count == 0)
            {
                // Няма такова място за настаняване в базата -> insert
                this.InsertNewAccomodationPlace(connection, argument, out accomodationPlaceId);
                responseCode = 1;
            }
            else
            {
                // Има и регистрирани (некатегоризирани) обекти които се различават от останалите (завършват на 0)
                if (argumentUIN.Last() == '0')
                {
                    DataRow foundRow = null;
                    foreach (var row in rows)
                    {
                        // Проверка за обекта дали е завършвал със същия последен символ: .Last()
                        var dbUin = row["uin"].ToString();
                        if (dbUin.Last() == argumentUIN.Last())
                        {
                            foundRow = row;
                        }
                    }

                    if (foundRow != null)
                    {
                        this.UpdateExistingAccomodationPlace(connection, argument, foundRow, out accomodationPlaceId);
                        responseCode = 2;
                    }
                    else
                    {
                        this.InsertNewAccomodationPlace(connection, argument, out accomodationPlaceId);
                        responseCode = 1;
                    }
                }
                else
                {
                    var categorizedObjects = rows.Where(x => x["uin"].ToString().Last() != '0').ToList();
                    if (categorizedObjects.Count == 0)
                    {
                        // Няма категоризиран обект, затова insert
                        this.InsertNewAccomodationPlace(connection, argument, out accomodationPlaceId);
                        responseCode = 1;
                    }
                    else
                    {
                        // Има категоризиран обект, следователно update
                        this.UpdateExistingAccomodationPlace(connection, argument, categorizedObjects[0], out accomodationPlaceId);
                        responseCode = 2;
                    }
                }
            }
        }

        // 2. Главен метод за SendInfoForAccomodationRegister
        public AccRegister.AccomodationRegisterResponseType CompleteOperationAccomodationRegister(
            DbConnection connection,
            AccRegister.AccomodationRegisterRequestType argument,
            AdapterAdditionalParameters aditionalParameters,
            out long accomodationPlaceId)
        {
            accomodationPlaceId = 0;
            if (string.IsNullOrEmpty(argument.AccomodationPlaceUIN))
            {
                throw new ArgumentException("AccomodationPlaceUin cannot be null or empty");
            }

            if (string.IsNullOrEmpty(aditionalParameters.OrganizationEIK))
            {
                throw new ArgumentException("ConsumerOID cannot be null or empty");
            }

            using (DbTransaction t = connection.BeginTransaction())
            {
                try
                {
                    var accomodationPlace = this.GetAccomodationPlace(connection, t, argument.AccomodationPlaceUIN);
                    if (accomodationPlace == null)
                    {
                        // МН-то не съществува
                        string message = string.Format("Accomodation place \"{0}\" is not found", argument.AccomodationPlaceUIN);
                        throw new ArgumentException(message);
                    }

                    var oid = accomodationPlace["regix_oid"];
                    if (oid == null || oid == DBNull.Value || string.IsNullOrWhiteSpace(oid.ToString()))
                    {
                        // МН-то няма зададено oid
                        string message = string.Format("Accomodation place \"{0}\" don't have oid in database", argument.AccomodationPlaceUIN);
                        throw new ArgumentException(message);
                    }

                    var placeOid = oid.ToString().Trim();
                    if (placeOid != aditionalParameters.OrganizationEIK)
                    {
                        // Консуматора няма право да променя друго място за настаняване (след проверка по oid)
                        string message = string.Format("You don't have access to accomodation place \"{0}\"", argument.AccomodationPlaceUIN);
                        throw new ArgumentException(message);
                    }

                    accomodationPlaceId = Convert.ToInt64(accomodationPlace["id"]);
                    AccRegister.AccomodationRegisterResponseType result;
                    switch (argument.Change)
                    {
                        case AccRegister.ChangeType.Insert:
                            {
                                var accomodation = argument.InsertAccomodation;
                                string validationMessage = this.ValidateInsertAccomodation(accomodation);
                                if (!string.IsNullOrEmpty(validationMessage))
                                {
                                    throw new ArgumentException(validationMessage);
                                }

                                var registrationUID = accomodation.RegistrationUID;
                                var accRegisterData = this.GetAccomodationRegister(connection, t, accomodationPlaceId, registrationUID);
                                if (accRegisterData.Rows.Count >= 1)
                                {
                                    // При добавяне в това МН, вече има съществуваща регистрация със това uid
                                    string format = "Cannot insert registration. RegistrationUID \"{0}\" already exists for place \"{1}\".";
                                    string message = string.Format(format, registrationUID, argument.AccomodationPlaceUIN);
                                    throw new ArgumentException(message);
                                }

                                result = this.InsertAccomodationRegister(connection, t, argument, accomodationPlaceId);
                            }
                            break;
                        case AccRegister.ChangeType.Update:
                            {
                                string validationMessage = this.ValidateUpdateAccomodation(argument.UpdateAccomodation);
                                if (!string.IsNullOrEmpty(validationMessage))
                                {
                                    throw new ArgumentException(validationMessage);
                                }

                                long registrationId = argument.UpdateAccomodation.RegistrationId;
                                var accRegisterData = this.GetAccomodationRegisterById(connection, t, accomodationPlaceId, registrationId);
                                if (accRegisterData.Rows.Count == 0)
                                {
                                    // При редактиране, не съществува регистрация със това id
                                    string message = string.Format("Cannot update registration. RegistrationId \"{0}\" doesn't exist for place \"{1}\".", registrationId, argument.AccomodationPlaceUIN);
                                    throw new ArgumentException(message);
                                }

                                var isCanceled = Convert.ToBoolean(accRegisterData.Rows[0]["is_canceled"]);
                                if (isCanceled)
                                {
                                    // Не може да се редактира анулирана регистрация
                                    throw new ArgumentException("Cannot update registration. Registration is canceled.");
                                }

                                result = this.UpdateAccomodationRegister(connection, t, argument);
                            }
                            break;
                        case AccRegister.ChangeType.Cancel:
                            {
                                if (argument.CancelAccomodation == null)
                                {
                                    throw new ArgumentException("Element \"CancelAccomodationType\" is required");
                                }

                                long registrationId = argument.CancelAccomodation.RegistrationId;
                                var accRegisterData = this.GetAccomodationRegisterById(connection, t, accomodationPlaceId, registrationId);
                                if (accRegisterData.Rows.Count == 0)
                                {
                                    // При отказване, не съществува регистрация със това id
                                    string message = string.Format("Cannot cancel registration. RegistrationId \"{0}\" doesn't exist for place \"{1}\".", registrationId, argument.AccomodationPlaceUIN);
                                    throw new ArgumentException(message);
                                }

                                var accomodationType = argument.CancelAccomodation;
                                result = this.CancelUpdateAccomodationRegister(connection, t, accomodationType);
                            }
                            break;
                        default:
                            throw new ArgumentException("Invalid option: " + argument.Change.ToString());
                    }

                    t.Commit();
                    return result;
                }
                catch (Exception ex)
                {
                    t.Rollback();
                    throw;
                }
            }
        }

        #region CommonSendInfoForAccomodationPlace

        private void InsertNewAccomodationPlace(DbConnection connection, AccomodationPlaceRequestType argument, out long accomodationPlaceId)
        {
            // В случай на добавяне на ново място за настаняване
            using (DbTransaction t = connection.BeginTransaction())
            {
                try
                {
                    // Добавя се нов адрес
                    var addressId = this.InsertAddress(connection, t, argument.Address, isEkatteRequired: true);

                    // Добавя се мястото за настаняване
                    accomodationPlaceId = this.InsertOrUpdateAccomodationPlace(connection, t, argument, isInsert: true, addressId: addressId);

                    // Редактира информацията за списъка от ЛИДО
                    this.ApplyChangesLidoList(connection, t, argument, accomodationPlaceId, isInsert: true);

                    // Проверява дали промените ще доведат до МН без ЛИДО
                    this.CheckLidosAfterChanges(connection, t, argument, accomodationPlaceId);

                    t.Commit();
                }
                catch (Exception ex)
                {
                    t.Rollback();
                    throw;
                }
            }
        }

        private void UpdateExistingAccomodationPlace(DbConnection connection, AccomodationPlaceRequestType argument, DataRow row, out long accomodationPlaceId)
        {
            // В случай на редактиране на място за настаняване
            using (DbTransaction t = connection.BeginTransaction())
            {
                try
                {
                    // Редактира се текущият адрес
                    var addressId = Convert.ToInt64(row["address_id"]);
                    this.UpdateAddress(connection, t, argument.Address, addressId, isEkatteRequired: true);

                    // Редактира се мястото за настаняване
                    accomodationPlaceId = Convert.ToInt64(row["id"]);
                    this.InsertOrUpdateAccomodationPlace(connection, t, argument, isInsert: false, accomodationPlaceId: accomodationPlaceId);

                    // Редактира информацията за списъка от ЛИДО
                    var previousIsActive = Convert.ToBoolean(row["is_active"]);
                    this.ApplyChangesLidoList(connection, t, argument, accomodationPlaceId, isInsert: false, previousIsActive: previousIsActive);

                    // Проверява дали промените ще доведат до МН без ЛИДО
                    this.CheckLidosAfterChanges(connection, t, argument, accomodationPlaceId);

                    t.Commit();
                }
                catch (Exception ex)
                {
                    t.Rollback();
                    throw;
                }
            }
        }

        private long InsertAddress(
            DbConnection connection,
            DbTransaction transaction,
            AddressType address,
            bool isEkatteRequired)
        {
            DbCommand command = CreateCommand();
            command.Connection = connection;
            command.CommandType = CommandType.Text;
            command.Transaction = transaction;
            command.CommandText =
                @"insert into address
                (
                    country_code,
                    ekatte,
                    post_code,
                    city_area,
                    district,
                    street_type,
                    street,
                    street_number,
                    building_number,
                    entrance,
                    floor,
                    appartment,
                    description,
                    sys_ins_user_id,
                    sys_ins_date
                )
                values
                (
                    @p_country_code,
                    @p_ekatte,
                    @p_post_code,
                    @p_city_area,
                    @p_district,
                    @p_street_type,
                    @p_street,
                    @p_street_number,
                    @p_building_number,
                    @p_entrance,
                    @p_floor,
                    @p_appartment,
                    @p_description,
                    @p_sys_ins_user_id,
                    @p_sys_ins_date
                )
                RETURNING id";

            this.ValidateAddress(connection, transaction, address);

            object ekatte = this.ExtractSettlementEkatteByAddress(connection, transaction, address, isEkatteRequired);
            if (isEkatteRequired && ekatte == null)
            {
                string format = "Couldn't find ekatte for settlement \"{0}\" and municipality \"{1}\". Ekatte is required here. " +
                    "Please specify ekatte or correct names";
                string message = string.Format(format, address.SettlementName, address.MunicipalityName);
                throw new ArgumentException(message);
            }
            ekatte = ekatte != null ? ekatte : MissingEkatte;

            object streetName;
            if (!string.IsNullOrEmpty(address.StreetName))
            {
                streetName = address.StreetName.Trim();
            }
            else
            {
                streetName = DBNull.Value;
            }

            this.AddParameter(command, "p_country_code", CustomDbType.Varchar, address.GetValueOrNull(r => r.CountryCode));
            this.AddParameter(command, "p_ekatte", CustomDbType.Varchar, ekatte);
            this.AddParameter(command, "p_post_code", CustomDbType.Varchar, address.GetValueOrNull(r => r.PostCode));
            this.AddParameter(command, "p_city_area", CustomDbType.Varchar, address.GetValueOrNull(r => r.CityArea));
            this.AddParameter(command, "p_district", CustomDbType.Varchar, address.GetValueOrNull(r => r.District));
            this.AddParameter(command, "p_street_type", CustomDbType.Varchar, address.GetValueOrNull(r => r.StreetType));
            this.AddParameter(command, "p_street", CustomDbType.Varchar, streetName);
            this.AddParameter(command, "p_street_number", CustomDbType.Varchar, address.GetValueOrNull(r => r.StreetNumber));
            this.AddParameter(command, "p_building_number", CustomDbType.Varchar, address.GetValueOrNull(r => r.BuildingNumber));
            this.AddParameter(command, "p_entrance", CustomDbType.Varchar, address.GetValueOrNull(r => r.Entrance));
            this.AddParameter(command, "p_floor", CustomDbType.Varchar, address.GetValueOrNull(r => r.Floor));
            this.AddParameter(command, "p_appartment", CustomDbType.Varchar, address.GetValueOrNull(r => r.Apartment));
            this.AddParameter(command, "p_description", CustomDbType.Varchar, address.GetValueOrNull(r => r.Description));
            this.AddParameter(command, "p_sys_ins_user_id", CustomDbType.Bigint, SystemUserId);
            this.AddParameter(command, "p_sys_ins_date", CustomDbType.Timestamp, DateTime.Now);

            var obj = this.ExtractScalarValue(command);
            long result = Convert.ToInt64(obj);
            return result;
        }

        private void UpdateAddress(
            DbConnection connection,
            DbTransaction transaction,
            AddressType address,
            long addressId,
            bool isEkatteRequired)
        {
            DbCommand command = CreateCommand();
            command.Connection = connection;
            command.CommandType = CommandType.Text;
            command.Transaction = transaction;
            command.CommandText =
            @"
                update address set
                
                country_code = @p_country_code,
                ekatte = @p_ekatte,
                post_code = @p_post_code,
                city_area = @p_city_area,
                district = @p_district,
                street_type = @p_street_type,
                street = @p_street,
                street_number = @p_street_number,
                building_number = @p_building_number,
                entrance = @p_entrance,
                floor = @p_floor,
                appartment = @p_appartment,
                description = @p_description,
                sys_upd_user_id = @p_sys_upd_user_id,
                sys_upd_date = @p_sys_upd_date

                where id = @p_address_id
            ";

            this.ValidateAddress(connection, transaction, address);

            object ekatte = this.ExtractSettlementEkatteByAddress(connection, transaction, address, isEkatteRequired);
            if (isEkatteRequired && ekatte == null)
            {
                string format = "Couldn't find ekatte for settlement \"{0}\" and municipality \"{1}\". Ekatte is required here. " +
                    "Please specify ekatte or correct names";
                string message = string.Format(format, address.SettlementName, address.MunicipalityName);
                throw new ArgumentException(message);
            }
            ekatte = ekatte != null ? ekatte : MissingEkatte;

            object streetName;
            if (!string.IsNullOrEmpty(address.StreetName))
            {
                streetName = address.StreetName.Trim();
            }
            else
            {
                streetName = DBNull.Value;
            }

            this.AddParameter(command, "p_country_code", CustomDbType.Varchar, address.GetValueOrNull(r => r.CountryCode));
            this.AddParameter(command, "p_ekatte", CustomDbType.Varchar, ekatte);
            this.AddParameter(command, "p_post_code", CustomDbType.Varchar, address.GetValueOrNull(r => r.PostCode));
            this.AddParameter(command, "p_city_area", CustomDbType.Varchar, address.GetValueOrNull(r => r.CityArea));
            this.AddParameter(command, "p_district", CustomDbType.Varchar, address.GetValueOrNull(r => r.District));
            this.AddParameter(command, "p_street_type", CustomDbType.Varchar, address.GetValueOrNull(r => r.StreetType));
            this.AddParameter(command, "p_street", CustomDbType.Varchar, streetName);
            this.AddParameter(command, "p_street_number", CustomDbType.Varchar, address.GetValueOrNull(r => r.StreetNumber));
            this.AddParameter(command, "p_building_number", CustomDbType.Varchar, address.GetValueOrNull(r => r.BuildingNumber));
            this.AddParameter(command, "p_entrance", CustomDbType.Varchar, address.GetValueOrNull(r => r.Entrance));
            this.AddParameter(command, "p_floor", CustomDbType.Varchar, address.GetValueOrNull(r => r.Floor));
            this.AddParameter(command, "p_appartment", CustomDbType.Varchar, address.GetValueOrNull(r => r.Apartment));
            this.AddParameter(command, "p_description", CustomDbType.Varchar, address.GetValueOrNull(r => r.Description));
            this.AddParameter(command, "p_sys_upd_user_id", CustomDbType.Bigint, SystemUserId);
            this.AddParameter(command, "p_sys_upd_date", CustomDbType.Timestamp, DateTime.Now);
            this.AddParameter(command, "p_address_id", CustomDbType.Bigint, addressId);

            command.ExecuteNonQuery();
        }

        private void DeleteAddress(
            DbConnection connection,
            DbTransaction transaction,
            long addressId)
        {
            DbCommand command = CreateCommand();
            command.Connection = connection;
            command.CommandType = CommandType.Text;
            command.Transaction = transaction;
            command.CommandText =
                @"delete from address where id = @p_address_id";

            this.AddParameter(command, "p_address_id", CustomDbType.Bigint, addressId);

            command.ExecuteNonQuery();
        }

        public void ValidateAccomodationPlace(AccomodationPlaceRequestType argument)
        {
            var result = new List<string>();

            if (string.IsNullOrEmpty(argument.UIN))
            {
                result.Add("UIN cannot be null or empty");
            }

            //if (string.IsNullOrEmpty(argument.Name))
            //{
            //    result.Add("AccomodationPlace Name cannot be null or empty");
            //}

            //if (argument.Name == "-")
            //{
            //    result.Add("AccomodationPlace Name cannot be '-'");
            //}

            if (result.Count > 0)
            {
                var formatedErrors = result.Select((obj, i) => $"[{i}]: {obj}").ToList();
                string message = this.CombineErrors(formatedErrors);
                throw new ArgumentException(message);
            }
        }

        private void ValidateAddress(
            DbConnection connection,
            DbTransaction transaction,
            AddressType address)
        {
            var result = new List<string>();

            if (!string.IsNullOrEmpty(address.EKATTE))
            {
                // Ако има зададено екатте се проверява в базата
                var dbSettlement = this.GetSettlement(connection, transaction, address.EKATTE);
                if (dbSettlement.Rows.Count != 1)
                {
                    string message = string.Format(NotExistingForeignKey, "EKATTE", address.EKATTE);
                    result.Add(message);
                }
            }

            var countryCody = address.CountryCode;
            var dbCountry = this.GetCountry(connection, transaction, countryCody);
            if (dbCountry.Rows.Count != 1)
            {
                string message = string.Format(NotExistingForeignKey, "CountryCode", countryCody);
                result.Add(message);
            }

            if (result.Count > 0)
            {
                var formatedErrors = result.Select((obj, i) => $"[{i}]: {obj}").ToList();
                string message = this.CombineErrors(formatedErrors);
                throw new ArgumentException(message);
            }
        }

        private DataTable GetProvinceCode(
            DbConnection connection,
            DbTransaction transaction,
            string provinceName)
        {
            if (string.IsNullOrEmpty(provinceName))
            {
                return null;
            }

            DbCommand command = CreateCommand();
            command.Connection = connection;
            command.CommandType = CommandType.Text;
            command.Transaction = transaction;
            command.CommandText =
                @"select code from province where LOWER(name) = LOWER(@p_name)";

            this.AddParameter(command, "p_name", CustomDbType.Varchar, provinceName);

            var adapter = CreateDataAdapter(command);
            var table = new DataTable();
            adapter.Fill(table);

            return table;
        }

        private DataTable GetMunicipalityData(
            DbConnection connection,
            DbTransaction transaction,
            string municipalityName)
        {
            if (string.IsNullOrEmpty(municipalityName))
            {
                return null;
            }

            DbCommand command = CreateCommand();
            command.Connection = connection;
            command.CommandType = CommandType.Text;
            command.Transaction = transaction;
            command.CommandText =
                @"select code, name from municipality where LOWER(name) = LOWER(@p_name)";

            this.AddParameter(command, "p_name", CustomDbType.Varchar, municipalityName);

            var adapter = CreateDataAdapter(command);
            var table = new DataTable();
            adapter.Fill(table);

            return table;
        }

        private string ExtractSettlementEkatteByAddress(
            DbConnection connection,
            DbTransaction transaction,
            AddressType address,
            bool isEkatteRequired)
        {
            // Ако има екатте, връщаме него
            if (!string.IsNullOrEmpty(address.EKATTE))
            {
                return address.EKATTE;
            }

            // Няма смисъл да търсим ако няма населено място
            if (string.IsNullOrEmpty(address.SettlementName))
            {
                return null;
            }

            var provinceData = this.GetProvinceCode(connection, transaction, address.ProvinceName);
            var municipalityData = this.GetMunicipalityData(connection, transaction, address.MunicipalityName);

            if (municipalityData == null || municipalityData.Rows.Count == 0)
            {
                // Не може да се намери общината
                return null;
            }

            // Търсене само по община, може да има повече от една със същото име затова не е по код
            // Взимаме го от базата понеже е сравнено с case insensitive
            var municipalityName = municipalityData.Rows[0]["name"];

            DbCommand command = CreateCommand();
            command.Connection = connection;
            command.CommandType = CommandType.Text;
            command.Transaction = transaction;
            if (provinceData == null || provinceData.Rows.Count == 0)
            {
                command.CommandText =
                @"
                    select settlement_code, settlement_name
                    from ekatte
                    where municipality_name = @p_municipality_name
                ";

                this.AddParameter(command, "p_municipality_name", CustomDbType.Varchar, municipalityName);
            }
            else
            {
                // Търсене по област и община
                var provinceCode = provinceData.Rows[0]["code"];
                command.CommandText =
                @"
                    select settlement_code, settlement_name
                    from ekatte
                    where province_code = @p_province_code and municipality_name = @p_municipality_name
                ";

                this.AddParameter(command, "p_province_code", CustomDbType.Varchar, provinceCode);
                this.AddParameter(command, "p_municipality_name", CustomDbType.Varchar, municipalityName);
            }

            var adapter = CreateDataAdapter(command);
            var table = new DataTable();
            adapter.Fill(table);

            if (table.Rows.Count == 0)
            {
                // Няма данни за населени места за тази община
                return null;
            }

            var settlements = table.Rows.Cast<DataRow>()
                .Select(x => new
                {
                    SettlementCode = x["settlement_code"].ToString(),
                    SettlementName = x["settlement_name"].ToString(),
                }).ToList();

            var filtered = settlements
                .Where(x => Contains(address.SettlementName, x.SettlementName, StringComparison.InvariantCultureIgnoreCase))
                .ToList();

            if (filtered.Count == 0)
            {
                return null;
            }

            if (filtered.Count == 1)
            {
                return filtered[0].SettlementCode;
            }

            var exactMatch = settlements
                .Where(x => address.SettlementName.ToLower() == x.SettlementName.ToLower())
                .ToList();

            if (exactMatch != null)
            {
                if (exactMatch.Count == 1)
                {
                    return exactMatch.FirstOrDefault().SettlementCode;
                }
                else
                {
                    // Има повече от едно населено място
                    if (string.IsNullOrEmpty(address.ProvinceName))
                    {
                        string format = "Cannot insert address! There are multiple settlements with name \"{0}\". Please specify province or ekatte.";
                        string message = string.Format(format, address.SettlementName);

                        if (isEkatteRequired)
                        {
                            throw new ArgumentException(message);
                        }
                        else
                        {
                            return null;
                        }
                    }

                    // И трите параметъра са зададени и има поне 2 населени места
                    // Тогава няма как да разберем ЕКАТТЕ-то
                    return null;
                }
            }

            return null;
        }

        private long InsertOrUpdateAccomodationPlace(
            DbConnection connection,
            DbTransaction transaction,
            AccomodationPlaceRequestType argument,
            bool isInsert,
            long? addressId = null,
            long? accomodationPlaceId = null)
        {
            DbCommand command = CreateCommand();
            command.Connection = connection;
            command.CommandType = CommandType.Text;
            command.Transaction = transaction;

            if (isInsert)
            {
                command.CommandText =
                @"insert into accomodation_place
                (
                    uin,
                    name,
                    accomodation_place_type_id,
                    class_type,
                    capacity,
                    rooms,
                    beds,
                    category_sertificate_number,
                    category_sertificate_date,
                    category_sertificate_valid_date,
                    issue_order_number,
                    issue_change_number,
                    issue_cancel_number,
                    issue_order_date,
                    issue_change_date,
                    issue_cancel_date,
                    certificate_blocking_date,
                    certificate_blocking_period,
                    web_site,
                    email,
                    phone_number,
                    category_code,
                    accomodation_place_subtype_id,
                    active_seasion_descr,
                    is_active,

                    address_id,
                    sys_ins_user_id,
                    sys_ins_date
                )
                values
                (
                    @p_uin,
                    @p_name,
                    @p_accomodation_place_type_id,
                    @p_class_type,
                    @p_capacity,
                    @p_rooms,
                    @p_beds,
                    @p_category_sertificate_number,
                    @p_category_sertificate_date,
                    @p_category_sertificate_valid_date,
                    @p_issue_order_number,
                    @p_issue_change_number,
                    @p_issue_cancel_number,
                    @p_issue_order_date,
                    @p_issue_change_date,
                    @p_issue_cancel_date,
                    @p_certificate_blocking_date,
                    @p_certificate_blocking_period,
                    @p_web_site,
                    @p_email,
                    @p_phone_number,
                    @p_category_code,
                    @p_accomodation_place_subtype_id,
                    @p_active_seasion_descr,
                    @p_is_active,

                    @p_address_id,
                    @p_sys_ins_user_id,
                    @p_sys_ins_date
                )
                RETURNING id";
            }
            else
            {
                command.CommandText =
                @"
                    update accomodation_place set
                
                    uin = @p_uin,
                    name = @p_name,
                    accomodation_place_type_id = @p_accomodation_place_type_id,
                    class_type = @p_class_type,
                    capacity = @p_capacity,
                    rooms = @p_rooms,
                    beds = @p_beds,
                    category_sertificate_number = @p_category_sertificate_number,
                    category_sertificate_date = @p_category_sertificate_date,
                    category_sertificate_valid_date = @p_category_sertificate_valid_date,
                    issue_order_number = @p_issue_order_number,
                    issue_change_number = @p_issue_change_number,
                    issue_cancel_number = @p_issue_cancel_number,
                    issue_order_date = @p_issue_order_date,
                    issue_change_date = @p_issue_change_date,
                    issue_cancel_date = @p_issue_cancel_date,
                    certificate_blocking_date = @p_certificate_blocking_date,
                    certificate_blocking_period = @p_certificate_blocking_period,
                    web_site = @p_web_site,
                    email = @p_email,
                    phone_number = @p_phone_number,
                    category_code = @p_category_code,
                    accomodation_place_subtype_id = @p_accomodation_place_subtype_id,
                    active_seasion_descr = @p_active_seasion_descr,
                    is_active = @p_is_active,

                    sys_upd_user_id = @p_sys_upd_user_id,
                    sys_upd_date = @p_sys_upd_date
                    
                    where id = @p_accomodation_place_id
                ";
            }

            object classType = argument.GetValueOrNull(r => r.Class);
            if (classType != DBNull.Value)
            {
                var cls = classType.ToString();
                classType = (cls == "С") ? "В" : cls; // Опция "С" е стара и показва обекти от клас В
            }

            object category = argument.GetValueOrNull(r => r.Category);
            category = this.GetLongValue(this.GetXmlEnumAttributeValue(category));
            object capacity = this.GetLongValue(argument.GetValueOrNull(r => r.Capacity));
            object rooms = this.GetLongValue(argument.GetValueOrNull(r => r.Rooms));
            object beds = this.GetLongValue(argument.GetValueOrNull(r => r.Beds));

            // Set required accPlaceTypeCode
            if (string.IsNullOrEmpty(argument.AccomodationPlaceTypeCode))
            {
                throw new ArgumentException("AccomodationPlaceTypeCode cannot be null");
            }
            object accTypeCode = argument.AccomodationPlaceTypeCode;
            object accomodationPlaceTypeId = this.GetIdFromNomenclature(connection, "accomodation_place_type", accTypeCode.ToString());

            // Set optional accPlaceSubTypeCode
            object accSubTypeCode = argument.AccomodationPlaceSubTypeCode;
            object accomodationPlaceSubTypeId = DBNull.Value;
            if (accSubTypeCode != null && accSubTypeCode.ToString() != "")
            {
                accomodationPlaceSubTypeId = this.GetIdFromNomenclature(connection, "accomodation_place_subtype", accSubTypeCode.ToString());
            }

            object email;
            if (string.IsNullOrEmpty(argument.Email))
            {
                // No spaces
                email = DBNull.Value;
            }
            else
            {
                email = argument.Email.Trim();
            }

            object issueChangeNumber;
            if (string.IsNullOrEmpty(argument.IssueChangeNumber))
            {
                // No spaces
                issueChangeNumber = DBNull.Value;
            }
            else
            {
                issueChangeNumber = argument.IssueChangeNumber.Trim();
            }

            object name = (argument.Name != null ? argument.Name.Trim() : ""); // Not null in db

            this.AddParameter(command, "p_uin", CustomDbType.Varchar, argument.GetValueOrNull(r => r.UIN));
            this.AddParameter(command, "p_name", CustomDbType.Varchar, name);
            this.AddParameter(command, "p_accomodation_place_type_id", CustomDbType.Bigint, accomodationPlaceTypeId);
            this.AddParameter(command, "p_class_type", CustomDbType.Varchar, classType);
            this.AddParameter(command, "p_capacity", CustomDbType.Integer, capacity);
            this.AddParameter(command, "p_rooms", CustomDbType.Integer, rooms);
            this.AddParameter(command, "p_beds", CustomDbType.Integer, beds);
            this.AddParameter(command, "p_category_sertificate_number", CustomDbType.Varchar, argument.GetValueOrNull(r => r.CategorySertificateNumber));
            this.AddParameter(command, "p_category_sertificate_date", CustomDbType.Date, argument.GetValueOrNull(r => r.CategorySertificateDate));
            this.AddParameter(command, "p_category_sertificate_valid_date", CustomDbType.Date, argument.GetValueOrNull(r => r.CategoryValidityPeriod));
            this.AddParameter(command, "p_issue_order_number", CustomDbType.Varchar, argument.GetValueOrNull(r => r.IssueOrderNumber));
            this.AddParameter(command, "p_issue_change_number", CustomDbType.Varchar, issueChangeNumber);
            this.AddParameter(command, "p_issue_cancel_number", CustomDbType.Varchar, argument.GetValueOrNull(r => r.IssueCancelNumber));
            this.AddParameter(command, "p_issue_order_date", CustomDbType.Timestamp, argument.GetValueOrNull(r => r.IssueOrderDate));
            this.AddParameter(command, "p_issue_change_date", CustomDbType.Date, argument.GetValueOrNull(r => r.IssueChangeDate));
            this.AddParameter(command, "p_issue_cancel_date", CustomDbType.Date, argument.GetValueOrNull(r => r.IssueCancelDate));
            this.AddParameter(command, "p_certificate_blocking_date", CustomDbType.Date, argument.GetValueOrNull(r => r.CertificateBlockingDate));
            this.AddParameter(command, "p_certificate_blocking_period", CustomDbType.Date, argument.GetValueOrNull(r => r.CertificateBlockingPeriod));
            this.AddParameter(command, "p_web_site", CustomDbType.Varchar, argument.GetValueOrNull(r => r.WebSite));
            this.AddParameter(command, "p_email", CustomDbType.Varchar, email);
            this.AddParameter(command, "p_phone_number", CustomDbType.Varchar, argument.GetValueOrNull(r => r.Phone));
            this.AddParameter(command, "p_category_code", CustomDbType.Bigint, category);
            this.AddParameter(command, "p_accomodation_place_subtype_id", CustomDbType.Bigint, accomodationPlaceSubTypeId);
            this.AddParameter(command, "p_active_seasion_descr", CustomDbType.Varchar, argument.GetValueOrNull(r => r.Description));
            this.AddParameter(command, "p_is_active", CustomDbType.Boolean, argument.GetValueOrNull(r => r.IsActive));

            if (isInsert)
            {
                this.AddParameter(command, "p_address_id", CustomDbType.Bigint, addressId);
                this.AddParameter(command, "p_sys_ins_user_id", CustomDbType.Bigint, SystemUserId);
                this.AddParameter(command, "p_sys_ins_date", CustomDbType.Timestamp, DateTime.Now);

                var obj = this.ExtractScalarValue(command);
                long result = Convert.ToInt64(obj);
                return result;
            }
            else
            {
                this.AddParameter(command, "p_sys_upd_user_id", CustomDbType.Bigint, SystemUserId);
                this.AddParameter(command, "p_sys_upd_date", CustomDbType.Timestamp, DateTime.Now);
                this.AddParameter(command, "p_accomodation_place_id", CustomDbType.Bigint, accomodationPlaceId);

                command.ExecuteNonQuery();
                return accomodationPlaceId.Value;
            }
        }

        private void RemoveAccPlaceUsers(
            DbConnection connection,
            DbTransaction transaction,
            long accomodationPlaceId)
        {
            DbCommand command = CreateCommand();
            command.Connection = connection;
            command.CommandType = CommandType.Text;
            command.Transaction = transaction;
            command.CommandText =
            @"
                delete from acc_place_user
                where accomodation_place_id = @p_accomodation_place_id
            ";

            this.AddParameter(command, "p_accomodation_place_id", CustomDbType.Bigint, accomodationPlaceId);
            command.ExecuteNonQuery();
        }

        private void InsertEmailEvents(
            DbConnection connection,
            DbTransaction transaction,
            EmailType emailType,
            string guid)
        {
            if (!this.shouldGenerateEmail)
            {
                return;
            }

            DbCommand command = CreateCommand();
            command.Connection = connection;
            command.CommandType = CommandType.Text;
            command.Transaction = transaction;
            command.CommandText =
            @"
                insert into email_events
                (
                    email,
                    subject,
                    body,
                    execution_start_date
                )
                values
                (
                    @p_email,
                    @p_subject,
                    @p_body,
                    @p_execution_start_date
                )
            ";

            string estiUrl = this.estiUrl;
            string subject = this.emailSubject;
            string bodyTemplate = this.emailBody;
            string publicUrl = estiUrl + guid;
            string body = string.Format(bodyTemplate, publicUrl);

            this.AddParameter(command, "p_email", CustomDbType.Varchar, emailType.EmailText);
            this.AddParameter(command, "p_subject", CustomDbType.Varchar, subject);
            this.AddParameter(command, "p_body", CustomDbType.Varchar, body);
            this.AddParameter(command, "p_execution_start_date", CustomDbType.Timestamp, DateTime.Now);

            command.ExecuteNonQuery();
        }

        private void UpdatePersonLidoWithAccomodationPlace(
            DbConnection connection,
            DbTransaction transaction,
            PersonType personLido,
            LidoDataType lidoDataType,
            string uin,
            long accomodationPlaceId)
        {
            ChangeLidoType changeType = lidoDataType.Change;

            this.ValidatePersonLido(personLido);

            // Изтегляне на данни за лидо от базата
            var table = this.GetPersonLido(connection, transaction, personLido);
            var identityDocumentTypeId = this.ExtractIdentityDocTypeId(connection, personLido);

            long personId;
            if (table.Rows.Count == 0)
            {
                // Не съществува такова, следователно insert
                personId = this.InsertPersonLido(connection, transaction, personLido, identityDocumentTypeId);

                // Ако има email, insert в lido_request със статус "SystemGenerated" и insert в email_events
                // След като си получи мейла, променя данни ако има нужда и от системно генерирана става чакаща
                if (personLido.Email != null && personLido.Email.Count > 0)
                {
                    var email = personLido.Email.OrderBy(x => x.EmailTypeCode).FirstOrDefault();
                    var phone = personLido.Phone.OrderBy(x => x.PhoneTypeCode).FirstOrDefault();

                    if (this.shouldInsertLidoRequest && !string.IsNullOrEmpty(email.EmailText) && IsValidEmail(email.EmailText))
                    {
                        string guid;
                        var lidoRequestStatusId = this.GetIdFromNomenclature(connection, "lido_request_status_type", LidoRequestStatusTypeCode);
                        this.InsertPersonRequestLido(connection, transaction, personLido, email, phone, personId, lidoRequestStatusId, identityDocumentTypeId, out guid);
                        this.InsertEmailEvents(connection, transaction, email, guid);
                    }
                }
            }
            else
            {
                personId = Convert.ToInt64(table.Rows[0]["id"]);

                // Винаги ще се update-ва, може да има промяна в информацията
                this.UpdatePersonLido(connection, transaction, personLido, identityDocumentTypeId, personId);
            }

            // Промяната на Лидо се прави всеки път, а по връзката Лидо-МН няма какво да се променя
            // Затова тук се прави проверка, ако е Update и няма връзка да се интерпретира като insert
            if (changeType == ChangeLidoType.Update)
            {
                var existingLink = this.GetAccPlacePerson(connection, transaction, accomodationPlaceId, personId);
                if (existingLink.Rows.Count == 0)
                {
                    changeType = ChangeLidoType.Insert;
                }
            }

            switch (changeType)
            {
                case ChangeLidoType.Insert:
                    {
                        // Всяко лидо има МН-та, на МН-тата техните супер потребителите се взимат
                        // Ще се добавят връзки на техните супер потребители с новото МН
                        var currentUsersFromLido = GetMnAdminUsersForPerson(connection, transaction, personId);
                        var userIdsFromLido = currentUsersFromLido.Rows.Cast<DataRow>().Select(x => Convert.ToInt64(x["id"])).ToList();

                        // Намират се текущите супер потребители на МН-то
                        var currentUsersFromPlace = GetMnAdminUsersForAccomodationPlace(connection, transaction, accomodationPlaceId);
                        var userIdsFromPlace = currentUsersFromPlace.Rows.Cast<DataRow>().Select(x => Convert.ToInt64(x["id"])).ToList();

                        // Премахваме тези за които имат вече съществуваща връзка (има unique constraint)
                        // И за останалите добавяме връзка User-AccPlace
                        var userIds = userIdsFromLido.Where(x => !userIdsFromPlace.Contains(x)).ToList();
                        this.InsertAccPlaceUsers(connection, transaction, accomodationPlaceId, userIds);

                        // Добавяне на връзка ЛИДО-МН (различна таблица при Person и LegalPerson)
                        // Прави се след user-ите понеже след insert на връзка AccPlace-Lido потребителя ще се повтаря
                        this.InsertAccPlacePerson(connection, transaction, personLido, uin, accomodationPlaceId, personId);
                    }
                    break;
                case ChangeLidoType.Delete:
                    {
                        // Премахване на връзка Лидо - МН (и потребителите на МН)
                        this.RemoveLinksAccPlacePerson(connection, transaction, accomodationPlaceId, personId);

                        bool hasChangeNumber = !string.IsNullOrEmpty(lidoDataType.IssueChangeNumber);
                        bool hasChangeDate = lidoDataType.IssueChangeDateSpecified && lidoDataType.IssueChangeDate != default(DateTime);
                        if (hasChangeNumber && hasChangeDate)
                        {
                            // Промяна в обстоятелствата, премахват се потребителите на МН-то
                            this.RemoveAccPlaceUsers(connection, transaction, accomodationPlaceId);
                        }
                    }
                    break;
            }

            // Промяна по много-много таблиците
            this.InsertOrUpdatePersonAddresses(connection, transaction, personLido, personId);
            this.InsertOrUpdatePersonPhones(connection, transaction, personLido, personId);
            this.InsertOrUpdatePersonEmails(connection, transaction, personLido, personId);
        }

        private void UpdateLegalLidoWithAccomodationPlace(
            DbConnection connection,
            DbTransaction transaction,
            LegalPersonType legalLido,
            LidoDataType lidoDataType,
            string uin,
            long accomodationPlaceId)
        {
            ChangeLidoType changeType = lidoDataType.Change;

            this.ValidateLegalLido(legalLido);

            // Изтегляне на данни за лидо от базата
            var table = this.GetLegalPersonLido(connection, transaction, legalLido);

            long legalPersonId;
            if (table.Rows.Count == 0)
            {
                // Не съществува такова, следователно insert
                legalPersonId = this.InsertLegalPersonLido(connection, transaction, legalLido);

                // Ако има email, insert в lido_request със статус "SystemGenerated" и insert в email_events
                if (legalLido.Email != null && legalLido.Email.Count > 0)
                {
                    var email = legalLido.Email.OrderBy(x => x.EmailTypeCode).FirstOrDefault();
                    var phone = legalLido.Phone.OrderBy(x => x.PhoneTypeCode).FirstOrDefault();

                    if (this.shouldInsertLidoRequest && !string.IsNullOrEmpty(email.EmailText) && IsValidEmail(email.EmailText))
                    {
                        string guid;
                        var lidoRequestStatusId = this.GetIdFromNomenclature(connection, "lido_request_status_type", LidoRequestStatusTypeCode);
                        this.InsertLegalPersonRequestLido(connection, transaction, legalLido, email, phone, legalPersonId, lidoRequestStatusId, out guid);
                        this.InsertEmailEvents(connection, transaction, email, guid);
                    }
                }
            }
            else
            {
                legalPersonId = Convert.ToInt64(table.Rows[0]["id"]);

                // Винаги ще се update-ва, може да има промяна в информацията
                this.UpdateLegalPersonLido(connection, transaction, legalLido, legalPersonId);
            }

            // Промяната на Лидо се прави всеки път, а по връзката Лидо-МН няма какво да се променя
            // Затова тук се прави проверка, ако е Update и няма връзка да се интерпретира като insert
            if (changeType == ChangeLidoType.Update)
            {
                var existingLink = this.GetAccPlaceLegalPerson(connection, transaction, accomodationPlaceId, legalPersonId);
                if (existingLink.Rows.Count == 0)
                {
                    changeType = ChangeLidoType.Insert;
                }
            }

            switch (changeType)
            {
                case ChangeLidoType.Insert:
                    {
                        // Всяко лидо има МН-та, на МН-тата техните супер потребителите се взимат
                        // Ще се добавят връзки на техните супер потребители с новото МН
                        var currentUsersFromLido = GetMnAdminUsersForLegalPerson(connection, transaction, legalPersonId);
                        var userIdsFromLido = currentUsersFromLido.Rows.Cast<DataRow>().Select(x => Convert.ToInt64(x["id"])).ToList();

                        // Намират се текущите супер потребители на МН-то
                        var currentUsersFromPlace = GetMnAdminUsersForAccomodationPlace(connection, transaction, accomodationPlaceId);
                        var userIdsFromPlace = currentUsersFromPlace.Rows.Cast<DataRow>().Select(x => Convert.ToInt64(x["id"])).ToList();

                        // Премахваме тези за които имат вече съществуваща връзка (има unique constraint)
                        // И за останалите добавяме връзка User-AccPlace
                        var userIds = userIdsFromLido.Where(x => !userIdsFromPlace.Contains(x)).ToList();
                        this.InsertAccPlaceUsers(connection, transaction, accomodationPlaceId, userIds);

                        // Добавяне на връзка ЛИДО-МН (различна таблица при Person и LegalPerson)
                        // Прави се след user-ите понеже след insert на връзка AccPlace-Lido потребителя ще се повтаря
                        this.InsertAccPlaceLegalPerson(connection, transaction, legalLido, uin, accomodationPlaceId, legalPersonId);
                    }
                    break;
                case ChangeLidoType.Delete:
                    {
                        // Премахване на връзка Лидо - МН (и потребителите на МН)
                        this.RemoveLinksAccPlaceLegalPerson(connection, transaction, accomodationPlaceId, legalPersonId);

                        bool hasChangeNumber = !string.IsNullOrEmpty(lidoDataType.IssueChangeNumber);
                        bool hasChangeDate = lidoDataType.IssueChangeDateSpecified && lidoDataType.IssueChangeDate != default(DateTime);
                        if (hasChangeNumber && hasChangeDate)
                        {
                            // Промяна в обстоятелствата, премахват се потребителите на МН-то
                            this.RemoveAccPlaceUsers(connection, transaction, accomodationPlaceId);
                        }
                    }
                    break;
            }

            // Промяна по много-много таблиците
            this.InsertOrUpdateLegalPersonAddresses(connection, transaction, legalLido, legalPersonId);
            this.InsertOrUpdateLegalPersonPhones(connection, transaction, legalLido, legalPersonId);
            this.InsertOrUpdateLegalPersonEmails(connection, transaction, legalLido, legalPersonId);
        }

        private DataTable GetMnAdminUsersForAccomodationPlace(DbConnection connection, DbTransaction transaction, long accomodationPlaceId)
        {
            // За дадено МН - Активни супер потребители или такива които още не са си потвърдили акаунта (такива които са блокирани)
            DbCommand command = CreateCommand();
            command.Connection = connection;
            command.CommandType = CommandType.Text;
            command.Transaction = transaction;
            command.CommandText = this.GetAccomodationPlaceUsersQuery();

            this.AddParameter(command, "p_accomodation_place_id", CustomDbType.Bigint, accomodationPlaceId);
            this.AddParameter(command, "p_role_name", CustomDbType.Varchar, MnAdminRole);

            var adapter = CreateDataAdapter(command);
            var table = new DataTable();
            adapter.Fill(table);

            return table;
        }

        private DataTable GetMnAdminUsersForPerson(DbConnection connection, DbTransaction transaction, long personId)
        {
            // Активни МН супер потребители или такива които още не са си потвърдили акаунта (такива които са блокирани)
            DbCommand command = CreateCommand();
            command.Connection = connection;
            command.CommandType = CommandType.Text;
            command.Transaction = transaction;
            command.CommandText = this.GetLidoUsersQuery("acc_place_person", "person_id");

            this.AddParameter(command, "p_lido_id", CustomDbType.Bigint, personId);
            this.AddParameter(command, "p_role_name", CustomDbType.Varchar, MnAdminRole);

            var adapter = CreateDataAdapter(command);
            var table = new DataTable();
            adapter.Fill(table);

            return table;
        }

        private DataTable GetMnAdminUsersForLegalPerson(
            DbConnection connection,
            DbTransaction transaction,
            long legalPersonId)
        {
            // Активни МН супер потребители или такива които още не са си потвърдили акаунта (такива които са блокирани)
            DbCommand command = CreateCommand();
            command.Connection = connection;
            command.CommandType = CommandType.Text;
            command.Transaction = transaction;
            command.CommandText = this.GetLidoUsersQuery("acc_place_legal_person", "legal_person_id");

            this.AddParameter(command, "p_lido_id", CustomDbType.Bigint, legalPersonId);
            this.AddParameter(command, "p_role_name", CustomDbType.Varchar, MnAdminRole);

            var adapter = CreateDataAdapter(command);
            var table = new DataTable();
            adapter.Fill(table);

            return table;
        }

        private string GetLidoUsersQuery(string tableName, string columnName)
        {
            return @"
                select distinct 
                    au.user_id as id
                from " + tableName + @" app
                join acc_place_user au on app.accomodation_place_id = au.accomodation_place_id
                join users u on au.user_id = u.id
                join user_role r on u.user_role_id = r.id
                where 
                    app." + columnName + @" = @p_lido_id and
                    r.name = @p_role_name and 
                    (u.email_confirmed = false or u.is_active)";
        }

        private string GetAccomodationPlaceUsersQuery()
        {
            return @"
                select distinct 
	                au.user_id as id
                from acc_place_user au
                join users u on au.user_id = u.id
                join user_role r on u.user_role_id = r.id
                where 
	                au.accomodation_place_id = @p_accomodation_place_id and
                    r.name = @p_role_name and 
	                (u.email_confirmed = false or u.is_active)";
        }

        private DataTable GetSettlement(
            DbConnection connection,
            DbTransaction transaction,
            string ekatte)
        {
            DbCommand command = CreateCommand();
            command.Connection = connection;
            command.CommandType = CommandType.Text;
            command.Transaction = transaction;
            command.CommandText =
                @"select ekatte from settlement where ekatte = @p_ekatte";

            this.AddParameter(command, "p_ekatte", CustomDbType.Varchar, ekatte);

            var adapter = CreateDataAdapter(command);
            var table = new DataTable();
            adapter.Fill(table);

            return table;
        }

        private DataTable GetCountry(
            DbConnection connection,
            DbTransaction transaction,
            string countryCode)
        {
            DbCommand command = CreateCommand();
            command.Connection = connection;
            command.CommandType = CommandType.Text;
            command.Transaction = transaction;
            command.CommandText =
                @"select code from country where code = @p_code";

            this.AddParameter(command, "p_code", CustomDbType.Varchar, countryCode);

            var adapter = CreateDataAdapter(command);
            var table = new DataTable();
            adapter.Fill(table);

            return table;
        }

        private void ApplyChangesLidoList(
            DbConnection connection,
            DbTransaction transaction,
            AccomodationPlaceRequestType argument,
            long accomodationPlaceId,
            bool isInsert,
            bool? previousIsActive = null)
        {
            if (argument.IsActive)
            {
                var orderedLido = this.OrderLidoData(argument.LidoData);
                if (orderedLido.Count != 0 && !IsEmpty(orderedLido.XmlSerialize()))
                {
                    foreach (var lido in orderedLido)
                    {
                        // При insert или първият елемент е наличен или вторият
                        // При update може да няма данни за лидо, понеже се променя само атрибутна информация
                        if (lido.LidoLegal != null && !IsEmpty(lido.LidoLegal.XmlSerialize()))
                        {
                            this.UpdateLegalLidoWithAccomodationPlace(connection, transaction, lido.LidoLegal, lido, argument.UIN, accomodationPlaceId);
                        }
                        else if (lido.LidoPerson != null && !IsEmpty(lido.LidoPerson.XmlSerialize()))
                        {
                            this.UpdatePersonLidoWithAccomodationPlace(connection, transaction, lido.LidoPerson, lido, argument.UIN, accomodationPlaceId);
                        }
                        else if (isInsert)
                        {
                            throw new ArgumentException("Lido is required when insert new accomodation place");
                        }
                    }
                }
                else if (isInsert)
                {
                    // When no lido element
                    throw new ArgumentException("Lido is required when insert new accomodation place");
                }
                else if (!isInsert && previousIsActive == false)
                {
                    // When updating element with status false, it must have lido
                    // All links were erased when the place was sent before with IsActive=false
                    throw new ArgumentException("When changing `IsActive` from false to true, lido is required with `Change`=Insert (Previous data for the connection Lido-Place have been removed)");
                }
            }
            else
            {
                // В случай когато предишни данни за това място за настаняване са били грешни
                // Премахват се връзките на мястото с ЛИДО, което вътрешно премахва и потребителите на МН-то

                // Физическо лице
                var personLidos = this.GetAccPlaceAllPersons(connection, transaction, accomodationPlaceId);
                foreach (DataRow item in personLidos.Rows)
                {
                    var personId = Convert.ToInt64(item["person_id"]);
                    this.RemoveLinksAccPlacePerson(connection, transaction, accomodationPlaceId, personId);

                    // Премахва потребителите на МН-то
                    this.RemoveAccPlaceUsers(connection, transaction, accomodationPlaceId);
                }

                // Юридическо лице
                var legalPersonLidos = this.GetAccPlaceAllLegalPersons(connection, transaction, accomodationPlaceId);
                foreach (DataRow item in legalPersonLidos.Rows)
                {
                    var legalPersonId = Convert.ToInt64(item["legal_person_id"]);
                    this.RemoveLinksAccPlaceLegalPerson(connection, transaction, accomodationPlaceId, legalPersonId);

                    // Премахва потребителите на МН-то
                    this.RemoveAccPlaceUsers(connection, transaction, accomodationPlaceId);
                }
            }
        }

        public void CheckLidosAfterChanges(
            DbConnection connection,
            DbTransaction transaction,
            AccomodationPlaceRequestType argument,
            long accomodationPlaceId)
        {
            if (argument.IsActive)
            {
                // Само в случай когато мястото е активно
                // Когато не е, данните за връзките се изтриват и не трябва да се прави проверка
                var personLidos = this.GetAccPlaceAllPersons(connection, transaction, accomodationPlaceId);
                var legalPersonLidos = this.GetAccPlaceAllLegalPersons(connection, transaction, accomodationPlaceId);

                var totalLidoCount = personLidos.Rows.Count + legalPersonLidos.Rows.Count;
                if (totalLidoCount == 0)
                {
                    throw new ArgumentException("Operation cannot be completed. This request will leave the given place without lido");
                }
            }
        }

        #endregion

        #region PersonLido

        private void ValidatePersonLido(PersonType lido)
        {
            var number = lido.IdentityNumber?.Trim();
            if (string.IsNullOrEmpty(number))
            {
                throw new ArgumentException("PersonLido `IdentityNumber` is required");
            }

            bool isValid = ValidatePersonalDataHelper.ValidatePersonNumber(number);
            if (!isValid)
            {
                throw new ArgumentException("PersonLido `IdentityNumber` does not meet validity constraints");
            }
        }

        private DataTable GetPersonLido(
            DbConnection connection,
            DbTransaction transaction,
            PersonType lido)
        {
            DbCommand command = CreateCommand();
            command.Connection = connection;
            command.CommandType = CommandType.Text;
            command.Transaction = transaction;
            command.CommandText =
                @"select id from person where egn = @p_identifier or foreign_number = @p_identifier"; // TODO: change?

            this.AddParameter(command, "p_identifier", CustomDbType.Varchar, lido.IdentityNumber);

            var adapter = CreateDataAdapter(command);
            var table = new DataTable();
            adapter.Fill(table);

            return table;
        }

        private long InsertPersonLido(
            DbConnection connection,
            DbTransaction transaction,
            PersonType lido,
            object identityDocumentTypeId)
        {
            DbCommand command = CreateCommand();
            command.Connection = connection;
            command.CommandType = CommandType.Text;
            command.Transaction = transaction;
            command.CommandText =
                @"insert into person
                (
                    identity_document_type_id,
                    identity_document_number,
                    identity_document_country_code,
                    egn,
                    foreign_number,
                    first_name,
                    middle_name,
                    last_name,
                    sys_ins_user_id,
                    sys_ins_date
                )
                values
                (
                    @p_identity_document_type_id,
                    @p_identity_document_number,
                    @p_identity_document_country_code,
                    @p_egn,
                    @p_foreign_number,
                    @p_first_name,
                    @p_middle_name,
                    @p_last_name,
                    @p_sys_ins_user_id,
                    @p_sys_ins_date
                )
                RETURNING id";

            var egnLnchStruct = this.ExtractEgnLnch(lido);
            object egn = egnLnchStruct.Item1;
            object lnch = egnLnchStruct.Item2;

            this.AddParameter(command, "p_identity_document_type_id", CustomDbType.Bigint, identityDocumentTypeId);
            this.AddParameter(command, "p_identity_document_number", CustomDbType.Varchar, lido.GetValueOrNull(r => r.IdentityDocumentNumber));
            this.AddParameter(command, "p_identity_document_country_code", CustomDbType.Varchar, lido.GetValueOrNull(r => r.IdentityDocumentCountryCode));
            this.AddParameter(command, "p_egn", CustomDbType.Varchar, egn);
            this.AddParameter(command, "p_foreign_number", CustomDbType.Varchar, lnch);
            this.AddParameter(command, "p_first_name", CustomDbType.Varchar, lido.GetValueOrNull(r => r.FirstName));
            this.AddParameter(command, "p_middle_name", CustomDbType.Varchar, lido.GetValueOrNull(r => r.MiddleName));
            this.AddParameter(command, "p_last_name", CustomDbType.Varchar, lido.GetValueOrNull(r => r.LastName));
            this.AddParameter(command, "p_sys_ins_user_id", CustomDbType.Bigint, SystemUserId);
            this.AddParameter(command, "p_sys_ins_date", CustomDbType.Timestamp, DateTime.Now);

            var obj = this.ExtractScalarValue(command);
            long id = Convert.ToInt64(obj);
            return id;
        }

        private void UpdatePersonLido(
            DbConnection connection,
            DbTransaction transaction,
            PersonType lido,
            object identityDocumentTypeId,
            long personId)
        {
            DbCommand command = CreateCommand();
            command.Connection = connection;
            command.CommandType = CommandType.Text;
            command.Transaction = transaction;
            command.CommandText =
            @"
                update person set

                identity_document_type_id = @p_identity_document_type_id,
                identity_document_number = @p_identity_document_number,
                identity_document_country_code = @p_identity_document_country_code,
                egn = @p_egn,
                foreign_number = @p_foreign_number,
                first_name = @p_first_name,
                middle_name = @p_middle_name,
                last_name = @p_last_name,
                sys_upd_user_id = @p_sys_upd_user_id,
                sys_upd_date = @p_sys_upd_date

                where id = @p_id
            ";

            var egnLnchStruct = this.ExtractEgnLnch(lido);
            object egn = egnLnchStruct.Item1;
            object lnch = egnLnchStruct.Item2;

            this.AddParameter(command, "p_identity_document_type_id", CustomDbType.Bigint, identityDocumentTypeId);
            this.AddParameter(command, "p_identity_document_number", CustomDbType.Varchar, lido.GetValueOrNull(r => r.IdentityDocumentNumber));
            this.AddParameter(command, "p_identity_document_country_code", CustomDbType.Varchar, lido.GetValueOrNull(r => r.IdentityDocumentCountryCode));
            this.AddParameter(command, "p_egn", CustomDbType.Varchar, egn);
            this.AddParameter(command, "p_foreign_number", CustomDbType.Varchar, lnch);
            this.AddParameter(command, "p_first_name", CustomDbType.Varchar, lido.GetValueOrNull(r => r.FirstName));
            this.AddParameter(command, "p_middle_name", CustomDbType.Varchar, lido.GetValueOrNull(r => r.MiddleName));
            this.AddParameter(command, "p_last_name", CustomDbType.Varchar, lido.GetValueOrNull(r => r.LastName));
            this.AddParameter(command, "p_sys_upd_user_id", CustomDbType.Bigint, SystemUserId);
            this.AddParameter(command, "p_sys_upd_date", CustomDbType.Timestamp, DateTime.Now);
            this.AddParameter(command, "p_id", CustomDbType.Bigint, personId);

            command.ExecuteNonQuery();
        }

        private DataTable GetAccPlaceAllPersons(
            DbConnection connection,
            DbTransaction transaction,
            long accomodationPlaceId)
        {
            DbCommand command = CreateCommand();
            command.Connection = connection;
            command.CommandType = CommandType.Text;
            command.Transaction = transaction;
            command.CommandText =
            @"
                select person_id from acc_place_person 
                where accomodation_place_id = @p_accomodation_place_id
            ";

            this.AddParameter(command, "p_accomodation_place_id", CustomDbType.Bigint, accomodationPlaceId);

            var adapter = CreateDataAdapter(command);
            var table = new DataTable();
            adapter.Fill(table);

            return table;
        }

        private DataTable GetAccPlacePerson(
            DbConnection connection,
            DbTransaction transaction,
            long accomodationPlaceId,
            long personId)
        {
            DbCommand command = CreateCommand();
            command.Connection = connection;
            command.CommandType = CommandType.Text;
            command.Transaction = transaction;
            command.CommandText =
            @"
                select id from acc_place_person 
                where accomodation_place_id = @p_accomodation_place_id and
                    person_id = @p_person_id
            ";

            this.AddParameter(command, "p_accomodation_place_id", CustomDbType.Bigint, accomodationPlaceId);
            this.AddParameter(command, "p_person_id", CustomDbType.Bigint, personId);

            var adapter = CreateDataAdapter(command);
            var table = new DataTable();
            adapter.Fill(table);

            return table;
        }

        private void InsertAccPlaceUsers(
            DbConnection connection,
            DbTransaction transaction,
            long accomodationPlaceId,
            List<long> userIds)
        {
            foreach (var userId in userIds)
            {
                DbCommand command = CreateCommand();
                command.Connection = connection;
                command.CommandType = CommandType.Text;
                command.Transaction = transaction;
                command.CommandText =
                @"
                    insert into acc_place_user
                    (
                        accomodation_place_id,
                        user_id,
                        sys_ins_user_id,
                        sys_ins_date
                    )
                    values
                    (
                        @p_accomodation_place_id,
                        @p_user_id,
                        @p_sys_ins_user_id,
                        @p_sys_ins_date
                    )
                ";

                this.AddParameter(command, "p_accomodation_place_id", CustomDbType.Bigint, accomodationPlaceId);
                this.AddParameter(command, "p_user_id", CustomDbType.Bigint, userId);
                this.AddParameter(command, "p_sys_ins_user_id", CustomDbType.Bigint, SystemUserId);
                this.AddParameter(command, "p_sys_ins_date", CustomDbType.Timestamp, DateTime.Now);

                command.ExecuteNonQuery();
            }
        }

        private void InsertAccPlacePerson(
            DbConnection connection,
            DbTransaction transaction,
            PersonType personLido,
            string uin,
            long accomodationPlaceId,
            long personId)
        {
            var existingAccPlacePerson = this.GetAccPlacePerson(connection, transaction, accomodationPlaceId, personId);
            if (existingAccPlacePerson.Rows.Count != 0)
            {
                string format = "Cannot insert link between person lido \"{0}\" and accomodation place \"{1}\". There is already existing record!";
                string message = string.Format(format, personLido.IdentityNumber, uin);
                throw new ArgumentException(message);
            }

            DbCommand command = CreateCommand();
            command.Connection = connection;
            command.CommandType = CommandType.Text;
            command.Transaction = transaction;
            command.CommandText =
            @"
                insert into acc_place_person
                (
                    accomodation_place_id,
                    acc_place_relation_type_id,
                    sys_ins_user_id,
                    sys_ins_date,
                    person_id
                )
                values
                (
                    @p_accomodation_place_id,
                    @p_acc_place_relation_type_id,
                    @p_sys_ins_user_id,
                    @p_sys_ins_date,
                    @p_person_id
                )
            ";

            this.AddParameter(command, "p_accomodation_place_id", CustomDbType.Bigint, accomodationPlaceId);
            this.AddParameter(command, "p_acc_place_relation_type_id", CustomDbType.Bigint, LidoRelationTypeId);
            this.AddParameter(command, "p_sys_ins_user_id", CustomDbType.Bigint, SystemUserId);
            this.AddParameter(command, "p_sys_ins_date", CustomDbType.Timestamp, DateTime.Now);
            this.AddParameter(command, "p_person_id", CustomDbType.Bigint, personId);

            command.ExecuteNonQuery();
        }

        private void RemoveLinksAccPlacePerson(
            DbConnection connection,
            DbTransaction transaction,
            long accomodationPlaceId,
            long personId)
        {
            // Изтрива връзката МН-Лидо
            DbCommand command = CreateCommand();
            command.Connection = connection;
            command.CommandType = CommandType.Text;
            command.Transaction = transaction;
            command.CommandText =
            @"
                delete from acc_place_person
                where accomodation_place_id = @p_accomodation_place_id and
                    person_id = @p_person_id and
                    acc_place_relation_type_id = @p_acc_place_relation_type_id
            ";

            this.AddParameter(command, "p_accomodation_place_id", CustomDbType.Bigint, accomodationPlaceId);
            this.AddParameter(command, "p_person_id", CustomDbType.Bigint, personId);
            this.AddParameter(command, "p_acc_place_relation_type_id", CustomDbType.Bigint, LidoRelationTypeId);

            command.ExecuteNonQuery();
        }

        private void InsertPersonAddress(
            DbConnection connection,
            DbTransaction transaction,
            AddressType addressType,
            long personId)
        {
            DbCommand command = CreateCommand();
            command.Connection = connection;
            command.CommandType = CommandType.Text;
            command.Transaction = transaction;
            command.CommandText =
            @"
                insert into person_address
                (
                    person_id,
                    address_type_id,
                    address_id,
                    sys_ins_user_id,
                    sys_ins_date
                )
                values
                (
                    @p_person_id,
                    @p_address_type_id,
                    @p_address_id,
                    @p_sys_ins_user_id,
                    @p_sys_ins_date
                )
            ";

            var addressId = this.InsertAddress(connection, transaction, addressType, isEkatteRequired: false);
            var addressTypeId = this.GetIdFromNomenclature(connection, "address_type", addressType.AdressTypeCode.ToString());

            this.AddParameter(command, "p_person_id", CustomDbType.Bigint, personId);
            this.AddParameter(command, "p_address_type_id", CustomDbType.Bigint, addressTypeId);
            this.AddParameter(command, "p_address_id", CustomDbType.Bigint, addressId);
            this.AddParameter(command, "p_sys_ins_user_id", CustomDbType.Bigint, SystemUserId);
            this.AddParameter(command, "p_sys_ins_date", CustomDbType.Timestamp, DateTime.Now);

            command.ExecuteNonQuery();
        }

        private void InsertPersonPhone(
            DbConnection connection,
            DbTransaction transaction,
            PhoneType phoneType,
            long personId)
        {
            DbCommand command = CreateCommand();
            command.Connection = connection;
            command.CommandType = CommandType.Text;
            command.Transaction = transaction;
            command.CommandText =
            @"
                insert into person_phone
                (
                    phone_type_id,
                    phone_number,
                    sys_ins_user_id,
                    sys_ins_date,
                    person_id
                )
                values
                (
                    @p_phone_type_id,
                    @p_phone_number,
                    @p_sys_ins_user_id,
                    @p_sys_ins_date,
                    @p_person_id
                )
            ";

            var phoneTypeId = this.GetIdFromNomenclature(connection, "phone_type", phoneType.PhoneTypeCode.ToString());
            var phoneParam = phoneType == null ? "" : phoneType.PhoneNumber != null ? phoneType.PhoneNumber.Trim() : "";

            this.AddParameter(command, "p_phone_type_id", CustomDbType.Bigint, phoneTypeId);
            this.AddParameter(command, "p_phone_number", CustomDbType.Varchar, phoneParam);
            this.AddParameter(command, "p_sys_ins_user_id", CustomDbType.Bigint, SystemUserId);
            this.AddParameter(command, "p_sys_ins_date", CustomDbType.Timestamp, DateTime.Now);
            this.AddParameter(command, "p_person_id", CustomDbType.Bigint, personId);

            command.ExecuteNonQuery();
        }

        private void InsertPersonEmail(
            DbConnection connection,
            DbTransaction transaction,
            EmailType emailType,
            long personId)
        {
            DbCommand command = CreateCommand();
            command.Connection = connection;
            command.CommandType = CommandType.Text;
            command.Transaction = transaction;
            command.CommandText =
            @"
                insert into person_email
                (
                    person_id,
                    email_type_id,
                    email,
                    sys_ins_user_id,
                    sys_ins_date
                )
                values
                (
                    @p_person_id,
                    @p_email_type_id,
                    @p_email,
                    @p_sys_ins_user_id,
                    @p_sys_ins_date
                )
            ";

            var emailTypeId = this.GetIdFromNomenclature(connection, "email_type", emailType.EmailTypeCode.ToString());

            this.AddParameter(command, "p_person_id", CustomDbType.Bigint, personId);
            this.AddParameter(command, "p_email_type_id", CustomDbType.Bigint, emailTypeId);
            this.AddParameter(command, "p_email", CustomDbType.Varchar, emailType.EmailText);
            this.AddParameter(command, "p_sys_ins_user_id", CustomDbType.Bigint, SystemUserId);
            this.AddParameter(command, "p_sys_ins_date", CustomDbType.Timestamp, DateTime.Now);

            command.ExecuteNonQuery();
        }

        private DataTable GetPersonAddress(
            DbConnection connection,
            DbTransaction transaction,
            long personId)
        {
            DbCommand command = CreateCommand();
            command.Connection = connection;
            command.CommandType = CommandType.Text;
            command.Transaction = transaction;
            command.CommandText =
                @"select id, address_type_id, address_id
                from person_address 
                where person_id = @p_person_id";

            this.AddParameter(command, "p_person_id", CustomDbType.Bigint, personId);

            var adapter = CreateDataAdapter(command);
            var table = new DataTable();
            adapter.Fill(table);

            return table;
        }

        private DataTable GetPersonPhone(
            DbConnection connection,
            DbTransaction transaction,
            long personId)
        {
            DbCommand command = CreateCommand();
            command.Connection = connection;
            command.CommandType = CommandType.Text;
            command.Transaction = transaction;
            command.CommandText =
                @"select id, phone_type_id 
                from person_phone 
                where person_id = @p_person_id";

            this.AddParameter(command, "p_person_id", CustomDbType.Bigint, personId);

            var adapter = CreateDataAdapter(command);
            var table = new DataTable();
            adapter.Fill(table);

            return table;
        }

        private DataTable GetPersonEmail(
            DbConnection connection,
            DbTransaction transaction,
            long personId)
        {
            DbCommand command = CreateCommand();
            command.Connection = connection;
            command.CommandType = CommandType.Text;
            command.Transaction = transaction;
            command.CommandText =
                @"select id, email_type_id
                from person_email 
                where person_id = @p_person_id";

            this.AddParameter(command, "p_person_id", CustomDbType.Bigint, personId);

            var adapter = CreateDataAdapter(command);
            var table = new DataTable();
            adapter.Fill(table);

            return table;
        }

        private void DeletePersonAddress(
            DbConnection connection,
            DbTransaction transaction,
            long personAddressId)
        {
            DbCommand command = CreateCommand();
            command.Connection = connection;
            command.CommandType = CommandType.Text;
            command.Transaction = transaction;
            command.CommandText =
                @"delete from person_address where id = @p_person_address_id";

            this.AddParameter(command, "p_person_address_id", CustomDbType.Bigint, personAddressId);

            command.ExecuteNonQuery();
        }

        private void DeletePersonPhone(
            DbConnection connection,
            DbTransaction transaction,
            long personPhoneId)
        {
            DbCommand command = CreateCommand();
            command.Connection = connection;
            command.CommandType = CommandType.Text;
            command.Transaction = transaction;
            command.CommandText =
                @"delete from person_phone where id = @p_person_phone_id";

            this.AddParameter(command, "p_person_phone_id", CustomDbType.Bigint, personPhoneId);

            command.ExecuteNonQuery();
        }

        private void DeletePersonEmail(
            DbConnection connection,
            DbTransaction transaction,
            long personEmailId)
        {
            DbCommand command = CreateCommand();
            command.Connection = connection;
            command.CommandType = CommandType.Text;
            command.Transaction = transaction;
            command.CommandText =
                @"delete from person_email where id = @p_person_email_id";

            this.AddParameter(command, "p_person_email_id", CustomDbType.Bigint, personEmailId);

            command.ExecuteNonQuery();
        }

        private void UpdateSinglePersonPhone(
            DbConnection connection,
            DbTransaction transaction,
            PhoneType phoneType,
            long personPhoneId)
        {
            DbCommand command = CreateCommand();
            command.Connection = connection;
            command.CommandType = CommandType.Text;
            command.Transaction = transaction;
            command.CommandText =
            @"
                update person_phone set

                phone_type_id = @p_phone_type_id,
                phone_number = @p_phone_number,
                sys_upd_user_id = @p_sys_upd_user_id,
                sys_upd_date = @p_sys_upd_date
                
                where id = @p_person_phone_id
            ";

            var phoneTypeId = this.GetIdFromNomenclature(connection, "phone_type", phoneType.PhoneTypeCode.ToString());
            var phoneParam = phoneType == null ? "" : phoneType.PhoneNumber != null ? phoneType.PhoneNumber.Trim() : "";

            this.AddParameter(command, "p_phone_type_id", CustomDbType.Bigint, phoneTypeId);
            this.AddParameter(command, "p_phone_number", CustomDbType.Varchar, phoneParam);
            this.AddParameter(command, "p_sys_upd_user_id", CustomDbType.Bigint, SystemUserId);
            this.AddParameter(command, "p_sys_upd_date", CustomDbType.Timestamp, DateTime.Now);
            this.AddParameter(command, "p_person_phone_id", CustomDbType.Bigint, personPhoneId);

            command.ExecuteNonQuery();
        }

        private void UpdateSinglePersonEmail(
            DbConnection connection,
            DbTransaction transaction,
            EmailType emailType,
            long personEmailId)
        {
            DbCommand command = CreateCommand();
            command.Connection = connection;
            command.CommandType = CommandType.Text;
            command.Transaction = transaction;
            command.CommandText =
            @"
                update person_email set

                email_type_id = @p_email_type_id,
                email = @p_email,
                sys_upd_user_id = @p_sys_upd_user_id,
                sys_upd_date = @p_sys_upd_date
                
                where id = @p_person_email_id
            ";

            var emailTypeId = this.GetIdFromNomenclature(connection, "email_type", emailType.EmailTypeCode.ToString());

            this.AddParameter(command, "p_email_type_id", CustomDbType.Bigint, emailTypeId);
            this.AddParameter(command, "p_email", CustomDbType.Varchar, emailType.GetValueOrNull(r => r.EmailText));
            this.AddParameter(command, "p_sys_upd_user_id", CustomDbType.Bigint, SystemUserId);
            this.AddParameter(command, "p_sys_upd_date", CustomDbType.Timestamp, DateTime.Now);
            this.AddParameter(command, "p_person_email_id", CustomDbType.Bigint, personEmailId);

            command.ExecuteNonQuery();
        }

        private void InsertOrUpdatePersonAddresses(
            DbConnection connection,
            DbTransaction transaction,
            PersonType lido,
            long personId)
        {
            if (lido.Address == null)
            {
                // Ако няма нови данни за адрес, то тези в базата ще се изтриват
                lido.Address = new List<AddressType>();
            }

            // Извличане на текущите данни за адреси от базата
            var previousAddressTable = this.GetPersonAddress(connection, transaction, personId);
            var previousAddresses = previousAddressTable.Rows.Cast<DataRow>().Select(x => new LidoLink
            {
                Id = x.ItemArray[0],
                TypeId = x.ItemArray[1],
                PrimaryId = x.ItemArray[2],
            }).ToList();

            // Валидация за повтаряне
            var allTypes = lido.Address.Select(x => x.AdressTypeCode).ToList();
            var distinctTypes = allTypes.Distinct().ToList();
            if (allTypes.Count != distinctTypes.Count)
            {
                throw new ArgumentException("You can't have multiple addresses with one AdressTypeCode");
            }

            // Update ако същестува в базата, иначе insert
            foreach (var addressType in lido.Address)
            {
                var addressTypeId = this.GetIdFromNomenclature(connection, "address_type", addressType.AdressTypeCode.ToString());
                var dbLidoAddress = previousAddresses.FirstOrDefault(x => x.TypeId.Equals(addressTypeId));
                if (dbLidoAddress == null)
                {
                    // Няма такова, следователно insert
                    this.InsertPersonAddress(connection, transaction, addressType, personId);
                }
                else
                {
                    // Не се update-ва много-много таблицата, понеже цялата информация се реферира през address_id
                    var addressId = Convert.ToInt64(dbLidoAddress.PrimaryId);
                    this.UpdateAddress(connection, transaction, addressType, addressId, isEkatteRequired: false);
                    dbLidoAddress.IsUpdated = true;
                }
            }

            // Ако не са били променени, се изтриват понеже е добавен нов адрес
            var nonUpdatedLinks = previousAddresses.Where(x => !x.IsUpdated);
            foreach (var link in nonUpdatedLinks)
            {
                var personAddressId = Convert.ToInt64(link.Id);
                this.DeletePersonAddress(connection, transaction, personAddressId);

                var addressId = Convert.ToInt64(link.PrimaryId);
                this.DeleteAddress(connection, transaction, addressId);
            }
        }

        private void InsertOrUpdatePersonPhones(
            DbConnection connection,
            DbTransaction transaction,
            PersonType lido,
            long personId)
        {
            if (lido.Phone == null)
            {
                // Ако няма нови данни за адрес, то тези в базата ще се изтриват
                lido.Phone = new List<PhoneType>();
            }

            // Извличане на текущите данни за адреси от базата
            var previousPhoneTable = this.GetPersonPhone(connection, transaction, personId);
            var previousPhones = previousPhoneTable.Rows.Cast<DataRow>().Select(x => new LidoLink
            {
                Id = x.ItemArray[0],
                TypeId = x.ItemArray[1],
            }).ToList();

            // Валидация за повтаряне
            var allTypes = lido.Phone.Select(x => x.PhoneTypeCode).ToList();
            var distinctTypes = allTypes.Distinct().ToList();
            if (allTypes.Count != distinctTypes.Count)
            {
                throw new ArgumentException("You can't have multiple phones with one PhoneTypeCode");
            }

            // Update ако същестува в базата, иначе insert
            foreach (var phoneType in lido.Phone)
            {
                if (string.IsNullOrEmpty(phoneType.PhoneNumber))
                {
                    continue;
                }

                var phoneTypeId = this.GetIdFromNomenclature(connection, "phone_type", phoneType.PhoneTypeCode.ToString());
                var dbLidoPhone = previousPhones.FirstOrDefault(x => x.TypeId.Equals(phoneTypeId));
                if (dbLidoPhone == null)
                {
                    // Няма такова, следователно insert
                    this.InsertPersonPhone(connection, transaction, phoneType, personId);
                }
                else
                {
                    // Иначе update на много-много таблицата
                    var personPhoneId = Convert.ToInt64(dbLidoPhone.Id);
                    this.UpdateSinglePersonPhone(connection, transaction, phoneType, personPhoneId);
                    dbLidoPhone.IsUpdated = true;
                }
            }

            // Ако не са били променени, се изтриват понеже е добавен нов адрес
            var nonUpdatedLinks = previousPhones.Where(x => !x.IsUpdated);
            foreach (var link in nonUpdatedLinks)
            {
                var personPhoneId = Convert.ToInt64(link.Id);
                this.DeletePersonPhone(connection, transaction, personPhoneId);
            }
        }

        private void InsertOrUpdatePersonEmails(
            DbConnection connection,
            DbTransaction transaction,
            PersonType lido,
            long personId)
        {
            if (lido.Email == null || lido.Email.Count == 0)
            {
                // Ако няма нови данни за мейли, то няма да се прави нищо
                // Тоест ако е имало преди данни за мейли, те не се пипат, нито се добавят нови редове със празни стойности
                return;
            }

            // Валидация за повтаряне
            var allTypes = lido.Email.Select(x => x.EmailTypeCode).ToList();
            var distinctTypes = allTypes.Distinct().ToList();
            if (allTypes.Count != distinctTypes.Count)
            {
                throw new ArgumentException("You can't have multiple emails with one EmailTypeCode");
            }

            // Извличане на текущите данни за адреси от базата
            var previousEmailTable = this.GetPersonEmail(connection, transaction, personId);
            var previousEmails = previousEmailTable.Rows.Cast<DataRow>().Select(x => new LidoLink
            {
                Id = x.ItemArray[0],
                TypeId = x.ItemArray[1],
            }).ToList();

            // Update ако същестува в базата, иначе insert
            foreach (var emailType in lido.Email)
            {
                // Валидация по емайл, ако не мине няма да се добавят или редактират данните в базата
                if (!string.IsNullOrEmpty(emailType.EmailText) && IsValidEmail(emailType.EmailText))
                {
                    var emailTypeId = this.GetIdFromNomenclature(connection, "email_type", emailType.EmailTypeCode.ToString());
                    var dbLidoEmail = previousEmails.FirstOrDefault(x => x.TypeId.Equals(emailTypeId));
                    if (dbLidoEmail == null)
                    {
                        // Няма такова, следователно insert
                        this.InsertPersonEmail(connection, transaction, emailType, personId);
                    }
                    else
                    {
                        // Иначе update на много-много таблицата
                        var personEmailId = Convert.ToInt64(dbLidoEmail.Id);
                        this.UpdateSinglePersonEmail(connection, transaction, emailType, personEmailId);
                        dbLidoEmail.IsUpdated = true;
                    }
                }
            }
        }

        private void InsertPersonRequestLido(
            DbConnection connection,
            DbTransaction transaction,
            PersonType lido,
            EmailType email,
            PhoneType phone,
            long personId,
            long lidoRequestStatusTypeId,
            object identityDocumentTypeId,
            out string guid)
        {
            DbCommand command = CreateCommand();
            command.Connection = connection;
            command.CommandType = CommandType.Text;
            command.Transaction = transaction;
            command.CommandText =
                @"insert into lido_request
                (
                    egn,
                    foreign_number,
                    identity_document_type_id,
                    identity_document_number,
                    identity_document_country_code,
                    first_name,
                    middle_name,
                    last_name,
                    email,
                    phone_number,
                    lido_request_status_type_id,
                    sys_ins_user_id,
                    sys_ins_date,
                    is_lido_legal_person,
                    lido_person_first_name,
                    lido_person_middle_name,
                    lido_person_last_name,
                    lido_person_egn,
                    lido_phone_number,
                    lido_email,
                    lido_person_foreign_number,
                    lido_request_uid,
                    person_id
                )
                values
                (
                    @p_egn,
                    @p_foreign_number,
                    @p_identity_document_type_id,
                    @p_identity_document_number,
                    @p_identity_document_country_code,
                    @p_first_name,
                    @p_middle_name,
                    @p_last_name,
                    @p_email,
                    @p_phone_number,
                    @p_lido_request_status_type_id,
                    @p_sys_ins_user_id,
                    @p_sys_ins_date,
                    @p_is_lido_legal_person,
                    @p_lido_person_first_name,
                    @p_lido_person_middle_name,
                    @p_lido_person_last_name,
                    @p_lido_person_egn,
                    @p_lido_phone_number,
                    @p_lido_email,
                    @p_lido_person_foreign_number,
                    @p_lido_request_uid,
                    @p_person_id
                )
                RETURNING id";

            var egnLnchStruct = this.ExtractEgnLnch(lido);
            object egn = egnLnchStruct.Item1;
            object lnch = egnLnchStruct.Item2;

            var emailParam = email.EmailText;
            object phoneParam = phone == null ? DBNull.Value :
                                phone.PhoneNumber != null ? (phone.PhoneNumber.Trim() as object) : DBNull.Value;
            guid = Guid.NewGuid().ToString();

            this.AddParameter(command, "p_egn", CustomDbType.Varchar, egn);
            this.AddParameter(command, "p_foreign_number", CustomDbType.Varchar, lnch);
            this.AddParameter(command, "p_identity_document_type_id", CustomDbType.Bigint, identityDocumentTypeId);
            this.AddParameter(command, "p_identity_document_number", CustomDbType.Varchar, lido.GetValueOrNull(r => r.IdentityDocumentNumber));
            this.AddParameter(command, "p_identity_document_country_code", CustomDbType.Varchar, lido.GetValueOrNull(r => r.IdentityDocumentCountryCode));
            this.AddParameter(command, "p_first_name", CustomDbType.Varchar, lido.GetValueOrNull(r => r.FirstName));
            this.AddParameter(command, "p_middle_name", CustomDbType.Varchar, lido.GetValueOrNull(r => r.MiddleName));
            this.AddParameter(command, "p_last_name", CustomDbType.Varchar, lido.GetValueOrNull(r => r.LastName));
            this.AddParameter(command, "p_email", CustomDbType.Varchar, emailParam);
            this.AddParameter(command, "p_phone_number", CustomDbType.Varchar, phoneParam);
            this.AddParameter(command, "p_lido_request_status_type_id", CustomDbType.Bigint, lidoRequestStatusTypeId);
            this.AddParameter(command, "p_sys_ins_user_id", CustomDbType.Bigint, SystemUserId);
            this.AddParameter(command, "p_sys_ins_date", CustomDbType.Timestamp, DateTime.Now);
            this.AddParameter(command, "p_is_lido_legal_person", CustomDbType.Boolean, false); // false - Заявката е за person
            this.AddParameter(command, "p_lido_person_first_name", CustomDbType.Varchar, lido.GetValueOrNull(r => r.FirstName));
            this.AddParameter(command, "p_lido_person_middle_name", CustomDbType.Varchar, lido.GetValueOrNull(r => r.MiddleName));
            this.AddParameter(command, "p_lido_person_last_name", CustomDbType.Varchar, lido.GetValueOrNull(r => r.LastName));
            this.AddParameter(command, "p_lido_person_egn", CustomDbType.Varchar, egn);
            this.AddParameter(command, "p_lido_phone_number", CustomDbType.Varchar, phoneParam);
            this.AddParameter(command, "p_lido_email", CustomDbType.Varchar, emailParam);
            this.AddParameter(command, "p_lido_person_foreign_number", CustomDbType.Varchar, lnch);
            this.AddParameter(command, "p_lido_request_uid", CustomDbType.Varchar, guid);
            this.AddParameter(command, "p_person_id", CustomDbType.Bigint, personId);

            command.ExecuteNonQuery();
        }

        #endregion

        #region LegalPersonLido

        private void ValidateLegalLido(LegalPersonType lido)
        {
            var bulstat = lido.BULSTAT?.Trim();
            if (string.IsNullOrEmpty(bulstat))
            {
                throw new ArgumentException("LegalLido `Bulstat` is required");
            }

            bool isValidBulstat = ValidateCompanyDataHelper.ValidateCompanyNumber(bulstat);
            if (!isValidBulstat)
            {
                throw new ArgumentException("LegalLido `Bulstat` does not meet validity constraints");
            }
        }

        private DataTable GetLegalPersonLido(
            DbConnection connection,
            DbTransaction transaction,
            LegalPersonType lido)
        {
            DbCommand command = CreateCommand();
            command.Connection = connection;
            command.CommandType = CommandType.Text;
            command.Transaction = transaction;
            command.CommandText =
                @"select id from legal_person where eik_bulstat = @p_identifier";

            this.AddParameter(command, "p_identifier", CustomDbType.Varchar, lido.BULSTAT);

            var adapter = CreateDataAdapter(command);
            var table = new DataTable();
            adapter.Fill(table);

            return table;
        }

        private long InsertLegalPersonLido(
            DbConnection connection,
            DbTransaction transaction,
            LegalPersonType lido)
        {
            DbCommand command = CreateCommand();
            command.Connection = connection;
            command.CommandType = CommandType.Text;
            command.Transaction = transaction;
            command.CommandText =
                @"insert into legal_person
                (
                    eik_bulstat,
                    name,
                    sys_ins_user_id,
                    sys_ins_date
                )
                values
                (
                    @p_eik_bulstat,
                    @p_name,
                    @p_sys_ins_user_id,
                    @p_sys_ins_date
                )
                RETURNING id";

            this.AddParameter(command, "p_eik_bulstat", CustomDbType.Varchar, lido.GetValueOrNull(r => r.BULSTAT));
            this.AddParameter(command, "p_name", CustomDbType.Varchar, lido.GetValueOrNull(r => r.Name));
            this.AddParameter(command, "p_sys_ins_user_id", CustomDbType.Bigint, SystemUserId);
            this.AddParameter(command, "p_sys_ins_date", CustomDbType.Timestamp, DateTime.Now);

            var obj = this.ExtractScalarValue(command);
            long id = Convert.ToInt64(obj);
            return id;
        }

        private void UpdateLegalPersonLido(
            DbConnection connection,
            DbTransaction transaction,
            LegalPersonType lido,
            long legalPersonId)
        {
            DbCommand command = CreateCommand();
            command.Connection = connection;
            command.CommandType = CommandType.Text;
            command.Transaction = transaction;
            command.CommandText =
            @"
                update legal_person set

                eik_bulstat = @p_eik_bulstat,
                name = @p_name,
                sys_upd_user_id = @p_sys_upd_user_id,
                sys_upd_date = @p_sys_upd_date

                where id = @p_id
            ";

            this.AddParameter(command, "p_eik_bulstat", CustomDbType.Varchar, lido.GetValueOrNull(r => r.BULSTAT));
            this.AddParameter(command, "p_name", CustomDbType.Varchar, lido.GetValueOrNull(r => r.Name));
            this.AddParameter(command, "p_sys_upd_user_id", CustomDbType.Bigint, SystemUserId);
            this.AddParameter(command, "p_sys_upd_date", CustomDbType.Timestamp, DateTime.Now);
            this.AddParameter(command, "p_id", CustomDbType.Bigint, legalPersonId);

            command.ExecuteNonQuery();
        }

        private DataTable GetAccPlaceAllLegalPersons(
            DbConnection connection,
            DbTransaction transaction,
            long accomodationPlaceId)
        {
            DbCommand command = CreateCommand();
            command.Connection = connection;
            command.CommandType = CommandType.Text;
            command.Transaction = transaction;
            command.CommandText =
            @"
                select legal_person_id from acc_place_legal_person 
                where accomodation_place_id = @p_accomodation_place_id
            ";

            this.AddParameter(command, "p_accomodation_place_id", CustomDbType.Bigint, accomodationPlaceId);

            var adapter = CreateDataAdapter(command);
            var table = new DataTable();
            adapter.Fill(table);

            return table;
        }

        private DataTable GetAccPlaceLegalPerson(
            DbConnection connection,
            DbTransaction transaction,
            long accomodationPlaceId,
            long legalPersonId)
        {
            DbCommand command = CreateCommand();
            command.Connection = connection;
            command.CommandType = CommandType.Text;
            command.Transaction = transaction;
            command.CommandText =
            @"
                select id from acc_place_legal_person 
                where accomodation_place_id = @p_accomodation_place_id and
                    legal_person_id = @p_legal_person_id
            ";

            this.AddParameter(command, "p_accomodation_place_id", CustomDbType.Bigint, accomodationPlaceId);
            this.AddParameter(command, "p_legal_person_id", CustomDbType.Bigint, legalPersonId);

            var adapter = CreateDataAdapter(command);
            var table = new DataTable();
            adapter.Fill(table);

            return table;
        }

        private void InsertAccPlaceLegalPerson(
            DbConnection connection,
            DbTransaction transaction,
            LegalPersonType legalPersonLido,
            string uin,
            long accomodationPlaceId,
            long legalPersonId)
        {
            var existingAccPlaceLegalPerson = this.GetAccPlaceLegalPerson(connection, transaction, accomodationPlaceId, legalPersonId);
            if (existingAccPlaceLegalPerson.Rows.Count != 0)
            {
                string format = "Cannot insert link between legal lido \"{0}\" and accomodation place \"{1}\". There is already existing record!";
                string message = string.Format(format, legalPersonLido.BULSTAT, uin);
                throw new ArgumentException(message);
            }

            DbCommand command = CreateCommand();
            command.Connection = connection;
            command.CommandType = CommandType.Text;
            command.Transaction = transaction;
            command.CommandText =
            @"
                insert into acc_place_legal_person
                (
                    accomodation_place_id,
                    acc_place_relation_type_id,
                    sys_ins_user_id,
                    sys_ins_date,
                    legal_person_id
                )
                values
                (
                    @p_accomodation_place_id,
                    @p_acc_place_relation_type_id,
                    @p_sys_ins_user_id,
                    @p_sys_ins_date,
                    @p_legal_person_id
                )
            ";

            this.AddParameter(command, "p_accomodation_place_id", CustomDbType.Bigint, accomodationPlaceId);
            this.AddParameter(command, "p_acc_place_relation_type_id", CustomDbType.Bigint, LidoRelationTypeId);
            this.AddParameter(command, "p_sys_ins_user_id", CustomDbType.Bigint, SystemUserId);
            this.AddParameter(command, "p_sys_ins_date", CustomDbType.Timestamp, DateTime.Now);
            this.AddParameter(command, "p_legal_person_id", CustomDbType.Bigint, legalPersonId);

            command.ExecuteNonQuery();
        }

        private void RemoveLinksAccPlaceLegalPerson(
            DbConnection connection,
            DbTransaction transaction,
            long accomodationPlaceId,
            long legalPersonId)
        {
            // Изтрива връзката МН-Лидо
            DbCommand command = CreateCommand();
            command.Connection = connection;
            command.CommandType = CommandType.Text;
            command.Transaction = transaction;
            command.CommandText =
            @"
                delete from acc_place_legal_person
                where accomodation_place_id = @p_accomodation_place_id and
                    legal_person_id = @p_legal_person_id and
                    acc_place_relation_type_id = @p_acc_place_relation_type_id
            ";

            this.AddParameter(command, "p_accomodation_place_id", CustomDbType.Bigint, accomodationPlaceId);
            this.AddParameter(command, "p_legal_person_id", CustomDbType.Bigint, legalPersonId);
            this.AddParameter(command, "p_acc_place_relation_type_id", CustomDbType.Bigint, LidoRelationTypeId);

            command.ExecuteNonQuery();
        }

        private void InsertLegalPersonAddress(
            DbConnection connection,
            DbTransaction transaction,
            AddressType addressType,
            long legalPersonId)
        {
            DbCommand command = CreateCommand();
            command.Connection = connection;
            command.CommandType = CommandType.Text;
            command.Transaction = transaction;
            command.CommandText =
            @"
                insert into legal_person_address
                (
                    legal_person_id,
                    address_type_id,
                    address_id,
                    sys_ins_user_id,
                    sys_ins_date
                )
                values
                (
                    @p_legal_person_id,
                    @p_address_type_id,
                    @p_address_id,
                    @p_sys_ins_user_id,
                    @p_sys_ins_date
                )
            ";

            var addressId = this.InsertAddress(connection, transaction, addressType, isEkatteRequired: false);
            var addressTypeId = this.GetIdFromNomenclature(connection, "address_type", addressType.AdressTypeCode.ToString());

            this.AddParameter(command, "p_legal_person_id", CustomDbType.Bigint, legalPersonId);
            this.AddParameter(command, "p_address_type_id", CustomDbType.Bigint, addressTypeId);
            this.AddParameter(command, "p_address_id", CustomDbType.Bigint, addressId);
            this.AddParameter(command, "p_sys_ins_user_id", CustomDbType.Bigint, SystemUserId);
            this.AddParameter(command, "p_sys_ins_date", CustomDbType.Timestamp, DateTime.Now);

            command.ExecuteNonQuery();
        }

        private void InsertLegalPersonPhone(
            DbConnection connection,
            DbTransaction transaction,
            PhoneType phoneType,
            long legalPersonId)
        {
            DbCommand command = CreateCommand();
            command.Connection = connection;
            command.CommandType = CommandType.Text;
            command.Transaction = transaction;
            command.CommandText =
            @"
                insert into legal_person_phone
                (
                    phone_type_id,
                    phone_number,
                    sys_ins_user_id,
                    sys_ins_date,
                    legal_person_id
                )
                values
                (
                    @p_phone_type_id,
                    @p_phone_number,
                    @p_sys_ins_user_id,
                    @p_sys_ins_date,
                    @p_legal_person_id
                )
            ";

            var phoneTypeId = this.GetIdFromNomenclature(connection, "phone_type", phoneType.PhoneTypeCode.ToString());
            var phoneParam = phoneType == null ? "" : phoneType.PhoneNumber != null ? phoneType.PhoneNumber.Trim() : "";

            this.AddParameter(command, "p_phone_type_id", CustomDbType.Bigint, phoneTypeId);
            this.AddParameter(command, "p_phone_number", CustomDbType.Varchar, phoneParam);
            this.AddParameter(command, "p_sys_ins_user_id", CustomDbType.Bigint, SystemUserId);
            this.AddParameter(command, "p_sys_ins_date", CustomDbType.Timestamp, DateTime.Now);
            this.AddParameter(command, "p_legal_person_id", CustomDbType.Bigint, legalPersonId);

            command.ExecuteNonQuery();
        }

        private void InsertLegalPersonEmail(
            DbConnection connection,
            DbTransaction transaction,
            EmailType emailType,
            long legalPersonId)
        {
            DbCommand command = CreateCommand();
            command.Connection = connection;
            command.CommandType = CommandType.Text;
            command.Transaction = transaction;
            command.CommandText =
            @"
                insert into legal_person_email
                (
                    legal_person_id,
                    email_type_id,
                    email,
                    sys_ins_user_id,
                    sys_ins_date
                )
                values
                (
                    @p_legal_person_id,
                    @p_email_type_id,
                    @p_email,
                    @p_sys_ins_user_id,
                    @p_sys_ins_date
                )
            ";

            var emailTypeId = this.GetIdFromNomenclature(connection, "email_type", emailType.EmailTypeCode.ToString());

            this.AddParameter(command, "p_legal_person_id", CustomDbType.Bigint, legalPersonId);
            this.AddParameter(command, "p_email_type_id", CustomDbType.Bigint, emailTypeId);
            this.AddParameter(command, "p_email", CustomDbType.Varchar, emailType.EmailText);
            this.AddParameter(command, "p_sys_ins_user_id", CustomDbType.Bigint, SystemUserId);
            this.AddParameter(command, "p_sys_ins_date", CustomDbType.Timestamp, DateTime.Now);

            command.ExecuteNonQuery();
        }

        private DataTable GetLegalPersonAddress(
            DbConnection connection,
            DbTransaction transaction,
            long legalPersonId)
        {
            DbCommand command = CreateCommand();
            command.Connection = connection;
            command.CommandType = CommandType.Text;
            command.Transaction = transaction;
            command.CommandText =
                @"select id, address_type_id, address_id
                from legal_person_address 
                where legal_person_id = @p_legal_person_id";

            this.AddParameter(command, "p_legal_person_id", CustomDbType.Bigint, legalPersonId);

            var adapter = CreateDataAdapter(command);
            var table = new DataTable();
            adapter.Fill(table);

            return table;
        }

        private DataTable GetLegalPersonPhone(
            DbConnection connection,
            DbTransaction transaction,
            long legalPersonId)
        {
            DbCommand command = CreateCommand();
            command.Connection = connection;
            command.CommandType = CommandType.Text;
            command.Transaction = transaction;
            command.CommandText =
                @"select id, phone_type_id 
                from legal_person_phone 
                where legal_person_id = @p_legal_person_id";

            this.AddParameter(command, "p_legal_person_id", CustomDbType.Bigint, legalPersonId);

            var adapter = CreateDataAdapter(command);
            var table = new DataTable();
            adapter.Fill(table);

            return table;
        }

        private DataTable GetLegalPersonEmail(
            DbConnection connection,
            DbTransaction transaction,
            long legalPersonId)
        {
            DbCommand command = CreateCommand();
            command.Connection = connection;
            command.CommandType = CommandType.Text;
            command.Transaction = transaction;
            command.CommandText =
                @"select id, email_type_id
                from legal_person_email 
                where legal_person_id = @p_legal_person_id";

            this.AddParameter(command, "p_legal_person_id", CustomDbType.Bigint, legalPersonId);

            var adapter = CreateDataAdapter(command);
            var table = new DataTable();
            adapter.Fill(table);

            return table;
        }

        private void DeleteLegalPersonAddress(
            DbConnection connection,
            DbTransaction transaction,
            long legalPersonAddressId)
        {
            DbCommand command = CreateCommand();
            command.Connection = connection;
            command.CommandType = CommandType.Text;
            command.Transaction = transaction;
            command.CommandText =
                @"delete from legal_person_address where id = @p_legal_person_address_id";

            this.AddParameter(command, "p_legal_person_address_id", CustomDbType.Bigint, legalPersonAddressId);

            command.ExecuteNonQuery();
        }

        private void DeleteLegalPersonPhone(
            DbConnection connection,
            DbTransaction transaction,
            long legalPersonPhoneId)
        {
            DbCommand command = CreateCommand();
            command.Connection = connection;
            command.CommandType = CommandType.Text;
            command.Transaction = transaction;
            command.CommandText =
                @"delete from legal_person_phone where id = @p_legal_person_phone_id";

            this.AddParameter(command, "p_legal_person_phone_id", CustomDbType.Bigint, legalPersonPhoneId);

            command.ExecuteNonQuery();
        }

        private void DeleteLegalPersonEmail(
            DbConnection connection,
            DbTransaction transaction,
            long legalPersonEmailId)
        {
            DbCommand command = CreateCommand();
            command.Connection = connection;
            command.CommandType = CommandType.Text;
            command.Transaction = transaction;
            command.CommandText =
                @"delete from legal_person_email where id = @p_legal_person_email_id";

            this.AddParameter(command, "p_legal_person_email_id", CustomDbType.Bigint, legalPersonEmailId);

            command.ExecuteNonQuery();
        }

        private void UpdateSingleLegalPersonPhone(
            DbConnection connection,
            DbTransaction transaction,
            PhoneType phoneType,
            long legalPersonPhoneId)
        {
            DbCommand command = CreateCommand();
            command.Connection = connection;
            command.CommandType = CommandType.Text;
            command.Transaction = transaction;
            command.CommandText =
            @"
                update legal_person_phone set

                phone_type_id = @p_phone_type_id,
                phone_number = @p_phone_number,
                sys_upd_user_id = @p_sys_upd_user_id,
                sys_upd_date = @p_sys_upd_date
                
                where id = @p_legal_person_phone_id
            ";

            var phoneTypeId = this.GetIdFromNomenclature(connection, "phone_type", phoneType.PhoneTypeCode.ToString());
            var phoneParam = phoneType == null ? "" : phoneType.PhoneNumber != null ? phoneType.PhoneNumber.Trim() : "";

            this.AddParameter(command, "p_phone_type_id", CustomDbType.Bigint, phoneTypeId);
            this.AddParameter(command, "p_phone_number", CustomDbType.Varchar, phoneParam);
            this.AddParameter(command, "p_sys_upd_user_id", CustomDbType.Bigint, SystemUserId);
            this.AddParameter(command, "p_sys_upd_date", CustomDbType.Timestamp, DateTime.Now);
            this.AddParameter(command, "p_legal_person_phone_id", CustomDbType.Bigint, legalPersonPhoneId);

            command.ExecuteNonQuery();
        }

        private void UpdateSingleLegalPersonEmail(
            DbConnection connection,
            DbTransaction transaction,
            EmailType emailType,
            long legalPersonEmailId)
        {
            DbCommand command = CreateCommand();
            command.Connection = connection;
            command.CommandType = CommandType.Text;
            command.Transaction = transaction;
            command.CommandText =
            @"
                update legal_person_email set

                email_type_id = @p_email_type_id,
                email = @p_email,
                sys_upd_user_id = @p_sys_upd_user_id,
                sys_upd_date = @p_sys_upd_date
                
                where id = @p_legal_person_email_id
            ";

            var emailTypeId = this.GetIdFromNomenclature(connection, "email_type", emailType.EmailTypeCode.ToString());

            this.AddParameter(command, "p_email_type_id", CustomDbType.Bigint, emailTypeId);
            this.AddParameter(command, "p_email", CustomDbType.Varchar, emailType.GetValueOrNull(r => r.EmailText));
            this.AddParameter(command, "p_sys_upd_user_id", CustomDbType.Bigint, SystemUserId);
            this.AddParameter(command, "p_sys_upd_date", CustomDbType.Timestamp, DateTime.Now);
            this.AddParameter(command, "p_legal_person_email_id", CustomDbType.Bigint, legalPersonEmailId);

            command.ExecuteNonQuery();
        }

        private void InsertOrUpdateLegalPersonAddresses(
            DbConnection connection,
            DbTransaction transaction,
            LegalPersonType lido,
            long legalPersonId)
        {
            if (lido.Address == null)
            {
                // Ако няма нови данни за адрес, то тези в базата ще се изтриват
                lido.Address = new List<AddressType>();
            }

            // Извличане на текущите данни за адреси от базата
            var previousAddressTable = this.GetLegalPersonAddress(connection, transaction, legalPersonId);
            var previousAddresses = previousAddressTable.Rows.Cast<DataRow>().Select(x => new LidoLink
            {
                Id = x.ItemArray[0],
                TypeId = x.ItemArray[1],
                PrimaryId = x.ItemArray[2],
            }).ToList();

            // Валидация за повтаряне
            var allTypes = lido.Address.Select(x => x.AdressTypeCode).ToList();
            var distinctTypes = allTypes.Distinct().ToList();
            if (allTypes.Count != distinctTypes.Count)
            {
                throw new ArgumentException("You can't have multiple addresses with one AdressTypeCode");
            }

            // Update ако същестува в базата, иначе insert
            foreach (var addressType in lido.Address)
            {
                var addressTypeId = this.GetIdFromNomenclature(connection, "address_type", addressType.AdressTypeCode.ToString());
                var dbLidoAddress = previousAddresses.FirstOrDefault(x => x.TypeId.Equals(addressTypeId));
                if (dbLidoAddress == null)
                {
                    // Няма такова, следователно insert
                    this.InsertLegalPersonAddress(connection, transaction, addressType, legalPersonId);
                }
                else
                {
                    // Не се update-ва много-много таблицата, понеже цялата информация се реферира през address_id
                    var addressId = Convert.ToInt64(dbLidoAddress.PrimaryId);
                    this.UpdateAddress(connection, transaction, addressType, addressId, isEkatteRequired: false);
                    dbLidoAddress.IsUpdated = true;
                }
            }

            // Ако не са били променени, се изтриват понеже е добавен нов адрес
            var nonUpdatedLinks = previousAddresses.Where(x => !x.IsUpdated);
            foreach (var link in nonUpdatedLinks)
            {
                var legalPersonAddressId = Convert.ToInt64(link.Id);
                this.DeleteLegalPersonAddress(connection, transaction, legalPersonAddressId);

                var addressId = Convert.ToInt64(link.PrimaryId);
                this.DeleteAddress(connection, transaction, addressId);
            }
        }

        private void InsertOrUpdateLegalPersonPhones(
            DbConnection connection,
            DbTransaction transaction,
            LegalPersonType lido,
            long legalPersonId)
        {
            if (lido.Phone == null)
            {
                // Ако няма нови данни за адрес, то тези в базата ще се изтриват
                lido.Phone = new List<PhoneType>();
            }

            // Извличане на текущите данни за адреси от базата
            var previousPhoneTable = this.GetLegalPersonPhone(connection, transaction, legalPersonId);
            var previousPhones = previousPhoneTable.Rows.Cast<DataRow>().Select(x => new LidoLink
            {
                Id = x.ItemArray[0],
                TypeId = x.ItemArray[1],
            }).ToList();

            // Валидация за повтаряне
            var allTypes = lido.Phone.Select(x => x.PhoneTypeCode).ToList();
            var distinctTypes = allTypes.Distinct().ToList();
            if (allTypes.Count != distinctTypes.Count)
            {
                throw new ArgumentException("You can't have multiple phones with one PhoneTypeCode");
            }

            // Update ако същестува в базата, иначе insert
            foreach (var phoneType in lido.Phone)
            {
                if (string.IsNullOrEmpty(phoneType.PhoneNumber))
                {
                    continue;
                }

                var phoneTypeId = this.GetIdFromNomenclature(connection, "phone_type", phoneType.PhoneTypeCode.ToString());
                var dbLidoPhone = previousPhones.FirstOrDefault(x => x.TypeId.Equals(phoneTypeId));
                if (dbLidoPhone == null)
                {
                    // Няма такова, следователно insert
                    this.InsertLegalPersonPhone(connection, transaction, phoneType, legalPersonId);
                }
                else
                {
                    // Иначе update на много-много таблицата
                    var legalPersonPhoneId = Convert.ToInt64(dbLidoPhone.Id);
                    this.UpdateSingleLegalPersonPhone(connection, transaction, phoneType, legalPersonPhoneId);
                    dbLidoPhone.IsUpdated = true;
                }
            }

            // Ако не са били променени, се изтриват понеже е добавен нов адрес
            var nonUpdatedLinks = previousPhones.Where(x => !x.IsUpdated);
            foreach (var link in nonUpdatedLinks)
            {
                var legalPersonPhoneId = Convert.ToInt64(link.Id);
                this.DeleteLegalPersonPhone(connection, transaction, legalPersonPhoneId);
            }
        }

        private void InsertOrUpdateLegalPersonEmails(
            DbConnection connection,
            DbTransaction transaction,
            LegalPersonType lido,
            long legalPersonId)
        {
            if (lido.Email == null || lido.Email.Count == 0)
            {
                // Ако няма нови данни за мейли, то няма да се прави нищо
                // Тоест ако е имало преди данни за мейли, те не се пипат, нито се добавят нови редове със празни стойности
                return;
            }

            // Валидация за повтаряне
            var allTypes = lido.Email.Select(x => x.EmailTypeCode).ToList();
            var distinctTypes = allTypes.Distinct().ToList();
            if (allTypes.Count != distinctTypes.Count)
            {
                throw new ArgumentException("You can't have multiple emails with one EmailTypeCode");
            }

            // Извличане на текущите данни за адреси от базата
            var previousEmailTable = this.GetLegalPersonEmail(connection, transaction, legalPersonId);
            var previousEmails = previousEmailTable.Rows.Cast<DataRow>().Select(x => new LidoLink
            {
                Id = x.ItemArray[0],
                TypeId = x.ItemArray[1],
            }).ToList();

            // Update ако същестува в базата, иначе insert
            foreach (var emailType in lido.Email)
            {
                // Валидация по емайл, ако не мине няма да се добавят или редактират данните в базата
                if (!string.IsNullOrEmpty(emailType.EmailText) && IsValidEmail(emailType.EmailText))
                {
                    var emailTypeId = this.GetIdFromNomenclature(connection, "email_type", emailType.EmailTypeCode.ToString());
                    var dbLidoEmail = previousEmails.FirstOrDefault(x => x.TypeId.Equals(emailTypeId));
                    if (dbLidoEmail == null)
                    {
                        // Няма такова, следователно insert
                        this.InsertLegalPersonEmail(connection, transaction, emailType, legalPersonId);
                    }
                    else
                    {
                        // Иначе update на много-много таблицата
                        var legalPersonEmailId = Convert.ToInt64(dbLidoEmail.Id);
                        this.UpdateSingleLegalPersonEmail(connection, transaction, emailType, legalPersonEmailId);
                        dbLidoEmail.IsUpdated = true;
                    }
                }
            }
        }

        private void InsertLegalPersonRequestLido(
            DbConnection connection,
            DbTransaction transaction,
            LegalPersonType lido,
            EmailType email,
            PhoneType phone,
            long legalPersonId,
            long lidoRequestStatusTypeId,
            out string guid)
        {
            DbCommand command = CreateCommand();
            command.Connection = connection;
            command.CommandType = CommandType.Text;
            command.Transaction = transaction;
            command.CommandText =
                @"insert into lido_request
                (
                    email,
                    phone_number,
                    lido_request_status_type_id,
                    sys_ins_user_id,
                    sys_ins_date,
                    is_lido_legal_person,
                    lido_legal_eik,
                    lido_legal_name,
                    lido_request_uid,
                    legal_person_id
                )
                values
                (
                    @p_email,
                    @p_phone_number,
                    @p_lido_request_status_type_id,
                    @p_sys_ins_user_id,
                    @p_sys_ins_date,
                    @p_is_lido_legal_person,
                    @p_lido_legal_eik,
                    @p_lido_legal_name,
                    @p_lido_request_uid,
                    @p_legal_person_id
                )
                RETURNING id";

            var emailParam = email.EmailText;
            var phoneParam = phone == null ? DBNull.Value : phone.GetValueOrNull(r => r.PhoneNumber);
            guid = Guid.NewGuid().ToString();

            this.AddParameter(command, "p_email", CustomDbType.Varchar, emailParam);
            this.AddParameter(command, "p_phone_number", CustomDbType.Varchar, phoneParam);
            this.AddParameter(command, "p_lido_request_status_type_id", CustomDbType.Bigint, lidoRequestStatusTypeId);
            this.AddParameter(command, "p_sys_ins_user_id", CustomDbType.Bigint, SystemUserId);
            this.AddParameter(command, "p_sys_ins_date", CustomDbType.Timestamp, DateTime.Now);
            this.AddParameter(command, "p_is_lido_legal_person", CustomDbType.Boolean, true); // true - Заявката е за legal_person
            this.AddParameter(command, "p_lido_legal_eik", CustomDbType.Varchar, lido.GetValueOrNull(r => r.BULSTAT));
            this.AddParameter(command, "p_lido_legal_name", CustomDbType.Varchar, lido.GetValueOrNull(r => r.Name));
            this.AddParameter(command, "p_lido_request_uid", CustomDbType.Varchar, guid);
            this.AddParameter(command, "p_legal_person_id", CustomDbType.Bigint, legalPersonId);

            command.ExecuteNonQuery();
        }

        #endregion

        #region CommonSendInfoForAccomodationRegister

        private DataRow GetAccomodationPlace(
            DbConnection connection,
            DbTransaction transaction,
            string uin)
        {
            DbCommand command = this.CreateCommand();
            command.Connection = connection;
            command.CommandType = CommandType.Text;
            command.Transaction = transaction;
            command.CommandText =
                @"select id, regix_oid, uin from accomodation_place where uin like @p_uin";

            var argumentUIN = uin.Trim();
            var parts = argumentUIN.Split('-');
            var startPart = string.Join("-", parts.Take(2)) + '%';
            this.AddParameter(command, "p_uin", CustomDbType.Varchar, startPart);

            var resultDataSet = this.CreateDataAdapter(command);
            DataSet ds = new DataSet();

            resultDataSet.Fill(ds);
            var majorTable = ds.Tables[0];
            var rows = majorTable.Rows.Cast<DataRow>().ToList();
            if (rows.Count == 0)
            {
                // Няма такова място за настаняване в базата
                return null;
            }
            else
            {
                // Има и регистрирани (некатегоризирани) обекти които се различават от останалите (завършват на 0)
                if (argumentUIN.Last() == '0')
                {
                    DataRow foundRow = null;
                    foreach (var row in rows)
                    {
                        var dbUin = row["uin"].ToString();
                        if (dbUin.Last() == argumentUIN.Last())
                        {
                            foundRow = row;
                        }
                    }

                    return foundRow;
                }
                else
                {
                    var categorizedObjects = rows.Where(x => x["uin"].ToString().Last() != '0').ToList();
                    if (categorizedObjects.Count == 0)
                    {
                        // Няма категоризиран обект
                        return null;
                    }
                    else
                    {
                        // Има категоризиран обект
                        return categorizedObjects[0];
                    }
                }
            }

            // Previous version
            //DbCommand command = CreateCommand();
            //command.Connection = connection;
            //command.CommandType = CommandType.Text;
            //command.Transaction = transaction;
            //command.CommandText =
            //    @"select id, regix_oid from accomodation_place where uin like @p_uin"; // TODO: not unique

            //object subUinValue = subUin != null ? (object)(subUin + '%') : DBNull.Value;
            //this.AddParameter(command, "p_uin", CustomDbType.Varchar, subUinValue);

            //var adapter = CreateDataAdapter(command);
            //var table = new DataTable();
            //adapter.Fill(table);

            //return table;
        }

        // Търсене на регистрация по string uid
        private DataTable GetAccomodationRegister(
            DbConnection connection,
            DbTransaction transaction,
            long accomodationPlaceId,
            string uid)
        {
            DbCommand command = CreateCommand();
            command.Connection = connection;
            command.CommandType = CommandType.Text;
            command.Transaction = transaction;
            command.CommandText =
            @"
                select id, accomodation_place_id
                from accomodation_register 
                where accomodation_register_uid = @p_uid and accomodation_place_id = @p_accomodation_place_id
            ";

            this.AddParameter(command, "p_uid", CustomDbType.Varchar, uid);
            this.AddParameter(command, "p_accomodation_place_id", CustomDbType.Bigint, accomodationPlaceId);

            var adapter = CreateDataAdapter(command);
            var table = new DataTable();
            adapter.Fill(table);

            return table;
        }

        // Търсене на регистрация по long id
        private DataTable GetAccomodationRegisterById(
            DbConnection connection,
            DbTransaction transaction,
            long accomodationPlaceId,
            long registrationId)
        {
            // Използват се два параметъра в случай, че консуматор се опита да достъпи регистрация на друго МН
            DbCommand command = CreateCommand();
            command.Connection = connection;
            command.CommandType = CommandType.Text;
            command.Transaction = transaction;
            command.CommandText =
            @"
                select id, accomodation_place_id, is_canceled
                from accomodation_register 
                where id = @p_id and accomodation_place_id = @p_accomodation_place_id
            ";

            this.AddParameter(command, "p_id", CustomDbType.Bigint, registrationId);
            this.AddParameter(command, "p_accomodation_place_id", CustomDbType.Bigint, accomodationPlaceId);

            var adapter = CreateDataAdapter(command);
            var table = new DataTable();
            adapter.Fill(table);

            return table;
        }

        private AccRegister.AccomodationRegisterResponseType InsertAccomodationRegister(
            DbConnection connection,
            DbTransaction transaction,
            AccRegister.AccomodationRegisterRequestType argument,
            long accomodationPlaceId)
        {
            DbCommand command = CreateCommand();
            command.Connection = connection;
            command.CommandType = CommandType.Text;
            command.Transaction = transaction;
            command.CommandText =
                @"insert into accomodation_register
                (
                    accomodation_register_uid,
                    accomodation_place_id,
                    registration_date,
                    first_name,
                    middle_name,
                    last_name,
                    gender_type_code,
                    identity_document_type_id,
                    identity_document_number,
                    identity_document_country_code,
                    egn,
                    foreign_number,
                    birth_date,
                    age,
                    floor,
                    room,
                    check_in_date,
                    check_out_date,
                    nights_count,
                    tourist_package,
                    avg_night_price,
                    sys_ins_user_id,
                    sys_ins_date
                )
                values
                (
                    @p_accomodation_register_uid,
                    @p_accomodation_place_id,
                    @p_registration_date,
                    @p_first_name,
                    @p_middle_name,
                    @p_last_name,
                    @p_gender_type_code,
                    @p_identity_document_type_id,
                    @p_identity_document_number,
                    @p_identity_document_country_code,
                    @p_egn,
                    @p_foreign_number,
                    @p_birth_date,
                    @p_age,
                    @p_floor,
                    @p_room,
                    @p_check_in_date,
                    @p_check_out_date,
                    @p_nights_count,
                    @p_tourist_package,
                    @p_avg_night_price,
                    @p_sys_ins_user_id,
                    @p_sys_ins_date
                )
                RETURNING id";

            var accomodation = argument.InsertAccomodation;

            // Tuple: ErrorMessage, NightsCount, Age
            var calculation = this.ValidateCalculationsForAccRegister(accomodation.Registration, accomodation.Person);
            if (!string.IsNullOrEmpty(calculation.Item1))
            {
                throw new ArgumentException(calculation.Item1);
            }

            var nightsCount = calculation.Item2;
            var age = calculation.Item3;

            var person = accomodation.Person;
            var registration = accomodation.Registration;

            var egnLnchStruct = this.ExtractEgnLnch(person);
            object egn = egnLnchStruct.Item1;
            object lnch = egnLnchStruct.Item2;

            var identityDocumentNumber = person.GetValueOrNull(r => r.IdentityDocumentNumber);
            var identityDocumentTypeId = this.ExtractIdentityDocTypeId(connection, person);
            var gender = person.Sex.ToString();

            // Crypto objects
            var subUin = CryptoUtils.GetSubUin(argument.AccomodationPlaceUIN);
            var cryptoFirstName = CryptoUtils.EncryptField(person.FirstName, subUin);
            var cryptoMiddleName = CryptoUtils.EncryptField(person.MiddleName, subUin);
            var cryptoFamilyName = CryptoUtils.EncryptField(person.FamilyName, subUin);
            var cryptoEgn = CryptoUtils.EncryptField(egn == DBNull.Value ? null : egn.ToString(), subUin);
            var cryptoLnch = CryptoUtils.EncryptField(lnch == DBNull.Value ? null : lnch.ToString(), subUin);

            var firstName = cryptoFirstName == null ? DBNull.Value : (object)cryptoFirstName;
            var middleName = cryptoMiddleName == null ? DBNull.Value : (object)cryptoMiddleName;
            var familyName = cryptoFamilyName == null ? DBNull.Value : (object)cryptoFamilyName;
            egn = (cryptoEgn == null) ? DBNull.Value : (object)cryptoEgn;
            lnch = (cryptoLnch == null) ? DBNull.Value : (object)cryptoLnch;

            // Tрите имена, ЕГН, ЛНЧ, номер на личен документ, тип на личен документ
            // Не се въвеждат когато данните са за туристи от страни в ЕС
            var countriesStatisticalData = this.GetCountriesWithOnlyStatisticalData(connection);
            if (countriesStatisticalData.Contains(person.IdentityDocumentCountryCode?.ToUpper()))
            {
                firstName = DBNull.Value;
                middleName = DBNull.Value;
                familyName = DBNull.Value;
                egn = DBNull.Value;
                lnch = DBNull.Value;
                identityDocumentNumber = DBNull.Value;
                identityDocumentTypeId = DBNull.Value;
            }

            this.AddParameter(command, "p_accomodation_register_uid", CustomDbType.Varchar, accomodation.GetValueOrNull(r => r.RegistrationUID));
            this.AddParameter(command, "p_accomodation_place_id", CustomDbType.Bigint, accomodationPlaceId);
            this.AddParameter(command, "p_registration_date", CustomDbType.Timestamp, registration.GetValueOrNull(r => r.RegistrationDate));
            this.AddParameter(command, "p_first_name", CustomDbType.Varchar, firstName);
            this.AddParameter(command, "p_middle_name", CustomDbType.Varchar, middleName);
            this.AddParameter(command, "p_last_name", CustomDbType.Varchar, familyName);
            this.AddParameter(command, "p_gender_type_code", CustomDbType.Varchar, gender);
            this.AddParameter(command, "p_identity_document_type_id", CustomDbType.Bigint, identityDocumentTypeId);
            this.AddParameter(command, "p_identity_document_number", CustomDbType.Varchar, identityDocumentNumber);
            this.AddParameter(command, "p_identity_document_country_code", CustomDbType.Varchar, person.GetValueOrNull(r => r.IdentityDocumentCountryCode));
            this.AddParameter(command, "p_egn", CustomDbType.Varchar, egn);
            this.AddParameter(command, "p_foreign_number", CustomDbType.Varchar, lnch);
            this.AddParameter(command, "p_birth_date", CustomDbType.Date, person.GetValueOrNull(r => r.BirthDate));
            this.AddParameter(command, "p_age", CustomDbType.Integer, age);
            this.AddParameter(command, "p_floor", CustomDbType.Varchar, registration.GetValueOrNull(r => r.Floor));
            this.AddParameter(command, "p_room", CustomDbType.Varchar, registration.GetValueOrNull(r => r.Room));
            this.AddParameter(command, "p_check_in_date", CustomDbType.Timestamp, registration.GetValueOrNull(r => r.CheckInDate));
            this.AddParameter(command, "p_check_out_date", CustomDbType.Timestamp, registration.GetValueOrNull(r => r.CheckOutDate));
            this.AddParameter(command, "p_nights_count", CustomDbType.Integer, nightsCount);
            this.AddParameter(command, "p_tourist_package", CustomDbType.Boolean, registration.GetValueOrNull(r => r.TouristPackage));
            this.AddParameter(command, "p_avg_night_price", CustomDbType.Numeric, registration.GetValueOrNull(r => r.AveragePrice));
            this.AddParameter(command, "p_sys_ins_user_id", CustomDbType.Bigint, SystemUserId);
            this.AddParameter(command, "p_sys_ins_date", CustomDbType.Timestamp, DateTime.Now);

            var commandResult = this.ExtractScalarValue(command);
            var registrationId = Convert.ToInt64(commandResult);
            var result = new AccRegister.AccomodationRegisterResponseType()
            {
                ResponseCode = 1,
                RegistrationId = registrationId
            };

            return result;
        }

        private AccRegister.AccomodationRegisterResponseType UpdateAccomodationRegister(
            DbConnection connection,
            DbTransaction transaction,
            AccRegister.AccomodationRegisterRequestType argument)
        {
            DbCommand command = CreateCommand();
            command.Connection = connection;
            command.CommandType = CommandType.Text;
            command.Transaction = transaction;
            command.CommandText =
            @"
                update accomodation_register set
                
                registration_date = @p_registration_date,
                first_name = @p_first_name,
                middle_name = @p_middle_name,
                last_name = @p_last_name,
                gender_type_code = @p_gender_type_code,
                identity_document_type_id = @p_identity_document_type_id,
                identity_document_number = @p_identity_document_number,
                identity_document_country_code = @p_identity_document_country_code,
                egn = @p_egn,
                foreign_number = @p_foreign_number,
                birth_date = @p_birth_date,
                age = @p_age,
                floor = @p_floor,
                room = @p_room,
                check_in_date = @p_check_in_date,
                check_out_date = @p_check_out_date,
                nights_count = @p_nights_count,
                tourist_package = @p_tourist_package,
                avg_night_price = @p_avg_night_price,
                sys_upd_user_id = @p_sys_upd_user_id,
                sys_upd_date = @p_sys_upd_date

                where id = @p_accomodation_register_id
            ";

            var accomodation = argument.UpdateAccomodation;

            // Tuple: ErrorMessage, NightsCount, Age
            var calculation = this.ValidateCalculationsForAccRegister(accomodation.Registration, accomodation.Person);
            if (!string.IsNullOrEmpty(calculation.Item1))
            {
                throw new ArgumentException(calculation.Item1);
            }

            var nightsCount = calculation.Item2;
            var age = calculation.Item3;

            var person = accomodation.Person;
            var registration = accomodation.Registration;

            var egnLnchStruct = this.ExtractEgnLnch(person);
            object egn = egnLnchStruct.Item1;
            object lnch = egnLnchStruct.Item2;

            var identityDocumentNumber = person.GetValueOrNull(r => r.IdentityDocumentNumber);
            var identityDocumentTypeId = this.ExtractIdentityDocTypeId(connection, person);
            var gender = person.Sex.ToString();

            // Crypto objects
            var subUin = CryptoUtils.GetSubUin(argument.AccomodationPlaceUIN);
            var cryptoFirstName = CryptoUtils.EncryptField(person.FirstName, subUin);
            var cryptoMiddleName = CryptoUtils.EncryptField(person.MiddleName, subUin);
            var cryptoFamilyName = CryptoUtils.EncryptField(person.FamilyName, subUin);
            var cryptoEgn = CryptoUtils.EncryptField(egn == DBNull.Value ? null : egn.ToString(), subUin);
            var cryptoLnch = CryptoUtils.EncryptField(lnch == DBNull.Value ? null : lnch.ToString(), subUin);

            var firstName = cryptoFirstName == null ? DBNull.Value : (object)cryptoFirstName;
            var middleName = cryptoMiddleName == null ? DBNull.Value : (object)cryptoMiddleName;
            var familyName = cryptoFamilyName == null ? DBNull.Value : (object)cryptoFamilyName;
            egn = (cryptoEgn == null) ? DBNull.Value : (object)cryptoEgn;
            lnch = (cryptoLnch == null) ? DBNull.Value : (object)cryptoLnch;

            // Tрите имена, ЕГН, ЛНЧ, номер на личен документ, тип на личен документ
            // Не се въвеждат когато данните са за туристи от страни в ЕС
            var countriesStatisticalData = this.GetCountriesWithOnlyStatisticalData(connection);
            if (countriesStatisticalData.Contains(person.IdentityDocumentCountryCode?.ToUpper()))
            {
                firstName = DBNull.Value;
                middleName = DBNull.Value;
                familyName = DBNull.Value;
                egn = DBNull.Value;
                lnch = DBNull.Value;
                identityDocumentNumber = DBNull.Value;
                identityDocumentTypeId = DBNull.Value;
            }

            this.AddParameter(command, "p_registration_date", CustomDbType.Timestamp, registration.GetValueOrNull(r => r.RegistrationDate));
            this.AddParameter(command, "p_first_name", CustomDbType.Varchar, firstName);
            this.AddParameter(command, "p_middle_name", CustomDbType.Varchar, middleName);
            this.AddParameter(command, "p_last_name", CustomDbType.Varchar, familyName);
            this.AddParameter(command, "p_gender_type_code", CustomDbType.Varchar, gender);
            this.AddParameter(command, "p_identity_document_type_id", CustomDbType.Bigint, identityDocumentTypeId);
            this.AddParameter(command, "p_identity_document_number", CustomDbType.Varchar, identityDocumentNumber);
            this.AddParameter(command, "p_identity_document_country_code", CustomDbType.Varchar, person.GetValueOrNull(r => r.IdentityDocumentCountryCode));
            this.AddParameter(command, "p_egn", CustomDbType.Varchar, egn);
            this.AddParameter(command, "p_foreign_number", CustomDbType.Varchar, lnch);
            this.AddParameter(command, "p_birth_date", CustomDbType.Date, person.GetValueOrNull(r => r.BirthDate));
            this.AddParameter(command, "p_age", CustomDbType.Integer, age);
            this.AddParameter(command, "p_floor", CustomDbType.Varchar, registration.GetValueOrNull(r => r.Floor));
            this.AddParameter(command, "p_room", CustomDbType.Varchar, registration.GetValueOrNull(r => r.Room));
            this.AddParameter(command, "p_check_in_date", CustomDbType.Timestamp, registration.GetValueOrNull(r => r.CheckInDate));
            this.AddParameter(command, "p_check_out_date", CustomDbType.Timestamp, registration.GetValueOrNull(r => r.CheckOutDate));
            this.AddParameter(command, "p_nights_count", CustomDbType.Integer, nightsCount);
            this.AddParameter(command, "p_tourist_package", CustomDbType.Boolean, registration.GetValueOrNull(r => r.TouristPackage));
            this.AddParameter(command, "p_avg_night_price", CustomDbType.Numeric, registration.GetValueOrNull(r => r.AveragePrice));
            this.AddParameter(command, "p_sys_upd_user_id", CustomDbType.Bigint, SystemUserId);
            this.AddParameter(command, "p_sys_upd_date", CustomDbType.Timestamp, DateTime.Now);
            this.AddParameter(command, "p_accomodation_register_id", CustomDbType.Bigint, accomodation.RegistrationId);

            command.ExecuteNonQuery();
            var result = new AccRegister.AccomodationRegisterResponseType()
            {
                ResponseCode = 2,
                RegistrationId = accomodation.RegistrationId
            };

            return result;
        }

        private AccRegister.AccomodationRegisterResponseType CancelUpdateAccomodationRegister(
            DbConnection connection,
            DbTransaction transaction,
            AccRegister.CancelAccomodationType accomodation)
        {
            DbCommand command = CreateCommand();
            command.Connection = connection;
            command.CommandType = CommandType.Text;
            command.Transaction = transaction;
            command.CommandText =
            @"
                update accomodation_register set

                is_canceled = @p_is_canceled,
                sys_upd_user_id = @p_sys_upd_user_id,
                sys_upd_date = @p_sys_upd_date

                where id = @p_accomodation_register_id
            ";

            this.AddParameter(command, "p_is_canceled", CustomDbType.Boolean, true);
            this.AddParameter(command, "p_sys_upd_user_id", CustomDbType.Bigint, SystemUserId);
            this.AddParameter(command, "p_sys_upd_date", CustomDbType.Timestamp, DateTime.Now);
            this.AddParameter(command, "p_accomodation_register_id", CustomDbType.Bigint, accomodation.RegistrationId);

            command.ExecuteNonQuery();
            var result = new AccRegister.AccomodationRegisterResponseType()
            {
                ResponseCode = 3,
                RegistrationId = accomodation.RegistrationId
            };

            return result;
        }

        private Tuple<string, int, int> ValidateCalculationsForAccRegister(
            AccRegister.RegistrationType registration,
            AccRegister.PersonType person)
        {
            // Compare check in and check out date
            if (registration.CheckInDate > registration.CheckOutDate)
            {
                var message = "CheckInDate can't be after CheckOutDate";
                return new Tuple<string, int, int>(message, 0, 0);
            }

            // Compare birthdate with check in date
            var dateToCompare = registration.RegistrationDate;
            if (person.BirthDate > dateToCompare)
            {
                var message = "BirthDate can't be after RegistrationDate";
                return new Tuple<string, int, int>(message, 0, 0);
            }

            var nightsCount = (registration.CheckOutDate - registration.CheckInDate).Days;
            var age = this.GetYearsDiff(dateToCompare, person.BirthDate);

            return new Tuple<string, int, int>("", nightsCount, age);
        }

        private string ValidateInsertAccomodation(AccRegister.InsertAccomodationType accomodation)
        {
            if (accomodation == null)
            {
                return "Element \"InsertAccomodation\" is required";
            }

            if (string.IsNullOrEmpty(accomodation.RegistrationUID))
            {
                return "Element \"InsertAccomodation.RegistrationUID\" is required";
            }

            if (accomodation.Person == null)
            {
                return "Element \"InsertAccomodation.Person\" is required";
            }

            if (accomodation.Registration == null)
            {
                return "Element \"InsertAccomodation.Registration\" is required";
            }

            string personMessage = this.ValidatePersonType(accomodation.Person);
            if (personMessage != null)
            {
                return personMessage;
            }

            string registrationMessage = this.ValidateRegistrationType(accomodation.Registration);
            if (registrationMessage != null)
            {
                return registrationMessage;
            }

            return null;
        }

        private string ValidateUpdateAccomodation(AccRegister.UpdateAccomodationType accomodation)
        {
            if (accomodation == null)
            {
                return "Element \"UpdateAccomodation\" is required";
            }

            if (accomodation.Person == null)
            {
                return "Element \"UpdateAccomodation.Person\" is required";
            }

            if (accomodation.Registration == null)
            {
                return "Element \"UpdateAccomodation.Registration\" is required";
            }

            string personMessage = this.ValidatePersonType(accomodation.Person);
            if (personMessage != null)
            {
                return personMessage;
            }

            string registrationMessage = this.ValidateRegistrationType(accomodation.Registration);
            if (registrationMessage != null)
            {
                return registrationMessage;
            }

            return null;
        }

        private string ValidatePersonType(AccRegister.PersonType person)
        {
            if (person.BirthDate == default(DateTime))
            {
                return "BirthDate is required";
            }

            if (string.IsNullOrEmpty(person.IdentityDocumentCountryCode))
            {
                return "IdentityDocumentCountryCode is required";
            }

            return null;
        }

        private string ValidateRegistrationType(AccRegister.RegistrationType registration)
        {
            if (registration.RegistrationDate == default(DateTime))
            {
                return "RegistrationDate is required";
            }

            if (registration.CheckInDate == default(DateTime))
            {
                return "CheckInDate is required";
            }

            if (registration.CheckOutDate == default(DateTime))
            {
                return "CheckOutDate is required";
            }

            return null;
        }

        #endregion

        #region Helpers

        private List<LidoDataType> OrderLidoData(List<LidoDataType> data)
        {
            if (data == null)
            {
                return new List<LidoDataType>();
            }

            var result = data
                .Where(x => x != null)
                .Select(x => new
                {
                    Element = x,
                    Order =
                        x.Change == ChangeLidoType.Delete ? 1 :
                        x.Change == ChangeLidoType.Insert ? 2 : 3,
                })
                .OrderBy(x => x.Order)
                .Select(x => x.Element)
                .ToList();

            return result;
        }

        private object ExtractIdentityDocTypeId(DbConnection connection, PersonType lido)
        {
            object identityDocTypeId = DBNull.Value;
            if (lido.IdentityDocumentTypeCodeSpecified)
            {
                identityDocTypeId = this.GetIdFromNomenclature(connection, "identity_document_type", lido.IdentityDocumentTypeCode.ToString());
            }

            return identityDocTypeId;
        }

        private object ExtractIdentityDocTypeId(DbConnection connection, AccRegister.PersonType person)
        {
            object identityDocTypeId = DBNull.Value;
            if (person.IdentityDocumentTypeCodeSpecified)
            {
                identityDocTypeId = this.GetIdFromNomenclature(connection, "identity_document_type", person.IdentityDocumentTypeCode.ToString());
            }

            return identityDocTypeId;
        }

        private string CombineErrors(List<string> errors)
        {
            var message = string.Join(Environment.NewLine, errors);
            return message;
        }

        private bool IsEmpty(string xml)
        {
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(xml);
            bool isEmpty = string.IsNullOrEmpty(doc.InnerText);
            return isEmpty;
        }

        private object GetLongValue(object value)
        {
            if (value != DBNull.Value)
            {
                return Convert.ToInt64(value);
            }

            return value;
        }

        private bool Contains(string text, string value, StringComparison comp)
        {
            return text?.IndexOf(value, comp) >= 0;
        }

        private string GetXmlEnumAttributeValue(object value)
        {
            if (value == null) return null;

            var enumType = value.GetType();
            if (!enumType.IsEnum) return null;

            var member = enumType.GetMember(value.ToString()).FirstOrDefault();
            if (member == null) return null;

            var attribute = member.GetCustomAttributes(false).OfType<XmlEnumAttribute>().FirstOrDefault();
            return attribute?.Name;
        }

        private int GetYearsDiff(DateTime biggerDate, DateTime smallerDate)
        {
            int age = biggerDate.Year - smallerDate.Year;
            if (smallerDate > biggerDate.AddYears(-age))
            {
                age--;
            }

            return age;
        }

        private Tuple<object, object> ExtractEgnLnch(PersonType lido)
        {
            object egn = DBNull.Value;
            object lnch = DBNull.Value;
            var identityNumber = lido.GetValueOrNull(r => r.IdentityNumber);
            if (lido.IdentityDocumentCountryCode == BgNationalityCode)
            {
                egn = identityNumber;
            }
            else
            {
                lnch = identityNumber;
            }

            return new Tuple<object, object>(egn, lnch);
        }

        private Tuple<object, object> ExtractEgnLnch(AccRegister.PersonType person)
        {
            object egn = DBNull.Value;
            object lnch = DBNull.Value;
            var identityNumber = person.GetValueOrNull(r => r.IdentityNumber);
            if (person.IdentityDocumentCountryCode == BgNationalityCode)
            {
                egn = identityNumber;
            }
            else
            {
                lnch = identityNumber;
            }

            return new Tuple<object, object>(egn, lnch);
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

        // Singleton pattern: ако са празни ги попълва, иначе ги връща
        private List<string> GetCountriesWithOnlyStatisticalData(DbConnection connection)
        {
            if (this._countriesWithOnlyStatisticalData != null)
            {
                return this._countriesWithOnlyStatisticalData;
            }

            string sql = "select code from country where statistical_data_only = true";
            DbCommand command = CreateCommand(sql, connection);
            DataTable table = new DataTable();
            CreateDataAdapter(command).Fill(table);

            this._countriesWithOnlyStatisticalData = table.Rows.Cast<DataRow>()
                .Select(x => x["code"].ToString().ToUpper())
                .OrderBy(x => x)
                .ToList();
            return _countriesWithOnlyStatisticalData;
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

        private bool IsValidEmail(string email)
        {
            var obj = new EmailObject { Email = email };

            var context = new ValidationContext(obj);
            var results = new List<ValidationResult>();
            bool isValid = Validator.TryValidateObject(obj, context, results, true);
            return isValid;
        }

        private class EmailObject
        {
            [EmailAddress]
            public string Email { get; set; }
        }

        #endregion
    }
}
