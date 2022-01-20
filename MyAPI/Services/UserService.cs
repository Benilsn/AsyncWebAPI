using MyAPI.InputModel;
using MyAPI.Repositories;
using System.Threading.Tasks;
using MyAPI.Model;
using MyAPI.ViewModel;

namespace MyAPI.Services
{
    public class UserService
    {

        private readonly UserRepository ur = new UserRepository();

        public async Task<UserViewModel> Get()
        {
            var user = await ur.Get();

            return new UserViewModel
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Age = user.Age,
                Email = user.Email,
                Username = user.Username,
                Password = user.Password
            };
        }

        public async Task InsertUser(UserInputModel userInputModel)
        {
            var user = new User
            {
                FirstName = userInputModel.FirstName,
                LastName = userInputModel.LastName,
                Age = userInputModel.Age,
                Email = userInputModel.Email,
                Username = userInputModel.Username,
                Password = userInputModel.Password
            };

            await ur.InsertUser(user);
        }
    }
}
