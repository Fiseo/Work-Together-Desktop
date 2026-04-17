namespace WorkTogether.Data.Models
{
    public partial class Accountant: Staff
    {
        public override bool IsDeleteable()
        {
            return true;
        }
    }
}