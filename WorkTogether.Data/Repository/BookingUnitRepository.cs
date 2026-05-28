using Microsoft.EntityFrameworkCore;
using WorkTogether.Data.Models;

namespace WorkTogether.Data.Repository;

public class BookingUnitRepository: EntityRepository<BookingUnit>
{
    public BookingUnitRepository() : base(new WorkTogetherContext()) { }
    public BookingUnitRepository(WorkTogetherContext context) : base(context) { }

    protected override void SetDbSet()
    {
        DbSet = Context.BookingUnitSet;
    }

    public override List<BookingUnit> FindAll()
    {
        return DbSet
            .Include(b => b.Booking)
            .Include(b => b.Unit)
            .ThenInclude(u => u.Bay)
            .ToList();
    }
}