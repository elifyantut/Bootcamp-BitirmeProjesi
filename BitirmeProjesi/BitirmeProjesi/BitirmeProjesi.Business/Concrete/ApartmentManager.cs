using BitirmeProjesi.Business.Abstract;
using BitirmeProjesi.Data.Abstract;
using BitirmeProjesi.Data.Concrete;
using BitirmeProjesi.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitirmeProjesi.Business.Concrete
{
    public class ApartmentManager : IApartmentService
    {
        private IApartmentRepository _apartmentRepository;

        public ApartmentManager(IApartmentRepository apaertmentRepository)
        {
            _apartmentRepository = apaertmentRepository;
        }

        public void Create(Apartment entity)
        {
            _apartmentRepository.Create(entity);
        }

        public void Delete(Apartment entity)
        {
            _apartmentRepository.Delete(entity);
        }

        public List<Apartment> GetAll()
        {
            return _apartmentRepository.GetAll();
        }

        public Apartment GetById(int id)
        {
            return _apartmentRepository.GetById(id);
        }

        public Apartment GetByIdWithUser(int id)
        {
            return _apartmentRepository.GetByIdWithUser(id);
        }

        public List<Apartment> GetByUserIdWithUserAndInvoice(string id)
        {
            return _apartmentRepository.GetByUserIdWithUserAndInvoice(id);
        }

        public void Update(Apartment entity)
        {
            _apartmentRepository.Update(entity);
        }
    }
}
