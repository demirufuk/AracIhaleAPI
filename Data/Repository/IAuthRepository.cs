using Data.Models;
using System.Threading.Tasks;

namespace Data.Repository
{
    public interface IAuthRepository
    {
        //Task<User> Register(User user, string password);
        //Task<User> Login(string username, string password);
        //Task<bool> UserExists(string username);
        Task<Users> LoginWithToken(string token);
    }
}