using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using QuanLySanBong.Controllers;
using QuanLySanBong.Models;
using QuanLySanBong.Views;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace QuanLySanBong
{
    public partial class LichDatSan : Window
    {
        private BookingController _bookingController;
        private StadiumController _stadiumController;
        private List<Grid> FieldRows = new List<Grid>();
        public List<string> TimeSlots { get; set; } = new List<string>();

        public LichDatSan()
        {
            InitializeComponent();
            DataContext = this;

            string dbPath = new DatabaseHelper().GetConnection().DatabasePath;
            _bookingController = new BookingController(dbPath);
            _stadiumController = new StadiumController(dbPath);


            dp.SelectedDate = DateTime.Today;
            LoadTimeSlots();
            LoadStadiums();
            InitializeTimeTable();

            StartTimeComboBox.SelectionChanged += StartTimeComboBox_SelectionChanged;
        }

        private void LoadTimeSlots()
        {
            for (int hour = 2; hour < 24; hour++)
            {
                TimeSlots.Add($"{hour:00}:00");
                TimeSlots.Add($"{hour:00}:15");
                TimeSlots.Add($"{hour:00}:30");
                TimeSlots.Add($"{hour:00}:45");
            }

            StartTimeComboBox.ItemsSource = TimeSlots;
            EndTimeComboBox.ItemsSource = TimeSlots;
        }

        private void LoadStadiums()
        {
            var stadiums = _stadiumController.GetAllStadiums();
            FieldComboBox.ItemsSource = stadiums;
            FieldComboBox.DisplayMemberPath = "Name";
            FieldComboBox.SelectedValuePath = "StadiumID";
        }

        private void InitializeTimeTable()
        {
            FieldRows.Clear();
            FieldRowsControl.Items.Clear();

            var stadiums = _stadiumController.GetAllStadiums();
            var bookings = _bookingController.GetAllBookings();

            foreach (var stadium in stadiums)
            {
                var stadiumBookings = bookings
                    .Where(b => b.StadiumID == stadium.StadiumID && b.Date == DateTime.Parse(dp.Text))
                    .OrderBy(b => b.StartTime)
                    .ToList();

                var row = new Grid
                {
                    Margin = new Thickness(10),
                };
                row.RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto });
                row.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(150) });

                var fieldText = new Border
                {
                    Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#C8E6C9")),
                    BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#A5D6A7")),
                    BorderThickness = new Thickness(1),
                    CornerRadius = new CornerRadius(5),
                    Child = new TextBlock
                    {
                        Text = stadium.Name,
                        Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#2E7D32")),
                        FontSize = 18,
                        FontWeight = FontWeights.Bold,
                        TextAlignment = TextAlignment.Center,
                        VerticalAlignment = VerticalAlignment.Center,
                        HorizontalAlignment = HorizontalAlignment.Center
                    }
                };
                Grid.SetColumn(fieldText, 0);
                row.Children.Add(fieldText);

                int columnIndex = 1;
                foreach (var booking in stadiumBookings)
                {
                    row.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(200) });

                    var backgroundColor = booking.IsMatch
                        ? "#81C784" // Xanh nhạt nếu IsMatch = true
                        : "#FFCDD2"; // Đỏ nhạt nếu IsMatch = false

                    var slot = new Border
                    {
                        Width = 140,
                        Padding = new Thickness(10),
                        Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString(backgroundColor)),
                        BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#BDBDBD")),
                        BorderThickness = new Thickness(1),
                        Margin = new Thickness(5),
                        CornerRadius = new CornerRadius(8), // Bo góc với bán kính 8
                        Child = new StackPanel
                        {
                            VerticalAlignment = VerticalAlignment.Center,
                            HorizontalAlignment = HorizontalAlignment.Center,
                            Children =
                    {
                        new Border
                        {
                            Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFF9C4")),
                            CornerRadius = new CornerRadius(5),
                            Padding = new Thickness(6),
                            Child = new TextBlock
                            {
                                Text = $"{booking.StartTime:HH:mm} - {booking.EndTime:HH:mm}",
                                Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#212121")),
                                FontSize = 16,
                                FontWeight = FontWeights.Bold,
                                TextAlignment = TextAlignment.Center
                            }
                        },
                        new Border
                        {
                            Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#E3F2FD")),
                            CornerRadius = new CornerRadius(5),
                            Padding = new Thickness(4),
                            Margin = new Thickness(3, 8, 3, 0),
                            Child = new TextBlock
                            {
                                Text = $"{booking.CustomerName}\n{booking.PhoneNumber}",
                                Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#1565C0")),
                                FontSize = 14,
                                FontWeight = FontWeights.Medium,
                                TextAlignment = TextAlignment.Center
                            }
                        }
                    }
                        },
                        Tag = booking
                    };

                    // Xử lý chuột phải
                    slot.MouseRightButtonDown += (s, e) => ShowContextMenu(s, booking);

                    Grid.SetColumn(slot, columnIndex++);
                    row.Children.Add(slot);
                }

                FieldRows.Add(row);
                FieldRowsControl.Items.Add(row);
            }
        }

        private void ShowContextMenu(object sender, Booking booking)
        {
            var contextMenu = new ContextMenu();

            // Tùy chọn xóa
            var deleteMenuItem = new MenuItem { Header = "Xóa" };
            deleteMenuItem.Click += (s, e) =>
            {
                var result = MessageBox.Show($"Bạn có chắc chắn muốn xóa lịch đặt của {booking.CustomerName} không?", "Xác nhận xóa", MessageBoxButton.YesNo, MessageBoxImage.Warning);

                if (result == MessageBoxResult.Yes)
                {
                    if (_bookingController.DeleteBooking(booking.BookingID))
                    {
                        MessageBox.Show("Xóa lịch đặt thành công!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
                        RefreshTimeTable();
                    }
                    else
                    {
                        MessageBox.Show("Có lỗi xảy ra khi xóa lịch đặt.", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            };

            // Tùy chọn thay đổi IsMatch
            var toggleMatchMenuItem = new MenuItem { Header = "Thay đổi trạng thái đã có đối ?" };
            toggleMatchMenuItem.Click += (s, e) =>
            {
                booking.IsMatch = !booking.IsMatch;
                if (_bookingController.UpdateBooking(booking))
                {
                    MessageBox.Show("Cập nhật trạng thái thành công!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
                    RefreshTimeTable();
                }
                else
                {
                    MessageBox.Show("Có lỗi xảy ra khi cập nhật trạng thái.", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            };

            // Thêm các mục vào menu
            contextMenu.Items.Add(deleteMenuItem);
            contextMenu.Items.Add(toggleMatchMenuItem);

            // Hiển thị menu
            if (sender is FrameworkElement fe)
            {
                contextMenu.IsOpen = true;
                contextMenu.PlacementTarget = fe;
            }
        }

        private void StartTimeComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (StartTimeComboBox.SelectedItem is string startTimeStr && TimeSpan.TryParse(startTimeStr, out var startTime))
            {
                var endTime = startTime.Add(new TimeSpan(0, 90, 0));
                EndTimeComboBox.SelectedItem = TimeSlots.FirstOrDefault(t => TimeSpan.TryParse(t, out var time) && time == endTime);
            }
        }

        private void BookFieldButton_Click(object sender, RoutedEventArgs e)
        {
            string name = NameTextBox.Text;
            string phone = PhoneTextBox.Text;
            if (string.IsNullOrEmpty(name))
            {
                MessageBox.Show("Vui lòng nhập tên khách.");
                return;
            }
            if (!int.TryParse(FieldComboBox.SelectedValue?.ToString(), out var selectedStadiumId))
            {
                MessageBox.Show("Vui lòng chọn sân hợp lệ.");
                return;
            }

            if (!TimeSpan.TryParse(StartTimeComboBox.SelectedItem as string, out var startTime))
            {
                MessageBox.Show("Vui lòng chọn giờ vào hợp lệ.");
                return;
            }

            if (!TimeSpan.TryParse(EndTimeComboBox.SelectedItem as string, out var endTime))
            {
                MessageBox.Show("Vui lòng chọn giờ ra hợp lệ.");
                return;
            }

            // Kiểm tra giờ ra phải lớn hơn giờ vào
            if (endTime <= startTime)
            {
                MessageBox.Show("Giờ ra phải lớn hơn giờ vào.");
                return;
            }

            var date = DateTime.Parse(dp.Text);
            if (!IsTimeSlotAvailable(selectedStadiumId, startTime, endTime, date))
            {
                MessageBox.Show("Khoảng thời gian này đã đặt trước.");
                return;
            }

            var newBooking = new Booking
            {
                CustomerName = name,
                PhoneNumber = phone,
                StadiumID = selectedStadiumId,
                StartTime = date.Add(startTime),
                EndTime = date.Add(endTime),
                Date = date,
                IsMatch = cbIsMatch.IsChecked ?? false
            };

            if (_bookingController.AddBooking(newBooking))
            {
                RefreshTimeTable();
                NameTextBox.Text = "";
                PhoneTextBox.Text = "";
                FieldComboBox.SelectedIndex = 0;
                StartTimeComboBox.SelectedIndex = 0;
                EndTimeComboBox.SelectedIndex = 0;
                MessageBox.Show("Đặt sân thành công!");
            }
            else
            {
                MessageBox.Show("Có lỗi xảy ra khi đặt sân.");
            }
        }

        private bool IsTimeSlotAvailable(int stadiumId, TimeSpan startTime, TimeSpan endTime, DateTime date)
        {
            var bookings = _bookingController.GetAllBookings();
            foreach (var booking in bookings)
            {
                if (booking.StadiumID == stadiumId && booking.Date == date &&
                    !(booking.EndTime.TimeOfDay <= startTime || booking.StartTime.TimeOfDay >= endTime))
                {
                    return false;
                }
            }
            return true;
        }

        private void RefreshTimeTable()
        {
            InitializeTimeTable();
        }

        private void dp_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dp.SelectedDate.HasValue)
            {
                DateTime selectedDate = dp.SelectedDate.Value;
                string formattedDate = selectedDate.ToString("dddd, 'ngày' dd 'tháng' MM 'năm' yyyy",
                                    new System.Globalization.CultureInfo("vi-VN"));

                DateTextBlock.Text = formattedDate;
            }
            else
            {
                DateTextBlock.Text = "Không có ngày nào được chọn.";
            }
            InitializeTimeTable();
        }

        private void btnSau_Click(object sender, RoutedEventArgs e)
        {
            // Kiểm tra xem ngày đã được chọn hay chưa
            if (dp.SelectedDate.HasValue)
            {
                // Lấy ngày đã chọn
                DateTime date = dp.SelectedDate.Value;

                // Lùi lại 1 ngày
                date = date.AddDays(1);

                // Cập nhật lại DatePicker với ngày mới
                dp.SelectedDate = date;
            }
            else
            {
                // Thông báo nếu không có ngày nào được chọn
                MessageBox.Show("Vui lòng chọn một ngày trước!");
            }
        }

        private void btnTruoc_Click(object sender, RoutedEventArgs e)
        {
            // Kiểm tra xem ngày đã được chọn hay chưa
            if (dp.SelectedDate.HasValue)
            {
                // Lấy ngày đã chọn
                DateTime date = dp.SelectedDate.Value;

                // Lùi lại 1 ngày
                date = date.AddDays(-1);

                // Cập nhật lại DatePicker với ngày mới
                dp.SelectedDate = date;
            }
            else
            {
                // Thông báo nếu không có ngày nào được chọn
                MessageBox.Show("Vui lòng chọn một ngày trước!");
            }
        }

        private void btnHomNay_Click(object sender, RoutedEventArgs e)
        {
            DateTime date = DateTime.Today;
            dp.SelectedDate = date;
        }

        private void btnDatSanCoDinh_Click(object sender, RoutedEventArgs e)
        {
            DatSanCoDinh dscd = new DatSanCoDinh();
            dscd.Show();
        }
    }
}
