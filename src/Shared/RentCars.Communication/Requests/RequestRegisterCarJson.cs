namespace RentCars.Communication.Requests
{
    public class RequestRegisterCarJson
    {
        public string Model { get; set; } = String.Empty;
        public string Brand { get; set; } = String.Empty;
        public int Year { get; set; }
        public string License_Plate { get; set; } = String.Empty;
        public string Status { get; set; } = String.Empty;
        public Boolean Air_conditioning { get; set; }
        public Boolean ABS { get; set; }
        public Boolean Automatic_transmission { get; set; }
        public string Steering_type { get; set; } = String.Empty;
        public int Num_passengers { get; set; }
    }
}
