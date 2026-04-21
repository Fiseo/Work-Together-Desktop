using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WorkTogether.Data.Models;

public class User : DbEntity
{
    public int Id { get; set; }

    [Required]
    [EmailAddress]
    public string Email { get; set; } = null!;

    public string Roles { get; set; } = "{ }";

    [Required]
    public string Password { get; set; } = null!;

    [Required]
    public string Username { get; set; } = null!;

    public string Type { get; set; } = null!;

    public virtual string Label => "none";

    public override bool IsDeleteable()
    {
        return false;
    }
}
