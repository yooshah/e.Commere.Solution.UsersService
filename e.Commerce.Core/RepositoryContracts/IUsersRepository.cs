
using e.Commerce.Core.Entities;

namespace e.Commerce.Core.RepositoryContracts;

public interface IUsersRepository
{

    Task<ApplicationUser?> AddUser(ApplicationUser user);

    Task<ApplicationUser?> GetUserByEmailAndPassword(string? email, string? password);

}
