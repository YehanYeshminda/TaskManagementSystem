using API.Dtos;
using API.Entities;
using API.Helpers;
using API.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Authorize]
    public class TaskMaterialController : BaseApiController
    {
        private readonly ITaskMaterialRepository _taskMaterialRepository;
        private readonly ITaskRepository _taskRepository;
        private readonly IMaterialRepository _materialRepository;
        private readonly IMapper _mapper;
        public TaskMaterialController(ITaskMaterialRepository taskMaterialRepository, ITaskRepository taskRepository, IMaterialRepository materialRepository, IMapper mapper)
        {
            _mapper = mapper;
            _materialRepository = materialRepository;
            _taskRepository = taskRepository;
            _taskMaterialRepository = taskMaterialRepository;
        }

        [HttpPost]
        public async Task<ActionResult<TaskMaterialDto>> CreateTaskMaterial(TaskMaterialParams taskMaterialParams)
        {
            var task = await _taskRepository.GetTasksFromId(taskMaterialParams.UserTasksId);
            if (task == null) return NotFound("Unable to find the task Id");

            var materials = await _materialRepository.GetMaterialByIdAsync(taskMaterialParams.MaterialsId);
            if (materials == null) return NotFound("Unable to find the materials");

            var newTaskMaterial = new TaskMaterial
            {
                Qty = taskMaterialParams.Qty,
                UsedQty = 0,
                UserTasks = task,
                Materials = materials,
                CreatedAt = DateTime.Now,
            };

            _taskMaterialRepository.AddTask(newTaskMaterial);

            if (await _taskMaterialRepository.SaveAllAsync()) return Ok("Task material has been inserted");

            return BadRequest("Failed to save task materials");
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TaskMaterial>>> GetTasks()
        {
            return Ok(await _taskMaterialRepository.GetTaskMaterials());
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateTaskMaterial([FromBody]UpdateTaskMaterialDto updateTaskMaterialDto, [FromRoute]int id)
        {
            var taskMaterial= await _taskMaterialRepository.GetTaskMaterialsFromId(id);

            if (taskMaterial== null) return NotFound("Unable to find Task material item");

            _mapper.Map(updateTaskMaterialDto, taskMaterial);

            if (await _taskMaterialRepository.SaveAllAsync()) return NoContent();

            return BadRequest("Unable to Update Task material item");
        }
    }
}