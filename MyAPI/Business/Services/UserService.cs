using MyAPI.Model.Users;
using MyAPI.Data.Repositories;
using System.Threading.Tasks;

namespace MyAPI.Business.Services
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
