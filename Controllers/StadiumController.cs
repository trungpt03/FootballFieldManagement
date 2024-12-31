using System.Collections.Generic;
using QuanLySanBong.Models;
using SQLite;

namespace QuanLySanBong.Controllers
{
    public class StadiumController
    {
        private readonly SQLiteConnection _db;

        public StadiumController(string dbPath)
        {
            _db = new SQLiteConnection(dbPath);
            _db.CreateTable<Stadium>(); // Ensure table exists
        }

        public List<Stadium> GetAllStadiums()
        {
            return _db.Table<Stadium>().ToList();
        }

        public bool AddStadium(Stadium stadium)
        {
            try
            {
                _db.Insert(stadium);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool UpdateStadium(Stadium stadium)
        {
            try
            {
                _db.Update(stadium);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi khi cập nhật trạng thái sân: {ex.Message}");
                return false;
            }
        }


        public bool DeleteStadium(int stadiumId)
        {
            try
            {
                var stadium = _db.Find<Stadium>(stadiumId);
                if (stadium != null)
                {
                    _db.Delete(stadium);
                    return true;
                }
                return false;
            }
            catch
            {
                return false;
            }
        }
    }
}
