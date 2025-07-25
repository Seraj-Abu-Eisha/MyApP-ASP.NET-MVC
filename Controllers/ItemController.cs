using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyApP.Data;
using MyApP.Models;

namespace MyApP.Controllers
{
    public class ItemController : Controller
    {
        private readonly MyAppContext _context;

        public ItemController(MyAppContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var item = await _context.Items.ToListAsync();
            return View(item);
        }
        public async Task<IActionResult> Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create([Bind("Id,Name,Price")] Item item)
        {
            if(ModelState.IsValid)
            {
                _context.Items.Add(item);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(item);
        }
    }
}
