using QuanLySanBong.Models;
using SQLite;
using System;
using System.Collections.Generic;

namespace QuanLySanBong.Controllers
{
    public class StadiumRentController
    {
        private readonly SQLiteConnection _db;

        public StadiumRentController(string dbPath)
        {
            _db = new SQLiteConnection(dbPath);
            _db.CreateTable<StadiumRent>(); // Đảm bảo bảng đã được tạo
        }

        // Lấy danh sách tất cả sân
        public List<StadiumRent> GetAllStadiumRents()
        {
            return _db.Table<StadiumRent>().ToList();
        }

        // Thêm một sân mới
        public bool AddStadiumRent(StadiumRent stadium)
        {
            try
            {
                _db.Insert(stadium);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi khi thêm thue sân: {ex.Message}");
                return false;
            }
        }

        // Lấy thông tin sân theo ID
        public StadiumRent GetStadiumRentById(int stadiumId)
        {
            return _db.Find<StadiumRent>(stadiumId);
        }

        // Cập nhật thông tin sân
        public bool UpdateStadiumRent(StadiumRent stadium)
        {
            try
            {
                var existingStadium = _db.Find<StadiumRent>(stadium.StadiumRentID);
                if (existingStadium != null)
                {
                    existingStadium.Name = stadium.Name;
                    existingStadium.StartTime = stadium.StartTime;
                    existingStadium.EndTime = stadium.EndTime;
                    _db.Update(existingStadium);
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi khi cập nhật thuê sân: {ex.Message}");
                return false;
            }
        }

        // Xóa sân theo ID
        public bool DeleteStadiumRent(int stadiumId)
        {
            try
            {
                var stadium = _db.Find<StadiumRent>(stadiumId);
                if (stadium != null)
                {
                    _db.Delete(stadium);
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi khi xóa thuê sân: {ex.Message}");
                return false;
            }
        }

        // Retrieve all stadium rentals ordered by EndTime (descending)
        public List<StadiumRent> GetRentalHistory()
        {
            try
            {
                return _db.Table<StadiumRent>()
                          .OrderByDescending(r => r.EndTime)
                          .ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error retrieving rental history: {ex.Message}");
                return new List<StadiumRent>();
            }
        }


        

    }
}
