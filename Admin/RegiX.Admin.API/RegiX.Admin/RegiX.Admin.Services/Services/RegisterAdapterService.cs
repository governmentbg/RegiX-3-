using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TechnoLogica.API.DataContracts;
using TechnoLogica.API.Repositories.Contracts;
using TechnoLogica.API.Services;
using TechnoLogica.RegiX.Admin.API.DataContracts.DTO.RegisterAdapter;
using TechnoLogica.RegiX.Admin.Infrastructure.Models;
using TechnoLogica.RegiX.Admin.Repositories.Contracts;
using TechnoLogica.RegiX.Admin.Services.Contracts;
using ZabbixAPICore;
using System.Linq;
using Microsoft.AspNet.OData.Query;
using TechnoLogica.RegiX.Admin.Services.QueryValidators;

namespace TechnoLogica.RegiX.Admin.Services.Services
{
    /// <summary>
    ///     Defines the <see cref="RegisterAdapterService" />
    /// </summary>
    public class RegisterAdapterService :
        ABaseService<RegisterAdapterInDto, RegisterAdapterOutDto, RegisterAdapters, decimal, RegiXContext>,
        IRegisterAdapterService
    {
        public RegisterAdapterService(IRegisterAdaptersRepository aBaseRepository)
            : base(aBaseRepository, new RegisterAdapterQueryValidator())
        {
        }
          
        public override List<RegisterAdapterOutDto> SelectAll(ODataQueryOptions<RegisterAdapters> aOptions)
        {
            var v = base.SelectAll(aOptions);
            var zabbixData = GetHostStatus();
            foreach (var adapter in v)
            {
                adapter.HostAvailability = zabbixData.Where(d => d.Key == adapter.Contract).SingleOrDefault().Value;
            }
            return v;
        }

        public override CustomPageResult<RegisterAdapterOutDto> SelectAllWithPagination(ODataQueryOptions<RegisterAdapters> aOptions)
        {
            var v =  base.SelectAllWithPagination(aOptions);
            var zabbixData = GetHostStatus();
            foreach( var adapter in v.Data)
            {
                adapter.HostAvailability = zabbixData.Where(d => d.Key == adapter.Contract).SingleOrDefault().Value;
            }
            return v;
        }

        static IEnumerable<KeyValuePair<string, bool>> GetHostStatus()
        {
            try
            {
                Zabbix zabbix = new Zabbix("Admin", "zabbix", "http://localhost/api_jsonrpc.php");

                zabbix.LoginAsync().Wait();

                Response response =
                    zabbix.GetResponseObjectAsync(
                    "trigger.get",
                    new
                    {
                        output = new string[] { "value" },
                        filter = new
                        {
                            templateid = 16718
                        },
                        selectHosts = new string[] { "host" }
                    }
                ).GetAwaiter().GetResult();
                var res = ((IEnumerable<dynamic>)response.result).Select(
                    r => new KeyValuePair<string, bool>(r.hosts[0].host, r.value == "1")).ToList();
                return res;
            }
            catch(Exception ex)
            {
                return new List<KeyValuePair<string, bool>>();
            }
        }

        protected override void ValidateUpdate(RegisterAdapters repoObj, RegisterAdapterInDto aInDto)
        {
            if (repoObj.RegisterId != aInDto.RegisterId) throw new Exception("Cannot update registerId");
        }

        /// <summary>
        ///     The PopulateDtoToEntityFieldsMapping
        /// </summary>
        protected override void PopulateDtoToEntityFieldsMapping()
        {
            dtoFieldsToEntityFields.Add("register.id", "Register/RegisterId");
            dtoFieldsToEntityFields.Add("register.displayName", "Register/Name");
            dtoFieldsToEntityFields.Add("id", "RegisterAdapterId");
        }

        protected override bool IsChildRecord(decimal aId, List<string> aParentsList)
        {
            return false;
        }
    }
}