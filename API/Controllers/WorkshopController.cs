using API.Dtos;
using API.Entities;
using API.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class WorkshopController : BaseApiController
    {
        private readonly IWorkshopRepository _workshopRepository;
        public WorkshopController(IWorkshopRepository workshopRepository)
        {
            _workshopRepository = workshopRepository;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<WorkShop>> GetWorkshopsById(int id)
        {
            return await _workshopRepository.GetWorkshopByIdAsync(id);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<WorkShop>>> GetWorkshops()
        {
            return Ok(await _workshopRepository.GetWorkshops());
        }
    }
}