using comunication.responses;

namespace application.UseCases.Categories.Interfaces
{
    public interface IListCategories
    {

        Task<List<CategoryJsonResponse>> Execute();
    }
}
