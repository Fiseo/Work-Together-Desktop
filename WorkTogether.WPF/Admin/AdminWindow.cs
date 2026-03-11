using WorkTogether.Data;
using WorkTogether.Data.Models;

namespace WorkTogether.WPF
{
    internal class AdminWindow : AbstractWindow<User>
    {
        public AdminWindow(User user, WorkTogetherContext? context = null) : base(user, context) { }
    }
}