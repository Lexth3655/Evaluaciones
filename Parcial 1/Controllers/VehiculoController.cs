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
    public class VehiculoController : Controller
    {
        private readonly ApplicationDbContext _context;
        private IRepository<Vehiculo> _vehRepository;
        private IRepository<Marca> _marcaRepository;

        public VehiculoController(IRepository<Vehiculo> vehRepository, IRepository<Marca> marcaRepository)
        {
            _vehRepository = vehRepository;
            _marcaRepository = marcaRepository;
        }

        // GET: Vehiculo
        public async Task<IActionResult> Index()
        {
            var vehiculo = await _vehRepository.GetAllAsync();            
            return View(vehiculo);
        }

        // GET: Vehiculo/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            var vehiculo = await _vehRepository.GetByIdAsync(id);
            if (vehiculo == null) return BadRequest();
            return View(vehiculo);
        }

        // GET: Vehiculo/Create
        public async Task<IActionResult> Create()
        {
            var marca = await _marcaRepository.GetAllAsync();
            ViewBag.Marca = new SelectList(marca, "id", "nombre_marca");
            return View();
        }

        // POST: Vehiculo/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("modelo,anio,cantidadPuertas,marcaID,id,fechaCreado,fechaModificado,activo")] Vehiculo vehiculo)
        {
            if (ModelState.IsValid)
            {
                await _vehRepository.AgregarAsync(vehiculo);
                return RedirectToAction(nameof(Index));
            }
            var marca = await _marcaRepository.GetAllAsync();
            ViewBag.Marca = new SelectList(marca, "id", "nombre_marca");
            return View(vehiculo);
        }

        // GET: Vehiculo/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            var vehiculo = await _vehRepository.GetByIdAsync(id);
            if (vehiculo == null)
            {
                return NotFound();
            }

            var marca = await _marcaRepository.GetAllAsync();
            ViewBag.Marca = new SelectList(marca, "id", "nombre_marca", vehiculo.marcaID);          
            return View(vehiculo);
        }

        // POST: Vehiculo/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("modelo,anio,cantidadPuertas,marcaID,id,fechaCreado,fechaModificado,activo")] Vehiculo vehiculo)
        {
            if (id != vehiculo.id)
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _vehRepository.ActualizarAsync(vehiculo);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (await _vehRepository.GetByIdAsync(id)==null)
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
            var marca = await _marcaRepository.GetAllAsync();
            ViewBag.Marca = new SelectList(marca, "id", "nombre_marca", vehiculo.marcaID);
            return View(vehiculo);
        }

        // GET: Vehiculo/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            var vehiculo = await _vehRepository.GetByIdAsync(id);
            if (vehiculo == null)
            {
                return NotFound();
            }

            return View(vehiculo);
        }

        // POST: Vehiculo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _vehRepository.EliminarAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
