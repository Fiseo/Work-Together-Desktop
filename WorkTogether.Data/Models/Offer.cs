using System;
using System.Collections.Generic;

namespace WorkTogether.Data.Models;

public partial class Offer
{
    public int Id { get; set; }

    public string Label { get; set; } = null!;

    public int Discount { get; set; }

    public int UnitProvided { get; set; }

    public string Description { get; set; } = null!;

    public ICollection<Booking> Bookings { get; set; } = new List<Booking>();
}
