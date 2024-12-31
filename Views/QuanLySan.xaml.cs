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
    /// Interaction logic for QuanLySan.xaml
    /// </summary>
    public partial class QuanLySan : Window
    {
        private readonly StadiumController _stadiumController;

        public QuanLySan()
        {
            InitializeComponent();
            _stadiumController = new StadiumController("football_booking.db");
            LoadStadiums();
        }

        private void LoadStadiums()
        {
            List<Stadium> stadiums = _stadiumController.GetAllStadiums();
            StadiumDataGrid.ItemsSource = stadiums;
        }

        private void AddStadium_Click(object sender, RoutedEventArgs e)
        {
            string name = NameTextBox.Text;

            if (string.IsNullOrEmpty(name))
            {
                MessageBox.Show("Tên sân không được để trống.");
                return;
            }

            var newStadium = new Stadium
            {
                Name = name,
            };

            if (_stadiumController.AddStadium(newStadium))
            {
                LoadStadiums();
                MessageBox.Show("Thêm sân thành công!");
                ClearInputFields();
            }
            else
            {
                MessageBox.Show("Lỗi khi thêm sân.");
            }
        }


        private void EditStadium_Click(object sender, RoutedEventArgs e)
        {
            if (StadiumDataGrid.SelectedItem is Stadium selectedStadium)
            {
                string name = NameTextBox.Text;

                if (string.IsNullOrEmpty(name))
                {
                    MessageBox.Show("Tên sân không được để trống.");
                    return;
                }

                selectedStadium.Name = name;

                if (_stadiumController.UpdateStadium(selectedStadium))
                {
                    LoadStadiums();
                    MessageBox.Show("Cập nhật sân thành công!");
                    ClearInputFields();
                }
                else
                {
                    MessageBox.Show("Lỗi khi cập nhật sân.");
                }
            }
            else
            {
                MessageBox.Show("Hãy chọn một sân để sửa.");
            }
        }


        private void DeleteStadium_Click(object sender, RoutedEventArgs e)
        {
            if (StadiumDataGrid.SelectedItem is Stadium selectedStadium)
            {
                if (_stadiumController.DeleteStadium(selectedStadium.StadiumID))
                {
                    LoadStadiums();
                    MessageBox.Show("Xóa sân thành công!");
                    ClearInputFields();
                }
                else
                {
                    MessageBox.Show("Lỗi khi xóa sân.");
                }
            }
            else
            {
                MessageBox.Show("Hãy chọn một sân để xóa.");
            }
        }
        private void ClearInputFields()
        {
            NameTextBox.Text = string.Empty;
        }

        private void StadiumDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (StadiumDataGrid.SelectedItem is Stadium selectedStadium)
            {
                // Điền thông tin sân vào các trường nhập liệu
                NameTextBox.Text = selectedStadium.Name;
            }
        }
    }
}
