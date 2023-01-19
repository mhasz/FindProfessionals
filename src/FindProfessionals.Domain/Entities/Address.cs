namespace FindProfessionals.Domain.Entities
{
    public class Address
    {
        public Guid Id { get; set; }
        public string AddressName { get; set; }
        public string Complement { get; set; }
        public int Number { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public int PostalCode { get; set; }

        public Guid UserId{ get; set; }
        public virtual User User{ get; set; }
    }
}
