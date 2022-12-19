using SalesCar.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesCar.Application.IServices
{
    public interface ICarService
    {
        /// <summary>
        /// Get all cars
        /// </summary>
        /// <returns></returns>
        Task<List<Car>> GetCars();
        /// <summary>
        /// Add car information
        /// </summary>
        /// <param name="car"></param>
        /// <returns></returns>
        Task<int> AddCar(Car car);
        /// <summary>
        /// Update car information
        /// </summary>
        /// <param name="car"></param>
        /// <returns></returns>
        Task<Car> UpdateCar(Car car);
    }
}
