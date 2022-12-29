using API.Data;
using API.Dtos;
using API.Entities;
using API.Extensions;
using API.Helpers;
using API.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Authorize]
    public class TasksController : BaseApiController
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly ITaskRepository _taskRepository;
        private readonly IDepartmentRepository _departmentRepository;
        private readonly IWorkshopRepository _workshopRepository;
        private readonly IProductRepository _productRepository;
        private readonly IUnitRepository _unitRepository;
        private readonly DataContext _context;
        public TasksController(IUserRepository userRepository, IMapper mapper, ITaskRepository taskRepository, IDepartmentRepository departmentRepository, IWorkshopRepository workshopRepository, IProductRepository productRepository, IUnitRepository unitRepository, DataContext context)
        {
            _context = context;
            _unitRepository = unitRepository;
            _productRepository = productRepository;
            _workshopRepository = workshopRepository;
            _departmentRepository = departmentRepository;
            _taskRepository = taskRepository;
            _mapper = mapper;
            _userRepository = userRepository;

        }

        [HttpPost]
        public async Task<ActionResult<TaskDto>> CreateTask(TaskParams taskParams)
        {
            var username = User.GetUsername();
            var userId = User.GetUserId();

            var user = await _userRepository.GetUserByIdAsync(userId);
            if (user == null) return NotFound( "Unable to find user" );

            var department = await _departmentRepository.GetDepartmentByIdAsync(taskParams.DepartmentId);
            if (department == null) return NotFound("Unable to find department");

            var unit = await _unitRepository.GetUnitByIdAsync(taskParams.UnitId);
            if (unit == null) return NotFound( "Unable to find unit" );

            var workshop = await _workshopRepository.GetWorkshopByIdAsync(taskParams.WorkshopId);
            if (workshop == null) return NotFound( "Unable to find workshop" );

            var product = await _productRepository.GetProductByIdAsync(taskParams.ProductId);
            if (product == null) return NotFound( "Unable to find product" );


            var newTask = new UserTasks
            {
                Name = taskParams.Name,
                Description = taskParams.Description,
                CustomerDetails = taskParams.CustomerDetails,
                Qty = taskParams.Qty,
                Status = taskParams.Status,
                StartDate = taskParams.StartDate,
                EndDate = taskParams.EndDate,
                Department = department,
                AppUser = user,
                Product = product,
                WorkShop = workshop,
                Unit = unit,
            };

            _taskRepository.AddTask(newTask);

            if (await _taskRepository.SaveAllAsync()) return Ok(newTask);

            return BadRequest("Failed to save a Task!");
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TaskDto>>> GetTasks()
        {
            return Ok(await _taskRepository.GetTasks());
        }

        public static TaskUpdateDto CheckupdatedObject(UserTasks original, TaskUpdateDto updatedObj)
        {
            foreach (var property in updatedObj.GetType().GetProperties())
            {
                if (property.GetValue(updatedObj, null) == null)
                {
                    property.SetValue(updatedObj, updatedObj.GetType().GetProperty(property.Name)
                    .GetValue(updatedObj, null));
                }
            }
            return updatedObj;
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateTask([FromBody]TaskUpdateDto userTasks, [FromRoute]int id)
        {
            var task = await _taskRepository.GetTasksFromId(id);

            if (task == null) return NotFound("Unable to find task");

            var updatedObj = (TaskUpdateDto) CheckupdatedObject(task, userTasks);

            _context.Entry(task).CurrentValues.SetValues(updatedObj);

            if (await _context.SaveChangesAsync() > 0) return NoContent();

            return BadRequest("Unable to Update Task");
        }
    }
}