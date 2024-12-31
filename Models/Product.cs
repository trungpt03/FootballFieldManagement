using SQLite;
using System.ComponentModel;

public class Product : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler PropertyChanged;

    [PrimaryKey, AutoIncrement]
    public int ProductID { get; set; }
    public string Name { get; set; }
    public double SalePrice { get; set; }
    public double PurchasePrice { get; set; }
    public int StockQuantity { get; set; }

    private int _quantity;
    [Ignore]
    public int Quantity
    {
        get => _quantity;
        set
        {
            if (_quantity != value)
            {
                _quantity = value;
                OnPropertyChanged(nameof(Quantity));
                OnPropertyChanged(nameof(TotalPrice));
            }
        }
    }

    [Ignore]
    public double TotalPrice => Quantity * SalePrice;

    protected void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
