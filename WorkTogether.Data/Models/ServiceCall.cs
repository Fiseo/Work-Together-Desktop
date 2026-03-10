using System;
using System.Collections.Generic;

namespace WorkTogether.Data.Models;

public partial class ServiceCall
{
    public int Id { get; set; }

    public DateTime Date { get; set; }

    public int TechnicianId { get; set; }

    public int UnitId { get; set; }

    public int TypeId { get; set; }

    public virtual Technician Technician { get; set; } = null!;

    public virtual ServiceCallType Type { get; set; } = null!;

    public virtual Unit Unit { get; set; } = null!;
}
