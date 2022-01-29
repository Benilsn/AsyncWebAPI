using System.Threading.Tasks;
using MyAPI.Business.Entities;

namespace MyAPI.Business.Repositories
{
    public interface IUserRepository
    {
        Task<User> Get();

        Task InsertUser(User u);

    }
}
