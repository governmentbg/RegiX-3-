using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechnoLogica.RegiX.Adapters.TestUtils;
using TechnoLogica.RegiX.BABHZhSAdapter.AdapterService;
using TechnoLogica.RegiX.BABHZhSAdapter.RegisteredAnimalsInOEZByCategory;
using TechnoLogica.RegiX.Common.DataContracts;
using TechnoLogica.RegiX.Common.ObjectMapping;

namespace TechnoLogica.RegiX.BABHZhSAdapter.Tests
{
    [TestClass]
    public class BABHZhSAdapterTest : AdapterTest<AdapterService.BABHZhSAdapter, IBABHZhSAdapter>
    {

        //[TestMethod]
        //public void BABHZhSAdapterTest_CheckHealthCheckAndParamtersTest()
        //{
        //    BABHZhSAdapter adapter = new BABHZhSAdapter();
        //    //test GetParameters , and ConnectionString
        //    var connectionString = adapter.GetParameters().ParameterList.Where(p => p.Key == TechnoLogica.RegiX.Common.Constants.WebServiceUrlParameterKeyName).FirstOrDefault();
        //    //test SetParameter
        //    adapter.SetParameter(TechnoLogica.RegiX.Common.Constants.WebServiceUrlParameterKeyName, connectionString.CurrentValue);
        //    //test HCfunctions
        //    var hcFunctions = adapter.GetHealthCheckFunctions();
        //    hcFunctions.HealthInfosList.ForEach(f => adapter.CheckHealthFunction(f.Key));
        //    Assert.IsTrue(true);
        //}

        //[TestMethod]
        //public void BABHZhSAdapterTest_CheckRegisterConnection()
        //{
        //    BABHZhSAdapter adapter = new BABHZhSAdapter();
        //    string result = adapter.CheckRegisterConnection();
        //    Assert.IsTrue(result == TechnoLogica.RegiX.Common.Constants.ConnectionOk || result == TechnoLogica.RegiX.Common.Constants.ConnectionStringNotSet);
        //}


        //[TestMethod]
        //public void GetAnimalIdentificationTestBG04075159()
        //{
        //    AdapterService.BABHZhSAdapter babhAdapter = new AdapterService.BABHZhSAdapter();
        //    var accessMatrix = AccessMatrix.CreateForType(typeof(AnimalIdentificationResponseType));

        //    AnimalIdentificationRequestType searchParam = new AnimalIdentificationRequestType();

        //    searchParam.AnimalIdentificationNumber = "BG04075159";

        //    var result = babhAdapter.GetAnimalIdentification(searchParam, accessMatrix,
        //        new TechnoLogica.RegiX.Common.DataContracts.AdapterAdditionalParameters
        //        {
        //            CallContext = new CallContext
        //            {
        //                Remark = "RegiX Test"
        //            }
        //        });
        //    using (StreamWriter outfile = new StreamWriter("GetAnimalIdentificationBG04075159.xml", false, System.Text.Encoding.UTF8))
        //    {
        //        outfile.Write(result.XmlSerialize());
        //    }

        //    //XsltUtils.RunXsltAndWriteHtml("BABHZhSAdapter", "AnimalIdentificationRequest", result.Data.Request.XmlSerialize());
        //    //XsltUtils.RunXsltAndWriteHtml("BABHZhSAdapter", "AnimalIdentificationResponse", result.Data.Response.XmlSerialize());

        //    Assert.IsNotNull(result);
        //}

        //[TestMethod]
        //public void GetAnimalIdentificationTestBG09D0036689()
        //{

        //    AdapterService.BABHZhSAdapter babhAdapter = new AdapterService.BABHZhSAdapter();
        //    var accessMatrix = AccessMatrix.CreateForType(typeof(AnimalIdentificationResponseType));

        //    AnimalIdentificationRequestType searchParam = new AnimalIdentificationRequestType();

        //    searchParam.AnimalIdentificationNumber = "BG09D0036689";

        //    var result = babhAdapter.GetAnimalIdentification(searchParam, accessMatrix,
        //        new TechnoLogica.RegiX.Common.DataContracts.AdapterAdditionalParameters
        //        {
        //            CallContext = new CallContext
        //            {
        //                Remark = "RegiX Test"
        //            }
        //        });
        //    using (StreamWriter outfile = new StreamWriter("GetAnimalIdentificationBG09D0036689.xml", false, System.Text.Encoding.UTF8))
        //    {
        //        outfile.Write(result.XmlSerialize());
        //    }

        //    //XsltUtils.RunXsltAndWriteHtml("BABHZhSAdapter", "AnimalIdentificationRequest", result.Data.Request.XmlSerialize());
        //    //XsltUtils.RunXsltAndWriteHtml("BABHZhSAdapter", "AnimalIdentificationResponse", result.Data.Response.XmlSerialize());

        //    Assert.IsNotNull(result);
        //}

        //[TestMethod]
        //public void GetAnimalIdentificationTestBG30289800()
        //{
        //    AdapterService.BABHZhSAdapter babhAdapter = new AdapterService.BABHZhSAdapter();
        //    var accessMatrix = AccessMatrix.CreateForType(typeof(AnimalIdentificationResponseType));

        //    AnimalIdentificationRequestType searchParam = new AnimalIdentificationRequestType();

        //    searchParam.AnimalIdentificationNumber = "BG30289800";

        //    var result = babhAdapter.GetAnimalIdentification(searchParam, accessMatrix,
        //        new TechnoLogica.RegiX.Common.DataContracts.AdapterAdditionalParameters
        //        {
        //            CallContext = new CallContext
        //            {
        //                Remark = "RegiX Test"
        //            }
        //        });
        //    using (StreamWriter outfile = new StreamWriter("GetAnimalIdentificationBG30289800.xml", false, System.Text.Encoding.UTF8))
        //    {
        //        outfile.Write(result.XmlSerialize());
        //    }

        //    //XsltUtils.RunXsltAndWriteHtml("BABHZhSAdapter", "AnimalIdentificationRequest", result.Data.Request.XmlSerialize());
        //    //XsltUtils.RunXsltAndWriteHtml("BABHZhSAdapter", "AnimalIdentificationResponse", result.Data.Response.XmlSerialize());

        //    Assert.IsNotNull(result);
        //}

        //[TestMethod]
        //public void GetAnimalIdentificationTestBG31373475()
        //{
        //    AdapterService.BABHZhSAdapter babhAdapter = new AdapterService.BABHZhSAdapter();
        //    var accessMatrix = AccessMatrix.CreateForType(typeof(AnimalIdentificationResponseType));

        //    AnimalIdentificationRequestType searchParam = new AnimalIdentificationRequestType();

        //    searchParam.AnimalIdentificationNumber = "BG31373475";

        //    var result = babhAdapter.GetAnimalIdentification(searchParam, accessMatrix,
        //        new TechnoLogica.RegiX.Common.DataContracts.AdapterAdditionalParameters
        //        {
        //            CallContext = new CallContext
        //            {
        //                Remark = "RegiX Test"
        //            }
        //        });
        //    using (StreamWriter outfile = new StreamWriter("GetAnimalIdentificationBG31373475.xml", false, System.Text.Encoding.UTF8))
        //    {
        //        outfile.Write(result.XmlSerialize());
        //    }

        //    //XsltUtils.RunXsltAndWriteHtml("BABHZhSAdapter", "AnimalIdentificationRequest", result.Data.Request.XmlSerialize());
        //    //XsltUtils.RunXsltAndWriteHtml("BABHZhSAdapter", "AnimalIdentificationResponse", result.Data.Response.XmlSerialize());

        //    Assert.IsNotNull(result);
        //}

        //[TestMethod]
        //public void GetMotorVehicleLicenceА6284КС()
        //{
        //    AdapterService.BABHZhSAdapter babhAdapter = new AdapterService.BABHZhSAdapter();
        //    var accessMatrix = AccessMatrix.CreateForType(typeof(MotorVehicleLicenceResponseType));

        //    MotorVehicleLicenceRequestType searchParam = new MotorVehicleLicenceRequestType();
        //    searchParam.MotorVehicleRegNumber = "А6284КС";

        //    var result = babhAdapter.GetMotorVehicleLicence(searchParam, accessMatrix,
        //        new TechnoLogica.RegiX.Common.DataContracts.AdapterAdditionalParameters
        //        {
        //            CallContext = new CallContext
        //            {
        //                Remark = "RegiX Test"
        //            }
        //        });
        //    using (StreamWriter outfile = new StreamWriter("GetMotorVehicleLicenceА6284КС.xml", false, System.Text.Encoding.UTF8))
        //    {
        //        outfile.Write(result.XmlSerialize());
        //    }

        //    //XsltUtils.RunXsltAndWriteHtml("BABHZhSAdapter", "MotorVehicleLicenceRequest", result.Data.Request.XmlSerialize());
        //    //XsltUtils.RunXsltAndWriteHtml("BABHZhSAdapter", "MotorVehicleLicence", result.Data.Response.XmlSerialize());

        //    Assert.IsNotNull(result);
        //}

        //[TestMethod]
        //public void GetMotorVehicleLicenceDefault()
        //{
        //    AdapterService.BABHZhSAdapter babhAdapter = new AdapterService.BABHZhSAdapter();
        //    var accessMatrix = AccessMatrix.CreateForType(typeof(MotorVehicleLicenceResponseType));

        //    MotorVehicleLicenceRequestType searchParam = new MotorVehicleLicenceRequestType();
        //    searchParam.MotorVehicleRegNumber = "C1234AC";

        //    var result = babhAdapter.GetMotorVehicleLicence(searchParam, accessMatrix,
        //        new TechnoLogica.RegiX.Common.DataContracts.AdapterAdditionalParameters
        //        {
        //            CallContext = new CallContext
        //            {
        //                Remark = "RegiX Test"
        //            }
        //        });
        //    using (StreamWriter outfile = new StreamWriter("GetMotorVehicleLicenceDefault.xml", false, System.Text.Encoding.UTF8))
        //    {
        //        outfile.Write(result.XmlSerialize());
        //    }

        //    //XsltUtils.RunXsltAndWriteHtml("BABHZhSAdapter", "MotorVehicleLicenceRequest", result.Data.Request.XmlSerialize());
        //    //XsltUtils.RunXsltAndWriteHtml("BABHZhSAdapter", "MotorVehicleLicence", result.Data.Response.XmlSerialize());

        //    Assert.IsNotNull(result);
        //}

        //[TestMethod]
        //public void GetMotorVehicleLicenceNull()
        //{
        //    AdapterService.BABHZhSAdapter babhAdapter = new AdapterService.BABHZhSAdapter();
        //    var accessMatrix = AccessMatrix.CreateForType(typeof(MotorVehicleLicenceResponseType));

        //    MotorVehicleLicenceRequestType searchParam = new MotorVehicleLicenceRequestType();
        //    searchParam.MotorVehicleRegNumber = "null";

        //    var result = babhAdapter.GetMotorVehicleLicence(searchParam, accessMatrix,
        //        new TechnoLogica.RegiX.Common.DataContracts.AdapterAdditionalParameters
        //        {
        //            CallContext = new CallContext
        //            {
        //                Remark = "RegiX Test"
        //            }
        //        });
        //    using (StreamWriter outfile = new StreamWriter("GetMotorVehicleLicenceNull.xml", false, System.Text.Encoding.UTF8))
        //    {
        //        outfile.Write(result.XmlSerialize());
        //    }

        //    //XsltUtils.RunXsltAndWriteHtml("BABHZhSAdapter", "MotorVehicleLicenceRequest", result.Data.Request.XmlSerialize());
        //    //XsltUtils.RunXsltAndWriteHtml("BABHZhSAdapter", "MotorVehicleLicence", result.Data.Response.XmlSerialize());

        //    Assert.IsNotNull(result);
        //}


        //[TestMethod]
        //public void GetRegisteredAnimalsByCategory()
        //{
        //    AdapterService.BABHZhSAdapter babhAdapter = new AdapterService.BABHZhSAdapter();
        //    var accessMatrix = AccessMatrix.CreateForType(typeof(RegisteredAnimalsByCategoryResponseType));

        //    RegisteredAnimalsByCategoryRequestType searchParam = new RegisteredAnimalsByCategoryRequestType();
        //    searchParam.EGN = "8708200047";
        //    searchParam.ValidDate = new DateTime(2012, 11, 13);


        //    var result = babhAdapter.GetRegisteredAnimalsByCategory(searchParam, accessMatrix,
        //        new TechnoLogica.RegiX.Common.DataContracts.AdapterAdditionalParameters
        //        {
        //            CallContext = new CallContext
        //            {
        //                Remark = "RegiX Test"
        //            }
        //        });
        //    using (StreamWriter outfile = new StreamWriter("GetRegisteredAnimalsByCategory.xml", false, System.Text.Encoding.UTF8))
        //    {
        //        outfile.Write(result.XmlSerialize());
        //    }

        //    //XsltUtils.RunXsltAndWriteHtml("BABHZhSAdapter", "RegisteredAnimalsByCategoryRequest", result.Data.Request.XmlSerialize());
        //    //XsltUtils.RunXsltAndWriteHtml("BABHZhSAdapter", "RegisteredAnimalsByCategory", result.Data.Response.XmlSerialize());

        //    Assert.IsNotNull(result);
        //}

        //[TestMethod]
        //public void GetRegisteredAnimalsByCategoryNull()
        //{
        //    AdapterService.BABHZhSAdapter babhAdapter = new AdapterService.BABHZhSAdapter();
        //    var accessMatrix = AccessMatrix.CreateForType(typeof(RegisteredAnimalsByCategoryResponseType));

        //    RegisteredAnimalsByCategoryRequestType searchParam = new RegisteredAnimalsByCategoryRequestType();
        //    searchParam.EGN = "null";
        //    searchParam.ValidDate = new DateTime(2012, 11, 13);


        //    var result = babhAdapter.GetRegisteredAnimalsByCategory(searchParam, accessMatrix,
        //        new TechnoLogica.RegiX.Common.DataContracts.AdapterAdditionalParameters
        //        {
        //            CallContext = new CallContext
        //            {
        //                Remark = "RegiX Test"
        //            }
        //        });
        //    using (StreamWriter outfile = new StreamWriter("GetRegisteredAnimalsByCategoryNull.xml", false, System.Text.Encoding.UTF8))
        //    {
        //        outfile.Write(result.XmlSerialize());
        //    }

        //    //XsltUtils.RunXsltAndWriteHtml("BABHZhSAdapter", "RegisteredAnimalsByCategoryRequest", result.Data.Request.XmlSerialize());
        //    //XsltUtils.RunXsltAndWriteHtml("BABHZhSAdapter", "RegisteredAnimalsByCategory", result.Data.Response.XmlSerialize());

        //    Assert.IsNotNull(result);
        //}

        //[TestMethod]
        //public void GetRegisteredAnimalsByCategoryAllOEZ()
        //{
        //    AdapterService.BABHZhSAdapter babhAdapter = new AdapterService.BABHZhSAdapter();
        //    var accessMatrix = AccessMatrix.CreateForType(typeof(RegisteredAnimalsInOEZByCategoryResponseType));

        //    RegisteredAnimalsInOEZCategoryRequestType searchParam = new RegisteredAnimalsInOEZCategoryRequestType();

        //    //no data=1212124563
        //    //some data=125506309
        //    searchParam.Identifier = "125506309";
        //    searchParam.ValidDate = new DateTime(2012, 11, 13);

        //    var result = babhAdapter.GetRegisteredAnimalsInOEZByCategory(searchParam, accessMatrix,
        //        new TechnoLogica.RegiX.Common.DataContracts.AdapterAdditionalParameters
        //        {
        //            CallContext = new CallContext
        //            {
        //                Remark = "RegiX Test"
        //            }
        //        });
        //    using (StreamWriter outfile = new StreamWriter("GetRegisteredAnimalsInOEZByCategory.xml", false, System.Text.Encoding.UTF8))
        //    {
        //        outfile.Write(result.XmlSerialize());
        //    }

        //    //XsltUtils.RunXsltAndWriteHtml("BABHZhSAdapter", "RegisteredAnimalsByCategoryRequest", result.Data.Request.XmlSerialize());
        //    //XsltUtils.RunXsltAndWriteHtml("BABHZhSAdapter", "RegisteredAnimalsByCategory", result.Data.Response.XmlSerialize());

        //    Assert.IsNotNull(result);
        //}

    }
}
