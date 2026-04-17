using System;
using System.Collections.Generic;

namespace WorkTogether.Data.Models;

public partial class ServiceCallType : DbEntity
{
    public override bool IsDeleteable()
    {
        if (ServiceCalls.Count == 0)
            return true;
        return false;
    }
}
