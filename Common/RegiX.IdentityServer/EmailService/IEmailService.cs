namespace EmailService
{
    public interface IEmailService
    {
        void SendAdminAppUserRegistrationNotificationMessage(string[] emails, string userName, string administrationName);
        void SendClientAppUserRegistrationNotificationMessage(string[] emails, string userName, string administrationName);
        void SendConsumerUserMessageWithPDFReport(string[] emails, string ConsumerProfileName,
            string ConsumerProfileUserEmail);
        void SendConsumerProfileMessageWithPDFReport(string[] emails, string ConsumerProfileName,
            string ConsumerProfileUserEmail);
        void NewConsumerProfileMessage(string[] emails, string ConsumerProfileName, string ConsumerProfileUserEmail);
        void NewConsumerProfileUserMessage(string[] emails, string ConsumerProfileName, string ConsumerProfileUserEmail);
    }
}