using SalesCar.Core.Models;
using SalesCar.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesCar.Application.IServices
{
    public interface IBuyerService
    {
        /// <summary>
        /// Get all Buyers list
        /// </summary>
        /// <returns></returns>
        Task<List<Buyer>> GetAllBuyers();
        /// <summary>
        /// Add Buyer information
        /// </summary>
        /// <param name="buyer"></param>
        /// <param name="carIdList"></param>
        /// <returns></returns>
        Task<int> AddBuyer(Buyer buyer, List<int> carIdList);
        /// <summary>
        /// Update Buyer Information
        /// </summary>
        /// <param name="buyer"></param>
        /// <param name="carIdList"></param>
        /// <returns></returns>
        Task<Buyer> UpdateBuyer(Buyer buyer, List<int> carIdList);
        /// <summary>
        /// Get all buyer's interested cars
        /// </summary>
        /// <param name="buyerId"></param>
        /// <returns></returns>
        Task<List<CarBuyerMap>> GetAllBuyersCars(int buyerId);


    }
}
