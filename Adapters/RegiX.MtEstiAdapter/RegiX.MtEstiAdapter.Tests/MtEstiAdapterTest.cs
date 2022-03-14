using Microsoft.VisualStudio.TestTools.UnitTesting;
using RegiX.Adapters.FileParameterStore;
using System;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.IO;
using System.Xml.Serialization;
using TechnoLogica.RegiX.Adapters.TestUtils;
using TechnoLogica.RegiX.Common;
using TechnoLogica.RegiX.Common.DataContracts;
using TechnoLogica.RegiX.Common.ObjectMapping;
using TechnoLogica.RegiX.MtEstiAdapter.AdapterService;

namespace TechnoLogica.RegiX.MtEstiAdapter.Tests
{
    [TestClass]
    public class MtEstiAdapterTest : AdapterTest<AdapterService.MtEstiAdapter, IMtEstiAdapter>
    {
        public MtEstiAdapterTest()
        {
            AggregateCatalog catalog = new AggregateCatalog();
            catalog.Catalogs.Add(new AssemblyCatalog(typeof(AdapterService.MtEstiAdapter).Assembly));
            catalog.Catalogs.Add(new AssemblyCatalog(typeof(MtEstiAdapterTest).Assembly));
            catalog.Catalogs.Add(new AssemblyCatalog(typeof(FileParameterStoreImplementation).Assembly));
            CompositionContainer result = new CompositionContainer(catalog, true);
            result.ComposeExportedValue(result);
            Composition.CompositionContainer = result;
        }

        //[TestMethod]
        public void SendInfoForAccomodationRegisterTest()
        {
            var adapter = new AdapterService.MtEstiAdapter();
            var accessMatrix = AccessMatrix.CreateForType(typeof(AccRegister.AccomodationRegisterRequestType));

            var additionalParameters = CreateAdditionalParameters("1.2.7.0.0.0.0.0.0.1");
            // var searchCriteria = CreateInsertRegister("ОО-ФФФ-ТТТ-ХХ", "cccc6666-66cc-6666-cccc-6666cccc6670");
            var searchCriteria = CreateUpdateRegister("ОО-ФФФ-ТТТ-ХХ", 6638);

            var result = adapter.SendInfoForAccomodationRegister(searchCriteria, accessMatrix, additionalParameters);
            string xml = result.XmlSerialize();
        }

        private AccRegister.AccomodationRegisterRequestType CreateInsertRegister(string uin, string registrationUid)
        {
            var change = AccRegister.ChangeType.Insert;
            var result = this.CreateAccomodationRegisterRequestType(uin, registrationUid, null, change);
            return result;
        }

        private AccRegister.AccomodationRegisterRequestType CreateUpdateRegister(string uin, long registrationId)
        {
            var change = AccRegister.ChangeType.Update;
            var result = this.CreateAccomodationRegisterRequestType(uin, null, registrationId, change);
            return result;
        }

        private AccRegister.AccomodationRegisterRequestType CreateCancelRegister(string uin, long registrationId)
        {
            var change = TechnoLogica.RegiX.MtEstiAdapter.AccRegister.ChangeType.Cancel;
            var result = this.CreateAccomodationRegisterRequestType(uin, null, registrationId, change);
            return result;
        }

        private AccRegister.AccomodationRegisterRequestType CreateAccomodationRegisterRequestType(
            string uin,
            string uid,
            long? registrationId,
            AccRegister.ChangeType change)
        {
            var accomodation = new AccRegister.AccomodationRegisterRequestType();
            accomodation.AccomodationPlaceUIN = uin;
            accomodation.Change = change;

            var person = new AccRegister.PersonType();
            person.FirstName = "Иван";
            person.MiddleName = "Петров";
            person.FamilyName = "Иванов";
            person.Sex = AccRegister.GenderType.M;
            person.BirthDate = new DateTime(1994, 10, 22);
            person.IdentityNumber = "9410229876";
            person.IdentityDocumentTypeCode = AccRegister.DocType.ICA;
            person.IdentityDocumentTypeCodeSpecified = true;
            person.IdentityDocumentNumber = "234512345";
            person.IdentityDocumentCountryCode = "BG";

            var registration = new AccRegister.RegistrationType();
            registration.RegistrationDate = DateTime.Now.AddDays(-5);
            registration.CheckInDate = DateTime.Now.AddDays(-3);
            registration.CheckOutDate = DateTime.Now.AddDays(-1);
            registration.Floor = "етаж 4";
            registration.Room = "ап. 42";
            registration.TouristPackage = true;
            registration.AveragePrice = 34;

            switch (change)
            {
                case AccRegister.ChangeType.Insert:
                    {
                        accomodation.InsertAccomodation = new AccRegister.InsertAccomodationType();
                        accomodation.InsertAccomodation.Person = person;
                        accomodation.InsertAccomodation.Registration = registration;
                        accomodation.InsertAccomodation.RegistrationUID = uid;
                    }
                    break;
                case AccRegister.ChangeType.Update:
                    {
                        person.FirstName = "Георги";
                        accomodation.UpdateAccomodation = new AccRegister.UpdateAccomodationType();
                        accomodation.UpdateAccomodation.RegistrationId = registrationId.Value;
                        accomodation.UpdateAccomodation.Person = person;
                        accomodation.UpdateAccomodation.Registration = registration;
                    }
                    break;
                case AccRegister.ChangeType.Cancel:
                    {
                        accomodation.AccomodationPlaceUIN = uin;
                        accomodation.CancelAccomodation.RegistrationId = registrationId.Value;
                    }
                    break;
                default:
                    break;
            }

            return accomodation;
        }

        // If you want to read the request from file
        //private AccomodationPlaceRequestType CreateAccomodationPlaceRequestType()
        //{
        //    string xml = File.ReadAllText(@"C:\Users\mdonchev\Desktop\testing.txt");

        //    var parameter = XmlDeserialize(xml, typeof(AccomodationPlaceRequestType));
        //    return parameter as AccomodationPlaceRequestType;
        //}

        private object XmlDeserialize(string serializedObject, Type type)
        {
            if (string.IsNullOrEmpty(serializedObject))
            {
                return null;
            }
            using (StringReader sr = new StringReader(serializedObject))
            {
                XmlSerializer serializer = new XmlSerializer(type);
                return serializer.Deserialize(sr);
            }
        }

        private AdapterAdditionalParameters CreateAdditionalParameters(string organizationEIK)
        {
            CallContext context = new CallContext()
            {
                AdministrationOId = "https://trust-party-openid.com",
                LawReason = "Тестване на RegiX",
                ServiceURI = "1222-200030-12.12.2022",
                Remark = "Забележки",
                EmployeeAditionalIdentifier = "Карта номер 3",
                EmployeeIdentifier = "test@tesactivedirectory.com",
                EmployeeNames = "Тестов Потребител Потребител",
                AdministrationName = "Българска агенция за Тестване",
                EmployeePosition = "Старши експерт Отдел \"Тестване на интеграцията\"",
                ResponsiblePersonIdentifier = "392309324",
                ServiceType = "За проверовъчна дейност"
            };

            AdapterAdditionalParameters additionalParameters = new AdapterAdditionalParameters();
            additionalParameters.CallContext = context;
            additionalParameters.CitizenEGN = "8888888888";
            additionalParameters.ClientIPAddress = "111.111.111.111";
            additionalParameters.ConsumerCertificateThumbprint = "###";
            additionalParameters.EIDToken = "token123";
            additionalParameters.EmployeeEGN = "11111111111111";
            additionalParameters.OrganizationEIK = organizationEIK;
            additionalParameters.OrganizationUnit = "qqqqqq";
            additionalParameters.SignResult = false;
            additionalParameters.ReturnAccessMatrix = false;

            return additionalParameters;
        }
    }
}
