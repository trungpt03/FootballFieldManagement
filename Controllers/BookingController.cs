using QuanLySanBong.Models;
using SQLite;
using System;
using System.Collections.Generic;

namespace QuanLySanBong.Controllers
{
    public class BookingController
    {
        private readonly SQLiteConnection _db;

        public BookingController(string dbPath)
        {
            _db = new SQLiteConnection(dbPath);
            _db.CreateTable<Booking>();
        }

        public List<Booking> GetAllBookings()
        {
            return _db.Table<Booking>().ToList();
        }

        public bool AddBooking(Booking booking)
        {
            try
            {
                _db.Insert(booking);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi khi thêm đặt sân: {ex.Message}");
                return false;
            }
        }

        public Booking GetBookingById(int bookingId)
        {
            return _db.Find<Booking>(bookingId);
        }

        public bool UpdateBooking(Booking booking)
        {
            try
            {
                var existingBooking = _db.Find<Booking>(booking.BookingID);
                if (existingBooking != null)
                {
                    existingBooking.StadiumID = booking.StadiumID;
                    existingBooking.CustomerName = booking.CustomerName;
                    existingBooking.PhoneNumber = booking.PhoneNumber;
                    existingBooking.StartTime = booking.StartTime;
                    existingBooking.EndTime = booking.EndTime;
                    existingBooking.IsMatch = booking.IsMatch;
                    _db.Update(existingBooking);
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi khi cập nhật đặt sân: {ex.Message}");
                return false;
            }
        }

        public bool DeleteBooking(int bookingId)
        {
            try
            {
                var booking = _db.Find<Booking>(bookingId);
                if (booking != null)
                {
                    _db.Delete(booking);
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi khi xóa đặt sân: {ex.Message}");
                return false;
            }
        }

        public List<Booking> GetBookingsByStadiumId(int stadiumId)
        {
            return _db.Table<Booking>().Where(b => b.StadiumID == stadiumId).ToList();
        }


    }
}
