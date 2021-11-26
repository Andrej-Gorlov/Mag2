using Mailjet.Client;
using Mailjet.Client.Resources;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mag2.AdditionalServices
{
    // рассылка emails
    public class EmailSender : IEmailSender
    {

        private readonly IConfiguration configuration;
        public MailJetSettings mailJetSettings { get; set; }

        public EmailSender(IConfiguration configuration)
        {
            this.configuration = configuration;
        }


        public Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            return Execute(email,subject,htmlMessage);
        }
        public async Task Execute(string email, string subject, string body)
        {
            //хранения ключей в appsettings
            this.mailJetSettings = this.configuration.GetSection("MailJet").Get<MailJetSettings>();
            
            MailjetClient client = new MailjetClient(this.mailJetSettings.ApiKey, this.mailJetSettings.SecretKey)
            {
                Version = ApiVersion.V3_1,
            };
            MailjetRequest request = new MailjetRequest
            {
                Resource = Send.Resource,
            }
             .Property(Send.Messages, new JArray 
             {
                 new JObject 
                 {
                     {
                       "From",
                        new JObject 
                        {
                            {"Email", "zverekane@yandex.ru"},
                            {"Name", "Andrej"}
                        }
                     }, 

                     {
                       "To",
                        new JArray 
                        {
                            new JObject 
                            {
                                {
                                  "Email",
                                  email
                                },
                                {
                                  "Name",
                                  "DotNetMastery"//имя получателя
                                }
                            }
                        }
                        }, 
                     {
                       "Subject",
                       subject //тема сообщения 
                     }
                     , 
                     {
                       "HTMLPart",
                       body
                     }
                 }
             });
            await client.PostAsync(request);

        }
    }
}
