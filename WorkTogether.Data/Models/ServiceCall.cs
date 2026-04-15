using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WorkTogether.Data.Models;

public partial class ServiceCall : DbEntity
{
    public int Id { get; set; }

    [Required]
    public DateTime Date { get; set; }

    public int TechnicianId { get; set; }

    public int UnitId { get; set; }

    public int TypeId { get; set; }

    [Required]
    public Technician Technician { get; set; } = null!;

    [Required]
    public ServiceCallType Type { get; set; } = null!;

    [Required]
    public Unit Unit { get; set; } = null!;
}
