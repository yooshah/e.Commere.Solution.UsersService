using e.Commerce.Core.RepositoryContracts;
using e.Commerece.Infrastucture.DbContext;
using e.Commerece.Infrastucture.Repository;
using Microsoft.Extensions.DependencyInjection;
namespace e.Commerece.Infrastucture;

public static class DependencyInjection
{

    /// <summary>
    ///  Extension method to add infrastructure services to the dependency injection container
    /// </summary>
    /// <param name="services"></param>
    /// <returns></returns>

    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {

        //TO DO: Add services to the IoC container
        //Infrastructure services often include data access, caching and other low-level components.

        services.AddSingleton<IUsersRepository,UsersRepository>();

        // no need o interface scince the dbContext only contain the constructure
        services.AddTransient<DapperDbContext>();
        return services;
    }


}
