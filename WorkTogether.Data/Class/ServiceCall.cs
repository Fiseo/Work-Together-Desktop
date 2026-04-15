using System;
using System.Collections.Generic;

namespace WorkTogether.Data.Models;

public partial class ServiceCall : DbEntity
{
    public override bool isDeletable()
    {
        return true;
    }
}
