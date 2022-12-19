using SalesCar.Infrastructure.Models;

namespace SalesCar.Core.Models
{
    public partial class CarBuyerMap
    {
        public int Id { get; set; }
        public int CarId { get; set; }
        public int BuyerId { get; set; }
        public virtual Buyer Buyer { get; set; } = null!;

        public virtual Car Car { get; set; } = null!;
    }
}
