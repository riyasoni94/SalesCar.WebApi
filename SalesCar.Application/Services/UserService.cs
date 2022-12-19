using SalesCar.Application.IServices;
using SalesCar.Core.Interfaces;
using SalesCar.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesCar.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        /// <summary>
        /// Use to find the existing user
        /// </summary>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public async Task<User> FindUser(string email, string password)
        {
            var user = new User
            {
                Email = email,
                Password = password
            };
            return await _userRepository.GetUser(user);
        }
    }
}
