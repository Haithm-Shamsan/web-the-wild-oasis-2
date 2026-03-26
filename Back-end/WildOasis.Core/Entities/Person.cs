using System;
using System.Collections.Generic;

namespace Api_WildOasis.Entities;

public partial class Person
{
    public int PersonId { get; set; }

    public string FullName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string NationalId { get; set; } = null!;

    public string Nationality { get; set; } = null!;

    public string CountryFlag { get; set; } = null!;

   
}
