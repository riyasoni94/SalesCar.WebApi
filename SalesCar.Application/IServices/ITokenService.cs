using SalesCar.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesCar.Application.IServices
{
    public interface ITokenService
    {
        /// <summary>
        /// Use to generate jwt access token for authorization
        /// </summary>
        /// <param name="appUser"></param>
        /// <returns></returns>
        string CreateToken(User appUser);
    }
}
