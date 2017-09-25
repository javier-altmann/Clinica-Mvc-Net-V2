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

        public void CrearUsuario(LoginUsuario userLogin, Usuario user)
        {            
          
            LoginUsuario login = new LoginUsuario
            {
                Username = userLogin.Username,
                Password = userLogin.Password            
            };

            Usuario usuario = new Usuario
            {
                Id_Usuario = login.Id_Usuario,
                Nombre = user.Nombre,
                Apellido = user.Apellido,
                Tipo_Documento = user.Tipo_Documento,
                Numero_Documento = user.Numero_Documento,
                Direccion = user.Direccion,
                Telefono = user.Telefono,
                Mail = user.Mail,
                Fecha_Nac = user.Fecha_Nac,
                Sexo = user.Sexo,
                LoginUsuario = login
            };

            context.Usuarios.Add(usuario);
            context.SaveChanges();
            
        }

        public IEnumerable<Rol> listadoDeRoles()
        {

            var roles = context.Rols.ToList();

            return roles;
        }


    }
}
