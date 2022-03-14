using RegiX.Adapters.Mocks;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Text;
using TechnoLogica.RegiX.Adapters.Common.ExportExtension;
using TechnoLogica.RegiX.Common;
using TechnoLogica.RegiX.KzldDeniedAdministratorsAdapter;
using TechnoLogica.RegiX.KzldDeniedAdministratorsAdapter.AdapterService;

namespace TechnoLogica.RegiX.KzldDeniedAdministratorsAdapter.Mock
{    
    public class KzldDeniedAdministratorsAdapterMock : BaseAdapterServiceProxy<IKzldDeniedAdministratorsAdapter>
    {
        static KzldDeniedAdministratorsAdapterMock()
        {
            RegisterResolver<DeniedEntryAdministratorRequestType, DeniedEntryAdministratorResponse>(
                (i, r, a, o) => i.GetRegisteredAdministratorByID(r, a, o),
                (r) => ResolveGetRegisteredAdministratorByIDFileName(r)
            );
        }

        private static string ResolveGetRegisteredAdministratorByIDFileName(DeniedEntryAdministratorRequestType r)
        {
            if (r?.PersonalDataControllerID != null)
            {
                return $"{DataFolder}GetRegisteredAdministratorByIDTest.xml";
            }
            else
            {
                return $"{DataFolder}GetRegisteredAdministratorByIDNullTest.xml";
            }
        }

        [Export(typeof(IAdapterService))]
        [ExportSimpleName(typeof(KzldDeniedAdministratorsAdapterMock), typeof(IAdapterService))]
        [ExportFullName(typeof(KzldDeniedAdministratorsAdapterMock), typeof(IAdapterService))]
        public static IKzldDeniedAdministratorsAdapter MockExport
        {
            get
            {
                return new KzldDeniedAdministratorsAdapterMock().Create();
            }
        }
    }
}

