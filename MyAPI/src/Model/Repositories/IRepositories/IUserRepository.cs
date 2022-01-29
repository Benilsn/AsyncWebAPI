using System.Threading.Tasks;
using MyAPI.src.Model.Entities.User;

namespace MyAPI.src.Model.Repositories.IRepositories
{
    public interface IUserRepository
    {
        Task<User> Get();

        Task InsertUser(User u);

    }
}
