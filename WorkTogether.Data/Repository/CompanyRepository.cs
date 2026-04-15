using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkTogether.Data.Models;

namespace WorkTogether.Data.Repository
{
    public class CompanyRepository: EntityRepository<Company>
    {
        public CompanyRepository() : base(new WorkTogetherContext()) { }
        public CompanyRepository(WorkTogetherContext context) : base(context) { }

        protected override void setDbSet()
        {
            DbSet = Context.CompanySet;
        }

        public override List<Company> findAll()
        {
            return DbSet
                .Include(c => c.Bookings)
                .ToList();
        }
    }
}
