using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{
    public class Comercio : BaseDTO
    {
        public string Nombre { get; set; }
        public int IdCuenta { get; set; }

        public void VerTransacciones() 
        { 
        }
        public void OfrecerDescuentos() 
        {
        }
    }
}
