using Kavenegar;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace CorService.Sender
{
    public class MassageSender : IEmailSender,ISmsSender
    {
        public async Task SendEmail(string to, string subject, string body)
        {
            using (var Client = new SmtpClient())
            {
                var Credential = new NetworkCredential
                {
                    UserName = "KamraniPedram@gmail.com",
                    Password = "Pedram73@",
                };

                Client.Credentials = Credential;
                Client.Host = "smtp.gmail.com";
                Client.Port = 587;
                Client.EnableSsl = true;

                using (var emailMessage = new MailMessage())
                {
                    emailMessage.To.Add(new MailAddress(to));
                    emailMessage.From = new MailAddress("KamraniPedram@gmail.com");
                    emailMessage.Subject = subject;
                    emailMessage.IsBodyHtml = true;
                    emailMessage.Body = body;

                    Client.Send(emailMessage);
                };

                await Task.CompletedTask;
            }
        }

        public void SendSms(string to, string messageText)
        { }
            public async Task<string> SendAuthSmsAsync(string Code, string PhoneNumber)
            {
                HttpClient httpClient = new HttpClient();
                var httpResponse = await httpClient.GetAsync($"https://api.kavenegar.com/v1/989898989898989898/verify/lookup.json?receptor={PhoneNumber}&token={Code}&template=AuthVerify");
                if (httpResponse.StatusCode == HttpStatusCode.OK)
                    return "Success";
                else
                    return "Failed";
            }
            //    var sender = messageText;
            //    var receptor = to;
            //    var api = new KavenegarApi("3744505573527536327444554B61446B773446553430487967764B43473151647571623447354932726B773D");
            //    api.Send(sender, receptor, messageText);
        }
    }
