using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApp.Pages
{
    [AllowAnonymous]
    public class WelcomeModel : PageModel
    {
        public void OnGet()
        {
        }
    }
}
