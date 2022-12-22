using API.Data;
using API.Dtos;
using API.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    public class TestController : BaseApiController
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly DataContext _context;
        public TestController(UserManager<AppUser> userManager, DataContext context)
        {
            _context = context;
            _userManager = userManager;
        }

        // [HttpGet] // returns all the users as a paused method which is task
        //  public async Task<IEnumerable<AppUser>> GetUsersAsync()
        // {
        //     return await _context.Users
        //             .Include(d => d.Departments).ThenInclude(c => c.Company)
        //             .Include(d => d.Departments).ThenInclude(f => f.Factory).ThenInclude(c => c.Company)
        //             .Include(d => d.Departments).ThenInclude(f => f.Factory).ThenInclude(p => p.Plant).ThenInclude(c => c.Company)
        //             .ToListAsync();
        // }
    }
}