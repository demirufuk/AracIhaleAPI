using Data.Layer;
using Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Data.Repository
{
    public class AuthRepository : IAuthRepository
    {
        private DataContext _context;

        public AuthRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<Users> LoginWithToken(string token)
        {
            var members = await _context.Users.FirstOrDefaultAsync(x => x.TokenKey == token);
            if (members == null)
            {
                return null;
            }

            return members;
        }
    }
}