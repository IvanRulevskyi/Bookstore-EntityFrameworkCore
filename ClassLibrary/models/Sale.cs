namespace ClassLibrary.models;

public class Sale
{
    public int Id { get; set; }
    public string Title { get; set; } = "";
    public int Quantity { get; set; }
    public decimal UnitPrice { get; set; }
    public decimal TotalPrice { get; set; }
    public DateTime? SaleDate  { get; set; }

    public string Author { get; set; } = "";

    public string Genre { get; set; } = "";

    public int UserId { get; set; }
    public Login? User { get; set; }
}
