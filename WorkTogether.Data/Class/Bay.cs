using System;
using System.Collections.Generic;

namespace WorkTogether.Data.Models;

public partial class Bay: DbEntity
{
    public int NumberUnit { get => Units.Count; }

    public override bool IsDeleteable()
    {
        if (NumberUnit == 0) 
            return true;
        return false;
    }

    public bool IsEveryUnitIsDeletable()
    {
        foreach(Unit unit in Units)
        {
            if (!unit.IsDeleteable())
                return false;
        }
        return true;
    }
}
