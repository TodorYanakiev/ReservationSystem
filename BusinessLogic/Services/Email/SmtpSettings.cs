namespace BusinessLogic.Services.Email
{
    public class SmtpSettings
    {
        public string Host { get; set; } = "smtp.gmail.com";
        public int Port { get; set; } = 587;
        public string Username { get; set; } = "todoryanakiev395@gmail.com";
        public string Password { get; set; } = Environment.GetEnvironmentVariable("SMTP_PASSWORD");
        public bool EnableSsl { get; set; } = true;
        public string From { get; set; } = "todoryanakiev395@gmail.com";
    }
}
