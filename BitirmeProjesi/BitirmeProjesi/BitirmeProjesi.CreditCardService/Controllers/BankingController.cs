using BitirmeProjesi.CreditCardService.Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BitirmeProjesi.CreditCardService.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class BankingController : ControllerBase
    {
        private readonly Services.CreditCardService _creditCardService;

        public BankingController(Services.CreditCardService creditCardService)
        {
            _creditCardService = creditCardService;
        }

        [HttpPost("WithdrawMoney")]
        public async Task<IActionResult> WithdrawMoney(CreditCardViewModel model) 
        {
            var result = await _creditCardService.WithdrawMoney(new Model.Mongo.CreditCard 
            {
                CardNumber = model.CardNumber,
                Cvv = model.Cvv,
                Owner = model.Owner,
                ValidMonth = model.ValidMonth,
                ValidYear = model.ValidYear
            },model.Money);

            return Ok(result);
        } 


    }
}
