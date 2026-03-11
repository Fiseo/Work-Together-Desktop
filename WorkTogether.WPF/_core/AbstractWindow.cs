using System.Windows;
using WorkTogether.Data;
using WorkTogether.Data.Models;

namespace WorkTogether.WPF
{
    abstract public class AbstractWindow<U>: Window
        where U : User
    {
        protected U user;
        protected WorkTogetherContext context;

        public AbstractWindow(U user, WorkTogetherContext? context)
        {
            this.user = user;
            if (context != null)
                this.context = context;
            else
                this.context = new WorkTogetherContext();
        }

        public void logout()
        {
            //TODO
        }
    }
}