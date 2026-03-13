using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SistemaCompras.Data;
using SistemaCompras.Models;
using SistemaCompras.ViewModels;

namespace SistemaCompras.Controllers
{
    public class OrdenesCompraController : Controller
    {
        private readonly ApplicationDbContext _context;

        public OrdenesCompraController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var ordenes = await _context.OrdenesCompra
                .Include(o => o.Proveedor)
                .Include(o => o.SolicitudCompra)
                .OrderByDescending(o => o.FechaOrden)
                .ToListAsync();

            return View(ordenes);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var orden = await _context.OrdenesCompra
                .Include(o => o.Proveedor)
                .Include(o => o.SolicitudCompra)
                .Include(o => o.Detalles)
                    .ThenInclude(d => d.Articulo)
                .Include(o => o.Detalles)
                    .ThenInclude(d => d.UnidadMedida)
                .Include(o => o.Detalles)
                    .ThenInclude(d => d.Marca)
                .FirstOrDefaultAsync(o => o.Id == id);

            if (orden == null) return NotFound();

            return View(orden);
        }

        public IActionResult Create()
        {
            var vm = new OrdenCompraCreateViewModel
            {
                NumeroOrden = $"OC-{DateTime.Now:yyyyMMddHHmmss}",
                Proveedores = new SelectList(_context.Proveedores, "Id", "Nombre"),
                Solicitudes = new SelectList(_context.SolicitudesCompra, "Id", "Id"),
                Articulos = new SelectList(_context.Articulos, "Id", "Nombre"),
                UnidadesMedida = new SelectList(_context.UnidadesMedida, "Id", "Nombre"),
                Marcas = new SelectList(_context.Marcas, "Id", "Nombre"),
                Detalles = new List<OrdenCompraDetalleInputModel>
                {
                    new OrdenCompraDetalleInputModel()
                }
            };

            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(OrdenCompraCreateViewModel vm)
        {
            vm.Detalles = vm.Detalles
                .Where(d => d.ArticuloId > 0 && d.UnidadMedidaId > 0 && d.MarcaId > 0 && d.Cantidad > 0)
                .ToList();

            if (!vm.Detalles.Any())
            {
                ModelState.AddModelError("", "Debe agregar al menos un artículo.");
            }

            if (ModelState.IsValid)
            {
                var orden = new OrdenCompra
                {
                    NumeroOrden = vm.NumeroOrden,
                    FechaOrden = DateTime.Now,
                    Estado = vm.Estado,
                    ProveedorId = vm.ProveedorId,
                    SolicitudCompraId = vm.SolicitudCompraId,
                    Detalles = vm.Detalles.Select(d => new DetalleOrdenCompra
                    {
                        ArticuloId = d.ArticuloId,
                        UnidadMedidaId = d.UnidadMedidaId,
                        MarcaId = d.MarcaId,
                        Cantidad = d.Cantidad,
                        CostoUnitario = d.CostoUnitario
                    }).ToList()
                };

                _context.OrdenesCompra.Add(orden);

                if (vm.SolicitudCompraId.HasValue)
                {
                    var solicitud = await _context.SolicitudesCompra.FindAsync(vm.SolicitudCompraId.Value);
                    if (solicitud != null)
                    {
                        solicitud.Estado = "Atendida";
                    }
                }

                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            vm.Proveedores = new SelectList(_context.Proveedores, "Id", "Nombre", vm.ProveedorId);
            vm.Solicitudes = new SelectList(_context.SolicitudesCompra, "Id", "Id", vm.SolicitudCompraId);
            vm.Articulos = new SelectList(_context.Articulos, "Id", "Nombre");
            vm.UnidadesMedida = new SelectList(_context.UnidadesMedida, "Id", "Nombre");
            vm.Marcas = new SelectList(_context.Marcas, "Id", "Nombre");

            return View(vm);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var orden = await _context.OrdenesCompra
                .Include(o => o.Proveedor)
                .FirstOrDefaultAsync(o => o.Id == id);

            if (orden == null) return NotFound();

            return View(orden);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var orden = await _context.OrdenesCompra
                .Include(o => o.Detalles)
                .FirstOrDefaultAsync(o => o.Id == id);

            if (orden != null)
            {
                _context.DetallesOrdenCompra.RemoveRange(orden.Detalles);
                _context.OrdenesCompra.Remove(orden);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }
    }
}