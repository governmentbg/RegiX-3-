namespace TechnoLogica.RegiX.GraoNMAdapter.AdapterService
{
    //public class NMAdapter : InformixAdapterService.InformixBaseAdapterService, INMAdapter, IAdapterService
    //{

    //    [Export(typeof(ParameterInfo))]
    //    public static ParameterInfo<string> ConnectionString =
    //        new ParameterInfo<string>("Database=grao;Host=egov;Server=ol_informix1170_1;Service=25852;Protocol=onsoctcp;UID=informix;Password=;DB_LOCALE=en_US.57372")
    //        {
    //            Key = Constants.ConnectionStringParameterKeyName,
    //            Description = "Connection string for Informix",
    //            OwnerAssembly = typeof(NMAdapter).Assembly
    //        };



    //    [Export(typeof(ParameterInfo))]
    //    public static ParameterInfo<string> SchemaName =
    //        new ParameterInfo<string>("grao")
    //        {
    //            Key = "SchemaName",
    //            Description = "Name of the schema in database",
    //            OwnerAssembly = typeof(NMAdapter).Assembly
    //        };

    //    public CommonSignedResponse<SettlementPlacesRequestType, SettlementPlacesResponseType> SettlementPlacesSearch(
    //        SettlementPlacesRequestType argument, 
    //        AccessMatrix accessMatrix,
    //        AdapterAdditionalParameters aditionalParameters)
    //    {
    //        Guid id = Guid.NewGuid();
    //        LogData(aditionalParameters, new { Request = argument.Serialize(), Guid = id });
    //        try
    //        {

    //            SettlementPlacesResponseType result = new SettlementPlacesResponseType();
    //            if (argument.EndDate < DateTime.Now.AddMonths(-1))
    //            {
    //                result = (SettlementPlacesResponseType)FileUtils.ReadXml("\\XMLData\\SettlementPlacesResponse.xml", typeof(SettlementPlacesResponseType));
    //            }
    //            else
    //            {
    //                result = (SettlementPlacesResponseType)FileUtils.ReadXml("\\XMLData\\SettlementPlacesResponse.xml", typeof(SettlementPlacesResponseType));
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
