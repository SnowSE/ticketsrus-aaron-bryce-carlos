using MailKit;
using MailKit.Net.Smtp;
using Microsoft.Extensions.Configuration;
using MimeKit;
using MimeKit.Utils;
using System.Net.Mail;


namespace TicketLibrary.Services;

public class MailMailMail(IConfiguration _configuration)
{
    //base code for this implementation taken from 
    // https://github.com/jstedfast/MailKit and adjusted to be a class on it's own by Aaron
    // in order to use Gmail to send you must get a app password for the email
    // instructions as found on google:
    /*  1. Go to your Google Account.
        2. Select Security.
        3. Under "Signing in to Google," select 2-Step Verification.
        4. At the bottom of the page, select App passwords.
        5. Enter a name that helps you remember where you'll use the app password.
        6. Select Generate.
     */


    public string sendEmail(string ReceiverEmail,
                        string QRCodeFilePath)
    {
        try
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("Auto Emailer", _configuration["googleAccount"]));
            message.To.Add(new MailboxAddress("An Email in need of a Message", ReceiverEmail));
            message.Subject = "Automated Message System";

            BodyBuilder bodyBuilder = new BodyBuilder();
            bodyBuilder.HtmlBody = $@"<html>
            <body>
                <p>You have successfully bought a ticket!</p>
                <img alt=""this is an image"" src=""cid:QREmail"" width=""300"" class=""mb-5"" />
            </body>
        </html>";

            message.Body = bodyBuilder.ToMessageBody();

            var attachment = new MimePart("image", "png")
            {
                Content = new MimeContent(File.OpenRead(QRCodeFilePath)),
                ContentDisposition = new ContentDisposition(ContentDisposition.Attachment),
                ContentTransferEncoding = ContentEncoding.Base64,
                FileName = Path.GetFileName(QRCodeFilePath)
            };

            attachment.ContentId = MimeUtils.GenerateMessageId();
            bodyBuilder.Attachments.Add(attachment);

            bodyBuilder.HtmlBody = bodyBuilder.HtmlBody.Replace("{QRCode}", $"cid:{attachment.ContentId}");

            message.Body = bodyBuilder.ToMessageBody();

            using (var client = new MailKit.Net.Smtp.SmtpClient())
            {
                client.Connect("smtp.gmail.com", 587, false);

                // Note: only needed if the SMTP server requires authentication
                client.Authenticate(_configuration["googleAccount"], _configuration["googlePassword"]);

                client.Send(message);
                client.Disconnect(true);
            }

            return "Email Sent";
        }
        catch (Exception e)
        {
            return "Bad Exception Happened";
        }
    }


}
