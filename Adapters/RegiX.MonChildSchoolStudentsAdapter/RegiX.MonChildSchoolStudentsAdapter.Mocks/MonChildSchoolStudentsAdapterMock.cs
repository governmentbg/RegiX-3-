using RegiX.Adapters.Mocks;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Text;
using TechnoLogica.RegiX.Adapters.Common.ExportExtension;
using TechnoLogica.RegiX.Common;
using TechnoLogica.RegiX.MonChildSchoolStudentsAdapter;
using TechnoLogica.RegiX.MonChildSchoolStudentsAdapter.AdapterService;

namespace TechnoLogica.RegiX.MonChildSchoolStudentsAdapter.Mock
{    
    public class MonChildSchoolStudentsAdapterMock : BaseAdapterServiceProxy<IMonChildSchoolStudentsAdapter>
    {
        [Export(typeof(IAdapterService))]
        [ExportSimpleName(typeof(MonChildSchoolStudentsAdapterMock), typeof(IAdapterService))]
        [ExportFullName(typeof(MonChildSchoolStudentsAdapterMock), typeof(IAdapterService))]
        public static IMonChildSchoolStudentsAdapter MockExport
        {
            get
            {
                return new MonChildSchoolStudentsAdapterMock().Create();
            }
        }
    }
}

