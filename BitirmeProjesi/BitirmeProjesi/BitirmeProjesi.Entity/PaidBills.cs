using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitirmeProjesi.Entity
{
    public class PaidBills
    {
        public int Id { get; set; }
        public User User { get; set; }
        public Apartment Apartment { get; set; }
        public int TotalBill { get; set; }
        public DateTime PaidDate { get; set; } = DateTime.Now;
        public double Dues { get; set; }
        public double ElectricityBill { get; set; }
        public double WaterBill { get; set; }
        public double GasBill { get; set; }
        public string Month { get; set; }
    }
}
