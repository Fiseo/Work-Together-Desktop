using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace WorkTogether.Data.Models;

public partial class User
{
    public int Id { get; set; }

    public string Email { get; set; } = null!;

    public string Roles { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string Username { get; set; } = null!;

    public string Type { get; set; } = null!;

    public virtual string Label => "none";
}
