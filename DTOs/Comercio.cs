using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{
    public class CuentaComercio
    {
        public int IdCuenta { get; set; }
        public string NombreUsuario { get; set; }
        public string Contrasena { get; set; }
    }
    public class Comercio : BaseDTO
    {
        public string Nombre { get; set; }
        public string CedulaJuridica { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string CorreoElectronico { get; set; }

        public int IdCuenta { get; set; }
        public CuentaComercio Cuenta { get; set; }

        public void RegistrarComercio()
        {
        }

        public void IniciarSesion()
        {
        }

        public void VerTransacciones() 
        { 
        }
        public void OfrecerDescuentos() 
        {
        }
    }
}
