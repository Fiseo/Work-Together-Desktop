using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WorkTogether.Data.Models;

public partial class Bay: DbEntity
{
    public int Id { get; set; }

    [Required]
    [StringLength(255, MinimumLength = 2)]
    public string Label { get; set; } = null!;

    public ICollection<Unit> Units { get; set; } = new List<Unit>();
}
