using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkTogether.Data.Models;

namespace WorkTogether.Data.Repository
{
    public class BookingRepository: EntityRepository<Booking>
    {
        public BookingRepository() : base(new WorkTogetherContext()) { }
        public BookingRepository(WorkTogetherContext context) : base(context) { }

        protected override void setDbSet()
        {
            DbSet = Context.BookingSet;
        }

        public override List<Booking> findAll()
        {
            return DbSet
                .Include(b => b.Individual)
                .Include(b => b.Company)
                .Include(b => b.Offer)
                .Include(b => b.BookingUnits)
                .ToList();
        }
    }
}
