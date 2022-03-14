using System;
using System.Collections.Generic;
using TechnoLogica.RegiX.Common;
using TechnoLogica.RegiX.Common.ObjectMapping;
using TechnoLogica.RegiX.Common.Utils;
using System.ComponentModel.Composition;
using TechnoLogica.RegiX.Common.DataContracts;
using TechnoLogica.RegiX.MtTouristRegisterAdapter.TOTAService;
using TechnoLogica.RegiX.Adapters.Common;
using TechnoLogica.RegiX.Adapters.Common.ExportExtension;
using TechnoLogica.RegiX.Adapters.Common.DataContracts;
using TechnoLogica.RegiX.Common.DataContracts.Parameter;
using TechnoLogica.RegiX.Adapters.Common.ObjectMapping;
using TechnoLogica.RegiX.Adapters.Common.Utils;

namespace TechnoLogica.RegiX.MtTouristRegisterAdapter.AdapterService
{
    [Export(typeof(IAdapterService))]
    [ExportFullName(typeof(MtTouristRegisterAdapter), typeof(IAdapterService))]
    [ExportSimpleName(typeof(MtTouristRegisterAdapter), typeof(IAdapterService))]
    public class MtTouristRegisterAdapter : BaseAdapterService, IMtTouristRegisterAdapter, IAdapterService
    {
        [Export(typeof(ParameterInfo))]
        [ExportFullName(typeof(MtTouristRegisterAdapter), typeof(ParameterInfo))] // Справка по ЕИК/БУЛСТАТ за регистрация на туроператор/туристически агент
        public static ParameterInfo<string> RegistrationServiceUrl =
            new ParameterInfo<string>("http://217.75.131.131:31381/Registration.nsf/query?OpenWebService")
            {
                Key = "RegistrationServiceUrl",
                Description = "MtTouristRegisterService Web Service Url",
                OwnerAssembly = typeof(MtTouristRegisterAdapter).Assembly
            };
        [Export(typeof(ParameterInfo))]
        [ExportFullName(typeof(MtTouristRegisterAdapter), typeof(ParameterInfo))] // Справка по ЕИК/БУЛСТАТ за категоризация на обекти
        public static ParameterInfo<string> CategorizationObjectServiceUrl =
            new ParameterInfo<string>("http://217.75.131.131:31381/CategoryzationMun.nsf/query2")
            {
                Key = "CategorizationObjectServiceUrl",
                Description = "MtTouristRegisterService Web Service Url",
                OwnerAssembly = typeof(MtTouristRegisterAdapter).Assembly
            };
        [Export(typeof(ParameterInfo))]
        [ExportFullName(typeof(MtTouristRegisterAdapter), typeof(ParameterInfo))] // Справка по ЕИК/БУЛСТАТ за категоризация на заведения за хранене и развлечение
        public static ParameterInfo<string> CategorizationBarServiceUrl =
            new ParameterInfo<string>("http://217.75.131.131:31381/CategoryzationMun.nsf/query3")
            {
                Key = "CategorizationBarServiceUrl",
                Description = "MtTouristRegisterService Web Service Url",
                OwnerAssembly = typeof(MtTouristRegisterAdapter).Assembly
            };
        [Export(typeof(ParameterInfo))]
        [ExportFullName(typeof(MtTouristRegisterAdapter), typeof(ParameterInfo))] // Справка по ЕИК/БУЛСТАТ за сключена застраховка за туроператор
        public static ParameterInfo<string> InsuranceServiceUrl =
            new ParameterInfo<string>("http://217.75.131.131:31381/Registration.nsf/query4")
            {
                Key = "InsuranceServiceUrl",
                Description = "MtTouristRegisterService Web Service Url",
                OwnerAssembly = typeof(MtTouristRegisterAdapter).Assembly
            };

        public override string CheckRegisterConnection()
        {
            System.Net.ServicePointManager.SecurityProtocol = System.Net.SecurityProtocolType.Tls12;
            Dictionary<string, string> results = new Dictionary<string, string>();
            string resultRegistrationService = CheckConnectionsUtils.CheckSoapConnection(RegistrationServiceUrl.Value);
            string resultCategorizationObjectService = CheckConnectionsUtils.CheckSoapConnection(CategorizationObjectServiceUrl.Value);
            string resultCategorizationBarService = CheckConnectionsUtils.CheckSoapConnection(CategorizationBarServiceUrl.Value);
            string resultInsuranceService = CheckConnectionsUtils.CheckSoapConnection(InsuranceServiceUrl.Value);

            results.Add("RegistrationServiceUrl", resultRegistrationService);
            results.Add("CategorizationObjectServiceUrl", resultCategorizationObjectService);
            results.Add("CategorizationBarServiceUrl", resultCategorizationBarService);
            results.Add("InsuranceServiceUrl", resultInsuranceService);

            string description = string.Empty;
            int statusOk = 0;
            int statusNotSet = 0;
            int ststusError = 0;
            foreach (var res in results)
            {
                description += String.Format("{0}: {1}\r\n", res.Key, res.Value);
                if (res.Value == Constants.ConnectionOk)
                {
                    statusOk++;
                }
                else
                {
                    if (res.Value == Constants.WebServiceUrlNotSet)
                    {
                        statusNotSet++;
                    }
                    else
                {
                        ststusError++;
                    }
                }
            }
            if (ststusError > 0)
            {
                return description;
            }
            else
            {
                if (statusNotSet > 0)
            {
                    return Constants.WebServiceUrlNotSet;
            }
            else
            {
                    return Constants.ConnectionOk;
                }
            }
        }

        public CommonSignedResponse<BarRestaurantCategoryByEIKRequestType, TouristEntertainmentObjectArray> GetTotaRegBarRestaurantCategoryByEIK(BarRestaurantCategoryByEIKRequestType argument, AccessMatrix accessMatrix, AdapterAdditionalParameters aditionalParameters)
        {
            Guid id = Guid.NewGuid();
            LogData(aditionalParameters, new { Request = argument.XmlSerialize(), Guid = id });
            try
            {
                System.Net.ServicePointManager.SecurityProtocol = System.Net.SecurityProtocolType.Tls12;
                TechnoLogica.RegiX.MtTouristRegisterAdapter.CategorizationResortService.CategorizationDBClient serviceClient = new TechnoLogica.RegiX.MtTouristRegisterAdapter.CategorizationResortService.CategorizationDBClient("Domino2", CategorizationBarServiceUrl.Value);
                TechnoLogica.RegiX.MtTouristRegisterAdapter.CategorizationResortService.BARRESTAURANTCATEGORYBYEIKREQUESTTYPE req = new TechnoLogica.RegiX.MtTouristRegisterAdapter.CategorizationResortService.BARRESTAURANTCATEGORYBYEIKREQUESTTYPE();
                req.EIK = argument.EIK;
                TechnoLogica.RegiX.MtTouristRegisterAdapter.CategorizationResortService.TOURISTENTERTAINMENTOBJECT[] serviceResult = serviceClient.BARRESTAURANTCATEGORYBYEIK(req);

                ObjectMapper<TechnoLogica.RegiX.MtTouristRegisterAdapter.CategorizationResortService.TOURISTENTERTAINMENTOBJECT[], TouristEntertainmentObjectArray> mapper = CreateBarRestaurantCategoryMapper(accessMatrix);
                TouristEntertainmentObjectArray searchResults = new TouristEntertainmentObjectArray();
                mapper.Map(serviceResult, searchResults);
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

        private static ObjectMapper<TechnoLogica.RegiX.MtTouristRegisterAdapter.CategorizationResortService.TOURISTENTERTAINMENTOBJECT[], TouristEntertainmentObjectArray> CreateBarRestaurantCategoryMapper(AccessMatrix accessMatrix)
        {
            ObjectMapper<TechnoLogica.RegiX.MtTouristRegisterAdapter.CategorizationResortService.TOURISTENTERTAINMENTOBJECT[], TouristEntertainmentObjectArray> mapper = new ObjectMapper<TechnoLogica.RegiX.MtTouristRegisterAdapter.CategorizationResortService.TOURISTENTERTAINMENTOBJECT[], TouristEntertainmentObjectArray>(accessMatrix);

            mapper.AddCollectionMap<TechnoLogica.RegiX.MtTouristRegisterAdapter.CategorizationResortService.TOURISTENTERTAINMENTOBJECT[]>((o) => o.Objects, c => c);
            mapper.AddPropertyMap((o) => o.Objects[0].SiteName, (c) => c[0].NAME);
            mapper.AddObjectMap((o) => o.Objects[0].Adress, (c) => c[0].ADDRESS);
            mapper.AddObjectMap((o) => o.Objects[0].SiteType, (c) => c[0].TYPE);
            mapper.AddPropertyMap((o) => o.Objects[0].SiteSubType, (c) => c[0].SUBTYPE);
            mapper.AddPropertyMap((o) => o.Objects[0].Category, (c) => c[0].CATEGORY);
            mapper.AddObjectMap((o) => o.Objects[0].Capacity, (c) => c[0].CAPACITY);
            mapper.AddPropertyMap((o) => o.Objects[0].WorkTime, (c) => c[0].WORKTIME);
            mapper.AddObjectMap((o) => o.Objects[0].Subobjects, (c) => c[0].SUBOBJECTS);
            mapper.AddObjectMap((o) => o.Objects[0].Certificate, (c) => c[0].CERTIFICATE);
            mapper.AddPropertyMap((o) => o.Objects[0].EIK, (c) => c[0].EIK);

            mapper.AddPropertyMap((o) => o.Objects[0].Adress.Adress, (c) => c[0].ADDRESS.ADDRESS);
            mapper.AddPropertyMap((o) => o.Objects[0].Adress.DistName, (c) => c[0].ADDRESS.CITY);
            mapper.AddPropertyMap((o) => o.Objects[0].Adress.Fax, (c) => c[0].ADDRESS.FAX);
            mapper.AddPropertyMap((o) => o.Objects[0].Adress.PopName, (c) => c[0].ADDRESS.MUNICIPALITY);
            mapper.AddPropertyMap((o) => o.Objects[0].Adress.Phone, (c) => c[0].ADDRESS.PHONE);
            mapper.AddPropertyMap((o) => o.Objects[0].Adress.TerName, (c) => c[0].ADDRESS.REGION);

            mapper.AddPropertyMap((o) => o.Objects[0].Capacity.Capacity, (c) => c[0].CAPACITY.TOTAL);
            mapper.AddPropertyMap((o) => o.Objects[0].Capacity.OutdoorsCapacity, (c) => c[0].CAPACITY.OUTDOORS);
            mapper.AddPropertyMap((o) => o.Objects[0].Capacity.IndoorsCapacity, (c) => c[0].CAPACITY.INDOORS);

            mapper.AddPropertyMap((o) => o.Objects[0].Subobjects[0].Description, (c) => c[0].SUBOBJECTS[0].DESCRIPTION);

            mapper.AddPropertyMap((o) => o.Objects[0].SiteType, (c) => c[0].TYPE);

            //mapper.AddFunctionMap<CategorizationResortService.ENTOBJECTTYPEENUM, EntertainmentObjectTypeEnum>((o) => (EntertainmentObjectTypeEnum)o.Objects[0].Subobjects[0].Type, (c) => (EntertainmentObjectTypeEnum)Enum.Parse(typeof(EntertainmentObjectTypeEnum), c.ToString()));
            //mapper.AddFunctionMap<CategorizationResortService.TOURISTENTERTAINMENTOBJECT[], Nullable<EntertainmentObjectTypeEnum>>
            //    ((o) => o.Objects[0].SiteType,
            //    (c) => ParseSiteTypeEnum(c[0].TYPE));
            //mapper.AddFunctionMap<CategorizationResortService.ENTOBJECTTYPEENUM, EntertainmentObjectTypeEnum>((o) => (EntertainmentObjectTypeEnum)o.Objects[0].SiteType, (c) => (EntertainmentObjectTypeEnum)Enum.Parse(typeof(EntertainmentObjectTypeEnum), c.ToString()));

            mapper.AddPropertyMap((o) => o.Objects[0].Certificate.CategoryCertDate, (c) => c[0].CERTIFICATE.DATE);
            mapper.AddPropertyMap((o) => o.Objects[0].Certificate.CategoryCertNum, (c) => c[0].CERTIFICATE.NUMBER);
            mapper.AddPropertyMap((o) => o.Objects[0].Certificate.ValidityTerm, (c) => c[0].CERTIFICATE.VALIDITY);

            return mapper;
        }

        
        public CommonSignedResponse<ObjectCategoryByEIKRequestType, TouristObjectArray> GetTotaRegCategoryByEIK(ObjectCategoryByEIKRequestType argument, AccessMatrix accessMatrix, AdapterAdditionalParameters aditionalParameters)
        {
            Guid id = Guid.NewGuid();
            LogData(aditionalParameters, new { Request = argument.XmlSerialize(), Guid = id });
            try
            {
                System.Net.ServicePointManager.SecurityProtocol = System.Net.SecurityProtocolType.Tls12;
                TechnoLogica.RegiX.MtTouristRegisterAdapter.CategorizationService.CategorizationDBClient serviceClient = new TechnoLogica.RegiX.MtTouristRegisterAdapter.CategorizationService.CategorizationDBClient("Domino1", CategorizationObjectServiceUrl.Value);
                TechnoLogica.RegiX.MtTouristRegisterAdapter.CategorizationService.OBJECTCATEGORYBYEIKREQUESTTYPE req = new TechnoLogica.RegiX.MtTouristRegisterAdapter.CategorizationService.OBJECTCATEGORYBYEIKREQUESTTYPE();
                req.EIK = argument.EIK;
                TechnoLogica.RegiX.MtTouristRegisterAdapter.CategorizationService.TOURISTOBJECT[] serviceResult = serviceClient.OBJECTCATEGORYBYEIK(req);

                ObjectMapper<TechnoLogica.RegiX.MtTouristRegisterAdapter.CategorizationService.TOURISTOBJECT[], TouristObjectArray> mapper = CreateTotaRegCategoryMapper(accessMatrix);
                TouristObjectArray searchResults = new TouristObjectArray();
                mapper.Map(serviceResult, searchResults);
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

        private static ObjectMapper<TechnoLogica.RegiX.MtTouristRegisterAdapter.CategorizationService.TOURISTOBJECT[], TouristObjectArray> CreateTotaRegCategoryMapper(AccessMatrix accessMatrix)
        {
            ObjectMapper<TechnoLogica.RegiX.MtTouristRegisterAdapter.CategorizationService.TOURISTOBJECT[], TouristObjectArray> mapper = new ObjectMapper<TechnoLogica.RegiX.MtTouristRegisterAdapter.CategorizationService.TOURISTOBJECT[], TouristObjectArray>(accessMatrix);

            mapper.AddCollectionMap<TechnoLogica.RegiX.MtTouristRegisterAdapter.CategorizationService.TOURISTOBJECT[]>((o) => o.Objects, c => c);
            mapper.AddPropertyMap((o) => o.Objects[0].SiteName, (c) => c[0].NAME);
            mapper.AddObjectMap((o) => o.Objects[0].Adress, (c) => c[0].ADDRESS);
            mapper.AddObjectMap((o) => o.Objects[0].SiteKind, (c) => c[0].KIND);
            mapper.AddObjectMap((o) => o.Objects[0].SiteType, (c) => c[0].TYPE);
            mapper.AddPropertyMap((o) => o.Objects[0].SiteSubType, (c) => c[0].SUBTYPE);
            mapper.AddPropertyMap((o) => o.Objects[0].Category, (c) => c[0].CATEGORY);
            mapper.AddObjectMap((o) => o.Objects[0].Capacity, (c) => c[0].CAPACITY);
            mapper.AddPropertyMap((o) => o.Objects[0].RoomsNumber, (c) => c[0].ROOMCOUNT);
            mapper.AddPropertyMap((o) => o.Objects[0].BedsNumber, (c) => c[0].BEDCOUNT);
            mapper.AddPropertyMap((o) => o.Objects[0].WorkTime, (c) => c[0].WORKTIME);
            mapper.AddObjectMap((o) => o.Objects[0].Subobjects, (c) => c[0].SUBOBJECTS);
            mapper.AddObjectMap((o) => o.Objects[0].Certificate, (c) => c[0].CERTIFICATE);
            mapper.AddPropertyMap((o) => o.Objects[0].EIK, (c) => c[0].EIK);

            mapper.AddPropertyMap((o) => o.Objects[0].Adress.Adress, (c) => c[0].ADDRESS.ADDRESS);
            mapper.AddPropertyMap((o) => o.Objects[0].Adress.DistName, (c) => c[0].ADDRESS.CITY);
            mapper.AddPropertyMap((o) => o.Objects[0].Adress.Fax, (c) => c[0].ADDRESS.FAX);
            mapper.AddPropertyMap((o) => o.Objects[0].Adress.Phone, (c) => c[0].ADDRESS.PHONE);
            mapper.AddPropertyMap((o) => o.Objects[0].Adress.PopName, (c) => c[0].ADDRESS.MUNICIPALITY);
            mapper.AddPropertyMap((o) => o.Objects[0].Adress.TerName, (c) => c[0].ADDRESS.REGION);

            mapper.AddFunctionMap<CategorizationService.TOURISTOBJECT[], Nullable<TouristObjectKindEnum>>
                ((o) => o.Objects[0].SiteKind,
                (c) => ParseTouristObjectKindEnum(c[0].KIND));
            
            //Todo remove
            //mapper.AddFunctionMap<CategorizationService.TOURISTOBJECT, TouristObjectTypeEnum>((o) => (TouristObjectTypeEnum)o.Objects[0].SiteType, (c) => (TouristObjectTypeEnum)Enum.Parse(typeof(TouristObjectTypeEnum), c.ToString()));
            
            mapper.AddPropertyMap((o) => o.Objects[0].SiteType, (c) => c[0].TYPE);

            mapper.AddPropertyMap((o) => o.Objects[0].Capacity.Capacity, (c) => c[0].CAPACITY.TOTAL);
            mapper.AddPropertyMap((o) => o.Objects[0].Capacity.IndoorsCapacity, (c) => c[0].CAPACITY.INDOORS);
            mapper.AddPropertyMap((o) => o.Objects[0].Capacity.OutdoorsCapacity, (c) => c[0].CAPACITY.OUTDOORS);

            mapper.AddPropertyMap((o) => o.Objects[0].Subobjects[0].Description, (c) => c[0].SUBOBJECTS[0].DESCRIPTION);

            //mapper.AddFunctionMap<CategorizationService.TOURISTOBJECT[], Nullable<EntertainmentObjectTypeEnum>>
            //    ((o) => o.Objects[0].SiteKind,
            //    (c) => ParseEnum(c[0].KIND));
            mapper.AddFunctionMap<CategorizationService.ENTOBJECTTYPEENUM, EntertainmentObjectTypeEnum>((o) => (EntertainmentObjectTypeEnum)o.Objects[0].Subobjects[0].Type, (c) => (EntertainmentObjectTypeEnum)Enum.Parse(typeof(EntertainmentObjectTypeEnum), c.ToString()));

            mapper.AddPropertyMap((o) => o.Objects[0].Certificate.CategoryCertDate, (c) => c[0].CERTIFICATE.DATE);
            mapper.AddPropertyMap((o) => o.Objects[0].Certificate.CategoryCertNum, (c) => c[0].CERTIFICATE.NUMBER);
            mapper.AddPropertyMap((o) => o.Objects[0].Certificate.ValidityTerm, (c) => c[0].CERTIFICATE.VALIDITY);

            return mapper;
        }

        private static Nullable<TouristObjectKindEnum> ParseTouristObjectKindEnum(Nullable<CategorizationService.TOURISTOBJECTKINDENUM> source)
        {
            Nullable<TouristObjectKindEnum> target;

            try
            {
                target = (TouristObjectKindEnum)Enum.Parse(typeof(TouristObjectKindEnum), source.ToString());
            }
            catch (Exception)
            {
                target = null;
            }

            return target;
        }

        public CommonSignedResponse<TOInsuranceByEIKRequestType, InsuranceArray> GetTotaRegToInsuranceByEIK(TOInsuranceByEIKRequestType argument, AccessMatrix accessMatrix, AdapterAdditionalParameters aditionalParameters)
        {
            Guid id = Guid.NewGuid();
            LogData(aditionalParameters, new { Request = argument.XmlSerialize(), Guid = id });
            try
            {
                System.Net.ServicePointManager.SecurityProtocol = System.Net.SecurityProtocolType.Tls12;
                TechnoLogica.RegiX.MtTouristRegisterAdapter.TOTAInsuranceService.TOTADBClient serviceClient = new TechnoLogica.RegiX.MtTouristRegisterAdapter.TOTAInsuranceService.TOTADBClient("Domino3", InsuranceServiceUrl.Value);
                TechnoLogica.RegiX.MtTouristRegisterAdapter.TOTAInsuranceService.TOINSURANCEBYEIKREQUESTTYPE req = new TechnoLogica.RegiX.MtTouristRegisterAdapter.TOTAInsuranceService.TOINSURANCEBYEIKREQUESTTYPE();
                req.EIK = argument.EIK;
                TechnoLogica.RegiX.MtTouristRegisterAdapter.TOTAInsuranceService.INSURANCETYPE[] serviceResult = serviceClient.TOINSURANCEBYEIK(req);

                ObjectMapper<TechnoLogica.RegiX.MtTouristRegisterAdapter.TOTAInsuranceService.INSURANCETYPE[], InsuranceArray> mapper = CreateTotaRegInsuranceMapper(accessMatrix);
                InsuranceArray searchResults = new InsuranceArray();
                mapper.Map(serviceResult, searchResults);
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

        private static ObjectMapper<TechnoLogica.RegiX.MtTouristRegisterAdapter.TOTAInsuranceService.INSURANCETYPE[], InsuranceArray> CreateTotaRegInsuranceMapper(AccessMatrix accessMatrix)
        {
            ObjectMapper<TechnoLogica.RegiX.MtTouristRegisterAdapter.TOTAInsuranceService.INSURANCETYPE[], InsuranceArray> mapper = new ObjectMapper<TechnoLogica.RegiX.MtTouristRegisterAdapter.TOTAInsuranceService.INSURANCETYPE[], InsuranceArray>(accessMatrix);

            mapper.AddCollectionMap<TechnoLogica.RegiX.MtTouristRegisterAdapter.TOTAInsuranceService.INSURANCETYPE[]>((o) => o.Insurance, c => c);
            mapper.AddPropertyMap((o) => o.Insurance[0].EIK, (c) => c[0].EIK);
            mapper.AddPropertyMap((o) => o.Insurance[0].InsuranceCompanyName, (c) => c[0].COMPANY);
            mapper.AddPropertyMap((o) => o.Insurance[0].InsuranceEndDate, (c) => c[0].VALIDITY);
            mapper.AddPropertyMap((o) => o.Insurance[0].InsuranceIssuedDate, (c) => c[0].DATE);
            mapper.AddPropertyMap((o) => o.Insurance[0].InsurancePolicyNum, (c) => c[0].POLICYNUMBER);
            mapper.AddPropertyMap((o) => o.Insurance[0].RegNum, (c) => c[0].REGISTRATIONNUMBER);

            return mapper;
        }

        public CommonSignedResponse<TOTAByEIKRequestType, Tota> GetTotaRegTotaByEIK(TOTAByEIKRequestType argument, AccessMatrix accessMatrix, AdapterAdditionalParameters aditionalParameters)
        {
            Guid id = Guid.NewGuid();
            LogData(aditionalParameters, new { Request = argument.XmlSerialize(), Guid = id });
            try
            {
                System.Net.ServicePointManager.SecurityProtocol = System.Net.SecurityProtocolType.Tls12;
                TechnoLogica.RegiX.MtTouristRegisterAdapter.TOTAService.TOTADBClient serviceClient = new TechnoLogica.RegiX.MtTouristRegisterAdapter.TOTAService.TOTADBClient("Domino", RegistrationServiceUrl.Value);
                TechnoLogica.RegiX.MtTouristRegisterAdapter.TOTAService.TOTABYEIKREQUESTTYPE req = new TechnoLogica.RegiX.MtTouristRegisterAdapter.TOTAService.TOTABYEIKREQUESTTYPE();
                req.EIK = argument.EIK;
                TechnoLogica.RegiX.MtTouristRegisterAdapter.TOTAService.TOTA serviceResult = serviceClient.TOTABYEIK(req);

                ObjectMapper<TechnoLogica.RegiX.MtTouristRegisterAdapter.TOTAService.TOTA, Tota> mapper = CreateTotaMapper(accessMatrix);
                Tota searchResults = new Tota();
                mapper.Map(serviceResult, searchResults);
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

        private static ObjectMapper<TechnoLogica.RegiX.MtTouristRegisterAdapter.TOTAService.TOTA, Tota> CreateTotaMapper(AccessMatrix accessMatrix)
        {
            ObjectMapper<TechnoLogica.RegiX.MtTouristRegisterAdapter.TOTAService.TOTA, Tota> mapper = new ObjectMapper<TechnoLogica.RegiX.MtTouristRegisterAdapter.TOTAService.TOTA, Tota>(accessMatrix);

            mapper.AddPropertyMap((o) => o.EIK, (c) => c.EIK);
            mapper.AddPropertyMap((o) => o.CompanyName, (c) => c.NAME);
            mapper.AddObjectMap((o) => o.TourOperationType, (c) => c.TYPE);
            mapper.AddObjectMap((o) => o.Registration, (c) => c.REGISTRATION);
            mapper.AddObjectMap((o) => o.LicenseCancellationOrder, (c) => c.SUSPENDORDER);
            mapper.AddObjectMap((o) => o.License, (c) => c.LICENSE);


            mapper.AddFunctionMap<TOTA, TypeEnum?>
                ((o) => o.TourOperationType,
                (c) => ParseTypeEnum(c.TYPE));

            mapper.AddFunctionMap<TOTAService.TYPEENUM?, TypeEnum?>((o) => (TypeEnum)o.TourOperationType, (c) => (TypeEnum)Enum.Parse(typeof(TypeEnum), c.ToString()));
            //mapper.AddFunctionMap<TOTAService.TYPEENUM?, TypeEnum?>((o) => (TypeEnum)o.TourOperationType, ((c) => Convert.ToBoolean(c) ? (TypeEnum)Enum.Parse(typeof(TypeEnum), c.ToString()) : (TypeEnum?)null));

            mapper.AddPropertyMap((o) => o.Registration.DateIssued, (c) => c.REGISTRATION.DATE);
            mapper.AddObjectMap((o) => o.Registration.Order, (c) => c.REGISTRATION.ORDER);
            mapper.AddPropertyMap((o) => o.Registration.RegNum, (c) => c.REGISTRATION.NUMBER);

            mapper.AddPropertyMap((o) => o.Registration.Order.Date, (c) => c.REGISTRATION.ORDER.DATE);
            mapper.AddPropertyMap((o) => o.Registration.Order.Number, (c) => c.REGISTRATION.ORDER.NUMBER);
            mapper.AddPropertyMap((o) => o.LicenseCancellationOrder.Date, (c) => c.SUSPENDORDER.DATE);
            mapper.AddPropertyMap((o) => o.LicenseCancellationOrder.Number, (c) => c.SUSPENDORDER.NUMBER);

            mapper.AddPropertyMap((o) => o.License.LicenseIssuedOrderDate, (c) => c.LICENSE.DATE);
            mapper.AddPropertyMap((o) => o.License.LicenseIssuedOrderNum, (c) => c.LICENSE.NUMBER);
            mapper.AddObjectMap((o) => o.License.Order, (c) => c.LICENSE.ORDER);

            mapper.AddPropertyMap((o) => o.License.Order.Date, (c) => c.LICENSE.ORDER.DATE);
            mapper.AddPropertyMap((o) => o.License.Order.Number, (c) => c.LICENSE.ORDER.NUMBER);

            mapper.AddCollectionMap<TechnoLogica.RegiX.MtTouristRegisterAdapter.TOTAService.TOTA>((o) => o.Offices, c => c.OFFICES);
            mapper.AddPropertyMap((o) => o.Offices[0].OfficeAddress, (c) => c.OFFICES[0].ADDRESS);
            mapper.AddPropertyMap((o) => o.Offices[0].OfficePhone, (c) => c.OFFICES[0].PHONE);
            mapper.AddPropertyMap((o) => o.Offices[0].OfficePopName, (c) => c.OFFICES[0].CITY);

            mapper.AddCollectionMap<TechnoLogica.RegiX.MtTouristRegisterAdapter.TOTAService.TOTA>((o) => o.OrderChanges, c => c.TERMSCHANGEORDERS);
            mapper.AddPropertyMap((o) => o.OrderChanges[0].Date, (c) => c.TERMSCHANGEORDERS[0].DATE);
            mapper.AddPropertyMap((o) => o.OrderChanges[0].Number, (c) => c.TERMSCHANGEORDERS[0].NUMBER);
            return mapper;
        }

        private static Nullable<TypeEnum> ParseTypeEnum(Nullable<TYPEENUM> source)
        {
            Nullable<TypeEnum> target;

            try
            {
                target = (TypeEnum)Enum.Parse(typeof(TypeEnum), source.ToString());
            }
            catch (Exception)
            {
                target = null;
            }

            return target;
        }
    }
}
