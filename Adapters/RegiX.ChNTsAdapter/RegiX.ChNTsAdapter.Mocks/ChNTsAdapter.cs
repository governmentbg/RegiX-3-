namespace TechnoLogica.RegiX.ChNTsAdapter.AdapterService
{
    //public class ChNTsAdapter : SQLServerAdapterService.SQLServerAdapterService, IChNTsAdapter, IAdapterService
    //{
    //    //public ChNTsAdapter()
    //    //{
    //    //    ConnectionString =
    //    //    new ParameterInfo<string>("data source=;initial catalog=;user id=;password=;")
    //    //    {
    //    //        Key = "ConnectionString",
    //    //        Description = "Connection string",
    //    //        OwnerAssembly = typeof(ChNTsAdapter).Assembly
    //    //    };
    //    //}

    //    [Export(typeof(ParameterInfo))]
    //    public static ParameterInfo<string> ConnectionString =
    //        new ParameterInfo<string>("data source=;initial catalog=;user id=;password=;")
    //        {
    //            Key = Constants.ConnectionStringParameterKeyName,
    //            Description = "Connection string",
    //            OwnerAssembly = typeof(ChNTsAdapter).Assembly
    //        };

    //    public CommonSignedResponse<ForeignerPermissionsRequestType, ForeignerPermissionsResponseType> GetForeignerPermissions(ForeignerPermissionsRequestType argument, AccessMatrix accessMatrix, AdapterAdditionalParameters aditionalParameters)
    //    {
    //        Guid id = Guid.NewGuid();
    //        LogData(aditionalParameters, new { Request = argument.Serialize(), Guid = id });
    //        try
    //        {
    //            ForeignerPermissionsResponseType result = new ForeignerPermissionsResponseType();

    //            result = (ForeignerPermissionsResponseType)FileUtils.ReadXml("\\XMLData\\ChNTs.xml", typeof(ForeignerPermissionsResponseType));

    //            return
    //                SigningUtils.CreateAndSign(
    //                    argument,
    //                    result,
    //                    accessMatrix,
    //                    aditionalParameters
    //                );
    //        }
    //        catch (Exception ex)
    //        {
    //            LogError(aditionalParameters, ex, new { Guid = id });
    //            throw ex;
    //        }
    //    }





    //}
}
