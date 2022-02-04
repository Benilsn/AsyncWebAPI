using MyAPI.src.Model.Entities.User;
using System.Threading.Tasks;

namespace MyAPI.src.Model.Repositories.IRepositories
{
    public interface IUserRepository
    {
        Task<User> Get();

        Task InsertUser(User u);

    }
}
