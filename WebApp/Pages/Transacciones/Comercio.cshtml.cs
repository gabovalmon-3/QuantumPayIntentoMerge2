using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using BaseManager;
using DTOs;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApp.Pages.Transacciones
{
    public class ComercioModel : PageModel
    {
        private readonly TransaccionManager _mgr;
        public int IdComercio { get; private set; }
        public IList<Transaccion> Transacciones { get; private set; }

        public ComercioModel(TransaccionManager mgr) => _mgr = mgr;

        public void OnGet(int idComercio)
        {
            IdComercio = idComercio;
            Transacciones = _mgr.ObtenerPorComercio(idComercio);
        }
    }
}
