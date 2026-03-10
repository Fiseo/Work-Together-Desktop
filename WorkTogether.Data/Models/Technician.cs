namespace WorkTogether.Data.Models
{
    public class Technician: Staff
    {
        public ICollection<ServiceCall> ServiceCalls { get; set; } = new List<ServiceCall>();
    }
}