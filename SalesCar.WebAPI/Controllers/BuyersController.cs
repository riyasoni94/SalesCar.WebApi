using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SalesCar.Application.IServices;
using SalesCar.Application.Services;
using SalesCar.Infrastructure.Models;
using SalesCar.WebAPI.Dtos;

namespace SalesCar.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BuyersController : ControllerBase
    {
        private readonly IBuyerService _buyerService;
        public IMapper _mapper;
        public BuyersController(IBuyerService buyerService, IMapper mapper)
        {
            _buyerService = buyerService;
            _mapper = mapper;
        }
        /// <summary>
        /// Add buyer information
        /// </summary>
        /// <param name="buyer"></param>
        /// <returns></returns>
        [HttpPost(nameof(AddBuyer))]
        [Authorize]
        public async Task<IActionResult> AddBuyer(BuyerDto buyer)
        {
            if (buyer == null)
            {
                return BadRequest();
            }
            var buyerModel = _mapper.Map<BuyerDto, Buyer>(buyer); //map model and data object model
            var result = await _buyerService.AddBuyer(buyerModel, buyer.CarIdList.ToList());
            if (result == 0)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Something Went Wrong");
            }
            return Ok("Added Successfully");
        }

        /// <summary>
        /// Get all buyer information
        /// </summary>
        /// <returns></returns>
        [HttpGet(nameof(GetAllBuyer))]
        [Authorize]
        public async Task<ActionResult> GetAllBuyer()
        {
            var result = await _buyerService.GetAllBuyers();
            if (result == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Something Went Wrong");
            }
            return Ok(result);
        }

        /// <summary>
        /// Update buyer information
        /// </summary>
        /// <param name="buyer"></param>
        /// <returns></returns>
        [HttpPut(nameof(UpdateBuyer))]
        [Authorize]
        public async Task<IActionResult> UpdateBuyer(BuyerDto buyer)
        {
            if (buyer == null)
            {
                return BadRequest();
            }
            var buyerModel = _mapper.Map<BuyerDto, Buyer>(buyer);
            var result = await _buyerService.UpdateBuyer(buyerModel, buyer.CarIdList.ToList());
            if (result == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Something Went Wrong");
            }
            return Ok("Added Successfully");
        }

        /// <summary>
        /// Get all interested cars of buyer
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet(nameof(GetAllBuyersCars))]
        [Authorize]
        public async Task<ActionResult> GetAllBuyersCars(int Id)
        {
            var result = await _buyerService.GetAllBuyersCars(Id);
            if (result == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Something Went Wrong");
            }
            return Ok(result);
        }
    }
}
