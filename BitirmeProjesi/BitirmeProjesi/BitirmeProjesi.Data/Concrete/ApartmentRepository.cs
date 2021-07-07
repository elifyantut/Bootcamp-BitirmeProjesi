using BitirmeProjesi.Data.Abstract;
using BitirmeProjesi.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitirmeProjesi.Data.Concrete
{
    public class ApartmentRepository : GenericRepository<Apartment>,IApartmentRepository
    {
        public ApartmentRepository(ProjeDbContext context):base(context)
        {

        }

        public Apartment GetByIdWithUser(int id)
        {
           
            return _context.Apartments.Where(c => c.Id == id).Include(c => c.User).FirstOrDefault();
        }

        public List<Apartment> GetByUserIdWithUserAndInvoice(string id)
        {
            return _context.Apartments.Where(c => c.User.Id == id).Include(c => c.Invoices).Include(c => c.User).ToList();
        }
    }
}
