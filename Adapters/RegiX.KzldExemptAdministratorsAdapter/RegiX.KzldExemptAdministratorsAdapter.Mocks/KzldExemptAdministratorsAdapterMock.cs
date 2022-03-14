using RegiX.Adapters.Mocks;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Text;
using TechnoLogica.RegiX.Adapters.Common.ExportExtension;
using TechnoLogica.RegiX.Common;
using TechnoLogica.RegiX.KzldExemptAdministratorsAdapter;
using TechnoLogica.RegiX.KzldExemptAdministratorsAdapter.AdapterService;

namespace TechnoLogica.RegiX.KzldExemptAdministratorsAdapter.Mock
{    
    public class KzldExemptAdministratorsAdapterMock : BaseAdapterServiceProxy<IKzldExemptAdministratorsAdapter>
    {
        static KzldExemptAdministratorsAdapterMock()
        {
            RegisterResolver<ExemptRegistrationRequestType, ExemptRegistrationAdministratorResponse>(
                (i, r, a, o) => i.GetExemptRegistrationAdministrator(r, a, o),
                (r) => ResolveGetExemptRegistrationAdministratorFileName(r));
        }

        private static string ResolveGetExemptRegistrationAdministratorFileName(ExemptRegistrationRequestType r)
        {
            if (r?.PersonalDataControllerID != null)
            {
                return $"{DataFolder}GetExemptRegistrationAdministratorTest.xml";
            }
            else
            {
                return $"{DataFolder}GetExemptRegistrationAdministratorNullTest.xml";
            }
        }

        [Export(typeof(IAdapterService))]
        [ExportSimpleName(typeof(KzldExemptAdministratorsAdapterMock), typeof(IAdapterService))]
        [ExportFullName(typeof(KzldExemptAdministratorsAdapterMock), typeof(IAdapterService))]
        public static IKzldExemptAdministratorsAdapter MockExport
        {
            get
            {
                return new KzldExemptAdministratorsAdapterMock().Create();
            }
        }
    }
}

