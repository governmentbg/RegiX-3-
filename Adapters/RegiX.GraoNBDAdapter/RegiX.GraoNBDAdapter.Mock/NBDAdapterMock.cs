using RegiX.Adapters.Mocks;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.IO;
using System.Text;
using TechnoLogica.RegiX.Adapters.Common.ExportExtension;
using TechnoLogica.RegiX.Common;
using TechnoLogica.RegiX.GraoNBDAdapter;
using TechnoLogica.RegiX.GraoNBDAdapter.AdapterService;

namespace RegiX.GraoNBDAdapter.Mock
{
    public class NBDAdapterMock : BaseAdapterServiceProxy<INBDAdapter>
    {
        static NBDAdapterMock()
        {
            RegisterResolver<PersonDataRequestType, PersonDataResponseType>(
                (i, r, a, o) => i.PersonDataSearch(r, a, o),
                fileNameResolver: 
                    (r) => ResolvePersonDataSearchFileName(r)
            );

            RegisterResolver<RelationsRequestType, RelationsResponseType>(
                (i, r, a, o) => i.RelationsSearch(r, a, o),
                fileNameResolver:
                    (r) => ResolveRelationsSearchFileName(r)
            );

            RegisterResolver<ValidPersonRequestType, ValidPersonResponseType>(
                (i, r, a, o) => i.ValidPersonSearch(r, a, o),
                fileNameResolver:
                    (r) => ResolveValidPersonSearchFileName(r)
            );
        }

        static string ResolvePersonDataSearchFileName(PersonDataRequestType argument)
        {
            if (argument != null && !string.IsNullOrEmpty(argument.EGN) && argument.EGN.Length > 3)
            {
                string fileName = $"{DataFolder}PersonDataResponse{argument.EGN}.xml";
                if (File.Exists(AppDomain.CurrentDomain.BaseDirectory + fileName))
                {
                    return fileName;
                }
                else
                {
                    switch (argument.EGN.Substring((argument.EGN.Length - 1), 1))
                    {
                        case "0":
                        case "1": return $"{DataFolder}PersonDataResponse.xml";
                        case "2":
                        case "3": return $"{DataFolder}PersonDataResponse1.xml";
                        case "4":
                        case "5": return $"{DataFolder}PersonDataResponse2.xml";
                        case "6":
                        case "7": return $"{DataFolder}PersonDataResponse3.xml";
                    };
                }
            }
            return $"{DataFolder}PersonDataResponse4.xml";
        }

        static string ResolveRelationsSearchFileName(RelationsRequestType argument)
        {
            if (argument != null && !String.IsNullOrEmpty(argument.EGN) && argument.EGN.Length > 3)
            {
                string fileName = $"{DataFolder}RelationsResponse{argument.EGN}.xml";
                if (File.Exists(AppDomain.CurrentDomain.BaseDirectory + fileName))
                {
                    return fileName;
                }
                else
                {
                    switch (argument.EGN.Substring((argument.EGN.Length - 1), 1))
                    {
                        case "0":
                        case "1": return $"{DataFolder}RelationsResponse.xml";
                        case "2":
                        case "3": return $"{DataFolder}RelationsResponse1.xml";
                        case "4":
                        case "5": return $"{DataFolder}RelationsResponse2.xml";
                        case "6":
                        case "7": return $"{DataFolder}RelationsResponse3.xml";
                    };
                }
            }
            return $"{DataFolder}RelationsResponse4.xml";
        }

        static string ResolveValidPersonSearchFileName(ValidPersonRequestType argument)
        {
            if (argument != null && !String.IsNullOrEmpty(argument.EGN) && argument.EGN.Length > 3)
            {
                string fileName = $"{DataFolder}ValidPersonResponse{argument.EGN}.xml";
                if (File.Exists(AppDomain.CurrentDomain.BaseDirectory + fileName))
                {
                    return fileName;
                }
                else
                {
                    switch (argument.EGN.Substring((argument.EGN.Length - 1), 1))
                    {
                        case "0":
                        case "1": return $"{DataFolder}ValidPersonResponse.xml";
                        case "2":
                        case "3": return $"{DataFolder}ValidPersonResponse1.xml";
                        case "4":
                        case "5": return $"{DataFolder}ValidPersonResponse2.xml";
                        case "6":
                        case "7": return $"{DataFolder}ValidPersonResponse3.xml";
                        case "8":
                        case "9": return $"{DataFolder}ValidPersonResponse4.xml";
                            //default:
                            //result = new ValidPersonResponseType(); break;
                    };
                }
            }
            return $"{DataFolder}ValidPersonResponse4.xml";
        }

        [Export(typeof(IAdapterService))]
        [ExportSimpleName(typeof(NBDAdapterMock), typeof(IAdapterService))]
        [ExportFullName(typeof(NBDAdapterMock), typeof(IAdapterService))]
        public static INBDAdapter MockExport
        {
            get
            {
                return new NBDAdapterMock().Create();
            }
        }
    }
}
