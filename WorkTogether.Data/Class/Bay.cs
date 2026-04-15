using System;
using System.Collections.Generic;

namespace WorkTogether.Data.Models;

public partial class Bay: DbEntity
{
    public int NumberUnit { get => Units.Count; }

    public override bool isDeletable()
    {
        if (NumberUnit == 0) 
            return true;
        return false;
    }
}
