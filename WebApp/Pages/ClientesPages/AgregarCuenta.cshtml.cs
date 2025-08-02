// WebApp/Pages/ClientesPages/AgregarCuenta.cshtml.cs
using CoreApp;
using DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApp.Pages.ClientesPages
{
    public class AgregarCuentaModel : PageModel
    {
        private readonly ClienteManager _clienteManager;

        // Permite enlazarse en GET (si quisieras pasar ?clienteId=123)
        [BindProperty(SupportsGet = true)]
        public int ClienteId { get; set; }

        public string ClienteEmail { get; private set; }

        public AgregarCuentaModel()
        {
            _clienteManager = new ClienteManager();
        }

        public IActionResult OnGet()
        {
            // 1) Obtiene el correo del usuario autenticado
            ClienteEmail = User.Identity?.Name;
            if (string.IsNullOrWhiteSpace(ClienteEmail))
            {
                // No hay usuario autenticado
                return RedirectToPage("/Account/Login");
            }

            // 2) Busca al cliente por correo
            var cliente = _clienteManager.RetrieveByEmail(ClienteEmail);
            if (cliente == null)
            {
                // Usuario autenticado no corresponde a un cliente en la DB
                return RedirectToPage("/Error");
            }

            // 3) Inyecta el ID de cliente para el formulario
            ClienteId = cliente.IdCliente;

            return Page();
        }
    }
}
