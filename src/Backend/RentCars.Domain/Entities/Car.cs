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
        public int Year { get; set; }
        public string License_Plate { get; set; } = String.Empty;
        public string Status { get; set; } = String.Empty;
        public bool Air_conditioning { get; set; }
        public bool ABS { get; set; }
        public bool Automatic_transmission { get; set; }
        public string Steering_type { get; set; } = String.Empty;
        public int Num_passengers { get; set; }

    }
}
