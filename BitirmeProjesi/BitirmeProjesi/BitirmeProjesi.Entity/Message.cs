using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitirmeProjesi.Entity
{
    public class Message
    {
        public int Id { get; set; }
        public User User { get; set; }
        public string UserMessage { get; set; }


    }
}
