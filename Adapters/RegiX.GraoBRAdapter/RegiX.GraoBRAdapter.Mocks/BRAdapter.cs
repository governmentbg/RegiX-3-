namespace TechnoLogica.RegiX.GraoBRAdapter.AdapterService
{
    //public class BRAdapter : InformixAdapterService.InformixBaseAdapterService, IBRAdapter, IAdapterService
    //{

    //    public override string CheckRegisterConnection()
    //    {
    //        return Constants.ConnectionOk;
    //    }


    //    public CommonSignedResponse<MaritalStatusRequestType, MaritalStatusResponseType> MaritalStatusSearch(MaritalStatusRequestType argument, AccessMatrix accessMatrix, AdapterAdditionalParameters aditionalParameters)
    //    {
    //        Guid id = Guid.NewGuid();
    //        LogData(aditionalParameters, new { Request = argument.Serialize(), Guid = id });
    //        try
    //        {
    //            MaritalStatusResponseType result = new MaritalStatusResponseType();
    //            switch (argument.EGN.Substring(0, 1))
    //            {
    //                case "0":
    //                case "1": result = (MaritalStatusResponseType)FileUtils.ReadXml("\\XMLData\\MaritalStatusResponse.xml", typeof(MaritalStatusResponseType)); break;
    //                case "2":
    //                case "3": result = (MaritalStatusResponseType)FileUtils.ReadXml("\\XMLData\\MaritalStatusResponse2.xml", typeof(MaritalStatusResponseType)); break;
    //                case "4":
    //                case "5": result = (MaritalStatusResponseType)FileUtils.ReadXml("\\XMLData\\MaritalStatusResponse3.xml", typeof(MaritalStatusResponseType)); break;
    //                case "6":
    //                case "7": result = (MaritalStatusResponseType)FileUtils.ReadXml("\\XMLData\\MaritalStatusResponse4.xml", typeof(MaritalStatusResponseType)); break;
    //                default: result = (MaritalStatusResponseType)FileUtils.ReadXml("\\XMLData\\MaritalStatusResponse9.xml", typeof(MaritalStatusResponseType)); break;
    //            };
    //            result.ReportDate = DateTime.Now;
    //            result.ReportDateSpecified = true;

    //            return
    //                SigningUtils.CreateAndSign(
    //                argument,
    //                result,
    //                accessMatrix,
    //                aditionalParameters
    //                );
    //        }
    //        catch (Exception ex)
    //        {
    //            LogError(aditionalParameters, ex, new { Guid = id });
    //            throw ex;
    //        }

    //    }

    //    public CommonSignedResponse<SpouseRequestType, SpouseResponseType> SpouseSearch(SpouseRequestType argument, AccessMatrix accessMatrix, AdapterAdditionalParameters aditionalParameters)
    //    {
    //        Guid id = Guid.NewGuid();
    //        LogData(aditionalParameters, new { Request = argument.Serialize(), Guid = id });
    //        try
    //        {
    //            SpouseResponseType result = new SpouseResponseType();
    //            switch (argument.EGN.Substring((argument.EGN.Length - 2), 1))
    //            {
    //                case "0": result = (SpouseResponseType)FileUtils.ReadXml("\\XMLData\\SpouseResponse.xml", typeof(SpouseResponseType)); break;
    //                case "2":
    //                case "4": result = (SpouseResponseType)FileUtils.ReadXml("\\XMLData\\SpouseResponse2.xml", typeof(SpouseResponseType)); break;
    //                case "6":
    //                case "8": result = (SpouseResponseType)FileUtils.ReadXml("\\XMLData\\SpouseResponse3.xml", typeof(SpouseResponseType)); break;
    //                case "1":
    //                case "3": result = (SpouseResponseType)FileUtils.ReadXml("\\XMLData\\SpouseResponse4.xml", typeof(SpouseResponseType)); break;
    //                default: result = (SpouseResponseType)FileUtils.ReadXml("\\XMLData\\SpouseResponse9.xml", typeof(SpouseResponseType)); break;
    //            };

    //            return
    //                SigningUtils.CreateAndSign(
    //                argument,
    //                result,
    //                accessMatrix,
    //                aditionalParameters
    //                );
    //        }
    //        catch (Exception ex)
    //        {
    //            LogError(aditionalParameters, ex, new { Guid = id });
    //            throw ex;
    //        }
    //    }

    //    public CommonSignedResponse<MarriageRequestType, MarriageResponseType> MarriageSearch(MarriageRequestType argument, AccessMatrix accessMatrix, AdapterAdditionalParameters aditionalParameters)
    //    {
    //        Guid id = Guid.NewGuid();
    //        LogData(aditionalParameters, new { Request = argument.Serialize(), Guid = id });
    //        try
    //        {
    //            MarriageResponseType result = new MarriageResponseType();
    //            switch (argument.EGN.Substring((argument.EGN.Length - 2), 1))
    //            {
    //                case "0": result = (MarriageResponseType)FileUtils.ReadXml("\\XMLData\\MarriageResponse.xml", typeof(MarriageResponseType)); break;
    //                case "2":
    //                case "4": result = (MarriageResponseType)FileUtils.ReadXml("\\XMLData\\MarriageResponse2.xml", typeof(MarriageResponseType)); break;
    //                case "6":
    //                case "8": result = (MarriageResponseType)FileUtils.ReadXml("\\XMLData\\MarriageResponse3.xml", typeof(MarriageResponseType)); break;
    //                case "1":
    //                case "3": result = (MarriageResponseType)FileUtils.ReadXml("\\XMLData\\MarriageResponse4.xml", typeof(MarriageResponseType)); break;
    //                default: result = (MarriageResponseType)FileUtils.ReadXml("\\XMLData\\MarriageResponse9.xml", typeof(MarriageResponseType)); break;
    //            };

    //            return
    //                SigningUtils.CreateAndSign(
    //                argument,
    //                result,
    //                accessMatrix,
    //                aditionalParameters
    //                );
    //        }
    //        catch (Exception ex)
    //        {
    //            LogError(aditionalParameters, ex, new { Guid = id });
    //            throw ex;
    //        }
    //    }

    //    public CommonSignedResponse<MaritalStatusSpouseChildrenRequestType, MaritalStatusSpouseChildrenResponseType> MaritalStatusSpouseChildrenSearch(MaritalStatusSpouseChildrenRequestType argument, AccessMatrix accessMatrix, AdapterAdditionalParameters aditionalParameters)
    //    {
    //        Guid id = Guid.NewGuid();
    //        LogData(aditionalParameters, new { Request = argument.XmlSerialize(), Guid = id });
    //        try
    //        {
    //            MaritalStatusSpouseChildrenResponseType result = new MaritalStatusSpouseChildrenResponseType();
    //            result = (MaritalStatusSpouseChildrenResponseType)FileUtils.ReadXml("\\XMLData\\MaritalStatusSpouseChildrenResponse.xml", typeof(MaritalStatusSpouseChildrenResponseType));

    //            result.ReportDate = DateTime.Now;
    //            result.ReportDateSpecified = true;

    //            return
    //               SigningUtils.CreateAndSign(
    //               argument,
    //               result,
    //               accessMatrix,
    //               aditionalParameters
    //               );
    //        }

    //        catch (Exception ex)
    //        {
    //            LogError(aditionalParameters, ex, new { Guid = id });
    //            throw ex;
    //        }
    //    }
    //}
}
