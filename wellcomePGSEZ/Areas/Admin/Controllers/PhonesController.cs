using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using wellcomePGSEZ.Models;

namespace wellcomePGSEZ.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class PhonesController : Controller
    {
        private readonly PgsezServicesContext _context;

        public PhonesController(PgsezServicesContext context)
        {
            _context = context;
        }

        // GET: Admin/Phones
        public async Task<IActionResult> Index()
        {
            var pgsezServicesContext = _context.Phones.Include(p => p.PDepNavigation);
            return View(await pgsezServicesContext.ToListAsync());
        }

        // GET: Admin/Phones/Details/5
        public async Task<IActionResult> Details(short? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var phone = await _context.Phones
                .Include(p => p.PDepNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (phone == null)
            {
                return NotFound();
            }

            return View(phone);
        }

        // GET: Admin/Phones/Create
        public IActionResult Create()
        {
            ViewData["PDep"] = new SelectList(_context.Departments, "Id", "Id");
            return View();
        }

        // POST: Admin/Phones/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,PhoneNumber,PCode,PName,PDep,PSerial,PropertyNumber")] Phone phone)
        {
            if (ModelState.IsValid)
            {
                _context.Add(phone);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PDep"] = new SelectList(_context.Departments, "Id", "Id", phone.PDep);
            return View(phone);
        }

        // GET: Admin/Phones/Edit/5
        public async Task<IActionResult> Edit(short? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var phone = await _context.Phones.FindAsync(id);
            if (phone == null)
            {
                return NotFound();
            }
            ViewData["PDep"] = new SelectList(_context.Departments, "Id", "Id", phone.PDep);
            return View(phone);
        }

        // POST: Admin/Phones/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(short id, [Bind("Id,PhoneNumber,PCode,PName,PDep,PSerial,PropertyNumber")] Phone phone)
        {
            if (id != phone.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(phone);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PhoneExists(phone.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["PDep"] = new SelectList(_context.Departments, "Id", "Id", phone.PDep);
            return View(phone);
        }

        // GET: Admin/Phones/Delete/5
        public async Task<IActionResult> Delete(short? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var phone = await _context.Phones
                .Include(p => p.PDepNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (phone == null)
            {
                return NotFound();
            }

            return View(phone);
        }

        // POST: Admin/Phones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(short id)
        {
            var phone = await _context.Phones.FindAsync(id);
            if (phone != null)
            {
                _context.Phones.Remove(phone);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PhoneExists(short id)
        {
            return _context.Phones.Any(e => e.Id == id);
        }
    }
}
