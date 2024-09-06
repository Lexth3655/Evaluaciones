using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Parcial_1.DataAccess.Interfaces;
using Parcial_1.Models;

namespace Parcial_1.Controllers
{
    public class VentasController : Controller
    {
        private readonly ApplicationDbContext _context;
        private IRepository<Venta> _ventaRepository;
        private IRepository<Vehiculo> _vehRepository;

        public VentasController(IRepository<Venta> ventaRepository, IRepository<Vehiculo> vehRepository)
        {
            _ventaRepository = ventaRepository;
            _vehRepository = vehRepository;
        }

        // GET: Ventas
        public async Task<IActionResult> Index()
        {
            var venta = await _ventaRepository.GetAllAsync();
            return View(venta);
        }

        // GET: Ventas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            var venta = await _ventaRepository.GetByIdAsync(id);
            if (venta == null) return BadRequest();
            return View(venta);
        }

        // GET: Ventas/Create
        public async Task<IActionResult> Create()
        {
            var vehiculo = await _vehRepository.GetAllAsync();
            ViewBag.vehiculo = new SelectList(vehiculo, "id", "modelo");
            return View();
        }

        // POST: Ventas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("totalVenta,cantidad,vehiculoID,id,fechaCreado,fechaModificado,activo")] Venta venta)
        {
            if (ModelState.IsValid)
            {
                await _ventaRepository.AgregarAsync(venta);
                return RedirectToAction(nameof(Index));
            }
            var vehiculo = await _vehRepository.GetAllAsync();
            ViewBag.vehiculo = new SelectList(vehiculo, "id", "modelo");
            return View(venta);
        }

        // GET: Ventas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var venta = await _context.Ventas.FindAsync(id);
            if (venta == null)
            {
                return NotFound();
            }
            var vehiculo = await _vehRepository.GetAllAsync();
            ViewBag.vehiculo = new SelectList(vehiculo, "id", "modelo");
            return View(venta);
        }

        // POST: Ventas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("totalVenta,cantidad,vehiculoID,id,fechaCreado,fechaModificado,activo")] Venta venta)
        {
            if (id != venta.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _ventaRepository.ActualizarAsync(venta);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (await _ventaRepository.GetByIdAsync(id) == null)
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
            var vehiculo = await _vehRepository.GetAllAsync();
            ViewBag.vehiculo = new SelectList(vehiculo, "id", "modelo", venta.vehiculoID);
            return View(venta);
        }

        // GET: Ventas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            var venta = await _ventaRepository.GetByIdAsync(id);
            if (venta == null)
            {
                return NotFound();
            }
            return View(venta);
        }

        // POST: Ventas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _ventaRepository.EliminarAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
