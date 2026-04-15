using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkTogether.Data.Models;

namespace WorkTogether.Data.Repository
{
    public class IndividualRepository: EntityRepository<Individual>
    {
        public IndividualRepository() : base(new WorkTogetherContext()) { }
        public IndividualRepository(WorkTogetherContext context) : base(context) { }

        protected override void setDbSet()
        {
            DbSet = Context.IndividualSet;
        }

        public override List<Individual> findAll()
        {
            return DbSet
                .Include(i => i.Civility)
                .Include(i => i.Bookings)
                .ToList();
        }
    }
}
