using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class AfiliadoDAO
    {
        private ClinicaNetDBEntities1 context;

        public AfiliadoDAO()
        {
            context = new ClinicaNetDBEntities1();
        }

        public void crearAfiliado(Afiliado affiliate, Usuario user)
        {
            Afiliado afiliado = new Afiliado
            {
                Estado_Civil = affiliate.Estado_Civil,
                Cantidad_Hijos = affiliate.Cantidad_Hijos,
                Plan_Codigo = affiliate.Plan_Codigo
                 
            };
            Usuario usuario = new Usuario
            {

                Nombre = user.Nombre,
                Apellido = user.Apellido,
                Tipo_Documento = user.Tipo_Documento,
                Numero_Documento = user.Numero_Documento,
                Direccion = user.Direccion,
                Telefono = user.Telefono,
                Mail = user.Mail,
                Fecha_Nac = user.Fecha_Nac,
                Sexo = user.Sexo,
                Afiliado = afiliado
            };

            context.Usuario.Add(usuario);

        }


        public IEnumerable<PlanAfiliado> listadoDePlanes()
        {

            var planes = context.PlanAfiliado.ToList();

            return planes;
        }

    }
}
