using QuanLySanBong.Models;
using SQLite;
using System;
using System.Collections.Generic;

namespace QuanLySanBong.Controllers
{
    public class ProductSaleController
    {
        private readonly SQLiteConnection _db;

        public ProductSaleController(string dbPath)
        {
            _db = new SQLiteConnection(dbPath);
            _db.CreateTable<ProductSale>();
        }

        public List<ProductSale> GetAllSales()
        {
            return _db.Table<ProductSale>().ToList();
        }

        public List<ProductSale> GetProductSalesByStadiumId(int stadiumId)
        {
            // Lấy danh sách BookingID liên quan đến StadiumID
            var bookingIds = _db.Table<Booking>().Where(b => b.StadiumID == stadiumId).Select(b => b.BookingID).ToList();

            // Lấy danh sách ProductSale liên quan đến các BookingID
            return _db.Table<ProductSale>().Where(ps => bookingIds.Contains(ps.StadiumRentID)).ToList();
        }

        public bool AddSale(ProductSale sale)
        {
            try
            {
                _db.Insert(sale);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi khi thêm thông tin bán hàng: {ex.Message}");
                return false;
            }
        }

        public ProductSale GetSaleById(int saleId)
        {
            return _db.Find<ProductSale>(saleId);
        }

        public bool UpdateSale(ProductSale sale)
        {
            try
            {
                var existingSale = _db.Find<ProductSale>(sale.SaleID);
                if (existingSale != null)
                {
                    existingSale.ProductID = sale.ProductID;
                    existingSale.StadiumRentID = sale.StadiumRentID;
                    existingSale.Quantity = sale.Quantity;
                    existingSale.TotalPrice = sale.TotalPrice;
                    existingSale.SaleDate = sale.SaleDate;
                    _db.Update(existingSale);
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi khi cập nhật thông tin bán hàng: {ex.Message}");
                return false;
            }
        }

        public bool DeleteSale(int saleId)
        {
            try
            {
                var sale = _db.Find<ProductSale>(saleId);
                if (sale != null)
                {
                    _db.Delete(sale);
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi khi xóa sản phẩm: {ex.Message}");
                return false;
            }
        }


        public bool DeleteProductSalesByStadiumId(int stadiumRentId)
        {
            try
            {
                var salesToDelete = _db.Table<ProductSale>().Where(ps => ps.StadiumRentID == stadiumRentId).ToList();
                foreach (var sale in salesToDelete)
                {
                    _db.Delete(sale);
                }
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi khi xóa danh sách sản phẩm đã gọi: {ex.Message}");
                return false;
            }
        }


        public List<ProductSale> GetOrderedProductsByBookingId(int bookingId)
        {
            // Lấy danh sách sản phẩm đã order dựa trên BookingID
            var sales = _db.Table<ProductSale>().Where(ps => ps.StadiumRentID == bookingId).ToList();

            // Tải toàn bộ danh sách sản phẩm vào từ điển để tra cứu nhanh
            var products = _db.Table<Product>().ToDictionary(p => p.ProductID);

            // Gán ProductName cho mỗi bản ghi trong ProductSale
            foreach (var sale in sales)
            {
                if (products.TryGetValue(sale.ProductID, out var product))
                {
                    sale.ProductName = product.Name; // Lấy tên sản phẩm
                }
                else
                {
                    sale.ProductName = "N/A"; // Không tìm thấy sản phẩm
                }
            }

            return sales;
        }



    }
}
