﻿namespace TechnoLogica.RegiX.IaaaEducationCentersAdapter.AdapterService
{
    //public class IaaaEducationCentersAdapter : RestServiceBaseAdapterService, IIaaaEducationCentersAdapter, IAdapterService
    //{
    //    [Export(typeof(ParameterInfo))]
    //    public static ParameterInfo<string> WebServiceUrl =
    //        new ParameterInfo<string>("http://213.91.157.27:7461/egov-web/api/redu/reports/")
    //        {
    //            Key = Constants.WebServiceUrlParameterKeyName,
    //            Description = "Web Service Url",
    //            OwnerAssembly = typeof(IaaaEducationCentersAdapter).Assembly
    //        };

    //    #region

    //    [Export(typeof(ParameterInfo))]
    //    public static ParameterInfo<string> GetReport1PermitMethodName =
    //            new ParameterInfo<string>("permits")
    //            {
    //                Key = "Report1PermitMethodName",
    //                Description = "Method name describing the service url",
    //                OwnerAssembly = typeof(IaaaEducationCentersAdapter).Assembly
    //            };

    //    [Export(typeof(ParameterInfo))]
    //    public static ParameterInfo<string> GetReport4InstructorPermitsDetailsMethodName =
    //            new ParameterInfo<string>("permit-instructor")
    //            {
    //                Key = "GetReport4InstructorPermitsDetailsMethodName",
    //                Description = "Method name describing the service url",
    //                OwnerAssembly = typeof(IaaaEducationCentersAdapter).Assembly
    //            };

    //    [Export(typeof(ParameterInfo))]
    //    public static ParameterInfo<string> GetReport5PermitsExamPeopleCountMethodName =
    //            new ParameterInfo<string>("permits-exam-people-count")
    //            {
    //                Key = "GetReport5PermitsExamPeopleCountMethodName",
    //                Description = "Method name describing the service url",
    //                OwnerAssembly = typeof(IaaaEducationCentersAdapter).Assembly
    //            };

    //    [Export(typeof(ParameterInfo))]
    //    public static ParameterInfo<string> GetReport6SubjectOwnedCategoriesMethodName =
    //            new ParameterInfo<string>("subject-owned-categories")
    //            {
    //                Key = "GetReport6SubjectOwnedCategoriesMethodName",
    //                Description = "Method name describing the service url",
    //                OwnerAssembly = typeof(IaaaEducationCentersAdapter).Assembly
    //            };
    //    #endregion

    //    public override string CheckRegisterConnection()
    //    {
    //        Dictionary<string, string> results = new Dictionary<string, string>();
    //        string resultReport1PermitMethodName = CheckConnectionsUtils.CheckConnection(WebServiceUrl.Value + GetReport1PermitMethodName.Value);
    //        string resultReport2PermitsInstructorsReportMethodName = CheckConnectionsUtils.CheckConnection(WebServiceUrl.Value + GetReport4InstructorPermitsDetailsMethodName.Value);
    //        string resultReport3PermitsExamPeopleCountReportMethodName = CheckConnectionsUtils.CheckConnection(WebServiceUrl.Value + GetReport5PermitsExamPeopleCountMethodName.Value);
    //        string resultReport4SubjectOwnedCategoriesMethodName = CheckConnectionsUtils.CheckConnection(WebServiceUrl.Value + GetReport6SubjectOwnedCategoriesMethodName.Value);

    //        results.Add("Report1PermitMethodName", resultReport1PermitMethodName);
    //        results.Add("Report2PermitsInstructorsReportMethodName", resultReport2PermitsInstructorsReportMethodName);
    //        results.Add("Report3PermitsExamPeopleCountReportMethodName", resultReport3PermitsExamPeopleCountReportMethodName);
    //        results.Add("Report4SubjectOwnedCategoriesMethodName", resultReport4SubjectOwnedCategoriesMethodName);

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

    //    public CommonSignedResponse<PermitsRequestType, PermitResponse> GetReport1Permit(PermitsRequestType argument, AccessMatrix accessMatrix, AdapterAdditionalParameters aditionalParameters)
    //    {
    //        Guid id = Guid.NewGuid();
    //        LogData(aditionalParameters, new { Request = argument.Serialize(), Guid = id });
    //        try
    //        {
    //            var serviceClient = new HttpClient();
    //            serviceClient.BaseAddress = new Uri(WebServiceUrl.Value);
    //            serviceClient.DefaultRequestHeaders.Accept.Clear();
    //            serviceClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/xml"));

    //            ServiceXMLShemas.permitsRequest param = new ServiceXMLShemas.permitsRequest();
    //            param.context = aditionalParameters.CallContext.ToString();
    //            param.identNumber = argument.IdentNumber;
    //            string request = param.XmlSerialize();

    //            string responseString = GetResponse(serviceClient, request, GetReport1PermitMethodName.Value, id, aditionalParameters).Result;
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
    //        mapper.AddPropertyMap(p => p.Permits[0].Number, "./*[local-name()='number']");
    //        mapper.AddPropertyMap(p => p.Permits[0].Address, "./*[local-name()='address']");
    //        mapper.AddFunctionMap(p => p.Permits[0].CeaseDate, node =>
    //        {
    //            XmlNode ceaseDateNode =
    //                    node.SelectSingleNode(
    //                        "./*[local-name()='ceaseDate']");
    //            if (ceaseDateNode != null &&
    //                !string.IsNullOrWhiteSpace(ceaseDateNode.InnerText))
    //            {
    //                return DateTime.ParseExact(ceaseDateNode.InnerText, "yyyy-MM-ddzzz",
    //                                            CultureInfo.InvariantCulture
    //                                                    .DateTimeFormat);
    //            }
    //            return null;
    //        });

    //        mapper.AddPropertyMap(p => p.Permits[0].CompanyFullName, "./*[local-name()='companyFullName']");
    //        mapper.AddPropertyMap(p => p.Permits[0].CompanyIdentNumber, "./*[local-name()='companyIdentNumber']");

    //        mapper.AddFunctionMap(p => p.Permits[0].ExamRoomsCount, node =>
    //        {
    //            XmlNode examRoomsCountNode =
    //                    node.SelectSingleNode(
    //                        "./*[local-name()='examRoomsCount']");

    //            if (examRoomsCountNode != null &&
    //                !string.IsNullOrWhiteSpace(examRoomsCountNode.InnerText))
    //            {
    //                short result;
    //                if (short.TryParse(examRoomsCountNode.InnerText, out result))
    //                return result;
    //            }
    //            return null;
    //        });

    //        mapper.AddFunctionMap(p => p.Permits[0].ExamSeatsCount, node =>
    //        {
    //            XmlNode examSeatsCountNode =
    //                    node.SelectSingleNode(
    //                        "./*[local-name()='examSeatsCount']");

    //            if (examSeatsCountNode != null &&
    //                !string.IsNullOrWhiteSpace(examSeatsCountNode.InnerText))
    //            {
    //                short result;
    //                if (short.TryParse(examSeatsCountNode.InnerText, out result))
    //                return result;
    //            }
    //            return null;
    //        });

    //        mapper.AddFunctionMap(p => p.Permits[0].IssueDate, node =>
    //        {
    //            XmlNode issueDateNode =
    //                    node.SelectSingleNode(
    //                        "./*[local-name()='issueDate']");
    //            if (issueDateNode != null &&
    //                !string.IsNullOrWhiteSpace(issueDateNode.InnerText))
    //            {
    //                return DateTime.ParseExact(issueDateNode.InnerText, "yyyy-MM-ddzzz",
    //                                            CultureInfo.InvariantCulture
    //                                                    .DateTimeFormat);
    //            }
    //            return null;
    //        });

    //        mapper.AddPropertyMap(p => p.Permits[0].ManagerFullName, "./*[local-name()='managerFullName']");
    //        mapper.AddPropertyMap(p => p.Permits[0].ManagerIdentNumber, "./*[local-name()='managerIdentNumber']");
    //        mapper.AddPropertyMap(p => p.Permits[0].Number, "./*[local-name()='number']");
    //        mapper.AddPropertyMap(p => p.Permits[0].OrgUnitShortName, "./*[local-name()='orgUnitShortName']");
    //        mapper.AddPropertyMap(p => p.Permits[0].PermitType, "./*[local-name()='permitType']");

    //        mapper.AddFunctionMap(p => p.Permits[0].SeatPlacesCount, node =>
    //        {
    //            XmlNode seatplacesCountNode =
    //                    node.SelectSingleNode(
    //                        "./*[local-name()='seatplacesCount']");

    //            if (seatplacesCountNode != null &&
    //                !string.IsNullOrWhiteSpace(seatplacesCountNode.InnerText))
    //            {
    //                short result;
    //                if (short.TryParse(seatplacesCountNode.InnerText, out result))
    //                return result;
    //            }
    //            return null;
    //        });

    //        mapper.AddPropertyMap(p => p.Permits[0].Status, "./*[local-name()='status']");
    //        mapper.AddPropertyMap(p => p.Permits[0].TechAssistantFullName, "./*[local-name()='techAssistantFullName']");
    //        mapper.AddPropertyMap(p => p.Permits[0].TechAssistantIdentNumber, "./*[local-name()='techAssistantIdentNumber']");

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

    //    public CommonSignedResponse<PermitsRequestType, PermitInstructorsResponse> GetReport2PermitInstructors(PermitsRequestType argument, AccessMatrix accessMatrix, AdapterAdditionalParameters aditionalParameters)
    //    {
    //        Guid id = Guid.NewGuid();
    //        LogData(aditionalParameters, new { Request = argument.Serialize(), Guid = id });
    //        try
    //        {
    //            var serviceClient = new HttpClient();
    //            serviceClient.BaseAddress = new Uri(WebServiceUrl.Value);
    //            serviceClient.DefaultRequestHeaders.Accept.Clear();
    //            serviceClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/xml"));

    //            ServiceXMLShemas.permitsRequest param = new ServiceXMLShemas.permitsRequest();
    //            param.context = aditionalParameters.CallContext.ToString();
    //            param.identNumber = argument.IdentNumber;
    //            string request = param.XmlSerialize();

    //            string responseString = GetResponse(serviceClient, request, GetReport1PermitMethodName.Value, id, aditionalParameters).Result;
    //            XElement resultXmlElement = XDocument.Parse(responseString).Root;

    //            XPathMapper<PermitInstructorsResponse> responseMapper = CreatePermitInstructorsMapper(accessMatrix);
    //            PermitInstructorsResponse result = new PermitInstructorsResponse();
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

    //    private static XPathMapper<PermitInstructorsResponse> CreatePermitInstructorsMapper(AccessMatrix accessMatrix)
    //    {
    //        XPathMapper<PermitInstructorsResponse> mapper =
    //            new XPathMapper<PermitInstructorsResponse>(accessMatrix);

    //        mapper.AddCollectionMap(p => p.Permits, "/*[local-name()='permitResponse']/*[local-name()='permits']/*[local-name()='permit']");

    //        mapper.AddPropertyMap(p => p.Permits[0].Number, "./*[local-name()='number']");

    //        mapper.AddPropertyMap(p => p.Permits[0].CompanyFullName, "./*[local-name()='companyFullName']");
    //        mapper.AddPropertyMap(p => p.Permits[0].CompanyIdentNumber, "./*[local-name()='companyIdentNumber']");

    //        mapper.AddCollectionMap(p => p.Permits[0].Instructors, "./*[local-name()='instructors']/*[local-name()='instructor']");

    //        mapper.AddFunctionMap(p => p.Permits[0].Instructors[0].ExamModuleNames, node =>
    //        {
    //            XmlNodeList examModuleNamesNodes =
    //                    node.SelectNodes(
    //                        "./*[local-name()='examModuleNames']/*[local-name()='examModuleName']");
    //            if (examModuleNamesNodes != null)
    //            {
    //                List<string> result = new List<string>();
    //                foreach (XmlNode item in examModuleNamesNodes)
    //                {
    //                    result.Add(item.InnerText);
    //                }
    //                return result;
    //            }
    //            return null;
    //        });

    //        mapper.AddFunctionMap(p => p.Permits[0].Instructors[0].LastDrivingLicenceCertificateCategories, node =>
    //        {
    //            XmlNode issueDateNode =
    //                    node.SelectSingleNode(
    //                        "./*[local-name()='lastDrivingLicenceCertificateCategories']");
    //            if (issueDateNode != null &&
    //                !string.IsNullOrWhiteSpace(issueDateNode.InnerText))
    //            {
    //                return issueDateNode.InnerText.Split(',').ToList();
    //            }
    //            return null;
    //        });

    //        mapper.AddFunctionMap(p => p.Permits[0].Instructors[0].LastDrivingLicenceCertificateIssueDate, node =>
    //        {
    //            XmlNode lastDrivingLicenceCertificateIssueDateNode =
    //                    node.SelectSingleNode(
    //                        "./*[local-name()='lastDrivingLicenceCertificateIssueDate']");
    //            if (lastDrivingLicenceCertificateIssueDateNode != null &&
    //                !string.IsNullOrWhiteSpace(lastDrivingLicenceCertificateIssueDateNode.InnerText))
    //            {
    //                return DateTime.ParseExact(lastDrivingLicenceCertificateIssueDateNode.InnerText, "yyyy-MM-ddzzz",
    //                                            CultureInfo.InvariantCulture
    //                                                    .DateTimeFormat);
    //            }
    //            return null;
    //        });

    //        mapper.AddPropertyMap(p => p.Permits[0].Instructors[0].LastDrivingLicenceCertificateNumber, "./*[local-name()='lastDrivingLicenceCertificateNumber']");

    //        mapper.AddFunctionMap(p => p.Permits[0].Instructors[0].LastQualificationCertificateIssueDate, node =>
    //        {
    //            XmlNode lastQualificationCertificateIssueDateNode =
    //                    node.SelectSingleNode(
    //                        "./*[local-name()='lastQualificationCertificateIssueDate']");
    //            if (lastQualificationCertificateIssueDateNode != null &&
    //                !string.IsNullOrWhiteSpace(lastQualificationCertificateIssueDateNode.InnerText))
    //            {
    //                return DateTime.ParseExact(lastQualificationCertificateIssueDateNode.InnerText, "yyyy-MM-ddzzz",
    //                                            CultureInfo.InvariantCulture
    //                                                    .DateTimeFormat);
    //            }
    //            return null;
    //        });

    //        mapper.AddPropertyMap(p => p.Permits[0].Instructors[0].LastQualificationCertificateIssuedBy, "./*[local-name()='lastQualificationCertificateIssuedBy']");
    //        mapper.AddPropertyMap(p => p.Permits[0].Instructors[0].LastQualificationCertificateNumber, "./*[local-name()='lastQualificationCertificateNumber']");
    //        mapper.AddPropertyMap(p => p.Permits[0].Instructors[0].SubjectFullName, "./*[local-name()='subjectFullName']");
    //        mapper.AddPropertyMap(p => p.Permits[0].Instructors[0].SubjectIdentNumber, "./*[local-name()='subjectIdentNumber']");

    //        mapper.AddFunctionMap(p => p.Permits[0].IssueDate, node =>
    //        {
    //            XmlNode issueDateNode =
    //                    node.SelectSingleNode(
    //                        "./*[local-name()='issueDate']");
    //            if (issueDateNode != null &&
    //                !string.IsNullOrWhiteSpace(issueDateNode.InnerText))
    //            {
    //                return DateTime.ParseExact(issueDateNode.InnerText, "yyyy-MM-ddzzz",
    //                                            CultureInfo.InvariantCulture
    //                                                    .DateTimeFormat);
    //            }
    //            return null;
    //        });

    //        mapper.AddFunctionMap(p => p.Permits[0].ValidTo, node =>
    //        {
    //            XmlNode issueDateNode =
    //                    node.SelectSingleNode(
    //                        "./*[local-name()='validTo']");
    //            if (issueDateNode != null &&
    //                !string.IsNullOrWhiteSpace(issueDateNode.InnerText))
    //            {
    //                return DateTime.ParseExact(issueDateNode.InnerText, "yyyy-MM-ddzzz",
    //                                            CultureInfo.InvariantCulture
    //                                                    .DateTimeFormat);
    //            }
    //            return null;
    //        });

    //        return mapper;
    //    }

    //    public CommonSignedResponse<PermitsRequestType, PermitVehiclesResponse> GetReport3PermitVehicles(PermitsRequestType argument, AccessMatrix accessMatrix, AdapterAdditionalParameters aditionalParameters)
    //    {
    //        Guid id = Guid.NewGuid();
    //        LogData(aditionalParameters, new { Request = argument.Serialize(), Guid = id });
    //        try
    //        {
    //            var serviceClient = new HttpClient();
    //            serviceClient.BaseAddress = new Uri(WebServiceUrl.Value);
    //            serviceClient.DefaultRequestHeaders.Accept.Clear();
    //            serviceClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/xml"));

    //            ServiceXMLShemas.permitsRequest param = new ServiceXMLShemas.permitsRequest();
    //            param.context = aditionalParameters.CallContext.ToString();
    //            param.identNumber = argument.IdentNumber;
    //            string request = param.XmlSerialize();

    //            string responseString = GetResponse(serviceClient, request, GetReport1PermitMethodName.Value, id, aditionalParameters).Result;
    //            XElement resultXmlElement = XDocument.Parse(responseString).Root;

    //            XPathMapper<PermitVehiclesResponse> responseMapper = CreatePermitVehiclesResponseMapper(accessMatrix);
    //            PermitVehiclesResponse result = new PermitVehiclesResponse();
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

    //    private static XPathMapper<PermitVehiclesResponse> CreatePermitVehiclesResponseMapper(AccessMatrix accessMatrix)
    //    {
    //        XPathMapper<PermitVehiclesResponse> mapper =
    //            new XPathMapper<PermitVehiclesResponse>(accessMatrix);

    //        mapper.AddCollectionMap(p => p.Permits, "/*[local-name()='permitResponse']/*[local-name()='permits']/*[local-name()='permit']");
    //        mapper.AddPropertyMap(p => p.Permits[0].Number, "./*[local-name()='number']");

    //        mapper.AddPropertyMap(p => p.Permits[0].CompanyFullName, "./*[local-name()='companyFullName']");
    //        mapper.AddPropertyMap(p => p.Permits[0].CompanyIdentNumber, "./*[local-name()='companyIdentNumber']");


    //        mapper.AddFunctionMap(p => p.Permits[0].IssueDate, node =>
    //        {
    //            XmlNode issueDateNode =
    //                    node.SelectSingleNode(
    //                        "./*[local-name()='issueDate']");
    //            if (issueDateNode != null &&
    //                !string.IsNullOrWhiteSpace(issueDateNode.InnerText))
    //            {
    //                return DateTime.ParseExact(issueDateNode.InnerText, "yyyy-MM-ddzzz",
    //                                            CultureInfo.InvariantCulture
    //                                                    .DateTimeFormat);
    //            }
    //            return null;
    //        });

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

    //        mapper.AddCollectionMap(p => p.Permits[0].Vehicles, "./*[local-name()='vehicles']/*[local-name()='vehicle']");
    //        mapper.AddPropertyMap(p => p.Permits[0].Vehicles[0].CargoDepartmentHeight, "./*[local-name()='cargoDepartmentHeight']");
    //        mapper.AddPropertyMap(p => p.Permits[0].Vehicles[0].CargoDepartmentWidth, "./*[local-name()='cargoDepartmentWidth']");
    //        mapper.AddPropertyMap(p => p.Permits[0].Vehicles[0].Categories, "./*[local-name()='categories']");

    //        mapper.AddFunctionMap(p => p.Permits[0].Vehicles[0].CertificateDate, node =>
    //        {
    //            XmlNode certificateDateNode =
    //                    node.SelectSingleNode(
    //                        "./*[local-name()='certificateDate']");
    //            if (certificateDateNode != null &&
    //                !string.IsNullOrWhiteSpace(certificateDateNode.InnerText))
    //            {
    //                return DateTime.ParseExact(certificateDateNode.InnerText, "yyyy-MM-ddzzz",
    //                                            CultureInfo.InvariantCulture
    //                                                    .DateTimeFormat);
    //            }
    //            return null;
    //        });

    //        mapper.AddPropertyMap(p => p.Permits[0].Vehicles[0].CertificateNumber, "./*[local-name()='certificateNumber']");

    //        mapper.AddFunctionMap(p => p.Permits[0].Vehicles[0].Code78, node =>
    //        {
    //            XmlNode code78Node =
    //                    node.SelectSingleNode(
    //                        "./*[local-name()='code78']");

    //            if (code78Node != null &&
    //                !string.IsNullOrWhiteSpace(code78Node.InnerText))
    //            {
    //                bool result;
    //                if (bool.TryParse(code78Node.InnerText, out result))
    //                    return result;
    //            }
    //            return null;
    //        });

    //        mapper.AddPropertyMap(p => p.Permits[0].Vehicles[0].EngineCapacity, "./*[local-name()='engineCapacity']");
    //        mapper.AddPropertyMap(p => p.Permits[0].Vehicles[0].Gears, "./*[local-name()='gears']");

    //        mapper.AddFunctionMap(p => p.Permits[0].Vehicles[0].HasABS, node =>
    //        {
    //            XmlNode hasABSNode =
    //                    node.SelectSingleNode(
    //                        "./*[local-name()='hasABS']");

    //            if (hasABSNode != null &&
    //                !string.IsNullOrWhiteSpace(hasABSNode.InnerText))
    //            {
    //                bool result;
    //                if (bool.TryParse(hasABSNode.InnerText, out result))
    //                    return result;
    //            }
    //            return null;
    //        });

    //        mapper.AddFunctionMap(p => p.Permits[0].Vehicles[0].HasTachograph, node =>
    //        {
    //            XmlNode hasTachographNode =
    //                    node.SelectSingleNode(
    //                        "./*[local-name()='hasTachograph']");

    //            if (hasTachographNode != null &&
    //                !string.IsNullOrWhiteSpace(hasTachographNode.InnerText))
    //            {
    //                bool result;
    //                if (bool.TryParse(hasTachographNode.InnerText, out result))
    //                    return result;
    //            }
    //            return null;
    //        });

    //        mapper.AddPropertyMap(p => p.Permits[0].Vehicles[0].IdentNumber, "./*[local-name()='identNumber']");
    //        mapper.AddPropertyMap(p => p.Permits[0].Vehicles[0].Length, "./*[local-name()='length']");
    //        mapper.AddPropertyMap(p => p.Permits[0].Vehicles[0].Make, "./*[local-name()='make']");
    //        mapper.AddPropertyMap(p => p.Permits[0].Vehicles[0].MaximumDesignSpeed, "./*[local-name()='maximumDesignSpeed']");
    //        mapper.AddPropertyMap(p => p.Permits[0].Vehicles[0].MaxPermittedDefinedMass, "./*[local-name()='maxPermittedDefinedMass']");

    //        mapper.AddFunctionMap(p => p.Permits[0].Vehicles[0].MaxPower, node =>
    //        {
    //            XmlNode maxPowerNode =
    //                    node.SelectSingleNode(
    //                        "./*[local-name()='maxPower']");

    //            if (maxPowerNode != null &&
    //                !string.IsNullOrWhiteSpace(maxPowerNode.InnerText))
    //            {
    //                short result;
    //                if (short.TryParse(maxPowerNode.InnerText, out result))
    //                    return result;
    //            }
    //            return null;
    //        });

    //        mapper.AddPropertyMap(p => p.Permits[0].Vehicles[0].PowerToWeightRatio, "./*[local-name()='powerToWeightRatio']");

    //        mapper.AddFunctionMap(p => p.Permits[0].Vehicles[0].ProtocolDate, node =>
    //        {
    //            XmlNode protocolDateNode =
    //                    node.SelectSingleNode(
    //                        "./*[local-name()='protocolDate']");
    //            if (protocolDateNode != null &&
    //                !string.IsNullOrWhiteSpace(protocolDateNode.InnerText))
    //            {
    //                return DateTime.ParseExact(protocolDateNode.InnerText, "yyyy-MM-ddzzz",
    //                                            CultureInfo.InvariantCulture
    //                                                    .DateTimeFormat);
    //            }
    //            return null;
    //        });

    //        mapper.AddPropertyMap(p => p.Permits[0].Vehicles[0].ProtocolNumber, "./*[local-name()='protocolNumber']");
    //        mapper.AddPropertyMap(p => p.Permits[0].Vehicles[0].RegNumber, "./*[local-name()='regNumber']");
    //        mapper.AddPropertyMap(p => p.Permits[0].Vehicles[0].SeatPlaces, "./*[local-name()='seatPlaces']");
    //        mapper.AddPropertyMap(p => p.Permits[0].Vehicles[0].Width, "./*[local-name()='width']");

    //        return mapper;
    //    }

    //    public CommonSignedResponse<PermitsInstructorsRequestType, PermitsInstructorsResponse> GetReport4InstructorPermitsDetails(PermitsInstructorsRequestType argument, AccessMatrix accessMatrix, AdapterAdditionalParameters aditionalParameters)
    //    {
    //        Guid id = Guid.NewGuid();
    //        LogData(aditionalParameters, new { Request = argument.Serialize(), Guid = id });
    //        try
    //        {
    //            var serviceClient = new HttpClient();
    //            serviceClient.BaseAddress = new Uri(WebServiceUrl.Value);
    //            serviceClient.DefaultRequestHeaders.Accept.Clear();
    //            serviceClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/xml"));

    //            ServiceXMLShemas.permitsInstructorsReportRequest param = new ServiceXMLShemas.permitsInstructorsReportRequest();
    //            param.context = aditionalParameters.CallContext.ToString();
    //            param.subjectIdentNumber = argument.SubjectIdentNumber;
    //            string request = param.XmlSerialize();

    //            string responseString = GetResponse(serviceClient, request, GetReport4InstructorPermitsDetailsMethodName.Value, id, aditionalParameters).Result;
    //            XElement resultXmlElement = XDocument.Parse(responseString).Root;

    //            XPathMapper<PermitsInstructorsResponse> responseMapper = CreatePermitsInstructorsResponseMapper(accessMatrix);
    //            PermitsInstructorsResponse result = new PermitsInstructorsResponse();
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

    //    private static XPathMapper<PermitsInstructorsResponse> CreatePermitsInstructorsResponseMapper(AccessMatrix accessMatrix)
    //    {
    //        XPathMapper<PermitsInstructorsResponse> mapper =
    //           new XPathMapper<PermitsInstructorsResponse>(accessMatrix);

    //        mapper.AddFunctionMap(p => p.Instructor, node =>
    //        {
    //            XmlNode permitNode =
    //                    node.SelectSingleNode(
    //                        "/*[local-name()='permitsInstructorsReportResponse']/*[local-name()='instructor']");
    //            if (permitNode != null &&
    //                !string.IsNullOrWhiteSpace(permitNode.InnerText))
    //            {
    //                return new InstructorWithPermitsDto();
    //            }
    //            return null;
    //        });

    //        mapper.AddFunctionMap(p => p.Instructor.ExamModuleNames, node =>
    //            {
    //                var examModuleNamesNode = node.SelectNodes("/*[local-name()='permitsInstructorsReportResponse']/*[local-name()='instructor']/*[local-name()='examModuleNames']/*[local-name()='examModuleName']");

    //                if (examModuleNamesNode != null)
    //                    {
    //                        List<string> names = new List<string>();
    //                        foreach (XmlNode item in examModuleNamesNode)
    //                        {
    //                            names.Add(item.InnerText);
    //                        }
    //                        return names;
    //                    }
    //                return null;
    //            });

    //        mapper.AddCollectionMap(p => p.Instructor.InstructorPermits, "/*[local-name()='permitsInstructorsReportResponse']/*[local-name()='instructor']/*[local-name()='instructorPermits']/*[local-name()='instructorPermit']");
    //        mapper.AddCollectionMap(p => p.Instructor.InstructorPermits[0].Certificates, "./*[local-name()='certificates']/*[local-name()='certificate']");
    //        mapper.AddPropertyMap(p => p.Instructor.InstructorPermits[0].Certificates[0].ExamTypePermission, "./*[local-name()='examTypePermission']");

    //        mapper.AddFunctionMap(p => p.Instructor.InstructorPermits[0].Certificates[0].PermitCertificateIssueDate, node =>
    //        {
    //            XmlNode permitCertificateIssueDateNode =
    //                    node.SelectSingleNode(
    //                        "./*[local-name()='permitCertificateIssueDate']");
    //            if (permitCertificateIssueDateNode != null &&
    //                !string.IsNullOrWhiteSpace(permitCertificateIssueDateNode.InnerText))
    //            {
    //                return DateTime.ParseExact(permitCertificateIssueDateNode.InnerText, "yyyy-MM-ddzzz",
    //                                            CultureInfo.InvariantCulture
    //                                                    .DateTimeFormat);
    //            }
    //            return null;
    //        });

    //        mapper.AddPropertyMap(p => p.Instructor.InstructorPermits[0].Certificates[0].PermitCertificateNumber, "./*[local-name()='permitCertificateNumber']");

    //        mapper.AddFunctionMap(p => p.Instructor.InstructorPermits[0].Permit, node =>
    //        {
    //            XmlNode permitNode =
    //                    node.SelectSingleNode(
    //                        "./*[local-name()='permit']");
    //            if (permitNode != null &&
    //                !string.IsNullOrWhiteSpace(permitNode.InnerText))
    //            {
    //                return new PermitWithVehiclesDto();
    //            }
    //            return null;
    //        });

    //        mapper.AddPropertyMap(p => p.Instructor.InstructorPermits[0].Permit.Address, "./*[local-name()='permit']/*[local-name()='address']");

    //        mapper.AddFunctionMap(p => p.Instructor.InstructorPermits[0].Permit.CeaseDate, node =>
    //        {
    //            XmlNode ceaseDateNode =
    //                    node.SelectSingleNode(
    //                        "./*[local-name()='permit']/*[local-name()='ceaseDate']");
    //            if (ceaseDateNode != null &&
    //                !string.IsNullOrWhiteSpace(ceaseDateNode.InnerText))
    //            {
    //                return DateTime.ParseExact(ceaseDateNode.InnerText, "yyyy-MM-ddzzz",
    //                                            CultureInfo.InvariantCulture
    //                                                    .DateTimeFormat);
    //            }
    //            return null;
    //        });

    //        mapper.AddPropertyMap(p => p.Instructor.InstructorPermits[0].Permit.CompanyFullName, "./*[local-name()='permit']/*[local-name()='companyFullName']");
    //        mapper.AddPropertyMap(p => p.Instructor.InstructorPermits[0].Permit.CompanyIdentNumber, "./*[local-name()='permit']/*[local-name()='companyIdentNumber']");

    //        mapper.AddFunctionMap(p => p.Instructor.InstructorPermits[0].Permit.ExamRoomsCount, node =>
    //        {
    //            XmlNode examRoomsCountNode =
    //                    node.SelectSingleNode(
    //                        "./*[local-name()='permit']/*[local-name()='examRoomsCount']");

    //            if (examRoomsCountNode != null &&
    //                !string.IsNullOrWhiteSpace(examRoomsCountNode.InnerText))
    //            {
    //                short result;
    //                if (short.TryParse(examRoomsCountNode.InnerText, out result))
    //                    return result;
    //            }
    //            return null;
    //        });

    //        mapper.AddFunctionMap(p => p.Instructor.InstructorPermits[0].Permit.ExamSeatsCount, node =>
    //        {
    //            XmlNode examSeatsCountNode =
    //                    node.SelectSingleNode(
    //                        "./*[local-name()='permit']/*[local-name()='examSeatsCount']");

    //            if (examSeatsCountNode != null &&
    //                !string.IsNullOrWhiteSpace(examSeatsCountNode.InnerText))
    //            {
    //                short result;
    //                if (short.TryParse(examSeatsCountNode.InnerText, out result))
    //                    return result;
    //            }
    //            return null;
    //        });

    //        mapper.AddFunctionMap(p => p.Instructor.InstructorPermits[0].Permit.IssueDate, node =>
    //        {
    //            XmlNode issueDateNode =
    //                    node.SelectSingleNode(
    //                        "./*[local-name()='permit']/*[local-name()='issueDate']");
    //            if (issueDateNode != null &&
    //                !string.IsNullOrWhiteSpace(issueDateNode.InnerText))
    //            {
    //                return DateTime.ParseExact(issueDateNode.InnerText, "yyyy-MM-ddzzz",
    //                                            CultureInfo.InvariantCulture
    //                                                    .DateTimeFormat);
    //            }
    //            return null;
    //        });

    //        mapper.AddPropertyMap(p => p.Instructor.InstructorPermits[0].Permit.ManagerFullName, "./*[local-name()='permit']/*[local-name()='managerFullName']");
    //        mapper.AddPropertyMap(p => p.Instructor.InstructorPermits[0].Permit.ManagerIdentNumber, "./*[local-name()='permit']/*[local-name()='managerIdentNumber']");
    //        mapper.AddPropertyMap(p => p.Instructor.InstructorPermits[0].Permit.Number, "./*[local-name()='permit']/*[local-name()='number']");
    //        mapper.AddPropertyMap(p => p.Instructor.InstructorPermits[0].Permit.OrgUnitShortName, "./*[local-name()='permit']/*[local-name()='orgUnitShortName']");
    //        mapper.AddPropertyMap(p => p.Instructor.InstructorPermits[0].Permit.PermitType, "./*[local-name()='permit']/*[local-name()='permitType']");

    //        mapper.AddFunctionMap(p => p.Instructor.InstructorPermits[0].Permit.SeatPlacesCount, node =>
    //        {
    //            XmlNode seatplacesCountNode =
    //                    node.SelectSingleNode(
    //                        "./*[local-name()='permit']/*[local-name()='seatplacesCount']");

    //            if (seatplacesCountNode != null &&
    //                !string.IsNullOrWhiteSpace(seatplacesCountNode.InnerText))
    //            {
    //                short result;
    //                if (short.TryParse(seatplacesCountNode.InnerText, out result))
    //                    return result;
    //            }
    //            return null;
    //        });

    //        mapper.AddPropertyMap(p => p.Instructor.InstructorPermits[0].Permit.Status, "./*[local-name()='permit']/*[local-name()='status']");
    //        mapper.AddPropertyMap(p => p.Instructor.InstructorPermits[0].Permit.TechAssistantFullName, "./*[local-name()='permit']/*[local-name()='techAssistantFullName']");
    //        mapper.AddPropertyMap(p => p.Instructor.InstructorPermits[0].Permit.TechAssistantIdentNumber, "./*[local-name()='permit']/*[local-name()='techAssistantIdentNumber']");

    //        mapper.AddFunctionMap(p => p.Instructor.InstructorPermits[0].Permit.ValidTo, node =>
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

    //        mapper.AddCollectionMap(p => p.Instructor.InstructorPermits[0].Permit.Vehicles, "./*[local-name()='permit']/*[local-name()='vehicles']/*[local-name()='vehicle']");
    //        mapper.AddPropertyMap(p => p.Instructor.InstructorPermits[0].Permit.Vehicles[0].CargoDepartmentHeight, "./*[local-name()='cargoDepartmentHeight']");
    //        mapper.AddPropertyMap(p => p.Instructor.InstructorPermits[0].Permit.Vehicles[0].CargoDepartmentWidth, "./*[local-name()='cargoDepartmentWidth']");
    //        mapper.AddPropertyMap(p => p.Instructor.InstructorPermits[0].Permit.Vehicles[0].Categories, "./*[local-name()='categories']");

    //        mapper.AddFunctionMap(p => p.Instructor.InstructorPermits[0].Permit.Vehicles[0].CertificateDate, node =>
    //        {
    //            XmlNode certificateDateNode =
    //                    node.SelectSingleNode(
    //                        "./*[local-name()='certificateDate']");
    //            if (certificateDateNode != null &&
    //                !string.IsNullOrWhiteSpace(certificateDateNode.InnerText))
    //            {
    //                return DateTime.ParseExact(certificateDateNode.InnerText, "yyyy-MM-ddzzz",
    //                                            CultureInfo.InvariantCulture
    //                                                    .DateTimeFormat);
    //            }
    //            return null;
    //        });

    //        mapper.AddPropertyMap(p => p.Instructor.InstructorPermits[0].Permit.Vehicles[0].CertificateNumber, "./*[local-name()='certificateNumber']");

    //        mapper.AddFunctionMap(p => p.Instructor.InstructorPermits[0].Permit.Vehicles[0].Code78, node =>
    //        {
    //            XmlNode code78Node =
    //                    node.SelectSingleNode(
    //                        "./*[local-name()='code78']");

    //            if (code78Node != null &&
    //                !string.IsNullOrWhiteSpace(code78Node.InnerText))
    //            {
    //                bool result;
    //                if (bool.TryParse(code78Node.InnerText, out result))
    //                    return result;
    //            }
    //            return null;
    //        });

    //        mapper.AddPropertyMap(p => p.Instructor.InstructorPermits[0].Permit.Vehicles[0].EngineCapacity, "./*[local-name()='engineCapacity']");
    //        mapper.AddPropertyMap(p => p.Instructor.InstructorPermits[0].Permit.Vehicles[0].Gears, "./*[local-name()='gears']");

    //        mapper.AddFunctionMap(p => p.Instructor.InstructorPermits[0].Permit.Vehicles[0].HasABS, node =>
    //        {
    //            XmlNode hasABSNode =
    //                    node.SelectSingleNode(
    //                        "./*[local-name()='hasABS']");

    //            if (hasABSNode != null &&
    //                !string.IsNullOrWhiteSpace(hasABSNode.InnerText))
    //            {
    //                bool result;
    //                if (bool.TryParse(hasABSNode.InnerText, out result))
    //                    return result;
    //            }
    //            return null;
    //        });

    //        mapper.AddFunctionMap(p => p.Instructor.InstructorPermits[0].Permit.Vehicles[0].HasTachograph, node =>
    //        {
    //            XmlNode hasTachographNode =
    //                    node.SelectSingleNode(
    //                        "./*[local-name()='hasTachograph']");

    //            if (hasTachographNode != null &&
    //                !string.IsNullOrWhiteSpace(hasTachographNode.InnerText))
    //            {
    //                bool result;
    //                if (bool.TryParse(hasTachographNode.InnerText, out result))
    //                    return result;
    //            }
    //            return null;
    //        });

    //        mapper.AddPropertyMap(p => p.Instructor.InstructorPermits[0].Permit.Vehicles[0].IdentNumber, "./*[local-name()='identNumber']");
    //        mapper.AddPropertyMap(p => p.Instructor.InstructorPermits[0].Permit.Vehicles[0].Length, "./*[local-name()='length']");
    //        mapper.AddPropertyMap(p => p.Instructor.InstructorPermits[0].Permit.Vehicles[0].Make, "./*[local-name()='make']");
    //        mapper.AddPropertyMap(p => p.Instructor.InstructorPermits[0].Permit.Vehicles[0].MaximumDesignSpeed, "./*[local-name()='maximumDesignSpeed']");
    //        mapper.AddPropertyMap(p => p.Instructor.InstructorPermits[0].Permit.Vehicles[0].MaxPermittedDefinedMass, "./*[local-name()='maxPermittedDefinedMass']");

    //        mapper.AddFunctionMap(p => p.Instructor.InstructorPermits[0].Permit.Vehicles[0].MaxPower, node =>
    //        {
    //            XmlNode maxPowerNode =
    //                    node.SelectSingleNode(
    //                        "./*[local-name()='maxPower']");

    //            if (maxPowerNode != null &&
    //                !string.IsNullOrWhiteSpace(maxPowerNode.InnerText))
    //            {
    //                short result;
    //                if (short.TryParse(maxPowerNode.InnerText, out result))
    //                    return result;
    //            }
    //            return null;
    //        });

    //        mapper.AddPropertyMap(p => p.Instructor.InstructorPermits[0].Permit.Vehicles[0].PowerToWeightRatio, "./*[local-name()='powerToWeightRatio']");

    //        mapper.AddFunctionMap(p => p.Instructor.InstructorPermits[0].Permit.Vehicles[0].ProtocolDate, node =>
    //        {
    //            XmlNode protocolDateNode =
    //                    node.SelectSingleNode(
    //                        "./*[local-name()='protocolDate']");
    //            if (protocolDateNode != null &&
    //                !string.IsNullOrWhiteSpace(protocolDateNode.InnerText))
    //            {
    //                return DateTime.ParseExact(protocolDateNode.InnerText, "yyyy-MM-ddzzz",
    //                                            CultureInfo.InvariantCulture
    //                                                    .DateTimeFormat);
    //            }
    //            return null;
    //        });

    //        mapper.AddPropertyMap(p => p.Instructor.InstructorPermits[0].Permit.Vehicles[0].ProtocolNumber, "./*[local-name()='protocolNumber']");
    //        mapper.AddPropertyMap(p => p.Instructor.InstructorPermits[0].Permit.Vehicles[0].RegNumber, "./*[local-name()='regNumber']");
    //        mapper.AddPropertyMap(p => p.Instructor.InstructorPermits[0].Permit.Vehicles[0].SeatPlaces, "./*[local-name()='seatPlaces']");
    //        mapper.AddPropertyMap(p => p.Instructor.InstructorPermits[0].Permit.Vehicles[0].Width, "./*[local-name()='width']");

    //        mapper.AddFunctionMap(p => p.Instructor.LastDrivingLicenceCertificateCategories, node =>
    //        {
    //            var lastDrivingLicenceCertificateCategoriesNode = node.SelectSingleNode("/*[local-name()='permitsInstructorsReportResponse']/*[local-name()='instructor']/*[local-name()='lastDrivingLicenceCertificateCategories']");

    //            if (lastDrivingLicenceCertificateCategoriesNode != null)
    //            {
    //                return lastDrivingLicenceCertificateCategoriesNode.InnerText.Split(',').ToList();
    //            }
    //            return null;
    //        });

    //        mapper.AddFunctionMap(p => p.Instructor.LastDrivingLicenceCertificateIssueDate, node =>
    //        {
    //            XmlNode lastDrivingLicenceCertificateIssueDateNode =
    //                    node.SelectSingleNode(
    //                        "/*[local-name()='permitsInstructorsReportResponse']/*[local-name()='instructor']/*[local-name()='lastDrivingLicenceCertificateIssueDate']");
    //            if (lastDrivingLicenceCertificateIssueDateNode != null &&
    //                !string.IsNullOrWhiteSpace(lastDrivingLicenceCertificateIssueDateNode.InnerText))
    //            {
    //                return DateTime.ParseExact(lastDrivingLicenceCertificateIssueDateNode.InnerText, "yyyy-MM-ddzzz",
    //                                            CultureInfo.InvariantCulture
    //                                                    .DateTimeFormat);
    //            }
    //            return null;
    //        });

    //        mapper.AddPropertyMap(p => p.Instructor.LastDrivingLicenceCertificateNumber, "/*[local-name()='permitsInstructorsReportResponse']/*[local-name()='instructor']/*[local-name()='lastDrivingLicenceCertificateNumber']");

    //        mapper.AddFunctionMap(p => p.Instructor.LastQualificationCertificateIssueDate, node =>
    //        {
    //            XmlNode lastQualificationCertificateIssueDateNode =
    //                    node.SelectSingleNode(
    //                        "/*[local-name()='permitsInstructorsReportResponse']/*[local-name()='instructor']/*[local-name()='lastQualificationCertificateIssueDate']");
    //            if (lastQualificationCertificateIssueDateNode != null &&
    //                !string.IsNullOrWhiteSpace(lastQualificationCertificateIssueDateNode.InnerText))
    //            {
    //                return DateTime.ParseExact(lastQualificationCertificateIssueDateNode.InnerText, "yyyy-MM-ddzzz",
    //                                            CultureInfo.InvariantCulture
    //                                                    .DateTimeFormat);
    //            }
    //            return null;
    //        });

    //        mapper.AddPropertyMap(p => p.Instructor.LastQualificationCertificateIssuedBy, "/*[local-name()='permitsInstructorsReportResponse']/*[local-name()='instructor']/*[local-name()='lastQualificationCertificateIssuedBy']");
    //        mapper.AddPropertyMap(p => p.Instructor.LastQualificationCertificateNumber, "/*[local-name()='permitsInstructorsReportResponse']/*[local-name()='instructor']/*[local-name()='lastQualificationCertificateNumber']");
    //        mapper.AddPropertyMap(p => p.Instructor.SubjectFullName, "/*[local-name()='permitsInstructorsReportResponse']/*[local-name()='instructor']/*[local-name()='subjectFullName']");
    //        mapper.AddPropertyMap(p => p.Instructor.SubjectIdentNumber, "/*[local-name()='permitsInstructorsReportResponse']/*[local-name()='instructor']/*[local-name()='subjectIdentNumber']");


    //        return mapper;

    //    }

    //    public CommonSignedResponse<PermitsExamPeopleCountRequestType, PermitsExamPeopleCountResponse> GetReport5PermitsExamPeopleCount(PermitsExamPeopleCountRequestType argument, AccessMatrix accessMatrix, AdapterAdditionalParameters aditionalParameters)
    //    {
    //        Guid id = Guid.NewGuid();
    //        LogData(aditionalParameters, new { Request = argument.Serialize(), Guid = id });
    //        try
    //        {
    //            var serviceClient = new HttpClient();
    //            serviceClient.BaseAddress = new Uri(WebServiceUrl.Value);
    //            serviceClient.DefaultRequestHeaders.Accept.Clear();
    //            serviceClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/xml"));

    //            ServiceXMLShemas.permitsExamPeopleCountRequest param = new ServiceXMLShemas.permitsExamPeopleCountRequest();
    //            param.context = aditionalParameters.CallContext.ToString();
    //            param.dateFromPrivate = argument.DateFrom;
    //            param.dateFromSpecified = argument.DateFromSpecified;
    //            param.dateToPrivate = argument.DateTo;
    //            param.dateToSpecified = argument.DateToSpecified;
    //            param.identNumber = argument.IdentNumber;
    //            string request = param.XmlSerialize();

    //            string responseString = GetResponse(serviceClient, request, GetReport5PermitsExamPeopleCountMethodName.Value, id, aditionalParameters).Result;
    //            XElement resultXmlElement = XDocument.Parse(responseString).Root;

    //            XPathMapper<PermitsExamPeopleCountResponse> responseMapper = CreatePermitsExamPeopleCountResponseMapper(accessMatrix);
    //            PermitsExamPeopleCountResponse result = new PermitsExamPeopleCountResponse();
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

    //    private static XPathMapper<PermitsExamPeopleCountResponse> CreatePermitsExamPeopleCountResponseMapper(AccessMatrix accessMatrix)
    //    {
    //        XPathMapper<PermitsExamPeopleCountResponse> mapper =
    //            new XPathMapper<PermitsExamPeopleCountResponse>(accessMatrix);

    //        mapper.AddCollectionMap(p => p.PermitsExamPeopleCounts, "/*[local-name()='permitsExamPeopleCountReportResponse']/*[local-name()='permitsExamPeopleCounts']/*[local-name()='permitExamPeopleCount']");
    //        mapper.AddPropertyMap(p => p.PermitsExamPeopleCounts[0].Address, "./*[local-name()='address']");

    //        mapper.AddFunctionMap(p => p.PermitsExamPeopleCounts[0].CeaseDate, node =>
    //        {
    //            XmlNode ceaseDateNode =
    //                    node.SelectSingleNode(
    //                        "./*[local-name()='ceaseDate']");
    //            if (ceaseDateNode != null &&
    //                !string.IsNullOrWhiteSpace(ceaseDateNode.InnerText))
    //            {
    //                return DateTime.ParseExact(ceaseDateNode.InnerText, "yyyy-MM-ddzzz",
    //                                            CultureInfo.InvariantCulture
    //                                                    .DateTimeFormat);
    //            }
    //            return null;
    //        });

    //        mapper.AddPropertyMap(p => p.PermitsExamPeopleCounts[0].CompanyFullName, "./*[local-name()='companyFullName']");
    //        mapper.AddPropertyMap(p => p.PermitsExamPeopleCounts[0].CompanyIdentNumber, "./*[local-name()='companyIdentNumber']");
    //        mapper.AddPropertyMap(p => p.PermitsExamPeopleCounts[0].ExamPeopleCount, "./*[local-name()='examPeopleCount']");

    //        mapper.AddFunctionMap(p => p.PermitsExamPeopleCounts[0].ExamRoomsCount, node =>
    //        {
    //            XmlNode examRoomsCountNode =
    //                    node.SelectSingleNode(
    //                        "./*[local-name()='examRoomsCount']");

    //            if (examRoomsCountNode != null &&
    //                !string.IsNullOrWhiteSpace(examRoomsCountNode.InnerText))
    //            {
    //                short result;
    //                if (short.TryParse(examRoomsCountNode.InnerText, out result))
    //                    return result;
    //            }
    //            return null;
    //        });

    //        mapper.AddFunctionMap(p => p.PermitsExamPeopleCounts[0].ExamSeatsCount, node =>
    //        {
    //            XmlNode examSeatsCountNode =
    //                    node.SelectSingleNode(
    //                        "./*[local-name()='examSeatsCount']");

    //            if (examSeatsCountNode != null &&
    //                !string.IsNullOrWhiteSpace(examSeatsCountNode.InnerText))
    //            {
    //                short result;
    //                if (short.TryParse(examSeatsCountNode.InnerText, out result))
    //                    return result;
    //            }
    //            return null;
    //        });

    //        mapper.AddFunctionMap(p => p.PermitsExamPeopleCounts[0].IssueDate, node =>
    //        {
    //            XmlNode issueDateNode =
    //                    node.SelectSingleNode(
    //                        "./*[local-name()='issueDate']");
    //            if (issueDateNode != null &&
    //                !string.IsNullOrWhiteSpace(issueDateNode.InnerText))
    //            {
    //                return DateTime.ParseExact(issueDateNode.InnerText, "yyyy-MM-ddzzz",
    //                                            CultureInfo.InvariantCulture
    //                                                    .DateTimeFormat);
    //            }
    //            return null;
    //        });

    //        mapper.AddPropertyMap(p => p.PermitsExamPeopleCounts[0].ManagerFullName, "./*[local-name()='managerFullName']");
    //        mapper.AddPropertyMap(p => p.PermitsExamPeopleCounts[0].ManagerIdentNumber, "./*[local-name()='managerIdentNumber']");
    //        mapper.AddPropertyMap(p => p.PermitsExamPeopleCounts[0].Number, "./*[local-name()='number']");
    //        mapper.AddPropertyMap(p => p.PermitsExamPeopleCounts[0].OrgUnitShortName, "./*[local-name()='orgUnitShortName']");
    //        mapper.AddPropertyMap(p => p.PermitsExamPeopleCounts[0].PermitType, "./*[local-name()='permitType']");

    //        mapper.AddFunctionMap(p => p.PermitsExamPeopleCounts[0].SeatPlacesCount, node =>
    //        {
    //            XmlNode seatplacesCountNode =
    //                    node.SelectSingleNode(
    //                        "./*[local-name()='seatplacesCount']");

    //            if (seatplacesCountNode != null &&
    //                !string.IsNullOrWhiteSpace(seatplacesCountNode.InnerText))
    //            {
    //                short result;
    //                if (short.TryParse(seatplacesCountNode.InnerText, out result))
    //                    return result;
    //            }
    //            return null;
    //        });

    //        mapper.AddPropertyMap(p => p.PermitsExamPeopleCounts[0].Status, "./*[local-name()='status']");
    //        mapper.AddPropertyMap(p => p.PermitsExamPeopleCounts[0].TechAssistantFullName, "./*[local-name()='techAssistantFullName']");
    //        mapper.AddPropertyMap(p => p.PermitsExamPeopleCounts[0].TechAssistantIdentNumber, "./*[local-name()='techAssistantIdentNumber']");

    //        mapper.AddFunctionMap(p => p.PermitsExamPeopleCounts[0].ValidTo, node =>
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

    //    public CommonSignedResponse<SubjectOwnedCategoriesRequestType, SubjectOwnedCategoriesResponse> GetReport6SubjectOwnedCategories(SubjectOwnedCategoriesRequestType argument, AccessMatrix accessMatrix, AdapterAdditionalParameters aditionalParameters)
    //    {
    //        Guid id = Guid.NewGuid();
    //        LogData(aditionalParameters, new { Request = argument.Serialize(), Guid = id });
    //        try
    //        {
    //            var serviceClient = new HttpClient();
    //            serviceClient.BaseAddress = new Uri(WebServiceUrl.Value);
    //            serviceClient.DefaultRequestHeaders.Accept.Clear();
    //            serviceClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/xml"));

    //            ServiceXMLShemas.subjectOwnedCategoriesRequest param = new ServiceXMLShemas.subjectOwnedCategoriesRequest();
    //            param.context = aditionalParameters.CallContext.ToString();
    //            param.subjectIdentNumber = argument.SubjectIdentNumber;
    //            string request = param.XmlSerialize();

    //            string responseString = GetResponse(serviceClient, request, GetReport6SubjectOwnedCategoriesMethodName.Value, id, aditionalParameters).Result;
    //            XElement resultXmlElement = XDocument.Parse(responseString).Root;

    //            XPathMapper<SubjectOwnedCategoriesResponse> responseMapper = CreateSubjectOwnedCategoriesResponseMapper(accessMatrix);
    //            SubjectOwnedCategoriesResponse result = new SubjectOwnedCategoriesResponse();
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

    //    private static XPathMapper<SubjectOwnedCategoriesResponse> CreateSubjectOwnedCategoriesResponseMapper(AccessMatrix accessMatrix)
    //    {
    //        XPathMapper<SubjectOwnedCategoriesResponse> mapper =
    //            new XPathMapper<SubjectOwnedCategoriesResponse>(accessMatrix);

    //        mapper.AddCollectionMap(p => p.OwnedCategories, "/*[local-name()='subjectOwnedCategoriesResponse']/*[local-name()='ownedCategories']/*[local-name()='ownedCategory']");
    //        mapper.AddPropertyMap(p => p.OwnedCategories[0].CategoryName, "./*[local-name()='categoryName']");

    //        mapper.AddFunctionMap(p => p.OwnedCategories[0].DateOwned, node =>
    //        {
    //            XmlNode dateOwnedNode =
    //                    node.SelectSingleNode(
    //                        "./*[local-name()='dateOwned']");
    //            if (dateOwnedNode != null &&
    //                !string.IsNullOrWhiteSpace(dateOwnedNode.InnerText))
    //            {
    //                return DateTime.ParseExact(dateOwnedNode.InnerText, "yyyy-MM-ddzzz",
    //                                            CultureInfo.InvariantCulture
    //                                                    .DateTimeFormat);
    //            }
    //            return null;
    //        });

    //        return mapper;
    //    }
    //}
}
