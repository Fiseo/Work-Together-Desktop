using System;
using System.Collections.Generic;

namespace WorkTogether.Data.Models;

public partial class BookingUnit
{
    public int Id { get; set; }

    public DateTime Start { get; set; }

    public DateTime End { get; set; }

    public int BookingId { get; set; }

    public int UnitId { get; set; }

    public virtual Booking Booking { get; set; } = null!;

    public virtual Unit Unit { get; set; } = null!;
}
