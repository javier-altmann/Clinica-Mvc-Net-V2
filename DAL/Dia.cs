//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DAL
{
    using System;
    using System.Collections.Generic;
    
    public partial class Dia
    {
        public int Id_Dia { get; set; }
        public string Dia1 { get; set; }
        public System.TimeSpan Horario_Inicio { get; set; }
        public System.TimeSpan Horario_Fin { get; set; }
        public int Agenda_Id { get; set; }
    
        public virtual Agenda Agenda { get; set; }
    }
}
