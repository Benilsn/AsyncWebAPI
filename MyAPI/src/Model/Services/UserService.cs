using MyAPI.src.Model.Entities.User;
using MyAPI.src.Model.Repositories;
using System.Threading.Tasks;

namespace MyAPI.src.Model.Services
{
    public class UserService
    {

        private readonly UserRepository ur = new UserRepository();

        public bool Exists(string userEmail, string userName)
        {
            var user = ur.Get(userEmail, userName);

            if (user == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public async Task InsertUser(UserInputModel userInputModel)
        {
            await Task.Run(() => ur.InsertUser(Converted.Convert(userInputModel)));
        }


    }
}
