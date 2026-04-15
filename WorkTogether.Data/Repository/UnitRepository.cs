using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkTogether.Data.Models;

namespace WorkTogether.Data.Repository
{
    public class UnitRepository: EntityRepository<Unit>
    {
        public UnitRepository() : base(new WorkTogetherContext()) { }
        public UnitRepository(WorkTogetherContext context) : base(context) { }

        protected override void setDbSet()
        {
            DbSet = Context.UnitSet;
        }

        public override List<Unit> findAll()
        {
            return DbSet
                .Include(u => u.Bay)
                .Include(u => u.ServiceCalls)
                .Include(u => u.BookingUnits)
                .ToList();
        }
    }
}
