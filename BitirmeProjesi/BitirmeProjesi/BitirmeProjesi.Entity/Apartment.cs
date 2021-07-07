using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitirmeProjesi.Entity
{
    public class Apartment
    {
        public int Id { get; set; }
        public string Block { get; set; }
        public string Status { get; set; }
        public string Type { get; set; }
        public int Floor { get; set; }
        public int Number { get; set; }
        public string UserType { get; set; }
        public User User { get; set; }
        public List<Invoice> Invoices { get; set; }
        public List<PaidBills> PaidBills { get; set; }

    }
}
