using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.ComponentModel.Composition;
using TechnoLogica.RegiX.Core.Data.Interfaces;

namespace TechnoLogica.RegiX.Core.AdapterClientNETCore
{
    [Export(typeof(HttpClient<>))]
    [PartCreationPolicy(CreationPolicy.Shared)]
    public class HttpClient<I> : HttpClient
    {
        /// <summary>
        /// Инициализация на контракта на адаптера извлечено от I
        /// </summary>
        private Lazy<string> _adapterContractName = new Lazy<string>(() => typeof(I).FullName);

        [ImportingConstructor]
        public HttpClient([Import(typeof(IRegiXData))] IRegiXData regiXData) : base()
        {
            IRegisterBindingInfo bindingInfo = regiXData.GetBindingInfo(_adapterContractName.Value);
            BaseAddress = new Uri(bindingInfo.AdapterURL);
            DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/xml"));
        }
    }
}
