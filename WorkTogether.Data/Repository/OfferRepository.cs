using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkTogether.Data.Models;

namespace WorkTogether.Data.Repository
{
    public class OfferRepository : EntityRepository<Offer>
    {
        public OfferRepository() : base(new WorkTogetherContext()) { }
        public OfferRepository(WorkTogetherContext context) : base(context) { }

        protected override void SetDbSet()
        {
            DbSet = Context.OfferSet;
        }

        public override List<Offer> FindAll()
        {
            return DbSet
                .Include(o => o.Bookings)
                .ToList();
        }

        public List<Offer> FindAllActive()
        {
            return DbSet
                .Include(o => o.Bookings)
                .Where(o => o.IsActive == true)
                .ToList();
        }
    }
}
