﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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

            var item = await _context.Items.Include(s => s.serialNumber)
                .Include(c => c.category)
                .ToListAsync();
            return View(item);
        }
        public IActionResult Create()
        {
            ViewData["Categories"] = new SelectList(_context.Categories, "Id", "Name");

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create([Bind("Id,Name,Price, CategoryId")] Item item)
        {
            if (ModelState.IsValid)
            {
                _context.Items.Add(item);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(item);
        }

        public async Task<IActionResult> Edit(int id)
        {
            ViewData["Categories"] = new SelectList(_context.Categories, "Id", "Name");

            var item = await _context.Items.FirstOrDefaultAsync(x => x.Id == id);
            return View(item);
        }
        [HttpPost]
        public async Task<IActionResult> Edit([Bind("Id,Name,Price,CategoryId ")] Item item)
        {
            if (ModelState.IsValid)
            {
                _context.Update(item);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(item);
        }
        public async Task<IActionResult> Delete(int id)
        {
            var item = await _context.Items.FirstOrDefaultAsync(x => x.Id == id);
            return View(item);
        }
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var item = await _context.Items.FindAsync(id);
            if (item != null)
            {
                _context.Items.Remove(item);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction("Index");
        }
    }
}
