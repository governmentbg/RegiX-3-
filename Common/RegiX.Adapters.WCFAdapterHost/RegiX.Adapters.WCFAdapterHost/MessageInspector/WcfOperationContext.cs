using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Web;

namespace TechnoLogica.RegiX.Adapters.WCFAdapterHost.MessageInspector
{
    public class WcfOperationContext : IExtension<OperationContext>
    {
        private readonly IDictionary<string, object> items;

        private WcfOperationContext()
        {
            items = new Dictionary<string, object>();
        }

        public IDictionary<string, object> Items
        {
            get { return items; }
        }

        public static WcfOperationContext Current
        {
            get
            {
                WcfOperationContext context = OperationContext.Current.Extensions.Find<WcfOperationContext>();
                if (context == null)
                {
                    context = new WcfOperationContext();
                    OperationContext.Current.Extensions.Add(context);
                }
                return context;
            }
        }

        public void Attach(OperationContext owner) { }
        public void Detach(OperationContext owner) { }
    }
}