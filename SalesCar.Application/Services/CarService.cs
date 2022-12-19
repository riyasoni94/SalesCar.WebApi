using SalesCar.Application.IServices;
using SalesCar.Core.Interfaces;
using SalesCar.Core.Models;
using SalesCar.Infrastructure.Models;
using SalesCar.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesCar.Application.Services
{
    public class CarService : ICarService
    {
        private readonly ICarRepository _carRepository;

        public CarService(ICarRepository carRepository)
        {
            _carRepository = carRepository;
        }
        /// <summary>
        /// Add car information
        /// </summary>
        /// <param name="car"></param>
        /// <returns></returns>
        public async Task<int> AddCar(Car car)
        {
            if (car != null)
            {
                var result = await _carRepository.AddCar(car);
                return result;
            }
            else
            {
                return 0;
            }
        }

        /// <summary>
        /// Get all car list
        /// </summary>
        /// <returns></returns>
        public async Task<List<Car>> GetCars()
        {
            return await _carRepository.GetCars();
        }

        /// <summary>
        /// Update car information
        /// </summary>
        /// <param name="car"></param>
        /// <returns></returns>
        public async Task<Car> UpdateCar(Car car)
        {
            var result = new Car();
            if (car != null)
            {
                result = await _carRepository.UpdateCar(car.Id, car);
            }
            return result;
        }
    }
}
