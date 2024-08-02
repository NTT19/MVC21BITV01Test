using Microsoft.AspNetCore.Mvc;
using MidTerm.Entity;
using MidTerm.Models;

namespace MidTerm.Controllers
{
    public class ProductController : Controller
    {
        private readonly QlbanHangContext _context;
        public ProductController (QlbanHangContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult SanphamAscending()
        {
            var data = _context.SanPhams.ToList();
            return View(data);
        }


        public IActionResult CreateProduct(SanPham model, IFormFile File)
        {
            try
            {
                //if (ModelState.IsValid)
                //{
                model.Hinh = MyTool.UploadImageToFolder(File, "Sanphams");
                _context.Add(model);
                _context.SaveChanges();
                return RedirectToAction("SanphamAscending");
                //}
            }
            catch (Exception ex)
            {
                return View();
            }
        }
       }
    }

