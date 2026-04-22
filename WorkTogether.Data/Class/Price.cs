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
            return false;
        }
    }
}
