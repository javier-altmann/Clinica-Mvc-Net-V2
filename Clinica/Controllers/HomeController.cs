using Clinica.Models;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static DAL.RolDao;

namespace Clinica.Controllers
{
    public class HomeController : Controller
    {

        private LoginUsuarioDAO dao; //se declara 

        private RolesDao rol;
        

        public HomeController()
        {
            dao = new LoginUsuarioDAO();
            rol =  new RolesDao();
      
            
        }
        public ActionResult Login()
        {

            return View(new LoginViewModel());
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel model)
        {
            string vista = null;

            var existeUsuario = dao.Login(model.Username, model.Password);

            if (existeUsuario == false)
            {
                ViewBag.Message = "El usuario no existe";
                vista = "Login";
            }
            else
            {
                Session["Username"] = model.Username; //esto hace que se guarde en sesion el nombre del username que se logueo correctamente
                //return RedirectToAction("ListaLogin");//lleva a otra vista 
                return RedirectToAction("CheckRoles");


            }

            return View(vista);
        }

        public ActionResult ListaLogin()
        {

            var listaDeUsuarios = dao.ListarUsuarios();
            //ahora hay que convertir la lista que traje del dao a una lista de viewmodels
            var model = listaDeUsuarios.Select(x => new LoginViewModel()
            {
                Username = x.Username,
                Password = x.Password
            });

            return View(model);

        }

        public ActionResult CheckRoles()
        {
            var valorRoles = rol.ChequearRol(Session["Username"].ToString());
            var model = new CheckRolesViewModel(valorRoles);
            


            return View(model);
        }


        [HttpGet]
        public ActionResult RedireccionarSegunRol()
        {
            
            return View();
        }

        [HttpPost]
        public ActionResult RedireccionarSegunRol(CheckRolesViewModel modelo)
        {
            int id_rol = (int.Parse(modelo.RolSeleccionado));

            if (id_rol == 1)
            {
                return View("AdministradorGeneral");
            }
            else if(id_rol == 2)
            {
                return View("Afiliado");
            }
            else if(id_rol == 3)
            {
                return View("Profesional");
            }
            else
            {
                return View("Administrativo");
            }
            
            
           
        }



        public ActionResult Index()
        {
         
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}