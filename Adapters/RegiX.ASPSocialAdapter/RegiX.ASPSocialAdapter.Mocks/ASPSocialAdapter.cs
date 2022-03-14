namespace TechnoLogica.RegiX.ASPSocialAdapter.Mocks
{
    //public class ASPSocialAdapter : OracleAdapterService.OracleBaseAdapterService, IASPSocialAdapter, IAdapterService
    //{
    //    private const string EgnInputParameter = "E";
    //    private const string LnchInputParamter = "L";

    //    [Export(typeof(ParameterInfo))]
    //    public static ParameterInfo<string> ConnectionString =
    //        new ParameterInfo<string>(@"Data Source=;User ID=;Password=;")
    //        {
    //            Key = Constants.ConnectionStringParameterKeyName,
    //            Description = "Connection string",
    //            OwnerAssembly = typeof(ASPSocialAdapter).Assembly
    //        };

    //    [Export(typeof(ParameterInfo))]
    //    public static ParameterInfo<string> MonthlySocialBenefitsProcedureName =
    //        new ParameterInfo<string>("regix_routines.get_monthly_social_benefits")
    //        {
    //            Key = "MonthlySocialBenefitsProcedureName",
    //            Description = "the procedure which is called by GetMonthlySocialBenefits()",
    //            OwnerAssembly = typeof(ASPSocialAdapter).Assembly
    //        };

    //    [Export(typeof(ParameterInfo))]
    //    public static ParameterInfo<string> BenefitsForHeatingProcedureName =
    //        new ParameterInfo<string>("regix_routines.get_benefits_for_heating")
    //        {
    //            Key = "BenefitsForHeatingProcedureName",
    //            Description = "the procedure which is called by GetBenefitsForHeating()",
    //            OwnerAssembly = typeof(ASPSocialAdapter).Assembly
    //        };

    //    [Export(typeof(ParameterInfo))]
    //    public static ParameterInfo<string> SocialServicesDecisionsProcedureName =
    //        new ParameterInfo<string>("regix_routines.get_social_services_decisions")
    //        {
    //            Key = "SocialServicesDecisionsProcedureName",
    //            Description = "the procedure which is called by GetSocialServicesDecisions()",
    //            OwnerAssembly = typeof(ASPSocialAdapter).Assembly
    //        };

    //    public CommonSignedResponse<GetMonthlySocialBenefitsRequest, GetMonthlySocialBenefitsResponseType> GetMonthlySocialBenefits(GetMonthlySocialBenefitsRequest argument, AccessMatrix accessMatrix, AdapterAdditionalParameters aditionalParameters)
    //    {
    //        Guid id = Guid.NewGuid();
    //        LogData(aditionalParameters, new { Request = argument.Serialize(), Guid = id });
    //        Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
    //        try
    //        {
    //            GetMonthlySocialBenefitsResponseType result = new GetMonthlySocialBenefitsResponseType();
    //            string val = argument.PersonData.Identifier;
    //            if (val != null && (val.EndsWith("0") || val.EndsWith("1") || val.EndsWith("2") || val.EndsWith("3") || val.EndsWith("4")))
    //            {
    //                result = (GetMonthlySocialBenefitsResponseType)FileUtils.ReadXml("\\XMLData\\GetMonthlySocialBenefitsResponse.xml", typeof(GetMonthlySocialBenefitsResponseType));
    //            }
    //            else
    //            {
    //                result = (GetMonthlySocialBenefitsResponseType)FileUtils.ReadXml("\\XMLData\\GetMonthlySocialBenefitsResponseEmpty.xml", typeof(GetMonthlySocialBenefitsResponseType));
    //            }
    //            result.CurrentTime = DateTime.Now;

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

    //    public CommonSignedResponse<GetBenefitsForHeatingRequest, GetBenefitsForHeatingResponseType> GetBenefitsForHeating(GetBenefitsForHeatingRequest argument, AccessMatrix accessMatrix, AdapterAdditionalParameters aditionalParameters)
    //    {
    //        Guid id = Guid.NewGuid();
    //        LogData(aditionalParameters, new { Request = argument.Serialize(), Guid = id });
    //        Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
    //        try
    //        {
    //            GetBenefitsForHeatingResponseType result = new GetBenefitsForHeatingResponseType();
    //            string val = argument.PersonData.Identifier;
    //            if (val != null && (val.EndsWith("0") || val.EndsWith("1") || val.EndsWith("2") || val.EndsWith("3") || val.EndsWith("4")))
    //            {
    //                result = (GetBenefitsForHeatingResponseType)FileUtils.ReadXml("\\XMLData\\GetBenefitsForHeatingResponse.xml", typeof(GetBenefitsForHeatingResponseType));
    //            }
    //            else
    //            {
    //                result = (GetBenefitsForHeatingResponseType)FileUtils.ReadXml("\\XMLData\\GetBenefitsForHeatingResponseEmpty.xml", typeof(GetBenefitsForHeatingResponseType));
    //            }
    //            result.CurrentTime = DateTime.Now;

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

    //    public CommonSignedResponse<GetSocialServicesDecisionsRequest, GetSocialServicesDecisionsResponseType> GetSocialServicesDecisions(GetSocialServicesDecisionsRequest argument, AccessMatrix accessMatrix, AdapterAdditionalParameters aditionalParameters)
    //    {
    //        Guid id = Guid.NewGuid();
    //        LogData(aditionalParameters, new { Request = argument.Serialize(), Guid = id });
    //        Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
    //        try
    //        {
    //            GetSocialServicesDecisionsResponseType result = new GetSocialServicesDecisionsResponseType();
    //            string val = argument.PersonData.Identifier;
    //            if (val != null && (val.EndsWith("0") || val.EndsWith("1") || val.EndsWith("2") || val.EndsWith("3") || val.EndsWith("4")))
    //            {
    //                result = (GetSocialServicesDecisionsResponseType)FileUtils.ReadXml("\\XMLData\\GetSocialServicesDecisionsResponse.xml", typeof(GetSocialServicesDecisionsResponseType));
    //            }
    //            else
    //            {
    //                result = (GetSocialServicesDecisionsResponseType)FileUtils.ReadXml("\\XMLData\\GetSocialServicesDecisionsResponseEmpty.xml", typeof(GetSocialServicesDecisionsResponseType));
    //            }
    //            result.CurrentTime = DateTime.Now;

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