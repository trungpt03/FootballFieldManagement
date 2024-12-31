using QuanLySanBong.Models;
using SQLite;
using System;
using System.Collections.Generic;

namespace QuanLySanBong.Controllers
{
    public class InvoiceController
    {
        private readonly SQLiteConnection _db;

        public InvoiceController(string dbPath)
        {
            _db = new SQLiteConnection(dbPath);
            _db.CreateTable<Invoice>();
        }

        public List<Invoice> GetAllInvoices()
        {
            return _db.Table<Invoice>()
              .OrderByDescending(i => i.InvoiceDate)
              .ToList();
        }

        public bool AddInvoice(Invoice invoice)
        {
            try
            {
                _db.Insert(invoice);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi khi thêm hóa đơn: {ex.Message}");
                return false;
            }
        }


        public Invoice GetInvoiceById(int invoiceId)
        {
            return _db.Find<Invoice>(invoiceId);
        }

        public bool UpdateInvoice(Invoice invoice)
        {
            try
            {
                var existingInvoice = _db.Find<Invoice>(invoice.InvoiceID);
                if (existingInvoice != null)
                {
                    existingInvoice.StadiumRentID = invoice.StadiumRentID;
                    existingInvoice.StadiumID = invoice.StadiumID;
                    existingInvoice.InvoiceDate = invoice.InvoiceDate;
                    existingInvoice.StadiumFee = invoice.StadiumFee;
                    existingInvoice.ServiceFee = invoice.ServiceFee;
                    existingInvoice.StartTime = invoice.StartTime;
                    existingInvoice.TotalTime = invoice.TotalTime;
                    existingInvoice.EndTime = invoice.EndTime;
                    existingInvoice.TotalPrice = invoice.TotalPrice;
                    existingInvoice.Discount = invoice.Discount;
                    existingInvoice.Note = invoice.Note;
                    _db.Update(existingInvoice);
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi khi cập nhật hóa đơn: {ex.Message}");
                return false;
            }
        }

        public bool DeleteInvoice(int invoiceId)
        {
            try
            {
                var invoice = _db.Find<Invoice>(invoiceId);
                if (invoice != null)
                {
                    _db.Delete(invoice);
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi khi xóa hóa đơn: {ex.Message}");
                return false;
            }
        }

        public List<Invoice> GetInvoicesByDateRange(DateTime startDate, DateTime endDate, List<Stadium> stadiums)
        {
            try
            {
                // Tạo khoảng thời gian từ đầu ngày bắt đầu đến cuối ngày kết thúc
                DateTime startDateTime = startDate.Date;
                DateTime endDateTime = endDate.Date.AddDays(1).AddTicks(-1);

                // Lọc hóa đơn trong khoảng thời gian
                var invoices = _db.Table<Invoice>()
                                  .Where(i => i.InvoiceDate >= startDateTime && i.InvoiceDate <= endDateTime)
                                  .OrderByDescending(i => i.InvoiceDate)
                                  .ToList();

                // Ánh xạ tên sân
                foreach (var invoice in invoices)
                {
                    var stadiumRent = stadiums.FirstOrDefault(s => s.StadiumID == invoice.StadiumID);
                    invoice.StadiumName = stadiumRent != null ? stadiumRent.Name : "Không xác định";
                }

                return invoices;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi khi lấy hóa đơn theo khoảng ngày: {ex.Message}");
                return new List<Invoice>();
            }
        }

        public void DeleteAllInvoices()
        {
            try
            {
                // Xóa tất cả hóa đơn từ bảng Invoice
                _db.Execute("DELETE FROM Invoice");

                // Log thông báo thành công
                Console.WriteLine("Tất cả hóa đơn đã được xóa thành công.");
            }
            catch (Exception ex)
            {
                // Ghi nhật ký lỗi nếu có vấn đề xảy ra
                Console.WriteLine($"Lỗi khi xóa tất cả hóa đơn: {ex.Message}");
                throw; // Ném lỗi ra để lớp gọi có thể xử lý nếu cần
            }
        }


    }
}
