using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkTogether.Data.Models;

namespace WorkTogether.Data.Repository
{
    public class ServiceCallTypeRepository : EntityRepository<ServiceCallType>
    {
        public ServiceCallTypeRepository() : base(new WorkTogetherContext()) { }
        public ServiceCallTypeRepository(WorkTogetherContext context) : base(context) { }

        protected override void setDbSet()
        {
            DbSet = Context.ServiceCallTypeSet;
        }

        public override List<ServiceCallType> findAll()
        {
            return DbSet
                .Include(sct => sct.ServiceCalls)
                .ToList();
        }
    }
}
