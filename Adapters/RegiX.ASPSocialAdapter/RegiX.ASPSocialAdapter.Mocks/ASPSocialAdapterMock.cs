using RegiX.Adapters.Mocks;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.IO;
using System.Text;
using TechnoLogica.RegiX.Adapters.Common.ExportExtension;
using TechnoLogica.RegiX.ASPSocialAdapter.AdapterService;
using TechnoLogica.RegiX.Common;

namespace TechnoLogica.RegiX.ASPSocialAdapter.Mocks
{
    public class ASPSocialAdapterMock : BaseAdapterServiceProxy<IASPSocialAdapter>
    {
        static string dataFolder = $"{Path.DirectorySeparatorChar}XMLData{Path.DirectorySeparatorChar}{typeof(ASPSocialAdapterMock).Assembly.GetName().Name}{Path.DirectorySeparatorChar}";

        static ASPSocialAdapterMock()
        {
            RegisterResolver<GetMonthlySocialBenefitsRequest, GetMonthlySocialBenefitsResponseType>(
                (i, r, a, o) => i.GetMonthlySocialBenefits(r, a, o),
                fileNameResolver:
                    (r) => ResolveMonthlySocialBenefits(r),
                augmentActionResolver:
                    (r) => AugmentMonthlySocialBenefits(r)
            );

            RegisterResolver<GetBenefitsForHeatingRequest, GetBenefitsForHeatingResponseType>(
                (i, r, a, o) => i.GetBenefitsForHeating(r, a, o),
                fileNameResolver:
                    (r) => ResolveBenefitsForHeating(r),
                augmentActionResolver:
                    (r) => AugmentBenefitsForHeating(r)
            );

            RegisterResolver<GetSocialServicesDecisionsRequest, GetSocialServicesDecisionsResponseType>(
                (i, r, a, o) => i.GetSocialServicesDecisions(r, a, o),
                fileNameResolver:
                    (r) => ResolveSocialServicesDecisions(r),
                augmentActionResolver:
                    (r) => AugmentSocialServicesDecisions(r)
            );

            RegisterResolver<PeopleWithDisabilitiesRequest, PeopleWithDisabilitiesResponseType>(
                (i, r, a, o) => i.GetPersonWithDisabilitiesSocialBenefitsList(r, a, o),
                fileNameResolver:
                    (r) => ResolvePersonWithDisabilitiesSocialBenefitsList(r)
            );

        }

        private static string ResolveMonthlySocialBenefits(GetMonthlySocialBenefitsRequest r)
        {
            string val = r?.PersonData?.Identifier;
            if (val != null && (val.EndsWith("0") || val.EndsWith("1") || val.EndsWith("2") || val.EndsWith("3") || val.EndsWith("4")))
            {
                return $"{dataFolder}GetMonthlySocialBenefitsResponse.xml";
            }
            else
            {
                return $"{dataFolder}GetMonthlySocialBenefitsResponseEmpty.xml";
            }
        }

        private static void AugmentMonthlySocialBenefits(GetMonthlySocialBenefitsResponseType r)
        {
            r.CurrentTime = DateTime.Now;
        }

        private static string ResolveBenefitsForHeating(GetBenefitsForHeatingRequest r)
        {
            string val = r?.PersonData?.Identifier;
            if (val != null && (val.EndsWith("0") || val.EndsWith("1") || val.EndsWith("2") || val.EndsWith("3") || val.EndsWith("4")))
            {
                return $"{dataFolder}GetBenefitsForHeatingResponse.xml";
            }
            else
            {
                return $"{dataFolder}GetBenefitsForHeatingResponseEmpty.xml";
            }
        }

        private static void AugmentBenefitsForHeating(GetBenefitsForHeatingResponseType r)
        {
            r.CurrentTime = DateTime.Now;
        }

        private static string ResolveSocialServicesDecisions(GetSocialServicesDecisionsRequest r)
        {
            string val = r?.PersonData?.Identifier;
            if (val != null && (val.EndsWith("0") || val.EndsWith("1") || val.EndsWith("2") || val.EndsWith("3") || val.EndsWith("4")))
            {
                return $"{dataFolder}GetSocialServicesDecisionsResponse.xml";
            }
            else
            {
                return $"{dataFolder}GetSocialServicesDecisionsResponseEmpty.xml";
            }
        }

        private static void AugmentSocialServicesDecisions(GetSocialServicesDecisionsResponseType r)
        {
            r.CurrentTime = DateTime.Now;
        }

        private static string ResolvePersonWithDisabilitiesSocialBenefitsList(PeopleWithDisabilitiesRequest r)
        {
            return $"{dataFolder}GetPersonWithDisabilitiesSocialBenefitsListResponse.xml";
        }

        [Export(typeof(IAdapterService))]
        [ExportSimpleName(typeof(ASPSocialAdapterMock), typeof(IAdapterService))]
        [ExportFullName(typeof(ASPSocialAdapterMock), typeof(IAdapterService))]
        public static IASPSocialAdapter MockExport
        {
            get
            {
                return new ASPSocialAdapterMock().Create();
            }
        }
    }
}
