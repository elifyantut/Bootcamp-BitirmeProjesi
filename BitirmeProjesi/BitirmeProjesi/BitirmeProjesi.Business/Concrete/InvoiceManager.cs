using BitirmeProjesi.Business.Abstract;
using BitirmeProjesi.Data.Abstract;
using BitirmeProjesi.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitirmeProjesi.Business.Concrete
{
    public class InvoiceManager : IInvoiceService
    {
        private IInvoiceRepository _invoiceRepository;

        public InvoiceManager(IInvoiceRepository invoiceRepository)
        {
            _invoiceRepository = invoiceRepository;
        }

        public void Create(Invoice entity)
        {
            _invoiceRepository.Create(entity);
        }

        public Invoice CreateAndReturnInvoice(Invoice entity)
        {
            return _invoiceRepository.CreateAndReturnInvoice(entity);
        }

        public void Delete(Invoice entity)
        {
            _invoiceRepository.Delete(entity);
        }

        public List<Invoice> GetAll()
        {
           return  _invoiceRepository.GetAll();
        }

        public List<Invoice> GetAllInvoiceByApartment()
        {
            return _invoiceRepository.GetAllInvoiceByApartment();
        }

        public Invoice GetById(int id)
        {
            return _invoiceRepository.GetById(id);
        }

        public Invoice GetByIdWithUser(int id)
        {
            return _invoiceRepository.GetByIdWithUser(id);
        }

        public void Update(Invoice entity)
        {
            _invoiceRepository.Update(entity);
        }
    }
}
