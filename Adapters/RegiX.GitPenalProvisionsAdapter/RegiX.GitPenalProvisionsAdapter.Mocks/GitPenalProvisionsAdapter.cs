namespace TechnoLogica.RegiX.GitPenalProvisionsAdapter.AdapterService
{
    //public class GitPenalProvisionsAdapter : SQLServerAdapterService.SQLServerAdapterService, IGitPenalProvisionsAdapter, IAdapterService
    //{

    //    //public GitPenalProvisionsAdapter()
    //    //{
    //    //    ConnectionString =
    //    //        new ParameterInfo<string>(@"data source=;initial catalog=regix2MockDb;user id=;password=;")
    //    //        {
    //    //            Key = "ConnectionString",
    //    //            Description = "Connection string",
    //    //            OwnerAssembly = typeof(GitPenalProvisionsAdapter).Assembly
    //    //        };
    //    //}

    //    [Export(typeof(ParameterInfo))]
    //    public static ParameterInfo<string> ConnectionString =
    //        new ParameterInfo<string>(@"data source=;initial catalog=regix2MockDb;user id=;password=;")
    //        {
    //            Key = Constants.ConnectionStringParameterKeyName,
    //            Description = "Connection string",
    //            OwnerAssembly = typeof(GitPenalProvisionsAdapter).Assembly
    //        };

    //    public CommonSignedResponse<PenalProvisionForPeriodRequest, PenalProvisionForPeriodResponse> GetPenalProvisionForPeriod(PenalProvisionForPeriodRequest argument, AccessMatrix accessMatrix, AdapterAdditionalParameters aditionalParameters)
    //    {
    //        Guid id = Guid.NewGuid();
    //        LogData(aditionalParameters, new { Request = argument.Serialize(), Guid = id });
    //        try
    //        {
    //            PenalProvisionForPeriodResponse result = new PenalProvisionForPeriodResponse();
    //            if (argument.IntruderIdentifier.StartsWith("9"))
    //            {
    //                result = (PenalProvisionForPeriodResponse)FileUtils.ReadXml("\\XMLData\\GetPenalProvisionForPeriodTest.xml", typeof(PenalProvisionForPeriodResponse));
    //            }
    //            else
    //            {
    //                result = (PenalProvisionForPeriodResponse)FileUtils.ReadXml("\\XMLData\\GetPenalProvisionForPeriodNullTest.xml", typeof(PenalProvisionForPeriodResponse));
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

    //    public CommonSignedResponse<PenalProvisionMediatorActType, PenalProvisionMediatorActResponse> GetPenalProvisionMediatorAct(PenalProvisionMediatorActType argument, AccessMatrix accessMatrix, AdapterAdditionalParameters aditionalParameters)
    //    {
    //        Guid id = Guid.NewGuid();
    //        LogData(aditionalParameters, new { Request = argument.Serialize(), Guid = id });
    //        try
    //        {
    //            PenalProvisionMediatorActResponse result = new PenalProvisionMediatorActResponse();
    //            if (argument.PenalProvisionRelation.StartsWith("T"))
    //            {
    //                result = (PenalProvisionMediatorActResponse)FileUtils.ReadXml("\\XMLData\\GetPenalProvisionMediatorActTest.xml", typeof(PenalProvisionMediatorActResponse));
    //            }
    //            else
    //            {
    //                result = (PenalProvisionMediatorActResponse)FileUtils.ReadXml("\\XMLData\\GetPenalProvisionMediatorActNullTest.xml", typeof(PenalProvisionMediatorActResponse));
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

    //    public CommonSignedResponse<PenalProvisionUnpaidFeeType, PenalProvisionUnpaidFeeResponse> GetPenalProvisionUnpaidFee(PenalProvisionUnpaidFeeType argument, AccessMatrix accessMatrix, AdapterAdditionalParameters aditionalParameters)
    //    {
    //        Guid id = Guid.NewGuid();
    //        LogData(aditionalParameters, new { Request = argument.Serialize(), Guid = id });
    //        try
    //        {
    //            PenalProvisionUnpaidFeeResponse result = new PenalProvisionUnpaidFeeResponse();
    //            if (argument.IntruderIdentifier.StartsWith("9"))
    //            {
    //                result = (PenalProvisionUnpaidFeeResponse)FileUtils.ReadXml("\\XMLData\\GetPenalProvisionUnpaidFeeTest.xml", typeof(PenalProvisionUnpaidFeeResponse));
    //            }
    //            else
    //            {
    //                result = (PenalProvisionUnpaidFeeResponse)FileUtils.ReadXml("\\XMLData\\GetPenalProvisionUnpaidFeeNullTest.xml", typeof(PenalProvisionUnpaidFeeResponse));
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
