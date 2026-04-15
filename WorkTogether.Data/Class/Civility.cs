using System;
using System.Collections.Generic;

namespace WorkTogether.Data.Models;

public partial class Civility : DbEntity
{
    public override bool isDeletable()
    {
        if (Individuals.Count == 0 && Staffs.Count == 0)
            return true;
        return false;
    }

}
