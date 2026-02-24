using Microsoft.EntityFrameworkCore;
using RentCars.Domain.Entities;
using RentCars.Domain.Enums.User;
using RentCars.Domain.Repositories.User;

namespace RentCars.Infrastructure.DataAccess.Repositories
{
    public class UserRepository : IUserReadOnlyRepository, IUserWriteOnlyRepository
    {
        private readonly RentCarsDBContext _dbContext;

        public UserRepository(RentCarsDBContext dbContext) => _dbContext = dbContext;

        public async Task Add(User user)
        {
            await _dbContext.Users.AddAsync(user);

            await _dbContext.SaveChangesAsync();
        }

        public async Task<bool> ExistUserWithDocument(EnumDocumentType doc_type, string document)
        {
            return await _dbContext.Users.AnyAsync(user => user.Document.Equals(document) && user.Document_Type.Equals(doc_type));
        }

        public async Task<bool> ExistUserWithEmail(string email)
        {
            return await _dbContext.Users.AnyAsync(user => user.Email.Equals(email));
        }

        public async Task<bool> ExistUserWithPhone(string phone, string ddd)
        {
            return await _dbContext.Users.AnyAsync(user => user.Phone_Number.Equals(phone) && user.DDD.Equals(ddd));
        }
    }
}
