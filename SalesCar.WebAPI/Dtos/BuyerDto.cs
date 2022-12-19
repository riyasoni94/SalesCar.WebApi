using Microsoft.Extensions.Hosting;
using SalesCar.Core.Models;

namespace SalesCar.WebAPI.Dtos
{
    public class BuyerDto
    {
        public int? Id { get; set; }
        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public int? Age { get; set; }

        public string? Phone { get; set; }

        public string? Address { get; set; }

        public string? City { get; set; }
        public ICollection<int> CarIdList { get; set; }
    }
}
