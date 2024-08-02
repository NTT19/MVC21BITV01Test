using Microsoft.AspNetCore.Mvc;
using MidTerm.Entity;
using MidTerm.Models;

namespace MidTerm.Controllers
{
    public class KhachHangController : Controller
    {
        private readonly QlbanHangContext _context;
        public KhachHangController(QlbanHangContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var data = _context.KhachHangs.ToList();
            return View(data);
        }

        [HttpGet]
        public IActionResult Create()
        {
            var data = _context.KhachHangs.ToList();
            return View(data);
        }

        [HttpGet("/khachhangs/all/ascending")]
        public IActionResult CustomerAscending()
        {
            var data = _context.KhachHangs
                 .OrderBy(c => c.TenCty)
                .ToList();
            return View(data);
        }

        [HttpGet("/khachhangs/all/descending")]
        public IActionResult CustomerDescending()
        {
            var data = _context.KhachHangs
                .OrderByDescending(c => c.TenCty)
             
                .ToList();
            return View("CustomerAscending", data);
        }

    
        public IActionResult CreateCustomer(KhachHang model)
        {
             if (ModelState.IsValid)
            {
                _context.KhachHangs.Add(model);
                _context.SaveChanges();
                return RedirectToAction("CustomerAscending");
            }
            return View(model);
        }
    }
}
