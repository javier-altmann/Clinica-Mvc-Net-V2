using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Clinica.Models
{
    public class CheckRolesViewModel 
    {
        public IEnumerable<SelectListItem> RolesAsignados { get; set; }//esto es para hacer una lista de opciones del combo

        public CheckRolesViewModel(IEnumerable<Rol> Roles)
        {
            RolesAsignados = Roles.Select(x => new SelectListItem()
            {
                Value = x.Id_Rol.ToString(),
                Text = x.Descripcion
            });




        }
    }

}
