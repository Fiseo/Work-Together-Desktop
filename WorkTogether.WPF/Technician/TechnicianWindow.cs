using WorkTogether.Data;
using WorkTogether.Data.Models;

namespace WorkTogether.WPF
{
    internal class TechnicianWindow : AbstractWindow<Technician>
    {
        public TechnicianWindow(Technician user, WorkTogetherContext? context = null) : base(user, context) { }
    }
}