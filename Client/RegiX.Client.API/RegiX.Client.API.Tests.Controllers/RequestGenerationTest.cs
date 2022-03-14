using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.IO;
using System.Text;
using System.Linq;
using System.Xml.Serialization;
using TechnoLogica.RegiX.Client.API.Controllers.V1;
using TechnoLogica.RegiX.Common;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace TechnoLogica.RegiX.Client.API.Tests.Controllers
{
    //[TestClass]
    //public class RequestGenerationTest
    //{
    //    public static IBinDirectoryLocator BinDirectoryLocator { get; set; }

    //    static RequestGenerationTest()
    //    {
    //        AggregateCatalog catalog = new AggregateCatalog();
    //        catalog.Catalogs.Add(new AssemblyCatalog(typeof(RequestGenerationTest).Assembly));
    //        CompositionContainer result = new CompositionContainer(catalog, true);
    //        result.ComposeExportedValue(result);
    //        Composition.CompositionContainer = result;
    //        BinDirectoryLocator = Composition.CompositionContainer.GetExportedValue<IBinDirectoryLocator>();
    //    }

    //    public static IEnumerable<Object[]> GetOperationsData()
    //    {
    //        string fullPathName =
    //           BinDirectoryLocator.GetBinDirectory() +
    //           Path.DirectorySeparatorChar +
    //           "XMLMetaData";
    //        DirectoryInfo di = new DirectoryInfo(fullPathName);
    //        var adapters = di.GetDirectories();
    //        Dictionary<string, AdapterOperation> data= new Dictionary<string, AdapterOperation>();
    //        foreach (var adapter in adapters)
    //        {
    //            var files = adapter.GetFiles();
    //            foreach (var file in files)
    //            {
    //                var content = File.ReadAllText(file.FullName);
    //                var serializer = new XmlSerializer(typeof(AdapterOperation));

    //                using (var reader = new StringReader(content))
    //                {
    //                    var requestMetadata = (AdapterOperation)serializer.Deserialize(reader);
    //                    data.Add(requestMetadata.OperationName, requestMetadata);
    //                }
    //            }
    //        }
    //        return data.Select(x => new object[] { x.Key, x.Value }).ToList();
    //    }

    //    [DataTestMethod]
    //    [DynamicData(nameof(GetOperationsData), DynamicDataSourceType.Method)]
    //    public async Task TestAPIServiceOperationRequestGeneration(string operationName, AdapterOperation operationMetaData) 
    //    {
    //        Console.WriteLine(operationName);
    //        AdapterOperationsController controller = new AdapterOperationsController(null);


    //        AdapterOperationsWithParams meta = new AdapterOperationsWithParams
    //        {
    //            OperationName = operationMetaData.OperationName,
    //            RequestObjectName = operationMetaData.RequestObjectName,
    //            Namespace = operationMetaData.Namespace,
    //            RequestMetadata = operationMetaData
    //        };

    //        var serializerSettings = new JsonSerializerSettings();
    //        serializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();

    //        dynamic jsonObject = new JObject();
    //        jsonObject.metadata = JObject.FromObject(meta, JsonSerializer.Create(serializerSettings));

    //        var actionResult = controller.ExecuteRequest(jsonObject);
    //        var okResult = actionResult as OkObjectResult;
    //        Console.WriteLine(okResult.Value);
    //    }
    //}

    //[Export(typeof(IBinDirectoryLocator))]
    //public class BinDirectoryLocator : IBinDirectoryLocator
    //{
    //    public string GetBinDirectory()
    //    {
    //        return AppDomain.CurrentDomain.BaseDirectory;
    //    }
    //}
}
