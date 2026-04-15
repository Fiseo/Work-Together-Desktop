namespace WorkTogether.Data.Models
{
    public class Technician: Staff
    {
        public ICollection<ServiceCall> ServiceCalls { get; set; } = new List<ServiceCall>();

        public override bool isDeletable()
        {
            if (ServiceCalls.Count == 0)
                return true;
            return false;
        }
    }
}