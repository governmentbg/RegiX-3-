using System;
using System.Linq;
using System.Data;
using TechnoLogica.RegiX.Common;
using TechnoLogica.RegiX.Common.ObjectMapping;
using TechnoLogica.RegiX.Common.Utils;
using System.ComponentModel.Composition;
using IBM.Data.Informix;
using TechnoLogica.RegiX.Common.DataContracts;
using TechnoLogica.RegiX.Adapters.Common.ExportExtension;
using TechnoLogica.RegiX.Adapters.Common.DataContracts;
using TechnoLogica.RegiX.Common.DataContracts.Parameter;
using TechnoLogica.RegiX.Adapters.Common.ObjectMapping;

namespace TechnoLogica.RegiX.ZADSAdapter.AdapterService
{
    [Export(typeof(IAdapterService))]
    [ExportFullName(typeof(ZADSAdapter), typeof(IAdapterService))]
    [ExportSimpleName(typeof(ZADSAdapter), typeof(IAdapterService))]
    public class ZADSAdapter : InformixAdapterService.InformixBaseAdapterService, IZADSAdapter, IAdapterService
    {
        [Export(typeof(ParameterInfo))]
        [ExportFullName(typeof(ZADSAdapter), typeof(ParameterInfo))]
        public static ParameterInfo<string> ConnectionString =
            new ParameterInfo<string>("Database=zads;Host=egov;Server=;Service=25852;Protocol=onsoctcp;UID=informix;Password=;DB_LOCALE=en_US.57372")
            {
                Key = Constants.ConnectionStringParameterKeyName,
                Description = "Connection string for Informix",
                OwnerAssembly = typeof(ZADSAdapter).Assembly
            };

        //[Export(typeof(HealthInfo))]
        //public static HealthInfoWithFunction CheckDBConnection =
        //    new HealthInfoWithFunction()
        //    {
        //        Key = "CheckDBConnection",
        //        Name = "Проверява връзката към базата",
        //        Description = "Проверява връзката към базата",
        //        CheckFunction =
        //        () =>
        //        {
        //            using (IfxConnection connection = new IfxConnection(ConnectionString.Value))
        //            {
        //                connection.Open();
        //                return "ZADSAdapter Connection - OK";
        //            }
        //        }
        //    };


        [Export(typeof(ParameterInfo))]
        [ExportFullName(typeof(ZADSAdapter), typeof(ParameterInfo))]
        public static ParameterInfo<string> SchemaName =
            new ParameterInfo<string>("zads")
            {
                Key = "SchemaName",
                Description = "Name of the schema in database",
                OwnerAssembly = typeof(ZADSAdapter).Assembly
            };

        [Export(typeof(ParameterInfo))]
        [ExportFullName(typeof(ZADSAdapter), typeof(ParameterInfo))]
        public static ParameterInfo<string> WhereStatement =
            new ParameterInfo<string>(@"and version = (select max(version) from customerinfo WHERE customerkey = ?)
                                        and not history")
            {
                Key = "WhereStatement",
                Description = "Condition for valid customer",
                OwnerAssembly = typeof(ZADSAdapter).Assembly
            };

        public CommonSignedResponse<RegistrationInfoRequestType, RegistrationInfoResponseType> GetRegistrationInfo(
            RegistrationInfoRequestType argument,
            AccessMatrix accessMatrix,
            AdapterAdditionalParameters aditionalParameters)
        {
            Guid id = Guid.NewGuid();
            LogData(aditionalParameters, new { Request = argument.Serialize(), Guid = id });
            try
            {
                IfxConnection connection;
                connection = new IfxConnection(ConnectionString.Value);
                DataSet ds = new DataSet();
                ds.Tables.Add("Customers");
                ds.Tables.Add("Products");
                ds.Tables.Add("Operators");
                try
                {
                    IfxCommand customerCommand = new IfxCommand();
                    customerCommand.Connection = connection;
                    customerCommand.CommandType = System.Data.CommandType.Text;
                    customerCommand.CommandText = @"SELECT customerid, customername, customerkey 
	                                  FROM customerinfo
                                     WHERE customerkey = ? " + WhereStatement.Value;

                    customerCommand.Parameters.Add("egn1", argument.EIK);
                    customerCommand.Parameters.Add("egn2", argument.EIK);

                    connection.Open();

                    IfxDataAdapter customerda = new IfxDataAdapter(customerCommand);
                    customerda.Fill(ds.Tables["Customers"]);

                    if (ds.Tables["Customers"].Rows.Count > 0)
                    {
                        IfxCommand operatorCommand = new IfxCommand();
                        operatorCommand.Connection = connection;
                        operatorCommand.CommandType = System.Data.CommandType.Text;
                        operatorCommand.CommandText = @" SELECT customerid, 
                                                    customerkey, 
                                                    o.economicoperatorid, 
                                                    type, 
                                                    customsoffice, 
                                                    registrationnumber, 
                                                    registrationtype, 
                                                    state, 
                                                    issuingdate, 
                                                    domicileexciseoffice, 
                                                    registrationexcisenumber, 
                                                    deliveringdate, 
                                                    taxwarehousename, 
                                                    taxwarehouseproductstype, 
                                                    taxwarehousetype, 
                                                    city, 
                                                    countrycode, 
                                                    municipality, 
                                                    postcode, 
                                                    region, 
                                                    streetname, 
                                                    streetnumber,
                                                    cancellationoperationdate, 
                                                    cancellationreason,
                                                    rejectiondate, 
                                                    rejectioncode || ' ' || rejectionreason  as rejectionreason
	                                            FROM economyoperatorinfo o
                                                left join cancellationinfo c on o.economicoperatorid = c.economicoperatorid and c.cancellationoperationdate <= ?
                                                left join rejectioninfo r on r.economicoperatorid = o.economicoperatorid and r.rejectiondate <= ?
                                               WHERE o.issuingdate <= ?
                                                 and o.customerid = ? ";
                        operatorCommand.Parameters.Add("statusDate1", argument.StatusDate);
                        operatorCommand.Parameters.Add("statusDate2", argument.StatusDate);
                        operatorCommand.Parameters.Add("statusDate3", argument.StatusDate);
                        operatorCommand.Parameters.Add("customerid", ds.Tables["Customers"].Rows[0]["customerid"]);

                        IfxDataAdapter operatorda = new IfxDataAdapter(operatorCommand);

                        operatorda.Fill(ds.Tables["Operators"]);
                        ds.Tables["Customers"].ChildRelations.Add(new DataRelation("CustomerOperators", ds.Tables["Customers"].Columns["customerid"], ds.Tables["Operators"].Columns["customerid"], true));

                        if (ds.Tables["Operators"].Rows.Count > 0)
                        {
                            IfxCommand productsCommand = new IfxCommand();
                            productsCommand.Connection = connection;
                            productsCommand.CommandType = System.Data.CommandType.Text;
                            productsCommand.CommandText = @"SELECT id, 
                                                   categorytwo, 
                                                   cncode, 
                                                   tradename, 
                                                   economicoperatorid 
	                                          FROM exciseproductinfo
                                             WHERE customerid = ?
                                               and issuingdate <= ?";
                            productsCommand.Parameters.Add("customerid", ds.Tables["Customers"].Rows[0]["customerid"]);
                            productsCommand.Parameters.Add("statusDate", argument.StatusDate);

                            IfxDataAdapter productsda = new IfxDataAdapter(productsCommand);

                            productsda.Fill(ds.Tables["Products"]);
                            ds.Tables["Operators"].ChildRelations.Add(new DataRelation("OperatorProducts", ds.Tables["Operators"].Columns["economicoperatorid"], ds.Tables["Products"].Columns["economicoperatorid"], true));
                        }
                    }
                }
                finally
                {
                    connection.Close();
                }
                DataSetMapper<RegistrationInfoResponseType> mapper = CreateZADSMap(accessMatrix);
                RegistrationInfoResponseType result = new RegistrationInfoResponseType();
                mapper.Map(ds, result);
                return SigningUtils.CreateAndSign(
                        argument,
                        result,
                        accessMatrix,
                        aditionalParameters
                        );
            }
            catch (Exception ex)
            {
                LogError(aditionalParameters, ex, new { Guid = id });
                System.IO.File.AppendAllText("C://Regix//AmAdapters//log_errors.txt", GetFullExceptionDetails(ex, true));
                throw ex;
            }

        }

        private static DataSetMapper<RegistrationInfoResponseType> CreateZADSMap(AccessMatrix accessMatrix)
        {
            DataSetMapper<RegistrationInfoResponseType> mapper = new DataSetMapper<RegistrationInfoResponseType>(accessMatrix);

            mapper.AddDataSetObjectInitializer((ds) => (ds.Tables["Customers"].Rows.Count >= 1) ? ds.Tables["Customers"].Rows[0] : null);

            mapper.AddDataColumnMap((f) => f.Name, "customername");

            mapper.AddDataRowMap((f) => f.EconomyOperators, (dr) => dr.GetChildRows("CustomerOperators"));

            mapper.AddDataColumnMap((f) => f.EconomyOperators[0].Status, "state");
            mapper.AddDataColumnMap((f) => f.EconomyOperators[0].CancellationDate, "cancellationoperationdate");
            mapper.AddDataColumnMap((f) => f.EconomyOperators[0].CancellationReason, "cancellationreason");
            mapper.AddDataColumnMap((f) => f.EconomyOperators[0].RejectionDate, "rejectiondate");
            mapper.AddDataColumnMap((f) => f.EconomyOperators[0].RejectionReason, "rejectionreason");
            mapper.AddDataColumnMap((f) => f.EconomyOperators[0].Type, "type");
            mapper.AddDataColumnMap((f) => f.EconomyOperators[0].RegistrationType, "registrationtype");
            mapper.AddDataColumnMap((f) => f.EconomyOperators[0].RegistrationNumber, "registrationnumber");
            mapper.AddDataColumnMap((f) => f.EconomyOperators[0].ExciseNumber, "registrationexcisenumber");
            mapper.AddDataColumnMap((f) => f.EconomyOperators[0].RegistrationDate, "issuingdate");
            mapper.AddDataColumnMap((f) => f.EconomyOperators[0].CustomsOffice, "customsoffice");
            mapper.AddDataColumnMap((f) => f.EconomyOperators[0].DomicileOffice, "domicileexciseoffice");
            mapper.AddDataColumnMap((f) => f.EconomyOperators[0].Warehouse.WarehouseName, "taxwarehousename");
            mapper.AddDataColumnMap((f) => f.EconomyOperators[0].Warehouse.WarehouseType, "taxwarehousetype");
            mapper.AddDataColumnMap((f) => f.EconomyOperators[0].Warehouse.WarehouseGroup, "taxwarehouseproductstype");
            mapper.AddDataColumnMap((f) => f.EconomyOperators[0].Warehouse.WarehouseAddress.City, "city");
            mapper.AddDataColumnMap((f) => f.EconomyOperators[0].Warehouse.WarehouseAddress.CountryCode, "countrycode");
            mapper.AddDataColumnMap((f) => f.EconomyOperators[0].Warehouse.WarehouseAddress.Municipality, "municipality");
            mapper.AddDataColumnMap((f) => f.EconomyOperators[0].Warehouse.WarehouseAddress.Postcode, "postcode");
            mapper.AddDataColumnMap((f) => f.EconomyOperators[0].Warehouse.WarehouseAddress.Region, "region");
            mapper.AddDataColumnMap((f) => f.EconomyOperators[0].Warehouse.WarehouseAddress.Streetname, "streetname");
            mapper.AddDataColumnMap((f) => f.EconomyOperators[0].Warehouse.WarehouseAddress.Streetnumber, "streetnumber");

            mapper.AddDataRowMap((f) => f.EconomyOperators[0].ExciseProducts, (dr) => dr.GetChildRows("OperatorProducts"));
            mapper.AddDataColumnMap((f) => f.EconomyOperators[0].ExciseProducts[0].TradeName, "tradename");
            mapper.AddDataColumnMap((f) => f.EconomyOperators[0].ExciseProducts[0].Category, "categorytwo");
            mapper.AddDataColumnMap((f) => f.EconomyOperators[0].ExciseProducts[0].CNCode, "cncode");

            return mapper;
        }

        private static string GetFullExceptionDetails(Exception e, bool includeStackTrace = false)
        {
            string newLine = Environment.NewLine;
            string message = e.Message;
            string exceptionType = e.GetType().ToString();



            string stack = "";
            if (includeStackTrace && !string.IsNullOrEmpty(e.StackTrace))
            {
                stack = e.StackTrace + newLine;
            }


            string LinesSeparator = new string('=', 27);
            string result = string.Format("{0}{1}{2}{1}{3}{1}{4}{1}{5}",
                LinesSeparator,
                newLine,
                exceptionType,
                e.Source,
                message,
                stack);
            if (e.InnerException != null)
            {
                result = result + GetFullExceptionDetails(e.InnerException, includeStackTrace);
            }

            return result;
        }
    }
}
