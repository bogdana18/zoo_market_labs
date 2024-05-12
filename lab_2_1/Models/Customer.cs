using System;
using System.Collections.Generic;

namespace lab_2_1.Models;

public partial class Customer
{
    public int Customerid { get; set; }

    public string? Name { get; set; }

    public string? Email { get; set; }

    public string? Phone { get; set; }

    public string? Address { get; set; }

    public virtual ICollection<Sale> Sales { get; } = new List<Sale>();
}
