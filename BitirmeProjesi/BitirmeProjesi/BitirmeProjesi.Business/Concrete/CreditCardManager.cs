using BitirmeProjesi.Business.Abstract;
using BitirmeProjesi.CreditCardService.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace BitirmeProjesi.Business.Concrete
{
    public class CreditCardManager : ICreditCardService
    {
        private readonly HttpClient _httpClient;

        public CreditCardManager(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<bool> WithdrawMoney(CreditCardViewModel creditCard)
        {
            string json = JsonSerializer.Serialize(creditCard);
            StringContent content = new StringContent(json,Encoding.UTF8,"application/json");

            var uri = new Uri($"{_httpClient.BaseAddress}Banking/WithdrawMoney");
            var response = await _httpClient.PostAsync(uri, content);

            if(response.StatusCode == System.Net.HttpStatusCode.OK) 
            {
                var result = await response.Content.ReadAsStringAsync();
                return bool.Parse(result);
            }
            return false;
        }
    }
}
