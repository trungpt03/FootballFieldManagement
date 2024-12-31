using QuanLySanBong.Models;
using SQLite;
using System;
using System.Collections.Generic;

namespace QuanLySanBong.Controllers
{
    public class ProductController
    {
        private readonly SQLiteConnection _db;

        public ProductController(string dbPath)
        {
            _db = new SQLiteConnection(dbPath);
            _db.CreateTable<Product>();
        }

        public List<Product> GetAllProducts()
        {
            return _db.Table<Product>().ToList();
        }

        public bool AddProduct(Product product)
        {
            try
            {
                _db.Insert(product);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi khi thêm sản phẩm: {ex.Message}");
                return false;
            }
        }

        public Product GetProductById(int productId)
        {
            return _db.Find<Product>(productId);
        }

        public bool UpdateProduct(Product product)
        {
            try
            {
                var existingProduct = _db.Find<Product>(product.ProductID);
                if (existingProduct != null)
                {
                    existingProduct.Name = product.Name;
                    existingProduct.PurchasePrice = product.PurchasePrice;
                    existingProduct.SalePrice = product.SalePrice;
                    existingProduct.StockQuantity = product.StockQuantity;
                    _db.Update(existingProduct);
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi khi cập nhật sản phẩm: {ex.Message}");
                return false;
            }
        }

        public bool DeleteProduct(int productId)
        {
            try
            {
                var product = _db.Find<Product>(productId);
                if (product != null)
                {
                    _db.Delete(product);
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
    }
}
