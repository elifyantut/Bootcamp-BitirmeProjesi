
using BitirmeProjesi.CreditCardService.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitirmeProjesi.Business.Abstract
{
    public interface ICreditCardService
    {
        Task<bool> WithdrawMoney(CreditCardViewModel creditCard);
    }
}
