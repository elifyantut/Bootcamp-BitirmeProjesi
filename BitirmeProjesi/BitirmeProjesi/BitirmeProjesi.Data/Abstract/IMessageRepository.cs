using BitirmeProjesi.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitirmeProjesi.Data.Abstract
{
    public interface IMessageRepository : IRepository<Message>
    {
        List<Message> GetAllMessageByUser();
    }
}
