using System;
using System.Collections.Generic;

namespace lab_2_1.Models;

public partial class Product
{
    public int Productid { get; set; }

    public string? Name { get; set; }

    public double? Price { get; set; }

    public string? Category { get; set; }

    public int? Stockquantity { get; set; }

    public virtual ICollection<Sale> Sales { get; } = new List<Sale>();
}
