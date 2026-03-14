using System;
using System.Collections.Generic;

namespace WorkTogether.Data.Models;

public partial class BookingUnit : DbEntity
{
    public int Id { get; set; }

    public DateTime Start { get; set; }

    public DateTime End { get; set; }

    public int BookingId { get; set; }

    public int UnitId { get; set; }

    public Booking Booking { get; set; } = null!;

    public Unit Unit { get; set; } = null!;
}
