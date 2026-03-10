namespace WorkTogether.Data.Models
{
    abstract public class Staff: User
    {
        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public int? CivilityId { get; set; }
        public virtual Civility? Civility { get; set; }
    }
}