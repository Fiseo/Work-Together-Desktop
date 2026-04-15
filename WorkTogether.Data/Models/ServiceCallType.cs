using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WorkTogether.Data.Models;

public partial class ServiceCallType : DbEntity
{
    public int Id { get; set; }

    [Required]
    [StringLength(255, MinimumLength = 2)]
    public string Label { get; set; } = null!;

    public ICollection<ServiceCall> ServiceCalls { get; set; } = new List<ServiceCall>();
}
