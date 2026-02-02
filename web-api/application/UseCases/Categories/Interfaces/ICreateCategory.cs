using comunication.requests;

namespace application.UseCases.Categories.Interfaces
{
    public interface ICreateCategory
    {
        Task Execute(CategoryDto data);
    }
}
