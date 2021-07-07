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
    public class MessageRepository : GenericRepository<Message>,IMessageRepository
    {
        public MessageRepository(ProjeDbContext context):base(context)
        {

        }

        public List<Message> GetAllMessageByUser()
        {
            return _context.Messages.Include(m => m.User).ToList();
        }
    }
}
