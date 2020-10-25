using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MvcOvertime.Data;
using MvcOvertime.Models;
using MvcOvertime.ViewModels;

namespace MvcOvertime.Controllers
{
    public class LoginController : Controller
    {
        private readonly OvertimeContext _context;
        private readonly SignInManager<IdentityUser> _signInManager;

        public LoginController(OvertimeContext context, SignInManager<IdentityUser> signInManager)
        {
            _context = context;
            _signInManager = signInManager;
        }

      
        public IActionResult Index()
        {
            return View();
        }

       
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(Admin admin)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(admin.Name, string.Empty, false, false);
                if(result.Succeeded)
                {
                    return RedirectToAction("index", "Home");
                }

                ModelState.AddModelError(string.Empty, "Invalid Login Attempt");
            }
            return View(admin);
        }

        //// GET: Logins/Edit/5
        //public async Task<IActionResult> Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var admin = await _context.Admin.FindAsync(id);
        //    if (admin == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(admin);
        //}

        // POST: Logins/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
    //    // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    //    [HttpPost]
    //    [ValidateAntiForgeryToken]
    //    public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] Admin admin)
    //    {
    //        if (id != admin.Id)
    //        {
    //            return NotFound();
    //        }

    //        if (ModelState.IsValid)
    //        {
    //            try
    //            {
    //                _context.Update(admin);
    //                await _context.SaveChangesAsync();
    //            }
    //            catch (DbUpdateConcurrencyException)
    //            {
    //                if (!AdminExists(admin.Id))
    //                {
    //                    return NotFound();
    //                }
    //                else
    //                {
    //                    throw;
    //                }
    //            }
    //            return RedirectToAction(nameof(Index));
    //        }
    //        return View(admin);
    //    }

    //    // GET: Logins/Delete/5
    //    public async Task<IActionResult> Delete(int? id)
    //    {
    //        if (id == null)
    //        {
    //            return NotFound();
    //        }

    //        var admin = await _context.Admin
    //            .FirstOrDefaultAsync(m => m.Id == id);
    //        if (admin == null)
    //        {
    //            return NotFound();
    //        }

    //        return View(admin);
    //    }

    //    // POST: Logins/Delete/5
    //    [HttpPost, ActionName("Delete")]
    //    [ValidateAntiForgeryToken]
    //    public async Task<IActionResult> DeleteConfirmed(int id)
    //    {
    //        var admin = await _context.Admin.FindAsync(id);
    //        _context.Admin.Remove(admin);
    //        await _context.SaveChangesAsync();
    //        return RedirectToAction(nameof(Index));
    //    }

    //    private bool AdminExists(int id)
    //    {
    //        return _context.Admin.Any(e => e.Id == id);
    //    }
    }
}
