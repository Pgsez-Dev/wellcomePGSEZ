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
        private readonly PgsezServiceContext _context;

        public PhonesController(PgsezServiceContext context)
        {
            _context = context;
        }

        // GET: Admin/Phones
        public async Task<IActionResult> Index()
        {
            var pgsezServiceContext = _context.Phones.Include(p => p.PModelNavigation).Include(p => p.PUserNavigation);
            return View(await pgsezServiceContext.ToListAsync());
        }

        // GET: Admin/Phones/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var phone = await _context.Phones
                .Include(p => p.PModelNavigation)
                .Include(p => p.PUserNavigation)
                .FirstOrDefaultAsync(m => m.PId == id);
            if (phone == null)
            {
                return NotFound();
            }

            return View(phone);
        }

        // GET: Admin/Phones/Create
        public IActionResult Create()
        {
            ViewData["PModel"] = new SelectList(_context.Models, "MId", "MName");
            ViewData["PUser"] = new SelectList(_context.Users, "UId", "UId");
            return View();
        }

        // POST: Admin/Phones/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PId,PProperty,PNumber,PIpAddress,PModel,PUser")] Phone phone)
        {
            if (ModelState.IsValid)
            {
                _context.Add(phone);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PModel"] = new SelectList(_context.Models, "MId", "MName", phone.PModel);
            ViewData["PUser"] = new SelectList(_context.Users, "UId", "UId", phone.PUser);
            return View(phone);
        }

        // GET: Admin/Phones/Edit/5
        public async Task<IActionResult> Edit(int? id)
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
            ViewData["PModel"] = new SelectList(_context.Models, "MId", "MName", phone.PModel);
            ViewData["PUser"] = new SelectList(_context.Users, "UId", "UId", phone.PUser);
            return View(phone);
        }

        // POST: Admin/Phones/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PId,PProperty,PNumber,PIpAddress,PModel,PUser")] Phone phone)
        {
            if (id != phone.PId)
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
                    if (!PhoneExists(phone.PId))
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
            ViewData["PModel"] = new SelectList(_context.Models, "MId", "MName", phone.PModel);
            ViewData["PUser"] = new SelectList(_context.Users, "UId", "UId", phone.PUser);
            return View(phone);
        }

        // GET: Admin/Phones/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var phone = await _context.Phones
                .Include(p => p.PModelNavigation)
                .Include(p => p.PUserNavigation)
                .FirstOrDefaultAsync(m => m.PId == id);
            if (phone == null)
            {
                return NotFound();
            }

            return View(phone);
        }

        // POST: Admin/Phones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var phone = await _context.Phones.FindAsync(id);
            if (phone != null)
            {
                _context.Phones.Remove(phone);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PhoneExists(int id)
        {
            return _context.Phones.Any(e => e.PId == id);
        }
    }
}
