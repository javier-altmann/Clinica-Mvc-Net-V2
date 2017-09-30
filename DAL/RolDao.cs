using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class RolDao//mandarle public si usamos desde controller
    {

        public class RolesDao : BaseDAO<Rol>
        {
            public RolesDao() : base() //constructor que hereda de base.dao . es un contructor que se utiliza para cuando se hace un new loginusuariodao
            {

            }
            public IEnumerable<Rol> ChequearRol(string username)//es una lista de ienumerables de la tabla Rol
            {
                //filtrar los usuarios para saber cual es el que esta en sesion por el logueo
                var query = _context.Set<LoginUsuario>()
                .Single(x => x.Username == username);

                var roles = query.Rol;
               
                return roles;

            }

        }
    }
}