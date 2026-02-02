using comunication.requests;
using System;
using System.Collections.Generic;
using System.Text;

namespace application.UseCases.Persons.Interfaces
{
    public interface ICreatePerson
    {
        Task Execute(PersonDto data);
    }
}
