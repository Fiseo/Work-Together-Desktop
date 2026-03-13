namespace WorkTogether.Data.Models
{
    abstract public class Staff: User
    {
        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public int? CivilityId { get; set; }
        public Civility? Civility { get; set; }

        public override string Label => FirstName + " " + LastName;
    }
}