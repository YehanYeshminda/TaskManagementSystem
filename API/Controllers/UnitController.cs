using API.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Authorize]
    public class UnitController : BaseApiController
    {
        private readonly IUnitRepository _unitRepository;
        public UnitController(IUnitRepository unitRepository)
        {
            _unitRepository = unitRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UnitDto>>> GetUnits()
        {
            return Ok(await _unitRepository.GetUnits());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<UnitDto>>> GetUnitsById(int id)
        {
            return Ok(await _unitRepository.GetUnitByIdAsync(id));
        }
    }
}