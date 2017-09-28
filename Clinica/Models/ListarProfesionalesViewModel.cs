using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Clinica.Models
{
    public class ListarProfesionalesViewModel
    {
        public int Id_usuario { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string TipoDocumento { get; set; }
        public int NumeroDocumento { get; set; }
        public string Direccion { get; set; }
        public int Telefono { get; set; }
        public string Mail { get; set; }
        public string Sexo { get; set; }
        public int Matricula { get; set; }

       
    }
}