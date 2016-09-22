using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HMI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace HMI.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly ApplicationDbContext _db;
        public AdminController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            return View(_db.Orders.Include(o => o.User).Include(o => o.Curtain).Where(o => o.State == 0).ToList());
        }

        public IActionResult GetAccepted()
        {
            return View(_db.Orders.Include(o => o.User).Include(o => o.Curtain).Where(o => o.State == 1).ToList());
        }

        public IActionResult GetCompleted()
        {
            return View(_db.Orders.Include(o => o.User).Include(o => o.Curtain).Where(o => o.State == 2).ToList());
        }

        public IActionResult GetRefused()
        {
            return View(_db.Orders.Include(o => o.User).Include(o => o.Curtain).Where(o => o.State == 3).ToList());
        }

        public IActionResult MakeCompleted(int orderId)
        {
            _db.Orders.Single(o => o.Id == orderId).State = 2;
            _db.SaveChanges();
            return RedirectToAction(nameof(GetAccepted));
        }

        public IActionResult AcceptOrder(int orderId)
        {
            _db.Orders.Single(o => o.Id == orderId).State = 1;
            _db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult RefuseOrder(int orderId)
        {
            _db.Orders.Single(o => o.Id == orderId).State = 3;
            _db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
