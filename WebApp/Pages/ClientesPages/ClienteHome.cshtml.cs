using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApp.Pages.Clientes
{
    [Authorize(Roles = "Cliente")]
    public class ClienteHomeModel : PageModel
    {
        [BindProperty(SupportsGet = true)]
        public int ClienteId { get; set; }

        [BindProperty(SupportsGet = true)]
        public string ClienteEmail { get; set; }

        public void OnGet()
        {
            // Permite recibir los parámetros por querystring cuando se navega
            // directamente a la página. Si no vienen, usa valores predeterminados
            // para evitar que las tablas de DataTables consulten con ID 0.
            if (ClienteId == 0)
            {
                ClienteId = 1;
            }

            if (string.IsNullOrWhiteSpace(ClienteEmail))
            {
                ClienteEmail = "cliente@example.com";
            }
        }
    }
}
