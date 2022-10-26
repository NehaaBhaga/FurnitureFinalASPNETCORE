using APICapstoneProject.Services;
using System;
using APICapstoneProject.Models;
using System.IO;
using System.Threading.Tasks;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Options;
using MimeKit;

using System.Text;


namespace APICapstoneProject.Services
{
    public class MailService : IMailService
    {
        private readonly MailSettings _mailSettings;
        public MailService(IOptions<MailSettings> mailSettings)
        {
            _mailSettings = mailSettings.Value;
        }

        public async Task SendEmailAsync(MailRequest mailRequest)
        {
            var email = new MimeMessage();
            email.Sender = MailboxAddress.Parse(_mailSettings.Mail);
            email.To.Add(MailboxAddress.Parse(mailRequest.Email));
            email.Subject = mailRequest.Subject;
            var builder = new BodyBuilder();
            //if (mailRequest.Attachments != null)
            //{
            //    byte[] fileBytes;
            //    foreach (var file in mailRequest.Attachments)
            //    {
            //        if (file.Length > 0)
            //        {
            //            using (var ms = new MemoryStream())
            //            {
            //                file.CopyTo(ms);
            //                fileBytes = ms.ToArray();
            //            }
            //            builder.Attachments.Add(file.FileName, fileBytes, ContentType.Parse(file.ContentType));
            //        }
            //    }
            //}
            builder.HtmlBody = mailRequest.Body;
            email.Body = builder.ToMessageBody();

            //string[] Body = new string[500];

            //builder.HtmlBody = mailRequest.FurnitureNeeded;
            //email.Body = builder.ToMessageBody();

            //builder.HtmlBody = mailRequest.EquipmentNeeded;
            //email.Body = builder.ToMessageBody();

            //builder.HtmlBody = mailRequest.ShippingAddress;
            //email.Body = builder.ToMessageBody();

            //builder.HtmlBody = mailRequest.DeliveryDate;
            //email.Body = builder.ToMessageBody();




            using var smtp = new SmtpClient();
            smtp.Connect(_mailSettings.Host, _mailSettings.Port, SecureSocketOptions.StartTls);
            smtp.Authenticate(_mailSettings.Mail, _mailSettings.Password);
            await smtp.SendAsync(email);
            smtp.Disconnect(true);


            //builder.HtmlBody = mailRequest.Body;
            //email.Body = builder.ToMessageBody();

            //using (SmtpClient client = new SmtpClient())
            //{
            //    try
            //    {

            //        client.ServerCertificateValidationCallback = (s, c, h, e) => true;
            //        client.CheckCertificateRevocation = false;
            //        await client.ConnectAsync(_mailSettings.Host,_mailSettings.Port,false);
            //        await client.AuthenticateAsync(_mailSettings.Mail, _mailSettings.Password);
            //        await client.SendAsync(email);
            //        client.Disconnect(true);


            //    }
            //    catch(Exception e)
            //    {
            //        string a = e.Message;
            //    }


            //}

            
        }
    }
}
