using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class UsuariosDAO 
    {
        private ClinicaNetDBEntities context;

        public UsuariosDAO()
        {
            context = new ClinicaNetDBEntities();
        }


        public ICollection<Rol> recuperarRoles(List<int> listadoElegido)
        {
            var roles = context.Rols.Where(x => listadoElegido.Contains(x.Id_Rol)).ToList();
            return roles;
        }

        public void CrearUsuario(ICollection<Rol> rol,LoginUsuario userLogin /*Usuario user*/)
        {
          
            LoginUsuario login = new LoginUsuario
            {
                Username = userLogin.Username,
                Password = userLogin.Password,  
                Rols = rol
            };

            //Usuario usuario = new Usuario
            //{
            //    Id_Usuario = login.Id_Usuario,
            //    Nombre = user.Nombre,
            //    Apellido = user.Apellido,
            //    Tipo_Documento = user.Tipo_Documento,
            //    Numero_Documento = user.Numero_Documento,
            //    Direccion = user.Direccion,
            //    Telefono = user.Telefono,
            //    Mail = user.Mail,
            //    Fecha_Nac = user.Fecha_Nac,
            //    Sexo = user.Sexo,
            //    LoginUsuario = login
            //};

            //  context.Usuario.Add(usuario);

            context.LoginUsuarios.Add(login);
            context.SaveChanges();
            
        }

        public void EditarUsuario(ICollection<Rol> rol, LoginUsuario userLogin, Usuario user) {
            Usuario idUsuarioAEditar = context.Usuarios.Where(x => x.Id_Usuario == user.Id_Usuario).FirstOrDefault();

            if(idUsuarioAEditar != null)
            {
                LoginUsuario login = new LoginUsuario
                {
                    Username = userLogin.Username,
                    Password = userLogin.Password,
                    Rols = rol
                };



                idUsuarioAEditar.Id_Usuario = login.Id_Usuario;
                idUsuarioAEditar.Nombre = user.Nombre;
                idUsuarioAEditar.Apellido = user.Apellido;
                idUsuarioAEditar.Tipo_Documento = user.Tipo_Documento;
                idUsuarioAEditar.Numero_Documento = user.Numero_Documento;
                idUsuarioAEditar.Direccion = user.Direccion;
                idUsuarioAEditar.Telefono = user.Telefono;
                idUsuarioAEditar.Mail = user.Mail;
                idUsuarioAEditar.Fecha_Nac = user.Fecha_Nac;
                idUsuarioAEditar.Sexo = user.Sexo;
                idUsuarioAEditar.LoginUsuario = login;
              
                context.SaveChanges();
            }


        }
        public IEnumerable<Rol> listadoDeRoles()
        {

            var roles = context.Rols.ToList();

            return roles;
        }


    }
}
