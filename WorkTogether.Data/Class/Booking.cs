using Google.Protobuf.WellKnownTypes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WorkTogether.Data.Models;

public partial class Booking: DbEntity
{
    public Client Client { get {
            if (Company != null)
                return Company;
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

    public override bool isDeletable()
    {
        if (!System.Convert.ToBoolean(this.IsPayed))
            return true;
        return false;
    }
}