using System.IO;
using System.Net;
using System.Net.Mail;
using EmailService.ReportingService;
using Microsoft.Extensions.Configuration;
using TechnoLogica.Authentication.Common;

namespace EmailService
{
    public class EmailService : IEmailService
    {
        private readonly IReportingService _reportingService;
        private static SmtpClient client;
        private readonly SMTPSettings SMTPSettings;

        public EmailService(IConfiguration configuration,IReportingService reportingService)
        {
            _reportingService = reportingService;
            this.SMTPSettings = configuration.GetSettings<SMTPSettings>();
            if (client == null)
            {
                client = new SmtpClient(SMTPSettings.Server);
                client.Port = SMTPSettings.Port;
                if (!string.IsNullOrEmpty(SMTPSettings.Username) && !string.IsNullOrEmpty(SMTPSettings.Password))
                {
                    client.Credentials = new NetworkCredential(SMTPSettings.Username, SMTPSettings.Password);
                }
                client.EnableSsl = SMTPSettings.EnableSSL;
            }
        }

        public void SendAdminAppUserRegistrationNotificationMessage(string[] emails, string userName, string administrationName)
        {
            MailMessage mail = new MailMessage();
            Attachment att = new Attachment("logo.png");
            att.ContentDisposition.Inline = true;
            mail.IsBodyHtml = true;
            mail.From = new MailAddress(this.SMTPSettings.From);

            if (SMTPSettings.AdminMailOverride.Length != 0)
            {
                foreach(var email in SMTPSettings.AdminMailOverride)
                {
                    mail.To.Add(email);
                }
            }
            else
            {
                foreach (var email in emails)
                {
                    mail.To.Add(email);
                }
            }

            mail.Subject = "Регистриран нов потребител";//TODO:fix subject and body 

            string body =
                "<html>\r\n" +
                "<head>\r\n<meta http-equiv=\"Content-Type\" content=\"text/html; charset=utf-8\"></head>\r\n" +
                "<p><!--579-->"+
                $"<img alt=\"HeaderLogo\" src=\"cid:{att.ContentId}\">"
                +
                "<br><head></head>" +
                "<body>" +
                "<br>" +
                "<html>\r\n" +
                "<head>\r\n<style>\r\np  {font-family:Calibri;font-size:14px; margin:0;}\r\nh1 {text-indent: 5px; direction: ltl;font-family:Calibri;font-size:16px;color:white;background-color:rgb(3,117,190);}\r\nh2 {text-indent: 5px; direction: ltl;font-family:Calibri;font-size:14px;color:rgb(97,145,120);}\r\nh3 {text-indent: 5px; direction: ltl;font-family:Calibri;font-size:11px;color:white;background-color:rgb(18,160,251);}\r\n</style>\r\n</head>\r\n" +
                "<h1>RegiX</h1>" +
                "<p><p>Здравейте,<br>\r\n<br>Регистриран е нов потребител " +
                "<b>" + string.Format("{0}", userName) +
                "</b>" +
                " в администрация " +
                "<b>" + string.Format("{0}", administrationName) +
                "</b>"
                + " !<br>\r\n\r\n<br><br>\r\n<i>Това е автоматично съобщение, моля, не отговаряйте!</i></p>\r\n" +
                "<h3>© RegiX</h3>" +
                "</body>" +
                "</p>" +
                "</html>";
            mail.Body = body;
            client.Send(mail);
        }

        public void SendClientAppUserRegistrationNotificationMessage(string[] emails, string userName, string administrationName)
        {
            MailMessage mail = new MailMessage();
            Attachment att = new Attachment("logo.png");
            att.ContentDisposition.Inline = true;
            mail.IsBodyHtml = true;
            mail.Attachments.Add(att);
            mail.From = new MailAddress(this.SMTPSettings.From);

            if (SMTPSettings.AdminMailOverride.Length != 0)
            {
                foreach (var email in SMTPSettings.AdminMailOverride)
                {
                    mail.To.Add(email);
                }
            }
            else
            {
                foreach (var email in emails)
                {
                    mail.To.Add(email);
                }
            }

            mail.Subject = "Регистриран нов потребител";//TODO:fix subject and body 

            string body =
                "<html>\r\n" +
                "<head>\r\n<meta http-equiv=\"Content-Type\" content=\"text/html; charset=utf-8\"></head>\r\n" +
                "<p><!--579-->" +
                string.Format("<img alt=\"HeaderLogo\" src=\"cid:{0}\">",att.ContentId)
                 +
                "<br><head></head>" +
                "<body>" +
                "<br>" +
                "<html>\r\n" +
                "<head>\r\n<style>\r\np  {font-family:Calibri;font-size:14px; margin:0;}\r\nh1 {text-indent: 5px; direction: ltl;font-family:Calibri;font-size:16px;color:white;background-color:rgb(3,117,190);}\r\nh2 {text-indent: 5px; direction: ltl;font-family:Calibri;font-size:14px;color:rgb(97,145,120);}\r\nh3 {text-indent: 5px; direction: ltl;font-family:Calibri;font-size:11px;color:white;background-color:rgb(18,160,251);}\r\n</style>\r\n</head>\r\n" +
                "<h1>RegiX</h1>" +
                "<p><p>Здравейте,<br>\r\n<br>Регистриран е нов потребител " +
                "<b>" + string.Format("{0}", userName) +
                "</b>" +
                " в администрация " +
                "<b>" + string.Format("{0}", administrationName) +
                "</b>"
                + " !<br>\r\n\r\n<br><br>\r\n<i>Това е автоматично съобщение, моля, не отговаряйте!</i></p>\r\n" +
                "<h3>© RegiX</h3>" +
                "</body>" +
                "</p>" +
                "</html>";
            mail.Body = body;
            client.Send(mail);
        }

        //send message to Representitive with generated PDF form 
        public void SendConsumerUserMessageWithPDFReport(string[] emails, string ConsumerProfileName, string ConsumerProfileUserEmail)
        {
            MailMessage mail = new MailMessage();
            Attachment att = new Attachment("logo.png");
            Stream stream = new MemoryStream(this._reportingService.RunReport(ConsumerProfileUserEmail).GetAwaiter().GetResult());
            Attachment file = new Attachment(stream,"FormRequest.pdf", "application/pdf");
            att.ContentDisposition.Inline = true;
            mail.IsBodyHtml = true;
            mail.Attachments.Add(att);
            mail.Attachments.Add(file);
            mail.From = new MailAddress(this.SMTPSettings.From);

            foreach (var email in emails)
            {
                mail.To.Add(email);
            }

            mail.Subject = "Регистрация на представител към консуматор в RegiX.Info ";

            string body =
                "<html>\r\n" +
                "<head>\r\n<meta http-equiv=\"Content-Type\" content=\"text/html; charset=utf-8\"></head>\r\n" +
                "<p><!--579-->" +
                string.Format("<img alt=\"HeaderLogo\" src=\"cid:{0}\">", att.ContentId)
                 +
                "<br><head></head>" +
                "<body>" +
                "<br>" +
                "<html>\r\n" +
                "<head>\r\n<style>\r\np  {font-family:Calibri;font-size:14px; margin:0;}\r\nh1 {text-indent: 5px; direction: ltl;font-family:Calibri;font-size:16px;color:white;background-color:rgb(3,117,190);}\r\nh2 {text-indent: 5px; direction: ltl;font-family:Calibri;font-size:14px;color:rgb(97,145,120);}\r\nh3 {text-indent: 5px; direction: ltl;font-family:Calibri;font-size:11px;color:white;background-color:rgb(18,160,251);}\r\n</style>\r\n</head>\r\n" +
                "<h1>RegiX</h1>" +
                "<p><p>Здравейте,<br>\r\n<br>Вие регистрирахте представител " + ConsumerProfileUserEmail + " в приложението на RegiX.Info към консуматор " + ConsumerProfileName + "."
                + "Вашият профил очаква активиране от администратор!<br>\r\n\r\n<br><br>\r\n<i>Това е автоматично съобщение, моля, не отговаряйте!</i></p>\r\n" +
                "<h3>© RegiX</h3>" +
                "</body>" +
                "</p>" +
                "</html>";
            mail.Body = body;
            client.Send(mail);
        }

        public void SendConsumerProfileMessageWithPDFReport(string[] emails, string ConsumerProfileName, string ConsumerProfileUserEmail)
        {
            MailMessage mail = new MailMessage();
            Attachment att = new Attachment("logo.png");
            Stream stream = new MemoryStream(this._reportingService.RunReport(ConsumerProfileUserEmail).GetAwaiter().GetResult());
            Attachment file = new Attachment(stream, "FormRequest.pdf", "application/pdf");
            att.ContentDisposition.Inline = true;
            mail.IsBodyHtml = true;
            mail.Attachments.Add(att);
            mail.Attachments.Add(file);
            mail.From = new MailAddress(this.SMTPSettings.From);

            foreach (var email in emails)
            {
                mail.To.Add(email);
            }

            mail.Subject = "Регистрация на консуматор и представител в RegiX.Info ";

            string body =
                "<html>\r\n" +
                "<head>\r\n<meta http-equiv=\"Content-Type\" content=\"text/html; charset=utf-8\"></head>\r\n" +
                "<p><!--579-->" +
                string.Format("<img alt=\"HeaderLogo\" src=\"cid:{0}\">", att.ContentId)
                 +
                "<br><head></head>" +
                "<body>" +
                "<br>" +
                "<html>\r\n" +
                "<head>\r\n<style>\r\np  {font-family:Calibri;font-size:14px; margin:0;}\r\nh1 {text-indent: 5px; direction: ltl;font-family:Calibri;font-size:16px;color:white;background-color:rgb(3,117,190);}\r\nh2 {text-indent: 5px; direction: ltl;font-family:Calibri;font-size:14px;color:rgb(97,145,120);}\r\nh3 {text-indent: 5px; direction: ltl;font-family:Calibri;font-size:11px;color:white;background-color:rgb(18,160,251);}\r\n</style>\r\n</head>\r\n" +
                "<h1>RegiX</h1>" +
                "<p><p>Здравейте,<br>\r\n<br>Вие регистрирахте консуматор " + ConsumerProfileName + " в приложението на RegiX.Info с представител " + ConsumerProfileUserEmail + ". " +  "<br>"
                + "Вашият профил очаква активиране от администратор !<br>\r\n\r\n<br><br>\r\n<i>Това е автоматично съобщение, моля, не отговаряйте!</i></p>\r\n" +
                "<h3>© RegiX</h3>" +
                "</body>" +
                "</p>" +
                "</html>";
            mail.Body = body;
            client.Send(mail);
        }

        //when new Consumer is created 
        public void NewConsumerProfileMessage(string[] emails, string ConsumerProfileName, string ConsumerProfileUserEmail)
        {
            MailMessage mail = new MailMessage();
            Attachment att = new Attachment("logo.png");
            att.ContentDisposition.Inline = true;
            mail.IsBodyHtml = true;
            mail.From = new MailAddress(this.SMTPSettings.From);


            if (SMTPSettings.AdminMailOverride.Length != 0)
            {
                foreach (var email in SMTPSettings.AdminMailOverride)
                {
                    mail.To.Add(email);
                }
            }
            else
            {
                foreach (var email in emails)
                {
                    mail.To.Add(email);
                }
            }

            mail.Subject = "Регистриран е нов консуматор ";//TODO:fix subject and body 

            string body =
                "<html>\r\n" +
                "<head>\r\n<meta http-equiv=\"Content-Type\" content=\"text/html; charset=utf-8\"></head>\r\n" +
                "<p><!--579-->" +
                $"<img alt=\"HeaderLogo\" src=\"cid:{att.ContentId}\">"
                +
                "<br><head></head>" +
                "<body>" +
                "<br>" +
                "<html>\r\n" +
                "<head>\r\n<style>\r\np  {font-family:Calibri;font-size:14px; margin:0;}\r\nh1 {text-indent: 5px; direction: ltl;font-family:Calibri;font-size:16px;color:white;background-color:rgb(3,117,190);}\r\nh2 {text-indent: 5px; direction: ltl;font-family:Calibri;font-size:14px;color:rgb(97,145,120);}\r\nh3 {text-indent: 5px; direction: ltl;font-family:Calibri;font-size:11px;color:white;background-color:rgb(18,160,251);}\r\n</style>\r\n</head>\r\n" +
                "<h1>RegiX</h1>" +
                "<p><p>Здравейте,<br>\r\n<br>Регистриран е нов консуматор " +
                "<b>" + string.Format("{0}", ConsumerProfileName) +
                "</b>" +
                " с представител " +
                "<b>" + string.Format("{0}", ConsumerProfileUserEmail) +
                "</b>"
                + " !<br>\r\n\r\n<br><br>\r\n<i>Това е автоматично съобщение, моля, не отговаряйте!</i></p>\r\n" +
                "<h3>© RegiX</h3>" +
                "</body>" +
                "</p>" +
                "</html>";
            mail.Body = body;
            client.Send(mail);
        }

        //when new Representitive is added/created  to Consumer 
        public void NewConsumerProfileUserMessage(string[] emails, string ConsumerProfileName, string ConsumerProfileUserEmail)
        {
            MailMessage mail = new MailMessage();
            Attachment att = new Attachment("logo.png");
            att.ContentDisposition.Inline = true;
            mail.IsBodyHtml = true;
            mail.Attachments.Add(att);
            mail.From = new MailAddress(this.SMTPSettings.From);


            if (SMTPSettings.AdminMailOverride.Length != 0)
            {
                foreach (var email in SMTPSettings.AdminMailOverride)
                {
                    mail.To.Add(email);
                }
            }
            else
            {
                foreach (var email in emails)
                {
                    mail.To.Add(email);
                }
            }

            mail.Subject = "Регистриран нов представител за консуматор " + string.Format("{0}", ConsumerProfileName);

            string body =
                "<html>\r\n" +
                "<head>\r\n<meta http-equiv=\"Content-Type\" content=\"text/html; charset=utf-8\"></head>\r\n" +
                "<p><!--579-->" +
                string.Format("<img alt=\"HeaderLogo\" src=\"cid:{0}\">", att.ContentId)
                 +
                "<br><head></head>" +
                "<body>" +
                "<br>" +
                "<html>\r\n" +
                "<head>\r\n<style>\r\np  {font-family:Calibri;font-size:14px; margin:0;}\r\nh1 {text-indent: 5px; direction: ltl;font-family:Calibri;font-size:16px;color:white;background-color:rgb(3,117,190);}\r\nh2 {text-indent: 5px; direction: ltl;font-family:Calibri;font-size:14px;color:rgb(97,145,120);}\r\nh3 {text-indent: 5px; direction: ltl;font-family:Calibri;font-size:11px;color:white;background-color:rgb(18,160,251);}\r\n</style>\r\n</head>\r\n" +
                "<h1>RegiX</h1>" +
                "<p><p>Здравейте,<br>\r\n<br>Регистриран е нов представител " +
                "<b>" + string.Format("{0}", ConsumerProfileUserEmail) +
                "</b>" +
                " за консуматор " +
                "<b>" + string.Format("{0}", ConsumerProfileName) +
                "</b>"
                + " !<br>\r\n\r\n<br><br>\r\n<i>Това е автоматично съобщение, моля, не отговаряйте!</i></p>\r\n" +
                "<h3>© RegiX</h3>" +
                "</body>" +
                "</p>" +
                "</html>";
            mail.Body = body;
            client.Send(mail);
        }
    }
}
