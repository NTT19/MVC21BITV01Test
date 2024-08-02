using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MidTerm.Entity;

namespace MidTerm.Controllers
{
    public class KhachHangController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        private readonly QlbanHangContext _context;

        public KhachHangController(QlbanHangContext context)
        {
            _context = context;
        }
        [HttpGet("/khachhang/all/ascending")]
        public IActionResult CustomerAscending()
        {
            var data = _context.KhachHangs
                 .OrderBy(c => c.ThanhPhoNavigation)
                .ToList();
            return View(data);
        }

        [HttpGet("/khachhangs/all/descending")]
        public IActionResult CustomerDescending()
        {
            var data = _context.KhachHangs
                .OrderByDescending(c => c.ThanhPhoNavigation)

                .ToList();
            return View("CustomerAscending", data);
        }

    }
}
