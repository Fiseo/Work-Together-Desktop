using System;
using System.Collections.Generic;

namespace WorkTogether.Data.Models;

public partial class Bay: DbEntity
{
    public int Id { get; set; }

    public string Label { get; set; } = null!;

    public ICollection<Unit> Units { get; set; } = new List<Unit>();

    public int NumberUnit { get => Units.Count; }
}
