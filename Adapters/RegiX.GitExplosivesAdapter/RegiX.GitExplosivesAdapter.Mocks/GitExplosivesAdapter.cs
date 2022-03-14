namespace TechnoLogica.RegiX.GitExplosivesAdapter.AdapterService
{
    //public class GitExplosivesAdapter : SQLServerAdapterService.SQLServerAdapterService, IGitExplosivesAdapter, IAdapterService
    //{
    //    //public GitExplosivesAdapter()
    //    //{
    //    //    ConnectionString =
    //    //        new ParameterInfo<string>(@"data source=;initial catalog=regix2MockDb;user id=;password=;")
    //    //        {
    //    //            Key = "ConnectionString",
    //    //            Description = "Connection string",
    //    //            OwnerAssembly = typeof(GitExplosivesAdapter).Assembly
    //    //        };
    //    //}

    //    [Export(typeof(ParameterInfo))]
    //    public static ParameterInfo<string> ConnectionString =
    //        new ParameterInfo<string>(@"data source=;initial catalog=regix2MockDb;user id=;password=;")
    //        {
    //            Key = Constants.ConnectionStringParameterKeyName,
    //            Description = "Connection string",
    //            OwnerAssembly = typeof(GitExplosivesAdapter).Assembly
    //        };

    //    [Export(typeof(ParameterInfo))]
    //    public static ParameterInfo<string> MViewsUser =
    //        new ParameterInfo<string>("[dbo]")
    //        {
    //            Key = "MViewsUser",
    //            Description = "Name of user where MViews are created",
    //            OwnerAssembly = typeof(GitExplosivesAdapter).Assembly
    //        };

    //    public CommonSignedResponse<AuthenticityExplosivesRequestType, ValidExplosivesCertificateResponse> GetAuthenticityExplosivesCertificate(AuthenticityExplosivesRequestType argument, AccessMatrix accessMatrix, AdapterAdditionalParameters aditionalParameters)
    //    {
    //        Guid id = Guid.NewGuid();
    //        LogData(aditionalParameters, new { Request = argument.Serialize(), Guid = id });
    //        try
    //        {
    //            ValidExplosivesCertificateResponse result = new ValidExplosivesCertificateResponse();
    //            if (argument.Identifier.StartsWith("9"))
    //            {
    //                result = (ValidExplosivesCertificateResponse)FileUtils.ReadXml("\\XMLData\\GetAuthenticityExplosivesCertificate_Test.xml", typeof(ValidExplosivesCertificateResponse));
    //            }
    //            else
    //            {
    //                result = (ValidExplosivesCertificateResponse)FileUtils.ReadXml("\\XMLData\\GetAuthenticityExplosivesCertificate_NULL_Test.xml", typeof(ValidExplosivesCertificateResponse));
    //            }
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

    //    public CommonSignedResponse<ValidExplosivesRequestType, ValidExplosivesCertificateResponse> GetValidExplosivesCertificate(ValidExplosivesRequestType argument, AccessMatrix accessMatrix, AdapterAdditionalParameters aditionalParameters)
    //    {
    //        Guid id = Guid.NewGuid();
    //        LogData(aditionalParameters, new { Request = argument.Serialize(), Guid = id });
    //        try
    //        {
    //            ValidExplosivesCertificateResponse result = new ValidExplosivesCertificateResponse();
    //            if (argument.Identifier.StartsWith("9"))
    //            {
    //                result = (ValidExplosivesCertificateResponse)FileUtils.ReadXml("\\XMLData\\GetValidExplosivesCertificate_Test.xml", typeof(ValidExplosivesCertificateResponse));
    //            }
    //            else
    //            {
    //                result = (ValidExplosivesCertificateResponse)FileUtils.ReadXml("\\XMLData\\GetValidExplosivesCertificate_NULL_Test.xml", typeof(ValidExplosivesCertificateResponse));
    //            }
    //            return
    //                 SigningUtils.CreateAndSign(
    //                     argument,
    //                     result,
    //                     accessMatrix,
    //                     aditionalParameters
    //                 );

    //        }
    //        catch (Exception ex)
    //        {
    //            LogError(aditionalParameters, ex, new { Guid = id });
    //            throw ex;
    //        }
    //    }

    //}    
}
