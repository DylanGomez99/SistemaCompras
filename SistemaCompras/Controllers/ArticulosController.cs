using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SistemaCompras.Data;
using SistemaCompras.Models;

namespace SistemaCompras.Controllers
{
    public class ArticulosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ArticulosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Articuloes
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Articulos.Include(a => a.Marca).Include(a => a.UnidadMedida);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Articuloes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var articulo = await _context.Articulos
                .Include(a => a.Marca)
                .Include(a => a.UnidadMedida)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (articulo == null)
            {
                return NotFound();
            }

            return View(articulo);
        }

        // GET: Articuloes/Create
        public IActionResult Create()
        {
            ViewData["MarcaId"] = new SelectList(_context.Marcas, "Id", "Nombre");
            ViewData["UnidadMedidaId"] = new SelectList(_context.UnidadesMedida, "Id", "Nombre");
            return View();
        }

        // POST: Articuloes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,MarcaId,UnidadMedidaId")] Articulo articulo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(articulo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MarcaId"] = new SelectList(_context.Marcas, "Id", "Nombre", articulo.MarcaId);
            ViewData["UnidadMedidaId"] = new SelectList(_context.UnidadesMedida, "Id", "Nombre", articulo.UnidadMedidaId);
            return View(articulo);
        }

        // GET: Articuloes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var articulo = await _context.Articulos.FindAsync(id);
            if (articulo == null)
            {
                return NotFound();
            }
            ViewData["MarcaId"] = new SelectList(_context.Marcas, "Id", "Nombre", articulo.MarcaId);
            ViewData["UnidadMedidaId"] = new SelectList(_context.UnidadesMedida, "Id", "Nombre", articulo.UnidadMedidaId);
            return View(articulo);
        }

        // POST: Articuloes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,MarcaId,UnidadMedidaId")] Articulo articulo)
        {
            if (id != articulo.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(articulo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ArticuloExists(articulo.Id))
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
            ViewData["MarcaId"] = new SelectList(_context.Marcas, "Id", "Nombre", articulo.MarcaId);
            ViewData["UnidadMedidaId"] = new SelectList(_context.UnidadesMedida, "Id", "Nombre", articulo.UnidadMedidaId);
            return View(articulo);
        }

        // GET: Articuloes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var articulo = await _context.Articulos
                .Include(a => a.Marca)
                .Include(a => a.UnidadMedida)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (articulo == null)
            {
                return NotFound();
            }

            return View(articulo);
        }

        // POST: Articuloes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var articulo = await _context.Articulos.FindAsync(id);
            if (articulo != null)
            {
                _context.Articulos.Remove(articulo);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ArticuloExists(int id)
        {
            return _context.Articulos.Any(e => e.Id == id);
        }
    }
}
