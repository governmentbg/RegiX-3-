using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace RegiX.Adapters.Common.Tests
{
    [TestClass]
    public class ParameterInfoTests
    {
        [TestMethod]
        public void IntConversionTest()
        {
            TypeConverter typeConverter = TypeDescriptor.GetConverter(typeof(int));
            object propValue = typeConverter.ConvertFromString("4");
            var intParam = (int)propValue;
            Assert.IsTrue(intParam == 4);
        }
    }
}
