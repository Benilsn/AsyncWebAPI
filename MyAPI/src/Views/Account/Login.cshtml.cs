using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;

namespace MyAPI.src.Views.Account
{
    public class LoginModel : PageModel
    {

        public string Email { get; set; }
        public string Password { get; set; }

        public void OnGet()
        {

        }

        public async Task<ActionResult> OnPostAsync()
        {

            if (ModelState.IsValid)
            {
                return RedirectToPage("/Index");
            }
            return Page();

        }
    }
}
