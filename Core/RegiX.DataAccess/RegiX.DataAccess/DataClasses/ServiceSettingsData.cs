using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TechnoLogica.RegiX.DataAccess.DataClasses
{
    public static class ServiceSettingsData
    {
        public static REGISTER_ADAPTERS GetServiceAPISettingsByName(RegiXContext context, string apiName)
        {
            REGISTER_ADAPTERS result = null;
            using (context)
            {
                result = context.REGISTER_ADAPTERS.Where(b => b.NAME == apiName).First();
            }
            return result;
        }
    }
}
