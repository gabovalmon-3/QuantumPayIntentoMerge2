using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApp.Pages.ClientesPages
{
    [Authorize(Roles = "Cliente")]
    public class NuevaTransaccionModel : PageModel
    {
        [BindProperty(SupportsGet = true)]
        public int ClienteId { get; set; }

        [BindProperty(SupportsGet = true)]
        public string Email { get; set; } = string.Empty;

        public void OnGet()
        {
            if (ClienteId == 0)
            {
                ClienteId = 1;
            }
        }
    }
}
