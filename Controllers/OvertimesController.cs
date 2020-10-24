using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MvcOvertime.Data;
using MvcOvertime.Models;

namespace MvcOvertime.Controllers
{
    public class OvertimesController : Controller
    {
        private readonly OvertimeContext _context;

        public OvertimesController(OvertimeContext context)
        {
            _context = context;
        }

        // GET: Overtimes
        public async Task<IActionResult> Index()
        {
            var overtimes = from o in _context.Overtime
                            join e in _context.Employee on o.EmployeeId equals e.Id 
                            into empOvertime from eo in empOvertime.DefaultIfEmpty()
                            select new ViewModel
                            {
                                Overtime = o,
                                Employee = eo == null ? null : eo
                            };

            return View(await overtimes.ToListAsync());
        }

        // GET: Overtimes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var overtime = await _context.Overtime
                .FirstOrDefaultAsync(m => m.Id == id);
            if (overtime == null)
            {
                return NotFound();
            }

            return View(overtime);
        }

        // GET: Overtimes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Overtimes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Day,NumberOfHours,StartTime,DtStartTime,Date,EmployeeId")] Overtime overtime)
        {
            if (ModelState.IsValid)
            {
                _context.Add(overtime);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(overtime);
        }

        // GET: Overtimes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var overtime = await _context.Overtime.FindAsync(id);
            var viewModel = new ViewModel() { Overtime = overtime };
            if (overtime == null)
            {
                return NotFound();
            }
            return View(viewModel);
        }

        // POST: Overtimes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Day,NumberOfHours,StartTime,DtStartTime,Date,EmployeeId,Employee.FullName")] Overtime overtime)
        {
            if (id != overtime.Id)
            {
                return NotFound();
            }
            //var employee = _context.Employee.Where(e => e.Id == overtime.EmployeeId).FirstOrDefault();
            //var viewModel = new ViewModel()
            //{
            //    Overtime = overtime,
            //    Employee = employee
            //};

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(overtime);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OvertimeExists(overtime.Id))
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
            return View(overtime);
        }

        // GET: Overtimes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var overtime = await _context.Overtime
                .FirstOrDefaultAsync(m => m.Id == id);
            if (overtime == null)
            {
                return NotFound();
            }

            return View(overtime);
        }

        // POST: Overtimes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var overtime = await _context.Overtime.FindAsync(id);
            _context.Overtime.Remove(overtime);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OvertimeExists(int id)
        {
            return _context.Overtime.Any(e => e.Id == id);
        }
    }
}
