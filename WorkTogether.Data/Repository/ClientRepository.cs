using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkTogether.Data.Models;

namespace WorkTogether.Data.Repository
{
    public class ClientRepository : EntityRepository<Client>
    {
        private UnitRepository _unitRepository;
        public ClientRepository() : this(new WorkTogetherContext()) { }
        public ClientRepository(WorkTogetherContext context) : base(context)
        {
            _unitRepository = new UnitRepository(context);
        }

        protected override void SetDbSet()
        {
            DbSet = Context.ClientSet;
        }

        public override List<Client> FindAll()
        {
            return DbSet
                .Include(s => (s as Individual).Civility)
                .Include(s => (s as Individual).Bookings)
                .Include(s => (s as Company).Bookings)
                .ToList();
        }
        
        public List<Client> FindAllWithBookingFulfill()
        {
            return DbSet
                //Individual   
                .Include(s => (s as Individual).Civility)
                .Include(s => (s as Individual).Bookings)
                .ThenInclude(b => b.BookingUnits)
                .Include(s => (s as Individual).Bookings)
                .ThenInclude(b => b.Offer)
                
                //Company
                .Include(s => (s as Company).Bookings)
                .Include(s => (s as Company).Bookings)
                .ThenInclude(b => b.BookingUnits)
                .Include(s => (s as Company).Bookings)
                .ThenInclude(b => b.Offer)
                
                .ToList();
        }
    }
}
