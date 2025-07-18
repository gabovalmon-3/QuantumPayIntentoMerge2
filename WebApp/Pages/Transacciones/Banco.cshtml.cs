using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using BaseManager;
using DTOs;

namespace WebApp.Pages.Transacciones
{
    public class BancoModel : PageModel
    {
        private readonly TransaccionManager _mgr;
        public int IdBanco { get; private set; }
        public IList<Transaccion> Transacciones { get; private set; }

        public BancoModel(TransaccionManager mgr) => _mgr = mgr;

        public void OnGet(int idBanco)
        {
            IdBanco = idBanco;
            Transacciones = _mgr.ObtenerPorBanco(idBanco);
        }
    }
}