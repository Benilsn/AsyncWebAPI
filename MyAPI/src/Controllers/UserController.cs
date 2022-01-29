using Microsoft.AspNetCore.Mvc;
using System;
using MyAPI.Model.Users;
using MyAPI.Business.Services;
using System.Threading.Tasks;

namespace MyAPI.src.Controllers
{

    [Route("[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly UserService us = new UserService();

        [HttpGet("/get")]
        public async Task<ActionResult<UserViewModel>> Get()
        {

            var u = await us.Get();

            return Ok(u);
        }

        [HttpPost("/register")]
        public async Task<ActionResult<UserViewModel>> InsertUser([FromForm] UserInputModel userInputModel)
        {
            try
            {
                await Task.Run(() => us.InsertUser(userInputModel));

                return Ok();

            }
            catch (ArgumentNullException e)
            {
                return Problem(e.Message);
            }
        }
    }
}
