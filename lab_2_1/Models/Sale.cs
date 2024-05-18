using lab_2_1.Models;

public class Sale
{
    public int Saleid { get; set; }
    public int? Customerid { get; set; }
    public int? Employeeid { get; set; }
    public int? Petid { get; set; }
    public int? Productid { get; set; }
    public DateOnly? Saledate { get; set; }
    public double Totalamount { get; set; }
    public string Paymentmethod { get; set; }

    public virtual Customer Customer { get; set; }
    public virtual Employee Employee { get; set; }
    public virtual Pet Pet { get; set; }
    public virtual Product Product { get; set; }
}