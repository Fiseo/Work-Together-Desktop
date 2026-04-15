using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WorkTogether.Data.Models;

public partial class Civility : DbEntity
{
    public int Id { get; set; }

    [Required]
    [StringLength(255, MinimumLength = 2)]
    public string Label { get; set; } = null!;

    public ICollection<Individual> Individuals { get; set; } = new List<Individual>();
    public ICollection<Staff> Staffs { get; set; } = new List<Staff>();

}
