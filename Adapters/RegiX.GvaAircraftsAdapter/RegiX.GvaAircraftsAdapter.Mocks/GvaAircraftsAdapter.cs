namespace TechnoLogica.RegiX.GvaAircraftsAdapter.AdapterService
{
    //public class GvaAircraftsAdapter : SQLServerAdapterService.SQLServerAdapterService , IGvaAircraftsAdapter, IAdapterService
    //{
    //    public override string CheckRegisterConnection()
    //    {
    //        return Constants.ConnectionOk;
    //    }

    //    private AircraftsResponse ExecuteOperation(string argument)
    //    {
    //        AircraftsResponse result = new AircraftsResponse();
    //        string fileName = AppDomain.CurrentDomain.BaseDirectory+ "\\XMLData\\"+ argument + ".xml";

    //        if( File.Exists(fileName))
    //        {
    //            result = (AircraftsResponse)FileUtils.ReadXml("\\XMLData\\" + argument + ".xml", typeof(AircraftsResponse));
    //        }
    //        else
    //        {
    //            result = (AircraftsResponse)FileUtils.ReadXml("\\XMLData\\default.xml", typeof(AircraftsResponse));
    //        }
    //        return result;

    //    }

    //    public CommonSignedResponse<AircraftsByMSNType, AircraftsResponse> GetAircraftsByMSN(AircraftsByMSNType argument, AccessMatrix accessMatrix, AdapterAdditionalParameters aditionalParameters)
    //    {
    //        Guid id = Guid.NewGuid();
    //        LogData(aditionalParameters, new { Request = argument.XmlSerialize(), Guid = id });
    //        try
    //        {
    //            AircraftsResponse response = ExecuteOperation(argument.MSN);

    //            return SigningUtils.CreateAndSign(
    //                argument,
    //                response,
    //                accessMatrix,
    //                aditionalParameters
    //            );

    //        }
    //        catch (Exception ex)
    //        {
    //            LogError(aditionalParameters, ex, new { Guid = id });
    //            throw ex;
    //        }
    //    }

    //    public CommonSignedResponse<AircraftsByOwnerType, AircraftsResponse> GetAircraftsByOwner(AircraftsByOwnerType argument, AccessMatrix accessMatrix, AdapterAdditionalParameters aditionalParameters)
    //    {
    //        Guid id = Guid.NewGuid();
    //        LogData(aditionalParameters, new { Request = argument.XmlSerialize(), Guid = id });
    //        try
    //        {
    //            AircraftsResponse response = ExecuteOperation(argument.OwnerID);

    //            return SigningUtils.CreateAndSign(
    //                argument,
    //                response,
    //                accessMatrix,
    //                aditionalParameters
    //            );

    //        }
    //        catch (Exception ex)
    //        {
    //            LogError(aditionalParameters, ex, new { Guid = id });
    //            throw ex;
    //        }
    //    }

    //    //private DataSetMapper<AircraftsResponse> CreateMapForAircratfResponse(AccessMatrix accessMatrix)
    //    //{
    //    //    DataSetMapper<AircraftsResponse> mapper = new DataSetMapper<AircraftsResponse>(accessMatrix);

    //    //    //Aircraft
    //    //    mapper.AddDataSetMap((r) => r.Aircraft, (ds) => ds.Tables["Aircraft"].Rows);

    //    //    mapper.AddDataColumnMap((r) => r.Aircraft[0].AirCategory.Code, "AirCategoryCode");
    //    //    mapper.AddDataColumnMap((r) => r.Aircraft[0].AirCategory.Name, "AirCategoryName");
    //    //    mapper.AddDataColumnMap((r) => r.Aircraft[0].ICAO, "Icao");
    //    //    mapper.AddDataColumnMap((r) => r.Aircraft[0].BGModelName, "Model");
    //    //    mapper.AddDataColumnMap((r) => r.Aircraft[0].ENModelName, "ModelEn");
    //    //    mapper.AddDataColumnMap((r) => r.Aircraft[0].MSNSerialNumber, "Msn");
    //    //    mapper.AddDataColumnMap((r) => r.Aircraft[0].Producer.Name, "ProducerName");
    //    //    mapper.AddDataColumnMap((r) => r.Aircraft[0].Producer.NameEn, "ProducerNameEn");
    //    //    mapper.AddDataColumnMap((r) => r.Aircraft[0].Producer.CountryCode, "ProducerCountryCode");
    //    //    mapper.AddDataColumnMap((r) => r.Aircraft[0].Producer.CountryName, "ProducerCountryName");

    //    //    //Registrations
    //    //    mapper.AddDataRowMap((r) => r.Aircraft[0].Registrations.Registration, (dr) => dr.GetChildRows("AircraftRegistrations"));
    //    //    mapper.AddDataColumnMap((r) => r.Aircraft[0].Registrations.Registration[0].RegistrationNumber, "RegNumber");
    //    //    mapper.AddDataColumnMap((r) => r.Aircraft[0].Registrations.Registration[0].RegistrationMark, "RegMark");
    //    //    mapper.AddDataColumnMap((r) => r.Aircraft[0].Registrations.Registration[0].RegistrationDate, "RegistrationDate");
    //    //    mapper.AddDataColumnMap((r) => r.Aircraft[0].Registrations.Registration[0].ActNumber, "ActNumber");
    //    //    mapper.AddDataColumnMap((r) => r.Aircraft[0].Registrations.Registration[0].IsLastRegistration, "IsLast");
    //    //    mapper.AddDataColumnMap((r) => r.Aircraft[0].Registrations.Registration[0].RegistrationStatus.IsActiveRegistration, "IsActive");
    //    //    mapper.AddDataColumnMap((r) => r.Aircraft[0].Registrations.Registration[0].RegistrationStatus.StatusCode, "RegistrationStatusId");
    //    //    mapper.AddDataColumnMap((r) => r.Aircraft[0].Registrations.Registration[0].RegistrationStatus.StatusName, "RegistrationStatusName");
    //    //    mapper.AddDataColumnMap((r) => r.Aircraft[0].Registrations.Registration[0].RegistrationDocument.DocNumber, "IncomingGvaDocNumber");
    //    //    mapper.AddDataColumnMap((r) => r.Aircraft[0].Registrations.Registration[0].RegistrationDocument.DocDate, "IncomingGvaDocDate");
    //    //    mapper.AddDataColumnMap((r) => r.Aircraft[0].Registrations.Registration[0].RegistrationDocument.Description, "IncomingGvaDocDesc");
    //    //    mapper.AddDataColumnMap((r) => r.Aircraft[0].Registrations.Registration[0].DeregistrationInfo.DeregistrationDate, "DeregistrationDate");
    //    //    mapper.AddDataColumnMap((r) => r.Aircraft[0].Registrations.Registration[0].DeregistrationInfo.DeregistrationReason, "DeregistrationReason");
    //    //    mapper.AddDataColumnMap((r) => r.Aircraft[0].Registrations.Registration[0].DeregistrationInfo.DeregistrationDescription, "DeregistrationDescription");
    //    //    mapper.AddDataColumnMap((r) => r.Aircraft[0].Registrations.Registration[0].DeregistrationInfo.DeregistrationCountryCode, "DeregistrationCountryCode");
    //    //    mapper.AddDataColumnMap((r) => r.Aircraft[0].Registrations.Registration[0].DeregistrationInfo.DeregistrationCountryName, "DeregistrationCountryName");
    //    //    mapper.AddDataColumnMap((r) => r.Aircraft[0].Registrations.Registration[0].LeasingInfo.DocNumber, "LeasingDocNumber");
    //    //    mapper.AddDataColumnMap((r) => r.Aircraft[0].Registrations.Registration[0].LeasingInfo.DocDate, "LeasingDocDate");
    //    //    mapper.AddDataColumnMap((r) => r.Aircraft[0].Registrations.Registration[0].LeasingInfo.EndDate, "LeasingEndDate");
    //    //    mapper.AddDataColumnMap((r) => r.Aircraft[0].Registrations.Registration[0].LeasingInfo.Agreement, "LeasingAgreement");
    //    //    mapper.AddDataColumnMap((r) => r.Aircraft[0].Registrations.Registration[0].LeasingInfo.Lessor.Person.Identifier, "LeasingPersonIdentifier");
    //    //    mapper.AddDataColumnMap((r) => r.Aircraft[0].Registrations.Registration[0].LeasingInfo.Lessor.Person.Names, "LeasingPersonNames");
    //    //    mapper.AddDataColumnMap((r) => r.Aircraft[0].Registrations.Registration[0].LeasingInfo.Lessor.Entity.Identifier, "LeasingEntityIdentifier");
    //    //    mapper.AddDataColumnMap((r) => r.Aircraft[0].Registrations.Registration[0].LeasingInfo.Lessor.Entity.Name, "LeasingEntityName");

    //    //    //OwnersEntities
    //    //    mapper.AddDataRowMap((r) => r.Aircraft[0].Registrations.Registration[0].Owners.EntitiesList.Entity, (dr) => dr.GetChildRows("RegistrationsOwnersEntities"));
    //    //    mapper.AddDataColumnMap((r) => r.Aircraft[0].Registrations.Registration[0].Owners.EntitiesList.Entity[0].Identifier, "Identifier");
    //    //    mapper.AddDataColumnMap((r) => r.Aircraft[0].Registrations.Registration[0].Owners.EntitiesList.Entity[0].Name, "Name");

    //    //    //OwnersPerson
    //    //    mapper.AddDataRowMap((r) => r.Aircraft[0].Registrations.Registration[0].Owners.PersonList.Person, (dr) => dr.GetChildRows("RegistrationsOwnersPerson"));
    //    //    mapper.AddDataColumnMap((r) => r.Aircraft[0].Registrations.Registration[0].Owners.PersonList.Person[0].Identifier, "Identifier");
    //    //    mapper.AddDataColumnMap((r) => r.Aircraft[0].Registrations.Registration[0].Owners.PersonList.Person[0].Names, "Name");

    //    //    //OperatorsEntites
    //    //    mapper.AddDataRowMap((r) => r.Aircraft[0].Registrations.Registration[0].Operators.EntitiesList.Entity, (dr) => dr.GetChildRows("RegistrationsOperatorsEntites"));
    //    //    mapper.AddDataColumnMap((r) => r.Aircraft[0].Registrations.Registration[0].Operators.EntitiesList.Entity[0].Identifier, "Identifier");
    //    //    mapper.AddDataColumnMap((r) => r.Aircraft[0].Registrations.Registration[0].Operators.EntitiesList.Entity[0].Name, "Name");

    //    //    //OperatorPerson
    //    //    mapper.AddDataRowMap((r) => r.Aircraft[0].Registrations.Registration[0].Operators.PersonList.Person, (dr) => dr.GetChildRows("RegistrationsOperatorsPerson"));
    //    //    mapper.AddDataColumnMap((r) => r.Aircraft[0].Registrations.Registration[0].Operators.PersonList.Person[0].Identifier, "Identifier");
    //    //    mapper.AddDataColumnMap((r) => r.Aircraft[0].Registrations.Registration[0].Operators.PersonList.Person[0].Names, "Name");

    //    //    //Debts
    //    //    mapper.AddDataRowMap((r) => r.Aircraft[0].Debts.Debt, (dr) => dr.GetChildRows("AircraftDebts"));
    //    //    mapper.AddDataColumnMap((r) => r.Aircraft[0].Debts.Debt[0].InputDate, "Date");
    //    //    mapper.AddDataColumnMap((r) => r.Aircraft[0].Debts.Debt[0].DebtType, "DebtType");
    //    //    mapper.AddDataColumnMap((r) => r.Aircraft[0].Debts.Debt[0].IsActive, "IsActive");
    //    //    mapper.AddDataColumnMap((r) => r.Aircraft[0].Debts.Debt[0].Applicant.Identifier, "ApplicantBulstat");
    //    //    mapper.AddDataColumnMap((r) => r.Aircraft[0].Debts.Debt[0].Applicant.Name, "ApplicantName");
    //    //    mapper.AddDataColumnMap((r) => r.Aircraft[0].Debts.Debt[0].Document.IncomingNumber, "IncomingGvaDocNumber");
    //    //    mapper.AddDataColumnMap((r) => r.Aircraft[0].Debts.Debt[0].Document.IncomingDate, "IncomingGvaDocDate");
    //    //    mapper.AddDataColumnMap((r) => r.Aircraft[0].Debts.Debt[0].Document.ExternalNumber, "TheirDocNumber");
    //    //    mapper.AddDataColumnMap((r) => r.Aircraft[0].Debts.Debt[0].Document.ExternalDate, "TheirDocDate");
    //    //    mapper.AddDataColumnMap((r) => r.Aircraft[0].Debts.Debt[0].Repayment.RepaymentDate, "RepaymentDate");
    //    //    mapper.AddDataColumnMap((r) => r.Aircraft[0].Debts.Debt[0].Repayment.RepaymentDocument.IncomingDate, "RepaymentIncomingGvaDocDate");
    //    //    mapper.AddDataColumnMap((r) => r.Aircraft[0].Debts.Debt[0].Repayment.RepaymentDocument.IncomingNumber, "RepaymentIncomingGvaDocNumber");
    //    //    mapper.AddDataColumnMap((r) => r.Aircraft[0].Debts.Debt[0].Repayment.RepaymentDocument.ExternalDate, "RepaymentTheirDocDate");
    //    //    mapper.AddDataColumnMap((r) => r.Aircraft[0].Debts.Debt[0].Repayment.RepaymentDocument.ExternalNumber, "RepaymentTheirDocNumber");
    //    //    mapper.AddDataColumnMap((r) => r.Aircraft[0].Debts.Debt[0].Repayment.Notes, "RepaymentNotes");
    //    //    mapper.AddDataColumnMap((r) => r.Aircraft[0].Debts.Debt[0].Notes, "Notes");

    //    //    return mapper;
    //    //}



    //}
}
