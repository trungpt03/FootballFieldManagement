using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using QuanLySanBong.Controllers;
using QuanLySanBong.Models;

namespace QuanLySanBong.Views
{
    public partial class DichVu : Window
    {
        private ProductController _productController;
        private ProductSaleController _productSaleController;
        private StadiumController _stadiumController;

        public ObservableCollection<Product> Products { get; set; }
        public ObservableCollection<ProductSale> OrderedProducts { get; set; }

        private int _bookingId;

        public DichVu(int bookingId)
        {
            InitializeComponent();

            _bookingId = bookingId;

            // Kết nối cơ sở dữ liệu
            string dbPath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "football_booking.db");
            _productController = new ProductController(dbPath);
            _productSaleController = new ProductSaleController(dbPath);
            _stadiumController = new StadiumController(dbPath);

            // Khởi tạo danh sách sản phẩm và sản phẩm đã order
            LoadProducts();
            LoadTenSanByID(_bookingId);
            LoadOrderedProducts(_bookingId);
        }

        private void LoadTenSanByID(int id)
        {
            // Lấy danh sách sân để ánh xạ
            var stadiums = _stadiumController.GetAllStadiums();

            // Ánh xạ tên sân
            
                var stadiumID = stadiums.FirstOrDefault(s => s.StadiumID == id);
                var s = stadiumID != null ? stadiumID.Name : "Không xác định";
                txtIDSan.Text = s;
        }

        // Tải danh sách sản phẩm khả dụng
        private void LoadProducts()
        {
            Products = new ObservableCollection<Product>(_productController.GetAllProducts());
            foreach (var product in Products)
            {
                product.Quantity = 0; // Khởi tạo số lượng là 0
            }
            ProductListView.ItemsSource = Products;
        }

        // Tải danh sách sản phẩm đã order từ cơ sở dữ liệu
        private void LoadOrderedProducts(int bookingId)
        {
            var orderedProducts = _productSaleController.GetOrderedProductsByBookingId(bookingId);

            OrderedProducts = new ObservableCollection<ProductSale>(orderedProducts);
            OrderedProductsListView.ItemsSource = OrderedProducts;
        }

        // Tăng số lượng sản phẩm
        private void IncreaseQuantity_Click(object sender, RoutedEventArgs e)
        {
            if (sender is FrameworkElement element && element.DataContext is Product product)
            {
                product.Quantity++;
            }
        }

        // Giảm số lượng sản phẩm
        private void DecreaseQuantity_Click(object sender, RoutedEventArgs e)
        {
            if (sender is FrameworkElement element && element.DataContext is Product product)
            {
                if (product.Quantity > 0)
                {
                    product.Quantity--;
                }
            }
        }

        // Đồng ý đặt hàng
        private void ConfirmButton_Click(object sender, RoutedEventArgs e)
        {
            foreach (var product in Products.Where(p => p.Quantity > 0))
            {
                var sale = new ProductSale
                {
                    ProductID = product.ProductID,
                    StadiumRentID = _bookingId, // Liên kết với Booking hiện tại
                    Quantity = product.Quantity,
                    TotalPrice = product.Quantity * product.SalePrice, // Sửa lỗi thiếu TotalPrice
                    SaleDate = DateTime.Now
                };

                _productSaleController.AddSale(sale);
            }

            // Tải lại danh sách sản phẩm đã order
            LoadOrderedProducts(_bookingId);
            Reload();
            //MessageBox.Show("Đơn hàng đã được lưu!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
            this.Close();
            
        }

        // Hủy đặt hàng
        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            Reload();
            this.Close();
        }

        private void Reload()
        {
            foreach (var product in Products)
            {
                product.Quantity = 0;
            }
        }

        private void DeleteProduct_Click(object sender, RoutedEventArgs e)
        {
            if (sender is FrameworkElement element && element.DataContext is ProductSale productSale)
            {
                // Xóa sản phẩm khỏi cơ sở dữ liệu
                var success = _productSaleController.DeleteSale(productSale.SaleID);

                if (success)
                {
                    // Xóa sản phẩm khỏi danh sách hiển thị
                    OrderedProducts.Remove(productSale);

                    MessageBox.Show("Đã xóa sản phẩm khỏi danh sách.", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    MessageBox.Show("Không thể xóa sản phẩm. Vui lòng thử lại.", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

    }
}
