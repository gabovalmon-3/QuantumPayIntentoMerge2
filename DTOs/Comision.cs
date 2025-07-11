using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{
    public class Comision : BaseDTO
    {
        public int IdInstitucionBancaria { get; set; }
        public int? IdCuentaComercio { get; set; }  // null = comisión general de banco
        public decimal Porcentaje { get; set; }     // ej. 0.015 = 1.5%
        public decimal MontoMaximo { get; set; }    // tope en moneda local
    }
}