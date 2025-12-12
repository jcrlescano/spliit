using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Spliit.Core.Interfaces;
using Spliit.Infrastructure.Data;
using Spliit.Infrastructure.Repositories;

namespace Spliit.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ApplicationDbContext>(options =>
            options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));

        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<IGroupRepository, GroupRepository>();
        services.AddScoped<IParticipantRepository, ParticipantRepository>();
        services.AddScoped<IExpenseRepository, ExpenseRepository>();
        services.AddScoped<ICategoryRepository, CategoryRepository>();
        services.AddScoped<IActivityRepository, ActivityRepository>();

        return services;
    }
}
