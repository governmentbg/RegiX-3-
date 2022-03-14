using AutoMapper;
using System;
using System.Security.Cryptography.X509Certificates;
using System.Security.Cryptography.Xml;
using System.Xml;
using TechnoLogica.RegiX.Client.API.DataContracts.DTO;
using TechnoLogica.RegiX.Client.API.DataContracts.DTO.AuditReportExecution;
using TechnoLogica.RegiX.Client.Infrastructure.Models;
using TechnoLogica.RegiX.Common.TransportObjects;
using TechnoLogica.RegiX.Common.Utils;
using TechnoLogica.RegiX.Core.Interfaces.TransportObjects;

namespace TechnoLogica.RegiX.Client.IoC.Configuration.Profiles
{
    public static class ResultWrapperExtensions
    {
        public static string GetForValidation(this ResultWrapper wrapped)
        {
            var container = wrapped.Result.Data.XmlSerialize().ToXmlElement();
            var signature = wrapped.Result.Signature;
            container.AppendChild(signature);
            return container.OuterXml;
        }

        public static byte[] TryGetPDF(this ResultWrapper wrapped)
        {
            var response = wrapped?.Result?.Data?.Response?.Response;
            if (response != null && response.LocalName == nameof(BinaryArgument))
            {
                return response.Deserialize<BinaryArgument>().Binary;
            }
            else
            {
                return new byte[] { };
            }
        }

        public static bool? GetSignatureVerified(this ResultWrapper wrapped)
        {
            XmlDocument document = new XmlDocument();
            document.LoadXml(wrapped.XmlSerialize());
            var sigInfo = new SignedXml(document);
            var elements = document.GetElementsByTagName("Signature", "http://www.w3.org/2000/09/xmldsig#");
            if (elements.Count > 0)
            {
                sigInfo.LoadXml((XmlElement)elements[0]);
                var verified = sigInfo.CheckSignature();
                return verified;
            }
            else
            {
                return null;
            }
        }

        public static byte[] GetSignatureCertirifcate(this ResultWrapper wrapped)
        {
            XmlDocument document = new XmlDocument();
            document.LoadXml(wrapped.XmlSerialize());
            var sigInfo = new SignedXml(document);
            var elements = document.GetElementsByTagName("Signature", "http://www.w3.org/2000/09/xmldsig#");
            if (elements.Count > 0)
            {
                sigInfo.LoadXml((XmlElement)elements[0]);
                var res = sigInfo.CheckSignature();
                foreach (var obj in sigInfo.KeyInfo)
                {
                    if (obj.GetType() == typeof(KeyInfoX509Data))
                    {
                        foreach (var cer in (obj as KeyInfoX509Data).Certificates)
                        {
                            return (cer as X509Certificate2).Export(X509ContentType.Cert);
                        }
                    }
                }
            }                
            return new byte[] { };
        }
    }

    public class AuditReportExecutionProfile : Profile
    {
        public AuditReportExecutionProfile()
        {
            // Configuration for AuditReportExecution
            CreateMap<AuditReportExecutionInDto, AuditReportExecutions>();
            CreateMap<AuditReportExecutions, AuditReportExecutionOutDto>()
                .ForMember(r => r.Report, report => report.MapFrom(a => new DisplayValue
                {
                    Id = a.Report.Id,
                    DisplayName = a.Report.Name
                }
                ))
                .ForMember(r => r.Authority, authority => authority.MapFrom(a => new DisplayValue
                {
                    Id = a.Authority.Id,
                    DisplayName = a.Authority.Name
                }
                ))
                .ForMember(r => r.User, user => user.MapFrom(a => new DisplayValue
                {
                    Id = a.User.Id,
                    DisplayName = a.User.UserName
                }
                ));
            CreateMap<AuditReportExecutions, AuditReportExecutionWithResultOutDto>()
              .ForMember(r => r.Report, report => report.MapFrom(a => new DisplayValue
              {
                  Id = a.Report.Id,
                  DisplayName = a.Report.Name
              }
              ))
              .ForMember(r => r.Authority, authority => authority.MapFrom(a => new DisplayValue
              {
                  Id = a.Authority.Id,
                  DisplayName = a.Authority.Name
              }
              ))
              .ForMember(r => r.RawRequestXml, a => a.MapFrom(e => e.RequestXml))
              .ForMember(r => r.RawResponseXml, a => a.MapFrom(e => e.ResponseXml))
              .ForMember(r => r.RequestXml, a => a.MapFrom(e => e.RequestXml != null ? e.RequestXml.XmlDeserialize<RequestWrapper>().Request.Argument.OuterXml : null))
              .ForMember(
                r => r.ResponseXml,
                a => a.MapFrom(
                    e =>
                        e.ResponseXml != null ?
                            e.ResponseXml.XmlDeserialize<ResultWrapper>().Result.Data.Response.Response.OuterXml :
                            null
                    )
                )
               .ForMember(
                r => r.ResponsePdf,
                a => a.MapFrom(
                    e =>
                        e.ResponseXml != null ?
                            e.ResponseXml.XmlDeserialize<ResultWrapper>().TryGetPDF() :
                            null
                    )
                )
              .ForMember(
                    r => r.SignatureVerified,
                    a => a.MapFrom(e => e.ResponseXml != null ? e.ResponseXml.XmlDeserialize<ResultWrapper>().GetSignatureVerified() : null)
               )
              .ForMember(
                    r => r.SignatureCertirifcate,
                    a => a.MapFrom(e => e.ResponseXml != null ? e.ResponseXml.XmlDeserialize<ResultWrapper>().GetSignatureCertirifcate() : new byte[] { })
               )
              .ForMember(r => r.AdapterOperationId, a => a.MapFrom(e => e.Report.AdapterOperationId))
              .ForMember(r => r.User, user => user.MapFrom(a => new DisplayValue
              {
                  Id = a.User.Id,
                  DisplayName = a.User.UserName
              }
              ));
        }
    }

}