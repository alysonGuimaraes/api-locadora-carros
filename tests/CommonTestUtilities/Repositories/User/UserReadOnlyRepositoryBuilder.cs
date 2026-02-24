
using Moq;
using RentCars.Domain.Enums.User;
using RentCars.Domain.Repositories.User;

namespace CommonTestUtilities.Repositories.User
{
    public class UserReadOnlyRepositoryBuilder
    {
        private readonly Mock<IUserReadOnlyRepository> _repository;

        public UserReadOnlyRepositoryBuilder() => _repository = new Mock<IUserReadOnlyRepository>();

        public void ExistUserWithEmail(string email)
        {
            _repository.Setup(repository => repository.ExistUserWithEmail(email)).ReturnsAsync(true);
        }

        public void ExistUserWithDocument(EnumDocumentType doc_type, string document)
        {
            _repository.Setup(repository => repository.ExistUserWithDocument(doc_type, document)).ReturnsAsync(true);
        }

        public void ExistUserWithPhone(string phone, string ddd)
        {
            _repository.Setup(repository => repository.ExistUserWithPhone(phone, ddd)).ReturnsAsync(true);
        }

        public IUserReadOnlyRepository Build()
        {
            return _repository.Object;
        }
    }
}
