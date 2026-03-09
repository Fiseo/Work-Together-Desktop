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

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public int? CivilityId { get; set; }

    public string? Review { get; set; }

    public int? Rating { get; set; }

    public DateTime? BirthDate { get; set; }

    public string? CompanyRegister { get; set; }

    public DateTime? Creation { get; set; }

    public string? Name { get; set; }

    public virtual ICollection<Booking> BookingCompanies { get; set; } = new List<Booking>();

    public virtual ICollection<Booking> BookingIndividuals { get; set; } = new List<Booking>();

    public virtual Civility? Civility { get; set; }

    public virtual ICollection<ServiceCall> ServiceCalls { get; set; } = new List<ServiceCall>();
}
