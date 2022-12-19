//using Microsoft.Azure.Documents;
using System;
using SalesCar.Infrastructure.Models;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesCar.Core.Interfaces
{
    public interface IUserRepository
    {
        /// <summary>
        /// Get user details
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        Task<User> GetUser(User user);
    }
}
