using BitirmeProjesi.Data.Abstract;
using BitirmeProjesi.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitirmeProjesi.Data.Concrete
{
    public class PaidBillsRepository : GenericRepository<PaidBills>,IPaidBillsRepository 
    {
        public PaidBillsRepository(ProjeDbContext context):base(context)
        {

        }
    }
}
