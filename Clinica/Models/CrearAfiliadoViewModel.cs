using DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Clinica.Models
{
    public class CrearAfiliadoViewModel
    {
        //DE TABLA USUARIO
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

        //DE TABLA AFILIADO
        public string Estado_Civil { get; set; }

        public decimal Cantidad_Hijos { get; set; }

        ////¿Revisar si este va o no?
        //public decimal Plan_Codigo { get; set; }

        public CrearAfiliadoViewModel() { }

        public CrearAfiliadoViewModel(IEnumerable<PlanAfiliado> PlanAfiliados)
        {
            Planes = PlanAfiliados.Select(x => new SelectListItem()
            {
                Value = x.Codigo_Plan.ToString(),
                Text = x.Descripcion
            });

        }

        public IEnumerable<SelectListItem> Planes { get; set; }

        public int PlanSeleccionado { get; set; }


    }
}