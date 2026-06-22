namespace CustomerCommLib
{
    public class CustomerComm
    {
        private readonly IMailSender _mailSender;

        public CustomerComm(IMailSender mailSender)
        {
            _mailSender = mailSender;
        }

        public bool SendMailToCustomer()
        {
            // Actual logic: send email to customer and return confirmation
            bool result = _mailSender.SendMail("cust123@abc.com", "Some Message");
            return result;
        }
    }
}
