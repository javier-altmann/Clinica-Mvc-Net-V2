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
    
    public partial class Compra
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Compra()
        {
            this.BonoConsulta = new HashSet<BonoConsulta>();
            this.BonoFarmacia = new HashSet<BonoFarmacia>();
        }
    
        public decimal Id_Compra { get; set; }
        public Nullable<decimal> Total { get; set; }
        public Nullable<int> Cantidad { get; set; }
        public Nullable<System.DateTime> Fecha { get; set; }
        public Nullable<decimal> Plan_Codigo { get; set; }
        public Nullable<int> Usuario_Id { get; set; }
    
        public virtual Afiliado Afiliado { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BonoConsulta> BonoConsulta { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BonoFarmacia> BonoFarmacia { get; set; }
        public virtual PlanAfiliado PlanAfiliado { get; set; }
    }
}
