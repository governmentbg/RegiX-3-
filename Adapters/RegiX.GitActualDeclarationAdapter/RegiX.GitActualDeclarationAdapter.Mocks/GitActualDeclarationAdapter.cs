namespace TechnoLogica.RegiX.GitActualDeclarationAdapter.AdapterService
{
    //public class GitActualDeclarationAdapter : SQLServerAdapterService.SQLServerAdapterService, IGitActualDeclarationAdapter, IAdapterService
    //{
    //    [Export(typeof(ParameterInfo))]
    //    public static ParameterInfo<string> ProcedureName =
    //        new ParameterInfo<string>("[usp_Deklaracia15_sel]")
    //        {
    //            Key = "ProcedureName",
    //            Description = "the procedure which is called",
    //            OwnerAssembly = typeof(GitActualDeclarationAdapter).Assembly
    //        };

    //    [Export(typeof(ParameterInfo))]
    //    public static ParameterInfo<string> ConnectionString =
    //        new ParameterInfo<string>(@"data source=;initial catalog=regix2MockDb;user id=;password=;")
    //        {
    //            Key = Constants.ConnectionStringParameterKeyName,
    //            Description = "Connection string",
    //            OwnerAssembly = typeof(GitActualDeclarationAdapter).Assembly
    //        };

    //    [Export(typeof(ParameterInfo))]
    //    public static ParameterInfo<string> MViewsUser =
    //        new ParameterInfo<string>("[dbo]")
    //        {
    //            Key = "MViewsUser",
    //            Description = "Name of user where MViews are created",
    //            OwnerAssembly = typeof(GitActualDeclarationAdapter).Assembly
    //        };

    //    public CommonSignedResponse<AuthenticityExplosivesRequestType, RZZBUTDeclaration> GetActualDeclaration(AuthenticityExplosivesRequestType argument, AccessMatrix accessMatrix, AdapterAdditionalParameters aditionalParameters)
    //    {
    //        Guid id = Guid.NewGuid();
    //        LogData(aditionalParameters, new { Request = argument.Serialize(), Guid = id });
    //        Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
    //        try
    //        {
    //            RZZBUTDeclaration result = new RZZBUTDeclaration();
    //            if (argument.DeclaratorIdentifier != null)
    //            {
    //                result = (RZZBUTDeclaration)FileUtils.ReadXml("\\XMLData\\test.xml", typeof(RZZBUTDeclaration));
    //            }
    //            else
    //            {
    //                result = (RZZBUTDeclaration)FileUtils.ReadXml("\\XMLData\\empty.xml", typeof(RZZBUTDeclaration));
    //            }

    //            return
    //                SigningUtils.CreateAndSign(
    //                    argument,
    //                    result,
    //                    accessMatrix,
    //                    aditionalParameters
    //                );

    //        }
    //        catch (Exception ex)
    //        {
    //            LogError(aditionalParameters, ex, new { Guid = id });
    //            throw ex;
    //        }


    //    }

    //    private void FillHelpTables(DataSet ds)
    //    {
    //        DataRow row = (ds.Tables[ProcedureName.Value].Rows.Count >= 1) ? ds.Tables[0].Select("not VALIDNA_DO is null").OrderByDescending((x) => x["VALIDNA_DO"]).FirstOrDefault() : null;

    //        this.FillPersonsAndDevisions(ds, row["upravliavashti"].ToString(), row["podrazdelenia"].ToString(), "EnterpriseUnits");
    //        this.FillActivities(ds, row["kid"].ToString(), "EnterpriseActivities");
    //        this.FillRests(ds, row["pochivki"].ToString(), "RegulatedRests");
    //        this.FillAgents(ds, row["p2_11"].ToString(), "DangerousCancerAgents");
    //        this.FillAgents(ds, row["p2_4"].ToString(), "DangerousChemicalAgents");
    //    }

    //    private void FillRests(DataSet ds, string xml, string tableName)
    //    {
    //        var r = new XmlDocument();
    //        r.InnerXml = string.Format("<root>{0}</root>", xml);

    //        var currentTable = ds.Tables[tableName];
    //        currentTable.Columns.Add("procent", typeof(double));
    //        currentTable.Columns.Add("BROI_RABOTESHTI", typeof(int));

    //        foreach (var item in r.DocumentElement.ChildNodes)
    //        {
    //            var node = (item as XmlElement);
    //            double procent = node.GetElementsByTagName("procent")[0] == null ? 0 :
    //                double.Parse(node.GetElementsByTagName("procent")[0].InnerText);
    //            int broi = node.GetElementsByTagName("BROI_RABOTESHTI")[0] == null ? 0 :
    //                int.Parse(node.GetElementsByTagName("BROI_RABOTESHTI")[0].InnerText);

    //            DataRow row = currentTable.NewRow();
    //            row["procent"] = procent;
    //            row["BROI_RABOTESHTI"] = broi;

    //            currentTable.Rows.Add(row);
    //        }
    //    }

    //    private void FillAgents(DataSet ds, string xml, string tableName)
    //    {
    //        var r = new XmlDocument();
    //        r.InnerXml = string.Format("<root>{0}</root>", xml);

    //        var currentTable = ds.Tables[tableName];
    //        currentTable.Columns.Add("CAS_NOMER", typeof(string));
    //        currentTable.Columns.Add("CAS_HIM_AGENT", typeof(string));
    //        currentTable.Columns.Add("BROI", typeof(int));

    //        foreach (var item in r.DocumentElement.ChildNodes)
    //        {
    //            var node = (item as XmlElement);
    //            string casNomer = node.GetElementsByTagName("CAS_NOMER")[0] == null ? null :
    //                node.GetElementsByTagName("CAS_NOMER")[0].InnerText;
    //            string himAgent = node.GetElementsByTagName("CAS_HIM_AGENT")[0] == null ? null :
    //                node.GetElementsByTagName("CAS_HIM_AGENT")[0].InnerText;
    //            int broi = node.GetElementsByTagName("BROI")[0] == null ? 0 :
    //                int.Parse(node.GetElementsByTagName("BROI")[0].InnerText);

    //            DataRow row = currentTable.NewRow();
    //            row["CAS_NOMER"] = casNomer;
    //            row["CAS_HIM_AGENT"] = himAgent;
    //            row["BROI"] = broi;

    //            currentTable.Rows.Add(row);
    //        }
    //    }

    //    private void FillActivities(DataSet ds, string xml, string tableName)
    //    {
    //        var r = new XmlDocument();
    //        r.InnerXml = string.Format("<root>{0}</root>", xml);

    //        var currentTable = ds.Tables[tableName];
    //        currentTable.Columns.Add("KID_KOD", typeof(string));
    //        currentTable.Columns.Add("KID_TEKST", typeof(string));

    //        foreach (var item in r.DocumentElement.ChildNodes)
    //        {
    //            var node = (item as XmlElement);
    //            string code = node.GetElementsByTagName("KID_KOD")[0] == null ? null :
    //                node.GetElementsByTagName("KID_KOD")[0].InnerText;
    //            string codeText = node.GetElementsByTagName("KID_TEKST")[0] == null ? null :
    //                node.GetElementsByTagName("KID_TEKST")[0].InnerText;

    //            DataRow row = currentTable.NewRow();
    //            row["KID_KOD"] = code;
    //            row["KID_TEKST"] = codeText;

    //            currentTable.Rows.Add(row);
    //        }
    //    }

    //    private void FillPersonsAndDevisions(DataSet ds, string personsXml, string devisionsXml, string tableName)
    //    {
    //        var doc = new XmlDocument();
    //        doc.InnerXml = string.Format("<root>{0}</root>", personsXml);

    //        var currentTable = ds.Tables[tableName];
    //        currentTable.Columns.Add("IMENA", typeof(string));
    //        currentTable.Columns.Add("DLAJNOST", typeof(string));
    //        currentTable.Columns.Add("TELEFON", typeof(string));
    //        currentTable.Columns.Add("EMAIL", typeof(string));

    //        foreach (var item in doc.DocumentElement.ChildNodes)
    //        {
    //            var node = (item as XmlElement);
    //            string name = node.GetElementsByTagName("IMENA")[0] == null ? null :
    //                node.GetElementsByTagName("IMENA")[0].InnerText;
    //            string position = node.GetElementsByTagName("DLAJNOST")[0] == null ? null :
    //                node.GetElementsByTagName("DLAJNOST")[0].InnerText;
    //            string phone = node.GetElementsByTagName("TELEFON")[0] == null ? null :
    //                node.GetElementsByTagName("TELEFON")[0].InnerText;
    //            string email = node.GetElementsByTagName("EMAIL")[0] == null ? null :
    //                node.GetElementsByTagName("EMAIL")[0].InnerText;

    //            DataRow row = currentTable.NewRow();
    //            row["IMENA"] = name;
    //            row["DLAJNOST"] = position;
    //            row["TELEFON"] = phone;
    //            row["EMAIL"] = email;

    //            currentTable.Rows.Add(row);
    //        }

    //        doc.InnerXml = string.Format("<root>{0}</root>", devisionsXml);
    //        currentTable.Columns.Add("BROI_NAETI_LICA", typeof(int));
    //        currentTable.Columns.Add("DEINOST_KID", typeof(string));
    //        currentTable.Columns.Add("NAIMENOVANIE", typeof(string));
    //        currentTable.Columns.Add("APARTAMENT", typeof(string));
    //        currentTable.Columns.Add("OBLAST_CODE", typeof(string));
    //        currentTable.Columns.Add("VHOD", typeof(string));
    //        currentTable.Columns.Add("ETAJ", typeof(string));
    //        currentTable.Columns.Add("BLOK", typeof(string));
    //        currentTable.Columns.Add("JK", typeof(string));
    //        currentTable.Columns.Add("GRAD_CODE_EKKATE", typeof(string));

    //        int index = 0;
    //        foreach (var item in doc.DocumentElement.ChildNodes)
    //        {
    //            var node = (item as XmlElement);
    //            int count = node.GetElementsByTagName("BROI_NAETI_LICA")[0] == null ? 0 :
    //                int.Parse(node.GetElementsByTagName("BROI_NAETI_LICA")[0].InnerText);
    //            string kid = node.GetElementsByTagName("DEINOST_KID")[0] == null ? null :
    //                node.GetElementsByTagName("DEINOST_KID")[0].InnerText;
    //            string name = node.GetElementsByTagName("NAIMENOVANIE")[0] == null ? null :
    //                node.GetElementsByTagName("NAIMENOVANIE")[0].InnerText;
    //            string apartament = node.GetElementsByTagName("APARTAMENT")[0] == null ? null :
    //                node.GetElementsByTagName("APARTAMENT")[0].InnerText;
    //            string district = node.GetElementsByTagName("OBLAST_CODE")[0] == null ? null :
    //                node.GetElementsByTagName("OBLAST_CODE")[0].InnerText;
    //            string entrance = node.GetElementsByTagName("VHOD")[0] == null ? null :
    //                node.GetElementsByTagName("VHOD")[0].InnerText;
    //            string floor = node.GetElementsByTagName("ETAJ")[0] == null ? null :
    //                node.GetElementsByTagName("ETAJ")[0].InnerText;
    //            string blok = node.GetElementsByTagName("BLOK")[0] == null ? null :
    //                node.GetElementsByTagName("BLOK")[0].InnerText;
    //            string jk = node.GetElementsByTagName("JK")[0] == null ? null :
    //                node.GetElementsByTagName("JK")[0].InnerText;
    //            string city = node.GetElementsByTagName("GRAD_CODE_EKKATE")[0] == null ? null :
    //                node.GetElementsByTagName("GRAD_CODE_EKKATE")[0].InnerText;

    //            DataRow row = currentTable.Rows[index];
    //            row["BROI_NAETI_LICA"] = count;
    //            row["DEINOST_KID"] = kid;
    //            row["NAIMENOVANIE"] = name;
    //            row["APARTAMENT"] = apartament;
    //            row["OBLAST_CODE"] = district;
    //            row["VHOD"] = entrance;
    //            row["ETAJ"] = floor;
    //            row["BLOK"] = blok;
    //            row["JK"] = jk;
    //            row["GRAD_CODE_EKKATE"] = city;

    //            currentTable.AcceptChanges();
    //            index++;
    //        }
    //    }

    //    private DataSetMapper<RZZBUTDeclaration> CreateMap(AccessMatrix accessMatrix, string declaratorIdentifier)
    //    {
    //        // TODO : IV_3_OCENEN_RISK, IV_4_VIDEO_DISPLEI, IV_7_POCHIVKA, IV_6_VIBRACII, IV_5_SHUM should be bool?
    //        // where not sure -> COLUMN_NAME?
    //        DataSetMapper<RZZBUTDeclaration> mapper = new DataSetMapper<RZZBUTDeclaration>(accessMatrix);

    //        mapper.AddDataSetObjectInitializer((ds) => (ds.Tables[ProcedureName.Value].Rows.Count >= 1) ? ds.Tables[0].Select("not VALIDNA_DO is null").OrderByDescending((x) => x["VALIDNA_DO"]).FirstOrDefault() : null);

    //        mapper.AddConstantMap((r) => r.EmployerIdentifier, declaratorIdentifier);

    //        //ПРИЛОЖЕНИЕ 2, ЧАСТ ІІІ. АЗБЕСТ : yes to all
    //        mapper.AddDataColumnMap((r) => r.Appl2_CheminalCancerAsbestosAgentsData.AsbestosData.BorderlineMeasure, "P2_A_PREDPR_MERKI_TEKST");
    //        mapper.AddDataColumnMap((r) => r.Appl2_CheminalCancerAsbestosAgentsData.AsbestosData.BorderlineMeasureTaken, "P2_A_PREDPR_MERKI", (o) => ((o.Equals(0) || o == DBNull.Value) ? false : true));
    //        mapper.AddDataColumnMap((r) => r.Appl2_CheminalCancerAsbestosAgentsData.AsbestosData.EmployeeRegisterAvailable, "P2_A_REG_RABOTESHTI", (o) => ((o.Equals(0) || o == DBNull.Value) ? false : true));
    //        mapper.AddDataColumnMap((r) => r.Appl2_CheminalCancerAsbestosAgentsData.AsbestosData.EmployeeRegisteredCount, "P2_A_REG_RABOTESHTI_BROI");
    //        mapper.AddDataColumnMap((r) => r.Appl2_CheminalCancerAsbestosAgentsData.AsbestosData.HealthStatusEstimated, "P2_A_OCENKA_ZS", (o) => ((o.Equals(0) || o == DBNull.Value) ? false : true));
    //        mapper.AddDataColumnMap((r) => r.Appl2_CheminalCancerAsbestosAgentsData.AsbestosData.HealthStatusEstimationCount, "P2_A_OCENKA_ZS_BROI");
    //        mapper.AddDataColumnMap((r) => r.Appl2_CheminalCancerAsbestosAgentsData.AsbestosData.LabourInspectionNotified, "P2_A_OVED_IT_RIKOZ", (o) => ((o.Equals(0) || o == DBNull.Value) ? false : true));
    //        mapper.AddDataColumnMap((r) => r.Appl2_CheminalCancerAsbestosAgentsData.AsbestosData.LicenseIssued, "P2_A_RAZRESH_DEMONTAJ", (o) => ((o.Equals(0) || o == DBNull.Value) ? false : true));
    //        mapper.AddDataColumnMap((r) => r.Appl2_CheminalCancerAsbestosAgentsData.AsbestosData.RiskEstimated, "P2_A_RISK_EKSPOZICIA", (o) => ((o.Equals(0) || o == DBNull.Value) ? false : true));
    //        mapper.AddDataColumnMap((r) => r.Appl2_CheminalCancerAsbestosAgentsData.AsbestosData.TrainingProvided, "P2_A_OBUCHENIE", (o) => ((o.Equals(0) || o == DBNull.Value) ? false : true));
    //        mapper.AddDataColumnMap((r) => r.Appl2_CheminalCancerAsbestosAgentsData.AsbestosUsed, "P2_AZBEST", (o) => ((o.Equals(0) || o == DBNull.Value) ? false : true));

    //        //ПРИЛОЖЕНИЕ 2, ЧАСТ ІІ. КАНЦЕРОГЕНИ И МУТАГЕНИ : yes to all
    //        mapper.AddDataColumnMap((r) => r.Appl2_CheminalCancerAsbestosAgentsData.CancerAgentsData.BorderlineCorresponding, "P2_KM_GRAN_STOINOSTI", (o) => ((o.Equals(0) || o == DBNull.Value) ? false : true));
    //        mapper.AddDataColumnMap((r) => r.Appl2_CheminalCancerAsbestosAgentsData.CancerAgentsData.ClosedProductionMeasure, "P2_KM_ZATV_SISTEMA_TEXT");
    //        mapper.AddDataColumnMap((r) => r.Appl2_CheminalCancerAsbestosAgentsData.CancerAgentsData.ClosedProductionSet, "P2_KM_ZATV_SISTEMA", (o) => ((o.Equals(0) || o == DBNull.Value) ? false : true));
    //        mapper.AddDataColumnMap((r) => r.Appl2_CheminalCancerAsbestosAgentsData.CancerAgentsData.EmployeeListedCount, "P2_KM_OPASTNOST_EKSPL_BROI");
    //        mapper.AddDataColumnMap((r) => r.Appl2_CheminalCancerAsbestosAgentsData.CancerAgentsData.ExposureDecreased, "P2_KM_NAM_EKSPOZICIA", (o) => ((o.Equals(0) || o == DBNull.Value) ? false : true));
    //        mapper.AddDataColumnMap((r) => r.Appl2_CheminalCancerAsbestosAgentsData.CancerAgentsData.ExposureDecreaseMeasure, "P2_KM_NAM_EKSPOZICIA_TEXT");
    //        mapper.AddDataColumnMap((r) => r.Appl2_CheminalCancerAsbestosAgentsData.CancerAgentsData.ExposureEsitamted, "P2_KM_OCENKA_RISK_EKSP", (o) => ((o.Equals(0) || o == DBNull.Value) ? false : true));
    //        mapper.AddDataColumnMap((r) => r.Appl2_CheminalCancerAsbestosAgentsData.CancerAgentsData.GeneralSecurityMeasure, "P2_KM_KOL_SR_ZASHTITA_TEXT");
    //        mapper.AddDataColumnMap((r) => r.Appl2_CheminalCancerAsbestosAgentsData.CancerAgentsData.GeneralSecuritySet, "P2_KM_KOL_SR_ZASHTITA", (o) => ((o.Equals(0) || o == DBNull.Value) ? false : true));
    //        mapper.AddDataColumnMap((r) => r.Appl2_CheminalCancerAsbestosAgentsData.CancerAgentsData.OtherMeasure, "P2_KM_DRUGI_TEXT");
    //        mapper.AddDataColumnMap((r) => r.Appl2_CheminalCancerAsbestosAgentsData.CancerAgentsData.OtherMeasureSet, "P2_KM_DRUGI", (o) => ((o.Equals(0) || o == DBNull.Value) ? false : true));
    //        mapper.AddDataColumnMap((r) => r.Appl2_CheminalCancerAsbestosAgentsData.CancerAgentsData.PersonalPreventionMeasure, "P2_KM_LPS_TEXT");
    //        mapper.AddDataColumnMap((r) => r.Appl2_CheminalCancerAsbestosAgentsData.CancerAgentsData.PersonalPreventionSet, "P2_KM_LPS", (o) => ((o.Equals(0) || o == DBNull.Value) ? false : true));
    //        mapper.AddDataColumnMap((r) => r.Appl2_CheminalCancerAsbestosAgentsData.CancerAgentsData.PreventionMeasureNotTaken, "P2_KM_NIAMA_PREDPR_MERKI", (o) => ((o.Equals(0) || o == DBNull.Value) ? false : true));
    //        mapper.AddDataColumnMap((r) => r.Appl2_CheminalCancerAsbestosAgentsData.CancerAgentsData.ReplacementMeasure, "P2_KM_MERKI_NAM_RISK_TEXT");
    //        mapper.AddDataColumnMap((r) => r.Appl2_CheminalCancerAsbestosAgentsData.CancerAgentsData.ReplacementSupplied, "P2_KM_MERKI_NAM_RISK", (o) => ((o.Equals(0) || o == DBNull.Value) ? false : true));
    //        mapper.AddDataColumnMap((r) => r.Appl2_CheminalCancerAsbestosAgentsData.CancerAgentsData.TrainingProvided, "P2_KM_OSIG_OBUCH", (o) => ((o.Equals(0) || o == DBNull.Value) ? false : true));
    //        mapper.AddDataColumnMap((r) => r.Appl2_CheminalCancerAsbestosAgentsData.CancerAgentsData.UpdatedEmployeeList, "P2_KM_OPASTNOST_EKSPL", (o) => ((o.Equals(0) || o == DBNull.Value) ? false : true));
    //        mapper.AddDataColumnMap((r) => r.Appl2_CheminalCancerAsbestosAgentsData.CancerAgentsData.WarningSignsProvided, "P2_KM_OSIG_ETIKIRANE", (o) => ((o.Equals(0) || o == DBNull.Value) ? false : true));
    //        mapper.AddDataColumnMap((r) => r.Appl2_CheminalCancerAsbestosAgentsData.CancerAgentsUsed, "P2_KACEROGENI_MUTAGENI", (o) => ((o.Equals(0) || o == DBNull.Value) ? false : true));

    //        mapper.AddDataRowMap((r) => r.Appl2_CheminalCancerAsbestosAgentsData.CancerAgentsData.DangerousCancerAgents, (dr) => dr.Table.DataSet.Tables["DangerousCancerAgents"].Rows);
    //        mapper.AddDataColumnMap((r) => r.Appl2_CheminalCancerAsbestosAgentsData.CancerAgentsData.DangerousCancerAgents[0].CASNumber, "CAS_NOMER");
    //        mapper.AddDataColumnMap((r) => r.Appl2_CheminalCancerAsbestosAgentsData.CancerAgentsData.DangerousCancerAgents[0].ChemicalAgentName, "CAS_HIM_AGENT");
    //        mapper.AddDataColumnMap((r) => r.Appl2_CheminalCancerAsbestosAgentsData.CancerAgentsData.DangerousCancerAgents[0].EmployeeExposedCount, "BROI");

    //        //ПРИЛОЖЕНИЕ 2, ЧАСТ І. ХИМИЧНИ АГЕНТИ : yes to all
    //        mapper.AddDataColumnMap((r) => r.Appl2_CheminalCancerAsbestosAgentsData.ChemicalAgentsData.ActionPlanPrepared, "P2_PLAN_PREDOTV_AVARII", (o) => ((o.Equals(0) || o == DBNull.Value) ? false : true));
    //        mapper.AddDataColumnMap((r) => r.Appl2_CheminalCancerAsbestosAgentsData.ChemicalAgentsData.ChemicalAgentsQuantityRestricted, "P2_OGR_HIM_AG", (o) => ((o.Equals(0) || o == DBNull.Value) ? false : true));
    //        mapper.AddDataColumnMap((r) => r.Appl2_CheminalCancerAsbestosAgentsData.ChemicalAgentsData.ChemicalAgentsQuatityMeasure, "P2_OGR_HIM_AG_TEXT");
    //        mapper.AddDataColumnMap((r) => r.Appl2_CheminalCancerAsbestosAgentsData.ChemicalAgentsData.EmployeeCountResticted, "P2_OGR_BROI_RAB", (o) => ((o.Equals(0) || o == DBNull.Value) ? false : true));
    //        mapper.AddDataColumnMap((r) => r.Appl2_CheminalCancerAsbestosAgentsData.ChemicalAgentsData.EmployeeRestrictionMeasure, "P2_OGR_BROI_RAB_TEXT");
    //        mapper.AddDataColumnMap((r) => r.Appl2_CheminalCancerAsbestosAgentsData.ChemicalAgentsData.ExposureDurationDecreased, "P2_NAMAL_PRODALJ", (o) => ((o.Equals(0) || o == DBNull.Value) ? false : true));
    //        mapper.AddDataColumnMap((r) => r.Appl2_CheminalCancerAsbestosAgentsData.ChemicalAgentsData.ExposureDurationMeasure, "P2_NAMAL_PRODALJ_TEXT");
    //        mapper.AddDataColumnMap((r) => r.Appl2_CheminalCancerAsbestosAgentsData.ChemicalAgentsData.GeneralSecurityMeasure, "P2_MERKI_KOL_ZASHT_TEXT");
    //        mapper.AddDataColumnMap((r) => r.Appl2_CheminalCancerAsbestosAgentsData.ChemicalAgentsData.GeneralSecuritySet, "P2_MERKI_KOL_ZASHT", (o) => ((o.Equals(0) || o == DBNull.Value) ? false : true));
    //        mapper.AddDataColumnMap((r) => r.Appl2_CheminalCancerAsbestosAgentsData.ChemicalAgentsData.HealthcareCount, "P2_ZDRAVNO_NABL_BROI");
    //        mapper.AddDataColumnMap((r) => r.Appl2_CheminalCancerAsbestosAgentsData.ChemicalAgentsData.HealthcareProvided, "P2_ZDRAVNO_NABL", (o) => ((o.Equals(0) || o == DBNull.Value) ? false : true));
    //        mapper.AddDataColumnMap((r) => r.Appl2_CheminalCancerAsbestosAgentsData.ChemicalAgentsData.OtherMeasure, "P2_DRUGI_TEXT");
    //        mapper.AddDataColumnMap((r) => r.Appl2_CheminalCancerAsbestosAgentsData.ChemicalAgentsData.OtherMeasureSet, "P2_DRUGI", (o) => ((o.Equals(0) || o == DBNull.Value) ? false : true));
    //        mapper.AddDataColumnMap((r) => r.Appl2_CheminalCancerAsbestosAgentsData.ChemicalAgentsData.PeriodicTestDone, "P2_PERIOD_IZMERV", (o) => ((o.Equals(0) || o == DBNull.Value) ? false : true));
    //        mapper.AddDataColumnMap((r) => r.Appl2_CheminalCancerAsbestosAgentsData.ChemicalAgentsData.PersonalPreventionMeasure, "P2_LPS_TEXT");
    //        mapper.AddDataColumnMap((r) => r.Appl2_CheminalCancerAsbestosAgentsData.ChemicalAgentsData.PersonalPreventionSet, "P2_LPS", (o) => ((o.Equals(0) || o == DBNull.Value) ? false : true));
    //        mapper.AddDataColumnMap((r) => r.Appl2_CheminalCancerAsbestosAgentsData.ChemicalAgentsData.PreventionMeasureNotTaken, "P2_NE_SA_PREDPR_MERKI", (o) => ((o.Equals(0) || o == DBNull.Value) ? false : true));
    //        mapper.AddDataColumnMap((r) => r.Appl2_CheminalCancerAsbestosAgentsData.ChemicalAgentsData.ProcedureManagementMeasure, "P2_SAHR_TRANSP_TEXT");
    //        mapper.AddDataColumnMap((r) => r.Appl2_CheminalCancerAsbestosAgentsData.ChemicalAgentsData.ProcedureManagementSet, "P2_SAHR_TRANSP", (o) => ((o.Equals(0) || o == DBNull.Value) ? false : true));
    //        mapper.AddDataColumnMap((r) => r.Appl2_CheminalCancerAsbestosAgentsData.ChemicalAgentsData.ReplacementMeasure, "P2_IZP_BEZOP_RPOC_TEXT");
    //        mapper.AddDataColumnMap((r) => r.Appl2_CheminalCancerAsbestosAgentsData.ChemicalAgentsData.ReplacementSupplied, "P2_IZP_BEZOP_RPOC", (o) => ((o.Equals(0) || o == DBNull.Value) ? false : true));
    //        mapper.AddDataColumnMap((r) => r.Appl2_CheminalCancerAsbestosAgentsData.ChemicalAgentsData.RiskEstimated, "P2_OCENKA_RISK", (o) => ((o.Equals(0) || o == DBNull.Value) ? false : true));
    //        mapper.AddDataColumnMap((r) => r.Appl2_CheminalCancerAsbestosAgentsData.ChemicalAgentsData.SafetyIndexBox, "P2_KARTOTEKA_ILB", (o) => ((o.Equals(0) || o == DBNull.Value) ? false : true));
    //        mapper.AddDataColumnMap((r) => r.Appl2_CheminalCancerAsbestosAgentsData.ChemicalAgentsData.TrainingProvided, "P2_OSIG_OBUCHENIE", (o) => ((o.Equals(0) || o == DBNull.Value) ? false : true));
    //        mapper.AddDataColumnMap((r) => r.Appl2_CheminalCancerAsbestosAgentsData.ChemicalAgentsUsed, "P2_HIM_AGENTI");

    //        mapper.AddDataRowMap((r) => r.Appl2_CheminalCancerAsbestosAgentsData.ChemicalAgentsData.DangerousChemicalAgents, (dr) => dr.Table.DataSet.Tables["DangerousChemicalAgents"].Rows);
    //        mapper.AddDataColumnMap((r) => r.Appl2_CheminalCancerAsbestosAgentsData.ChemicalAgentsData.DangerousChemicalAgents[0].CASNumber, "CAS_NOMER");
    //        mapper.AddDataColumnMap((r) => r.Appl2_CheminalCancerAsbestosAgentsData.ChemicalAgentsData.DangerousChemicalAgents[0].ChemicalAgentName, "CAS_HIM_AGENT");
    //        mapper.AddDataColumnMap((r) => r.Appl2_CheminalCancerAsbestosAgentsData.ChemicalAgentsData.DangerousChemicalAgents[0].EmployeeExposedCount, "BROI");

    //        //4. Лице за контакти:
    //        mapper.AddDataColumnMap((r) => r.ContactPerson.Email, "I_LK_EMAIL");
    //        mapper.AddDataColumnMap((r) => r.ContactPerson.FirstMiddleLastName, "I_LK_IMENA");
    //        mapper.AddDataColumnMap((r) => r.ContactPerson.Phone, "I_LK_TEL_FAKS");
    //        mapper.AddDataColumnMap((r) => r.ContactPerson.Position, "I_LK_DLAJNOST");

    //        mapper.AddDataColumnMap((r) => r.DeclaredYear, "GODINA");

    //        //16. Документирана оценка на рисковете за безопасността и здравето на работещите
    //        mapper.AddDataColumnMap((r) => r.DocumentedEstimation, "III_16", (o) => ((o.Equals(0) || o == DBNull.Value) ? false : true));

    //        //1. Наименование/име на юридическото и физическото лице, което:
    //        mapper.AddDataColumnMap((r) => r.EmployerEntityName, "I_NAIMENOVANIE_UL");
    //        mapper.AddDataColumnMap((r) => r.EmployerHiring, "I_SAMOSTO_NAEMAT_RAB", (o) => ((o.Equals(0) || o == DBNull.Value) ? false : true));
    //        mapper.AddDataColumnMap((r) => r.EmployerIdentifier, "I_EIK");
    //        mapper.AddDataColumnMap((r) => r.EmployerPersonFullName, "I_IMENA_FL");
    //        mapper.AddDataColumnMap((r) => r.EmployerTemporaryWork, "I_ZAEMANI_RABOTNICI", (o) => ((o.Equals(0) || o == DBNull.Value) ? false : true));

    //        //7. Основна и спомагателна дейност съгласно Класификатора на икономическите дейности (КИД 2008)
    //        mapper.AddDataRowMap((r) => r.EnterpriseActivity, (dr) => dr.Table.DataSet.Tables["EnterpriseActivities"].Rows);
    //        mapper.AddDataColumnMap((r) => r.EnterpriseActivity[0].KIDCode, "KID_KOD");
    //        mapper.AddDataColumnMap((r) => r.EnterpriseActivity[0].KIDDescription, "KID_TEKST");

    //        //5. РАЗДЕЛ ІІ. ДАННИ ЗА ПРЕДПРИЯТИЕТО:
    //        mapper.AddDataColumnMap((r) => r.EnterpriseName, "II_NAIMENOVANIE");
    //        mapper.AddDataColumnMap((r) => r.EnterpriseAddress.Town, "II_GRAD_CODE_EKKATE");
    //        mapper.AddDataColumnMap((r) => r.EnterpriseAddress.District, "II_OBLAST_CODE", (o) => o.ToString()); // код, който съответства на кодове от файл KODOVE-GR-OB-OBL.xlsx(така пише в мейла)
    //        mapper.AddDataColumnMap((r) => r.EnterpriseAddress.Apartment, "II_BLOK_APARTAMENT");
    //        mapper.AddDataColumnMap((r) => r.EnterpriseAddress.Email, "II_EMAIL");
    //        mapper.AddDataColumnMap((r) => r.EnterpriseAddress.Entrance, "II_BLOK_VHOD");
    //        mapper.AddDataColumnMap((r) => r.EnterpriseAddress.Floor, "II_BLOK_ETAJ");
    //        mapper.AddDataColumnMap((r) => r.EnterpriseAddress.Municipality, "II_OBSHTINA");
    //        mapper.AddDataColumnMap((r) => r.EnterpriseAddress.Phone, "II_TELEFON");
    //        mapper.AddDataColumnMap((r) => r.EnterpriseAddress.PostCode, "II_POSHTENSKI_KOD");
    //        mapper.AddDataColumnMap((r) => r.EnterpriseAddress.ResidenceBlock, "II_BLOK_NO");
    //        mapper.AddDataColumnMap((r) => r.EnterpriseAddress.Street, "II_ULICA");
    //        mapper.AddDataColumnMap((r) => r.EnterpriseAddress.Suburb, "II_JILISHTEN_KOMPLEKS");

    //        //6.Ръководител на предприятието
    //        mapper.AddDataColumnMap((r) => r.EnterpriseManager.Email, "II_RAKOVODITEL_EMAIL");
    //        mapper.AddDataColumnMap((r) => r.EnterpriseManager.FirstMiddleLastName, "II_RAKOVODITEL_IMENA");
    //        mapper.AddDataColumnMap((r) => r.EnterpriseManager.Phone, "II_RAKOVODITEL_TELEFON");
    //        mapper.AddDataColumnMap((r) => r.EnterpriseManager.Position, "II_RAKOVODITEL_DLAJNOST");

    //        //9. Големина на предприятието според средносписъчния брой на персонала 
    //        mapper.AddDataColumnMap((r) => r.EnterpriseStaffSizeInterval, "II_IS_PODRAZDELENIA");

    //        //8. Поделения на предприятието извън адреса по т. 5
    //        mapper.AddDataColumnMap((r) => r.EnterpriseUnitAvailable, "II_PERSONAL_BROI", (o) => ((o.Equals(0) || o == DBNull.Value) ? false : true));

    //        // Column "ADRES" is not used in our mapping, but it is in the procedure
    //        mapper.AddDataRowMap((r) => r.EnterpriseUnit, (dr) => dr.Table.DataSet.Tables["EnterpriseUnits"].Rows);
    //        mapper.AddDataColumnMap((r) => r.EnterpriseUnit[0].EmployeeCount, "BROI_NAETI_LICA");
    //        mapper.AddDataColumnMap((r) => r.EnterpriseUnit[0].EnterpriseKIDCode, "DEINOST_KID");
    //        mapper.AddDataColumnMap((r) => r.EnterpriseUnit[0].EnterpriseUnitName, "NAIMENOVANIE");
    //        mapper.AddDataColumnMap((r) => r.EnterpriseUnit[0].EnterpriseUnitAddress.Apartment, "APARTAMENT");
    //        mapper.AddDataColumnMap((r) => r.EnterpriseUnit[0].EnterpriseUnitAddress.District, "OBLAST_CODE");
    //        mapper.AddDataColumnMap((r) => r.EnterpriseUnit[0].EnterpriseUnitAddress.Entrance, "VHOD");
    //        mapper.AddDataColumnMap((r) => r.EnterpriseUnit[0].EnterpriseUnitAddress.Floor, "ETAJ");
    //        //mapper.AddDataColumnMap((r) => r.EnterpriseUnit[0].EnterpriseUnitAddress.Email, ""); // Mising in procedure
    //        //mapper.AddDataColumnMap((r) => r.EnterpriseUnit[0].EnterpriseUnitAddress.Municipality, "");
    //        //mapper.AddDataColumnMap((r) => r.EnterpriseUnit[0].EnterpriseUnitAddress.Phone, "");
    //        //mapper.AddDataColumnMap((r) => r.EnterpriseUnit[0].EnterpriseUnitAddress.PostCode, "");
    //        //mapper.AddDataColumnMap((r) => r.EnterpriseUnit[0].EnterpriseUnitAddress.Street, "");
    //        mapper.AddDataColumnMap((r) => r.EnterpriseUnit[0].EnterpriseUnitAddress.ResidenceBlock, "BLOK");
    //        mapper.AddDataColumnMap((r) => r.EnterpriseUnit[0].EnterpriseUnitAddress.Suburb, "JK");
    //        mapper.AddDataColumnMap((r) => r.EnterpriseUnit[0].EnterpriseUnitAddress.Town, "GRAD_CODE_EKKATE");

    //        mapper.AddDataColumnMap((r) => r.EnterpriseUnit[0].EnterpriseUnitManager.Email, "EMAIL");
    //        mapper.AddDataColumnMap((r) => r.EnterpriseUnit[0].EnterpriseUnitManager.FirstMiddleLastName, "IMENA");
    //        mapper.AddDataColumnMap((r) => r.EnterpriseUnit[0].EnterpriseUnitManager.Phone, "TELEFON");
    //        mapper.AddDataColumnMap((r) => r.EnterpriseUnit[0].EnterpriseUnitManager.Position, "DLAJNOST");

    //        //2. РАЗДЕЛ І. ДАННИ ЗА РАБОТОДАТЕЛЯ
    //        mapper.AddDataColumnMap((r) => r.HeadquarterAddress.Town, "I_GRAD_CODE_EKKATE");
    //        mapper.AddDataColumnMap((r) => r.HeadquarterAddress.District, "I_OBLAST_CODE", (o) => o.ToString()); // код, който съответства на кодове от файл KODOVE-GR-OB-OBL.xlsx
    //        mapper.AddDataColumnMap((r) => r.HeadquarterAddress.Apartment, "I_BLOK_APARTAMENT");
    //        mapper.AddDataColumnMap((r) => r.HeadquarterAddress.Email, "I_EMAIL");
    //        mapper.AddDataColumnMap((r) => r.HeadquarterAddress.Entrance, "I_BLOK_VHOD");
    //        mapper.AddDataColumnMap((r) => r.HeadquarterAddress.Floor, "I_BLOK_ETAJ");
    //        mapper.AddDataColumnMap((r) => r.HeadquarterAddress.Municipality, "I_OBSHTINA");
    //        mapper.AddDataColumnMap((r) => r.HeadquarterAddress.Phone, "I_TELEFON");
    //        mapper.AddDataColumnMap((r) => r.HeadquarterAddress.PostCode, "I_POSHTENSKI_KOD");
    //        mapper.AddDataColumnMap((r) => r.HeadquarterAddress.ResidenceBlock, "I_BLOK_NO");
    //        mapper.AddDataColumnMap((r) => r.HeadquarterAddress.Street, "I_ULICA");
    //        mapper.AddDataColumnMap((r) => r.HeadquarterAddress.Suburb, "I_JILISHTEN_KOMPLEKS");

    //        //10.1. Работници и служители, наети по трудово/служебно правоотношение 
    //        mapper.AddDataColumnMap((r) => r.HiredEmployeesCount, "II_NAETI_O");
    //        mapper.AddDataColumnMap((r) => r.HiredMenCount, "II_NAETI_M");
    //        mapper.AddDataColumnMap((r) => r.HiredWomenCount, "II_NAETI_J");

    //        //0.
    //        mapper.AddDataColumnMap((r) => r.IssueDate, "VALIDNA_DO");
    //        mapper.AddDataColumnMap((r) => r.IncomingNumber, "VHODIASHT_NOMER");
    //        mapper.AddDataColumnMap((r) => r.InspectionName, "DIREKCIA_IT");

    //        //14. Учреден комитет и група/и по условия на труд (да/не)
    //        mapper.AddDataColumnMap((r) => r.LabourCommitteAndGroup, "III_14_3", (o) => ((o.Equals(0) || o == DBNull.Value) ? false : true));

    //        //14. Учреден комитет по условия на труд
    //        mapper.AddDataColumnMap((r) => r.LabourCommittee, "III_14_1", (o) => ((o.Equals(0) || o == DBNull.Value) ? false : true));

    //        //14. група по условия на труд
    //        mapper.AddDataColumnMap((r) => r.LabourGroup, "III_14_2", (o) => ((o.Equals(0) || o == DBNull.Value) ? false : true));

    //        //20. Провеждане на задължителни предварителни и периодични медицински прегледи
    //        mapper.AddDataColumnMap((r) => r.LabourMedicalVisit, "III_20", (o) => ((o.Equals(0) || o == DBNull.Value) ? false : true));

    //        //24. Опасности/източници на опасност, създаващи риск за здравето и безопасността на работещите, съгласно оценката на риска 
    //        mapper.AddDataColumnMap((r) => r.LabourConditions.AsbestosRiskCount, "IV_1_AZBEST_BROI");
    //        mapper.AddDataColumnMap((r) => r.LabourConditions.BiologicalAgentsRiskCount, "IV_1_BIOL_AGENTI_BROI");
    //        mapper.AddDataColumnMap((r) => r.LabourConditions.CancerRiskCount, "IV_1_KANCEROGENI_BROI");
    //        mapper.AddDataColumnMap((r) => r.LabourConditions.ChemicalAgentsRiskCount, "IV_1_HIM_AGENTI_BROI");
    //        mapper.AddDataColumnMap((r) => r.LabourConditions.ContsructionRiskAvailable, "IV_1_SKELETA", (o) => ((o.Equals(0) || o == DBNull.Value) ? false : true));
    //        mapper.AddDataColumnMap((r) => r.LabourConditions.DustRiskCount, "IV_1_PRAH_BROI");
    //        mapper.AddDataColumnMap((r) => r.LabourConditions.DutyWorkCount, "IV_1_DEJURSTVA_BROI");
    //        mapper.AddDataColumnMap((r) => r.LabourConditions.ElectricityRiskAvailable, "IV_1_ELTOK", (o) => ((o.Equals(0) || o == DBNull.Value) ? false : true));
    //        mapper.AddDataColumnMap((r) => r.LabourConditions.ElectromagneticRadiationRiskCount, "IV_1_ELMAG_BROI");
    //        mapper.AddDataColumnMap((r) => r.LabourConditions.ExplosivesRiskCount, "IV_1_VZRIV_BROI");
    //        mapper.AddDataColumnMap((r) => r.LabourConditions.FiresRiskCount, "IV_1_POJAR_BROI");
    //        mapper.AddDataColumnMap((r) => r.LabourConditions.HighVoltageRiskAvailable, "IV_1_EL_UREDBI", (o) => ((o.Equals(0) || o == DBNull.Value) ? false : true));
    //        mapper.AddDataColumnMap((r) => r.LabourConditions.HomeWorkPlacesCount, "IV_1_NADOMNI_RM");
    //        mapper.AddDataColumnMap((r) => r.LabourConditions.IlluminationRiskCount, "IV_1_OSVETENOST_BROI");
    //        mapper.AddDataColumnMap((r) => r.LabourConditions.IonizingRadiationRiskCount, "IV_1_ION_LACHENIA_BROI");
    //        mapper.AddDataColumnMap((r) => r.LabourConditions.LaserRadiationRiskCount, "IV_1_LAZERI_BROI");
    //        mapper.AddDataColumnMap((r) => r.LabourConditions.LiftingEquipmentRiskAvailable, "IV_1_POV_SAORAJENIA", (o) => ((o.Equals(0) || o == DBNull.Value) ? false : true));
    //        mapper.AddDataColumnMap((r) => r.LabourConditions.MachineEquipmentRiskAvailable, "IV_1_MASHINI", (o) => ((o.Equals(0) || o == DBNull.Value) ? false : true));
    //        mapper.AddDataColumnMap((r) => r.LabourConditions.MicroclimateRiskCount, "IV_1_MIKROKLIMAT_BROI");
    //        mapper.AddDataColumnMap((r) => r.LabourConditions.MobileWorkPlacesCount, "IV_1_PODVIJNI_RM");
    //        mapper.AddDataColumnMap((r) => r.LabourConditions.MovingPlatformRiskAvailable, "IV_1_PLATFORMI", (o) => ((o.Equals(0) || o == DBNull.Value) ? false : true));
    //        mapper.AddDataColumnMap((r) => r.LabourConditions.NanomaterialRiskCount, "IV_1_NANOMATERIALI_BROI");
    //        mapper.AddDataColumnMap((r) => r.LabourConditions.NightWorkCount, "IV_1_NOSHTEN_TRUD_BROI");
    //        mapper.AddDataColumnMap((r) => r.LabourConditions.NoiseRiskCount, "IV_1_SHUM_BROI");
    //        mapper.AddDataColumnMap((r) => r.LabourConditions.OnairWorkPlacesCount, "IV_1_RABOTA_VAZDUHA_O");
    //        mapper.AddDataColumnMap((r) => r.LabourConditions.OnairWorkPlacesMen, "IV_1_RABOTA_VAZDUHA_M");
    //        mapper.AddDataColumnMap((r) => r.LabourConditions.OnairWorkPlacesWomen, "IV_1_RABOTA_VAZDUHA_J");
    //        mapper.AddDataColumnMap((r) => r.LabourConditions.OnCallWorkCount, "IV_1_RAZPOLOJENIE_BROI");
    //        mapper.AddDataColumnMap((r) => r.LabourConditions.OtherRadiationRiskCount, "IV_1_DR_LACHENIA_BROI");
    //        mapper.AddDataColumnMap((r) => r.LabourConditions.OtherRiskAvailable, "IV_1_DRUGI", (o) => ((o.Equals(0) || o == DBNull.Value) ? false : true));
    //        mapper.AddDataColumnMap((r) => r.LabourConditions.OutdoorsWorkPlacesCount, "IV_1_RABOTA_OTKRITO_O");
    //        mapper.AddDataColumnMap((r) => r.LabourConditions.OutdoorsWorkPlacesMen, "IV_1_RABOTA_OTKRITO_M");
    //        mapper.AddDataColumnMap((r) => r.LabourConditions.OutdoorsWorkPlacesWomen, "IV_1_RABOTA_OTKRITO_J");
    //        mapper.AddDataColumnMap((r) => r.LabourConditions.PhisicalWorkRiskCount, "IV_1_FIZ_NAT_BROI");
    //        mapper.AddDataColumnMap((r) => r.LabourConditions.PressureRiskAvailable, "IV_1_S_NALIAGANE", (o) => ((o.Equals(0) || o == DBNull.Value) ? false : true));
    //        mapper.AddDataColumnMap((r) => r.LabourConditions.RopeWayRiskAvailable, "IV_1_V_LINII", (o) => ((o.Equals(0) || o == DBNull.Value) ? false : true));
    //        mapper.AddDataColumnMap((r) => r.LabourConditions.ShiftWorkCount, "IV_1_RABOTA_SMENI_BROI");
    //        mapper.AddDataColumnMap((r) => r.LabourConditions.TransportMeansRiskAvailable, "IV_1_TR_SREDSTVA", (o) => ((o.Equals(0) || o == DBNull.Value) ? false : true));
    //        mapper.AddDataColumnMap((r) => r.LabourConditions.UndergroundWorkPlacesCount, "IV_1_RABOTA_PODZEM_O");
    //        mapper.AddDataColumnMap((r) => r.LabourConditions.UndergroundWorkPlacesMen, "IV_1_RABOTA_PODZEM_M");
    //        mapper.AddDataColumnMap((r) => r.LabourConditions.UndergroundWorkPlacesWomen, "IV_1_RABOTA_PODZEM_J");
    //        mapper.AddDataColumnMap((r) => r.LabourConditions.VibrationRiskCount, "IV_1_VIBRACII_BROI");
    //        mapper.AddDataColumnMap((r) => r.LabourConditions.WaterWorkPlacesCount, "IV_1_RABOTA_VODA_O");
    //        mapper.AddDataColumnMap((r) => r.LabourConditions.WaterWorkPlacesMen, "IV_1_RABOTA_VODA_M");
    //        mapper.AddDataColumnMap((r) => r.LabourConditions.WaterWorkPlacesWomen, "IV_1_RABOTA_VODA_J");
    //        mapper.AddDataColumnMap((r) => r.LabourConditions.WeightLoadRiskCount, "IV_1_TEJESTI_BROI");
    //        mapper.AddDataColumnMap((r) => r.LabourConditions.WorkPlacesCount, "IV_1_OBSHT_BROI_RM");

    //        //15. Осигурено обслужване от служба по трудова медицина, регистрирана в Министерството на здравеопазването
    //        mapper.AddDataColumnMap((r) => r.LabourMedicineService, "III_15", (o) => ((o.Equals(0) || o == DBNull.Value) ? false : true));

    //        //29. ЧАСТ ІІІ. Ръчна работа с тежести (РРТ) : yes to all
    //        mapper.AddDataColumnMap((r) => r.ManualWeightWork.ManualWeightRiskEstimated, "IV_3_OCENEN_RISK");
    //        mapper.AddDataColumnMap((r) => r.ManualWeightWork.MeasuresNotTaken, "IV_3_NE_SA_PREDPRIETI_MERKI", (o) => ((o.Equals(0) || o == DBNull.Value) ? false : true));
    //        mapper.AddDataColumnMap((r) => r.ManualWeightWork.MedicalEvaluationCount, "IV_3_MED_OCENKA_BROI");
    //        mapper.AddDataColumnMap((r) => r.ManualWeightWork.OrganisationalMeasuresAdditionalInformation, "IV_3_INFO", (o) => ((o.Equals(0) || o == DBNull.Value) ? false : true));
    //        mapper.AddDataColumnMap((r) => r.ManualWeightWork.OrganisationalMeasuresConsultations, "IV_3_KONSULTACII", (o) => ((o.Equals(0) || o == DBNull.Value) ? false : true));
    //        mapper.AddDataColumnMap((r) => r.ManualWeightWork.OrganisationalMeasuresOthers, "IV_3_DRUGI", (o) => ((o.Equals(0) || o == DBNull.Value) ? false : true));
    //        mapper.AddDataColumnMap((r) => r.ManualWeightWork.OrganisationalMeasuresOthersText, "IV_3_DRUGI_TEXT");
    //        mapper.AddDataColumnMap((r) => r.ManualWeightWork.OrganisationalMeasuresTrainings, "IV_3_OBUCHENIE", (o) => ((o.Equals(0) || o == DBNull.Value) ? false : true));
    //        mapper.AddDataColumnMap((r) => r.ManualWeightWork.OrganisationalMeasuresTaken, "IV_3_PREDPRIETI_MERKI_ORG", (o) => ((o.Equals(0) || o == DBNull.Value) ? false : true));
    //        mapper.AddDataColumnMap((r) => r.ManualWeightWork.TechnicalEquipment, "IV_3_TEHN_SREDSTVA");
    //        mapper.AddDataColumnMap((r) => r.ManualWeightWork.TechnicalEquipmentSupplied, "IV_3_PREDPRIETI_MERKI_TECH", (o) => ((o.Equals(0) || o == DBNull.Value) ? false : true));
    //        mapper.AddDataColumnMap((r) => r.ManualWeightWork.WeightWorkEmployeeCount, "IV_3_BROI_RRT");
    //        mapper.AddDataColumnMap((r) => r.ManualWeightWork.WeightWorkMenCount, "IV_3_BROI_RRT_M");
    //        mapper.AddDataColumnMap((r) => r.ManualWeightWork.WeightWorkWomenCount, "IV_3_BROI_RRT_J");

    //        //37. ЧАСТ V. Шум 
    //        mapper.AddDataColumnMap((r) => r.NoiseConditions.AudiometricTestedCount, "IV_5_OSIGURENO_ZDR_NABL");
    //        mapper.AddDataColumnMap((r) => r.NoiseConditions.AverageWeeklyNoiseExposureData, "IV_5_SEDMICHNO_NIVO", (o) => ((o.Equals(0) || o == DBNull.Value) ? false : true));
    //        mapper.AddDataColumnMap((r) => r.NoiseConditions.CombinedNoiseAndOtotoxicExposure, "IV_5_SHUM_I_OTTOTOKS_MAT", (o) => ((o.Equals(0) || o == DBNull.Value) ? false : true));
    //        mapper.AddDataColumnMap((r) => r.NoiseConditions.CombinedNoiseAndVibrationExposure, "IV_5_SHUM_I_VIBRACII", (o) => ((o.Equals(0) || o == DBNull.Value) ? false : true));
    //        mapper.AddDataColumnMap((r) => r.NoiseConditions.ConstantNoiseExposureRisk, "IV_5_POSTOIANEN_SHUM", (o) => ((o.Equals(0) || o == DBNull.Value) ? false : true));
    //        mapper.AddDataColumnMap((r) => r.NoiseConditions.DailyNoiseExposureData, "IV_5_DNEVNO_NIVO", (o) => ((o.Equals(0) || o == DBNull.Value) ? false : true));
    //        mapper.AddDataColumnMap((r) => r.NoiseConditions.EmployeeCountOver80dB, "IV_5_BROU_NAD_80");
    //        mapper.AddDataColumnMap((r) => r.NoiseConditions.EmployeeCountOver85dB, "IV_5_BROU_NAD_85");
    //        mapper.AddDataColumnMap((r) => r.NoiseConditions.EmployeeCountOver87dB, "IV_5_BROU_NAD_87");
    //        mapper.AddDataColumnMap((r) => r.NoiseConditions.ExceptionAvailable, "IV_5_IZKL_CHLEN10", (o) => ((o.Equals(0) || o == DBNull.Value) ? false : true));
    //        mapper.AddDataColumnMap((r) => r.NoiseConditions.ExceptionReason, "IV_5_IZKL_CHLEN10_OSNOVANIE");
    //        mapper.AddDataColumnMap((r) => r.NoiseConditions.NoiseExposureEscapeEquipment, "IV_5_PODH_OBORUDVANE", (o) => ((o.Equals(0) || o == DBNull.Value) ? false : true));
    //        mapper.AddDataColumnMap((r) => r.NoiseConditions.NoiseExposureEscapeLps, "IV_5_LPS", (o) => ((o.Equals(0) || o == DBNull.Value) ? false : true));
    //        mapper.AddDataColumnMap((r) => r.NoiseConditions.NoiseExposureEscapeMaintenance, "IV_5_PODDRAJKA_OBOR", (o) => ((o.Equals(0) || o == DBNull.Value) ? false : true));
    //        mapper.AddDataColumnMap((r) => r.NoiseConditions.NoiseExposureEscapeNewMethods, "IV_5_METOD_S_PO_NISAK_SHUM", (o) => ((o.Equals(0) || o == DBNull.Value) ? false : true));
    //        mapper.AddDataColumnMap((r) => r.NoiseConditions.NoiseExposureEscapeOrganization, "IV_5_ORGANIZ_RAB", (o) => ((o.Equals(0) || o == DBNull.Value) ? false : true));
    //        mapper.AddDataColumnMap((r) => r.NoiseConditions.NoiseExposureEscapeTechnicalEquipment, "IV_5_TEHN_SREDSTVA", (o) => ((o.Equals(0) || o == DBNull.Value) ? false : true));
    //        mapper.AddDataColumnMap((r) => r.NoiseConditions.NoiseExposureEscapeWorkPlaces, "IV_5_RAZPOLOJENIE_RM", (o) => ((o.Equals(0) || o == DBNull.Value) ? false : true));
    //        mapper.AddDataColumnMap((r) => r.NoiseConditions.NoiseExposureEscapeNoMeasures, "IV_5_NE_SA_REDPR_MERKI", (o) => ((o.Equals(0) || o == DBNull.Value) ? false : true));
    //        mapper.AddDataColumnMap((r) => r.NoiseConditions.NoiseExposureRiskEstimated, "IV_5_SHUM");
    //        mapper.AddDataColumnMap((r) => r.NoiseConditions.OtherNoiseExposureData, "IV_5_DRUGI", (o) => ((o.Equals(0) || o == DBNull.Value) ? false : true)); //IV_5_DRUGO?
    //        mapper.AddDataColumnMap((r) => r.NoiseConditions.OtherNoiseExposureDataText, "IV_5_DRUGI_TEKST"); // IV_5_DRUGO_TEXT?
    //        mapper.AddDataColumnMap((r) => r.NoiseConditions.VariableNoiseExposureRisk, "IV_5_PROMENLIV_SHUM", (o) => ((o.Equals(0) || o == DBNull.Value) ? false : true));

    //        //10.2. Работници/служители на друго физическо или юридическо лице 
    //        mapper.AddDataColumnMap((r) => r.OtherEntityEmployeesCount, "II_NAETI_DR_LICE_O");
    //        mapper.AddDataColumnMap((r) => r.OtherEntityMenCount, "II_NAETI_DR_LICE_M");
    //        mapper.AddDataColumnMap((r) => r.OtherEntityWomenCount, "II_NAETI_DR_LICE_J");

    //        //10. Наети лица към датата на подаване на декларацията
    //        mapper.AddDataColumnMap((r) => r.StaffCount, "II_NAETI_LICA");

    //        //45. ЧАСТ VІ. Вибрации 
    //        mapper.AddDataColumnMap((r) => r.VibrationConditions.ExceptionAvailable, "IV_6_IZKL_CHLEN9", (o) => ((o.Equals(0) || o == DBNull.Value) ? false : true));
    //        mapper.AddDataColumnMap((r) => r.VibrationConditions.ExceptionReason, "IV_6_IZKL_CHLEN9_TEKST");
    //        mapper.AddDataColumnMap((r) => r.VibrationConditions.HealthcareCount, "IV_6_OSIGURENO_ZDR_NABL");
    //        mapper.AddDataColumnMap((r) => r.VibrationConditions.VibrationArmShoulderCount, "IV_6_BROI_RAKA_RAMO");
    //        mapper.AddDataColumnMap((r) => r.VibrationConditions.VibrationBorderlineCount, "IV_6_OBSHT_BROI");
    //        mapper.AddDataColumnMap((r) => r.VibrationConditions.OtherMeasures, "IV_6_DRUGI", (o) => ((o.Equals(0) || o == DBNull.Value) ? false : true));
    //        mapper.AddDataColumnMap((r) => r.VibrationConditions.OtherMeasuresDescription, "IV_6_DRUGI_TEKST");
    //        mapper.AddDataColumnMap((r) => r.VibrationConditions.VibrationExposureEscapeAdditionalEquipment, "IV_6_DOP_OBORUDVANE", (o) => ((o.Equals(0) || o == DBNull.Value) ? false : true));
    //        mapper.AddDataColumnMap((r) => r.VibrationConditions.VibrationExposureEscapeClimateConditions, "IV_6_MIKROKL_USL", (o) => ((o.Equals(0) || o == DBNull.Value) ? false : true));
    //        mapper.AddDataColumnMap((r) => r.VibrationConditions.VibrationExposureEscapeLimits, "IV_6_OGRAN_PRODALJ", (o) => ((o.Equals(0) || o == DBNull.Value) ? false : true));
    //        mapper.AddDataColumnMap((r) => r.VibrationConditions.VibrationExposureEscapeLps, "IV_6_LPS", (o) => ((o.Equals(0) || o == DBNull.Value) ? false : true));
    //        mapper.AddDataColumnMap((r) => r.VibrationConditions.VibrationExposureEscapeMaintenance, "IV_6_PODD_OBORUDVANE", (o) => ((o.Equals(0) || o == DBNull.Value) ? false : true));
    //        mapper.AddDataColumnMap((r) => r.VibrationConditions.VibrationExposureEscapeMethods, "IV_6_METODI_RABOTA", (o) => ((o.Equals(0) || o == DBNull.Value) ? false : true));
    //        mapper.AddDataColumnMap((r) => r.VibrationConditions.VibrationExposureEscapeNoMeasures, "IV_6_NE_SA_PREDPR_MERKI", (o) => ((o.Equals(0) || o == DBNull.Value) ? false : true));
    //        mapper.AddDataColumnMap((r) => r.VibrationConditions.VibrationExposureEscapeWorkEquipment, "IV_6_OBORUDVANE", (o) => ((o.Equals(0) || o == DBNull.Value) ? false : true));
    //        mapper.AddDataColumnMap((r) => r.VibrationConditions.VibrationExposureRiskEstimated, "IV_6_VIBRACII");
    //        mapper.AddDataColumnMap((r) => r.VibrationConditions.VibrationWholeBodyCount, "IV_6_BROI_CIALO_TIALO");

    //        //50. ЧАСТ VІІ. Физиологични режими на труд и почивка 
    //        mapper.AddDataRowMap((r) => r.WorkRestRegime.RegulatedRests, (dr) => dr.Table.DataSet.Tables["RegulatedRests"].Rows);
    //        mapper.AddDataColumnMap((r) => r.WorkRestRegime.RegulatedRests[0].EmployeesCountForRest, "BROI_RABOTESHTI");
    //        mapper.AddDataColumnMap((r) => r.WorkRestRegime.RegulatedRests[0].WorktimePercentageForRest, "procent");

    //        mapper.AddDataColumnMap((r) => r.WorkRestRegime.RegulatedRestActive, "IV_7_AKTIVNA");
    //        mapper.AddDataColumnMap((r) => r.WorkRestRegime.RegulatedRestPassive, "IV_7_PASIVNA");
    //        mapper.AddDataColumnMap((r) => r.WorkRestRegime.RegulatedRestSemiPassive, "IV_7_POLUPASIVNA");
    //        mapper.AddDataColumnMap((r) => r.WorkRestRegime.RestSpotProvided, "IV_7_MESTA_POCHIVKA");
    //        mapper.AddDataColumnMap((r) => r.WorkRestRegime.WorkRestRegimeEstimated, "IV_7_POCHIVKA");

    //        //33. ЧАСТ ІV. Работа с видеодисплеи:
    //        mapper.AddDataColumnMap((r) => r.WorkWithMonitors.MoreWorkWithMonitorCount, "IV_4_NAD_POLOVINATA_RV");
    //        mapper.AddDataColumnMap((r) => r.WorkWithMonitors.VisionComplainCount, "IV_4_PREGLED_OCHI_OPLAKVANE");
    //        mapper.AddDataColumnMap((r) => r.WorkWithMonitors.VisionCorrectionMeansCount, "IV_4_OSIGURENI_SREDSTVA_KOR");
    //        mapper.AddDataColumnMap((r) => r.WorkWithMonitors.VisionTestEmployeeCount, "IV_4_PREGLED_OCHI");
    //        mapper.AddDataColumnMap((r) => r.WorkWithMonitors.WorkWithMonitorEmployeeCount, "IV_4_OBSHT_BROI");
    //        mapper.AddDataColumnMap((r) => r.WorkWithMonitors.WorkWithMonitorRiskEstimated, "IV_4_VIDEO_DISPLEI");

    //        return mapper;
    //    }
    //}
}
