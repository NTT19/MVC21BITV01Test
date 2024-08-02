using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MidTerm.Entity;
using MidTerm.Models;

namespace MidTerm.Controllers
{
    public class ProductsController : Controller
    {
        private readonly QlbanHangContext _context;
        public ProductsController (QlbanHangContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var data = _context.SanPhams.ToList();
            return View();
        }
                [HttpGet]
         public IActionResult SanphamAscending()
         {
             var data = _context.SanPhams.ToList();
             return View(data);
         }
        public IActionResult CreateProduct(SanPham model, IFormFile file)
        {
            try
            {
                //if (ModelState.IsValid)
                //{
                model.Hinh = MyTool.UploadImageToFolder(file, "Sanphams");
                _context.Add(model);
                _context.SaveChanges();
                return RedirectToAction("SanphamAscending");
                //}
            }
            catch (Exception ex)
            {
                return View();
            }
            return View();
        }
    }
}
