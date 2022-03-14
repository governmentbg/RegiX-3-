//using System;
//using System.Collections.Generic;
//using System.Data;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
//using System.Linq;
//using TechnoLogica.RegiX.Common.ObjectMapping;

//namespace RegiX.CommonTests
//{
//    [TestClass]
//    public class MapperTests
//    {
//        private static AccessMatrix accessMatrix = null;
//        private static DataSet ds = new DataSet();
//        private static DataSetMapper<RoutesResponse> routesMapper = null;
//        private static ObjectMapper<RoutesResponse, RoutesResponse> objectMapper = null;
//        static RoutesResponse sourceRoutes = null;

//        [ClassInitialize]
//        public static void ClassInitialize(TestContext testContext)
//        {
//            Dictionary<string, bool> amDictionary =
//                new Dictionary<string, bool>()
//                {
//                    {"Route", true},
//                    {"Route.RouteCode", true},
//                    {"Route.RouteName", true},
//                    {"Route.RouteDescrtiption", true},
//                    {"Route.DriversCount", true},
//                    {"Route.BusesCount", true},
//                    {"Route.ApprovalDate", true},
//                    {"Route.ContractorName", true},
//                    {"Route.Seasonal", true},
//                    {"Route.Seasonal.IsSeasonal", true},
//                    {"Route.Seasonal.SeasonStartDay", true},
//                    {"Route.Seasonal.SeasonStartMonth", true},
//                    {"Route.Seasonal.SeasonEndDay", true},
//                    {"Route.Seasonal.SeasonEndMonth", true},
//                    {"Route.Schedule", true},
//                    {"Route.Schedule.IsDaily", true},
//                    {"Route.Schedule.Monday", true},
//                    {"Route.Schedule.Tuesday", true},
//                    {"Route.Schedule.Wednesday", true},
//                    {"Route.Schedule.Thursday", true},
//                    {"Route.Schedule.Friday", true},
//                    {"Route.Schedule.Saturday", true},
//                    {"Route.Schedule.Sunday", true},
//                    {"Route.Schedule.BeforeHoliday", true},
//                    {"Route.Schedule.Holiday", true},
//                    {"Route.ForwardRoute", true},
//                    {"Route.ForwardRoute.Path", true},
//                    {"Route.ForwardRoute.Path.FromStation", true},
//                    {"Route.ForwardRoute.Path.ToStation", true},
//                    {"Route.ForwardRoute.Path.DepartTime", true},
//                    {"Route.ForwardRoute.Path.ArriveTime", true},
//                    {"Route.ForwardRoute.Path.Rest", true},
//                    {"Route.ForwardRoute.Path.Distance", true},
//                    {"Route.ForwardRoute.Path.Speed", true},
//                    {"Route.ForwardRoute.Distance", true},
//                    {"Route.ForwardRoute.TravelTime", true},
//                    {"Route.ForwardRoute.TripTime", true},
//                    {"Route.ForwardRoute.TravelSpeed", true},
//                    {"Route.ForwardRoute.TripSpeed", true},
//                    {"Route.BackwardRoute", true},
//                    {"Route.BackwardRoute.Path", true},
//                    {"Route.BackwardRoute.Path.FromStation", true},
//                    {"Route.BackwardRoute.Path.ToStation", true},
//                    {"Route.BackwardRoute.Path.DepartTime", true},
//                    {"Route.BackwardRoute.Path.ArriveTime", true},
//                    {"Route.BackwardRoute.Path.Rest", true},
//                    {"Route.BackwardRoute.Path.Distance", true},
//                    {"Route.BackwardRoute.Path.Speed", true},
//                    {"Route.BackwardRoute.Distance", true},
//                    {"Route.BackwardRoute.TravelTime", true},
//                    {"Route.BackwardRoute.TripTime", true},
//                    {"Route.BackwardRoute.TravelSpeed", true},
//                    {"Route.BackwardRoute.TripSpeed", true}
//                };
//            accessMatrix = AccessMatrix.LoadFromDictionary(amDictionary);

//            ds.ReadXmlSchema("DataFiles\\ResultSchema.xml");
//            ds.ReadXml("DataFiles\\DataSource.xml");
//            routesMapper = CreateRoutesMap(accessMatrix);
//           // objectMapper = CreateRouteObjectsMap(accessMatrix);
//            sourceRoutes = new RoutesResponse();
//            routesMapper.Map(ds, sourceRoutes);
//        }

//        [TestMethod]
//        public void DataSetMapperTest()
//        {
//            RoutesResponse result = new RoutesResponse();
//            routesMapper.Map(ds, result);
//            Assert.IsNotNull(result);
//        }

//        [TestMethod]
//        public void ObjectMapperTest()
//        {
//            RoutesResponse result = new RoutesResponse();
//            objectMapper.Map(sourceRoutes, result);
//            Assert.IsNotNull(result);
//        }

//        [TestMethod]
//        public void ObjectMapperIdentityObjectTest()
//        {
//            ObjectMapper<TestSourceClass, TestTargetClass> mapper = 
//                new ObjectMapper<TestSourceClass, TestTargetClass>(
//                    AccessMatrix.LoadFromDictionary(
//                        new Dictionary<string, bool>() 
//                        { 
//                            { "InnerClassValue", true },
//                            { "InnerClassValue.Prop", true },

//                        }
//                    )
//                );
//            mapper.AddObjectMap(d => d.InnerClassValue, s => s);
//            mapper.AddPropertyMap(d => d.InnerClassValue.Prop, s => s.Prop);
//            TestTargetClass result = new TestTargetClass();
//            mapper.Map(new TestSourceClass() { Prop = "Blah" }, result);
//            Assert.IsNotNull(result.InnerClassValue.Prop);
//        }

//        [TestMethod]
//        public void ObjectMapperSimpleObjectListsMap()
//        {
//            ObjectMapper<TestSourceClass, TestTargetClass> mapper =
//                new ObjectMapper<TestSourceClass, TestTargetClass>(
//                    AccessMatrix.LoadFromDictionary(
//                        new Dictionary<string, bool>() 
//                        { 
//                            { "InnerClassValue", true },
//                            { "InnerClassValue.Prop", true },
//                            { "StringList", true }
//                        }
//                    )
//                );
//            mapper.AddFunctionMap<TestSourceClass, List<string>>(d => d.StringList, s => s.StringArray.ToList());
//            mapper.AddObjectMap(d => d.InnerClassValue, s => s);
//            mapper.AddPropertyMap(d => d.InnerClassValue.Prop, s => s.Prop);
//            TestTargetClass result = new TestTargetClass();
//            mapper.Map(new TestSourceClass() { Prop = "Blah", StringArray = new string[]{ "asd","asdf"} }, result);
//            Assert.IsTrue(result.StringList.Count > 0);
//        }

//        [TestMethod]
//        public void AccessMatrixCreationTestForSimpleArrays()
//        {
//            var am = AccessMatrix.CreateForType(typeof(TestSourceClass));
//            Assert.IsTrue(am.AMEntry.AccessMatrix["StringArray"].AccessMatrix == null);
//        }

        
//        public class TestSourceClass
//        {
//            public string[] StringArray { get; set; }
//            public string Prop { get; set; }
//        }

//        public class TestTargetClass
//        {
//            public List<string> StringList { get; set; }
//            public TestSourceClass InnerClassValue { get; set; }
//        }

//        private static DataSetMapper<RoutesResponse> CreateRoutesMap(AccessMatrix accessMatrix)
//        {
//            DataSetMapper<RoutesResponse> routesMapper = new DataSetMapper<RoutesResponse>(accessMatrix);

//            routesMapper.AddDataSetMap((r) => r.Routes, (d) => d.Tables["Lines_info"].Rows);

//            routesMapper.AddDataColumnMap((r) => r.Routes[0].RouteCode, "routecode");
//            routesMapper.AddDataColumnMap((r) => r.Routes[0].RouteName, "routename");
//            routesMapper.AddDataColumnMap((r) => r.Routes[0].RouteDescrtiption, "routedescrtiption");
//            routesMapper.AddDataColumnMap((r) => r.Routes[0].DriversCount, "driverscount");
//            routesMapper.AddDataColumnMap((r) => r.Routes[0].BusesCount, "busescount");
//            routesMapper.AddDataColumnMap((r) => r.Routes[0].ApprovalDate, "approvaldate");
//            routesMapper.AddDataColumnMap((r) => r.Routes[0].Contractor.ContractorName, "contractorname");

//            routesMapper.AddDataColumnMap((r) => r.Routes[0].Seasonal.IsSeasonal, "seasonal");
//            routesMapper.AddDataColumnMap((r) => r.Routes[0].Seasonal.SeasonStartDay, "seasonstartday");
//            routesMapper.AddDataColumnMap((r) => r.Routes[0].Seasonal.SeasonEndDay, "seasonendday");
//            routesMapper.AddDataColumnMap((r) => r.Routes[0].Seasonal.SeasonStartMonth, "seasonstartmonth");
//            routesMapper.AddDataColumnMap((r) => r.Routes[0].Seasonal.SeasonEndMonth, "seasonendmonth");

//            routesMapper.AddDataColumnMap((r) => r.Routes[0].Schedule.IsDaily, "isdaily");
//            routesMapper.AddDataColumnMap((r) => r.Routes[0].Schedule.Monday, "monday");
//            routesMapper.AddDataColumnMap((r) => r.Routes[0].Schedule.Tuesday, "tuesday");
//            routesMapper.AddDataColumnMap((r) => r.Routes[0].Schedule.Wednesday, "wednesday");
//            routesMapper.AddDataColumnMap((r) => r.Routes[0].Schedule.Thursday, "thursday");
//            routesMapper.AddDataColumnMap((r) => r.Routes[0].Schedule.Saturday, "saturday");
//            routesMapper.AddDataColumnMap((r) => r.Routes[0].Schedule.Sunday, "sunday");
//            routesMapper.AddDataColumnMap((r) => r.Routes[0].Schedule.BeforeHoliday, "beforeholiday");
//            routesMapper.AddDataColumnMap((r) => r.Routes[0].Schedule.Holiday, "holiday");

//            routesMapper.AddDataColumnMap((r) => r.Routes[0].ForwardRoute.Distance, "fdistance");
//            routesMapper.AddDataColumnMap((r) => r.Routes[0].ForwardRoute.TravelTime, "ftraveltime");
//            routesMapper.AddDataColumnMap((r) => r.Routes[0].ForwardRoute.TravelSpeed, "ftravelspeed");
//            routesMapper.AddDataColumnMap((r) => r.Routes[0].ForwardRoute.TripTime, "ftriptime");
//            routesMapper.AddDataColumnMap((r) => r.Routes[0].ForwardRoute.TripSpeed, "ftripspeed");

//            routesMapper.AddDataColumnMap((r) => r.Routes[0].BackwardRoute.Distance, "bdistance");
//            routesMapper.AddDataColumnMap((r) => r.Routes[0].BackwardRoute.TravelTime, "btraveltime");
//            routesMapper.AddDataColumnMap((r) => r.Routes[0].BackwardRoute.TravelSpeed, "btravelspeed");
//            routesMapper.AddDataColumnMap((r) => r.Routes[0].BackwardRoute.TripTime, "btriptime");
//            routesMapper.AddDataColumnMap((r) => r.Routes[0].BackwardRoute.TripSpeed, "btripspeed");

//            routesMapper.AddDataRowMap((r) => r.Routes[0].BackwardRoute.Paths, (dr) => dr.GetChildRows("LinePaths").OrderBy((d) => d["order"]).Where((d) => Convert.ToString(d["direction"]) == "forward"));
//            routesMapper.AddDataRowMap((r) => r.Routes[0].ForwardRoute.Paths, (dr) => dr.GetChildRows("LinePaths").OrderBy((d) => d["order"]).Where((d) => Convert.ToString(d["direction"]) == "backward"));

//            routesMapper.AddDataColumnMap((r) => r.Routes[0].ForwardRoute.Paths[0].FromStation, "fromstation");
//            routesMapper.AddDataColumnMap((r) => r.Routes[0].ForwardRoute.Paths[0].ToStation, "tostation");
//            routesMapper.AddDataColumnMap((r) => r.Routes[0].ForwardRoute.Paths[0].DepartTime, "departtime");
//            routesMapper.AddDataColumnMap((r) => r.Routes[0].ForwardRoute.Paths[0].ArriveTime, "arrivetime");
//            routesMapper.AddDataColumnMap((r) => r.Routes[0].ForwardRoute.Paths[0].Rest, "rest");
//            routesMapper.AddDataColumnMap((r) => r.Routes[0].ForwardRoute.Paths[0].Distance, "distance");
//            routesMapper.AddDataColumnMap((r) => r.Routes[0].ForwardRoute.Paths[0].Speed, "speed");

//            routesMapper.AddDataColumnMap((r) => r.Routes[0].BackwardRoute.Paths[0].FromStation, "fromstation");
//            routesMapper.AddDataColumnMap((r) => r.Routes[0].BackwardRoute.Paths[0].ToStation, "tostation");
//            routesMapper.AddDataColumnMap((r) => r.Routes[0].BackwardRoute.Paths[0].DepartTime, "departtime");
//            routesMapper.AddDataColumnMap((r) => r.Routes[0].BackwardRoute.Paths[0].ArriveTime, "arrivetime");
//            routesMapper.AddDataColumnMap((r) => r.Routes[0].BackwardRoute.Paths[0].Rest, "rest");
//            routesMapper.AddDataColumnMap((r) => r.Routes[0].BackwardRoute.Paths[0].Distance, "distance");
//            routesMapper.AddDataColumnMap((r) => r.Routes[0].BackwardRoute.Paths[0].Speed, "speed");

//            return routesMapper;
//        }

//        //private static ObjectMapper<RoutesResponse, RoutesResponse> CreateRouteObjectsMap(AccessMatrix accessMatrix)
//        //{
//        //    ObjectMapper<RoutesResponse, RoutesResponse> routesMapper = new ObjectMapper<RoutesResponse, RoutesResponse>(accessMatrix);

//        //    routesMapper.AddCollectionMap<RoutesSearch>((r) => r.Routes, (r) => r.Routes);

//        //    routesMapper.AddPropertyMap((r) => r.Routes[0].RouteCode, (r) => r.Routes[0].RouteCode);
//        //    routesMapper.AddPropertyMap((r) => r.Routes[0].RouteName, (r) => r.Routes[0].RouteName);
//        //    routesMapper.AddPropertyMap((r) => r.Routes[0].RouteDescrtiption, (r) => r.Routes[0].RouteDescrtiption);
//        //    routesMapper.AddPropertyMap((r) => r.Routes[0].DriversCount, (r) => r.Routes[0].DriversCount);
//        //    routesMapper.AddPropertyMap((r) => r.Routes[0].BusesCount, (r) => r.Routes[0].BusesCount);
//        //    routesMapper.AddPropertyMap((r) => r.Routes[0].ApprovalDate, (r) => r.Routes[0].ApprovalDate);
//        //    //routesMapper.AddPropertyMap((r) => r.Routes[0], (r) => r.Routes[0].ContractorName);

//        //    routesMapper.AddObjectMap((r) => r.Routes[0].Seasonal, (r) => r.Routes[0].Seasonal);
//        //    routesMapper.AddPropertyMap((r) => r.Routes[0].Seasonal.IsSeasonal, (r) => r.Route[0].Seasonal.IsSeasonal);
//        //    routesMapper.AddPropertyMap((r) => r.Routes[0].Seasonal.SeasonStartDay, (r) => r.Route[0].Seasonal.SeasonStartDay);
//        //    routesMapper.AddPropertyMap((r) => r.Routes[0].Seasonal.SeasonEndDay, (r) => r.Route[0].Seasonal.SeasonEndDay);
//        //    routesMapper.AddPropertyMap((r) => r.Routes[0].Seasonal.SeasonStartMonth, (r) => r.Route[0].Seasonal.SeasonStartMonth);
//        //    routesMapper.AddPropertyMap((r) => r.Routes[0].Seasonal.SeasonEndMonth, (r) => r.Route[0].Seasonal.SeasonEndMonth);

//        //    routesMapper.AddObjectMap((r) => r.Routes[0].Schedule, (r) => r.Route[0].Schedule);
//        //    routesMapper.AddPropertyMap((r) => r.Routes[0].Schedule.IsDaily, (r) => r.Route[0].Schedule.IsDaily);
//        //    routesMapper.AddPropertyMap((r) => r.Routes[0].Schedule.Monday, (r) => r.Route[0].Schedule.Monday);
//        //    routesMapper.AddPropertyMap((r) => r.Routes[0].Schedule.Tuesday, (r) => r.Route[0].Schedule.Tuesday);
//        //    routesMapper.AddPropertyMap((r) => r.Routes[0].Schedule.Wednesday, (r) => r.Route[0].Schedule.Wednesday);
//        //    routesMapper.AddPropertyMap((r) => r.Routes[0].Schedule.Thursday, (r) => r.Route[0].Schedule.Thursday);
//        //    routesMapper.AddPropertyMap((r) => r.Routes[0].Schedule.Saturday, (r) => r.Route[0].Schedule.Saturday);
//        //    routesMapper.AddPropertyMap((r) => r.Routes[0].Schedule.Sunday, (r) => r.Route[0].Schedule.Sunday);
//        //    routesMapper.AddPropertyMap((r) => r.Routes[0].Schedule.BeforeHoliday, (r) => r.Route[0].Schedule.BeforeHoliday);
//        //    routesMapper.AddPropertyMap((r) => r.Routes[0].Schedule.Holiday, (r) => r.Route[0].Schedule.Holiday);

//        //    routesMapper.AddObjectMap((r) => r.Routes[0].ForwardRoute, (r) => r.Route[0].ForwardRoute);
//        //    routesMapper.AddPropertyMap((r) => r.Routes[0].ForwardRoute.Distance, (r) => r.Route[0].ForwardRoute.Distance);
//        //    routesMapper.AddPropertyMap((r) => r.Routes[0].ForwardRoute.TravelTime, (r) => r.Route[0].ForwardRoute.TravelTime);
//        //    routesMapper.AddPropertyMap((r) => r.Routes[0].ForwardRoute.TravelSpeed, (r) => r.Route[0].ForwardRoute.TravelSpeed);
//        //    routesMapper.AddPropertyMap((r) => r.Route[0].ForwardRoute.TripTime, (r) => r.Route[0].ForwardRoute.TripTime);
//        //    routesMapper.AddPropertyMap((r) => r.Route[0].ForwardRoute.TripSpeed, (r) => r.Route[0].ForwardRoute.TripSpeed);

//        //    routesMapper.AddObjectMap((r) => r.Route[0].BackwardRoute, (r) => r.Route[0].BackwardRoute);
//        //    routesMapper.AddPropertyMap((r) => r.Route[0].BackwardRoute.Distance, (r) => r.Route[0].BackwardRoute.Distance);
//        //    routesMapper.AddPropertyMap((r) => r.Route[0].BackwardRoute.TravelTime, (r) => r.Route[0].BackwardRoute.TravelTime);
//        //    routesMapper.AddPropertyMap((r) => r.Route[0].BackwardRoute.TravelSpeed, (r) => r.Route[0].BackwardRoute.TravelSpeed);
//        //    routesMapper.AddPropertyMap((r) => r.Route[0].BackwardRoute.TripTime, (r) => r.Route[0].BackwardRoute.TripTime);
//        //    routesMapper.AddPropertyMap((r) => r.Route[0].BackwardRoute.TripSpeed, (r) => r.Route[0].BackwardRoute.TripSpeed);

//        //    routesMapper.AddCollectionMap<RouteType>((r) => r.Route[0].BackwardRoute.Path, (r) => r.BackwardRoute.Path);
//        //    routesMapper.AddCollectionMap<RouteType>((r) => r.Route[0].ForwardRoute.Path, (r) => r.ForwardRoute.Path);

//        //    routesMapper.AddPropertyMap((r) => r.Route[0].ForwardRoute.Path[0].FromStation, (r) => r.Route[0].ForwardRoute.Path[0].FromStation);
//        //    routesMapper.AddPropertyMap((r) => r.Route[0].ForwardRoute.Path[0].ToStation, (r) => r.Route[0].ForwardRoute.Path[0].ToStation);
//        //    routesMapper.AddPropertyMap((r) => r.Route[0].ForwardRoute.Path[0].DepartTime, (r) => r.Route[0].ForwardRoute.Path[0].DepartTime);
//        //    routesMapper.AddPropertyMap((r) => r.Route[0].ForwardRoute.Path[0].ArriveTime, (r) => r.Route[0].ForwardRoute.Path[0].ArriveTime);
//        //    routesMapper.AddPropertyMap((r) => r.Route[0].ForwardRoute.Path[0].Rest, (r) => r.Route[0].ForwardRoute.Path[0].Rest);
//        //    routesMapper.AddPropertyMap((r) => r.Route[0].ForwardRoute.Path[0].Distance, (r) => r.Route[0].ForwardRoute.Path[0].Distance);
//        //    routesMapper.AddPropertyMap((r) => r.Route[0].ForwardRoute.Path[0].Speed, (r) => r.Route[0].ForwardRoute.Path[0].Speed);

//        //    routesMapper.AddPropertyMap((r) => r.Route[0].BackwardRoute.Path[0].FromStation, (r) => r.Route[0].BackwardRoute.Path[0].FromStation);
//        //    routesMapper.AddPropertyMap((r) => r.Route[0].BackwardRoute.Path[0].ToStation, (r) => r.Route[0].BackwardRoute.Path[0].ToStation);
//        //    routesMapper.AddPropertyMap((r) => r.Route[0].BackwardRoute.Path[0].DepartTime, (r) => r.Route[0].BackwardRoute.Path[0].DepartTime);
//        //    routesMapper.AddPropertyMap((r) => r.Route[0].BackwardRoute.Path[0].ArriveTime, (r) => r.Route[0].BackwardRoute.Path[0].ArriveTime);
//        //    routesMapper.AddPropertyMap((r) => r.Route[0].BackwardRoute.Path[0].Rest, (r) => r.Route[0].BackwardRoute.Path[0].Rest);
//        //    routesMapper.AddPropertyMap((r) => r.Route[0].BackwardRoute.Path[0].Distance, (r) => r.Route[0].BackwardRoute.Path[0].Distance);
//        //    routesMapper.AddPropertyMap((r) => r.Route[0].BackwardRoute.Path[0].Speed, (r) => r.Route[0].BackwardRoute.Path[0].Speed);

//        //    return routesMapper;
//        //}
//    }
//}
