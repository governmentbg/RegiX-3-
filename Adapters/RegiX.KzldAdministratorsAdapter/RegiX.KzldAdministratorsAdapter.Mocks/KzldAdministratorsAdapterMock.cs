using RegiX.Adapters.Mocks;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Text;
using TechnoLogica.RegiX.Adapters.Common.ExportExtension;
using TechnoLogica.RegiX.Common;
using TechnoLogica.RegiX.KzldAdministratorsAdapter;
using TechnoLogica.RegiX.KzldAdministratorsAdapter.AdapterService;

namespace TechnoLogica.RegiX.KzldAdministratorsAdapter.Mock
{    
    public class KzldAdministratorsAdapterMock : BaseAdapterServiceProxy<IKzldAdministratorsAdapter>
    {
        static KzldAdministratorsAdapterMock()
        {
            RegisterResolver<RegisteredAdministratorByIDType, RegisteredAdministratorByIDResponse>(
                (i, r, a, o) => i.GetRegisteredAdministratorByID(r, a, o),
                (r) => ResolveGetRegisteredAdministratorByIDFileName(r)
            );
            RegisterResolver<RegisteredAdministratorByNumberType, RegisteredAdministratorByNumberResponse>(
                (i, r, a, o) => i.GetRegisteredAdministratorByNumber(r, a, o),
                (r) => ResolveGetRegisteredAdministratorByNumberFileName(r)
            );
        }

        private static string ResolveGetRegisteredAdministratorByIDFileName(RegisteredAdministratorByIDType r)
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

        private static string ResolveGetRegisteredAdministratorByNumberFileName(RegisteredAdministratorByNumberType r)
        {
            if (r?.PDCRegisterNumber != null)
            {
                return $"{DataFolder}GetRegisteredAdministratorByNumberRESPONSE.xml";
            }
            else
            {
                return $"{DataFolder}GetRegisteredAdministratorByNumberNullTest.xml";
            }
        }

        [Export(typeof(IAdapterService))]
        [ExportSimpleName(typeof(KzldAdministratorsAdapterMock), typeof(IAdapterService))]
        [ExportFullName(typeof(KzldAdministratorsAdapterMock), typeof(IAdapterService))]
        public static IKzldAdministratorsAdapter MockExport
        {
            get
            {
                return new KzldAdministratorsAdapterMock().Create();
            }
        }
    }
}

