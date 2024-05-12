using System;
using System.Collections.Generic;

namespace lab_2_1.Models;

public partial class Employee
{
    public int Employeeid { get; set; }

    public string? Name { get; set; }

    public string? Position { get; set; }

    public string? Email { get; set; }

    public double? Salary { get; set; }

    public virtual ICollection<Sale> Sales { get; } = new List<Sale>();
}
