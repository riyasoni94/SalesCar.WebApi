using SalesCar.Core.Models;
using SalesCar.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesCar.Core.Interfaces
{
    public interface IBuyerRepository
    {
        /// <summary>
        /// Get All Buyers
        /// </summary>
        /// <returns></returns>
        Task<List<Buyer>> GetAllBuyers();
       
        /// <summary>
        /// Add Buyer
        /// </summary>
        /// <param name="buyer"></param>
        /// <returns></returns>
        Task<int> AddBuyer(Buyer buyer);
        /// <summary>
        /// Add Buyer's interested Cars
        /// </summary>
        /// <param name="carBuyer"></param>
        /// <returns></returns>
        Task<List<CarBuyerMap>> AddBuyerCars(List<CarBuyerMap> carBuyer);
        /// <summary>
        /// Update Buyer information
        /// </summary>
        /// <param name="id"></param>
        /// <param name="buyer"></param>
        /// <returns></returns>
        Task<Buyer> UpdateBuyer(int id, Buyer buyer);
        /// <summary>
        /// Get Buyer's interested Cars
        /// </summary>
        /// <param name="buyerId"></param>
        /// <returns></returns>
        Task<List<CarBuyerMap>> GetBuyersCars(int buyerId);
        /// <summary>
        /// Remove Buyer's interested cars by Id
        /// </summary>
        /// <param name="buyerId"></param>
        /// <returns></returns>
        Task<Boolean> RemoveBuyerCars(int buyerId);
    }
}
