using QuanLySanBong.Controllers;
using QuanLySanBong.Models;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;

namespace QuanLySanBong.Views
{
    public partial class LichSuThueSan : Window
    {
        private readonly InvoiceController _invoiceController;
        private readonly StadiumController _stadiumController;

        public ObservableCollection<Invoice> RentHistory { get; set; }

        public LichSuThueSan()
        {
            InitializeComponent();

            // Đường dẫn tới cơ sở dữ liệu
            var _dbPath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "football_booking.db");
            _invoiceController = new InvoiceController(_dbPath);
            _stadiumController = new StadiumController(_dbPath);
            // Load the history data
            LoadStadiumsToComboBox();
            LoadHistory();
        }

        private void LoadHistory()
        {
            // Lấy danh sách hóa đơn từ cơ sở dữ liệu
            var invoices = _invoiceController.GetAllInvoices();

            // Lấy danh sách sân để ánh xạ
            var stadiums = _stadiumController.GetAllStadiums();

            // Ánh xạ tên sân
            foreach (var invoice in invoices)
            {
                var stadiumRent = stadiums.FirstOrDefault(s => s.StadiumID == invoice.StadiumID);
                invoice.StadiumName = stadiumRent != null ? stadiumRent.Name : "Không xác định";
            }

            // Tạo ObservableCollection để hiển thị
            var rentHistory = new ObservableCollection<Invoice>(invoices);
            HistoryDataGrid.ItemsSource = rentHistory;

            // Tính toán tổng
            UpdateTotals();
        }



        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void UpdateTotals()
        {
            if (HistoryDataGrid.ItemsSource is ObservableCollection<Invoice> items)
            {
                // Tính toán tổng
                double totalStadiumFee = items.Sum(item => item.StadiumFee);
                double totalServiceFee = items.Sum(item => item.ServiceFee);
                double totalDiscount = items.Sum(item => item.Discount);
                double grandTotal = items.Sum(item => item.TotalPrice);

                // Hiển thị các giá trị tổng trong giao diện
                TotalStadiumFeeText.Text = totalStadiumFee.ToString("N0") + " VND";
                TotalServiceFeeText.Text = totalServiceFee.ToString("N0") + " VND";
                TotalDiscountText.Text = totalDiscount.ToString("N0") + " VND";
                GrandTotalText.Text = grandTotal.ToString("N0") + " VND";
            }
        }

        private void btnBaoCao_Click(object sender, RoutedEventArgs e)
        {
            if (dpBatDau.SelectedDate == null || dpKetThuc.SelectedDate == null)
            {
                MessageBox.Show("Vui lòng chọn đầy đủ ngày bắt đầu và ngày kết thúc.", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            var startDate = dpBatDau.SelectedDate.Value;
            var endDate = dpKetThuc.SelectedDate.Value;

            if (startDate > endDate)
            {
                MessageBox.Show("Ngày bắt đầu không thể lớn hơn ngày kết thúc.", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (cbSan.SelectedValue is int selectedStadiumId)
            {
                // Lấy danh sách hóa đơn từ bộ điều khiển
                var filteredInvoices = _invoiceController.GetInvoicesByDateRange(startDate, endDate, _stadiumController.GetAllStadiums());

                if (selectedStadiumId != -1) // Không phải "Tất cả các sân"
                {
                    // Lọc hóa đơn theo sân được chọn
                    filteredInvoices = filteredInvoices
                        .Where(invoice => invoice.StadiumID == selectedStadiumId)
                        .ToList();
                }

                if (filteredInvoices.Any())
                {
                    // Hiển thị danh sách hóa đơn được lọc
                    HistoryDataGrid.ItemsSource = new ObservableCollection<Invoice>(filteredInvoices);
                    UpdateTotals(); // Tính toán tổng sau khi tải dữ liệu
                }
                else
                {
                    MessageBox.Show("Không tìm thấy hóa đơn trong khoảng thời gian và sân đã chọn.", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
                    HistoryDataGrid.ItemsSource = null;
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một sân hợp lệ.", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }


        private void btnTatCa_Click(object sender, RoutedEventArgs e)
        {
            LoadHistory();
        }

        private void btnXoaTatCa_Click(object sender, RoutedEventArgs e)
        {
            // Hiển thị hộp thoại xác nhận
            var result = MessageBox.Show(
                "Bạn có chắc chắn muốn xóa tất cả các hóa đơn? Hành động này không thể hoàn tác.",
                "Xác nhận xóa",
                MessageBoxButton.YesNo,
                MessageBoxImage.Warning);

            if (result == MessageBoxResult.Yes)
            {
                try
                {
                    // Gọi phương thức xóa tất cả hóa đơn trong InvoiceController
                    _invoiceController.DeleteAllInvoices();

                    // Tải lại danh sách hóa đơn để cập nhật giao diện
                    LoadHistory();

                    MessageBox.Show("Đã xóa tất cả hóa đơn thành công.", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                catch (Exception ex)
                {
                    // Hiển thị lỗi nếu có vấn đề xảy ra
                    MessageBox.Show($"Đã xảy ra lỗi: {ex.Message}", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }


        private void LoadStadiumsToComboBox()
        {
            try
            {
                // Lấy danh sách sân từ StadiumController
                var stadiums = _stadiumController.GetAllStadiums();

                // Thêm tùy chọn "Tất cả các sân"
                var allStadiumOption = new Stadium
                {
                    StadiumID = -1, // ID đặc biệt để biểu thị "Tất cả các sân"
                    Name = "Tất cả các sân"
                };

                // Thêm tùy chọn vào danh sách
                stadiums.Insert(0, allStadiumOption);

                // Gán danh sách sân làm ItemsSource cho ComboBox
                cbSan.ItemsSource = stadiums;

                // Đặt thuộc tính hiển thị tên sân
                cbSan.DisplayMemberPath = "Name";

                // Đặt thuộc tính giá trị cho ComboBox (nếu cần sử dụng ID của sân)
                cbSan.SelectedValuePath = "StadiumID";

                // Đặt giá trị mặc định là "Tất cả các sân"
                cbSan.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Đã xảy ra lỗi khi tải danh sách sân: {ex.Message}", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }


    }
}
