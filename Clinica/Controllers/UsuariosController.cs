using Clinica.Models;
using DAL;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Clinica.Controllers
{
    public class UsuariosController : Controller
    {
        public UsuariosDAO _usuariosDAO;
        private ClinicaNetDBEntities1 context;

        public UsuariosController()
        {
            _usuariosDAO = new UsuariosDAO();
            context = new ClinicaNetDBEntities1();
        }

        // GET: Usuarios
        public async Task<ActionResult> Index(int? pagina)
        {
            int tamañoDePagina = 10;
            int numeroPagina = pagina ?? 1;

            var listado = await Task.Run(() => MapearViewModelListadoDeUsuarios());
            return View(listado.OrderBy(p => p.Id_usuario).ToPagedList(numeroPagina, tamañoDePagina));
        }
     
        public  List<ListarUsuariosxRolesViewModel> MapearViewModelListadoDeUsuarios() {
            var model = _usuariosDAO.ListadoUsuarioxRoles();

            var listado = new List<ListarUsuariosxRolesViewModel>();

            foreach (var item in model)
            {

                listado.Add(new ListarUsuariosxRolesViewModel()
                {
                    Id_usuario = item.Id_Usuario,
                    Descripcion = item.Rol.Select(prueba => prueba.Descripcion),
                    Username = item.Username


                });

            }
            return listado;
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
                    Rol = rol
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
            
            var model = _usuariosDAO.ListadoRolesXUsuarios(id);
            
            var listaDeRolesParaMultiSelect = new EditarUsuarioViewModel();
            var listadoDeRoles = new List<SelectListItem>();

            //MI LISTA DE ROLES CORRESPONDIENTES AL USUARIO 
            IEnumerable<Rol> roles = _usuariosDAO.ListadoRolesXUsuarios(id).First().Rol;

            //MI LISTA COMPLETA DE ROLES
           IEnumerable<Rol> rolesUsuario = _usuariosDAO.listadoDeRoles();

            foreach (var rol in rolesUsuario)
            {
                var selected = roles.Any(ru => ru.Id_Rol == rol.Id_Rol);
                //var selected = _rolesID.Any(ru => ru.Id_Rol == rol.Id_Rol);


                listadoDeRoles.Add(new SelectListItem
                {
                    Selected = selected,
                    Text = rol.Descripcion,
                    Value = rol.ToString()
                        
            });

            }

            listaDeRolesParaMultiSelect.Roles = listadoDeRoles;



            return View(listaDeRolesParaMultiSelect);
        }

        // POST: Usuarios/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, EditarUsuarioViewModel model)
        {
            
                
                var rol = _usuariosDAO.recuperarRoles(model.RolSeleccionado);
                try
                {
                _usuariosDAO.EditarUsuario(rol, new LoginUsuario()
                {
                    Id_Usuario = id,
                    Username = model.Usuario,
                    Password = model.Password,
                    Rol = rol
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
            var model = new EliminarUsuarioViewModel(_usuariosDAO.listadoDeRolesPorUsuario(id));

            return View(model);
        }

        // POST: Usuarios/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, EliminarUsuarioViewModel model)
        {
            //var rol = _usuariosDAO.recuperarRoles(model.RolSeleccionado);

            try
            {
                //_usuariosDAO.EliminarUsuario(id, rol, new LoginUsuario()
                //{
                //    Id_Usuario = id,
                //    Username = model.Usuario,
                //    Password = model.Password,
                //    Rol = rol
                //});

                    return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
