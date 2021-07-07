using BitirmeProjesi.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitirmeProjesi.Business.Abstract
{
    public interface IApartmentService
    {
         

        void Create(Apartment entity);
        void Update(Apartment entity);
        void Delete(Apartment entity);
        List<Apartment> GetAll();
        Apartment GetById(int id);
        Apartment GetByIdWithUser(int id);
        List<Apartment> GetByUserIdWithUserAndInvoice(string id);
    }
}
