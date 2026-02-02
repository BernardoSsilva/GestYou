using System;
using System.Collections.Generic;
using System.Text;

namespace application.UseCases.Persons.Interfaces
{
    public interface IDeletePerson
    {
        Task Execute(int id);
    }
}
