using Microsoft.EntityFrameworkCore;
using SalesCar.Core.Interfaces;
using SalesCar.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using User = SalesCar.Infrastructure.Models.User;

namespace SalesCar.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        public CarSalesContext _carSalesContext;
        public UserRepository(CarSalesContext carSalesContext)
        {
            _carSalesContext = carSalesContext;
        }
        /// <summary>
        /// Get user details
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public async Task<User> GetUser(User user)
        {
            return await _carSalesContext.Users
                 .Where(x => x.Email == user.Email && x.Password == user.Password).FirstOrDefaultAsync();
        }
    }
}
