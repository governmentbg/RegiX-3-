namespace TechnoLogica.RegiX.AVTRAdapter.AdapterService
{
    //public class TRAdapter : OracleAdapterService.OracleBaseAdapterService, ITRAdapter, IAdapterService
    //{
    //    public override string CheckRegisterConnection()
    //    {
    //        return Constants.ConnectionOk;
    //    }
    //    public CommonSignedResponse<ActualStateRequestType, ActualStateResponseType> GetActualState(ActualStateRequestType argument, AccessMatrix accessMatrix, AdapterAdditionalParameters aditionalParameters)
    //    {
    //        Guid id = Guid.NewGuid();
    //        LogData(aditionalParameters, new { Request = argument.Serialize(), Guid = id });
    //        try
    //        {
    //            ActualStateResponseType result = new ActualStateResponseType();
    //            if (argument.UIC != null)
    //            {
    //                switch (argument.UIC.Substring(argument.UIC.Length-1))
    //                {
    //                    case "1":
    //                        result = (ActualStateResponseType)FileUtils.ReadXml("\\XMLData\\ActualState_ET.xml", typeof(ActualStateResponseType));
    //                        break;
    //                    case "2":
    //                        result = (ActualStateResponseType)FileUtils.ReadXml("\\XMLData\\ActualState_SD.xml", typeof(ActualStateResponseType));
    //                        break;
    //                    case "3":
    //                        result = (ActualStateResponseType)FileUtils.ReadXml("\\XMLData\\ActualState_KD.xml", typeof(ActualStateResponseType));
    //                        break;
    //                    case "4":
    //                        result = (ActualStateResponseType)FileUtils.ReadXml("\\XMLData\\ActualState_OOD.xml", typeof(ActualStateResponseType));
    //                        break;
    //                    case "5":
    //                        result = (ActualStateResponseType)FileUtils.ReadXml("\\XMLData\\ActualState_OOD.xml", typeof(ActualStateResponseType));
    //                        break;
    //                    case "6":
    //                        result = (ActualStateResponseType)FileUtils.ReadXml("\\XMLData\\ActualState_DP.xml", typeof(ActualStateResponseType));
    //                        break;
    //                    case "7":
    //                        result = (ActualStateResponseType)FileUtils.ReadXml("\\XMLData\\ActualState_KOOP.xml", typeof(ActualStateResponseType));
    //                        break;
    //                    default:
    //                        result = (ActualStateResponseType)FileUtils.ReadXml("\\XMLData\\ActualState_EAD.xml", typeof(ActualStateResponseType));
    //                        break;
    //                }
    //            }
    //            else
    //            {
    //                result = (ActualStateResponseType)FileUtils.ReadXml("\\XMLData\\ActualStateNoRecords.xml", typeof(ActualStateResponseType));
    //            }

    //            result.DataValidForDate = DateTime.Now;
    //            result.DataValidForDateSpecified = true;

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

    //    public CommonSignedResponse<ActualStateRequestV2, ActualStateResponseV2> GetActualStateV2(ActualStateRequestV2 argument, AccessMatrix accessMatrix, AdapterAdditionalParameters aditionalParameters)
    //    {
    //        Guid id = Guid.NewGuid();
    //        LogData(aditionalParameters, new { Request = argument.XmlSerialize(), Guid = id });
    //        try
    //        {
    //            ActualStateResponseV2 result = new ActualStateResponseV2();
    //            if (argument.UIC != null && argument.UIC.Length > 1)
    //            {
    //                string fileName = AppDomain.CurrentDomain.BaseDirectory + "\\XMLData\\" + argument.UIC + ".xml";

    //                if (File.Exists(fileName))
    //                {
    //                    result = (ActualStateResponseV2)FileUtils.ReadXml("\\XMLData\\" + argument + ".xml", typeof(ActualStateResponseV2));
    //                }
    //                else
    //                {
    //                    switch (argument.UIC.Substring(argument.UIC.Length - 1))
    //                    {
    //                        case "1":
    //                            result = (ActualStateResponseV2)FileUtils.ReadXml("\\XMLData\\ActualStateV2_1.xml", typeof(ActualStateResponseV2));
    //                            break;
    //                        case "2":
    //                            result = (ActualStateResponseV2)FileUtils.ReadXml("\\XMLData\\ActualStateV2_2.xml", typeof(ActualStateResponseV2));
    //                            break;
    //                        case "3":
    //                            result = (ActualStateResponseV2)FileUtils.ReadXml("\\XMLData\\ActualStateV2_3.xml", typeof(ActualStateResponseV2));
    //                            break;
    //                        case "4":
    //                            result = (ActualStateResponseV2)FileUtils.ReadXml("\\XMLData\\ActualStateV2_4.xml", typeof(ActualStateResponseV2));
    //                            break;
    //                        case "5":
    //                            result = (ActualStateResponseV2)FileUtils.ReadXml("\\XMLData\\ActualStateV2_5.xml", typeof(ActualStateResponseV2));
    //                            break;
    //                        case "6":
    //                            result = (ActualStateResponseV2)FileUtils.ReadXml("\\XMLData\\ActualStateV2_6.xml", typeof(ActualStateResponseV2));
    //                            break;
    //                        case "7":
    //                            result = (ActualStateResponseV2)FileUtils.ReadXml("\\XMLData\\ActualStateV2_7.xml", typeof(ActualStateResponseV2));
    //                            break;
    //                        case "8":
    //                            result = (ActualStateResponseV2)FileUtils.ReadXml("\\XMLData\\ActualStateV2_8.xml", typeof(ActualStateResponseV2));
    //                            break;
    //                        case "9":
    //                            result = (ActualStateResponseV2)FileUtils.ReadXml("\\XMLData\\ActualStateV2_9.xml", typeof(ActualStateResponseV2));
    //                            break;
    //                        case "0":
    //                            result = (ActualStateResponseV2)FileUtils.ReadXml("\\XMLData\\ActualStateV2_0.xml", typeof(ActualStateResponseV2));
    //                            break;
    //                        default:
    //                            result = (ActualStateResponseV2)FileUtils.ReadXml("\\XMLData\\ActualStateV2_def.xml", typeof(ActualStateResponseV2));
    //                            break;
    //                    }
    //                }
    //                result.DataValidForDate = DateTime.Now;
    //                result.DataValidForDateSpecified = true;
    //                result.Deed.UIC = argument.UIC;
    //                if (!string.IsNullOrEmpty(argument.FieldList) && !string.IsNullOrWhiteSpace(argument.FieldList))
    //                {
    //                    var list = argument.FieldList.Split(',').Where(t => !string.IsNullOrEmpty(t) && !string.IsNullOrWhiteSpace(t));
    //                    if (list.Count() > 0)
    //                    {
    //                        List<ActualStateV2.Record> r = new List<ActualStateV2.Record>();
    //                        foreach(var l in list)
    //                        {
    //                            r.AddRange(result.Deed.Records.Where(f => f.FieldIdent.Contains(l.Trim())));
    //                        }
    //                        result.Deed.Records = r;
    //                    }
    //                }

    //            }
    //            else
    //            {
    //                result = new ActualStateResponseV2();
    //                //result = (ActualStateResponseV2)FileUtils.ReadXml("\\XMLData\\ActualStateV2NoRecords.xml", typeof(ActualStateResponseV2));
    //                result.Deed = null;
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

    //    public CommonSignedResponse<ActualStateRequestV3, ActualStateResponseV3> GetActualStateV3(ActualStateRequestV3 argument, AccessMatrix accessMatrix, AdapterAdditionalParameters aditionalParameters)
    //    {
    //        Guid id = Guid.NewGuid();
    //        LogData(aditionalParameters, new { Request = argument.XmlSerialize(), Guid = id });
    //        try
    //        {
    //            ActualStateResponseV3 result = new ActualStateResponseV3();
    //            if (argument.UIC != null && argument.UIC.Length > 1)
    //            {
    //                string fileName = AppDomain.CurrentDomain.BaseDirectory + "\\XMLData\\ActualStateV3\\" + argument.UIC + ".xml";

    //                if (File.Exists(fileName))
    //                {
    //                    result = (ActualStateResponseV3)FileUtils.ReadXml("\\XMLData\\ActualStateV3\\" + argument.UIC + ".xml", typeof(ActualStateResponseV3));
    //                }
    //                else
    //                {
    //                    if (argument.UIC.StartsWith("0"))
    //                    {
    //                        result = (ActualStateResponseV3)FileUtils.ReadXml("\\XMLData\\ActualStateV3\\empty.xml", typeof(ActualStateResponseV3));
    //                    }
    //                    else
    //                    {
    //                        result = (ActualStateResponseV3)FileUtils.ReadXml("\\XMLData\\ActualStateV3\\default.xml", typeof(ActualStateResponseV3));
    //                    }
    //                }

    //                result.DataValidForDate = DateTime.Now;
    //                result.DataValidForDateSpecified = true;

    //                if(result.DataFound == true && result.DataFoundSpecified == true)
    //                {
    //                    result.Deed.UIC = argument.UIC;
    //                    if (!string.IsNullOrEmpty(argument.FieldList) && !string.IsNullOrWhiteSpace(argument.FieldList))
    //                    {
    //                        var list = argument.FieldList.Split(',').Where(t => !string.IsNullOrEmpty(t) && !string.IsNullOrWhiteSpace(t));
    //                        if (list.Count() > 0 && result.Deed.Subdeeds != null)
    //                        {
    //                            if(result.Deed.Subdeeds.Subdeed != null)
    //                            {
    //                                foreach (var grp in result.Deed.Subdeeds.Subdeed)
    //                                {
    //                                    List<ActualStateV3.Record> r = new List<ActualStateV3.Record>();
    //                                    foreach (var l in list)
    //                                    {
    //                                        r.AddRange(grp.Records.Where(f => f.FieldIdent.Contains(l.Trim())));
    //                                    }
    //                                    grp.Records = r;
    //                                }
    //                            }
    //                        }
    //                    }
    //                }
    //                else
    //                {
    //                    result.Deed = null;
    //                }



    //            }
    //            else
    //            {
    //                result = new ActualStateResponseV3();
    //                //result = (ActualStateResponseV2)FileUtils.ReadXml("\\XMLData\\ActualStateV2NoRecords.xml", typeof(ActualStateResponseV2));
    //                result.Deed = null;
    //                result.DataFound = false;
    //                result.DataFoundSpecified = true;
    //                result.DataValidForDate = DateTime.Now;
    //                result.DataValidForDateSpecified = true;
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

    //    public CommonSignedResponse<GetBranchOfficeRequest, GetBranchOfficeResponse> GetBranchOffice(GetBranchOfficeRequest argument, AccessMatrix accessMatrix, AdapterAdditionalParameters aditionalParameters)
    //    {
    //        Guid id = Guid.NewGuid();
    //        LogData(aditionalParameters, new { Request = argument.XmlSerialize(), Guid = id });
    //        try
    //        {
    //            if (string.IsNullOrEmpty(argument.UIC) || argument.UIC.Length != 13)
    //            {
    //                throw new ArgumentException("Invalid length of UIC. UIC of branch company must be 13 symbols long.");
    //            }

    //            GetBranchOfficeResponse result = new GetBranchOfficeResponse();
    //            if (argument.UIC != null && argument.UIC.Length > 1)
    //            {

    //                if(argument.UIC.Length != 13)
    //                {
    //                    throw new ArgumentException("Invalid length of UIC. UIC of branch company must be 13 symbols long.");
    //                }

    //                string fileName = AppDomain.CurrentDomain.BaseDirectory + "\\XMLData\\GetBranchOffice\\" + argument.UIC + ".xml";

    //                if (File.Exists(fileName))
    //                {
    //                    result = (GetBranchOfficeResponse)FileUtils.ReadXml("\\XMLData\\GetBranchOffice\\" + argument.UIC + ".xml", typeof(GetBranchOfficeResponse));
    //                }
    //                else
    //                {
    //                    if (argument.UIC.StartsWith("0"))
    //                    {
    //                        result = (GetBranchOfficeResponse)FileUtils.ReadXml("\\XMLData\\GetBranchOffice\\empty.xml", typeof(GetBranchOfficeResponse));
    //                    }
    //                    else
    //                    {
    //                        result = (GetBranchOfficeResponse)FileUtils.ReadXml("\\XMLData\\GetBranchOffice\\default.xml", typeof(GetBranchOfficeResponse));
    //                    }
    //                }

    //                result.DataValidForDate = DateTime.Now;
    //                result.DataValidForDateSpecified = true;

    //                if(result.DataFound == true && result.DataFoundSpecified)
    //                {
    //                    result.Deed.UIC = argument.UIC.Substring(0, 9);
    //                    if (result.Deed.Subdeeds != null)
    //                    {
    //                        var branchInfo = result.Deed.Subdeeds.Subdeed?.Where(x => x.SubUICType == SubUICType.Item3).FirstOrDefault();
    //                        if (branchInfo != null)
    //                        {
    //                            branchInfo.SubUIC = argument.UIC.Substring(9);
    //                        }
    //                    }
    //                }
    //                else
    //                {
    //                    result.Deed = null;
    //                }



    //            }
    //            else
    //            {
    //                result = new GetBranchOfficeResponse();
    //                //result = (ActualStateResponseV2)FileUtils.ReadXml("\\XMLData\\ActualStateV2NoRecords.xml", typeof(ActualStateResponseV2));
    //                result.Deed = null;
    //                result.DataFound = false;
    //                result.DataFoundSpecified = true;
    //                result.DataValidForDate = DateTime.Now;
    //                result.DataValidForDateSpecified = true;
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

    //    public CommonSignedResponse<ValidUICRequestType, ValidUICResponseType> GetValidUICInfo(ValidUICRequestType argument, AccessMatrix accessMatrix, AdapterAdditionalParameters aditionalParameters)
    //    {
    //        Guid id = Guid.NewGuid();
    //        LogData(aditionalParameters, new { Request = argument.Serialize(), Guid = id });
    //        try
    //        {

    //            ValidUICResponseType result = new ValidUICResponseType();
    //            if (argument.UIC != null)
    //            {
    //                result = (ValidUICResponseType)FileUtils.ReadXml("\\XMLData\\ValidUIC_TL.xml", typeof(ValidUICResponseType));
    //            }
    //            else
    //            {
    //                result = (ValidUICResponseType)FileUtils.ReadXml("\\XMLData\\ValidUIC_NotFound.xml", typeof(ValidUICResponseType));
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

    //    public CommonSignedResponse<SearchParticipationInCompaniesRequestType, SearchParticipationInCompaniesResponseType> PersonInCompaniesSearch(SearchParticipationInCompaniesRequestType argument, AccessMatrix accessMatrix, AdapterAdditionalParameters aditionalParameters)
    //    {
    //        Guid id = Guid.NewGuid();
    //        LogData(aditionalParameters, new { Request = argument.Serialize(), Guid = id });
    //        try
    //        {
    //            SearchParticipationInCompaniesResponseType result = new SearchParticipationInCompaniesResponseType();
    //            if (argument.EGN != null)
    //            {
    //                result = (SearchParticipationInCompaniesResponseType)FileUtils.ReadXml("\\XMLData\\SearchParticipationInCompanies_Ogi.xml", typeof(SearchParticipationInCompaniesResponseType));
    //            }
    //            else
    //            {
    //                result = (SearchParticipationInCompaniesResponseType)FileUtils.ReadXml("\\XMLData\\SearchParticipationInCompanies_NotFound.xml", typeof(SearchParticipationInCompaniesResponseType));
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

    //}
}
