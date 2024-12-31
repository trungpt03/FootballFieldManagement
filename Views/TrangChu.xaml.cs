using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using QuanLySanBong.Controllers;
using QuanLySanBong.Models;

namespace QuanLySanBong.Views
{
    public partial class TrangChu : Window
    {
        private readonly StadiumController _stadiumController;
        private readonly string _dbPath;

        public TrangChu()
        {
            InitializeComponent();

            // Đường dẫn tới cơ sở dữ liệu
            _dbPath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "football_booking.db");
            _stadiumController = new StadiumController(_dbPath);

            // Tải danh sách sân
            LoadStadiumSlots();
        }

        /// <summary>
        /// Tải danh sách sân từ cơ sở dữ liệu và hiển thị
        /// </summary>
        private void LoadStadiumSlots()
        {
            try
            {
                var stadiums = _stadiumController.GetAllStadiums();
                FieldRowsControl.ItemsSource = stadiums;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải danh sách sân: {ex.Message}", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void OpenStadium_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (sender is MenuItem menuItem && menuItem.DataContext is Stadium stadium)
                {
                    var rentController = new StadiumRentController(_dbPath);

                    // Lưu thông tin mở sân
                    var rent = new StadiumRent
                    {
                        Name = stadium.Name,
                        StartTime = DateTime.Now,
                    };
                    rentController.AddStadiumRent(rent);

                    // Cập nhật trạng thái sân
                    stadium.Status = true; // Trạng thái sân: đang sử dụng
                    _stadiumController.UpdateStadium(stadium);

                    MessageBox.Show($"Sân {stadium.Name} đã được mở vào lúc {rent.StartTime}!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
                    LoadStadiumSlots();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi mở sân: {ex.Message}", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void CloseStadium_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (sender is MenuItem menuItem && menuItem.DataContext is Stadium stadium)
                {
                    var rentController = new StadiumRentController(_dbPath);
                    var invoiceController = new InvoiceController(_dbPath);
                    var productSaleController = new ProductSaleController(_dbPath);

                    // Lấy thông tin thuê sân
                    var rent = rentController.GetAllStadiumRents()
                                             ?.LastOrDefault(r => r.Name == stadium.Name);

                    if (rent == null)
                    {
                        MessageBox.Show("Không tìm thấy thông tin thuê sân.", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                        // Cập nhật trạng thái sân
                        stadium.Status = false;
                        return;
                    }

                    rent.EndTime = DateTime.Now;

                    // Hiển thị giao diện nhập thông tin hóa đơn
                    var hoaDonWindow = new HoaDon(rent.StartTime, rent.EndTime, stadium.StadiumID);
                    if (hoaDonWindow.ShowDialog() == true)
                    {
                        rent.TotalPrice = hoaDonWindow.TotalPrice;

                        // Cập nhật trạng thái sân
                        stadium.Status = false;

                        // Lưu thông tin thuê sân và hóa đơn
                        rentController.UpdateStadiumRent(rent);
                        invoiceController.AddInvoice(new Invoice
                        {
                            StadiumRentID = rent.StadiumRentID,
                            StadiumID = stadium.StadiumID,
                            InvoiceDate = DateTime.Now,
                            StartTime = rent.StartTime,
                            EndTime = rent.EndTime,
                            TotalTime = hoaDonWindow.TotalHours,
                            StadiumFee = hoaDonWindow.TienSan,
                            ServiceFee = hoaDonWindow.TienDichVu,
                            Discount = hoaDonWindow.Discount,
                            TotalPrice = hoaDonWindow.TotalPrice,
                            Note = hoaDonWindow.Note,
                        });

                        // Đặt lại danh sách sản phẩm đã gọi
                        productSaleController.DeleteProductSalesByStadiumId(stadium.StadiumID);

                        // Cập nhật trạng thái sân
                        _stadiumController.UpdateStadium(stadium);

                        // Làm mới danh sách sân
                        LoadStadiumSlots();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi đóng sân: {ex.Message}", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnDatSan_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                LichDatSan lds = new LichDatSan();
                lds.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi mở giao diện đặt sân: {ex.Message}", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnHangHoa_Click(object sender, RoutedEventArgs e)
        {
            QuanLyProduct qlp = new QuanLyProduct();
            qlp.Show();
        }

        private void DichVu_Click(object sender, RoutedEventArgs e)
        {
            if (sender is MenuItem menuItem && menuItem.Tag is int bookingId)
            {
                DichVu dv = new DichVu(bookingId);
                dv.ShowDialog();
            }
            else
            {
                MessageBox.Show("Invalid booking ID.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnLichSuThueSan_Click(object sender, RoutedEventArgs e)
        {
            LichSuThueSan lsts = new LichSuThueSan();
            lsts.Show();
        }

        private void btnCaiDatSan_Click(object sender, RoutedEventArgs e)
        {
            QuanLySan qls = new QuanLySan();
            qls.Show();
        }

        private void btnRefreshKhuVucSan_Click(object sender, RoutedEventArgs e)
        {
            LoadStadiumSlots();
        }
    }
}
