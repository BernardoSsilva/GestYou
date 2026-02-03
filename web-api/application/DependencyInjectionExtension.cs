using application.UseCases.Categories;
using application.UseCases.Categories.Interfaces;
using application.UseCases.Persons;
using application.UseCases.Persons.Interfaces;
using application.UseCases.Transactions;
using application.UseCases.Transactions.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace application
{
    public static class DependencyInjectionExtension
    {
        public static void AddApplication(this IServiceCollection service)
        {
            AddUseCases(service);
            AddAutoMapper(service);
        }

        public static void AddAutoMapper(IServiceCollection service)
        {
            service.AddAutoMapper(cfg =>
            {
                cfg.AddProfile<AutoMapper>();
            }, typeof(AutoMapper).Assembly);
        }

        private static void AddUseCases(IServiceCollection service)
        {
            service.AddScoped<ICreatePerson, CreatePersonUseCase>();
            service.AddScoped<IDeletePerson, DeletePersonUseCase>();
            service.AddScoped<IListPersons, ListPersonsUseCase>();
            service.AddScoped<IUpdatePerson, UpdatePersonUseCase>();

            service.AddScoped<ICreateTransaction, CreateTransactionUseCase>();
            service.AddScoped<IDeleteTransaction, DeleteTransactionUseCase>();
            service.AddScoped<IListTransactions, ListTransactionsUseCase>();
            service.AddScoped<IUpdateTransaction, UpdateTransactionUseCase>();
            service.AddScoped<IGetTransactionsByCategory, GetTransactionsByCategory>();
            service.AddScoped<IGetTransactionsByPerson, GetTransactionsByPerson>();

            service.AddScoped<ICreateCategory, CreateCategoryUseCase>();
            service.AddScoped<IDeleteCategory, DeleteCategoryUseCase>();
            service.AddScoped<IListCategories, ListCategoriesUseCase>();
            service.AddScoped<IUpdateCategory, UpdateCategoryUseCase>();
        }
    }
}
