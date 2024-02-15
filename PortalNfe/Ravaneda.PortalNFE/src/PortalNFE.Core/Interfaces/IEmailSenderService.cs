namespace PortalNFE.Core.Interfaces
{
    public interface IEmailSenderService
    {
        Task SendEmail(string destinatario, string assunto, string corpo);
    }
}
