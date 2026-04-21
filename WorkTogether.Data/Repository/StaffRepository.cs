using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkTogether.Data.Models;

namespace WorkTogether.Data.Repository
{
    public class StaffRepository : EntityRepository<Staff>
    {
        private UnitRepository _unitRepository;
        public StaffRepository() : this(new WorkTogetherContext()) { }
        public StaffRepository(WorkTogetherContext context) : base(context)
        {
            _unitRepository = new UnitRepository(context);
        }

        protected override void SetDbSet()
        {
            DbSet = Context.StaffSet;
        }

        public override List<Staff> FindAll()
        {
            return DbSet
                .Include(s => s.Civility)
                .Include(s => (s as Technician).ServiceCalls)
                .ToList();
        }
    }
}
