using System;
using System.Collections.Generic;

namespace WorkTogether.Data.Models;

public partial class ServiceCall : DbEntity
{
    public int Id { get; set; }

    public DateTime Date { get; set; }

    public int TechnicianId { get; set; }

    public int UnitId { get; set; }

    public int TypeId { get; set; }

    public Technician Technician { get; set; } = null!;

    public ServiceCallType Type { get; set; } = null!;

    public Unit Unit { get; set; } = null!;
}
