using System;
using System.Collections.Generic;

namespace WorkTogether.Data.Models;

public partial class Offer : DbEntity
{
    public override bool IsDeleteable()
    {
        if (Bookings.Count == 0)
            return true;
        return false;
    }
}
