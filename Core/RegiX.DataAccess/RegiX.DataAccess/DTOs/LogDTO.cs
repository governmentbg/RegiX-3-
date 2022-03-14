using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace TechnoLogica.RegiX.DataAccess.DTOs
{
    public class LogDTO
    {
        /// <summary>
        /// CallId
        /// </summary>
        public decimal? ServiceCallId { get; set; }
        /// <summary>
        /// Име
        /// </summary>
        public string ApplicationName { get; set; }
        /// <summary>
        /// IP адрес на приложението
        /// </summary>
        public string ApplicationIPAddress { get; set; }

        /// <summary>
        /// Идентификатор на (сертификат)
        /// </summary>
        public decimal? ConsumerCertificateId { get; set; }
        /// <summary>
        /// От
        /// </summary>
        public System.DateTime StartDate { get; set; }
        /// <summary>
        /// До
        /// </summary>
        public Nullable<System.DateTime> EndDate { get; set; }
        /// <summary>
        /// @Идентификатор на ползвател
        /// </summary>
        public decimal ConsumerId { get; set; }
        /// <summary>
        /// Ползвател
        /// </summary>
        public string ConsumerName { get; set; }
        /// <summary>
        /// OID на ползвател
        /// </summary>
        public string ConsumerOID { get; set; }

        /// <summary>
        /// @Идентификатор на интерфейс
        /// </summary>
        public decimal ServiceId { get; set; }

        /// <summary>
        /// Интерфейс
        /// </summary>
        public string ServiceName { get; set; }
        
        /// <summary>
        /// Готов резултат
        /// </summary>
        public bool ResultReady { get; set; }

        /// <summary>
        /// Идентификатор на операция
        /// </summary>
        public decimal ServiceOperationId { get; set; }
        /// <summary>
        /// Име на операция
        /// </summary>
        public string ServiceOperationCode { get; set; }

        /// <summary>
        /// Върнат резултат
        /// </summary>
        public bool ResultReturned { get; set; }

        /// <summary>
        /// Електронна идентификация
        /// </summary>
        public string EidToken { get; set; }
        /// <summary>
        /// Съдържание на електронна идентификация
        /// </summary>
        public string EidContent { get; set; }
        /// <summary>
        /// Ip адрес
        /// </summary>
        public string IpAddress { get; set; }

        /// <summary>
        /// Грешка
        /// </summary>
        public Nullable<bool> HasErorr { get; set; }
        /// <summary>
        /// Съдържание на грешката
        /// </summary>
        public string ErrorContent { get; set; }
        /// <summary>
        /// Oid идентификация
        /// </summary>
        public string OidToken { get; set; }

       
        
        /// <summary>
        ///  Име на администрация
        /// </summary>
        public string AdministrationName { get; set; }
        /// <summary>
        /// Идентификационен код на администрация (oID от eAuth)
        /// </summary>
        public string AdministrationOId { get; set; }
        /// <summary>
        /// Идентификатор на служител
        /// </summary>
        public string EmployeeIdentifier { get; set; }
        /// <summary>
        /// Име на служител
        /// </summary>
        public string EmployeeNames { get; set; }
        /// <summary>
        /// Длъжност или позиция на служител
        /// </summary>
        public string EmployeePosition { get; set; }
        /// <summary>
        /// Допълнителен идентификатор на служител
        /// </summary>
        public string EmployeeAditionalIdentifier { get; set; }
        /// <summary>
        /// Идентификатор на отговорник за справката
        /// </summary>
        public string ResponsiblePersonIdentifier { get; set; }
        /// <summary>
        /// УРИ
        /// </summary>
        public string ServiceURI { get; set; }
        /// <summary>
        /// Бележки 
        /// </summary>
        public string Remark { get; set; }
        /// <summary>
        /// Тип на услугата
        /// </summary>
        public string ServiceType { get; set; }
        /// <summary>
        /// Правно основание
        /// </summary>
        public string LawReason { get; set; }

    }
}