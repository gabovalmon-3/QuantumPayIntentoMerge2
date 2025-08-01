using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApp.Pages.ClientesPages
{
    [Authorize(Roles = "Cliente")]
    public class AgregarCuentaModel : PageModel
    {
        [BindProperty(SupportsGet = true)]
        public int ClienteId { get; set; }

        public void OnGet()
        {
            if (ClienteId == 0)
            {
                ClienteId = 1;
            }
        }
    }
}
