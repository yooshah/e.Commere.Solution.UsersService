
using Dapper;
using e.Commerce.Core.DTO;
using e.Commerce.Core.Entities;
using e.Commerce.Core.RepositoryContracts;
using e.Commerece.Infrastucture.DbContext;

namespace e.Commerece.Infrastucture.Repository;

internal class UsersRepository : IUsersRepository
{

    private readonly DapperDbContext _dbcontext;

    public UsersRepository(DapperDbContext dbContext)
    {
        _dbcontext = dbContext;
       
    }
    public async Task<ApplicationUser?> AddUser(ApplicationUser user)
    {
        user.UserID = Guid.NewGuid();

        string query= "INSERT INTO public.\"Users\"(\"UserID\", \"Email\", \"PersonName\", \"Gender\", \"Password\") VALUES(@UserID, @Email, @PersonName, @Gender, @Password)";

        int rowCountAffected = await _dbcontext.DbConnection.ExecuteAsync(query, user);
        if (rowCountAffected > 0)
        {
            return user;
        }
        else
        {
            return null;
        }
    }

    public async Task<ApplicationUser?> GetUserByEmailAndPassword(string? email, string? password)
    {

        string query = "SELECT * FROM public.\"Users\" WHERE \"Email\"=@Email AND \"Password\"=@Password";
        var parameters = new { Email = email, Password = password };

        ApplicationUser? user = await _dbcontext.DbConnection.QueryFirstOrDefaultAsync<ApplicationUser>(query, parameters);

        return user;

    }
}
