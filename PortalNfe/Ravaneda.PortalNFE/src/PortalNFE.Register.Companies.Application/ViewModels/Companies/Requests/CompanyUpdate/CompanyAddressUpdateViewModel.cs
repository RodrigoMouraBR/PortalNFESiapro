namespace PortalNFE.Register.Companies.Application.ViewModels.Companies.Requests.CompanyUpdate
{
    public class CompanyAddressUpdateViewModel
    {
        public Guid CompanyId { get; set; }
        public string ZipCode { get; set; }
        public string Street { get; set; }
        public string Number { get; set; }
        public string Neighborhood { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string Complement { get; set; }
    }
}
