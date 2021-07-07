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
    public class MessageManager : IMessageService
    {
        private readonly IMessageRepository _messageRepository;
        public MessageManager(IMessageRepository messageRepository)
        {
            _messageRepository = messageRepository;
        }

        public void Create(Message entity)
        {
            _messageRepository.Create(entity);
        }

        public void Delete(Message entity)
        {
            _messageRepository.Delete(entity);
        }

        public List<Message> GetAll()
        {
            return _messageRepository.GetAll();
        }

        public List<Message> GetAllMessageByUser()
        {
            return _messageRepository.GetAllMessageByUser();
        }

        public Message GetById(int id)
        {
            return _messageRepository.GetById(id);
        }

        public void Update(Message entity)
        {
            _messageRepository.Update(entity);
        }
    }
}
