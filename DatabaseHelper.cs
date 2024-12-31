using QuanLySanBong.Models;
using SQLite;
using System;
using System.IO;
using System.Windows;

namespace QuanLySanBong
{
    public class DatabaseHelper
    {
        private SQLiteConnection _connection;
        private string _dbPath;

        public DatabaseHelper()
        {
            string exeDirectory = AppDomain.CurrentDomain.BaseDirectory;
            _dbPath = Path.Combine(exeDirectory, "football_booking.db");
            _connection = new SQLiteConnection(_dbPath);
            InitializeDatabase();
        }

        private void InitializeDatabase()
        {
            try
            {
                // Tạo các bảng
                _connection.CreateTable<StadiumRent>();
                _connection.CreateTable<Booking>();
                _connection.CreateTable<Product>();
                _connection.CreateTable<ProductSale>();
                _connection.CreateTable<Invoice>();

                //MessageBox.Show($"Cơ sở dữ liệu đã được tạo thành công tại: {_dbPath}");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi tạo cơ sở dữ liệu: {ex.Message}");
            }
        }

        public SQLiteConnection GetConnection()
        {
            if (_connection == null)
            {
                _connection = new SQLiteConnection(_dbPath);
            }
            return _connection;
        }

        public void CloseConnection()
        {
            _connection?.Close();
            _connection = null;
        }
    }
}
