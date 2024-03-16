namespace SendEmailApp.Service.EmailService
{
    public interface IEmailService
    {
        public bool SendEmail(String EmailRecieveUser, String UserNameCustomer, String HostContactName, String HostPhoneNumber);
    }
}
