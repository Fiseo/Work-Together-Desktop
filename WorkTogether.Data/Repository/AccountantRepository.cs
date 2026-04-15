using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkTogether.Data.Models;

namespace WorkTogether.Data.Repository
{
    public class AccountantRepository: EntityRepository<Accountant>
    {
        public AccountantRepository() : base(new WorkTogetherContext()) { }
        public AccountantRepository(WorkTogetherContext context) : base(context) { }

        protected override void setDbSet()
        {
            DbSet = Context.AccountantSet;
        }

        public override List<Accountant> findAll()
        {
            return DbSet
                .Include(a => a.Civility)
                .ToList();
        }
    }
}
