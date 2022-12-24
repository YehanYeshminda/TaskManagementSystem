using API.Data;
using API.Entities;
using API.Extensions;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext _context;
        public UserRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<AppUser> GetUserByIdAsync(int id)
        {
            return await _context.Users.FindAsync(id);
        }

        public async Task<AppUser> GetUserByUsernameAsync(string username)
        {
            return await _context.Users
            .Include(d => d.Departments).ThenInclude(c => c.Companys)
            .Include(d => d.Departments).ThenInclude(c => c.Factorys).ThenInclude(c => c.Company)
            .Include(d => d.Departments).ThenInclude(c => c.Factorys).ThenInclude(c => c.Plant).ThenInclude(c => c.Company)
            .SingleOrDefaultAsync(x => x.UserName == username);
        }

        public void Update(AppUser user)
        {
            throw new NotImplementedException();
        }
    }
}