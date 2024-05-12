using System;
using System.Collections.Generic;

namespace lab_2_1.Models;

public partial class Pet
{
    public int Petid { get; set; }

    public string? Species { get; set; }

    public string? Name { get; set; }

    public string? Breed { get; set; }

    public DateOnly? Birthdate { get; set; }

    public string? Healthstatus { get; set; }

    public virtual ICollection<Sale> Sales { get; } = new List<Sale>();
}
