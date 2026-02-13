namespace RentCars.Communication.Requests
{
    public class RequestRegisterUserJson
    {
        public string Name { get; set; } = String.Empty;
        public string Lastname { get; set; } = String.Empty;
        public string Document { get; set; } = String.Empty;
        public string Document_Type { get; set; } = String.Empty;
        public DateTime Birth_Date { get; set; }
        public string Email { get; set; } = String.Empty;
        public string DDD { get; set; } = String.Empty;
        public string Phone_Number { get; set; } = String.Empty;
        public string Password { get; set; } = String.Empty;
        public string Gender { get; set; } = String.Empty;

        // Objeto contendo as informações de endereço
        public RequestAddressJson Address { get; set; } = new();
    }
}
