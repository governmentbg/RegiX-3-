using System;
using TechnoLogica.RegiX.Common;
using TechnoLogica.RegiX.Common.ObjectMapping;
using TechnoLogica.RegiX.Common.Utils;
using System.Data;
using System.ComponentModel.Composition;
using TechnoLogica.RegiX.Common.DataContracts;
using System.Data.SqlClient;
using System.ServiceModel;
using TechnoLogica.RegiX.Adapters.Common.ExportExtension;
using TechnoLogica.RegiX.Adapters.Common.DataContracts;
using TechnoLogica.RegiX.Common.DataContracts.Parameter;
using TechnoLogica.RegiX.Adapters.Common.ObjectMapping;

namespace TechnoLogica.RegiX.GvaAircraftsAdapter.AdapterService
{
    [Export(typeof(IAdapterService))]
    [ExportFullName(typeof(GvaAircraftsAdapter), typeof(IAdapterService))]
    [ExportSimpleName(typeof(GvaAircraftsAdapter), typeof(IAdapterService))]
    public class GvaAircraftsAdapter : SQLServerAdapterService.SQLServerAdapterService , IGvaAircraftsAdapter, IAdapterService
    {
        [Export(typeof(ParameterInfo))]
        [ExportFullName(typeof(GvaAircraftsAdapter), typeof(ParameterInfo))]
        public static ParameterInfo<string> ProcedureNameForMSNSearch =
            new ParameterInfo<string>("[RegiXSearchByMSN]")
            {
                Key = "ProcedureName",
                Description = "Name of the procedure which is executed for AircraftsData",
                OwnerAssembly = typeof(GvaAircraftsAdapter).Assembly
            };

        [Export(typeof(ParameterInfo))]
        [ExportFullName(typeof(GvaAircraftsAdapter), typeof(ParameterInfo))]
        public static ParameterInfo<string> ProcedureNameForIdentifierSearch =
            new ParameterInfo<string>("[RegiXSearchByIdentifier]")
            {
                Key = "ProcedureName2",
                Description = "Name of the procedure which is executed for BurdensData",
                OwnerAssembly = typeof(GvaAircraftsAdapter).Assembly
            };

        [Export(typeof(ParameterInfo))]
        [ExportFullName(typeof(GvaAircraftsAdapter), typeof(ParameterInfo))]
        public static ParameterInfo<string> DbUser =
            new ParameterInfo<string>("[dbo]")
            {
                Key = "DbUser",
                Description = "Name of user where views are created",
                OwnerAssembly = typeof(GvaAircraftsAdapter).Assembly
            };

        [Export(typeof(ParameterInfo))]
        [ExportFullName(typeof(GvaAircraftsAdapter), typeof(ParameterInfo))]
        public static ParameterInfo<string> ConnectionString =
            new ParameterInfo<string>(@"data source=REGIX2-sql.regix.tlogica.com;initial catalog=Gva.2016.08.01;user id=;password=;")
            {
                Key = "ConnectionString",
                Description = "Connection string",
                OwnerAssembly = typeof(GvaAircraftsAdapter).Assembly
            };

        private AircraftsResponse ExecuteOperation(SqlCommand command, AccessMatrix accessMatrix)
        {
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
            ds.Tables[0].TableName = "Aircraft";
            ds.Tables[1].TableName = "Registrations";
            ds.Tables[2].TableName = "OwnersEntities";
            ds.Tables[3].TableName = "OwnersPersons";
            ds.Tables[4].TableName = "OperatorsEntites";
            ds.Tables[5].TableName = "OperatorsPersons";
            ds.Tables[6].TableName = "Debts";

            ds.Tables["Aircraft"].ChildRelations.Add(
                  new DataRelation
                      ("AircraftRegistrations",
                      ds.Tables["Aircraft"].Columns["AircraftId"],
                      ds.Tables["Registrations"].Columns["AircraftId"],
                      true));

            ds.Tables["Registrations"].ChildRelations.Add(
                  new DataRelation
                      ("RegistrationsOwnersEntities",
                      ds.Tables["Registrations"].Columns["RegistrationId"],
                      ds.Tables["OwnersEntities"].Columns["RegistrationId"],
                      true));

            ds.Tables["Registrations"].ChildRelations.Add(
                 new DataRelation
                     ("RegistrationsOwnersPerson",
                     ds.Tables["Registrations"].Columns["RegistrationId"],
                     ds.Tables["OwnersPersons"].Columns["RegistrationId"],
                     true));

            ds.Tables["Registrations"].ChildRelations.Add(
                 new DataRelation
                     ("RegistrationsOperatorsEntites",
                     ds.Tables["Registrations"].Columns["RegistrationId"],
                     ds.Tables["OperatorsEntites"].Columns["RegistrationId"],
                     true));

            ds.Tables["Registrations"].ChildRelations.Add(
                 new DataRelation
                     ("RegistrationsOperatorsPerson",
                     ds.Tables["Registrations"].Columns["RegistrationId"],
                     ds.Tables["OperatorsPersons"].Columns["RegistrationId"],
                     true));

            ds.Tables["Aircraft"].ChildRelations.Add(
                   new DataRelation
                       ("AircraftDebts",
                       ds.Tables["Aircraft"].Columns["AircraftId"],
                       ds.Tables["Debts"].Columns["AircraftId"],
                       true));

            DataSetMapper<AircraftsResponse> mapper = CreateMapForAircratfResponse(accessMatrix);
            AircraftsResponse result = new AircraftsResponse();
            mapper.Map(ds, result);

            return result;
                
        }

        public CommonSignedResponse<AircraftsByMSNType, AircraftsResponse> GetAircraftsByMSN(AircraftsByMSNType argument, AccessMatrix accessMatrix, AdapterAdditionalParameters aditionalParameters)
        {
            Guid id = Guid.NewGuid();
            LogData(aditionalParameters, new { Request = argument.XmlSerialize(), Guid = id });
            try
            {
                if(argument == null  || ( string.IsNullOrEmpty(argument.MSN) && string.IsNullOrEmpty(argument.RegMark)))
                {
                    //TODO: "Поне едно от полетата MSN(Сериен номер) или Регистрационен знак трябва да е попълнено!"
                    throw new FaultException();
                }

                SqlCommand command = new SqlCommand();
                //command.Connection = connection;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText =  DbUser.Value + "." + ProcedureNameForMSNSearch.CurrentValue;
                if (!string.IsNullOrEmpty(argument.MSN))
                {
                    command.Parameters.AddWithValue("@msn", argument.MSN);
                }
                else
                {
                    command.Parameters.AddWithValue("@msn", DBNull.Value);
                }
                if (!string.IsNullOrEmpty(argument.ICAO))
                {
                    command.Parameters.AddWithValue("@icao", argument.ICAO);
                }
                else
                {
                    command.Parameters.AddWithValue("@icao", DBNull.Value);
                }
                if (!string.IsNullOrEmpty(argument.RegMark))
                {
                    command.Parameters.AddWithValue("@regmark", argument.RegMark);
                }
                else
                {
                    command.Parameters.AddWithValue("@regmark", DBNull.Value);
                }
                
                return SigningUtils.CreateAndSign(
                    argument,
                    ExecuteOperation(command, accessMatrix),
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

        private DataSetMapper<AircraftsResponse> CreateMapForAircratfResponse(AccessMatrix accessMatrix)
        {
            DataSetMapper<AircraftsResponse> mapper = new DataSetMapper<AircraftsResponse>(accessMatrix);
            
            //Aircraft
            mapper.AddDataSetMap((r) => r.Aircraft, (ds) => ds.Tables["Aircraft"].Rows);
            
            mapper.AddDataColumnMap((r) => r.Aircraft[0].AirCategory.Code, "AirCategoryCode");
            mapper.AddDataColumnMap((r) => r.Aircraft[0].AirCategory.Name, "AirCategoryName");
            mapper.AddDataColumnMap((r) => r.Aircraft[0].ICAO, "Icao");
            mapper.AddDataColumnMap((r) => r.Aircraft[0].BGModelName, "Model");
            mapper.AddDataColumnMap((r) => r.Aircraft[0].ENModelName, "ModelEn");
            mapper.AddDataColumnMap((r) => r.Aircraft[0].MSNSerialNumber, "Msn");
            mapper.AddDataColumnMap((r) => r.Aircraft[0].Producer.Name, "ProducerName");
            mapper.AddDataColumnMap((r) => r.Aircraft[0].Producer.NameEn, "ProducerNameEn");
            mapper.AddDataColumnMap((r) => r.Aircraft[0].Producer.CountryCode, "ProducerCountryCode");
            mapper.AddDataColumnMap((r) => r.Aircraft[0].Producer.CountryName, "ProducerCountryName");

            //Registrations
            mapper.AddDataRowMap((r) => r.Aircraft[0].Registrations.Registration, (dr) => dr.GetChildRows("AircraftRegistrations"));
            mapper.AddDataColumnMap((r) => r.Aircraft[0].Registrations.Registration[0].RegistrationNumber, "RegNumber");
            mapper.AddDataColumnMap((r) => r.Aircraft[0].Registrations.Registration[0].RegistrationMark, "RegMark");
            mapper.AddDataColumnMap((r) => r.Aircraft[0].Registrations.Registration[0].RegistrationDate, "RegistrationDate");
            mapper.AddDataColumnMap((r) => r.Aircraft[0].Registrations.Registration[0].ActNumber, "ActNumber");
            mapper.AddDataColumnMap((r) => r.Aircraft[0].Registrations.Registration[0].IsLastRegistration, "IsLast");
            mapper.AddDataColumnMap((r) => r.Aircraft[0].Registrations.Registration[0].RegistrationStatus.IsActiveRegistration, "IsActive");
            mapper.AddDataColumnMap((r) => r.Aircraft[0].Registrations.Registration[0].RegistrationStatus.StatusCode, "RegistrationStatusId");
            mapper.AddDataColumnMap((r) => r.Aircraft[0].Registrations.Registration[0].RegistrationStatus.StatusName, "RegistrationStatusName");
            mapper.AddDataColumnMap((r) => r.Aircraft[0].Registrations.Registration[0].RegistrationDocument.DocNumber, "IncomingGvaDocNumber");
            mapper.AddDataColumnMap((r) => r.Aircraft[0].Registrations.Registration[0].RegistrationDocument.DocDate, "IncomingGvaDocDate");
            mapper.AddDataColumnMap((r) => r.Aircraft[0].Registrations.Registration[0].RegistrationDocument.Description, "IncomingGvaDocDesc");
            mapper.AddDataColumnMap((r) => r.Aircraft[0].Registrations.Registration[0].DeregistrationInfo.DeregistrationDate, "DeregistrationDate");
            mapper.AddDataColumnMap((r) => r.Aircraft[0].Registrations.Registration[0].DeregistrationInfo.DeregistrationReason, "DeregistrationReason");
            mapper.AddDataColumnMap((r) => r.Aircraft[0].Registrations.Registration[0].DeregistrationInfo.DeregistrationDescription, "DeregistrationDescription");
            mapper.AddDataColumnMap((r) => r.Aircraft[0].Registrations.Registration[0].DeregistrationInfo.DeregistrationCountryCode, "DeregistrationCountryCode");
            mapper.AddDataColumnMap((r) => r.Aircraft[0].Registrations.Registration[0].DeregistrationInfo.DeregistrationCountryName, "DeregistrationCountryName");
            mapper.AddDataColumnMap((r) => r.Aircraft[0].Registrations.Registration[0].LeasingInfo.DocNumber, "LeasingDocNumber");
            mapper.AddDataColumnMap((r) => r.Aircraft[0].Registrations.Registration[0].LeasingInfo.DocDate, "LeasingDocDate");
            mapper.AddDataColumnMap((r) => r.Aircraft[0].Registrations.Registration[0].LeasingInfo.EndDate, "LeasingEndDate");
            mapper.AddDataColumnMap((r) => r.Aircraft[0].Registrations.Registration[0].LeasingInfo.Agreement, "LeasingAgreement");
            mapper.AddDataColumnMap((r) => r.Aircraft[0].Registrations.Registration[0].LeasingInfo.Lessor.Person.Identifier, "LeasingPersonIdentifier");
            mapper.AddDataColumnMap((r) => r.Aircraft[0].Registrations.Registration[0].LeasingInfo.Lessor.Person.Names, "LeasingPersonNames");
            mapper.AddDataColumnMap((r) => r.Aircraft[0].Registrations.Registration[0].LeasingInfo.Lessor.Entity.Identifier, "LeasingEntityIdentifier");
            mapper.AddDataColumnMap((r) => r.Aircraft[0].Registrations.Registration[0].LeasingInfo.Lessor.Entity.Name, "LeasingEntityName");

            //OwnersEntities
            mapper.AddDataRowMap((r) => r.Aircraft[0].Registrations.Registration[0].Owners.EntitiesList.Entity, (dr) => dr.GetChildRows("RegistrationsOwnersEntities"));
            mapper.AddDataColumnMap((r) => r.Aircraft[0].Registrations.Registration[0].Owners.EntitiesList.Entity[0].Identifier, "Identifier");
            mapper.AddDataColumnMap((r) => r.Aircraft[0].Registrations.Registration[0].Owners.EntitiesList.Entity[0].Name, "Name");

            //OwnersPerson
            mapper.AddDataRowMap((r) => r.Aircraft[0].Registrations.Registration[0].Owners.PersonList.Person, (dr) => dr.GetChildRows("RegistrationsOwnersPerson"));
            mapper.AddDataColumnMap((r) => r.Aircraft[0].Registrations.Registration[0].Owners.PersonList.Person[0].Identifier, "Identifier");
            mapper.AddDataColumnMap((r) => r.Aircraft[0].Registrations.Registration[0].Owners.PersonList.Person[0].Names, "Name");

            //OperatorsEntites
            mapper.AddDataRowMap((r) => r.Aircraft[0].Registrations.Registration[0].Operators.EntitiesList.Entity, (dr) => dr.GetChildRows("RegistrationsOperatorsEntites"));
            mapper.AddDataColumnMap((r) => r.Aircraft[0].Registrations.Registration[0].Operators.EntitiesList.Entity[0].Identifier, "Identifier");
            mapper.AddDataColumnMap((r) => r.Aircraft[0].Registrations.Registration[0].Operators.EntitiesList.Entity[0].Name, "Name");

            //OperatorPerson
            mapper.AddDataRowMap((r) => r.Aircraft[0].Registrations.Registration[0].Operators.PersonList.Person, (dr) => dr.GetChildRows("RegistrationsOperatorsPerson"));
            mapper.AddDataColumnMap((r) => r.Aircraft[0].Registrations.Registration[0].Operators.PersonList.Person[0].Identifier, "Identifier");
            mapper.AddDataColumnMap((r) => r.Aircraft[0].Registrations.Registration[0].Operators.PersonList.Person[0].Names, "Name");

            //Debts
            mapper.AddDataRowMap((r) => r.Aircraft[0].Debts.Debt, (dr) => dr.GetChildRows("AircraftDebts"));
            mapper.AddDataColumnMap((r) => r.Aircraft[0].Debts.Debt[0].InputDate, "Date");
            mapper.AddDataColumnMap((r) => r.Aircraft[0].Debts.Debt[0].DebtType, "DebtType");
            mapper.AddDataColumnMap((r) => r.Aircraft[0].Debts.Debt[0].IsActive, "IsActive");
            mapper.AddDataColumnMap((r) => r.Aircraft[0].Debts.Debt[0].Applicant.Identifier, "ApplicantBulstat");
            mapper.AddDataColumnMap((r) => r.Aircraft[0].Debts.Debt[0].Applicant.Name, "ApplicantName");
            mapper.AddDataColumnMap((r) => r.Aircraft[0].Debts.Debt[0].Document.IncomingNumber, "IncomingGvaDocNumber");
            mapper.AddDataColumnMap((r) => r.Aircraft[0].Debts.Debt[0].Document.IncomingDate, "IncomingGvaDocDate");
            mapper.AddDataColumnMap((r) => r.Aircraft[0].Debts.Debt[0].Document.ExternalNumber, "TheirDocNumber");
            mapper.AddDataColumnMap((r) => r.Aircraft[0].Debts.Debt[0].Document.ExternalDate, "TheirDocDate");
            mapper.AddDataColumnMap((r) => r.Aircraft[0].Debts.Debt[0].Repayment.RepaymentDate, "RepaymentDate");
            mapper.AddDataColumnMap((r) => r.Aircraft[0].Debts.Debt[0].Repayment.RepaymentDocument.IncomingDate, "RepaymentIncomingGvaDocDate");
            mapper.AddDataColumnMap((r) => r.Aircraft[0].Debts.Debt[0].Repayment.RepaymentDocument.IncomingNumber, "RepaymentIncomingGvaDocNumber");
            mapper.AddDataColumnMap((r) => r.Aircraft[0].Debts.Debt[0].Repayment.RepaymentDocument.ExternalDate, "RepaymentTheirDocDate");
            mapper.AddDataColumnMap((r) => r.Aircraft[0].Debts.Debt[0].Repayment.RepaymentDocument.ExternalNumber, "RepaymentTheirDocNumber");
            mapper.AddDataColumnMap((r) => r.Aircraft[0].Debts.Debt[0].Repayment.Notes, "RepaymentNotes");
            mapper.AddDataColumnMap((r) => r.Aircraft[0].Debts.Debt[0].Notes, "Notes");

            return mapper;
        }

        public CommonSignedResponse<AircraftsByOwnerType, AircraftsResponse> GetAircraftsByOwner(AircraftsByOwnerType argument, AccessMatrix accessMatrix, AdapterAdditionalParameters aditionalParameters)
        {
            Guid id = Guid.NewGuid();
            LogData(aditionalParameters, new { Request = argument.XmlSerialize(), Guid = id });
            try
            {
                SqlCommand command = new SqlCommand();
                //command.Connection = connection;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = DbUser.Value + "." + ProcedureNameForIdentifierSearch.CurrentValue;

                command.Parameters.AddWithValue("@identifier", argument.OwnerID);
                if(argument.DateFromSpecified)
                {
                    command.Parameters.AddWithValue("@dateFrom",  argument.DateFrom);
                }
                else
                {
                    command.Parameters.AddWithValue("@dateFrom", DBNull.Value);
                }
                if (argument.DateToSpecified)
                {
                    command.Parameters.AddWithValue("@dateTo", argument.DateTo);
                }
                else
                {
                    command.Parameters.AddWithValue("@dateTo", DBNull.Value);
                }
                

                return SigningUtils.CreateAndSign(
                    argument,
                    ExecuteOperation(command, accessMatrix),
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

       
    }
}
