using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace QuanLySanBong.Models
{
    public class StadiumRent
    {
        [PrimaryKey, AutoIncrement]
        public int StadiumRentID { get; set; }
        public string Name { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public double TotalPrice { get; set; }

        // Thuộc tính tính toán TotalTime (tổng thời gian)
        public TimeSpan TotalTime
        {
            get
            {
                return EndTime - StartTime; // Tính sự khác biệt giữa EndTime và StartTime
            }
        }
    }


}
