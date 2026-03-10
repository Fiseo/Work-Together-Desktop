using System;
using System.Collections.Generic;

namespace WorkTogether.Data.Models;

public partial class Civility
{
    public int Id { get; set; }

    public string Label { get; set; } = null!;

    public ICollection<Individual> Individuals { get; set; } = new List<Individual>();
    public ICollection<Staff> Staffs { get; set; } = new List<Staff>();

}
