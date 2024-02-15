namespace PortalNFE.Core.Messages.CommonMessages.IntegrationEvents.UserPerson
{
    public class CreateIdentityUserPersonEvent : IntegrationEvent
    {
        public CreateIdentityUserPersonEvent(string email, string password, string confirmPassword, Guid userPersonId)
        {
            Email = email;
            Password = password;
            ConfirmPassword = confirmPassword;
            UserPersonId = userPersonId;
        }

        public string Email { get; private set; }
        public string Password { get; private set; }
        public string ConfirmPassword { get; private set; }
        public Guid UserPersonId { get; private set; }
    }
}
