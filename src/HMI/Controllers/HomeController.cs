using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using HMI.Models.ProjectViewModels;
using HMI.Data;
using HMI.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace HMI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _db;

        public HomeController(ApplicationDbContext db, UserManager<ApplicationUser> userManager)
        {
            _db = db;
            
        }

        public IActionResult Index()
        {
            if (User.IsInRole("Admin"))
            {
                return RedirectToAction("Index", "Admin");
            }
            return View();
        }

        [Authorize]
        [HttpGet]
        public IActionResult CreateOrder()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        public IActionResult CreateOrder(Curtain curtain)
        {
            if (ModelState.IsValid)
            {
                Order order = new Order()
                {
                    Curtain = curtain,
                    DateOfStart = DateTime.Now,
                    DateOfFinish = DateTime.Now,
                    User = _db.Users.Single(u => u.UserName == User.Identity.Name),
                    Price = Order.GetPrice(curtain),
                    State = 0
                };
                _db.Orders.Add(order);
                _db.Curtains.Add(curtain);
                _db.SaveChanges();
                return RedirectToAction(nameof(MyOrders));
            }
            return View(curtain);
        }

        public IActionResult MyOrders()
        {
            var appUser = _db.Users.Include(u => u.Orders).Single(u => u.UserName == User.Identity.Name);
            var orders = _db.Orders.Include(o => o.Curtain).Include(o => o.User).Where(o => o.User == appUser).ToList();
            return View(orders);
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }

        public decimal CalculatePrice(Curtain curtain)
        {
            return Order.GetPrice(curtain);
        }


        public IActionResult GetPrice()
        {
            return View();
        }
    }
}
