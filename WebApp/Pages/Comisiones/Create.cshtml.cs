using BaseManager;
using DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApp.Pages.Comisiones
{
    public class CreateModel : PageModel
    {
        private readonly ComisionManager _mgr;

        [BindProperty]
        public Comision Input { get; set; }

        public CreateModel(ComisionManager mgr) => _mgr = mgr;

        public void OnGet(int? editId)
        {
            Input = editId.HasValue
                ? _mgr.Obtener(editId.Value)
                : new Comision();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
                return Page();

            if (Input.Id > 0) _mgr.Actualizar(Input);
            else _mgr.Create(Input);

            return RedirectToPage("Index");
        }
    }
}
