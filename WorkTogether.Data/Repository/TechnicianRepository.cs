using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkTogether.Data.Models;

namespace WorkTogether.Data.Repository
{
    public class TechnicianRepository: EntityRepository<Technician>
    {
        public TechnicianRepository() : base(new WorkTogetherContext()) { }
        public TechnicianRepository(WorkTogetherContext context) : base(context) { }

        protected override void SetDbSet()
        {
            DbSet = Context.TechnicianSet;
        }

        public override List<Technician> FindAll()
        {
            return DbSet
                .Include(t => t.ServiceCalls)
                .ToList();
        }
    }
}
