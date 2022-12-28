using API.Dtos;
using API.Entities;
using API.Helpers;
using API.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class InventoryController : BaseApiController
    {
        private readonly IInventoryRepository _inventoryRepository;
        private readonly IMaterialRepository _materialRepository;
        private readonly IGrnRepository _grnRepository;
        public InventoryController(IInventoryRepository inventoryRepository, IMaterialRepository materialRepository, IGrnRepository grnRepository)
        {
            _grnRepository = grnRepository;
            _materialRepository = materialRepository;
            _inventoryRepository = inventoryRepository;
        }

        [HttpPost]
        public async Task<ActionResult<Inventory>> CreateInventory(InventoryParams inventoryParams)
        {
            var material = await _materialRepository.GetMaterialByIdAsync(inventoryParams.MaterialsId);
            if (material == null) return NotFound("Unable to find the material Id");

            var grn = await _grnRepository.GetGrnByIdAsync(inventoryParams.GrnId); 
            if (grn == null) return NotFound("Unable to find the grn Id");

            var newInventoryItem = new Inventory
            {
                Qty = inventoryParams.Qty,
                AvailableQty = inventoryParams.AvailableQty,
                UnitCost = inventoryParams.UnitCost,
                CreatedAt = DateTime.Now,
                Materials = material,
                Grn = grn,
            };

            _inventoryRepository.AddInventory(newInventoryItem);

            if (await _inventoryRepository.SaveAllAsync()) return Ok("Inventory item has been added");

            return BadRequest("Failed to save inventory items");
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Inventory>>> GetInventory()
        {
            return Ok(await _inventoryRepository.GetInventory());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<Inventory>>> GetInventoryByIdAsync(int id)
        {
            return Ok(await _inventoryRepository.GetInventoryFromId(id));
        }
    }
}