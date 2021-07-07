using BitirmeProjesi.Business.Abstract;
using BitirmeProjesi.Entity;
using BitirmeProjesi.WebUI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BitirmeProjesi.WebUI.Controllers
{
    [Authorize(Roles ="Admin")]
    public class AdminController : Controller
    {

        private readonly UserManager<User> _userManager;
        private readonly IApartmentService _apartmentService;
        private readonly IInvoiceService _invoiceService;
        private readonly IMessageService _messageService;
        private readonly IPaidBillsService _paidBillsService;

        public AdminController(UserManager<User> userManager, IApartmentService apartmentService, IInvoiceService invoiceService, IMessageService messageService, IPaidBillsService paidBillsService)
        {
            _userManager = userManager;
            _apartmentService = apartmentService;
            _invoiceService = invoiceService;
            _messageService = messageService;
            _paidBillsService = paidBillsService;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult CreateUser() 
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser(UserCreateViewModel model) 
        {
            if (ModelState.IsValid) 
            {
                var result = await _userManager.CreateAsync(new Entity.User { 
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    TCNO = model.TCNO,
                    Phone = model.Phone,
                    UserName=model.UserName,
                    CarPlate=model.CarPlate,
                    Email = model.Email
                },"User.111");

                if (result.Succeeded) return RedirectToAction("Index", "Home");
            } 
            return View(model);
        }

        public IActionResult GetAllUser()
        {
            List<UserViewModel>  users = _userManager.Users.Select(u=> new UserViewModel{FirstName = u.FirstName,LastName=u.LastName,Id=u.Id}).ToList();
            
            return View(users);
        }

        public async  Task<IActionResult> GetUserById(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            return View(user);
        }

        [HttpPost]
        public async  Task<IActionResult> DeleteUser(string Id) 
        {
            var user = await _userManager.FindByIdAsync(Id);
            var result = await _userManager.DeleteAsync(user);
            if (result.Succeeded) 
            {
                return RedirectToAction("Index", "Home");
            }
            return RedirectToAction("GetAllUser");
        }

        public IActionResult CreateApartment() 
        {
            return View();
        }

        [HttpPost]
        public   IActionResult CreateApartment(ApartmentCreateViewModel model) 
        {

            if (ModelState.IsValid) 
            {
                _apartmentService.Create(new Apartment { Block = model.Block, Floor = model.Floor, Status = model.Status, Type = model.Type, Number = model.Number,UserType=model.UserType });
                return RedirectToAction("Index", "Home");
            }
            return View(model);
            
            
        } 

        public IActionResult GetAllApartment() 
        {
            var apartments = _apartmentService.GetAll();
            return View(apartments);
        }

        public IActionResult GetApartment(int id) 
        {
            var apartment = _apartmentService.GetByIdWithUser(id);
            if(apartment.User == null) 
            {
                ViewBag.ApartmentUser = "Daireye boş.";
                return View(apartment);
            }
            ViewBag.ApartmentUser  = apartment.User.UserName;
            return View(apartment);
        }

        [HttpPost]
        public IActionResult DeleteApartment(int id) 
        {
            
            var apartment = _apartmentService.GetById(id);
            _apartmentService.Delete(apartment);
            return RedirectToAction("GetAllApartment");
        }

        public async Task<IActionResult> UpdateUser(string id) 
        {
            ViewBag.UserId = id;
            var user = await _userManager.FindByIdAsync(id);
            var model = new UserCreateViewModel()
            {
                CarPlate = user.CarPlate,
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Phone = user.Phone,
                TCNO = user.TCNO,
                UserName = user.UserName
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateUser(UserCreateViewModel model,string UserId) 
        {
            var user = await _userManager.FindByIdAsync(UserId);
            if (ModelState.IsValid) 
            {
                user.CarPlate = model.CarPlate;
                user.Email = model.Email;
                user.FirstName = model.FirstName;
                user.LastName = model.LastName;
                user.Phone = model.Phone;
                user.TCNO = model.TCNO;
                user.UserName = model.UserName;

                var result = await _userManager.UpdateAsync(user);

                if (result.Succeeded) 
                {
                    return RedirectToAction("GetAllUser");
                }
                return View(model);

            }
            return View(model);
        }

        public IActionResult UpdateApartment(int id) 
        {
            ViewBag.ApartmentId = id;
            var apartment = _apartmentService.GetById(id);
            var model = new ApartmentCreateViewModel()
            {
                Block = apartment.Block,
                Floor = apartment.Floor,
                Number = apartment.Number,
                Status = apartment.Status,
                Type = apartment.Type
            };
            return View(model);
        }

        [HttpPost]
        public IActionResult UpdateApartment(ApartmentCreateViewModel model,int ApartmentID) 
        {
            var apartment = _apartmentService.GetById(ApartmentID);
            if (ModelState.IsValid) 
            {
                apartment.Block = model.Block;
                apartment.Floor = model.Floor;
                apartment.Number = model.Number;
                apartment.Status = model.Status;
                apartment.Type = model.Type;

                _apartmentService.Update(apartment);
                return RedirectToAction("GetAllApartment");
            }
            return View(model);
        }

        public IActionResult AddUserToApartment(int id) 
        {
            ViewBag.ApartmentId = id;
            return View();

        }

        [HttpPost]
        public async Task<IActionResult> AddUserToCircle(string username,int ApartmentId)
        {
            var user = await _userManager.FindByNameAsync(username);
            var apartment = _apartmentService.GetById(ApartmentId);

            if(user != null)
            {
                apartment.User = user;
                _apartmentService.Update(apartment);
                return RedirectToAction("GetAllApartment");
            }

            ViewBag.ApartmentId = ApartmentId;
            ModelState.AddModelError("", "Böyle bir kullanıcı yok.");
  
            return View();

        }

        public IActionResult AddInvoiceToApartment(int id) 
        {
            ViewBag.ApatmentId = id;
            return View();
        }

        [HttpPost]
        public IActionResult AddInvoiceToApartment(int ApartmentId,InvoiceCreateViewModel model) 
        {
            if (ModelState.IsValid) 
            {
                var apartment = _apartmentService.GetById(ApartmentId);

                 _invoiceService.Create(new Invoice 
                 {
                     Dues = model.Dues,
                     ElectricityBill = model.ElectricityBill,
                     GasBill = model.GasBill,
                     WaterBill = model.WaterBill,
                     Month=model.Month,
                     Apartment=apartment
                 });

                
                return RedirectToAction("GetAllApartment");

            }
            ViewBag.ApartmentId = ApartmentId;
            return View(model);
        }

        public IActionResult GetAllInvoice()
        {
            var invoices = _invoiceService.GetAllInvoiceByApartment();
            var groupbyModel = invoices.GroupBy(i => i.Month); 
            return View(groupbyModel);
        }

        public IActionResult GetAllMessage() 
        {
            var messages = _messageService.GetAllMessageByUser();
            return View(messages);
        }

        public IActionResult GetAllPaidBills() 
        {
            var model = _paidBillsService.GetAll();
            return View(model);
        }





    }
}
