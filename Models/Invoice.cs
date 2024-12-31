using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace QuanLySanBong.Models
{
    public class Invoice
    {
        [PrimaryKey, AutoIncrement]
        public int InvoiceID { get; set; }
        public int StadiumRentID { get; set; }
        public int StadiumID { get; set; }
        public DateTime InvoiceDate { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public double TotalTime { get; set; }
        public double StadiumFee { get; set; }
        public double ServiceFee { get; set; }
        public double TotalPrice { get; set; }
        public double Discount { get; set; }
        public string Note { get; set; }
        [Ignore]
        public string StadiumName { get; set; } // Tên sân hiển thị
    }


}
