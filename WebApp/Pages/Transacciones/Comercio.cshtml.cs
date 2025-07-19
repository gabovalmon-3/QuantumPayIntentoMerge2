using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApp.Pages.Transacciones
{
    public class ComercioModel : PageModel
    {
        [BindProperty(SupportsGet = true)]
        public int IdComercio { get; set; }

        public void OnGet() { }
    }
}
