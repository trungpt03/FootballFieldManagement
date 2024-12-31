using System;
using System.Windows;
using QuanLySanBong.Controllers;

namespace QuanLySanBong.Views
{
    public partial class HoaDon : Window
    {
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public double TotalHours => (EndTime - StartTime).TotalHours;
        public double Discount { get; private set; }
        public double TienSan { get; private set; }
        public double TienDichVu { get; private set; }
        public double TotalPrice { get; private set; }
        public string Note { get; private set; }

        public HoaDon(DateTime startTime, DateTime endTime, int stadiumRentId)
        {
            InitializeComponent();
            LoadProductSales(stadiumRentId);

            StartTime = startTime;
            EndTime = endTime;

            // Hiển thị thông tin ban đầu
            StartTimeText.Text = StartTime.ToString("HH:mm:ss");
            EndTimeText.Text = EndTime.ToString("HH:mm:ss");
            TotalHoursText.Text = TotalHours.ToString("F2") + " giờ";

            // Tính toán tổng tiền ban đầu
            TinhTongTien();
            UpdateConfirmButtonState();
        }

        private void TinhTongTien()
        {
            // Đảm bảo các TextBox không null
            if (TienSanTextBox == null || GiamGiaTextBox == null || TongTienText == null || txtGhiChu == null)
            {
                return;
            }

            // Kiểm tra và xử lý giá trị đầu vào
            if (double.TryParse(TienSanTextBox.Text, out double tienSan) &&
                double.TryParse(GiamGiaTextBox.Text, out double giamGia))
            {
                TienSan = tienSan * 1000;
                double discount = giamGia * 1000;
                Discount = discount;
                TotalPrice = TienSan - discount + TienDichVu;
                TongTienText.Text = TotalPrice.ToString("N0") + " VND";
                Note = txtGhiChu.Text;
            }
            else
            {
                TongTienText.Text = "0 VND";
            }

            // Cập nhật trạng thái của nút Confirm
            UpdateConfirmButtonState();
        }

        private void LoadProductSales(int stadiumRentId)
        {
            var productSaleController = new ProductSaleController("football_booking.db");

            // Lấy danh sách sản phẩm theo StadiumRentID
            var productSales = productSaleController.GetOrderedProductsByBookingId(stadiumRentId);

            // Gán dữ liệu vào DataGrid
            dgDichVu.ItemsSource = productSales;

            // Tính tổng tiền dịch vụ
            double totalServiceFee = 0;
            foreach (var sale in productSales)
            {
                totalServiceFee += sale.TotalPrice;
            }
            TienDichVu = totalServiceFee;
            // Hiển thị tổng tiền dịch vụ
            DichVuText.Text = TienDichVu.ToString("N0") + " VND";
        }

        private void UpdateConfirmButtonState()
        {
            // Nút Confirm chỉ khả dụng khi "Tiền sân" và "Giảm giá" là hợp lệ
            ConfirmButton.IsEnabled =
                double.TryParse(TienSanTextBox.Text, out _) &&
                double.TryParse(GiamGiaTextBox.Text, out _);
        }

        private void ConfirmButton_Click(object sender, RoutedEventArgs e)
        {
            TinhTongTien();
            DialogResult = true;
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }

        private void GiamGiaTextBox_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            TinhTongTien();
        }

        private void TienSanTextBox_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            TinhTongTien();
        }
    }
}
