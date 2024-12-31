using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using QuanLySanBong.Models;
using QuanLySanBong.Controllers;

namespace QuanLySanBong.Views
{
    public partial class DatSanCoDinh : Window
    {
        LichDatSan lds = new LichDatSan();
        StadiumController _stadiumController;
        BookingController _bookingController;

        public DatSanCoDinh()
        {
            InitializeComponent();

            string dbPath = new DatabaseHelper().GetConnection().DatabasePath;
            _bookingController = new BookingController(dbPath);
            _stadiumController = new StadiumController(dbPath);

            LoadData();
        }

        private void LoadData()
        {
            cbSan.ItemsSource = _stadiumController.GetAllStadiums();
            cbGioBatDau.ItemsSource = lds.TimeSlots;
            cbGioKetThuc.ItemsSource = lds.TimeSlots;
        }

        private void btnDatSan_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (dpBatDau.SelectedDate == null)
                {
                    MessageBox.Show("Vui lòng chọn ngày bắt đầu.", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                if (dpKetThuc.SelectedDate == null)
                {
                    MessageBox.Show("Vui lòng chọn ngày kết thúc.", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                DateTime startDate = dpBatDau.SelectedDate.Value;
                DateTime endDate = dpKetThuc.SelectedDate.Value;

                if (startDate > endDate)
                {
                    MessageBox.Show("Ngày bắt đầu không được lớn hơn ngày kết thúc.", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                if (cbSan.SelectedValue == null)
                {
                    MessageBox.Show("Vui lòng chọn sân.", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                int selectedStadiumId = int.Parse(cbSan.SelectedValue.ToString());

                if (cbThu.SelectedItem == null)
                {
                    MessageBox.Show("Vui lòng chọn ít nhất một thứ trong tuần.", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                var selectedDays = new List<DayOfWeek>();
                if (cbThu.SelectedItem is ComboBoxItem selectedItem)
                {
                    string dayString = selectedItem.Content.ToString();
                    switch (dayString)
                    {
                        case "Thứ hai": selectedDays.Add(DayOfWeek.Monday); break;
                        case "Thứ ba": selectedDays.Add(DayOfWeek.Tuesday); break;
                        case "Thứ tư": selectedDays.Add(DayOfWeek.Wednesday); break;
                        case "Thứ năm": selectedDays.Add(DayOfWeek.Thursday); break;
                        case "Thứ sáu": selectedDays.Add(DayOfWeek.Friday); break;
                        case "Thứ bảy": selectedDays.Add(DayOfWeek.Saturday); break;
                        case "Chủ nhật": selectedDays.Add(DayOfWeek.Sunday); break;
                    }
                }

                if (cbGioBatDau.SelectedItem == null)
                {
                    MessageBox.Show("Vui lòng chọn giờ bắt đầu.", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                if (cbGioKetThuc.SelectedItem == null)
                {
                    MessageBox.Show("Vui lòng chọn giờ kết thúc.", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                TimeSpan startTime = TimeSpan.Parse(cbGioBatDau.SelectedItem.ToString());
                TimeSpan endTime = TimeSpan.Parse(cbGioKetThuc.SelectedItem.ToString());

                if (startTime >= endTime)
                {
                    MessageBox.Show("Giờ bắt đầu phải nhỏ hơn giờ kết thúc.", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtTenKhachHang.Text))
                {
                    MessageBox.Show("Vui lòng nhập tên khách hàng.", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                string customerName = txtTenKhachHang.Text;
                string phoneNumber = txtSoDienThoai.Text;

                if (!string.IsNullOrWhiteSpace(phoneNumber))
                {
                    if (!System.Text.RegularExpressions.Regex.IsMatch(phoneNumber, @"^0\d{9}$"))
                    {
                        MessageBox.Show("Số điện thoại không hợp lệ. Vui lòng nhập số điện thoại 10 chữ số bắt đầu bằng 0.", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Warning);
                        return;
                    }
                }

                bool isMatch = cbIsMatch.IsChecked ?? false;

                var bookings = new List<Booking>();
                var conflictingDates = new List<string>();

                for (var date = startDate; date <= endDate; date = date.AddDays(1))
                {
                    if (selectedDays.Contains(date.DayOfWeek))
                    {
                        var existingBookings = _bookingController.GetBookingsByStadiumId(selectedStadiumId)
                            .Where(b => b.Date == date &&
                                        ((b.StartTime.TimeOfDay < endTime && b.EndTime.TimeOfDay > startTime)))
                            .ToList();

                        if (existingBookings.Any())
                        {
                            conflictingDates.Add(date.ToString("dd/MM/yyyy"));
                            continue;
                        }

                        bookings.Add(new Booking
                        {
                            StadiumID = selectedStadiumId,
                            CustomerName = customerName,
                            PhoneNumber = phoneNumber,
                            StartTime = date.Add(startTime),
                            EndTime = date.Add(endTime),
                            Date = date,
                            IsMatch = isMatch
                        });
                    }
                }

                if (conflictingDates.Count > 0)
                {
                    string message = "Các ngày sau đã bị trùng lịch:\n" + string.Join("\n", conflictingDates);
                    MessageBox.Show(message, "Cảnh báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                foreach (var booking in bookings)
                {
                    if (!_bookingController.AddBooking(booking))
                    {
                        MessageBox.Show($"Lỗi khi lưu lịch đặt vào ngày {booking.Date:dd/MM/yyyy}.", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
                        return;
                    }
                }

                MessageBox.Show("Đặt sân cố định thành công!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnHuy_Click(object sender, RoutedEventArgs e)
        {
            // Đóng cửa sổ khi nhấn nút Hủy
            this.Close();
        }

        private void cbGioBatDau_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cbGioBatDau.SelectedItem is string startTimeStr && TimeSpan.TryParse(startTimeStr, out var startTime))
            {
                var endTime = startTime.Add(new TimeSpan(0, 90, 0));
                cbGioKetThuc.SelectedItem = lds.TimeSlots.FirstOrDefault(t => TimeSpan.TryParse(t, out var time) && time == endTime);
            }
        }
    }
}
