using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using TechnoLogica.RegiX.Common;
using System.Linq;
using System;

namespace TechnoLogica.RegiX.Adapters.TestUtils
{
    public abstract class AdapterTest<T, I>
        where T : class
        where I : IAdapterService
    {
        public AdapterTest()
        {
            AggregateCatalog catalog = new AggregateCatalog();
            catalog.Catalogs.Add(new AssemblyCatalog(typeof(T).Assembly));
            catalog.Catalogs.Add(new AssemblyCatalog(typeof(AdapterTest<,>).Assembly));
            CompositionContainer result = new CompositionContainer(catalog, true);
            result.ComposeExportedValue(result);
            Composition.CompositionContainer = result;
        }

        [TestMethod]
        public void CheckIAdapterServiceExported()
        {
            Assert.IsTrue(
                Composition.
                    CompositionContainer.
                    GetExportedValues<IAdapterService>().
                    Where(
                        a => a.GetType() == typeof(T)
                    ).Count() == 1,
                $"The type {typeof(T).FullName} should be exported exactly one time"
            );
        }

        [TestMethod]
        public void CheckAdapterSimpleNameExported()
        {
            Assert.IsTrue(
                Composition.
                    CompositionContainer.
                    GetExportedValues<IAdapterService>(typeof(T).Name).
                    Where(
                        a => a.GetType() == typeof(T)
                    ).Count() == 1,
                $"The type {typeof(T).FullName} should be exported exactly one time (by Name)"
            );
        }

        [TestMethod]
        public void CheckExportFullNameExported()
        {
            Assert.IsTrue(
                Composition.
                    CompositionContainer.
                    GetExportedValues<IAdapterService>(typeof(T).FullName).
                    Where(
                        a => a.GetType() == typeof(T)
                    ).Count() == 1,
                $"The type {typeof(T).FullName} should be exported exactly one time (by FullName)"
            );
        }

        [TestMethod]
        public void CheckAdapterServiceInterface()
        {
            try
            {
                var composed = 
                    Composition.
                            CompositionContainer.
                            GetExport<IAdapterService>();
            }
            catch(Exception ex)
            {

            }

            Assert.IsTrue(
                  Composition.
                      CompositionContainer.
                      GetExportedValue<IAdapterService>(typeof(T).FullName).
                      AdapterServiceInterface == typeof(I),
                  $"The type {typeof(T).FullName} should be exported exactly one time (by FullName)"
              );
        }

        [TestMethod]
        public void CheckAdapterServiceName()
        {
            Assert.IsTrue(
                  Composition.
                      CompositionContainer.
                      GetExportedValue<IAdapterService>(typeof(T).FullName)
                      .AdapterServiceName == typeof(T).Name,
                  $"The type {typeof(T).FullName} should be exported exactly one time (by FullName)"
              );
        }

        [TestMethod]
        public void CheckAdapterServiceType()
        {
            Assert.IsTrue(
                  Composition.
                      CompositionContainer.
                      GetExportedValue<IAdapterService>(typeof(T).FullName)
                      .AdapterServiceType == typeof(T),
                  $"The type {typeof(T).FullName} should be exported exactly one time (by FullName)"
              );
        }
    }
}
