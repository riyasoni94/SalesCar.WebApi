using Microsoft.Azure;
using SalesCar.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesCar.Application.IServices
{
    public interface IUserService
    {
        /// <summary>
        /// Use to find existing user
        /// </summary>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        Task<User> FindUser(string email, string password);
    }
}
