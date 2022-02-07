using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyAPI.src.Controllers;
using MyAPI.src.Model.Entities.User;
using System.Threading.Tasks;

namespace MyAPI.src.Views
{
    public class RegisterModel : PageModel
    {

        [BindProperty]
        public new UserInputModel User { get; set; }

        public UserController Controller = new UserController();


        public void OnGet()
        {
            
        }


        public async Task<ActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                if (Controller.IsEmailInUse(User.Email))
                {
                    return Controller.NoContent();
;                }
                else
                {

                    await Controller.InsertUser(User);

                    return RedirectToPage("/Index");
                }
            }
            else
            {
                return Page();
            }

        }

    }

}

