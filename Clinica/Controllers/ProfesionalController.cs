using Clinica.Models;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Clinica.Controllers
{
    public class ProfesionalController : Controller
    {
        public ProfesionalDAO _profesionalDAO;
        private ClinicaNetDBEntities context;

        public ProfesionalController()
        {
            _profesionalDAO = new ProfesionalDAO();
            context = new ClinicaNetDBEntities();
        }
        // GET: Profesional
        public ActionResult Index()
        {
            var listadoDeProfesionales = _profesionalDAO.ListadoDeProfesionales();
          
            return View(listadoDeProfesionales);
        }

        // GET: Profesional/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Profesional/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Profesional/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Profesional/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Profesional/Edit/5
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

        // GET: Profesional/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Profesional/Delete/5
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
