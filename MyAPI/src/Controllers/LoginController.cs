using Microsoft.AspNetCore.Mvc;
using MyAPI.src.Model.Services;

namespace MyAPI.src.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : Controller
    {

        private readonly UserService us = new UserService();

        /*[AcceptVerbs("Post", "Get")]
        public async Task<ActionResult> EmailExists([Bind(Prefix = "User.Email")] string userEmail)
        {
            var email = await us.EmailExists(userEmail);

            if (email)
            {
                return Json(true);
            }
            else
            {
                return Json("Email not registered!");
            }
        }

        [AcceptVerbs("Post", "Get")]
        public async Task<ActionResult> CheckPassword(string password, string email)
        {

            if (email == null)
            {
                return Json("Recebi o email!");
            }
            return Json("Nao recebi o email!");
        }*/



    }
}
