using System;
using System.Collections.Generic;

namespace WorkTogether.Data.Models;

public partial class BookingUnit : DbEntity
{
    public override bool isDeletable()
    {
        return true;
    }

    public bool isCurrent   
    {
        get
        {
            DateTime now = DateTime.Now;
            return (Start <= now && End >= now);
        }
    }
}
