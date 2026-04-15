using System;
using System.Collections.Generic;

namespace WorkTogether.Data.Models;

public partial class ServiceCallType : DbEntity
{
    public override bool isDeletable()
    {
        if (ServiceCalls.Count == 0)
            return true;
        return false;
    }
}
