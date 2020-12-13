using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Trucks.Api.ControllerFilters;
using Trucks.Api.DataAccess.Services;
using Trucks.Api.Model.Models;


namespace Trucks.Api.Controllers
{
    [Route("api/trucks")]
    [ApiController]
    public class TrucksController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ITrucksRepository _trucksRepository;
        public TrucksController(ITrucksRepository trucksRepository, IMapper mapper)
        {
            _trucksRepository = trucksRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [TrucksResultFilter]
        public async Task<ActionResult> GetTrucksAsync()
        {
            var modelTrucks = await _trucksRepository.GetTrucksAsync();
            return Ok(modelTrucks);
        }

        [HttpGet("trucksbycategory/{categoryId:int}")]
        [TrucksResultFilter]
        public async Task<ActionResult> GetTrucksByCategoryAsync(int categoryId)
        {
            var modelTrucks = await _trucksRepository.GetTrucksByCategoryAsync(categoryId);
            return Ok(modelTrucks);
        }

        [HttpGet("{truckId:int}", Name = "GetTruck")]
        [TruckResultFilter]
        public async Task<ActionResult> GetTruckAsync(int truckId)
        {
            var modelTruck = await _trucksRepository.GetTruckAsync(truckId);
            return Ok(modelTruck);
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateTruck([FromBody] Dto.TruckDto truckDto)
        {
            if (ModelState.IsValid) {
                var truck = _mapper.Map<Truck>(truckDto);
                await _trucksRepository.AddTruckAsync(truck);
                if (await _trucksRepository.SaveChangesAsync() != false) {
                    var newTruckDto = _mapper.Map<Dto.TruckDto>(truck);
                    return CreatedAtRoute("GetTruck", new { truckId = truck.TruckId }, newTruckDto);
                }
            }
            return BadRequest();
        }

        [HttpPost]
        [Route("truckphoto")]
        public async Task<ActionResult> CreateTruckPhoto([FromBody] Dto.PhotoDto photoDto)
        {
            if (ModelState.IsValid) {
                var photo = _mapper.Map<Photo>(photoDto);
                await _trucksRepository.AddTruckPhotoAsync(photo);
                if (await _trucksRepository.SaveChangesAsync() != false)
                    return Ok();
            }
            return BadRequest();
        }

        [HttpPatch("{truckId}")]
        public async Task<ActionResult> PatchTruck(int truckId, [FromBody] JsonPatchDocument<Dto.TruckDto> truckPatch)
        {
            if (truckPatch == null) {
                return BadRequest();
            }

            var truck = await _trucksRepository.GetTruckAsync(truckId);
            if (truck == null) {
                return NotFound();
            }
            var truckDtoToPatch = _mapper.Map<Dto.TruckDto>(truck);

            truckPatch.ApplyTo(truckDtoToPatch, ModelState);

            if (!TryValidateModel(truckDtoToPatch)) {
                return ValidationProblem(this.ModelState);
            }

            // truck = _mapper.Map<Truck>(truckDtoToPatch);
            _mapper.Map(truckDtoToPatch, truck);

            _trucksRepository.UpdateTruck(truck);

            if (await _trucksRepository.SaveChangesAsync() != false) {
                return NoContent();
            }
            return BadRequest();
        }

        [HttpPut]
        public async Task<ActionResult> UpdateTruck([FromBody] Dto.TruckDto truckDto)
        {
            if (truckDto == null) return BadRequest();
            var truck = await _trucksRepository.GetTruckAsync(truckDto.TruckId);
            if (truck == null) return BadRequest();
            if (!TryValidateModel(truckDto))
                return ValidationProblem(this.ModelState);
            _mapper.Map(truckDto, truck);
            _trucksRepository.UpdateTruck(truck);
            if (await _trucksRepository.SaveChangesAsync() != false) {
                truckDto = _mapper.Map<Dto.TruckDto>(truck);
                return CreatedAtRoute("GetTruck", new { truckId = truckDto.TruckId }, truckDto);
            }
            return BadRequest();

        }

        [HttpPost]
        [Route("trucksale")]
        public async Task<ActionResult> CreateTruckSale([FromBody] Dto.SalesDto sodDto)
        {
            if (ModelState.IsValid) {
                var sodModel = _mapper.Map<SalesOrderDetail>(sodDto);
                await _trucksRepository.AddSaleAsync(sodModel);
                if (await _trucksRepository.SaveChangesAsync() != false)
                    return Ok();
            }
            return BadRequest();
        }

    }
}
