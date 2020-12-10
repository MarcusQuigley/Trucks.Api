using AutoMapper;
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
    }
}
