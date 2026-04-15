using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WorkTogether.Data.Models;

public partial class Offer : DbEntity
{
    public int Id { get; set; }

    [Required]
    [StringLength(255, MinimumLength = 2)]
    public string Label { get; set; } = null!;

    [Required]
    [Range(0, 100)]
    public int Discount { get; set; }

    [Required]
    public int UnitProvided { get; set; }

    [Required]
    public string Description { get; set; } = null!;

    public ICollection<Booking> Bookings { get; set; } = new List<Booking>();
}
