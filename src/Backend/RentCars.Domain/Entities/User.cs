using RentCars.Domain.Enums.User;

namespace RentCars.Domain.Entities
{
    public class User
    {
        public long Id { get; set; }
        public DateTime CreatedOn { get; set; } = DateTime.UtcNow;
        public DateTime ModifiedOn { get; set; } = DateTime.UtcNow;
        public bool Active { get; set; } = true;

        // Atributos recebidos do cadastro
        public string Name { get; set; } = String.Empty;
        public string Lastname { get; set; } = String.Empty;
        public string Document { get; set; } = String.Empty;
        public EnumDocumentType Document_Type {  get; set; }
        public DateTime Birth_Date {  get; set; }
        public string Email {  get; set; } = String.Empty;
        public string DDD { get; set; } = String.Empty;
        public string Phone_Number { get; set; } = String.Empty;
        public string Password { get; set; } = String.Empty;
        public string Zip_Code {  get; set; } = String.Empty;
        public string City {  get; set; } = String.Empty;
        public string Country { get; set; } = String.Empty;
        public string Street {  get; set; } = String.Empty;
        public string State { get; set; } = String.Empty;
        public string House_Number {  get; set; } = String.Empty;
        public EnumGender Gender {  get; set; }

    }
}
