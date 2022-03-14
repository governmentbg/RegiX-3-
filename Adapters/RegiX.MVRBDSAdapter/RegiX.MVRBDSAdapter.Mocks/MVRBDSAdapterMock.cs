using RegiX.Adapters.Mocks;
using System.ComponentModel.Composition;
using System.IO;
using System;
using TechnoLogica.RegiX.Adapters.Common.ExportExtension;
using TechnoLogica.RegiX.Common;
using TechnoLogica.RegiX.MVRBDSAdapter.AdapterService;

namespace TechnoLogica.RegiX.MVRBDSAdapter.Mock
{
    public class MVRBDSAdapterMock : BaseAdapterServiceProxy<IMVRBDSAdapter>
    {
        static MVRBDSAdapterMock()
        {
            RegisterResolver<PersonalIdentityInfoRequestType, PersonalIdentityInfoResponseType>(
                (i, r, a, o) => i.GetPersonalIdentity(r, a, o),
                fileNameResolver:
                    (r) => ResolveGetPersonalIdentityFileName(r)
            );

            RegisterResolver<MVRBDSAdapterV2.PersonalIdentityInfoRequestType, MVRBDSAdapterV2.PersonalIdentityInfoResponseType>(
                (i, r, a, o) => i.GetPersonalIdentityV2(r, a, o),
                fileNameResolver:
                    (r) => ResolveGetPersonalIdentityV2FileName(r)
            );

            RegisterResolver<MVRBDSAdapterV3.PersonalIdentityInfoRequestType, MVRBDSAdapterV3.PersonalIdentityInfoResponseType>(
                (i, r, a, o) => i.GetPersonalIdentityV3(r, a, o),
                fileNameResolver:
                    (r) => ResolveGetPersonalIdentityV3FileName(r)
            );
        }


        static string ResolveGetPersonalIdentityFileName(PersonalIdentityInfoRequestType argument)
        {
            if (argument != null && !string.IsNullOrEmpty(argument.EGN))
            {
                string fileName = $"{DataFolder}GetPersonalIdentity_{argument.EGN}_{argument.IdentityDocumentNumber}.xml";
                if (File.Exists(AppDomain.CurrentDomain.BaseDirectory + fileName))
                {
                    return fileName;
                }
            }
            return $"{DataFolder}IMVRBDSAdapter.GetPersonalIdentity.response.xml";
        }

        static string ResolveGetPersonalIdentityV2FileName(MVRBDSAdapterV2.PersonalIdentityInfoRequestType argument)
        {
            if (argument != null && !string.IsNullOrEmpty(argument.EGN))
            {
                string fileName = $"{DataFolder}GetPersonalIdentityV2_{argument.EGN}_{argument.IdentityDocumentNumber}.xml";
                if (File.Exists(AppDomain.CurrentDomain.BaseDirectory + fileName))
                {
                    return fileName;
                }
            }
            return $"{DataFolder}IMVRBDSAdapter.GetPersonalIdentityV2.response.xml";
        }

        static string ResolveGetPersonalIdentityV3FileName(MVRBDSAdapterV3.PersonalIdentityInfoRequestType argument)
        {
            if (argument != null && !string.IsNullOrEmpty(argument.EGN))
            {
                string fileName = $"{DataFolder}GetPersonalIdentityV3_{argument.EGN}_{argument.IdentityDocumentNumber}.xml";
                if (File.Exists(AppDomain.CurrentDomain.BaseDirectory + fileName))
                {
                    return fileName;
                }
            }
            return $"{DataFolder}IMVRBDSAdapter.GetPersonalIdentityV3.response.xml";
        }

        [Export(typeof(IAdapterService))]
        [ExportSimpleName(typeof(MVRBDSAdapterMock), typeof(IAdapterService))]
        [ExportFullName(typeof(MVRBDSAdapterMock), typeof(IAdapterService))]
        public static IMVRBDSAdapter MockExport
        {
            get
            {
                return new MVRBDSAdapterMock().Create();
            }
        }
    }
}

