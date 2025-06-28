using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{
    public class InstitucionBancaria : BaseDTO
    {
        public int codigoIdentidad { get; set; }
        public int codigoIBAN { get; set; }
        public string cedulaJuridica { get; set; }
        public string direccionSedePrincipal { get; set; }
        public string telefono { get; set; }
        public string correoElectronico { get; set; }

        public void iniciarSesion()
        {
        }

        public void ofrecerDescuentos()
        { 
        }

        public void RegistrarInstitucionBancaria()
        {
        }

        public void verTransacciones()
        {
        }



    }
}
