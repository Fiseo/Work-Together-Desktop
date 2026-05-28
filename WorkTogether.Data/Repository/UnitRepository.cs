using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkTogether.Data.Models;

namespace WorkTogether.Data.Repository
{
    public class UnitRepository: EntityRepository<Unit>
    {
        public UnitRepository() : base(new WorkTogetherContext()) { }
        public UnitRepository(WorkTogetherContext context) : base(context) { }

        protected override void SetDbSet()
        {
            DbSet = Context.UnitSet;
        }

        public override List<Unit> FindAll()
        {
            return DbSet
                .Include(u => u.Bay)
                .Include(u => u.ServiceCalls)
                .Include(u => u.BookingUnits)
                .ThenInclude(b => b.Booking)
                .ToList();
        }

        public List<Unit> FindWithProblem()
        {
            return DbSet
                .Where(u => u.HaveProblem == true)
                .Include(u => u.Bay)
                .Include(u => u.ServiceCalls)
                .Include(u => u.BookingUnits)
                .ThenInclude(b => b.Booking)
                .ToList();
        }
        
        public List<Unit> FindUsedWithProblem()
        {
            var now = DateTime.Now;
            return DbSet
                .Where(u => u.HaveProblem == true 
                            && u.BookingUnits.Any(bu => bu.Start <= now && bu.End >= now))
                .Include(u => u.Bay)
                .Include(u => u.ServiceCalls)
                .Include(u => u.BookingUnits)
                .ThenInclude(b => b.Booking)
                .ToList();
        }

        public List<Unit> FindAvailable()
        {
            var now = DateTime.Now;
            return DbSet
                .Where(u => u.HaveProblem == false 
                            && !u.BookingUnits.Any(bu => bu.Start <= now && bu.End >= now))
                .Include(u => u.Bay)
                .Include(u => u.ServiceCalls)
                .Include(u => u.BookingUnits)
                .ThenInclude(b => b.Booking)
                .ToList();
        }
        
        public List<Unit> FindAvailableByBay(Bay bay)
        {
            var now = DateTime.Now;
            return DbSet
                .Where(u => !u.BookingUnits.Any(bu => bu.Start <= now && bu.End >= now) 
                            && u.HaveProblem == false 
                            && u.Bay == bay)
                .Include(u => u.Bay)
                .Include(u => u.ServiceCalls)
                .Include(u => u.BookingUnits)
                .ThenInclude(b => b.Booking)
                .ToList();
        }
    }
}
