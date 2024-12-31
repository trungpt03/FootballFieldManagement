using SQLite;

public class ProductSale
{
    [PrimaryKey, AutoIncrement]
    public int SaleID { get; set; }
    public int ProductID { get; set; }
    public int StadiumRentID { get; set; } 
    public int Quantity { get; set; }
    public double TotalPrice { get; set; }
    public DateTime SaleDate { get; set; }

    [Ignore]
    public string ProductName { get; set; } // Đặt giá trị từ bên ngoài
}
