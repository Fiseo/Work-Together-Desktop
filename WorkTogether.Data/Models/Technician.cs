namespace WorkTogether.Data.Models
{
    public class Technician: Staff
    {
        public virtual ICollection<ServiceCall> ServiceCalls { get; set; } = new List<ServiceCall>();
    }
}