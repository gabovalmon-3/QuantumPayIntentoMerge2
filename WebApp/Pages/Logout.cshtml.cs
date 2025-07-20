using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApp.Pages
{
    public class LogoutModel : PageModel
    {
        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            // Llama al endpoint de la API si es necesario
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToPage("/Login");
        }
    }
}
