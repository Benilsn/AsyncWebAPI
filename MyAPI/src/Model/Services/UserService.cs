using MyAPI.src.Model.Entities.User;
using MyAPI.src.Model.Repositories;
using System.Threading.Tasks;

namespace MyAPI.src.Model.Services
{
    public class UserService
    {

        private readonly UserRepository ur = new UserRepository();

        public async Task<UserViewModel> Get()
        {
            var user = await ur.Get();
            return Converted.Convert(user);
        }

        public async Task InsertUser(UserInputModel userInputModel)
        {
            await Task.Run(() => ur.InsertUser(Converted.Convert(userInputModel)));
        }


    }
}
