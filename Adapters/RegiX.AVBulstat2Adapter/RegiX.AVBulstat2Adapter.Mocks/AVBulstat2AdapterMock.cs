using RegiX.Adapters.Mocks;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechnoLogica.RegiX.Adapters.Common.ExportExtension;
using TechnoLogica.RegiX.AVBulstat2Adapter.AdapterService;
using TechnoLogica.RegiX.AVBulstat2Adapter.AVBulstat2ServiceReference;
using TechnoLogica.RegiX.Common;

namespace TechnoLogica.RegiX.AVBulstat2Adapter.Mocks
{
    public class AVBulstat2AdapterMock : BaseAdapterServiceProxy<IAVBulstat2Adapter>
    {

        static AVBulstat2AdapterMock()
        {
            RegisterResolver<XMLSchemas.GetActualUICInfoRequestType, XMLSchemas.GetActualUICInfoResponseType>(
                (i, r, a, o) => i.GetActualUICInfo(r, a, o),
                fileNameResolver:
                    (r) => ResolveGetActualUICInfoFileName(r)
            );

            RegisterResolver<GetStateOfPlayRequest, StateOfPlay>(
                (i, r, a, o) => i.GetStateOfPlay(r, a, o),
                fileNameResolver:
                    (r) => ResolveGetStateOfPlayFileName(r)
            );
        }

        static string ResolveGetActualUICInfoFileName(XMLSchemas.GetActualUICInfoRequestType argument)
        {
            if (argument != null && !string.IsNullOrEmpty(argument.UIC))
            {
                string fileName = $"{DataFolder}GetActualUICInfo{argument.UIC}.xml";
                if (File.Exists(AppDomain.CurrentDomain.BaseDirectory + fileName))
                {
                    return fileName;
                }
            }
            return $"{DataFolder}IAVBulstat2Adapter.GetActualUICInfo.response.xml";
        }

        static string ResolveGetStateOfPlayFileName(GetStateOfPlayRequest argument)
        {
            if (argument != null && !string.IsNullOrEmpty(argument.UIC))
            {
                string fileName = $"{DataFolder}GetStateOfPlay{argument.UIC}.xml";
                if (File.Exists(AppDomain.CurrentDomain.BaseDirectory + fileName))
                {
                    return fileName;
                }
            }
            return $"{DataFolder}IAVBulstat2Adapter.GetStateOfPlay.response.xml";
        }

        [Export(typeof(IAdapterService))]
        [ExportSimpleName(typeof(AVBulstat2AdapterMock), typeof(IAdapterService))]
        [ExportFullName(typeof(AVBulstat2AdapterMock), typeof(IAdapterService))]
        public static IAVBulstat2Adapter MockExport
        {
            get
            {
                return new AVBulstat2AdapterMock().Create();
            }
        }
    }
}
