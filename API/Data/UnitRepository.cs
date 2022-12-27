using API.Entities;
using API.Interfaces;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class UnitRepository : IUnitRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        public UnitRepository(DataContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }
        
        public async Task<Unit> GetUnitByIdAsync(int id)
        {
            return await _context.Unit
            .Include(s => s.Department)
            .Include(s => s.UserTasks)
            .SingleOrDefaultAsync(s => s.Id == id);
        }

        public async Task<IEnumerable<UnitDto>> GetUnits()
        {
            var query = await _context.Unit.Include(s => s.UserTasks).ToListAsync();

            return _mapper.Map<IEnumerable<UnitDto>>(query);
        }
    }
}