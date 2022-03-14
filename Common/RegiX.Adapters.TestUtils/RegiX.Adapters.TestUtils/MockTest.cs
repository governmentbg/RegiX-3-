using Microsoft.VisualStudio.TestTools.UnitTesting;
using RegiX.Adapters.Mocks;
using System;
using System.Collections.Generic;
using System.Text;
using TechnoLogica.RegiX.Common;
using System.Linq;
using System.Reflection;

namespace TechnoLogica.RegiX.Adapters.TestUtils
{
    public class MockTest<M, I>
        where I : IAdapterService
        where M : BaseAdapterServiceProxy<I>, new()
    {
        public static IEnumerable<object[]> GetOperations()
        {
            return typeof(I).GetMethods().Select(m => new object[] { m });
        }

        [DataTestMethod]
        [DynamicData(nameof(GetOperations), DynamicDataSourceType.Method)]
        public void Test(MethodInfo operation)
        {
            var mock = new M().Create();
            var result = operation.Invoke(mock, new object[] { null, null, null });
            Assert.IsNotNull(result);
        }
    }
}
