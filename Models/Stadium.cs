using System.Windows;
using SQLite;

namespace QuanLySanBong.Models
{
    public class Stadium
    {
        [PrimaryKey, AutoIncrement]
        public int StadiumID { get; set; }
        public string Name { get; set; }
        public bool Status { get; set; } // true: Đang sử dụng, false: Trống

        // Màu nền dựa trên trạng thái sân
        public string BackgroundColor => Status ? "#FF5252" : "#66BB6A"; // Đỏ nếu đang sử dụng, xanh nếu trống

        // Hiển thị menu "Mở sân" khi trống
        public Visibility OpenMenuVisibility => Status ? Visibility.Collapsed : Visibility.Visible;

        // Hiển thị menu "Đóng sân" và "Dịch vụ" khi đang sử dụng
        public Visibility CloseMenuVisibility => Status ? Visibility.Visible : Visibility.Collapsed;
    }
}
