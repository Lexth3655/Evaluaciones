using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Parcial_1.DataAccess.Interfaces;
using Parcial_1.Models;

namespace Parcial_1.Controllers
{
    public class MarcasController : Controller
    {
        private readonly ApplicationDbContext _context;
        private IRepository<Marca> _marcaRepository;

       
        public MarcasController(IRepository<Marca> marcaRepository)
        {
            _marcaRepository = marcaRepository;
        }

        // GET: Marcas
        public async Task<IActionResult> Index()
        {
            var data = await _marcaRepository.GetAllAsync();
            return View(data);
        }

        // GET: Marcas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            var marca = await _marcaRepository.GetByIdAsync(id);
            if (marca == null)
            {
                return NotFound();
            }                      

            return View(marca);
        }

        // GET: Marcas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Marcas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("nombre_marca,id,fechaCreado,fechaModificado,activo")] Marca marca)
        {
            if (ModelState.IsValid)
            {
                await _marcaRepository.AgregarAsync(marca);             
                return RedirectToAction(nameof(Index));
            }
            return View(marca);
        }

        // GET: Marcas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            var model = new Marca();
            if (model == null)
            {
                return NotFound();
            }

            return View(model);
        }

        // POST: Marcas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("nombre_marca,id,fechaCreado,fechaModificado,activo")] Marca marca)
        {
            if (id != marca.id)
            {
                return BadRequest();
            }
            if (ModelState.IsValid)
            {
                try
                {
                    await _marcaRepository.ActualizarAsync(marca);                    
                }
                catch (Exception)
                {
                    if (await _marcaRepository.GetByIdAsync(id) == null)
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
            return View(marca);
        }

        // GET: Marcas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {

            var marca = await _marcaRepository.GetByIdAsync(id);
            if (marca == null)
            {
                return NotFound();
            }

            return View(marca);
        }

        // POST: Marcas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var aux = await _marcaRepository.EliminarAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
