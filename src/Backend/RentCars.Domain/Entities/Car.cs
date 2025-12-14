using RentCars.Domain.Enums;

namespace RentCars.Domain.Entities
{
    public class Car
    {
        public long Id { get; set; }
        public DateTime CreatedOn {  get; set; } = DateTime.UtcNow;
        public DateTime ModifiedOn { get; set; } = DateTime.UtcNow;
        public bool Active { get; set; } = true;

        // Atributos recebidos do cadastro
        public string Model { get; set; } = string.Empty;
        public string Brand { get; set; } = String.Empty;
        public string Year { get; set; } = String.Empty;
        public string License_Plate { get; set; } = String.Empty;
        public EnumCarStatus Status { get; set; }
        public bool Air_conditioning { get; set; }
        public bool ABS { get; set; }
        public bool Automatic_transmission { get; set; }
        public EnumCarSteeringType Steering_type { get; set; }
        public int Num_passengers { get; set; }

    }
}
