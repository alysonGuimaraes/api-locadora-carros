using RentCars.Domain.Enums.User;

namespace RentCars.Domain.Repositories.User
{
    public interface IUserReadOnlyRepository
    {
        public Task<bool> ExistUserWithEmail(string email);
        public Task<bool> ExistUserWithDocument(EnumDocumentType doc_type, string document);
        public Task<bool> ExistUserWithPhone(string phone, string ddd);
    }
}
