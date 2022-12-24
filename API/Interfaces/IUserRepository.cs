using API.Entities;

namespace API.Extensions
{
    public interface IUserRepository
    {
        void Update(AppUser user);      
        Task<AppUser> GetUserByIdAsync(int id);
        Task<AppUser> GetUserByUsernameAsync(string username);  
    }
}