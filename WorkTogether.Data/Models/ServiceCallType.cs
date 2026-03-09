using System;
using System.Collections.Generic;

namespace WorkTogether.Data.Models;

public partial class ServiceCallType
{
    public int Id { get; set; }

    public string Label { get; set; } = null!;

    public virtual ICollection<ServiceCall> ServiceCalls { get; set; } = new List<ServiceCall>();
}
