using SalesCar.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesCar.Core.Interfaces
{
    public interface ICarRepository
    {
        /// <summary>
        /// Get all Cars list
        /// </summary>
        /// <returns></returns>
        Task<List<Car>> GetCars();
        /// <summary>
        /// Add car details
        /// </summary>
        /// <param name="car"></param>
        /// <returns></returns>
        Task<int> AddCar(Car car);
        /// <summary>
        /// Update Car deatails
        /// </summary>
        /// <param name="id"></param>
        /// <param name="car"></param>
        /// <returns></returns>
        Task<Car> UpdateCar(int id, Car car);

    }
}
