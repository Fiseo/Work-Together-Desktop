using Google.Protobuf.WellKnownTypes;
using System;
using System.Collections.Generic;

namespace WorkTogether.Data.Models;

public partial class Booking: DbEntity
{
    public int Id { get; set; }

    public sbyte IsMonthly { get; set; }

    public DateTime Start { get; set; }

    public DateTime End { get; set; }

    public int OfferId { get; set; }
    public virtual Offer Offer { get; set; } = null!;

    public sbyte IsPayed { get; set; }

    public sbyte IsRenewable { get; set; }

    public int? IndividualId { get; set; }
    public virtual Individual? Individual { get; set; }

    public int? CompanyId { get; set; }
    public virtual Company? Company { get; set; }

    public string Label { get; set; } = null!;

    public ICollection<BookingUnit> BookingUnits { get; set; } = new List<BookingUnit>();

    public Client Client { get {
            if (Company != null)
                return this.Company;
            return Individual;
        } 
    }

    public string Status { get
        {
            DateTime now = DateTime.Now;
            bool IsPayed = System.Convert.ToBoolean(this.IsPayed);
            if (IsPayed && Start <= now && End >= now)
                return "Active";
            else if (IsPayed && End <= now)
                return "Terminée";
            else if (!IsPayed)
                return "En attente de payement";
            return "aucune";
        } }
}