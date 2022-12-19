using Microsoft.Azure.Documents;
using Microsoft.EntityFrameworkCore;
using SalesCar.Core.Interfaces;
using SalesCar.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesCar.Infrastructure.Repositories
{
    public class CarRepository : ICarRepository
    {
        public CarSalesContext _carSalesContext;
        public CarRepository(CarSalesContext carSalesContext)
        {
            _carSalesContext = carSalesContext;
        }
        /// <summary>
        /// Add car information
        /// </summary>
        /// <param name="car"></param>
        /// <returns></returns>
        public async Task<int> AddCar(Car car)
        {
            if (_carSalesContext != null)
            {
                await _carSalesContext.Cars.AddAsync(car);
                await _carSalesContext.SaveChangesAsync();
                return car.Id;
            }
            return 0;
        }

        /// <summary>
        /// Get all car list
        /// </summary>
        /// <returns></returns>
        public async Task<List<Car>> GetCars()
        {
            return await _carSalesContext.Cars.ToListAsync();
        }

        /// <summary>
        /// Update car information
        /// </summary>
        /// <param name="id"></param>
        /// <param name="car"></param>
        /// <returns></returns>
        public async Task<Car> UpdateCar(int id, Car car)
        {
            var cars = new Car();
            cars = _carSalesContext.Cars.FirstOrDefault(x => x.Id == id);// Find car by id
            if (cars != null)
            {
                cars.Year = car.Year;
                cars.Price = car.Price;
                cars.Transmission = car.Transmission;
                cars.Make = car.Make;
                cars.PreviousOwners = car.PreviousOwners;
                cars.Mileage = car.Mileage;
                cars.Model = car.Model;
                cars.Vin = car.Vin;

                _carSalesContext.Entry(cars).State = EntityState.Modified; //Upate car information

                await _carSalesContext.SaveChangesAsync();
            }
            return cars;
        }
    }
}
