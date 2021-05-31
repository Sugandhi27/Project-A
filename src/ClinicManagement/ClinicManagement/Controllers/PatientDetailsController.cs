using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ClinicManagement.Models;
using ClinicManagement.Service;

namespace ClinicManagement.Controllers
{
    public class PatientDetailsController : Controller
    {
        private readonly ClinicContext _context;
        public PatientDetailsController(ClinicContext context)
        {
            _context = context;
        }

        // GET: PatientDetails
        public async Task<IActionResult> Index()
        {
            return View(await _context.PatientTable.ToListAsync());
        }
        // GET: PatientDetails/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var patientDetail = await _context.PatientTable
                .FirstOrDefaultAsync(m => m.PatientID == id);
            if (patientDetail == null)
            {
                return NotFound();
            }

            return View(patientDetail);
        }

        // GET: PatientDetails/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PatientDetails/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PatientID,FirstName,LastName,Sex,Age,Date_of_Birth,PhoneNumber,Reason")] PatientDetail patientDetail)
        {
            if (ModelState.IsValid)
            {
                _context.Add(patientDetail);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(patientDetail);
        }

        // GET: PatientDetails/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var patientDetail = await _context.PatientTable.FindAsync(id);
            if (patientDetail == null)
            {
                return NotFound();
            }
            return View(patientDetail);
        }

        // POST: PatientDetails/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PatientID,FirstName,LastName,Sex,Age,Date_of_Birth,PhoneNumber,Reason")] PatientDetail patientDetail)
        {
            if (id != patientDetail.PatientID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(patientDetail);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PatientDetailExists(patientDetail.PatientID))
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
            return View(patientDetail);
        }

        // GET: PatientDetails/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var patientDetail = await _context.PatientTable
                .FirstOrDefaultAsync(m => m.PatientID == id);
            if (patientDetail == null)
            {
                return NotFound();
            }

            return View(patientDetail);
        }

        // POST: PatientDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var patientDetail = await _context.PatientTable.FindAsync(id);
            _context.PatientTable.Remove(patientDetail);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PatientDetailExists(int id)
        {
            return _context.PatientTable.Any(e => e.PatientID == id);
        }
    }
}
