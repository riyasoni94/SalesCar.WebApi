using Microsoft.Azure.Documents;
using SalesCar.Application.IServices;
using SalesCar.Core.Interfaces;
using SalesCar.Core.Models;
using SalesCar.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace SalesCar.Application.Services
{
    public class BuyerService : IBuyerService
    {

        public readonly IBuyerRepository _buyerRepository;

        public BuyerService(IBuyerRepository buyerRepository)
        {
            _buyerRepository = buyerRepository;
        }
        /// <summary>
        /// Add buyer information
        /// </summary>
        /// <param name="buyer"></param>
        /// <param name="carIdList"></param>
        /// <returns></returns>
        public async Task<int> AddBuyer(Buyer buyer, List<int> carIdList)
        {
            if (buyer != null)
            {
                var result = await _buyerRepository.AddBuyer(buyer);

                if (result != 0)
                {
                    var list = new List<CarBuyerMap>();
                    foreach (var id in carIdList)
                    {
                        var carBuyerDto = new CarBuyerMap
                        {
                            BuyerId = result,
                            CarId = id
                        };
                        list.Add(carBuyerDto);
                    }
                    await _buyerRepository.AddBuyerCars(list); // Add interested cars of buyer's
                }
                return result;
            }
            else
            {
                return 0;
            }
        }

        /// <summary>
        /// Update buyer information
        /// </summary>
        /// <param name="buyer"></param>
        /// <param name="carIdList"></param>
        /// <returns></returns>
        public async Task<Buyer> UpdateBuyer(Buyer buyer, List<int> carIdList)
        {
            var result = new Buyer();
            if (buyer != null)
            {
                result = await _buyerRepository.UpdateBuyer(buyer.Id, buyer); // Update buyer information

                var isRemoved = await _buyerRepository.RemoveBuyerCars(buyer.Id); // Remove all interested cars
                if (isRemoved)
                {
                    var list = new List<CarBuyerMap>();
                    foreach (var id in carIdList)
                    {
                        var carBuyerDto = new CarBuyerMap
                        {
                            BuyerId = buyer.Id,
                            CarId = id
                        };
                        list.Add(carBuyerDto);

                    }
                    await _buyerRepository.AddBuyerCars(list);// Add all interested cars
                    return result;
                }
            }
            return result;
        }

        /// <summary>
        /// Get all buyer information
        /// </summary>
        /// <returns></returns>
        public async Task<List<Buyer>> GetAllBuyers()
        {
            return await _buyerRepository.GetAllBuyers();
        }


        /// <summary>
        /// Get all buyer's interested cars details
        /// </summary>
        /// <param name="buyerId"></param>
        /// <returns></returns>
        public Task<List<CarBuyerMap>> GetAllBuyersCars(int buyerId)
        {
            return _buyerRepository.GetBuyersCars(buyerId);
        }
    }
}
