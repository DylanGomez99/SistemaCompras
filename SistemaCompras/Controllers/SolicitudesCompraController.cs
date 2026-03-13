using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SistemaCompras.Data;
using SistemaCompras.Models;
using SistemaCompras.ViewModels;

namespace SistemaCompras.Controllers
{
    public class SolicitudesCompraController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SolicitudesCompraController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var solicitudes = await _context.SolicitudesCompra
                .Include(s => s.Empleado)
                .OrderByDescending(s => s.FechaSolicitud)
                .ToListAsync();

            return View(solicitudes);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var solicitud = await _context.SolicitudesCompra
                .Include(s => s.Empleado)
                .Include(s => s.Detalles)
                    .ThenInclude(d => d.Articulo)
                .Include(s => s.Detalles)
                    .ThenInclude(d => d.UnidadMedida)
                .FirstOrDefaultAsync(s => s.Id == id);

            if (solicitud == null) return NotFound();

            return View(solicitud);
        }

        public IActionResult Create()
        {
            var vm = new SolicitudCompraCreateViewModel
            {
                Empleados = new SelectList(_context.Empleados, "Id", "Nombre"),
                Articulos = new SelectList(_context.Articulos, "Id", "Nombre"),
                UnidadesMedida = new SelectList(_context.UnidadesMedida, "Id", "Nombre"),
                Detalles = new List<SolicitudCompraDetalleInputModel>
                {
                    new SolicitudCompraDetalleInputModel()
                }
            };

            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(SolicitudCompraCreateViewModel vm)
        {
            vm.Detalles = vm.Detalles
                .Where(d => d.ArticuloId > 0 && d.UnidadMedidaId > 0 && d.Cantidad > 0)
                .ToList();

            if (!vm.Detalles.Any())
            {
                ModelState.AddModelError("", "Debe agregar al menos un artículo.");
            }

            if (ModelState.IsValid)
            {
                var solicitud = new SolicitudCompra
                {
                    FechaSolicitud = DateTime.Now,
                    EmpleadoId = vm.EmpleadoId,
                    Estado = vm.Estado,
                    Detalles = vm.Detalles.Select(d => new DetalleSolicitudCompra
                    {
                        ArticuloId = d.ArticuloId,
                        UnidadMedidaId = d.UnidadMedidaId,
                        Cantidad = d.Cantidad
                    }).ToList()
                };

                _context.SolicitudesCompra.Add(solicitud);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            vm.Empleados = new SelectList(_context.Empleados, "Id", "Nombre", vm.EmpleadoId);
            vm.Articulos = new SelectList(_context.Articulos, "Id", "Nombre");
            vm.UnidadesMedida = new SelectList(_context.UnidadesMedida, "Id", "Nombre");

            return View(vm);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var solicitud = await _context.SolicitudesCompra
                .Include(s => s.Empleado)
                .FirstOrDefaultAsync(s => s.Id == id);

            if (solicitud == null) return NotFound();

            return View(solicitud);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var solicitud = await _context.SolicitudesCompra
                .Include(s => s.Detalles)
                .FirstOrDefaultAsync(s => s.Id == id);

            if (solicitud != null)
            {
                _context.DetallesSolicitudCompra.RemoveRange(solicitud.Detalles);
                _context.SolicitudesCompra.Remove(solicitud);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }
    }
}