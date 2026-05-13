using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkTogether.Data.Models
{
    public partial class Price : DbEntity
    {
        public override bool IsDeleteable()
        {
            if (Start >= DateTime.Now)
                return true;
            return false;
        }

        public bool IsCurrent()
        {
            if (Start >= DateTime.Now)
                return false;
            if (Start <= DateTime.Now && End == null)
                return true;
            if (Start <= DateTime.Now && End >= DateTime.Now)
                return true;
            return false;
        }

        public bool IsLast()
        {
            if(End == null)
                return true;
            return false;
        }
    }
}
