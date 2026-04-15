using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkTogether.Data.Models;

namespace WorkTogether.Data.Repository
{
    public class ServiceCallRepository: EntityRepository<ServiceCall>
    {
        public ServiceCallRepository() : base(new WorkTogetherContext()) { }
        public ServiceCallRepository(WorkTogetherContext context) : base(context) { }

        protected override void setDbSet()
        {
            DbSet = Context.ServiceCallSet;
        }

        public override List<ServiceCall> findAll()
        {
            return DbSet
                .Include(sc => sc.Unit)
                .Include(sc => sc.Technician)
                .Include(sc => sc.Type)
                .ToList();
        }
    }
}
