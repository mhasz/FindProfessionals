namespace FindProfessionals.Domain.Dtos.Address
{
    public class AddressDto
    {
        public Guid Id { get; set; }
        public string AddressName { get; set; }
        public string Complement { get; set; }
        public int Number { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
    }
}
