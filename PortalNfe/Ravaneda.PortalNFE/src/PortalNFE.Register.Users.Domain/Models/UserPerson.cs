using PortalNFE.Core.DomainObjects;
using PortalNFE.Register.Users.Domain.Enums;

namespace PortalNFE.Register.Users.Domain.Models
{
    public class UserPerson : Entity
    {       
        public UserPerson(string name, 
                          string email, 
                          string cellPhone, 
                          string password, 
                          string confirmPassword)
        {
            Name = name;
            Email = email;
            CellPhone = cellPhone;
            Password = password;
            ConfirmPassword = confirmPassword;
        }

        public string Name { get; private set; } = string.Empty;
        public string Email { get; private set; } = string.Empty;
        public string CellPhone { get; private set; } = string.Empty;
        public string Password { get; private set; } = string.Empty;
        public string ConfirmPassword { get; private set; } = string.Empty;
        public EUserPersonStatus Status { get; private set; }
        public ICollection<UserPersonCompany> PersonCompanies { get; set; }
    }
}
