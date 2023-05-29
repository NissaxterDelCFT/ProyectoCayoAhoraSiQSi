using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProyectoCayoAhoraSiQSi.Models;

namespace ProyectoCayoAhoraSiQSi.Controllers
{
    public class AsignaturasAsiganadasController : Controller
    {
        private readonly SistemaCftContext _context;

        public AsignaturasAsiganadasController(SistemaCftContext context)
        {
            _context = context;
        }

        // GET: AsignaturasAsiganadas
        public async Task<IActionResult> Index()
        {
            var sistemaCftContext = _context.Asignaturaasignada.Include(a => a.Asignatura).Include(a => a.Estudiante);
            return View(await sistemaCftContext.ToListAsync());
        }

        // GET: AsignaturasAsiganadas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Asignaturaasignada == null)
            {
                return NotFound();
            }

            var asignaturasAsiganada = await _context.Asignaturaasignada
                .Include(a => a.Asignatura)
                .Include(a => a.Estudiante)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (asignaturasAsiganada == null)
            {
                return NotFound();
            }

            return View(asignaturasAsiganada);
        }

        // GET: AsignaturasAsiganadas/Create
        public IActionResult Create()
        {
            ViewData["AsignaturaId"] = new SelectList(_context.Asignaturas, "Id", "Id");
            ViewData["EstudianteId"] = new SelectList(_context.Estudiantes, "Id", "Id");
            return View();
        }

        // POST: AsignaturasAsiganadas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,EstudianteId,AsignaturaId,FechaRegistro")] AsignaturasAsiganada asignaturasAsiganada)
        {
            if (asignaturasAsiganada.EstudianteId != 0 && asignaturasAsiganada.AsignaturaId != 0)
            {
                _context.Asignaturaasignada.Add(asignaturasAsiganada);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AsignaturaId"] = new SelectList(_context.Asignaturas, "Id", "Id", asignaturasAsiganada.AsignaturaId);
            ViewData["EstudianteId"] = new SelectList(_context.Estudiantes, "Id", "Id", asignaturasAsiganada.EstudianteId);
            return View(asignaturasAsiganada);
        }

        // GET: AsignaturasAsiganadas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Asignaturaasignada == null)
            {
                return NotFound();
            }

            var asignaturasAsiganada = await _context.Asignaturaasignada.FindAsync(id);
            if (asignaturasAsiganada == null)
            {
                return NotFound();
            }
            ViewData["AsignaturaId"] = new SelectList(_context.Asignaturas, "Id", "Id", asignaturasAsiganada.AsignaturaId);
            ViewData["EstudianteId"] = new SelectList(_context.Estudiantes, "Id", "Id", asignaturasAsiganada.EstudianteId);
            return View(asignaturasAsiganada);
        }

        // POST: AsignaturasAsiganadas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,EstudianteId,AsignaturaId,FechaRegistro")] AsignaturasAsiganada asignaturasAsiganada)
        {
            if (id != asignaturasAsiganada.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(asignaturasAsiganada);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AsignaturasAsiganadaExists(asignaturasAsiganada.Id))
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
            ViewData["AsignaturaId"] = new SelectList(_context.Asignaturas, "Id", "Id", asignaturasAsiganada.AsignaturaId);
            ViewData["EstudianteId"] = new SelectList(_context.Estudiantes, "Id", "Id", asignaturasAsiganada.EstudianteId);
            return View(asignaturasAsiganada);
        }

        // GET: AsignaturasAsiganadas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Asignaturaasignada == null)
            {
                return NotFound();
            }

            var asignaturasAsiganada = await _context.Asignaturaasignada
                .Include(a => a.Asignatura)
                .Include(a => a.Estudiante)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (asignaturasAsiganada == null)
            {
                return NotFound();
            }

            return View(asignaturasAsiganada);
        }

        // POST: AsignaturasAsiganadas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Asignaturaasignada == null)
            {
                return Problem("Entity set 'SistemaCftContext.Asignaturaasignada'  is null.");
            }
            var asignaturasAsiganada = await _context.Asignaturaasignada.FindAsync(id);
            if (asignaturasAsiganada != null)
            {
                _context.Asignaturaasignada.Remove(asignaturasAsiganada);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AsignaturasAsiganadaExists(int id)
        {
          return (_context.Asignaturaasignada?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
