using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DatabaseFirstDemo.Models;
using DatabaseFirstDemo.Repository;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace WebDemo14112023.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class RolesController : BaseController
    {
        private readonly ProductMangementBatch177Context _context;

        IRolesRepository roleRepository = null;
        public RolesController()
        {
            roleRepository = new RolesRepository();
        }


        // GET: Admin/Roles
        public async Task<IActionResult> Index()
        {
            var result = roleRepository.GetAll();
            return View(result);
            /* return result != null ?
                          View(await result) :
                          Problem("Entity set 'ProductMangementBatch177Context.Roles'  is null.");*/
        }

        // GET: Admin/Roles/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Roles == null)
            {
                return NotFound();
            }

            var role = await _context.Roles
                .FirstOrDefaultAsync(m => m.Id == id);
            if (role == null)
            {
                return NotFound();
            }

            return View(role);
        }

        // GET: Admin/Roles/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/Roles/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] Role role)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    roleRepository.Insert(role);
                    SetAlert("Insert Data is success!", "success");
                    //_context.Add(role);
                    //await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("Error",
                                 ex.Message);
            }
            return View(role);
        }

        // GET: Admin/Roles/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            Role role = roleRepository.GetById(id);
            if (id == null || role == null)
            {
                return NotFound();
            }

            //var role = await _context.Roles.FindAsync(id);
            /*if (role == null)
            {
                return NotFound();
            }*/
            return View(role);
        }

        // POST: Admin/Roles/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] Role role)
        {
            try
            {
                if (id != role.Id)
                {
                    return NotFound();
                }

                if (ModelState.IsValid)
                {
                    try
                    {
                        roleRepository.Update(role);
                        SetAlert("Update Data is success!", "success");
                        //await _context.SaveChangesAsync();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!RoleExists(role.Id))
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
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("Error",
                                 ex.Message);
            }
            return View(role);
        }

        // GET: Admin/Roles/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            Role role = roleRepository.GetById(id);
            if (id == null || role == null)
            {
                return NotFound();
            }

            //var role = await _context.Roles.FindAsync(id);
            /*if (role == null)
            {
                return NotFound();
            }*/
            return View(role);
        }

        // POST: Admin/Roles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                var result = roleRepository.GetById(id);
                if (result == null)
                {
                    return Problem("Entity set 'ProductMangementBatch177Context.Roles'  is null.");
                }
                roleRepository.Delete(result);
                SetAlert("Delete Data is success!", "success");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("Error",
                                ex.Message);
            }
            return RedirectToAction(nameof(Index));
        }

        private bool RoleExists(int id)
        {
            return (_context.Roles?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
