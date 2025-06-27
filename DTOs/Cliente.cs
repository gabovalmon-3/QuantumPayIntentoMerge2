using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{
    public class Cliente : BaseDTO
    {
        public string cedula { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public int telefono { get; set; }
        public string direccion { get; set; }
        public string fotoCedula { get; set; }
        public DateOnly fechaNacimiento { get; set; }
        public string fotoPerfil { get; set; }
        public string contrasena { get; set; }
        public string IBAN { get; set; }
    }
}
