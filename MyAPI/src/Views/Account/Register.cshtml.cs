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
        public UserInputModel userInputModel { get; set; }
        private readonly UserController uc = new UserController();


        public void OnGet()
        {
        }

        public ActionResult OnPost()
        {
            var firstname = Request.Form["firstName"];
            var lastname = Request.Form["lastName"];
            var age = Request.Form["age"];
            var email = Request.Form["email"];
            var username = Request.Form["userName"];
            var password = Request.Form["password"];
            var password2 = Request.Form["password2"];

            /*await uc.InsertUser(new UserInputModel
            {
                FirstName = firstname,
                LastName = lastname,
                Age = int.Parse(age),
                Email = email,
                Username = username,
                Password = password
            }) ;*/

            return Content("Not Working!");
        }

    }
}
