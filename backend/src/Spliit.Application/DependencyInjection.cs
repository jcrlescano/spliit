using Microsoft.Extensions.DependencyInjection;
using Spliit.Application.Interfaces;
using Spliit.Application.Services;

namespace Spliit.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<IGroupService, GroupService>();
        services.AddScoped<IExpenseService, ExpenseService>();

        return services;
    }
}
