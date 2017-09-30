using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Clinica.Models
{
    public class ListarUsuariosxRolesViewModel
    {
        public int Id_usuario { get; set; }
        public string Username { get; set; }
        //public ICollection<Rol> rol;
        public IEnumerable<string> Descripcion;

    }
}