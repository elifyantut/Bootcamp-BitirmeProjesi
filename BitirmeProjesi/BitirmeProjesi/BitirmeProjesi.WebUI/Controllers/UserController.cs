using BitirmeProjesi.Business.Abstract;
using BitirmeProjesi.CreditCardService.Model;

using BitirmeProjesi.Entity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BitirmeProjesi.WebUI.Controllers
{
    [Authorize]
    public class UserController : Controller
    {

        private readonly IMessageService _messageService;
        private readonly UserManager<User> _userManager;
        private readonly IApartmentService _apartmentService;
        private readonly IInvoiceService _invoiceService;
        private readonly ICreditCardService _creditCardService;
        private readonly IPaidBillsService _paidBillsService;
        public UserController(IMessageService messageService, UserManager<User> userManager, IApartmentService apartmentService, IInvoiceService invoiceService, ICreditCardService creditCardService, IPaidBillsService paidBillsService)
        {
            _messageService = messageService;
            _userManager = userManager;
            _apartmentService = apartmentService;
            _invoiceService = invoiceService;
            _creditCardService = creditCardService;
            _paidBillsService = paidBillsService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult SendMessageToAdmin() 
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SendMessageToAdmin(string Message) 
        {
            var user = await _userManager.GetUserAsync(User);
            _messageService.Create(new Entity.Message { User = user, UserMessage = Message });
            return View();
        }

        public async Task<IActionResult> GetAllInvoiceByUserId() 
        {
            var user = await _userManager.GetUserAsync(User);
            var userId = user.Id;
            var apartments = _apartmentService.GetByUserIdWithUserAndInvoice(userId);
            return View(apartments);
        }

        public IActionResult PayBill(int id) 
        {
            var invoice = _invoiceService.GetByIdWithUser(id);
            ViewBag.Invoice = invoice;
            ViewBag.TotalBill = invoice.Dues + invoice.ElectricityBill + invoice.GasBill + invoice.WaterBill;
            return View();
            
        }

        [HttpPost]
        public async Task<IActionResult> PayBill(CreditCardViewModel model,int InvoiceId) 
        {
            
            var invoice = _invoiceService.GetByIdWithUser(InvoiceId);
            if (ModelState.IsValid)
            {
                
                var result = await _creditCardService.WithdrawMoney(model);
                if (result == true)
                {
                 
                    _paidBillsService.Create(new PaidBills 
                    { 
                        User = invoice.Apartment.User,
                        Apartment = invoice.Apartment,
                        TotalBill = (int)(invoice.Dues + invoice.ElectricityBill + invoice.GasBill + invoice.WaterBill),
                        Dues = invoice.Dues,
                        ElectricityBill = invoice.ElectricityBill,
                        GasBill = invoice.GasBill,
                        WaterBill = invoice.WaterBill,
                        Month = invoice.Month
                        
                    });
                    _invoiceService.Delete(invoice);
                    return RedirectToAction("Index", "Home");

                }
            }

            ModelState.AddModelError("", "Kredi kartı hatası.");
            ViewBag.TotalBill = invoice.Dues + invoice.ElectricityBill + invoice.GasBill + invoice.WaterBill;
            ViewBag.Invoice = invoice;
            return View();
        }
       
    }
}
 
