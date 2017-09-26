using Clinica.Models;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Clinica.Controllers
{
    public class UsuariosController : Controller
    {
        public UsuariosDAO _usuariosDAO;
        private ClinicaNetDBEntities context;

        public UsuariosController()
        {
            _usuariosDAO = new UsuariosDAO();
            context = new ClinicaNetDBEntities();
        }

        // GET: Usuarios
        public ActionResult Index()
        {
            return View();
        }

        // GET: Usuarios/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Usuarios/Create
        public ActionResult Create()
        {
            var model = new CrearUsuarioViewModel(_usuariosDAO.listadoDeRoles());
            return View(model);
        }

        // POST: Usuarios/Create
        [HttpPost]
        public ActionResult Create(CrearUsuarioViewModel model)
        {
            LoginUsuario login = new LoginUsuario();
            var rol = _usuariosDAO.recuperarRoles(model.RolSeleccionado);
            try
            {
                _usuariosDAO.CrearUsuario(rol, new LoginUsuario()
                {
                    Username = model.Usuario,
                    Password = model.Password,
                    Rols = rol
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
                    Sexo = model.Sexo
                });

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {

                return View();
            }
        }

        // GET: Usuarios/Edit/5
        public ActionResult Edit(int id)
        {
            var model = new CrearUsuarioViewModel(_usuariosDAO.listadoDeRoles());
            return View(model);
        }

        // POST: Usuarios/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, CrearUsuarioViewModel model)
        {
            
                LoginUsuario login = new LoginUsuario();
                var rol = _usuariosDAO.recuperarRoles(model.RolSeleccionado);
                try
                {
                    _usuariosDAO.EditarUsuario(rol, new LoginUsuario()
                    {
                        Username = model.Usuario,
                        Password = model.Password,
                        Rols = rol
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
                        Sexo = model.Sexo
                    });


                    return RedirectToAction("Index");
                }
                catch
                {
                    return View();
                }

         }

    
        // GET: Usuarios/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Usuarios/Delete/5
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
