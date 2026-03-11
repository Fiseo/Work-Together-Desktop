using WorkTogether.Data;
using WorkTogether.Data.Models;

namespace WorkTogether.WPF
{
    internal class AccountantWindow : AbstractWindow<Accountant>
    {
        public AccountantWindow(Accountant user, WorkTogetherContext? context = null) : base(user, context) { }
    }
}