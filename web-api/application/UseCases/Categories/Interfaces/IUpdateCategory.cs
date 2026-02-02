using comunication.requests;
using System;
using System.Collections.Generic;
using System.Text;

namespace application.UseCases.Categories.Interfaces
{
    public interface IUpdateCategory
    {
        Task Execute(int categoryId, CategoryDto data);
    }
}
