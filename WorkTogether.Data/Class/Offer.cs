using System;
using System.Collections.Generic;

namespace WorkTogether.Data.Models;

public partial class Offer : DbEntity
{
    public override bool isDeletable()
    {
        if (Bookings.Count == 0)
            return true;
        return false;
    }
}
