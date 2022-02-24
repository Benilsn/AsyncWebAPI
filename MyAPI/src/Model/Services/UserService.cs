using MyAPI.src.Model.Entities.User;
using MyAPI.src.Model.Repositories;
using MyAPI.src.Model.Services.ConvertModels;
using MyAPI.src.Model.Services.Password;
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

        public async Task<bool> EmailExists(string userEmail)
        {
            var email = await Task.Run(() => ur.GetByEmail(userEmail));

            if (email == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public async Task<bool> CheckPassword(string userEmail, string enteredPassword)
        {
            var email = await Task.Run(() => ur.GetByEmail(userEmail));

            if (email != null)
            {
                var hash = ur.CheckPassword(userEmail).Result;

                if (HashSalt.VerifyPassword(enteredPassword, hash.Hash, hash.Salt))
                {
                    return true;
                }

                return false;
            }

            return false;
        }



        public async Task InsertUser(UserInputModel userInputModel)
        {
            HashSalt hashSalt = HashSalt.GenerateSaltedHash(userInputModel.Password);

            await Task.Run(() => ur.InsertUser(Converted.Convert(userInputModel), hashSalt));
        }


    }
}
