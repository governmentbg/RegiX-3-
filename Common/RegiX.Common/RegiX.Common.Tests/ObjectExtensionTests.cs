using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechnoLogica.RegiX.Common.Utils;

namespace RegiX.CommonTests
{
    [TestClass]
    public class ObjectExtensionTests
    {
        [TestMethod]
        public void ValueOrNull_ValueNotSpecified()
        {
            ValueOrNullTestClass val = new ValueOrNullTestClass() { Value = true, ValueSpecified = false };
            Assert.IsTrue(val.GetValueOrNull(v => v.Value) == System.DBNull.Value);
        }

        [TestMethod]
        public void ValueOrNull_ValueSpecified()
        {
            ValueOrNullTestClass val = new ValueOrNullTestClass() { Value = true, ValueSpecified = true };
            Assert.IsTrue((bool)val.GetValueOrNull(v => v.Value));
        }

        [TestMethod]
        public void ValueOrNull_NoSpecified_True()
        {
            ValueOrNullTestClassNoSpecified val = new ValueOrNullTestClassNoSpecified() { Value = true };
            Assert.IsTrue((bool)val.GetValueOrNull(v => v.Value));
        }

        [TestMethod]
        public void ValueOrNull_NoSpecified_False()
        {
            ValueOrNullTestClassNoSpecified val = new ValueOrNullTestClassNoSpecified() { Value = false };
            Assert.IsTrue(!(bool)val.GetValueOrNull(v => v.Value));
        }
    }

    public class ValueOrNullTestClass
    {
        public bool Value { get; set; }
        public bool ValueSpecified { get; set; }
    }

    public class ValueOrNullTestClassNoSpecified
    {
        public bool Value { get; set; }
    }
}
