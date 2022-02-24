using MyAPI.src.Model.Entities.User;
using MyAPI.src.Model.Services.Password;
using System.Threading.Tasks;

namespace MyAPI.src.Model.Repositories.IRepositories
{
    public interface IUserRepository
    {
        Task<string> GetByEmail(string userEmail);

        Task InsertUser(User u, HashSalt hash);

    }
}
