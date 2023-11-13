using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using nikhiltodolist.Data;
using nikhiltodolist.Models;

namespace nikhiltodolist.Controllers
{
    public class WorkListsController : Controller
    {
        private readonly ToDoListContext _context;

        public WorkListsController(ToDoListContext context)
        {
            _context = context;
        }

        // GET: WorkLists
        public async Task<IActionResult> Index()
        {
              return _context.gaipuja != null ? 
                          View(await _context.gaipuja.ToListAsync()) :
                          Problem("Entity set 'ToDoListContext.gaipuja'  is null.");
        }

        // GET: WorkLists/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.gaipuja == null)
            {
                return NotFound();
            }

            var workList = await _context.gaipuja
                .FirstOrDefaultAsync(m => m.Id == id);
            if (workList == null)
            {
                return NotFound();
            }

            return View(workList);
        }

        // GET: WorkLists/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: WorkLists/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,worktitle,time,category")] WorkList workList)
        {
            if (ModelState.IsValid)
            {
                _context.Add(workList);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(workList);
        }

        // GET: WorkLists/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.gaipuja == null)
            {
                return NotFound();
            }

            var workList = await _context.gaipuja.FindAsync(id);
            if (workList == null)
            {
                return NotFound();
            }
            return View(workList);
        }

        // POST: WorkLists/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,worktitle,time,category")] WorkList workList)
        {
            if (id != workList.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(workList);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WorkListExists(workList.Id))
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
            return View(workList);
        }

        // GET: WorkLists/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.gaipuja == null)
            {
                return NotFound();
            }

            var workList = await _context.gaipuja
                .FirstOrDefaultAsync(m => m.Id == id);
            if (workList == null)
            {
                return NotFound();
            }

            return View(workList);
        }

        // POST: WorkLists/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.gaipuja == null)
            {
                return Problem("Entity set 'ToDoListContext.gaipuja'  is null.");
            }
            var workList = await _context.gaipuja.FindAsync(id);
            if (workList != null)
            {
                _context.gaipuja.Remove(workList);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool WorkListExists(int id)
        {
          return (_context.gaipuja?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
