using System;
using System.Collections.Generic;

namespace WorkTogether.Data.Models;

public partial class Civility
{
    public int Id { get; set; }

    public string Label { get; set; } = null!;

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
