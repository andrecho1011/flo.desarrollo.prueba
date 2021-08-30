using flo.desarrollo.prueba.datos;
using flo.desarrollo.prueba.entidades.Articulo;
using flo.desarrollo.prueba.entidades.Fabricante;
using flo.desarrollo.prueba.presentacion.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace flo.desarrollo.prueba.presentacion.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        public HomeController(AppDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// consulta y retorno de la lista de fabricantes de la B.D.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View(await _context.Fabricante.ToListAsync());
        }

        /// <summary>
        /// se utiliza region para agrupar metodos por tipo de transaccion
        /// </summary>
        /// <returns></returns>
        #region metodos create

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        /// <summary>
        /// Se guarda el registro en tabla Fabricante, que se recibe por parametro
        /// _context trae la conexion a la B.D
        /// </summary>
        /// <param name="fabricante"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Create(Fabricante fabricante)
        {
            if (ModelState.IsValid)
            {
                _context.Fabricante.Add(fabricante);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        #endregion


        #region detalle

        [HttpGet]
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var fabricante = _context.Fabricante.Find(id);
            if (fabricante == null)
            {
                return NotFound();
            }

            return View(fabricante);
        }

        #endregion

        #region editar

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var fabricante = _context.Fabricante.Find(id);
            if (fabricante == null)
            {
                return NotFound();
            }

            return View(fabricante);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Fabricante fabricante)
        {
            if (ModelState.IsValid)
            {
                _context.Fabricante.Update(fabricante);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(fabricante);
        }

        #endregion

        #region eliminar

        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var fabricante = _context.Fabricante.Find(id);
            if (fabricante == null)
            {
                return NotFound();
            }

            return View(fabricante);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteFabricante(int? id)
        {
            var fabricante = await _context.Fabricante.FindAsync(id);
            if (fabricante == null)
            {
                return NotFound();
            }

            _context.Fabricante.Remove(fabricante);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));

        }

        #endregion



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
