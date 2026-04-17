using System;
using System.Collections.Generic;

namespace WorkTogether.Data.Models;

public partial class BookingUnit : DbEntity
{
    public override bool IsDeleteable()
    {
        return true;
    }

    public bool IsCurrent   
    {
        get
        {
            DateTime now = DateTime.Now;
            return (Start <= now && End >= now);
        }
    }
}
