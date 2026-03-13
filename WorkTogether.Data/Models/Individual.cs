
namespace WorkTogether.Data.Models
{
    public class Individual: Client
    {
        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public int? CivilityId { get; set; }
        public Civility? Civility { get; set; }

        public DateTime? BirthDate { get; set; }

        public ICollection<Booking> Bookings { get; set; } = new List<Booking>();

        public override string Label => FirstName + " " + LastName;
    }
}