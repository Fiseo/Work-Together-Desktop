using System;
using System.Collections.Generic;

namespace WorkTogether.Data.Models;

public partial class Unit
{
    public int Id { get; set; }

    public string Label { get; set; } = null!;

    public sbyte HaveProblem { get; set; }

    public int BayId { get; set; }

    public virtual Bay Bay { get; set; } = null!;

    public virtual ICollection<BookingUnit> BookingUnits { get; set; } = new List<BookingUnit>();

    public virtual ICollection<ServiceCall> ServiceCalls { get; set; } = new List<ServiceCall>();
}
