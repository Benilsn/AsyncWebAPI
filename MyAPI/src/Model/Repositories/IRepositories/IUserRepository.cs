using MyAPI.src.Model.Entities.User;
using System.Threading.Tasks;

namespace MyAPI.src.Model.Repositories.IRepositories
{
    public interface IUserRepository
    {
        string GetByEmail(string userEmail);
        //Task<string> GetByUserName(string userName);

        Task InsertUser(User u);

    }
}
