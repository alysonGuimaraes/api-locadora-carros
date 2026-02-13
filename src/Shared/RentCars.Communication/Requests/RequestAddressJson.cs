using RentCars.Domain.Enums.Address;

namespace RentCars.Communication.Requests
{
    public class RequestAddressJson
    {
        public string Zip_Code { get; set; } = String.Empty;
        public string City { get; set; } = String.Empty;
        public string Country { get; set; } = String.Empty;
        public string Street { get; set; } = String.Empty;
        public string State { get; set; } = String.Empty;
        public string Neighborhood {  get; set; } = String.Empty;
        public string House_Number { get; set; } = String.Empty;
    }
}
