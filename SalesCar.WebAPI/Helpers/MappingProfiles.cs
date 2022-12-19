using AutoMapper;
using SalesCar.Infrastructure.Models;
using SalesCar.WebAPI.Dtos;

namespace SalesCar.Helpers
{
    public class MappingProfiles: Profile
    {
        /// <summary>
        /// Auto map model to object models
        /// </summary>
        public MappingProfiles()
        {
            CreateMap<User, UserDto>();
            CreateMap<CarDto, Car>();
            CreateMap<BuyerDto, Buyer>();
        }
    }
}
