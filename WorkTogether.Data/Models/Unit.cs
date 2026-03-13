using System;
using System.Collections.Generic;

namespace WorkTogether.Data.Models;

public partial class Unit
{
    public int Id { get; set; }

    public string Label { get; set; } = null!;

    public sbyte HaveProblem { get; set; }

    public int BayId { get; set; }

    public Bay Bay { get; set; } = null!;

    public ICollection<BookingUnit> BookingUnits { get; set; } = new List<BookingUnit>();

    public ICollection<ServiceCall> ServiceCalls { get; set; } = new List<ServiceCall>();

    public string FullLabel => Bay.Label + "-" + Label;
}
