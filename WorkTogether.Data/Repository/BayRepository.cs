using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkTogether.Data.Models;

namespace WorkTogether.Data.Repository
{
    public class BayRepository: EntityRepository<Bay>
    {
        public BayRepository() : base(new WorkTogetherContext()) { }
        public BayRepository(WorkTogetherContext context) : base(context) { }

        protected override void setDbSet()
        {
            DbSet = Context.BaySet;
        }

        public override List<Bay> findAll()
        {
            return DbSet
                .Include(b => b.Units)
                .ToList();
        }
    }
}
