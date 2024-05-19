using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Dominio.Entidad.Negocios.Entidad;
using Infraestructura.Data.Negocios;

namespace POOII_EF_OscarAquise.Controllers
{
    public class MantenimientoController : Controller
    {
        herramientaDTO  _herramientaDTO   = new herramientaDTO();
        categoriaDTO    _categoriaDTO     =new categoriaDTO();

        //GetCrudHerramientas
        #region Consulta
        public ActionResult ConsultaHerramientas(int numberPage = 0, int categorias = 0)
        {
            var listado = _categoriaDTO.GetAll();
            var herramientas = _herramientaDTO.GetAllHerramientasCategoria(categorias);
            var cantidad = herramientas.Count();
            int rowsPerPage = 5;

            bool tieneResiduo = (cantidad % rowsPerPage == 0);
            int numberPages = (tieneResiduo) ? (cantidad / rowsPerPage) : (cantidad / rowsPerPage + 1);

            ViewBag.numberPage = numberPage;
            ViewBag.numberPages = numberPages;
            ViewBag.selectCategorias = new SelectList(listado, "IdCategoria", "NombreCategoria", categorias);
            ViewBag.mensaje = $"Cantidad de Herramientas: {cantidad}";

            return View(herramientas.Skip(rowsPerPage * numberPage).Take(rowsPerPage));
        }
        #endregion

        #region crearHerramienta
        public ActionResult CreateOscarAquise()
        {   
            var listado = _categoriaDTO.GetAll();
            ViewBag.selectCategoria = new SelectList(listado, "IdCategoria", "NombreCategoria");
            return View(new Herramienta());
        }
        [HttpPost]
        public ActionResult CreateOscarAquise(Herramienta nuevaHerramienta)
        {
            var listado = _categoriaDTO.GetAll();

            if (!ModelState.IsValid)
            {
                ViewBag.selectCategoria = new SelectList(listado, "IdCategoria", "NombreCategoria");
                return View(nuevaHerramienta);
            }

            ViewBag.mensaje = _herramientaDTO.Create(nuevaHerramienta);
            ViewBag.selectCategoria = new SelectList(listado, "IdCategoria", "NombreCategoria", nuevaHerramienta.IdCategoria);
            return View(nuevaHerramienta);
        }
        #endregion

        #region editarHerramienta
        public ActionResult EditOscarAquise(int id)
        {
            Herramienta herramienta = _herramientaDTO.Find(id);
            var listado = _categoriaDTO.GetAll();
            ViewBag.selectCategoria = new SelectList(listado, "IdCategoria", "NombreCategoria");
            return View(herramienta);
        }
        
        [HttpPost]
        public ActionResult EditOscarAquise(Herramienta herramienta)
        {
            var listado = _categoriaDTO.GetAll();

            if (!ModelState.IsValid)
            {
                ViewBag.selectCategoria = new SelectList(listado, "IdCategoria", "NombreCategoria");
                return View(herramienta);
            }

            ViewBag.mensaje = _herramientaDTO.Update(herramienta);
            ViewBag.selectCategoria = new SelectList(listado, "IdCategoria", "NombreCategoria", herramienta.IdCategoria);
            return View(herramienta);
        }
        #endregion

        #region detalleHerramienta
        public ActionResult DetailsOscarAquise(int? id)
        {
            if (id == null)
                return RedirectToAction("ConsultaHerramientas");

            Herramienta herramienta = _herramientaDTO.Find(id.Value);
            return View(herramienta);
        }



        #endregion

        #region eliminarHerramienta
        public ActionResult DeleteOscarAquise(int? id)
        {
            if (id == null)
                return RedirectToAction("ConsultaHerramientas");

            ViewBag.mensajeEliminar = _herramientaDTO.Delete(id.Value);
            TempData["MensajeEliminacion"] = $"La Herramienta con el ID {id} ha sido eliminada.";
            return RedirectToAction("ConsultaHerramientas");
        }



        #endregion


    }
}