﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class UsuariosDAO 
    {
        private ClinicaNetDBEntities1 context;
     

        public UsuariosDAO()
        {
            context = new ClinicaNetDBEntities1();
        }

       
        public ICollection<Rol> recuperarRoles(List<int> listadoElegido)
        {
            var roles = context.Rol.Where(x => listadoElegido.Contains(x.Id_Rol)).ToList();
            return roles;
        }

        public void CrearUsuario(ICollection<Rol> rol,LoginUsuario userLogin)
        {
          
            LoginUsuario login = new LoginUsuario
            {
                Username = userLogin.Username,
                Password = userLogin.Password,  
                Rol = rol
            };

            context.LoginUsuario.Add(login);
            context.SaveChanges();

            
            
        }

        public void EditarUsuario(ICollection<Rol> rol, LoginUsuario userLogin) {
            LoginUsuario idUsuarioAEditar = context.LoginUsuario.Where(x => x.Id_Usuario == userLogin.Id_Usuario)
                                            .FirstOrDefault();

            if(idUsuarioAEditar != null)
            {

                idUsuarioAEditar.Username = userLogin.Username;
                idUsuarioAEditar.Password = userLogin.Password;
                idUsuarioAEditar.Rol = rol;

                context.SaveChanges();
            }


        }
        public IEnumerable<Rol> listadoDeRoles()
        {

            var roles = context.Rol.ToList();

            return roles;
        }


        public IEnumerable<Rol> listadoDeRolesPorUsuario(int id)
        {

            var roles = context.Rol.Where(x => x.Id_Rol == id).ToList();
            
            return roles;
        }

        public List<LoginUsuario> ListadoUsuarioxRoles()
        {

            var query = context.LoginUsuario.ToList();
            

            return query;
        }


        public List<LoginUsuario> ListadoRolesXUsuarios(int id)
        {

            var query = context.LoginUsuario.Where(x => x.Id_Usuario == id).ToList();


            return query;
        }

        public void EliminarUsuario(int id, ICollection<Rol> rol, LoginUsuario userLogin)
        {
            var idUsuarioAEliminar = context.LoginUsuario.Where(x => x.Id_Usuario == id).FirstOrDefault();

            if (idUsuarioAEliminar != null)
            {
                idUsuarioAEliminar.Usuario = userLogin.Usuario;
                idUsuarioAEliminar.Password = userLogin.Password;
                idUsuarioAEliminar.Rol = rol;

                context.LoginUsuario.Remove(idUsuarioAEliminar);    
            }


        }


    }
}
