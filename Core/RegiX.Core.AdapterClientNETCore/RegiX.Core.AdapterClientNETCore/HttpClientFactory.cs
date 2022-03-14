using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechnoLogica.RegiX.Common;
using TechnoLogica.RegiX.Core.Data.Interfaces;
using TechnoLogica.RegiX.Core.Interfaces;

namespace TechnoLogica.RegiX.Core.AdapterClientNETCore
{
    /// <summary>
    /// Спомагателен клас изграждащ factory за HTTP клиенти към конкретен IAdapterService
    /// </summary>
    /// <typeparam name="I">Тип на IAdapterService</typeparam>
    [Export(typeof(IRegisterChannelFacotry<>))]
    public class HttpClientFactory<I> : IRegisterChannelFacotry<I>
        where I : IAdapterServiceNETCore
    {
        /// <summary>
        /// CompositionContainer
        /// </summary>
        [Import(typeof(CompositionContainer))]
        public CompositionContainer CompositionContainer { get; set; }

        public I CreateChannel()
        {
            return HttpClientProxy<I>.Create(CompositionContainer);
        }
    }
}
