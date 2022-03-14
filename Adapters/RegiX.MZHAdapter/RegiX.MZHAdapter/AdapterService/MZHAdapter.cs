using System;
using System.Linq;
using System.Data;
using TechnoLogica.RegiX.Common;
using TechnoLogica.RegiX.Common.ObjectMapping;
using TechnoLogica.RegiX.Common.Utils;
using System.ComponentModel.Composition;
using TechnoLogica.RegiX.Common.DataContracts;
using TechnoLogica.RegiX.Adapters.Common.ExportExtension;
using TechnoLogica.RegiX.Adapters.Common.DataContracts;
using TechnoLogica.RegiX.Common.DataContracts.Parameter;
using TechnoLogica.RegiX.Adapters.Common.ObjectMapping;

namespace TechnoLogica.RegiX.MZHAdapter.AdapterService
{
    [Export(typeof(IAdapterService))]
    [ExportFullName(typeof(MZHAdapter), typeof(IAdapterService))]
    [ExportSimpleName(typeof(MZHAdapter), typeof(IAdapterService))]
    public class MZHAdapter : NpgsqlAdapterService.NpgsqlBaseAdapterService, IMZHAdapter, IAdapterService
    {
        [Export(typeof(ParameterInfo))]
        [ExportFullName(typeof(MZHAdapter), typeof(ParameterInfo))]
        public static ParameterInfo<string> ConnectionString =
            new ParameterInfo<string>("Server=egov;Port=5432;Database=drive;UserId=postgres;Password=admin;Timeout=1024")
            {
                Key = Constants.ConnectionStringParameterKeyName,
                Description = "Connection string",
                OwnerAssembly = typeof(MZHAdapter).Assembly
            };

        [Export(typeof(ParameterInfo))]
        [ExportFullName(typeof(MZHAdapter), typeof(ParameterInfo))]
        public static ParameterInfo<string> SchemaName =
            new ParameterInfo<string>("MZH")
            {
                Key = "SchemaName",
                Description = "Name of the schema in database",
                OwnerAssembly = typeof(MZHAdapter).Assembly
            };

        public CommonSignedResponse<FarmerSearchParametersType, FarmerType> FarmerDetailsSearch(FarmerSearchParametersType argument, AccessMatrix accessMatrix, AdapterAdditionalParameters aditionalParameters)
        {
            Guid id = Guid.NewGuid();
            LogData(aditionalParameters, new { Request = argument.Serialize(), Guid = id });
            try
            {
            Npgsql.NpgsqlConnection connection = new Npgsql.NpgsqlConnection(ConnectionString.Value);
            Npgsql.NpgsqlCommand command = new Npgsql.NpgsqlCommand();
            command.Connection = connection;
            command.CommandType = System.Data.CommandType.Text;
            command.CommandText = @"SELECT case when adm.jur = 0 then adm.ime1 else null end as name, 
                                          case when adm.jur = 0 then adm.ime2 else null end as surname, 
                                          case when adm.jur = 0 then adm.ime3 else null end as family, 
                                          case when adm.jur != 0 then adm.firm else null end as companyname, 
                                          case when adm.jur != 0 then n_jur.ime else null end leagalstatus,
                                          case when reg.zp_id is not null then reg.dat else null end as registrationdate,
                                          case when otp.zp_id is not null then otp.dat else null end as cancellationdate,
                                          zp.id"
                                     + " FROM \"" + SchemaName.Value + "\".adm"
                                     + " join \"" + SchemaName.Value + "\".zp  on  adm.zp_id = zp.id"
                                     + @" left join (SELECT reg.zp_id,
			                                               max(reg.dat) dat"
                                                    + " FROM \"" + SchemaName.Value + "\".reg"
                                                     + @"  WHERE reg.god = @pyear 		  
		                                              GROUP BY zp_id)  reg on reg.zp_id = zp.id
                                        left join (SELECT otp.zp_id,
		                                                 max(otp.dat) dat "
                                                         + " FROM \"" + SchemaName.Value + "\".otp"
                                                + @" WHERE otp.god = @pyear 		  
                                                   GROUP BY zp_id ) otp on reg.zp_id = zp.id "
                                       + " left join  \"" + SchemaName.Value + "\".n_zp as n_jur on n_jur.kod =  adm.jur "
                                     + @" WHERE adm.akt = true
                                          AND zp.ege = @pidentifier;";

            command.Parameters.AddWithValue("@pyear", DateTime.Now.Year);
            command.Parameters.AddWithValue("@pidentifier", argument.GetValueOrNull(r => r.Parameter));

            Npgsql.NpgsqlCommand landsCommand = new Npgsql.NpgsqlCommand();
            landsCommand.Connection = connection;
            landsCommand.CommandType = System.Data.CommandType.Text;
            landsCommand.CommandText = @"SELECT zp.id,
                                                ekt.ek ekkate,
                                                sum(op) infield"
                                             + " FROM \"" + SchemaName.Value + "\".zp"
                                            + " join \"" + SchemaName.Value + "\".reg on  reg.zp_id = zp.id"
                                            + " join \"" + SchemaName.Value + "\".dan on dan.reg_id = reg.id"
                                            + " join \"" + SchemaName.Value + "\".ekt on dan.id = ekt.dan_id"
                                            + " join \"" + SchemaName.Value + "\".dekt on ekt.id = dekt.ekt_id"
                                            + " join \"" + SchemaName.Value + "\".tab1 on dekt.id = tab1.dekt_id"
                                            + @" WHERE dan.akt = true 
                                            and reg.god = @pyear 
                                            and dekt.akt = true
                                            and zp.ege = @pidentifier
                                            group by zp.id, ekt.ek";

            landsCommand.Parameters.AddWithValue("@pyear", DateTime.Now.Year);
            landsCommand.Parameters.AddWithValue("@pidentifier", argument.GetValueOrNull(r => r.Parameter));


            Npgsql.NpgsqlCommand cropsCommand = new Npgsql.NpgsqlCommand();
            cropsCommand.Connection = connection;
            cropsCommand.CommandType = System.Data.CommandType.Text;
            cropsCommand.CommandText = @"SELECT zp.id,
                                                ekt.ek ekkate,
                                                tab2.kod as CropCode,
                                                nom.ime as CropName,
                                                sum(f3) SownArea,
                                                sum(f7) IntendedSownAreaNextYear"
                                             + " FROM \"" + SchemaName.Value + "\".zp"
                                            + " join \"" + SchemaName.Value + "\".reg on  reg.zp_id = zp.id"
                                            + " join \"" + SchemaName.Value + "\".dan on dan.reg_id = reg.id"
                                            + " join \"" + SchemaName.Value + "\".ekt on dan.id = ekt.dan_id"
                                            + " join \"" + SchemaName.Value + "\".dekt on ekt.id = dekt.ekt_id"
                                            + " join \"" + SchemaName.Value + "\".tab2 on dekt.id = tab2.dekt_id"
                                            + " join \"" + SchemaName.Value + "\".n_rast nom on tab2.kod = nom.kod"
                                            + @" WHERE dan.akt = true 
                                            and reg.god = @pyear 
                                            and dekt.akt = true
                                            and zp.ege = @pidentifier
                                            group by zp.id, ekt.ek, tab2.kod, nom.ime";

            cropsCommand.Parameters.AddWithValue("@pyear", DateTime.Now.Year);
            cropsCommand.Parameters.AddWithValue("@pidentifier", argument.GetValueOrNull(r => r.Parameter));

            Npgsql.NpgsqlCommand animalsCommand = new Npgsql.NpgsqlCommand();
            animalsCommand.Connection = connection;
            animalsCommand.CommandType = System.Data.CommandType.Text;
            animalsCommand.CommandText = @"  SELECT zp.id,
                                                    ekt.ek ekkate,
                                                    tab3.kod as AnimalCode,
                                                    nom.ime as AnimalName,
                                                    sum(kol) Units"
                                             + " FROM \"" + SchemaName.Value + "\".zp"
                                            + " join \"" + SchemaName.Value + "\".reg on  reg.zp_id = zp.id"
                                            + " join \"" + SchemaName.Value + "\".dan on dan.reg_id = reg.id"
                                            + " join \"" + SchemaName.Value + "\".ekt on dan.id = ekt.dan_id"
                                            + " join \"" + SchemaName.Value + "\".dekt on ekt.id = dekt.ekt_id"
                                            + " join \"" + SchemaName.Value + "\".tab3 on dekt.id = tab3.dekt_id"
                                            + " join \"" + SchemaName.Value + "\".n_anim nom on nom.kod = tab3.kod"
                                            + @" WHERE dan.akt = true 
                                            and reg.god = @pyear 
                                            and dekt.akt = true
                                            and zp.ege = @pidentifier
                                            group by zp.id, ekt.ek, tab3.kod, nom.ime";

            animalsCommand.Parameters.AddWithValue("@pyear", DateTime.Now.Year);
            animalsCommand.Parameters.AddWithValue("@pidentifier", argument.GetValueOrNull(r => r.Parameter));


            Npgsql.NpgsqlDataAdapter da = new Npgsql.NpgsqlDataAdapter(command);
            Npgsql.NpgsqlDataAdapter daLands = new Npgsql.NpgsqlDataAdapter(landsCommand);
            Npgsql.NpgsqlDataAdapter daCrops = new Npgsql.NpgsqlDataAdapter(cropsCommand);
            Npgsql.NpgsqlDataAdapter daAnimals = new Npgsql.NpgsqlDataAdapter(animalsCommand);

            DataSet ds = new DataSet();
            ds.Tables.Add("AdministrativeData");
            ds.Tables.Add("Lands");
            ds.Tables.Add("Crops");
            ds.Tables.Add("Animals");
            try
            {
                connection.Open();
                da.Fill(ds.Tables["AdministrativeData"]);
                daLands.Fill(ds.Tables["Lands"]);
                daCrops.Fill(ds.Tables["Crops"]);
                daAnimals.Fill(ds.Tables["Animals"]);
                ds.Tables["AdministrativeData"].ChildRelations.Add(new DataRelation("FarmerLands", ds.Tables["AdministrativeData"].Columns["id"], ds.Tables["Lands"].Columns["id"], true));
                ds.Tables["AdministrativeData"].ChildRelations.Add(new DataRelation("FarmerCrops", ds.Tables["AdministrativeData"].Columns["id"], ds.Tables["Crops"].Columns["id"], true));
                ds.Tables["AdministrativeData"].ChildRelations.Add(new DataRelation("FarmerAnimals", ds.Tables["AdministrativeData"].Columns["id"], ds.Tables["Animals"].Columns["id"], true));
            }
            finally
            {
                connection.Close();
            }
            
            DataSetMapper<FarmerType> routesMapper = CreateFarmerMap(accessMatrix);
            FarmerType result = new FarmerType();
            routesMapper.Map(ds, result);
           
            return
                   SigningUtils.CreateAndSign(
                       argument,
                       result,
                       accessMatrix,
                       aditionalParameters
                   );
            }
            catch (Exception ex)
            {
                LogError(aditionalParameters, ex, new { Guid = id });
                throw;
            }
        
        }

        private static DataSetMapper<FarmerType> CreateFarmerMap(AccessMatrix accessMatrix)
        {
            DataSetMapper<FarmerType> farmerMapper = new DataSetMapper<FarmerType>(accessMatrix);

            farmerMapper.AddDataSetObjectInitializer((ds) => (ds.Tables["AdministrativeData"].Rows.Count == 1) ? ds.Tables["AdministrativeData"].Rows[0] : null);

            farmerMapper.AddDataColumnMap((f) => f.AdministrativeData.ActiveRegistration.RegistrationDate, "registrationdate");
            farmerMapper.AddDataColumnMap((f) => f.AdministrativeData.CancelledRegistration.CancelledDate, "cancellationdate");
            farmerMapper.AddDataColumnMap((f) => f.AdministrativeData.Entity.CompanyName, "companyname");
            farmerMapper.AddDataColumnMap((f) => f.AdministrativeData.Entity.LegalStatus, "leagalstatus", (o) => o.ToString());
            farmerMapper.AddDataColumnMap((f) => f.AdministrativeData.Person.Name, "name");
            farmerMapper.AddDataColumnMap((f) => f.AdministrativeData.Person.Surname, "surname");
            farmerMapper.AddDataColumnMap((f) => f.AdministrativeData.Person.Family, "family");

            farmerMapper.AddDataRowMap((f) => f.Animals, (dr) => dr.GetChildRows("FarmerAnimals"));
            farmerMapper.AddDataColumnMap((f) => f.Animals[0].AnimalCode, "AnimalCode");
            farmerMapper.AddDataColumnMap((f) => f.Animals[0].AnimalName, "AnimalName", (o) => o.ToString());
            farmerMapper.AddDataColumnMap((f) => f.Animals[0].EKKATE, "ekkate", (o) => o.ToString());
            farmerMapper.AddDataColumnMap((f) => f.Animals[0].Units, "Units");

            farmerMapper.AddDataRowMap((f) => f.Crops, (dr) => dr.GetChildRows("FarmerCrops"));
            farmerMapper.AddDataColumnMap((f) => f.Crops[0].CropCode, "CropCode");
            farmerMapper.AddDataColumnMap((f) => f.Crops[0].CropName, "CropName", (o) => o.ToString());
            farmerMapper.AddDataColumnMap((f) => f.Crops[0].EKKATE, "ekkate", (o) => o.ToString());
            farmerMapper.AddDataColumnMap((f) => f.Crops[0].IntendedSownAreaNextYear, "IntendedSownAreaNextYear");
            farmerMapper.AddDataColumnMap((f) => f.Crops[0].SownArea, "SownArea");

            farmerMapper.AddDataRowMap((f) => f.Lands, (dr) => dr.GetChildRows("FarmerLands"));
            farmerMapper.AddDataColumnMap((f) => f.Lands[0].EKKATE, "ekkate", (o) => o.ToString());
            farmerMapper.AddDataColumnMap((f) => f.Lands[0].Infield, "infield");

            return farmerMapper;
        }
    }
}
