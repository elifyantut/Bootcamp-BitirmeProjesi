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
    public class InvoiceRepository : GenericRepository<Invoice>, IInvoiceRepository
    {
        public InvoiceRepository(ProjeDbContext context) : base(context)
        {
        }

        public Invoice CreateAndReturnInvoice(Invoice entity)
        {
            var Invoice = entity;
            _context.Invoice.Add(Invoice);
            _context.SaveChanges();
            return Invoice;
              
        }

        public List<Invoice> GetAllInvoiceByApartment()
        {
            return _context.Invoice.Include(i => i.Apartment).ToList();
        }

        public Invoice GetByIdWithUser(int id)
        {
            return _context.Invoice.Where(i => i.Id == id).Include(i=>i.Apartment).ThenInclude(c=>c.User).FirstOrDefault();
        }
    }
}
