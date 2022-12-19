namespace SalesCar.WebAPI.Dtos
{
    public class CarDto
    {
        public int? Id { get; set; }
        public string Make { get; set; } = null!;

        public string Model { get; set; } = null!;

        public int? Year { get; set; }

        public decimal Price { get; set; }

        public int Mileage { get; set; }

        public string? Transmission { get; set; }

        public string? Vin { get; set; }

        public string? Type { get; set; }
        public int? PreviousOwners { get; set; }

    }
}
