using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkTogether.Data.Models;

namespace WorkTogether.Data.Repository
{
    public class UserRepository: EntityRepository<User>
    {
        public UserRepository() : base(new WorkTogetherContext()) { }
        public UserRepository(WorkTogetherContext context) : base(context) { }

        protected override void setDbSet()
        {
            DbSet = Context.UserSet;
        }
    }
}
