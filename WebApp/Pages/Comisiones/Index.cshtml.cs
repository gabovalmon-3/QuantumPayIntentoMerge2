using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using BaseManager;
using DTOs;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApp.Pages.Comisiones
{
    public class IndexModel : PageModel
    {
        private readonly ComisionManager _mgr;
        public IList<Comision> Comisiones { get; private set; }

        public IndexModel(ComisionManager mgr) => _mgr = mgr;

        public void OnGet()
        {
            Comisiones = _mgr.Listar();
        }
    }
}
