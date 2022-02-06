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

        [HttpGet("/get")]
        public JsonResult Exists(string userEmail, string userName)
        {

            var u = us.Exists(userEmail, userName);

            return Json(u);
        }

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

        public void UserExists(string userEmail, string userName)
        {

        }
    }
}
