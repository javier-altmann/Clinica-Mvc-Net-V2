using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class LoginUsuarioDAO : BaseDAO<LoginUsuario>
    {
       public LoginUsuarioDAO() : base() //hereda de base.dao . es un contructor que se utiliza para cuando se hace un new loginusuariodao
        {

        }
        public bool Login(string username , string password)
        {
            return _context.Set<LoginUsuario>()
                .Any(x => x.Username == username && x.Password == password);
            
        }
        public IEnumerable<LoginUsuario> ListarUsuarios()
        {
            List<LoginUsuario> ListaUsuarios = new List<LoginUsuario>();
            foreach (var element in _context.Set<LoginUsuario>().ToList())
            {
                ListaUsuarios.Add(element);

            }
            return ListaUsuarios;
    }

    }
}
