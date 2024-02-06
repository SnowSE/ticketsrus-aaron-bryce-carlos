using MailKit;
using MailKit.Net.Smtp;
using MimeKit;
using System.Net.Mail;

namespace TicketLibrary.Services;

public class MailMailMail
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
    public string sendEmail(string SenderEmail,
                            string SenderPass,
                            string ReceiverEmail,
                            string QRCode)
    {
        try
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("Auto Emailer", SenderEmail));
            message.To.Add(new MailboxAddress("An Email in need of a Message", ReceiverEmail));
            message.Subject = "Automated Message System";

            message.Body = new TextPart("plain")
            {
                Text = @$"Hey YOU,

                   I just wanted to let you know that this is a really authentic message and you should tip Jonathan heavily when you get it.

                    {QRCode}"
            };

            using (var client = new MailKit.Net.Smtp.SmtpClient())
            {
                client.Connect("smtp.gmail.com", 587, false);

                // Note: only needed if the SMTP server requires authentication
                client.Authenticate(SenderEmail, SenderPass);

                client.Send(message);
                client.Disconnect(true);
            }
            return "Email Sent";
        }
        catch (Exception e)
        {
            return "Bad Exception Happend";
        }
    }
}
