using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Mail;
using System.Configuration;
using System.Net.Sockets;
using System.Net.Http;

namespace Common
{
    public class MailHelper
    {
        public void SendMail(string vToEmailAddress, string subject,string content)
        {
            var vFromEmailAddress = ConfigurationManager.AppSettings["FromEmailAddress"].ToString();
            var vFromEmailDisplayName = ConfigurationManager.AppSettings["FromEmailDisplayName"].ToString();
            var vFromEmailPassword = ConfigurationManager.AppSettings["FromEmailPassword"].ToString();
            var vSMTPHost = ConfigurationManager.AppSettings["SMTPHost"].ToString();
            var vSMTPPort = ConfigurationManager.AppSettings["SMTPPort"].ToString();

            bool enabledSsl = bool.Parse(ConfigurationManager.AppSettings["EnabledSSL"].ToString());

            string body = content;
            MailMessage message = new MailMessage(new MailAddress(vFromEmailAddress, vFromEmailDisplayName), new MailAddress(vToEmailAddress));
            message.Subject = subject;
            message.IsBodyHtml = true;
            message.Body = body;

            var client = new SmtpClient();
            client.Credentials = new NetworkCredential(vFromEmailAddress, vFromEmailPassword);
            client.Host = vSMTPHost;
            client.EnableSsl = enabledSsl;
            client.Port = !string.IsNullOrEmpty(vSMTPPort) ? Convert.ToInt32(vSMTPPort) : 0;
            client.Send(message);
            
        }
    }
}
