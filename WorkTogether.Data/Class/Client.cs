namespace WorkTogether.Data.Models
{
    abstract public class Client: User
    {
        public string? Review { get; set; }

        public int? Rating { get; set; }

        public override bool isDeletable()
        {
            return false;
        }
    }
}