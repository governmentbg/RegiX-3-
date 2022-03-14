using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechnoLogica.RegiX.GraoCommon
{
    public class GraoLogObject
    {
        public string UserNames { get; set; }
        public string UserIp { get; set; }
        public string UserEgn { get; set; }
        public string Service { get; set; }
        public string Method { get; set; }
        public string TargetEgn { get; set; }
        public string OtherParameters { get; set; }
        public string CallId { get; set; }
        public string OrganizationUnit { get; set; }

        public override string ToString()
        {
            return string.Format("User = {0}, UserIp = {1}, UserEgn = {2}, Service = {3}, Method = {4}, TargetEgn = {5}, CallId = {6}, OrganizationUnit = {7} ",
                UserNames, UserIp, UserEgn, Service, Method, TargetEgn, OtherParameters, CallId, OrganizationUnit);
        }
    }
}
