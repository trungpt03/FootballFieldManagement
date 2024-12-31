using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using QuanLySanBong.Controllers;
using QuanLySanBong.Models;

namespace QuanLySanBong.Views
{
    /// <summary>
    /// Interaction logic for QuanLyProduct.xaml
    /// </summary>
    public partial class QuanLyProduct : Window
    {
        private ProductController _productController;
        public QuanLyProduct()
        {
            InitializeComponent();

            // Đường dẫn đến cơ sở dữ liệu
            string dbPath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "football_booking.db");
            _productController = new ProductController(dbPath);

            LoadProducts();
        }

        private void ClearForm()
        {
            txtProductName.Clear();
            //txtPurchasePrice.Clear();
            txtSalePrice.Clear();
            //txtStockQuantity.Clear();
        }

        private void LoadProducts()
        {
            var products = _productController.GetAllProducts();
            dataGridProducts.ItemsSource = products;
        }


        private void AddProduct_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Kiểm tra tính hợp lệ của các trường nhập liệu
                if (string.IsNullOrWhiteSpace(txtProductName.Text) ||
                    string.IsNullOrWhiteSpace(txtSalePrice.Text))
                {
                    MessageBox.Show("Vui lòng điền đầy đủ thông tin sản phẩm.", "Thông báo");
                    return;
                }

                // Chuyển đổi dữ liệu từ các ô nhập liệu
                string productName = txtProductName.Text;
                //if (!double.TryParse(txtPurchasePrice.Text, out double purchasePrice) || purchasePrice < 0)
                //{
                //    MessageBox.Show("Giá nhập không hợp lệ. Vui lòng nhập số lớn hơn hoặc bằng 0.", "Lỗi");
                //    return;
                //}

                if (!double.TryParse(txtSalePrice.Text, out double salePrice) || salePrice < 0)
                {
                    MessageBox.Show("Giá bán không hợp lệ. Vui lòng nhập số lớn hơn hoặc bằng 0.", "Lỗi");
                    return;
                }

                //if (!int.TryParse(txtStockQuantity.Text, out int stockQuantity) || stockQuantity < 0)
                //{
                //    MessageBox.Show("Số lượng tồn kho không hợp lệ. Vui lòng nhập số lớn hơn hoặc bằng 0.", "Lỗi");
                //    return;
                //}

                // Tạo đối tượng Product
                Product newProduct = new Product
                {
                    Name = productName,

                    SalePrice = salePrice * 1000

                };

                // Thêm sản phẩm vào cơ sở dữ liệu
                if (_productController.AddProduct(newProduct))
                {
                    MessageBox.Show("Thêm sản phẩm thành công!", "Thông báo");
                    ClearForm();
                    LoadProducts(); // Tải lại danh sách sản phẩm
                }
                else
                {
                    MessageBox.Show("Lỗi khi thêm sản phẩm. Vui lòng thử lại.", "Lỗi");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Đã xảy ra lỗi: {ex.Message}", "Lỗi");
            }
        }


        private void UpdateProduct_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (dataGridProducts.SelectedItem is Product selectedProduct)
                {
                    // Kiểm tra tính hợp lệ của các trường nhập liệu
                    if (string.IsNullOrWhiteSpace(txtProductName.Text) ||
                        
                        string.IsNullOrWhiteSpace(txtSalePrice.Text))
                    {
                        MessageBox.Show("Vui lòng điền đầy đủ thông tin sản phẩm.", "Thông báo");
                        return;
                    }

                    // Cập nhật thông tin sản phẩm
                    selectedProduct.Name = txtProductName.Text;
                    
                    selectedProduct.SalePrice = double.Parse(txtSalePrice.Text)*1000;
                    

                    // Gửi cập nhật vào cơ sở dữ liệu
                    if (_productController.UpdateProduct(selectedProduct))
                    {
                        MessageBox.Show("Cập nhật sản phẩm thành công!", "Thông báo");
                        ClearForm();
                        LoadProducts(); // Làm mới danh sách sản phẩm
                    }
                    else
                    {
                        MessageBox.Show("Lỗi khi cập nhật sản phẩm. Vui lòng thử lại.", "Lỗi");
                    }
                }
                else
                {
                    MessageBox.Show("Vui lòng chọn sản phẩm để cập nhật.", "Thông báo");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Đã xảy ra lỗi: {ex.Message}", "Lỗi");
            }
        }


        private void DeleteProduct_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (dataGridProducts.SelectedItem is Product selectedProduct)
                {
                    // Xác nhận trước khi xóa
                    if (MessageBox.Show("Bạn có chắc chắn muốn xóa sản phẩm này?", "Xác nhận", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                    {
                        if (_productController.DeleteProduct(selectedProduct.ProductID))
                        {
                            MessageBox.Show("Xóa sản phẩm thành công!", "Thông báo");
                            ClearForm();
                            LoadProducts(); // Làm mới danh sách sản phẩm
                        }
                        else
                        {
                            MessageBox.Show("Lỗi khi xóa sản phẩm. Vui lòng thử lại.", "Lỗi");
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Vui lòng chọn sản phẩm để xóa.", "Thông báo");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Đã xảy ra lỗi: {ex.Message}", "Lỗi");
            }
        }


        private void DataGridProducts_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dataGridProducts.SelectedItem is Product selectedProduct)
            {
                txtProductName.Text = selectedProduct.Name;
                
                txtSalePrice.Text = ((selectedProduct.SalePrice)/1000).ToString();
                
            }
        }

    }
}
