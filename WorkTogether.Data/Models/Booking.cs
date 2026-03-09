using System;
using System.Collections.Generic;

namespace WorkTogether.Data.Models;

public partial class Booking
{
    public int Id { get; set; }

    public sbyte IsMonthly { get; set; }

    public DateTime Start { get; set; }

    public DateTime End { get; set; }

    public int OfferId { get; set; }

    public sbyte IsPayed { get; set; }

    public sbyte IsRenewable { get; set; }

    public int? IndividualId { get; set; }

    public int? CompanyId { get; set; }

    public string Label { get; set; } = null!;

    public virtual ICollection<BookingUnit> BookingUnits { get; set; } = new List<BookingUnit>();

    public virtual User? Company { get; set; }

    public virtual User? Individual { get; set; }

    public virtual Offer Offer { get; set; } = null!;
}
