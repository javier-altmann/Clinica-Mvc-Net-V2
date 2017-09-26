using Clinica.Models;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Clinica.Controllers
{
    public class AfiliadoController : Controller
    {

        public AfiliadoDAO _afiliadosDAO;
        private ClinicaNetDBEntities context;

        public AfiliadoController()
        {
            _afiliadosDAO = new AfiliadoDAO();
            context = new ClinicaNetDBEntities();
        }



        // GET: Afiliado
        public ActionResult Index()
        {
            return View();
        }

        // GET: Afiliado/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Afiliado/Create
        public ActionResult Create()
        {
            var model = new CrearAfiliadoViewModel(_afiliadosDAO.listadoDePlanes());
            return View(model);
        }

        // POST: Afiliado/Create
        [HttpPost]
        public ActionResult Create(CrearAfiliadoViewModel model)
        {

            try
            {
                _afiliadosDAO.crearAfiliado(new Afiliado()
                {
                    Estado_Civil = model.Estado_Civil,
                    Cantidad_Hijos = model.Cantidad_Hijos,
                    Plan_Codigo = model.PlanSeleccionado

                }, new Usuario()
                {
                    Nombre = model.Nombre,
                    Apellido = model.Apellido,
                    Tipo_Documento = model.TipoDocumento,
                    Numero_Documento = model.NumeroDocumento,
                    Direccion = model.Direccion,
                    Telefono = model.Telefono,
                    Mail = model.Mail,
                    Fecha_Nac = model.FechaNacimiento,
                    Sexo = model.Sexo,

                });
                
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }

        }
        

        // GET: Afiliado/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Afiliado/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Afiliado/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Afiliado/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
