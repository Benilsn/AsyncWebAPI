using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyAPI.src.Model.Entities.User;
using MyAPI.src.Model.Services;
using System;
using System.Threading.Tasks;

namespace MyAPI.src.Controllers
{

    [Route("[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly UserService us = new UserService();


        [HttpPost("/register")]
        public async Task<ActionResult> InsertUser(UserInputModel userInputModel)
        {
            try
            {
                await Task.Run(() => us.InsertUser(userInputModel));

                return RedirectToPage("Index");

            }
            catch (ArgumentNullException e)
            {
                return Problem(e.Message);
            }
        }

        [AcceptVerbs("Post","Get")]
        public bool IsEmailInUse(string userEmail)
        {
            var email = us.IsEmailInUse(userEmail);

            if (email.Result)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /*[AcceptVerbs("Post", "Get")]]

        public async Task<ActionResult> IsUserNameInUse(string userName)
        {

        }*/
    }
}
