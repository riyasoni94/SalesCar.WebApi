using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SalesCar.Application.IServices;
using SalesCar.Infrastructure.Models;
using SalesCar.WebAPI.Dtos;
using System.Net;

namespace SalesCar.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]

    public class CarController : ControllerBase
    {
        private readonly ICarService _carService;
        public IMapper _Mapper;


        public CarController(ICarService carService, IMapper mapper)
        {
            _Mapper = mapper;
            _carService = carService;
        }
        /// <summary>
        /// Add car information
        /// </summary>
        /// <param name="car"></param>
        /// <returns></returns>

        [HttpPost(nameof(AddCar))]
        public async Task<IActionResult> AddCar(CarDto car)
        {
            if (car == null)
            {
                return BadRequest();
            }
            var carModel = _Mapper.Map<CarDto, Car>(car);
            var result = await _carService.AddCar(carModel);
            if (result == 0)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Something Went Wrong");
            }
            return Ok("Added Successfully");
        }

        /// <summary>
        /// Get all car details
        /// </summary>
        /// <returns></returns>
        [HttpGet(nameof(GetAllCar))]
        public async Task<ActionResult> GetAllCar()
        {
            var result = await _carService.GetCars();
            if (result == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Something Went Wrong");
            }
            return Ok(result);
        }

       
        /// <summary>
        /// Update car information
        /// </summary>
        /// <param name="car"></param>
        /// <returns></returns>
        [HttpPut(nameof(UpdateCar))]
        public async Task<IActionResult> UpdateCar(CarDto car)
        {
            if (car == null)
            {
                return BadRequest();
            }
            var carModel = _Mapper.Map<CarDto, Car>(car);
            var result = await _carService.UpdateCar(carModel);
            if (result == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Something Went Wrong");
            }
            return Ok("Updated Successfully");
        }
    }
}
