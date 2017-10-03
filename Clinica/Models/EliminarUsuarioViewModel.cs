using DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Clinica.Models
{
    public class EliminarUsuarioViewModel
    {
        public string Usuario { get; set; }

        [DataType(DataType.Password)]
        public string Password { get; set; }

        public EliminarUsuarioViewModel() { }

        public EliminarUsuarioViewModel(IEnumerable<Rol> Rol)
        {
            Roles = Rol.Select(x => new SelectListItem()
            {
                Value = x.Id_Rol.ToString(),
                Text = x.Descripcion
            });

        }

        public IEnumerable<SelectListItem> Roles { get; set; }

        public List<int> RolSeleccionado { get; set; }
    }
}