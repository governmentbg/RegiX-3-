using RegiX.Adapters.Mocks;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.IO;
using System.Text;
using TechnoLogica.RegiX.Adapters.Common.ExportExtension;
using TechnoLogica.RegiX.AVTRAdapter.ActualStateV2;
using TechnoLogica.RegiX.AVTRAdapter.ActualStateV3;
using TechnoLogica.RegiX.AVTRAdapter.AdapterService;
using TechnoLogica.RegiX.Common;

namespace TechnoLogica.RegiX.AVTRAdapter.Mocks
{
    public class TRAdapterMock : BaseAdapterServiceProxy<ITRAdapter>
    {
        static TRAdapterMock()
        {
            RegisterResolver<ActualStateRequestType, ActualStateResponseType>(
                (i, r, a, o) => i.GetActualState(r, a, o),
                (r) => ResolveGetActualStateFileName(r),
                (r) => AugmentGetActualState(r)
                );
            RegisterResolver<ActualStateRequestV2, ActualStateResponseV2>(
                (i, r, a, o) => i.GetActualStateV2(r, a, o),
                (r) => ResolveGetActualStateV2FileName(r),
                (r) => AugmentGetActualStateV2(r)
                );
            RegisterResolver<ActualStateRequestV3, ActualStateResponseV3>(
                (i, r, a, o) => i.GetActualStateV3(r, a, o),
                (r) => ResolveGetActualStateV3FileName(r),
                (r) => AugmentGetActualStateV3(r)
                );
            RegisterResolver<ValidUICRequestType, ValidUICResponseType>(
                (i, r, a, o) => i.GetValidUICInfo(r, a, o),
                (r) => ResolveGetValidUICInfoFileName(r),
                (r) => AugmentGetValidUICInfo(r)
                );
            RegisterResolver<GetBranchOfficeRequest, GetBranchOfficeResponse>(
                (i, r, a, o) => i.GetBranchOffice(r, a, o),
                (r) => ResolveGetBranchOfficeFileName(r),
                (r) => AugmentGetBranchOffice(r)
                );
            RegisterResolver<SearchParticipationInCompaniesRequestType, SearchParticipationInCompaniesResponseType>(
                (i, r, a, o) => i.PersonInCompaniesSearch(r, a, o),
                (r) => ResolvePersonInCompaniesSearchFileName(r)
                );
        }

        private static string ResolvePersonInCompaniesSearchFileName(SearchParticipationInCompaniesRequestType r)
        {
            if (r?.EGN != null)
            {
                return $"{DataFolder}SearchParticipationInCompanies_Ogi.xml";
            }
            else
            {
                return $"{DataFolder}SearchParticipationInCompanies_NotFound.xml";
            }
        }

        private static string ResolveGetBranchOfficeFileName(GetBranchOfficeRequest r)
        {
            return $"{DataFolder}GetBranchOffice{Path.DirectorySeparatorChar}default.xml";
        }

        private static void AugmentGetBranchOffice(GetBranchOfficeResponse r)
        {
        }

        private static string ResolveGetValidUICInfoFileName(ValidUICRequestType r)
        {
            if (r?.UIC != null)
            {
                return $"{DataFolder}ValidUIC_TL.xml";
            }
            else
            {
                return $"{DataFolder}ValidUIC_NotFound.xml";                
            }
            
        }

        private static void AugmentGetValidUICInfo(ValidUICResponseType r)
        {
        }

        private static string ResolveGetActualStateV3FileName(ActualStateRequestV3 r)
        {
            return $"{DataFolder}ActualStateV3{Path.DirectorySeparatorChar}default.xml";
        }

        private static void AugmentGetActualStateV3(ActualStateResponseV3 r)
        {
        }

        private static string ResolveGetActualStateV2FileName(ActualStateRequestV2 r)
        {
            if (r?.UIC != null && r.UIC.Length > 1)
            {
                string fileName = $"{DataFolder}{r.UIC}.xml";

                if (File.Exists(AppDomain.CurrentDomain.BaseDirectory + fileName))
                {
                    return fileName;
                }
                else
                {
                    switch (r?.UIC.Substring(r.UIC.Length - 1))
                    {
                        case "1":
                            return $"{DataFolder}ActualStateV2_1.xml";
                        case "2":
                            return $"{DataFolder}ActualStateV2_2.xml";
                        case "3":
                            return $"{DataFolder}ActualStateV2_3.xml";
                        case "4":
                            return $"{DataFolder}ActualStateV2_4.xml";
                        case "5":
                            return $"{DataFolder}ActualStateV2_5.xml";
                        case "6":
                            return $"{DataFolder}ActualStateV2_6.xml";
                        case "7":
                            return $"{DataFolder}ActualStateV2_7.xml";
                        case "8":
                            return $"{DataFolder}ActualStateV2_8.xml";
                        case "9":
                            return $"{DataFolder}ActualStateV2_9.xml";
                        case "0":
                            return $"{DataFolder}ActualStateV2_0.xml";
                        default:
                            return $"{DataFolder}ActualStateV2_def.xml";

                    }
                }
            }
            return $"{DataFolder}ActualStateV2NoRecords.xml";
        }

        private static void AugmentGetActualStateV2(ActualStateResponseV2 r)
        {
                r.DataValidForDate = DateTime.Now;
                r.DataValidForDateSpecified = true;
                //r.Deed.UIC = r.UIC;
                //if (!string.IsNullOrEmpty(argument.FieldList) && !string.IsNullOrWhiteSpace(argument.FieldList))
                //{
                //    var list = argument.FieldList.Split(',').Where(t => !string.IsNullOrEmpty(t) && !string.IsNullOrWhiteSpace(t));
                //    if (list.Count() > 0)
                //    {
                //        List<ActualStateV2.Record> r = new List<ActualStateV2.Record>();
                //        foreach (var l in list)
                //        {
                //            r.AddRange(result.Deed.Records.Where(f => f.FieldIdent.Contains(l.Trim())));
                //        }
                //        result.Deed.Records = r;
                //    }
                //}
           }

        private static string ResolveGetActualStateFileName(ActualStateRequestType r)
        {
            if (r?.UIC != null)
            {
                string fileName = $"{DataFolder}ActualState_{r?.UIC}.xml";
                if (File.Exists(AppDomain.CurrentDomain.BaseDirectory + fileName))
                {
                    return fileName;
                }
                else
                {
                    switch (r?.UIC?.Substring(r.UIC.Length - 1))
                    {
                        case "1":
                            return $"{DataFolder}ActualState_ET.xml";
                        case "2":
                            return $"{DataFolder}ActualState_SD.xml";
                        case "3":
                            return $"{DataFolder}ActualState_KD.xml";
                        case "4":
                            return $"{DataFolder}ActualState_OOD.xml";
                        case "5":
                            return $"{DataFolder}ActualState_OOD.xml";
                        case "6":
                            return $"{DataFolder}ActualState_DP.xml";
                        case "7":
                            return $"{DataFolder}ActualState_KOOP.xml";
                        default:
                            return $"{DataFolder}ActualState_EAD.xml";
                    }
                }
            }
            else
            {
                return $"{DataFolder}ActualStateNoRecords.xml";
            }
        }

        private static void AugmentGetActualState(ActualStateResponseType r)
        {
            if (r != null)
            {
                r.DataValidForDate = DateTime.Now;
                r.DataValidForDateSpecified = true;
            }
        }



        [Export(typeof(IAdapterService))]
        [ExportSimpleName(typeof(TRAdapterMock), typeof(IAdapterService))]
        [ExportFullName(typeof(TRAdapterMock), typeof(IAdapterService))]
        public static ITRAdapter MockExport
        {
            get
            {
                return new TRAdapterMock().Create();
            }
        }
    }
}
