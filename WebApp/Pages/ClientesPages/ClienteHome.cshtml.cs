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
        }
    }
}
