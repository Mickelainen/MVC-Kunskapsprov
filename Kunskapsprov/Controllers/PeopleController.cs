using Kunskapsprov.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kunskapsprov.Controllers
{
    public class PeopleController : Controller
    {
        private readonly ServerContext _context;

        public PeopleController(ServerContext context)
        {
            _context = context;
        }
        // GET: PersonController
        public async Task<IActionResult> Index()
        {
            return View(await _context.People.ToListAsync());
        }

        // GET: PersonController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }


       // POST: PersonController/Create
       [HttpPost]
       [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create( Person person)
        {
            if (ModelState.IsValid)
            {
                _context.Add(person);
                await _context.SaveChangesAsync();
                
                return RedirectToAction(nameof(Index));
                
            }
            return View();
        }

        // GET: PersonController/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var person = await _context.People.FindAsync(id);

            return View(person);
        }

        // POST: PersonController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit( Person person)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(person);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    return NotFound();
                }
                return RedirectToAction(nameof(Index));
            }
            return View(person);
        }

        // GET: PersonController/Delete/5
        
        public async Task<IActionResult> Delete(int? id)
        {
            
            var person = await _context.People.FirstOrDefaultAsync(p => p.Id == id);

            if (person == null)
            {
                return NotFound();
            }

            _context.People.Remove(person);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        
    }
}
