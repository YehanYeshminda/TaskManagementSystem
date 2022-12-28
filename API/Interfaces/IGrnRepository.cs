using API.Entities;

namespace API.Interfaces
{
    public interface IGrnRepository
    {
        Task<IEnumerable<Grn>> GetGrns();
        Task<Grn> GetGrnByIdAsync(int id);
    }
}