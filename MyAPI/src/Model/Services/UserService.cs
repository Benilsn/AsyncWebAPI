using MyAPI.src.Model.Entities.User;
using MyAPI.src.Model.Repositories;
using System.Threading.Tasks;

namespace MyAPI.src.Model.Services
{
    public class UserService
    {

        private readonly UserRepository ur = new UserRepository();

        public async Task<bool> IsEmailInUse(string userEmail)
        {
            var email = await Task.Run(() => ur.GetByEmail(userEmail));
            

            if (email == null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<bool> IsUserNameInUse(string userName)
        {
            var uname = await Task.Run(() => ur.GetByEmail(userName));

            if (uname == null)
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
