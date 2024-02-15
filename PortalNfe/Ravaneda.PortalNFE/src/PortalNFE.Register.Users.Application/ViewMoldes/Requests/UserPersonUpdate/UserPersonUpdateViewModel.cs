using System.ComponentModel.DataAnnotations;

namespace PortalNFE.Register.Users.Application.ViewMoldes.Requests.UserPersonUpdate
{
    public class UserPersonUpdateViewModel
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string CellPhone { get; set; } = string.Empty;
    }
}
