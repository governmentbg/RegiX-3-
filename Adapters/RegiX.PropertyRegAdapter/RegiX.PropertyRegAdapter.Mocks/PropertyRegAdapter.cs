//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using TechnoLogica.RegiX.Common;
//using TechnoLogica.RegiX.Common.ObjectMapping;
//using TechnoLogica.RegiX.Common.AdapterCore;
//using TechnoLogica.RegiX.Common.Utils;
//using System.ComponentModel.Composition;
//using System.Data;
//using System.Globalization;
//using TechnoLogica.RegiX.Common.ServiceContracts;
//using TechnoLogica.RegiX.Common.DataContracts;
//using Oracle.ManagedDataAccess.Client;
//using TechnoLogica.RegiX.Common.TransportObject;
//using TechnoLogica.RegiX.OracleAdapterService;
//using System.IO;

//namespace TechnoLogica.RegiX.PropertyRegAdapter.AdapterService
//{
//    public class PropertyRegAdapter : OracleBaseAdapterService, IPropertyRegAdapter, IAdapterService
//    {
//        public override string CheckRegisterConnection()
//        {
//            return Constants.ConnectionOk;
//        }


//        public CommonSignedResponse<EntityInfoRequestType, EntityInfoResponseType> GetEntityInfo(EntityInfoRequestType argument, AccessMatrix accessMatrix, AdapterAdditionalParameters aditionalParameters)
//        {
//            Guid id = Guid.NewGuid();
//            LogData(aditionalParameters, new { Request = argument.Serialize(), Guid = id });
//            try
//            {
//                EntityInfoResponseType result = new EntityInfoResponseType();
//                string fileName = AppDomain.CurrentDomain.BaseDirectory + "\\XMLData\\GetEntityInfo\\" + argument.EIK + ".xml";

//                if (File.Exists(fileName))
//                {
//                    result = (EntityInfoResponseType)FileUtils.ReadXml("\\XMLData\\GetEntityInfo\\" + argument.EIK + ".xml", typeof(EntityInfoResponseType));
//                }
//                else
//                {
//                    result = (EntityInfoResponseType)FileUtils.ReadXml("\\XMLData\\GetEntityInfo\\default.xml", typeof(EntityInfoResponseType));
//                }
                
//                return
//                    SigningUtils.CreateAndSign(
//                        argument,
//                        result,
//                        accessMatrix,
//                        aditionalParameters
//                    );

//            }
//            catch (Exception ex)
//            {
//                LogError(aditionalParameters, ex, new { Guid = id });
//                throw ex;
//            }
//        }

//        public CommonSignedResponse<PersonInfoRequestType, PersonInfoResponseType> GetPersonInfo(PersonInfoRequestType argument, AccessMatrix accessMatrix, AdapterAdditionalParameters aditionalParameters)
//        {
//            Guid id = Guid.NewGuid();
//            LogData(aditionalParameters, new { Request = argument.Serialize(), Guid = id });
//            try
//            {

//                PersonInfoResponseType result = new PersonInfoResponseType();

//                string fileName = AppDomain.CurrentDomain.BaseDirectory + "\\XMLData\\GetPersonInfo\\" + argument.EGN + ".xml";

//                if (File.Exists(fileName))
//                {
//                    result = (PersonInfoResponseType)FileUtils.ReadXml("\\XMLData\\GetPersonInfo\\" + argument.EGN + ".xml", typeof(PersonInfoResponseType));
//                }
//                else
//                {
//                    result = (PersonInfoResponseType)FileUtils.ReadXml("\\XMLData\\GetPersonInfo\\default.xml", typeof(PersonInfoResponseType));
//                }

//                return
//                    SigningUtils.CreateAndSign(
//                        argument,
//                        result,
//                        accessMatrix,
//                        aditionalParameters
//                    );

//            }
//            catch (Exception ex)
//            {
//                LogError(aditionalParameters, ex, new { Guid = id });
//                throw ex;
//            }
//        }


//        public CommonSignedResponse<PropertyInfoRequestType, PropertyInfoResponseType> GetPropertyInfo(PropertyInfoRequestType argument, AccessMatrix accessMatrix, AdapterAdditionalParameters aditionalParameters)
//        {
//            Guid id = Guid.NewGuid();
//            LogData(aditionalParameters, new { Request = argument.Serialize(), Guid = id });
//            try
//            {

//                PropertyInfoResponseType result = new PropertyInfoResponseType();

//                string fileName = AppDomain.CurrentDomain.BaseDirectory + "\\XMLData\\GetPropertyInfo\\" + argument.PropertyID + ".xml";

//                if (File.Exists(fileName))
//                {
//                    result = (PropertyInfoResponseType)FileUtils.ReadXml("\\XMLData\\GetPropertyInfo\\" + argument.PropertyID + ".xml", typeof(PropertyInfoResponseType));
//                }
//                else
//                {
//                    result = (PropertyInfoResponseType)FileUtils.ReadXml("\\XMLData\\GetPropertyInfo\\default.xml", typeof(PropertyInfoResponseType));
//                }

//                return
//                    SigningUtils.CreateAndSign(
//                        argument,
//                        result,
//                        accessMatrix,
//                        aditionalParameters
//                    );

//            }
//            catch (Exception ex)
//            {
//                LogError(aditionalParameters, ex, new { Guid = id });
//                throw ex;
//            }
//        }


//        public CommonSignedResponse<PropertySearchRequestType, PropertySearchResponseType> PropertySearch(PropertySearchRequestType argument, AccessMatrix accessMatrix, AdapterAdditionalParameters aditionalParameters)
//        {
//            Guid id = Guid.NewGuid();
//            LogData(aditionalParameters, new { Request = argument.Serialize(), Guid = id });
//            try
//            {

//                PropertySearchResponseType result = new PropertySearchResponseType();
//                string fileName = AppDomain.CurrentDomain.BaseDirectory + "\\XMLData\\PropertySearch\\" + argument.PropertyLot + ".xml";

//                if (File.Exists(fileName))
//                {
//                    result = (PropertySearchResponseType)FileUtils.ReadXml("\\XMLData\\PropertySearch\\" + argument.PropertyLot + ".xml", typeof(PropertySearchResponseType));
//                }
//                else
//                {
//                    result = (PropertySearchResponseType)FileUtils.ReadXml("\\XMLData\\PropertySearch\\default.xml", typeof(PropertySearchResponseType));
//                }

//                return
//                    SigningUtils.CreateAndSign(
//                        argument,
//                        result,
//                        accessMatrix,
//                        aditionalParameters
//                    );

//            }
//            catch (Exception ex)
//            {
//                LogError(aditionalParameters, ex, new { Guid = id });
//                throw ex;
//            }

//        }


//        public CommonSignedResponse<GetSitesRequestType, GetSitesResponseType> GetSites(GetSitesRequestType argument, AccessMatrix accessMatrix, AdapterAdditionalParameters aditionalParameters)
//        {
//            Guid id = Guid.NewGuid();
//            LogData(aditionalParameters, new { Request = argument.Serialize(), Guid = id });
//            try
//            {

//                GetSitesResponseType result = new GetSitesResponseType();
              
//                result = (GetSitesResponseType)FileUtils.ReadXml("\\XMLData\\GetSites\\default.xml", typeof(GetSitesResponseType));

//                return
//                    SigningUtils.CreateAndSign(
//                        argument,
//                        result,
//                        accessMatrix,
//                        aditionalParameters
//                    );
//            }
//            catch (Exception ex)
//            {
//                LogError(aditionalParameters, ex, new { Guid = id });
//                throw ex;
//            }
//        }

//    }
//}
