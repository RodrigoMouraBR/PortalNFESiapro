using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;
using PortalNFE.Core.Interfaces;

namespace PortalNFE.Core.SendEMail
{
    public class EmailSenderService : IEmailSenderService
    {
        public async Task SendEmail(string destinatario, string assunto, string corpo)
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("Seu Nome", "seuemail@dominio.com"));
            message.To.Add(new MailboxAddress("", destinatario));
            message.Subject = assunto;

            var builder = new BodyBuilder();
            builder.TextBody = corpo;
            message.Body = builder.ToMessageBody();

            using var client = new SmtpClient();
            await client.ConnectAsync("smtp.gmail.com", 587, SecureSocketOptions.StartTls);

            #region
            // gmail:            client.ConnectAsync("smtp.gmail.com", 587, SecureSocketOptions.StartTls);
            // hotmail:          client.ConnectAsync("smtp.live.com", 587, SecureSocketOptions.StartTls);
            // office 365:       client.ConnectAsync("smtp.office365.com", 587, SecureSocketOptions.StartTls);
            // aws ses (simple email service):   client.ConnectAsync("email-smtp.[AWS REGION].amazonaws.com", 587, SecureSocketOptions.StartTls);
            #endregion

            await client.AuthenticateAsync("seuemail@dominio.com", "suaSenha");
            await client.SendAsync(message);
            await client.DisconnectAsync(true);
        }
    }
}
