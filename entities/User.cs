using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace entities;

public partial class User
{
    public int Id { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    [StringLength(maximumLength: 20, ErrorMessage = "too long password")]

    public string Password { get; set; } = null!;

    [EmailAddress(ErrorMessage = "Email not valid")]

    public string Email { get; set; } = null!;

    [JsonIgnore]

    public virtual ICollection<Order> Orders { get; } = new List<Order>();
}
