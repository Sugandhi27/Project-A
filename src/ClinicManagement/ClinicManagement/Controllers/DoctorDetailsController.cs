using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ClinicManagement.Models;

namespace ClinicManagement.Controllers
{
    public class DoctorDetailsController : Controller
    {
        private readonly ClinicContext _context;

        public DoctorDetailsController(ClinicContext context)
        {
            _context = context;
        }

        // GET: DoctorDetails
        public async Task<IActionResult> Index()
        {
            return View(await _context.DoctorTable.ToListAsync());
        }

        // GET: DoctorDetails/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var doctorDetail = await _context.DoctorTable
                .FirstOrDefaultAsync(m => m.DoctorID == id);
            if (doctorDetail == null)
            {
                return NotFound();
            }

            return View(doctorDetail);
        }

        // GET: DoctorDetails/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: DoctorDetails/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DoctorID,FirstName,LastName,Sex,Age,Specialization,FromTime,ToTime,PhoneNumber")] DoctorDetail doctorDetail)
        {
            if (ModelState.IsValid)
            {
                _context.Add(doctorDetail);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(doctorDetail);
        }

        // GET: DoctorDetails/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var doctorDetail = await _context.DoctorTable.FindAsync(id);
            if (doctorDetail == null)
            {
                return NotFound();
            }
            return View(doctorDetail);
        }

        // POST: DoctorDetails/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DoctorID,FirstName,LastName,Sex,Age,Specialization,FromTime,ToTime,PhoneNumber")] DoctorDetail doctorDetail)
        {
            if (id != doctorDetail.DoctorID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(doctorDetail);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DoctorDetailExists(doctorDetail.DoctorID))
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
            return View(doctorDetail);
        }

        // GET: DoctorDetails/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var doctorDetail = await _context.DoctorTable
                .FirstOrDefaultAsync(m => m.DoctorID == id);
            if (doctorDetail == null)
            {
                return NotFound();
            }

            return View(doctorDetail);
        }

        // POST: DoctorDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var doctorDetail = await _context.DoctorTable.FindAsync(id);
            _context.DoctorTable.Remove(doctorDetail);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DoctorDetailExists(int id)
        {
            return _context.DoctorTable.Any(e => e.DoctorID == id);
        }
    }
}
