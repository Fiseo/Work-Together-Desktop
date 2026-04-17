using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkTogether.Data.Models;

namespace WorkTogether.Data.Repository
{
    public class CivilityRepository: EntityRepository<Civility>
    {
        public CivilityRepository():base(new WorkTogetherContext()) { }
        public CivilityRepository(WorkTogetherContext context) : base(context) { }

        protected override void SetDbSet()
        {
            DbSet = Context.CivilitySet;
        }

        public override List<Civility> FindAll()
        {
            return DbSet
                .Include(c => c.Individuals)
                .Include(c => c.Staffs)
                .ToList();
        }
    }
}
