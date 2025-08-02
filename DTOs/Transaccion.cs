// 1_DTOs/DTOs/Transaccion.cs
using System;

namespace DTOs
{
    public class Transaccion : BaseDTO
    {
        public int Id { get; set; }
        public int IdCuentaCliente { get; set; }
        public int IdCuentaBancaria { get; set; }
        public string IBAN { get; set; }
        public int IdCuentaComercio { get; set; }
        public decimal Monto { get; set; }
        public decimal Comision { get; set; }
        public decimal DescuentoAplicado { get; set; }
        public DateTime Fecha { get; set; }
        public string MetodoPago { get; set; }
    }
}
