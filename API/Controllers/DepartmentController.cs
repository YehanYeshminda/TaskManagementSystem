using API.Entities;
using API.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Authorize]
    public class DepartmentController : BaseApiController
    {
        private readonly IDepartmentRepository _departmentRepository;
        public DepartmentController(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Department>>> GetDepartments()
        {
            return Ok(await _departmentRepository.GetDepartments());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Department>> GetDepartmentsById(int id)
        {
            return Ok(await _departmentRepository.GetDepartmentByIdAsync(id));
        }
    }
}