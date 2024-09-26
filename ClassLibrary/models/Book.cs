namespace ClassLibrary.models;

public class Book
{
    public int Id { get; set; }
    public string Title { get; set; } = "";
    public string Publisher { get; set; } = "";
    public int Pages { get; set; }
    public int Year { get; set; }
    public decimal CostPrice { get; set; }
    public decimal SellingPrice { get; set; }


    public int GenreId { get; set; }
    public Genre? Genre { get; set; }

    public int AuthorId { get; set; }
    public Author? Author { get; set; }

    public decimal? DiscountPercentage { get; set; }
    public DateTime? PromotionStartDate { get; set; }
    public DateTime? PromotionEndDate { get; set; }
    public decimal PriceWithDiscount
    {
        get
        {
            if (DiscountPercentage.HasValue &&
                PromotionStartDate.HasValue && PromotionEndDate.HasValue &&
                DateTime.Now >= PromotionStartDate && DateTime.Now <= PromotionEndDate)
            {
                return SellingPrice - (SellingPrice * DiscountPercentage.Value / 100);
            }

            return SellingPrice;
        }
    }
}
