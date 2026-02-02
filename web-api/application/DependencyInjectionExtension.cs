using application.UseCases.Categories;
using application.UseCases.Categories.Interfaces;
using application.UseCases.Persons;
using application.UseCases.Persons.Interfaces;
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

            service.AddScoped<ICreateCategory, CreateCategoryUseCase>();
            service.AddScoped<IDeleteCategory, DeleteCategoryUseCase>();
            service.AddScoped<IListCategories, ListCategoriesUseCase>();
            service.AddScoped<IUpdateCategory, UpdateCategoryUseCase>();
        }
    }
}
