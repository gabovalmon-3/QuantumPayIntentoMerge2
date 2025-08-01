using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{
    public class Transaccion : BaseDTO
    {
        public string IdCuentaBancaria { get; set; }

        public int IdCuentaComercio { get; set; }
        public decimal Monto { get; set; }
        public decimal Comision { get; set; }
        public decimal DescuentoAplicado { get; set; }
        public DateTime Fecha { get; set; }
        public string MetodoPago { get; set; }
    }
}