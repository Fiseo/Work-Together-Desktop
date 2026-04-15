namespace WorkTogether.Data.Models
{
    public class Company: Client
    {
        public string? CompanyRegister { get; set; }

        public DateTime? Creation { get; set; }

        public string? Name { get; set; }

        public ICollection<Booking> Bookings { get; set; } = new List<Booking>();

        public override string Label => Name;
    }
}