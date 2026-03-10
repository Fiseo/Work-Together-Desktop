
namespace WorkTogether.Data.Models
{
    public class Individual: Client
    {
        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public int? CivilityId { get; set; }
        public virtual Civility? Civility { get; set; }

        public DateTime? BirthDate { get; set; }

        public virtual ICollection<Booking> Bookings { get; set; } = new List<Booking>();
    }
}