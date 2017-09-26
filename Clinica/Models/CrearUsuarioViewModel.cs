using DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace Clinica.Models
{
    public class CrearUsuarioViewModel
    {
        public string Usuario { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string TipoDocumento { get; set; }

        [DisplayFormat(DataFormatString = "{0:0.#}", ApplyFormatInEditMode = true)]
        public decimal NumeroDocumento { get; set; }
        public string Direccion { get; set; }

        [DisplayFormat(DataFormatString = "{0:0.#}", ApplyFormatInEditMode = true)]
        public decimal Telefono { get; set; }
        public string Mail { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime FechaNacimiento { get; set; }

        [MaxLength(1)]
        public string Sexo { get; set; }

        public string Descripcion { get; set; }

       public CrearUsuarioViewModel() { }

        public CrearUsuarioViewModel(IEnumerable<Rol> Rol)
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