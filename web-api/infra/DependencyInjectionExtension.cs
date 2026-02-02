using domain.Repository;
using infra.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace infra
{
    public static class DependencyInjectionExtension
    {

        public static void AddInfrastructure(this IServiceCollection service)
        {
            AddRepositories(service);
        }

      

        public static void AddRepositories(IServiceCollection service)
        {
            service.AddScoped<ICategoryRepository, CategoryRepository>();
            service.AddScoped<ITransactionsRepository, TransactionRepository>();
            service.AddScoped<IPersonRepository, PersonRepository>();

        }
    }
}
