using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SalesCar.Application.IServices;
using SalesCar.Infrastructure.Models;
using SalesCar.WebAPI.Dtos;
using SalesCar.WebAPI.Errors;
using StackExchange.Redis;
using System.Net;

namespace SalesCar.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly IUserService _userService;
        public IMapper _Mapper;
        private readonly ITokenService _tokenService;
        public AccountsController(IUserService userService, IMapper mapper, ITokenService tokenService)
        {
            _userService = userService;
            _Mapper = mapper;
            _tokenService = tokenService;
        }

        /// <summary>
        /// Use to login the authorized user
        /// </summary>
        /// <param name="loginDto"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost(nameof(Login))]
        public async Task<ActionResult<UserDto>> Login(LoginDto loginDto)
        {
            var result = await _userService.FindUser(loginDto.Email, loginDto.Password);
            if (result == null)
            {
                return Unauthorized(new APIResponce(401));
            }
            return new UserDto
            {
                Role = result.Role,
                Token = _tokenService.CreateToken(result)
            };

        }
    }
}
