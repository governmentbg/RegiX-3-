namespace TechnoLogica.RegiX.IaaaVehicleInspectionsAdapter.AdapterService
{
    //public class IaaaVehicleInspectionsAdapter : WebServiceBaseAdapterService, IIaaaVehicleInspectionsAdapter, IAdapterService
    //{
    //    [Export(typeof(ParameterInfo))]
    //    public static ParameterInfo<string> WebServiceUrl =
    //        new ParameterInfo<string>("http://213.91.157.27:7461/egov-web/api/redu/reports/")
    //        {
    //            Key = Constants.WebServiceUrlParameterKeyName,
    //            Description = "Web Service Url",
    //            OwnerAssembly = typeof(IaaaVehicleInspectionsAdapter).Assembly
    //        };

    //    #region
    //    [Export(typeof(ParameterInfo))]
    //    public static ParameterInfo<string> Report1PermitMethodName =
    //            new ParameterInfo<string>("permits")
    //            {
    //                Key = "Report1PermitMethodName",
    //                Description = "Method name describing the service url",
    //                OwnerAssembly = typeof(IaaaVehicleInspectionsAdapter).Assembly
    //            };

    //    [Export(typeof(ParameterInfo))]
    //    public static ParameterInfo<string> Report2PermitInspectorsMethodName =
    //            new ParameterInfo<string>("permit-inspectors")
    //            {
    //                Key = "Report2PermitInspectorsMethodName",
    //                Description = "Method name describing the service url",
    //                OwnerAssembly = typeof(IaaaVehicleInspectionsAdapter).Assembly
    //            };

    //    [Export(typeof(ParameterInfo))]
    //    public static ParameterInfo<string> Report3PermitsInspectionCountReportMethodName =
    //            new ParameterInfo<string>("permit-inspection-count")
    //            {
    //                Key = "Report3PermitsInspectionCountReportMethodName",
    //                Description = "Method name describing the service url",
    //                OwnerAssembly = typeof(IaaaVehicleInspectionsAdapter).Assembly
    //            };

    //    [Export(typeof(ParameterInfo))]
    //    public static ParameterInfo<string> Report4VehicleInspectionMethodName =
    //            new ParameterInfo<string>("vehicle-inspection")
    //            {
    //                Key = "Report4VehicleInspectionMethodName",
    //                Description = "Method name describing the service url",
    //                OwnerAssembly = typeof(IaaaVehicleInspectionsAdapter).Assembly
    //            };

    //    [Export(typeof(ParameterInfo))]
    //    public static ParameterInfo<string> Report5VehicleInspectionStickerMethodName =
    //            new ParameterInfo<string>("vehicle-inspection-sticker")
    //            {
    //                Key = "Report5VehicleInspectionStickerMethodName",
    //                Description = "Method name describing the service url",
    //                OwnerAssembly = typeof(IaaaVehicleInspectionsAdapter).Assembly
    //            };
    //    #endregion

    //    public override string CheckRegisterConnection()
    //    {
    //        Dictionary<string, string> results = new Dictionary<string, string>();

    //        string resultReport1PermitMethodName = CheckConnectionsUtils.CheckConnection(WebServiceUrl.Value + Report1PermitMethodName.Value);
    //        string resultReport2PermitInspectorsMethodName = CheckConnectionsUtils.CheckConnection(WebServiceUrl.Value + Report2PermitInspectorsMethodName.Value);
    //        string resultReport3PermitsInspectionCountReportMethodName = CheckConnectionsUtils.CheckConnection(WebServiceUrl.Value + Report3PermitsInspectionCountReportMethodName.Value);
    //        string resultReport4VehicleInspectionMethodName = CheckConnectionsUtils.CheckConnection(WebServiceUrl.Value + Report4VehicleInspectionMethodName.Value);
    //        string resultReport5VehicleInspectionStickerMethodName = CheckConnectionsUtils.CheckConnection(WebServiceUrl.Value + Report5VehicleInspectionStickerMethodName.Value);

    //        results.Add("Report1PermitMethodName", resultReport1PermitMethodName);
    //        results.Add("Report2PermitInspectorsMethodName", resultReport2PermitInspectorsMethodName);
    //        results.Add("Report3PermitsInspectionCountReportMethodName", resultReport3PermitsInspectionCountReportMethodName);
    //        results.Add("Report4VehicleInspectionMethodName", resultReport4VehicleInspectionMethodName);
    //        results.Add("Report5VehicleInspectionStickerMethodName", resultReport5VehicleInspectionStickerMethodName);

    //        string description = string.Empty;
    //        int statusOk = 0;
    //        int statusNotSet = 0;
    //        int ststusError = 0;
    //        foreach (var res in results)
    //        {
    //            description += String.Format("{0}: {1}\r\n", res.Key, res.Value);
    //            if (res.Value == Constants.ConnectionOk)
    //            {
    //                statusOk++;
    //            }
    //            else
    //            {
    //                if (res.Value == Constants.WebServiceUrlNotSet)
    //                {
    //                    statusNotSet++;
    //                }
    //                else
    //                {
    //                    ststusError++;
    //                }
    //            }
    //        }
    //        if (ststusError > 0)
    //        {
    //            return description;
    //        }
    //        else
    //        {
    //            if (statusNotSet > 0)
    //            {
    //                return Constants.WebServiceUrlNotSet;
    //            }
    //            else
    //            {
    //                return Constants.ConnectionOk;
    //            }
    //        }
    //    }

    //    private async Task<string> GetResponse(HttpClient serviceClient, string argument, string adress, Guid id, AdapterAdditionalParameters aditionalParameters)
    //    {
    //        XmlDocument doc = new XmlDocument();
    //        doc.InnerXml = argument;
    //        HttpResponseMessage response = await serviceClient.PostAsXmlAsync(adress, doc.DocumentElement);

    //        if (response.IsSuccessStatusCode)
    //        {
    //            return await response.Content.ReadAsStringAsync();
    //        }
    //        else
    //        {
    //            string content = await response.Content.ReadAsStringAsync();
    //            LogData(aditionalParameters, new { NotSuccessfulResponse = response, Content = content, Guid = id });
    //            throw new Exception("StatusCode: " + response.StatusCode + "; Content: " + content);
    //        }
    //    }

    //    public CommonSignedResponse<PermitRequestType, PermitResponse> GetReport1Permit(PermitRequestType argument, AccessMatrix accessMatrix, AdapterAdditionalParameters aditionalParameters)
    //    {
    //        Guid id = Guid.NewGuid();
    //        LogData(aditionalParameters, new { Request = argument.Serialize(), Guid = id });
    //        try
    //        {
    //            var serviceClient = new HttpClient();
    //            serviceClient.BaseAddress = new Uri(WebServiceUrl.Value);
    //            serviceClient.DefaultRequestHeaders.Accept.Clear();
    //            serviceClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/xml"));

    //            ServiceXMLShemas.permitRequest param = new ServiceXMLShemas.permitRequest();
    //            param.context = aditionalParameters.CallContext.ToString();
    //            param.identNumber = argument.IdentNumber;
    //            string request = param.XmlSerialize();

    //            string responseString = GetResponse(serviceClient, request, Report1PermitMethodName.Value, id, aditionalParameters).Result;
    //            XElement resultXmlElement = XDocument.Parse(responseString).Root;

    //            XPathMapper<PermitResponse> responseMapper = CreatePermitResponseMapper(accessMatrix);
    //            PermitResponse result = new PermitResponse();
    //            responseMapper.Map(resultXmlElement, result);

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

    //    private static XPathMapper<PermitResponse> CreatePermitResponseMapper(AccessMatrix accessMatrix)
    //    {
    //        XPathMapper<PermitResponse> mapper =
    //            new XPathMapper<PermitResponse>(accessMatrix);

    //        mapper.AddCollectionMap(p => p.Permits, "/*[local-name()='permitResponse']/*[local-name()='permits']/*[local-name()='permit']");

    //        mapper.AddFunctionMap(p => p.Permits[0].CloseDate, node =>
    //        {
    //            XmlNode closeDateNode =
    //                    node.SelectSingleNode(
    //                        "./*[local-name()='closeDate']");
    //            if (closeDateNode != null &&
    //                !string.IsNullOrWhiteSpace(closeDateNode.InnerText))
    //            {
    //                return DateTime.ParseExact(closeDateNode.InnerText, "yyyy-MM-ddzzz",
    //                                            CultureInfo.InvariantCulture
    //                                                    .DateTimeFormat);
    //            }
    //            return null;
    //        });

    //        mapper.AddPropertyMap(p => p.Permits[0].CloseReason, "./*[local-name()='closeReason']");

    //        mapper.AddFunctionMap(p => p.Permits[0].FirstRegDate, node =>
    //        {
    //            XmlNode firstRegDateNode =
    //                    node.SelectSingleNode(
    //                        "./*[local-name()='firstRegDate']");
    //            if (firstRegDateNode != null &&
    //                !string.IsNullOrWhiteSpace(firstRegDateNode.InnerText))
    //            {
    //                return DateTime.ParseExact(firstRegDateNode.InnerText, "yyyy-MM-ddzzz",
    //                                            CultureInfo.InvariantCulture
    //                                                    .DateTimeFormat);
    //            }
    //            return null;
    //        });

    //        mapper.AddFunctionMap(p => p.Permits[0].InspectionDate, node =>
    //        {
    //            XmlNode inspectionDateNode =
    //                    node.SelectSingleNode(
    //                        "./*[local-name()='inspectionDate']");
    //            if (inspectionDateNode != null &&
    //                !string.IsNullOrWhiteSpace(inspectionDateNode.InnerText))
    //            {
    //                return DateTime.ParseExact(inspectionDateNode.InnerText, "yyyy-MM-ddzzz",
    //                                            CultureInfo.InvariantCulture
    //                                                    .DateTimeFormat);
    //            }
    //            return null;
    //        });

    //        mapper.AddPropertyMap(p => p.Permits[0].InspectionProtocols, "./*[local-name()='inspectionProtocols']");
    //        mapper.AddCollectionMap(p => p.Permits[0].Inspectors, "./*[local-name()='inspectors']/*[local-name()='inspector']");
    //        mapper.AddPropertyMap(p => p.Permits[0].Inspectors[0].CurrentStatus, "./*[local-name()='currentStatus']");

    //        mapper.AddFunctionMap(p => p.Permits[0].Inspectors[0].IsChairman, node =>
    //        {
    //            XmlNode isChairmanNode =
    //                    node.SelectSingleNode(
    //                        "./*[local-name()='isChairman']");

    //            if (isChairmanNode != null &&
    //                !string.IsNullOrWhiteSpace(isChairmanNode.InnerText))
    //            {
    //                bool result;
    //                if (bool.TryParse(isChairmanNode.InnerText, out result))
    //                    return result;
    //            }
    //            return null;
    //        });

    //        mapper.AddPropertyMap(p => p.Permits[0].Inspectors[0].SubjectFullName, "./*[local-name()='subjectFullName']");
    //        mapper.AddPropertyMap(p => p.Permits[0].Inspectors[0].SubjectIdentNumber, "./*[local-name()='subjectIdentNumber']");
    //        mapper.AddPropertyMap(p => p.Permits[0].KtpAddress, "./*[local-name()='ktpAddress']");
    //        mapper.AddPropertyMap(p => p.Permits[0].KtpCategoryLabel, "./*[local-name()='ktpCategoryLabel']");
    //        mapper.AddPropertyMap(p => p.Permits[0].KtpCityName, "./*[local-name()='ktpCityName']");
    //        mapper.AddPropertyMap(p => p.Permits[0].KtpName, "./*[local-name()='ktpName']");

    //        mapper.AddFunctionMap(p => p.Permits[0].LastChangeDate, node =>
    //        {
    //            XmlNode lastChangeDateNode =
    //                    node.SelectSingleNode(
    //                        "./*[local-name()='lastChangeDate']");
    //            if (lastChangeDateNode != null &&
    //                !string.IsNullOrWhiteSpace(lastChangeDateNode.InnerText))
    //            {
    //                return DateTime.ParseExact(lastChangeDateNode.InnerText, "yyyy-MM-ddzzz",
    //                                            CultureInfo.InvariantCulture
    //                                                    .DateTimeFormat);
    //            }
    //            return null;
    //        });

    //        mapper.AddFunctionMap(p => p.Permits[0].LineCount, node =>
    //        {
    //            XmlNode lineCountNode =
    //                    node.SelectSingleNode(
    //                        "./*[local-name()='lineCount']");

    //            if (lineCountNode != null &&
    //                !string.IsNullOrWhiteSpace(lineCountNode.InnerText))
    //            {
    //                short result;
    //                if (short.TryParse(lineCountNode.InnerText, out result))
    //                    return result;
    //            }
    //            return null;
    //        });

    //        mapper.AddFunctionMap(p => p.Permits[0].ListChangeDate, node =>
    //        {
    //            XmlNode listChangeDateNode =
    //                    node.SelectSingleNode(
    //                        "./*[local-name()='listChangeDate']");
    //            if (listChangeDateNode != null &&
    //                !string.IsNullOrWhiteSpace(listChangeDateNode.InnerText))
    //            {
    //                return DateTime.ParseExact(listChangeDateNode.InnerText, "yyyy-MM-ddzzz",
    //                                            CultureInfo.InvariantCulture
    //                                                    .DateTimeFormat);
    //            }
    //            return null;
    //        });

    //        mapper.AddPropertyMap(p => p.Permits[0].OrgUnitShortName, "./*[local-name()='orgUnitShortName']");
    //        mapper.AddPropertyMap(p => p.Permits[0].PermitNumber, "./*[local-name()='permitNumber']");
    //        mapper.AddPropertyMap(p => p.Permits[0].PermitStatus, "./*[local-name()='permitStatus']");
    //        mapper.AddPropertyMap(p => p.Permits[0].PermitStatusCode, "./*[local-name()='permitStatusCode']");
    //        mapper.AddPropertyMap(p => p.Permits[0].Remarks, "./*[local-name()='remarks']");

    //        mapper.AddFunctionMap(p => p.Permits[0].StampNumber, node =>
    //        {
    //            XmlNode stampNumberNode =
    //                    node.SelectSingleNode(
    //                        "./*[local-name()='stampNumber']");

    //            if (stampNumberNode != null &&
    //                !string.IsNullOrWhiteSpace(stampNumberNode.InnerText))
    //            {
    //                short result;
    //                if (short.TryParse(stampNumberNode.InnerText, out result))
    //                    return result;
    //            }
    //            return null;
    //        });

    //        mapper.AddPropertyMap(p => p.Permits[0].SubjectIdentNumber, "./*[local-name()='subjectIdentNumber']");

    //        mapper.AddFunctionMap(p => p.Permits[0].ValidTo, node =>
    //        {
    //            XmlNode validToNode =
    //                    node.SelectSingleNode(
    //                        "./*[local-name()='validTo']");
    //            if (validToNode != null &&
    //                !string.IsNullOrWhiteSpace(validToNode.InnerText))
    //            {
    //                return DateTime.ParseExact(validToNode.InnerText, "yyyy-MM-ddzzz",
    //                                            CultureInfo.InvariantCulture
    //                                                    .DateTimeFormat);
    //            }
    //            return null;
    //        });

    //        return mapper;
    //    }

    //    public CommonSignedResponse<PermitInspectorsRequestType, PermitInspectorsResponse> GetReport2PermitInspectors(PermitInspectorsRequestType argument, AccessMatrix accessMatrix, AdapterAdditionalParameters aditionalParameters)
    //    {
    //        Guid id = Guid.NewGuid();
    //        LogData(aditionalParameters, new { Request = argument.Serialize(), Guid = id });
    //        try
    //        {
    //            var serviceClient = new HttpClient();
    //            serviceClient.BaseAddress = new Uri(WebServiceUrl.Value);
    //            serviceClient.DefaultRequestHeaders.Accept.Clear();
    //            serviceClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/xml"));

    //            ServiceXMLShemas.permitInspectorsRequest param = new ServiceXMLShemas.permitInspectorsRequest();
    //            param.context = aditionalParameters.CallContext.ToString();
    //            param.identNumber = argument.IdentNumber;
    //            string request = param.XmlSerialize();

    //            string responseString = GetResponse(serviceClient, request, Report2PermitInspectorsMethodName.Value, id, aditionalParameters).Result;
    //            XElement resultXmlElement = XDocument.Parse(responseString).Root;

    //            XPathMapper<PermitInspectorsResponse> responseMapper = CreatePermitInspectorsResponseMapper(accessMatrix);
    //            PermitInspectorsResponse result = new PermitInspectorsResponse();
    //            responseMapper.Map(resultXmlElement, result);

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

    //    private static XPathMapper<PermitInspectorsResponse> CreatePermitInspectorsResponseMapper(AccessMatrix accessMatrix)
    //    {
    //        XPathMapper<PermitInspectorsResponse> mapper =
    //            new XPathMapper<PermitInspectorsResponse>(accessMatrix);

    //        mapper.AddCollectionMap(p => p.Inspectors, "/*[local-name()='permitInspectorsResponse']/*[local-name()='inspectors']/*[local-name()='inspector']");
    //        mapper.AddPropertyMap(p => p.Inspectors[0].CurrentStatus, "./*[local-name()='currentStatus']");

    //        mapper.AddFunctionMap(p => p.Inspectors[0].IsChairman, node =>
    //        {
    //            XmlNode isChairmanNode =
    //                    node.SelectSingleNode(
    //                        "./*[local-name()='isChairman']");

    //            if (isChairmanNode != null &&
    //                !string.IsNullOrWhiteSpace(isChairmanNode.InnerText))
    //            {
    //                bool result;
    //                if (bool.TryParse(isChairmanNode.InnerText, out result))
    //                    return result;
    //            }
    //            return null;
    //        });

    //        mapper.AddPropertyMap(p => p.Inspectors[0].SubjectFullName, "./*[local-name()='subjectFullName']");
    //        mapper.AddPropertyMap(p => p.Inspectors[0].SubjectIdentNumber, "./*[local-name()='subjectIdentNumber']");

    //        mapper.AddFunctionMap(p => p.Inspectors[0].Permit, node =>
    //        {
    //            XmlNode permitNode =
    //                    node.SelectSingleNode(
    //                        "./*[local-name()='permit']");

    //            if (permitNode != null &&
    //                !string.IsNullOrWhiteSpace(permitNode.InnerText))
    //            {
    //                return new PermitDto();
    //            }
    //            return null;
    //        });

    //        mapper.AddFunctionMap(p => p.Inspectors[0].Permit.CloseDate, node =>
    //        {
    //            XmlNode closeDateNode =
    //                    node.SelectSingleNode(
    //                        "./*[local-name()='permit']/*[local-name()='closeDate']");
    //            if (closeDateNode != null &&
    //                !string.IsNullOrWhiteSpace(closeDateNode.InnerText))
    //            {
    //                return DateTime.ParseExact(closeDateNode.InnerText, "yyyy-MM-ddzzz",
    //                                            CultureInfo.InvariantCulture
    //                                                    .DateTimeFormat);
    //            }
    //            return null;
    //        });

    //        mapper.AddPropertyMap(p => p.Inspectors[0].Permit.CloseReason, "./*[local-name()='permit']/*[local-name()='closeReason']");

    //        mapper.AddFunctionMap(p => p.Inspectors[0].Permit.FirstRegDate, node =>
    //        {
    //            XmlNode firstRegDateNode =
    //                    node.SelectSingleNode(
    //                        "./*[local-name()='permit']/*[local-name()='firstRegDate']");
    //            if (firstRegDateNode != null &&
    //                !string.IsNullOrWhiteSpace(firstRegDateNode.InnerText))
    //            {
    //                return DateTime.ParseExact(firstRegDateNode.InnerText, "yyyy-MM-ddzzz",
    //                                            CultureInfo.InvariantCulture
    //                                                    .DateTimeFormat);
    //            }
    //            return null;
    //        });

    //        mapper.AddFunctionMap(p => p.Inspectors[0].Permit.InspectionDate, node =>
    //        {
    //            XmlNode inspectionDateNode =
    //                    node.SelectSingleNode(
    //                        "./*[local-name()='permit']/*[local-name()='inspectionDate']");
    //            if (inspectionDateNode != null &&
    //                !string.IsNullOrWhiteSpace(inspectionDateNode.InnerText))
    //            {
    //                return DateTime.ParseExact(inspectionDateNode.InnerText, "yyyy-MM-ddzzz",
    //                                            CultureInfo.InvariantCulture
    //                                                    .DateTimeFormat);
    //            }
    //            return null;
    //        });

    //        mapper.AddPropertyMap(p => p.Inspectors[0].Permit.InspectionProtocols, "./*[local-name()='permit']/*[local-name()='inspectionProtocols']");
    //        mapper.AddPropertyMap(p => p.Inspectors[0].Permit.KtpAddress, "./*[local-name()='permit']/*[local-name()='ktpAddress']");
    //        mapper.AddPropertyMap(p => p.Inspectors[0].Permit.KtpCategoryLabel, "./*[local-name()='permit']/*[local-name()='ktpCategoryLabel']");
    //        mapper.AddPropertyMap(p => p.Inspectors[0].Permit.KtpCityName, "./*[local-name()='permit']/*[local-name()='ktpCityName']");
    //        mapper.AddPropertyMap(p => p.Inspectors[0].Permit.KtpName, "./*[local-name()='permit']/*[local-name()='ktpName']");

    //        mapper.AddFunctionMap(p => p.Inspectors[0].Permit.LastChangeDate, node =>
    //        {
    //            XmlNode lastChangeDateNode =
    //                    node.SelectSingleNode(
    //                        "./*[local-name()='permit']/*[local-name()='lastChangeDate']");
    //            if (lastChangeDateNode != null &&
    //                !string.IsNullOrWhiteSpace(lastChangeDateNode.InnerText))
    //            {
    //                return DateTime.ParseExact(lastChangeDateNode.InnerText, "yyyy-MM-ddzzz",
    //                                            CultureInfo.InvariantCulture
    //                                                    .DateTimeFormat);
    //            }
    //            return null;
    //        });

    //        mapper.AddFunctionMap(p => p.Inspectors[0].Permit.LineCount, node =>
    //        {
    //            XmlNode lineCountNode =
    //                    node.SelectSingleNode(
    //                        "./*[local-name()='permit']/*[local-name()='lineCount']");

    //            if (lineCountNode != null &&
    //                !string.IsNullOrWhiteSpace(lineCountNode.InnerText))
    //            {
    //                short result;
    //                if (short.TryParse(lineCountNode.InnerText, out result))
    //                    return result;
    //            }
    //            return null;
    //        });

    //        mapper.AddFunctionMap(p => p.Inspectors[0].Permit.ListChangeDate, node =>
    //        {
    //            XmlNode listChangeDateNode =
    //                    node.SelectSingleNode(
    //                        "./*[local-name()='permit']/*[local-name()='listChangeDate']");
    //            if (listChangeDateNode != null &&
    //                !string.IsNullOrWhiteSpace(listChangeDateNode.InnerText))
    //            {
    //                return DateTime.ParseExact(listChangeDateNode.InnerText, "yyyy-MM-ddzzz",
    //                                            CultureInfo.InvariantCulture
    //                                                    .DateTimeFormat);
    //            }
    //            return null;
    //        });

    //        mapper.AddPropertyMap(p => p.Inspectors[0].Permit.OrgUnitShortName, "./*[local-name()='permit']/*[local-name()='orgUnitShortName']");
    //        mapper.AddPropertyMap(p => p.Inspectors[0].Permit.PermitNumber, "./*[local-name()='permit']/*[local-name()='permitNumber']");
    //        mapper.AddPropertyMap(p => p.Inspectors[0].Permit.PermitStatus, "./*[local-name()='permit']/*[local-name()='permitStatus']");
    //        mapper.AddPropertyMap(p => p.Inspectors[0].Permit.PermitStatusCode, "./*[local-name()='permit']/*[local-name()='permitStatusCode']");
    //        mapper.AddPropertyMap(p => p.Inspectors[0].Permit.Remarks, "./*[local-name()='permit']/*[local-name()='remarks']");

    //        mapper.AddFunctionMap(p => p.Inspectors[0].Permit.StampNumber, node =>
    //        {
    //            XmlNode stampNumberNode =
    //                    node.SelectSingleNode(
    //                        "./*[local-name()='permit']/*[local-name()='stampNumber']");

    //            if (stampNumberNode != null &&
    //                !string.IsNullOrWhiteSpace(stampNumberNode.InnerText))
    //            {
    //                short result;
    //                if (short.TryParse(stampNumberNode.InnerText, out result))
    //                    return result;
    //            }
    //            return null;
    //        });

    //        mapper.AddPropertyMap(p => p.Inspectors[0].Permit.SubjectIdentNumber, "./*[local-name()='permit']/*[local-name()='subjectIdentNumber']");

    //        mapper.AddFunctionMap(p => p.Inspectors[0].Permit.ValidTo, node =>
    //        {
    //            XmlNode validToNode =
    //                    node.SelectSingleNode(
    //                        "./*[local-name()='permit']/*[local-name()='validTo']");
    //            if (validToNode != null &&
    //                !string.IsNullOrWhiteSpace(validToNode.InnerText))
    //            {
    //                return DateTime.ParseExact(validToNode.InnerText, "yyyy-MM-ddzzz",
    //                                            CultureInfo.InvariantCulture
    //                                                    .DateTimeFormat);
    //            }
    //            return null;
    //        });

    //        return mapper;
    //    }

    //    public CommonSignedResponse<PermitsInspectionCountRequestType, PermitsInspectionCountResponse> GetReport3PermitsInspectionCount(PermitsInspectionCountRequestType argument, AccessMatrix accessMatrix, AdapterAdditionalParameters aditionalParameters)
    //    {
    //        Guid id = Guid.NewGuid();
    //        LogData(aditionalParameters, new { Request = argument.Serialize(), Guid = id });
    //        try
    //        {
    //            var serviceClient = new HttpClient();
    //            serviceClient.BaseAddress = new Uri(WebServiceUrl.Value);
    //            serviceClient.DefaultRequestHeaders.Accept.Clear();
    //            serviceClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/xml"));

    //            ServiceXMLShemas.permitsInspectionCountReportRequest param = new ServiceXMLShemas.permitsInspectionCountReportRequest();
    //            param.context = aditionalParameters.CallContext.ToString();
    //            param.identNumber = argument.IdentNumber;
    //            param.dateFromPrivate = argument.DateFrom;
    //            param.dateFromSpecified = argument.DateFromSpecified;
    //            param.dateToPrivate = argument.DateTo;
    //            param.dateToSpecified = argument.DateToSpecified;

    //            string request = param.XmlSerialize();
    //            string responseString = GetResponse(serviceClient, request, Report3PermitsInspectionCountReportMethodName.Value, id, aditionalParameters).Result;
    //            XElement resultXmlElement = XDocument.Parse(responseString).Root;

    //            XPathMapper<PermitsInspectionCountResponse> responseMapper = CreatePermitsInspectionCountResponseMapper(accessMatrix);
    //            PermitsInspectionCountResponse result = new PermitsInspectionCountResponse();
    //            responseMapper.Map(resultXmlElement, result);

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

    //    private static XPathMapper<PermitsInspectionCountResponse> CreatePermitsInspectionCountResponseMapper(AccessMatrix accessMatrix)
    //    {
    //        XPathMapper<PermitsInspectionCountResponse> mapper =
    //            new XPathMapper<PermitsInspectionCountResponse>(accessMatrix);

    //        mapper.AddCollectionMap(p => p.PermitsInspectionsCounts, "/*[local-name()='permitsInspectionCountResponse']/*[local-name()='permitsInspectionsCounts']/*[local-name()='permitInspectionsCount']");

    //        mapper.AddFunctionMap(p => p.PermitsInspectionsCounts[0].CloseDate, node =>
    //        {
    //            XmlNode closeDateNode =
    //                    node.SelectSingleNode(
    //                        "./*[local-name()='closeDate']");
    //            if (closeDateNode != null &&
    //                !string.IsNullOrWhiteSpace(closeDateNode.InnerText))
    //            {
    //                return DateTime.ParseExact(closeDateNode.InnerText, "yyyy-MM-ddzzz",
    //                                            CultureInfo.InvariantCulture
    //                                                    .DateTimeFormat);
    //            }
    //            return null;
    //        });

    //        mapper.AddPropertyMap(p => p.PermitsInspectionsCounts[0].CloseReason, "./*[local-name()='closeReason']");

    //        mapper.AddFunctionMap(p => p.PermitsInspectionsCounts[0].FirstRegDate, node =>
    //        {
    //            XmlNode firstRegDateNode =
    //                    node.SelectSingleNode(
    //                        "./*[local-name()='firstRegDate']");
    //            if (firstRegDateNode != null &&
    //                !string.IsNullOrWhiteSpace(firstRegDateNode.InnerText))
    //            {
    //                return DateTime.ParseExact(firstRegDateNode.InnerText, "yyyy-MM-ddzzz",
    //                                            CultureInfo.InvariantCulture
    //                                                    .DateTimeFormat);
    //            }
    //            return null;
    //        });

    //        mapper.AddPropertyMap(p => p.PermitsInspectionsCounts[0].InspectionCount, "./*[local-name()='inspectionCount']");

    //        mapper.AddFunctionMap(p => p.PermitsInspectionsCounts[0].InspectionDate, node =>
    //        {
    //            XmlNode inspectionDateNode =
    //                    node.SelectSingleNode(
    //                        "./*[local-name()='inspectionDate']");
    //            if (inspectionDateNode != null &&
    //                !string.IsNullOrWhiteSpace(inspectionDateNode.InnerText))
    //            {
    //                return DateTime.ParseExact(inspectionDateNode.InnerText, "yyyy-MM-ddzzz",
    //                                            CultureInfo.InvariantCulture
    //                                                    .DateTimeFormat);
    //            }
    //            return null;
    //        });

    //        mapper.AddPropertyMap(p => p.PermitsInspectionsCounts[0].InspectionProtocols, "./*[local-name()='inspectionProtocols']");
    //        mapper.AddPropertyMap(p => p.PermitsInspectionsCounts[0].KtpAddress, "./*[local-name()='ktpAddress']");
    //        mapper.AddPropertyMap(p => p.PermitsInspectionsCounts[0].KtpCategoryLabel, "./*[local-name()='ktpCategoryLabel']");
    //        mapper.AddPropertyMap(p => p.PermitsInspectionsCounts[0].KtpCityName, "./*[local-name()='ktpCityName']");
    //        mapper.AddPropertyMap(p => p.PermitsInspectionsCounts[0].KtpName, "./*[local-name()='ktpName']");

    //        mapper.AddFunctionMap(p => p.PermitsInspectionsCounts[0].LastChangeDate, node =>
    //        {
    //            XmlNode lastChangeDateNode =
    //                    node.SelectSingleNode(
    //                        "./*[local-name()='lastChangeDate']");
    //            if (lastChangeDateNode != null &&
    //                !string.IsNullOrWhiteSpace(lastChangeDateNode.InnerText))
    //            {
    //                return DateTime.ParseExact(lastChangeDateNode.InnerText, "yyyy-MM-ddzzz",
    //                                            CultureInfo.InvariantCulture
    //                                                    .DateTimeFormat);
    //            }
    //            return null;
    //        });

    //        mapper.AddFunctionMap(p => p.PermitsInspectionsCounts[0].LineCount, node =>
    //        {
    //            XmlNode lineCountNode =
    //                    node.SelectSingleNode(
    //                        "./*[local-name()='lineCount']");

    //            if (lineCountNode != null &&
    //                !string.IsNullOrWhiteSpace(lineCountNode.InnerText))
    //            {
    //                short result;
    //                if (short.TryParse(lineCountNode.InnerText, out result))
    //                    return result;
    //            }
    //            return null;
    //        });

    //        mapper.AddFunctionMap(p => p.PermitsInspectionsCounts[0].ListChangeDate, node =>
    //        {
    //            XmlNode listChangeDateNode =
    //                    node.SelectSingleNode(
    //                        "./*[local-name()='listChangeDate']");
    //            if (listChangeDateNode != null &&
    //                !string.IsNullOrWhiteSpace(listChangeDateNode.InnerText))
    //            {
    //                return DateTime.ParseExact(listChangeDateNode.InnerText, "yyyy-MM-ddzzz",
    //                                            CultureInfo.InvariantCulture
    //                                                    .DateTimeFormat);
    //            }
    //            return null;
    //        });

    //        mapper.AddPropertyMap(p => p.PermitsInspectionsCounts[0].OrgUnitShortName, "./*[local-name()='orgUnitShortName']");
    //        mapper.AddPropertyMap(p => p.PermitsInspectionsCounts[0].PermitNumber, "./*[local-name()='permitNumber']");
    //        mapper.AddPropertyMap(p => p.PermitsInspectionsCounts[0].PermitStatus, "./*[local-name()='permitStatus']");
    //        mapper.AddPropertyMap(p => p.PermitsInspectionsCounts[0].PermitStatusCode, "./*[local-name()='permitStatusCode']");
    //        mapper.AddPropertyMap(p => p.PermitsInspectionsCounts[0].Remarks, "./*[local-name()='remarks']");

    //        mapper.AddFunctionMap(p => p.PermitsInspectionsCounts[0].StampNumber, node =>
    //        {
    //            XmlNode stampNumberNode =
    //                    node.SelectSingleNode(
    //                        "./*[local-name()='stampNumber']");

    //            if (stampNumberNode != null &&
    //                !string.IsNullOrWhiteSpace(stampNumberNode.InnerText))
    //            {
    //                short result;
    //                if (short.TryParse(stampNumberNode.InnerText, out result))
    //                    return result;
    //            }
    //            return null;
    //        });

    //        mapper.AddPropertyMap(p => p.PermitsInspectionsCounts[0].SubjectIdentNumber, "./*[local-name()='subjectIdentNumber']");

    //        mapper.AddFunctionMap(p => p.PermitsInspectionsCounts[0].ValidTo, node =>
    //        {
    //            XmlNode validToNode =
    //                    node.SelectSingleNode(
    //                        "./*[local-name()='validTo']");
    //            if (validToNode != null &&
    //                !string.IsNullOrWhiteSpace(validToNode.InnerText))
    //            {
    //                return DateTime.ParseExact(validToNode.InnerText, "yyyy-MM-ddzzz",
    //                                            CultureInfo.InvariantCulture
    //                                                    .DateTimeFormat);
    //            }
    //            return null;
    //        });

    //        return mapper;
    //    }

    //    public CommonSignedResponse<VehicleInspectionRequestType, VehicleInspectionResponse> GetReport4VehicleInspection(VehicleInspectionRequestType argument, AccessMatrix accessMatrix, AdapterAdditionalParameters aditionalParameters)
    //    {
    //        Guid id = Guid.NewGuid();
    //        LogData(aditionalParameters, new { Request = argument.Serialize(), Guid = id });
    //        try
    //        {
    //            var serviceClient = new HttpClient();
    //            serviceClient.BaseAddress = new Uri(WebServiceUrl.Value);
    //            serviceClient.DefaultRequestHeaders.Accept.Clear();
    //            serviceClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/xml"));

    //            ServiceXMLShemas.vehicleInspectionRequest param = new ServiceXMLShemas.vehicleInspectionRequest();
    //            param.context = aditionalParameters.CallContext.ToString();
    //            param.regNumber = argument.RegNumber;
    //            string request = param.XmlSerialize();

    //            string responseString = GetResponse(serviceClient, request, Report4VehicleInspectionMethodName.Value, id, aditionalParameters).Result;
    //            XElement resultXmlElement = XDocument.Parse(responseString).Root;

    //            XPathMapper<VehicleInspectionResponse> responseMapper = CreateVehicleInspectionResponseMapper(accessMatrix);
    //            VehicleInspectionResponse result = new VehicleInspectionResponse();
    //            responseMapper.Map(resultXmlElement, result);

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

    //    private static XPathMapper<VehicleInspectionResponse> CreateVehicleInspectionResponseMapper(AccessMatrix accessMatrix)
    //    {
    //        XPathMapper<VehicleInspectionResponse> mapper =
    //            new XPathMapper<VehicleInspectionResponse>(accessMatrix);

    //        mapper.AddFunctionMap(p => p.Chairman, node =>
    //        {
    //            XmlNode chairmanNode =
    //                    node.SelectSingleNode(
    //                        "/*[local-name()='vehicleInspectionResponse']/*[local-name()='chairman']");
    //            if (chairmanNode != null &&
    //                !string.IsNullOrWhiteSpace(chairmanNode.InnerText))
    //            {
    //                return new PermitInspectorDto();
    //            }
    //            return null;
    //        });

    //        mapper.AddPropertyMap(p => p.Chairman.CurrentStatus, "/*[local-name()='vehicleInspectionResponse']/*[local-name()='chairman']/*[local-name()='currentStatus']");

    //        mapper.AddFunctionMap(p => p.Chairman.IsChairman, node =>
    //        {
    //            XmlNode isChairmanNode =
    //                    node.SelectSingleNode(
    //                        "/*[local-name()='vehicleInspectionResponse']/*[local-name()='chairman']/*[local-name()='isChairman']");

    //            if (isChairmanNode != null &&
    //                !string.IsNullOrWhiteSpace(isChairmanNode.InnerText))
    //            {
    //                bool result;
    //                if (bool.TryParse(isChairmanNode.InnerText, out result))
    //                    return result;
    //            }
    //            return null;
    //        });

    //        mapper.AddPropertyMap(p => p.Chairman.SubjectFullName, "/*[local-name()='vehicleInspectionResponse']/*[local-name()='chairman']/*[local-name()='subjectFullName']");
    //        mapper.AddPropertyMap(p => p.Chairman.SubjectIdentNumber, "/*[local-name()='vehicleInspectionResponse']/*[local-name()='chairman']/*[local-name()='subjectIdentNumber']");
    //        mapper.AddPropertyMap(p => p.Conclusion, "/*[local-name()='vehicleInspectionResponse']/*[local-name()='conclusion']");
    //        mapper.AddPropertyMap(p => p.CurrentStatus, "/*[local-name()='vehicleInspectionResponse']/*[local-name()='currentStatus']");

    //        mapper.AddFunctionMap(p => p.EndDateTime, node =>
    //        {
    //            XmlNode endDateTimeNode =
    //                    node.SelectSingleNode(
    //                        "/*[local-name()='vehicleInspectionResponse']/*[local-name()='endDateTime']");
    //            if (endDateTimeNode != null &&
    //                !string.IsNullOrWhiteSpace(endDateTimeNode.InnerText))
    //            {
    //                return DateTime.ParseExact(endDateTimeNode.InnerText, "yyyy-MM-ddzzz",
    //                                            CultureInfo.InvariantCulture
    //                                                    .DateTimeFormat);
    //            }
    //            return null;
    //        });

    //        mapper.AddFunctionMap(p => p.InspectionDateTime, node =>
    //        {
    //            XmlNode inspectionDateTimeNode =
    //                    node.SelectSingleNode(
    //                        "/*[local-name()='vehicleInspectionResponse']/*[local-name()='inspectionDateTime']");
    //            if (inspectionDateTimeNode != null &&
    //                !string.IsNullOrWhiteSpace(inspectionDateTimeNode.InnerText))
    //            {
    //                return DateTime.ParseExact(inspectionDateTimeNode.InnerText, "yyyy-MM-ddzzz",
    //                                            CultureInfo.InvariantCulture
    //                                                    .DateTimeFormat);
    //            }
    //            return null;
    //        });

    //        mapper.AddFunctionMap(p => p.Member, node =>
    //        {
    //            XmlNode chairmanNode =
    //                    node.SelectSingleNode(
    //                        "/*[local-name()='vehicleInspectionResponse']/*[local-name()='member']");
    //            if (chairmanNode != null &&
    //                !string.IsNullOrWhiteSpace(chairmanNode.InnerText))
    //            {
    //                return new PermitInspectorDto();
    //            }
    //            return null;
    //        });

    //        mapper.AddPropertyMap(p => p.Member.CurrentStatus, "/*[local-name()='vehicleInspectionResponse']/*[local-name()='member']/*[local-name()='currentStatus']");

    //        mapper.AddFunctionMap(p => p.Member.IsChairman, node =>
    //        {
    //            XmlNode isChairmanNode =
    //                    node.SelectSingleNode(
    //                        "/*[local-name()='vehicleInspectionResponse']/*[local-name()='member']/*[local-name()='isChairman']");

    //            if (isChairmanNode != null &&
    //                !string.IsNullOrWhiteSpace(isChairmanNode.InnerText))
    //            {
    //                bool result;
    //                if (bool.TryParse(isChairmanNode.InnerText, out result))
    //                    return result;
    //            }
    //            return null;
    //        });

    //        mapper.AddPropertyMap(p => p.Member.SubjectFullName, "/*[local-name()='vehicleInspectionResponse']/*[local-name()='member']/*[local-name()='subjectFullName']");
    //        mapper.AddPropertyMap(p => p.Member.SubjectIdentNumber, "/*[local-name()='vehicleInspectionResponse']/*[local-name()='member']/*[local-name()='subjectIdentNumber']");
    //        mapper.AddPropertyMap(p => p.NextInspectionDate, "/*[local-name()='vehicleInspectionResponse']/*[local-name()='nextInspectionDate']");

    //        mapper.AddFunctionMap(p => p.Permit, node =>
    //        {
    //            XmlNode chairmanNode =
    //                    node.SelectSingleNode(
    //                        "/*[local-name()='vehicleInspectionResponse']/*[local-name()='permit']");
    //            if (chairmanNode != null &&
    //                !string.IsNullOrWhiteSpace(chairmanNode.InnerText))
    //            {
    //                return new PermitDto();
    //            }
    //            return null;
    //        });

    //        mapper.AddFunctionMap(p => p.Permit.CloseDate, node =>
    //        {
    //            XmlNode closeDateNode =
    //                    node.SelectSingleNode(
    //                        "/*[local-name()='vehicleInspectionResponse']/*[local-name()='permit']/*[local-name()='closeDate']");
    //            if (closeDateNode != null &&
    //                !string.IsNullOrWhiteSpace(closeDateNode.InnerText))
    //            {
    //                return DateTime.ParseExact(closeDateNode.InnerText, "yyyy-MM-ddzzz",
    //                                            CultureInfo.InvariantCulture
    //                                                    .DateTimeFormat);
    //            }
    //            return null;
    //        });

    //        mapper.AddPropertyMap(p => p.Permit.CloseReason, "/*[local-name()='vehicleInspectionResponse']/*[local-name()='permit']/*[local-name()='closeReason']");

    //        mapper.AddFunctionMap(p => p.Permit.FirstRegDate, node =>
    //        {
    //            XmlNode firstRegDateNode =
    //                    node.SelectSingleNode(
    //                        "/*[local-name()='vehicleInspectionResponse']/*[local-name()='permit']/*[local-name()='firstRegDate']");
    //            if (firstRegDateNode != null &&
    //                !string.IsNullOrWhiteSpace(firstRegDateNode.InnerText))
    //            {
    //                return DateTime.ParseExact(firstRegDateNode.InnerText, "yyyy-MM-ddzzz",
    //                                            CultureInfo.InvariantCulture
    //                                                    .DateTimeFormat);
    //            }
    //            return null;
    //        });

    //        mapper.AddFunctionMap(p => p.Permit.InspectionDate, node =>
    //        {
    //            XmlNode inspectionDateNode =
    //                    node.SelectSingleNode(
    //                        "/*[local-name()='vehicleInspectionResponse']/*[local-name()='permit']/*[local-name()='inspectionDate']");
    //            if (inspectionDateNode != null &&
    //                !string.IsNullOrWhiteSpace(inspectionDateNode.InnerText))
    //            {
    //                return DateTime.ParseExact(inspectionDateNode.InnerText, "yyyy-MM-ddzzz",
    //                                            CultureInfo.InvariantCulture
    //                                                    .DateTimeFormat);
    //            }
    //            return null;
    //        });

    //        mapper.AddPropertyMap(p => p.Permit.InspectionProtocols, "/*[local-name()='vehicleInspectionResponse']/*[local-name()='permit']/*[local-name()='inspectionProtocols']");
    //        mapper.AddPropertyMap(p => p.Permit.KtpAddress, "/*[local-name()='vehicleInspectionResponse']/*[local-name()='permit']/*[local-name()='ktpAddress']");
    //        mapper.AddPropertyMap(p => p.Permit.KtpCategoryLabel, "/*[local-name()='vehicleInspectionResponse']/*[local-name()='permit']/*[local-name()='ktpCategoryLabel']");
    //        mapper.AddPropertyMap(p => p.Permit.KtpCityName, "/*[local-name()='vehicleInspectionResponse']/*[local-name()='permit']/*[local-name()='ktpCityName']");
    //        mapper.AddPropertyMap(p => p.Permit.KtpName, "/*[local-name()='vehicleInspectionResponse']/*[local-name()='permit']/*[local-name()='ktpName']");

    //        mapper.AddFunctionMap(p => p.Permit.LastChangeDate, node =>
    //        {
    //            XmlNode lastChangeDateNode =
    //                    node.SelectSingleNode(
    //                        "/*[local-name()='vehicleInspectionResponse']/*[local-name()='permit']/*[local-name()='lastChangeDate']");
    //            if (lastChangeDateNode != null &&
    //                !string.IsNullOrWhiteSpace(lastChangeDateNode.InnerText))
    //            {
    //                return DateTime.ParseExact(lastChangeDateNode.InnerText, "yyyy-MM-ddzzz",
    //                                            CultureInfo.InvariantCulture
    //                                                    .DateTimeFormat);
    //            }
    //            return null;
    //        });

    //        mapper.AddFunctionMap(p => p.Permit.LineCount, node =>
    //        {
    //            XmlNode lineCountNode =
    //                    node.SelectSingleNode(
    //                        "/*[local-name()='vehicleInspectionResponse']/*[local-name()='permit']/*[local-name()='lineCount']");

    //            if (lineCountNode != null &&
    //                !string.IsNullOrWhiteSpace(lineCountNode.InnerText))
    //            {
    //                short result;
    //                if (short.TryParse(lineCountNode.InnerText, out result))
    //                    return result;
    //            }
    //            return null;
    //        });

    //        mapper.AddFunctionMap(p => p.Permit.ListChangeDate, node =>
    //        {
    //            XmlNode listChangeDateNode =
    //                    node.SelectSingleNode(
    //                        "/*[local-name()='vehicleInspectionResponse']/*[local-name()='permit']/*[local-name()='listChangeDate']");
    //            if (listChangeDateNode != null &&
    //                !string.IsNullOrWhiteSpace(listChangeDateNode.InnerText))
    //            {
    //                return DateTime.ParseExact(listChangeDateNode.InnerText, "yyyy-MM-ddzzz",
    //                                            CultureInfo.InvariantCulture
    //                                                    .DateTimeFormat);
    //            }
    //            return null;
    //        });

    //        mapper.AddPropertyMap(p => p.Permit.OrgUnitShortName, "/*[local-name()='vehicleInspectionResponse']/*[local-name()='permit']/*[local-name()='orgUnitShortName']");
    //        mapper.AddPropertyMap(p => p.Permit.PermitNumber, "/*[local-name()='vehicleInspectionResponse']/*[local-name()='permit']/*[local-name()='permitNumber']");
    //        mapper.AddPropertyMap(p => p.Permit.PermitStatus, "/*[local-name()='vehicleInspectionResponse']/*[local-name()='permit']/*[local-name()='permitStatus']");
    //        mapper.AddPropertyMap(p => p.Permit.PermitStatusCode, "/*[local-name()='vehicleInspectionResponse']/*[local-name()='permit']/*[local-name()='permitStatusCode']");
    //        mapper.AddPropertyMap(p => p.Permit.Remarks, "/*[local-name()='vehicleInspectionResponse']/*[local-name()='permit']/*[local-name()='remarks']");

    //        mapper.AddFunctionMap(p => p.Permit.StampNumber, node =>
    //        {
    //            XmlNode stampNumberNode =
    //                    node.SelectSingleNode(
    //                        "/*[local-name()='vehicleInspectionResponse']/*[local-name()='permit']/*[local-name()='stampNumber']");

    //            if (stampNumberNode != null &&
    //                !string.IsNullOrWhiteSpace(stampNumberNode.InnerText))
    //            {
    //                short result;
    //                if (short.TryParse(stampNumberNode.InnerText, out result))
    //                    return result;
    //            }
    //            return null;
    //        });

    //        mapper.AddPropertyMap(p => p.Permit.SubjectIdentNumber, "/*[local-name()='vehicleInspectionResponse']/*[local-name()='permit']/*[local-name()='subjectIdentNumber']");

    //        mapper.AddFunctionMap(p => p.Permit.ValidTo, node =>
    //        {
    //            XmlNode validToNode =
    //                    node.SelectSingleNode(
    //                        "/*[local-name()='vehicleInspectionResponse']/*[local-name()='permit']/*[local-name()='validTo']");
    //            if (validToNode != null &&
    //                !string.IsNullOrWhiteSpace(validToNode.InnerText))
    //            {
    //                return DateTime.ParseExact(validToNode.InnerText, "yyyy-MM-ddzzz",
    //                                            CultureInfo.InvariantCulture
    //                                                    .DateTimeFormat);
    //            }
    //            return null;
    //        });

    //        mapper.AddFunctionMap(p => p.ProtocolNumber, node =>
    //        {
    //            XmlNode protocolNumberNode =
    //                    node.SelectSingleNode(
    //                        "/*[local-name()='vehicleInspectionResponse']/*[local-name()='protocolNumber']");

    //            if (protocolNumberNode != null &&
    //                !string.IsNullOrWhiteSpace(protocolNumberNode.InnerText))
    //            {
    //                long result;
    //                if (long.TryParse(protocolNumberNode.InnerText, out result))
    //                    return result;
    //            }
    //            return null;
    //        });

    //        mapper.AddPropertyMap(p => p.RegNumber, "/*[local-name()='vehicleInspectionResponse']/*[local-name()='regNumber']");

    //        mapper.AddFunctionMap(p => p.StickerNumber, node =>
    //        {
    //            XmlNode stickerNumberNode =
    //                    node.SelectSingleNode(
    //                        "/*[local-name()='vehicleInspectionResponse']/*[local-name()='stickerNumber']");

    //            if (stickerNumberNode != null &&
    //                !string.IsNullOrWhiteSpace(stickerNumberNode.InnerText))
    //            {
    //                long result;
    //                if (long.TryParse(stickerNumberNode.InnerText, out result))
    //                    return result;
    //            }
    //            return null;
    //        });

    //        return mapper;
    //    }

    //    public CommonSignedResponse<VehicleInspectionStickerRequestType, VehicleInspectionResponse> GetReport5VehicleInspectionSticker(VehicleInspectionStickerRequestType argument, AccessMatrix accessMatrix, AdapterAdditionalParameters aditionalParameters)
    //    {
    //        Guid id = Guid.NewGuid();
    //        LogData(aditionalParameters, new { Request = argument.Serialize(), Guid = id });
    //        try
    //        {
    //            var serviceClient = new HttpClient();
    //            serviceClient.BaseAddress = new Uri(WebServiceUrl.Value);
    //            serviceClient.DefaultRequestHeaders.Accept.Clear();
    //            serviceClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/xml"));

    //            ServiceXMLShemas.vehicleInspectionStickerRequest param = new ServiceXMLShemas.vehicleInspectionStickerRequest();
    //            param.context = aditionalParameters.CallContext.ToString();
    //            param.regNumber = argument.RegNumber;
    //            param.stickerNumber = argument.StickerNumber;
    //            param.stickerNumberSpecified = argument.StickerNumberSpecified;
    //            string request = param.XmlSerialize();

    //            string responseString = GetResponse(serviceClient, request, Report5VehicleInspectionStickerMethodName.Value, id, aditionalParameters).Result;
    //            XElement resultXmlElement = XDocument.Parse(responseString).Root;

    //            XPathMapper<VehicleInspectionResponse> responseMapper = CreateVehicleInspectionResponseMapper(accessMatrix);
    //            VehicleInspectionResponse result = new VehicleInspectionResponse();
    //            responseMapper.Map(resultXmlElement, result);

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


    //}
}
