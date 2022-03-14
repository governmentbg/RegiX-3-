//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.ServiceModel;
//using System.Configuration;
//using TechnoLogica.RegiX.Common.ObjectMapping;
//using TechnoLogica.RegiX.Common.AdapterCore;
//using TechnoLogica.RegiX.REZMAAdapter;
//using System.ComponentModel.Composition;
//using MySql.Data.MySqlClient;
//using System.Data;
//using TechnoLogica.RegiX.Common.ServiceContracts;
//using TechnoLogica.RegiX.Common.Utils;
//using TechnoLogica.RegiX.Common.TransportObject;
//using TechnoLogica.RegiX.Common.DataContracts;
//using System.IO;

//namespace TechnoLogica.RegiX.REZMAAdapter.AdapterService
//{
//    public class REZMAAdapter : MySqlAdapterService.MySqlBaseAdapterService, IREZMAAdapter, IAdapterService
//    {
//        [Export(typeof(ParameterInfo))]
//        [ExportFullName(typeof(REZMAAdapter), typeof(ParameterInfo))]
//        public ParameterInfo<string> ConnectionString =
//            new ParameterInfo<string>("Server=egov;Uid=rezma;Pwd=rezma;Database=rezma;port=3306;")
//            {
//                Key = TechnoLogica.RegiX.Common.Constants.ConnectionStringParameterKeyName,
//                Description = "Connection string for MySQL database",
//                OwnerAssembly = typeof(REZMAAdapter).Assembly
//            };

//        [Export(typeof(ParameterInfo))]
//        [ExportFullName(typeof(REZMAAdapter), typeof(ParameterInfo))]
//        public static ParameterInfo<string> SchemaName =
//            new ParameterInfo<string>("rezma")
//            {
//                Key = "SchemaName",
//                Description = "Name of the schema in database",
//                OwnerAssembly = typeof(REZMAAdapter).Assembly
//            };
//        private string GetFileNamePart(string fileFolder, string identifier)
//        {
//            string fileName = "\\XMLData\\" + fileFolder + "\\" + identifier + ".xml";
//            //var apPath = Directory.GetCurrentDirectory() + "\\XMLData\\" + fileFolder;
//            //var files = Directory.GetFiles(apPath, "*.xml");
//            //var filePath = files.Where(x => x.Contains(identifier)).FirstOrDefault();

//            //string fileName = string.Empty;

//            //if (!string.IsNullOrEmpty(filePath))
//            //{
//            //    var fileParts = filePath.Split(new char[] { '\\' }, StringSplitOptions.RemoveEmptyEntries)
//            //        .Reverse()
//            //        .Take(3)
//            //        .Reverse();

//            //    fileName = string.Join("\\", fileParts);
//            //}
//            return fileName;
//        }


//        public CommonSignedResponse<CustomsObligationsRequestType, CustomsObligationsResponseType> GetCustomsObligations(CustomsObligationsRequestType argument, AccessMatrix accessMatrix, AdapterAdditionalParameters aditionalParameters)
//        {
//            Guid id = Guid.NewGuid();
//            LogData(aditionalParameters, new { Request = argument.Serialize(), Guid = id });
//            try
//            {
//                CustomsObligationsResponseType result = new CustomsObligationsResponseType();
//                string fileName =  GetFileNamePart("customObligationsResponse", argument.Identifier);
//                try
//                {
//                    result = (CustomsObligationsResponseType)
//                        FileUtils.ReadXml(fileName,
//                            typeof(CustomsObligationsResponseType));
//                    if (!string.IsNullOrEmpty(result.UIN))
//                    {
//                        result.UIN = argument.Identifier;
//                    }
//                }
//                catch (Exception ex)
//                {
//                    result = (CustomsObligationsResponseType)
//                     FileUtils.ReadXml(@"\XMLData\customObligationsResponse\default.xml",
//                         typeof(CustomsObligationsResponseType));
//                    if (!string.IsNullOrEmpty(result.UIN))
//                    {
//                        result.UIN = argument.Identifier;
//                    }
//                }
//                return
//                    SigningUtils.CreateAndSign(
//                    argument,
//                    result,
//                    accessMatrix,
//                    aditionalParameters
//                    );
//            }
//            catch (Exception ex)
//            {
//                LogError(aditionalParameters, ex, new { Guid = id });
//                throw ex;
//            }
//        }

//        public CommonSignedResponse<ExciseObligationsRequestType, ExciseObligationsResponseType> GetExciseObligations(ExciseObligationsRequestType argument, AccessMatrix accessMatrix, AdapterAdditionalParameters aditionalParameters)
//        {
//            Guid id = Guid.NewGuid();
//            LogData(aditionalParameters, new { Request = argument.Serialize(), Guid = id });
//            try
//            {
//                ExciseObligationsResponseType result = new ExciseObligationsResponseType();
//                string fileName = GetFileNamePart("exciseObligationsResponse", argument.Identifier);
//                try
//                {
//                    result = (ExciseObligationsResponseType)
//                        FileUtils.ReadXml(fileName,
//                            typeof(ExciseObligationsResponseType));
//                    if (!string.IsNullOrEmpty(result.UIN))
//                    {
//                        result.UIN = argument.Identifier;
//                    }
//                }
//                catch (Exception ex)
//                {
//                    result = (ExciseObligationsResponseType)
//                    FileUtils.ReadXml(@"\XMLData\exciseObligationsResponse\default.xml",
//                        typeof(ExciseObligationsResponseType));
//                    if (!string.IsNullOrEmpty(result.UIN))
//                    {
//                        result.UIN = argument.Identifier;
//                    }
//                }

//                return
//                    SigningUtils.CreateAndSign(
//                    argument,
//                    result,
//                    accessMatrix,
//                    aditionalParameters
//                    );
//            }
//            catch (Exception ex)
//            {
//                LogError(aditionalParameters, ex, new { Guid = id });
//                throw ex;
//            }
//        }

//        public CommonSignedResponse<CheckObligationsRequestType, CheckObligationsResponseType> CheckObligations(CheckObligationsRequestType argument, AccessMatrix accessMatrix, AdapterAdditionalParameters aditionalParameters)
//        {
//            Guid id = Guid.NewGuid();
//            LogData(aditionalParameters, new { Request = argument.XmlSerialize(), Guid = id });
//            try
//            {
//                CheckObligationsResponseType result = new CheckObligationsResponseType();
                
//                string fileName = GetFileNamePart("checkObligations", argument.Identifier);
//                try
//                {
//                    result = (CheckObligationsResponseType)
//                        FileUtils.ReadXml(fileName,
//                            typeof(CheckObligationsResponseType));
//                }
//                catch (Exception ex)
//                {
//                    result = (CheckObligationsResponseType)
//                    FileUtils.ReadXml(@"\XMLData\checkObligations\default.xml",
//                        typeof(CheckObligationsResponseType));
                    
//                }
//                result.ReportDate = DateTime.Now;
//                result.ReportDateSpecified = true;
//                if (!string.IsNullOrEmpty(result.UIN))
//                {
//                    result.UIN = argument.Identifier;
//                }

//                return
//                       SigningUtils.CreateAndSign(
//                           argument,
//                           result,
//                           accessMatrix,
//                           aditionalParameters
//                       );
//            }
//            catch (Exception ex)
//            {
//                LogError(aditionalParameters, ex, new { Guid = id });
//                throw ex;
//            }
//        }

//    }
//}
