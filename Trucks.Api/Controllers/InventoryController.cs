using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Trucks.Api.DataAccess.Services;
using Trucks.Api.Model.Models;

namespace Trucks.Api.Controllers
{
    [Route("api/truckinventory")]
    [ApiController]
    public class InventoryController : ControllerBase
    {
        private readonly IInventoryRepository _inventoryRepository;
        private readonly IMapper _mapper;
        public InventoryController(IInventoryRepository inventoryRepository, IMapper mapper)
        {
            _inventoryRepository = inventoryRepository ?? throw new ArgumentNullException(nameof(inventoryRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet("{truckId:int}", Name = "GetInventory")]
        public async Task<ActionResult> GetTruckInventoryAsync(int truckId)
        {
            var inventory = await _inventoryRepository.GetInventoryAsync(truckId);
            return Ok(inventory);
        }

        [HttpPost]
        public async Task<ActionResult> AddTruckInventoryAsync([FromBody] Dto.TruckInventoryDto inventoryDto)
        {
            var inventory = _mapper.Map<TruckInventory>(inventoryDto);
            await _inventoryRepository.AddInventoryAsync(inventory);
            if (await _inventoryRepository.SaveChangesAsync() != false) {
                var dto = _mapper.Map<Dto.TruckInventoryDto>(inventory);
                return CreatedAtRoute("GetInventory", new { truckId = inventory.TruckInventoryId }, dto);
            }

            return BadRequest();
        }
    }
}
