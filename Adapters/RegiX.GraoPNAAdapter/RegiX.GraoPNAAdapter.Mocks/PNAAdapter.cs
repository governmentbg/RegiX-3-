namespace TechnoLogica.RegiX.GraoPNAAdapter.AdapterService
{
    //public class PNAAdapter : InformixAdapterService.InformixBaseAdapterService, IPNAAdapter, IAdapterService
    //{

    //    [Export(typeof(ParameterInfo))]
    //    public static ParameterInfo<string> ConnectionString =
    //        new ParameterInfo<string>("Database=grao;Host=egov;Server=;Service=25852;Protocol=onsoctcp;UID=informix;Password=;DB_LOCALE=en_US.57372")
    //        {
    //            Key = Constants.ConnectionStringParameterKeyName,
    //            Description = "Connection string for Informix",
    //            OwnerAssembly = typeof(PNAAdapter).Assembly
    //        };


    //    /// <summary>
    //    /// Конверсия от ЕГН към ЕГН с век
    //    /// </summary>


    //    public CommonSignedResponse<PermanentAddressRequestType, PermanentAddressResponseType> PermanentAddressSearch(
    //        PermanentAddressRequestType argument,
    //        AccessMatrix accessMatrix,
    //        AdapterAdditionalParameters aditionalParameters)
    //    {
    //        Guid id = Guid.NewGuid();
    //        LogData(aditionalParameters, new { Request = argument.Serialize(), Guid = id });
    //        try
    //        {
    //            PermanentAddressResponseType result = new PermanentAddressResponseType();
    //            if (!argument.EGN.StartsWith("1"))
    //            {
    //                result = (PermanentAddressResponseType)FileUtils.ReadXml("\\XMLData\\PermanentAddressResponse.xml", typeof(PermanentAddressResponseType));
    //            }
    //            else
    //            {
    //                result = (PermanentAddressResponseType)FileUtils.ReadXml("\\XMLData\\PermanentAddressResponse.xml", typeof(PermanentAddressResponseType));
    //            }
    //            return SigningUtils.CreateAndSign(
    //                      argument,
    //                      result,
    //                      accessMatrix,
    //                      aditionalParameters
    //                      );
    //        }
    //        catch (Exception ex)
    //        {
    //            LogError(aditionalParameters, ex, new { Guid = id });
    //            throw ex;
    //        }
    //    }

    //    public CommonSignedResponse<TemporaryAddressRequestType, TemporaryAddressResponseType> TemporaryAddressSearch(TemporaryAddressRequestType argument, AccessMatrix accessMatrix, AdapterAdditionalParameters aditionalParameters)
    //    {
    //        Guid id = Guid.NewGuid();
    //        LogData(aditionalParameters, new { Request = argument.Serialize(), Guid = id });
    //        try
    //        {
    //            TemporaryAddressResponseType result = new TemporaryAddressResponseType();
    //            if (!argument.EGN.StartsWith("1"))
    //            {
    //                result = (TemporaryAddressResponseType)FileUtils.ReadXml("\\XMLData\\TemporaryAddressResponse.xml", typeof(TemporaryAddressResponseType));
    //            }
    //            else
    //            {
    //                result = (TemporaryAddressResponseType)FileUtils.ReadXml("\\XMLData\\TemporaryAddressResponse.xml", typeof(TemporaryAddressResponseType));
    //            }
    //            return SigningUtils.CreateAndSign(
    //                    argument,
    //                    result,
    //                    accessMatrix,
    //                    aditionalParameters
    //                    );
    //        }
    //        catch (Exception ex)
    //        {
    //            LogError(aditionalParameters, ex, new { Guid = id });
    //            throw ex;
    //        }
    //    }

    //}
}
