using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace QuanLySanBong.Models
{
    public class Booking
    {
        [PrimaryKey, AutoIncrement]
        public int BookingID { get; set; }
        public int StadiumID { get; set; }
        public string CustomerName { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public DateTime Date { get; set; }
        public bool IsMatch { get; set; }
        
        
    }

}
