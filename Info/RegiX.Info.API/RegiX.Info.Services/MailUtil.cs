using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Text;

namespace RegiX.Info.Services
{
    public static class MailUtil
    {
        internal static void PrepareBody(MailMessage newConsumerProfileUserMessage, string body, params string[] args)
        {
            Attachment att = new Attachment("logo.png");
            att.ContentDisposition.Inline = true;
            newConsumerProfileUserMessage.IsBodyHtml = true;
            newConsumerProfileUserMessage.Attachments.Add(att);
            List<object> arguments = new List<object>();
            arguments.Add(att.ContentId);
            arguments.AddRange(args);
            newConsumerProfileUserMessage.Body = string.Format(body, arguments.ToArray());
        }
    }
}
