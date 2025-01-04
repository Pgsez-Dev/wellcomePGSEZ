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
    public class SoftwaresController : Controller
    {
        private readonly PgsezServicesContext _context;

        public SoftwaresController(PgsezServicesContext context)
        {
            _context = context;
        }

        // GET: Admin/Softwares
        public async Task<IActionResult> Index()
        {
            return View(await _context.Softwares.ToListAsync());
        }

        // GET: Admin/Softwares/Details/5
        public async Task<IActionResult> Details(short? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var software = await _context.Softwares
                .FirstOrDefaultAsync(m => m.Id == id);
            if (software == null)
            {
                return NotFound();
            }

            return View(software);
        }

        // GET: Admin/Softwares/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/Softwares/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,SName,SAddress,SImagePath,SExplain")] Software software , IFormFile SImagePath)
        {
            if (ModelState.IsValid)
            {


                if (SImagePath != null)
                {

                    software.SImagePath = Guid.NewGuid().ToString() + System.IO.Path.GetExtension(SImagePath.FileName);

                    string fn = Directory.GetCurrentDirectory();
                    string path = Path.Combine(fn+"\\wwwroot\\images",software.SImagePath);

                    using(var stream = new FileStream(path, FileMode.Create))
                    {
                        SImagePath.CopyTo(stream);
                    }
                }

                _context.Add(software);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(software);
        }

        // GET: Admin/Softwares/Edit/5
        public async Task<IActionResult> Edit(short? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var software = await _context.Softwares.FindAsync(id);
            if (software == null)
            {
                return NotFound();
            }
            return View(software);
        }

        // POST: Admin/Softwares/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(short id, [Bind("Id,SName,SAddress,SImagePath,SExplain")] Software software)
        {
            if (id != software.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(software);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SoftwareExists(software.Id))
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
            return View(software);
        }

        // GET: Admin/Softwares/Delete/5
        public async Task<IActionResult> Delete(short? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var software = await _context.Softwares
                .FirstOrDefaultAsync(m => m.Id == id);
            if (software == null)
            {
                return NotFound();
            }

            return View(software);
        }

        // POST: Admin/Softwares/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(short id)
        {
            var software = await _context.Softwares.FindAsync(id);
            if (software != null)
            {
                _context.Softwares.Remove(software);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SoftwareExists(short id)
        {
            return _context.Softwares.Any(e => e.Id == id);
        }
    }
}
