using Microsoft.EntityFrameworkCore;
using SalesCar.Core.Interfaces;
using SalesCar.Core.Models;
using SalesCar.Infrastructure.Models;

namespace SalesCar.Infrastructure.Repositories
{
    public class BuyerRepository : IBuyerRepository
    {
        public CarSalesContext _carSalesContext;
        public BuyerRepository(CarSalesContext carSalesContext)
        {
            _carSalesContext = carSalesContext;
        }
        /// <summary>
        /// Add buyer information
        /// </summary>
        /// <param name="buyer"></param>
        /// <returns></returns>
        public async Task<int> AddBuyer(Buyer buyer)
        {
            if (_carSalesContext != null)
            {
                await _carSalesContext.Buyers.AddAsync(buyer);
                await _carSalesContext.SaveChangesAsync();
                return buyer.Id;
            }
            return 0;
        }

        /// <summary>
        /// Add interested cars of buyer
        /// </summary>
        /// <param name="carBuyer"></param>
        /// <returns></returns>
        public async Task<List<CarBuyerMap>> AddBuyerCars(List<CarBuyerMap> carBuyer)
        {
            if (carBuyer != null)
            {
                await _carSalesContext.CarBuyerMaps.AddRangeAsync(carBuyer);
                await _carSalesContext.SaveChangesAsync();
            }
            return carBuyer;
        }


        /// <summary>
        /// Remove interested cars for update of buyer
        /// </summary>
        /// <param name="buyerId"></param>
        /// <returns></returns>
        public async Task<Boolean> RemoveBuyerCars(int buyerId)
        {
            var existingList = _carSalesContext.CarBuyerMaps.Where(x => x.BuyerId == buyerId).ToList();
            _carSalesContext.CarBuyerMaps.RemoveRange(existingList);
            await _carSalesContext.SaveChangesAsync();
            return true;
        }

        /// <summary>
        /// Get all buyer's information
        /// </summary>
        /// <returns></returns>
        public async Task<List<Buyer>> GetAllBuyers()
        {
            return await _carSalesContext.Buyers.ToListAsync();
        }
        /// <summary>
        /// Get buyer interested cars
        /// </summary>
        /// <param name="buyerId"></param>
        /// <returns></returns>
        public async Task<List<CarBuyerMap>> GetBuyersCars(int buyerId)
        {
            var result = new List<CarBuyerMap>();

            if (_carSalesContext != null)
            {
                result = await _carSalesContext.CarBuyerMaps
                   .Include(y => y.Car)
                   .Include(y => y.Buyer)
                   .Where(x => x.BuyerId == buyerId).ToListAsync();
            }
            return result;
        }

        /// <summary>
        /// Update buyer informations
        /// </summary>
        /// <param name="id"></param>
        /// <param name="buyer"></param>
        /// <returns></returns>
        public async Task<Buyer> UpdateBuyer(int id, Buyer buyer)
        {
            var buyers = new Buyer();
            buyers = _carSalesContext.Buyers.FirstOrDefault(x => x.Id == id); // Find existing buyer details 
            if (buyers != null)
            {
                buyers.FirstName = buyer.FirstName;
                buyers.LastName = buyer.LastName;
                buyers.Address = buyer.Address;
                buyers.Phone = buyer.Phone;
                buyers.City = buyer.City;
                buyers.Age = buyer.Age;

                _carSalesContext.Entry(buyers).State = EntityState.Modified;

                await _carSalesContext.SaveChangesAsync();
            }
            return buyers;
        }
    }
}
