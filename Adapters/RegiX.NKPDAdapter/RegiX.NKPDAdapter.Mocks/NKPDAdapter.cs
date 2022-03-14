//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Data;
//using System.Data.SqlClient;
//using TechnoLogica.RegiX.Common.Utils;
//using System.Diagnostics;
//using System.Threading.Tasks;
//using TechnoLogica.RegiX.Common;
//using TechnoLogica.RegiX.Common.ObjectMapping;
//using TechnoLogica.RegiX.Common.AdapterCore;
//using System.ComponentModel.Composition;
//using TechnoLogica.RegiX.Common.ServiceContracts;
//using TechnoLogica.RegiX.Common.TransportObject;
//using TechnoLogica.RegiX.Common.DataContracts;

//namespace TechnoLogica.RegiX.NKPDAdapter.AdapterService
//{
//    public class NKPDAdapter : SQLServerAdapterService.SQLServerAdapterService, INKPDAdapter, IAdapterService
//    {

//        //public NKPDAdapter()
//        //{
//        //    ConnectionString =
//        //    new ParameterInfo<string>("Data Source=egov;Initial Catalog=NKPD;Password=;User ID=")
//        //    {
//        //        Key = "ConnectionString",
//        //        Description = "Connection string",
//        //        OwnerAssembly = typeof(NKPDAdapter).Assembly
//        //    };
//        //}

//        [Export(typeof(ParameterInfo))]
//        [ExportFullName(typeof(NKPDAdapter), typeof(ParameterInfo))]
//        public static ParameterInfo<string> ConnectionString =
//            new ParameterInfo<string>("Data Source=egov;Initial Catalog=NKPD;Password=;User ID=")
//            {
//                Key = Constants.ConnectionStringParameterKeyName,
//                Description = "Connection string",
//                OwnerAssembly = typeof(NKPDAdapter).Assembly
//            };


//        public CommonSignedResponse<AllNKPDDataSearchType, AllNKPDDataType> GetNKPDAllData(AllNKPDDataSearchType allNkpdSearch, AccessMatrix accessMatrix, AdapterAdditionalParameters additionalParameters)
//        {
//            Guid id = Guid.NewGuid();
//            LogData(additionalParameters, new { Request = allNkpdSearch.Serialize(), Guid = id });
//            try
//            {
//                AllNKPDDataType result = new AllNKPDDataType();
//                if (allNkpdSearch.ValidDate.CompareTo(DateTime.Now) == 1)
//                {
//                    result = (AllNKPDDataType)FileUtils.ReadXml("\\XMLData\\AllNKPDData.xml", typeof(AllNKPDDataType));
//                }
//                else
//                {
//                    result = (AllNKPDDataType)FileUtils.ReadXml("\\XMLData\\AllNKPDData.xml", typeof(AllNKPDDataType));
//                }
//                return
//                    SigningUtils.CreateAndSign(
//                        allNkpdSearch,
//                        result,
//                        accessMatrix,
//                        additionalParameters
//                    );
//            }
//            catch(Exception ex)
//            {
//                LogError(additionalParameters, ex, new { Guid = id });
//                throw ex;
//            }
//        }

        




//        public CommonSignedResponse<NKPDDataSearchType, NKPDDataType> GetNKPDData(NKPDDataSearchType nkpdDataSearch, AccessMatrix accessMatrix, AdapterAdditionalParameters additionalParameters)
//        {
//                Guid id = Guid.NewGuid();
//                LogData(additionalParameters, new {Request = nkpdDataSearch.Serialize(), Guid = id });
//                try
//                {
//                    NKPDDataType result = new NKPDDataType();
//                    if (nkpdDataSearch.Code == "1")
//                    {
//                        result = (NKPDDataType)FileUtils.ReadXml("\\XMLData\\NKPDData.xml", typeof(NKPDDataType));
//                    }
//                    else
//                    {
//                        result = (NKPDDataType)FileUtils.ReadXml("\\XMLData\\NKPDData.xml", typeof(NKPDDataType));
//                    }
//                    return
//                        SigningUtils.CreateAndSign(
//                            nkpdDataSearch,
//                            result,
//                            accessMatrix,
//                            additionalParameters
//                        );
                        
//                }
//                catch(Exception ex)
//                {
//                    LogError(additionalParameters, ex, new { Guid = id });
//                    throw ex;
//                }

//        }

        

//    }
//}
