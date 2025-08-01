using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{
    public class Admin : BaseDTO
    {
        public string nombreUsuario { get; set; }
        public string contrasena { get; set; }

        public void AprobarSolicitudInstitucionBancaria()
        {
            //Definir comision
        }

        public void AprobarSolicitudComercio()
        {
            //Definir comision
        }



    }
}
