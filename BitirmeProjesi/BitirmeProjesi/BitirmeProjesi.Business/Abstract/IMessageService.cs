using BitirmeProjesi.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitirmeProjesi.Business.Abstract
{
    public interface IMessageService
    {
        void Create(Message entity);
        void Update(Message entity);
        void Delete(Message entity);
        List<Message> GetAll();
        Message GetById(int id);
        List<Message> GetAllMessageByUser();
    }
}
