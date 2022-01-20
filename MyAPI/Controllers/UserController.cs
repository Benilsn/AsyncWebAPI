using Microsoft.AspNetCore.Mvc;
using MyAPI.InputModel;
using MyAPI.Services;
using MyAPI.ViewModel;
using System;
using System.Threading.Tasks;

namespace MyAPI.Controllers
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

        [HttpPost("/post")]
        public async Task<ActionResult<UserViewModel>> InsertUser([FromBody] UserInputModel userInputModel)
        {
            try
            {
                await Task.Run(() => us.InsertUser(userInputModel));

                return Created("Created!", userInputModel);

            }catch (ArgumentNullException e)
            {
                return Problem(e.Message);
            }
        }
    }
}
