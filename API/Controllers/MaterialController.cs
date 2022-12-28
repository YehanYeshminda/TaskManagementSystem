using API.Data;
using API.Entities;
using API.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class MaterialController : BaseApiController
    {
        private readonly DataContext _context;
        private readonly IMaterialRepository _materialRepository;
        public MaterialController(IMaterialRepository materialRepository)
        {
            _materialRepository = materialRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Materials>>> GetProduct()
        {
            return Ok(await _materialRepository.GetMaterials());
        }
    }
}