using System;
using System.Collections.Generic;

namespace WorkTogether.Data.Models;

public partial class Unit : DbEntity
{
    public string FullLabel => Bay.Label + "-" + Label;

    public string Status
    {
        get
        {
            bool HaveProblem = System.Convert.ToBoolean(this.HaveProblem);
            if (HaveProblem)
                return "Incident";
            return "Ok";
        }
    }

    public override bool IsDeleteable()
    {
        //TODO : Optimiser cette vérification
        foreach (BookingUnit var in BookingUnits)
            if (var.IsCurrent)
                return false;
        return true;
    }
}
