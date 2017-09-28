using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class ProfesionalDAO
    {
        private ClinicaNetDBEntities context;

        public ProfesionalDAO()
        {
            context = new ClinicaNetDBEntities();
        }

        //public IEnumerable<Object> ListadoDeProfesionales()
        //{
        //    var listadoDeProfesionales = from c in context.Usuarios
        //                 from p in context.Profesionals
        //                 where c.Id_Usuario == p.Usuario_Id
        //                 select new
        //                 {
        //                     c.Nombre,
        //                     c.Apellido,
        //                     c.Tipo_Documento,
        //                     c.Numero_Documento,
        //                     c.Direccion,
        //                     c.Telefono,
        //                     c.Mail,
        //                     c.Sexo,
        //                     p.Matricula,

        //                 };
        //    return listadoDeProfesionales.ToList();
        //}

        public IEnumerable<Usuario> ListadoDeProfesionales()
        {
            
            var query = context.Usuarios.Where(usuario => context.Profesionals.Any(prof => prof.Usuario_Id == usuario.Id_Usuario))
                .ToList();
                            
            return query;
        }
    }
}
