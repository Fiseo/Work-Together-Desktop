using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkTogether.Data.Models;

namespace WorkTogether.Data.Repository
{
    public class PriceRepository : EntityRepository<Price>
    {
        public PriceRepository() : base(new WorkTogetherContext()) { }
        public PriceRepository(WorkTogetherContext context) : base(context) { }

        protected override void SetDbSet()
        {
            DbSet = Context.PriceSet;
        }

        public Price? FindLatest()
        {
            return DbSet
                .Include(p => p.Preceding)
                .Include(p => p.Successor)
                .Where(p => p.End == null)
                .SingleOrDefault();
        }

        public override List<Price> FindAll()
        {
            return DbSet
                .Include(p => p.Preceding)
                .Include (p => p.Successor)
                .ToList();
        }
    }
}
