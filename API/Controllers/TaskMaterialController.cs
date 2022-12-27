using API.Dtos;
using API.Entities;
using API.Helpers;
using API.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class TaskMaterialController : BaseApiController
    {
        private readonly ITaskMaterialRepository _taskMaterialRepository;
        private readonly ITaskRepository _taskRepository;
        private readonly IMaterialRepository _materialRepository;
        public TaskMaterialController(ITaskMaterialRepository taskMaterialRepository, ITaskRepository taskRepository, IMaterialRepository materialRepository)
        {
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
    }
}