namespace PortalNFE.Register.Company.Domain.Models
{
    public class CompanyAddress : Entity
    {
        public CompanyAddress(string zipCode, 
                              string street, 
                              string number, 
                              string neighborhood, 
                              string city, 
                              string state, 
                              string country, 
                              string complement)
        {
            ZipCode = zipCode;
            Street = street;
            Number = number;
            Neighborhood = neighborhood;
            City = city;
            State = state;
            Country = country;
            Complement = complement;
        }
        protected CompanyAddress()
        {
        }
        public Guid CompanyId { get; private set; }
        public string ZipCode { get; private set; } = string.Empty;
        public string Street { get; private set; } = string.Empty;
        public string Number { get; private set; } = string.Empty;
        public string Neighborhood { get; private set; } = string.Empty;
        public string City { get; private set; } = string.Empty;
        public string State { get; private set; } = string.Empty;
        public string Country { get; private set; } = string.Empty;
        public string Complement { get; private set; } = string.Empty;

        //EF
        public Company Companies { get; private set; }

        internal void RelateAddressCompany(Guid companyId)
        {
            Id = Guid.NewGuid();
            CompanyId = companyId;
        }
    }
}
