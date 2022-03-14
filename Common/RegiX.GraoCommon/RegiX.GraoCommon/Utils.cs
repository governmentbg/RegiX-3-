using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using TechnoLogica.RegiX.Common.DataContracts;

namespace TechnoLogica.RegiX.GraoCommon
{
    public static class Utils
    {
        /// <summary>
        /// Конверсия от число към пол
        /// </summary>
        public static Func<object, string> ToGenderNameType = (o) =>
        {
            if (o != null && o != System.DBNull.Value)
            {
                string result;
                switch (o.ToString())
                {
                    case "1":
                        result = "Мъж";
                        break;
                    case "2":
                        result = "Жена";
                        break;
                    default:
                        return null;
                }
                return result;
            }
            else
            {
                return string.Empty;
            }
        };

        public static Func<object, string> ToMaritalStatusText = (o) =>
        {
            if (o != null && o != System.DBNull.Value)
            {
                string result;
                switch (o.ToString())
                {
                    case "1":
                        result = "Heжeнeн";
                        break;
                    case "2":
                        result = "Жeнeн";
                        break;
                    case "3":
                        result = "Bдoвeц";
                        break;
                    case "4":
                        result = "Paзвeдeн";
                        break;
                    case "9":
                        result = "Heпoкaзaнo";
                        break;
                    case "10":
                        result = "Нeoмъжeнa";
                        break;
                    case "20":
                        result = "Омъжeнa";
                        break;
                    case "30":
                        result = "Bдoвицa";
                        break;
                    case "40":
                        result = "Paзвeдeнa";
                        break;
                    case "90":
                        result = "Heпoкaзaнo";
                        break;
                    default:
                        result = "Heпoкaзaнo";
                        break;
                }
                return result;
            }
            else
            {
                return string.Empty;
            }
        };

        public static Func<object, string> ToSettlementTypeName = (o) =>
        {
            if (o != null && o != System.DBNull.Value)
            {
                string result;
                switch (o.ToString())
                {
                    case "1":
                        result = "град";
                        break;
                    case "3":
                        result = "село";
                        break;
                    case "0":
                        result = "район, квартал, градски общини";
                        break;
                    default:
                        result = null;
                        break;
                }
                return result;
            }
            else
            {
                return string.Empty;
            }
        };

        /// <summary>
        /// Конверсия от ЕГН към ЕГН с век
        /// </summary>
        public static string EGNtoVEGN(string egn)
        {
            if (!String.IsNullOrEmpty(egn) && egn.Length > 3)
            {
                string result = "1";
                switch (egn.Substring(2, 1))
                {
                    case "0":
                    case "1": result = "1"; break;
                    case "2":
                    case "3": result = "0"; break;
                    case "4":
                    case "5": result = "2"; break;
                    default: result = "1"; break;
                }
                return result + egn.ToString();
            }
            else
            {
                return egn;
            }
        }

        public static object GetLogMessageForSuccessOperation(string egn, AdapterAdditionalParameters aditionalParameters, string otherParamsFromRequest = "")
        {

            string service, uri, task, resp, employeeName, employeeEGN;
            //За БАБХ се прави допълнително парсване:
            // stringtomatch = "Услуга: \"Регистрация на зоопаркове, аквариуми, терариуми, циркове, ферми, волиери и вивариуми\"; УРИ: \"101-26806-14.09.2016\"; Задача: \"Задача за контрол на етап \"Проверка на идентификацията на получателя на услугата (автоматичен)\"\"; Отговорни служители: Стефка Динкова Возница ЕГН: 7003141896";
            // stringtomatch2 = "Услуга: \"Регистрация на обекти за производство и търговия с храни\"; УРИ: \"101-26828-14.09.2016\"; Задача: \"Задача за контрол на етап \"Проверка на идентификацията на получателя на услугата (автоматичен)\"\"; Отговорни служители: Цветелина Ангелова Василева ЕГН: 6810291752";
            if (aditionalParameters != null &&
                aditionalParameters.OrganizationEIK == "2.16.100.1.1.17.1.1" &&
                aditionalParameters.CallContext != null &&
                !string.IsNullOrEmpty(aditionalParameters.CallContext.Remark) &&
                ParseRemark(aditionalParameters.CallContext.Remark, out service, out uri, out task, out resp, out employeeName, out employeeEGN))
            {
                return (new 
                {
                    UserNames = employeeName,
                    UserIp = aditionalParameters == null ? string.Empty : aditionalParameters.ClientIPAddress,
                    UserEgn = employeeEGN,
                    Service = string.Format("{0} {1}", uri, service),
                    Method = (new StackTrace()).GetFrame(1).GetMethod().Name,
                    TargetEgn = egn,
                    OtherParameters = otherParamsFromRequest,
                    CallId = aditionalParameters == null ? string.Empty : aditionalParameters.ApiServiceCallId.ToString(),
                    OrganizationUnit = aditionalParameters.OrganizationUnit
                });
            }
            //за останалите е в CallContext-а
            else
            {
                return (new 
                {
                    UserNames = aditionalParameters == null || aditionalParameters.CallContext == null ? string.Empty :
                                    !string.IsNullOrEmpty(aditionalParameters.CallContext.EmployeeNames) ? aditionalParameters.CallContext.EmployeeNames :
                                         !string.IsNullOrEmpty(aditionalParameters.CallContext.EmployeeIdentifier) ? aditionalParameters.CallContext.EmployeeIdentifier :
                                            aditionalParameters.CallContext.EmployeeAditionalIdentifier
                               ,
                    UserIp = aditionalParameters == null ? string.Empty : aditionalParameters.ClientIPAddress,
                    UserEgn = aditionalParameters != null && !string.IsNullOrEmpty(aditionalParameters.EmployeeEGN) ? aditionalParameters.EmployeeEGN :
                                    aditionalParameters == null || aditionalParameters.CallContext == null ? string.Empty :
                                     !string.IsNullOrEmpty(aditionalParameters.CallContext.EmployeeIdentifier) ? aditionalParameters.CallContext.EmployeeIdentifier :
                                            aditionalParameters.CallContext.EmployeeAditionalIdentifier,
                    Service = aditionalParameters == null || aditionalParameters.CallContext == null ? string.Empty :
                                    string.Format("{0} {1}", aditionalParameters.CallContext.ServiceURI, aditionalParameters.CallContext.ServiceType),
                    Method = (new StackTrace()).GetFrame(1).GetMethod().Name,
                    TargetEgn = egn,
                    OtherParameters = otherParamsFromRequest,
                    CallId = aditionalParameters == null ? string.Empty : aditionalParameters.ApiServiceCallId.ToString(),
                    OrganizationUnit = aditionalParameters.OrganizationUnit

                });
            }
        }

        public static bool ParseRemark(string test,
               out string service,
               out string uri,
               out string task,
               out string resp,
               out string employeeName,
               out string employeeEGN
            )
        {
            service = string.Empty;
            uri = string.Empty;
            task = string.Empty;
            resp = string.Empty;
            employeeName = string.Empty;
            employeeEGN = string.Empty;

            var pattern = "Услуга: \"([\\p{Ll}\\p{Lt}0-9\\,\\s\\-\\.\\:\"\\(\\)]+)\"; УРИ: \"([A-Za-z0-9\\-\\.]+)\"; Задача: \"([\\p{Ll}\\p{Lt}0-9\\,\\s\\-\\.\\:\"\\(\\)]+)\"; Отговорни служители: ([\\p{Ll}\\p{Lt}0-9\\,\\s\\-\\.\\:\"\\(\\)]*)";
            var result = default(string);
            var match = Regex.Match(test, pattern, RegexOptions.IgnoreCase);
            if (match.Success)
            {
                service = match.Groups.Count > 1 ? match.Groups[1].Value : string.Empty;
                uri = match.Groups.Count > 2 ? match.Groups[2].Value : string.Empty;
                task = match.Groups.Count > 3 ? match.Groups[3].Value : string.Empty;
                resp = match.Groups.Count > 4 ? match.Groups[4].Value : string.Empty;

                if (!string.IsNullOrEmpty(resp))
                {
                    var patternEgn = "([\\p{Ll}\\p{Lt}\\-\\s]+) ЕГН: ([0-9]+)";
                    var matchEgn = Regex.Match(resp, patternEgn, RegexOptions.IgnoreCase);
                    if (matchEgn.Success)
                    {
                        employeeName = matchEgn.Groups.Count > 1 ? matchEgn.Groups[1].Value : string.Empty;
                        employeeEGN = matchEgn.Groups.Count > 2 ? matchEgn.Groups[2].Value : string.Empty;
                    }
                }
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
