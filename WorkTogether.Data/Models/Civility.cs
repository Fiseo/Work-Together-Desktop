using System;
using System.Collections.Generic;

namespace WorkTogether.Data.Models;

public partial class Civility
{
    public int Id { get; set; }

    public string Label { get; set; } = null!;

    public virtual ICollection<Individual> Individuals { get; set; } = new List<Individual>();
    public virtual ICollection<Staff> Staffs { get; set; } = new List<Staff>();

}
