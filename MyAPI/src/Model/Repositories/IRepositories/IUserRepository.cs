using MyAPI.src.Model.Entities.User;
using System.Threading.Tasks;

namespace MyAPI.src.Model.Repositories.IRepositories
{
    public interface IUserRepository
    {
        User Get(string userEmail, string userName);

        Task InsertUser(User u);

    }
}
