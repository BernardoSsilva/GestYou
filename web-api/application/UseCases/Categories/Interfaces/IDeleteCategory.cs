using System;
using System.Collections.Generic;
using System.Text;

namespace application.UseCases.Categories.Interfaces
{
    public interface IDeleteCategory
    {
        Task Execute(int id);
    }
}
