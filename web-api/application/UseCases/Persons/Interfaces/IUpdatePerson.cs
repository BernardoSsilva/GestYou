using comunication.requests;
using System;
using System.Collections.Generic;
using System.Text;

namespace application.UseCases.Persons.Interfaces
{
    public interface IUpdatePerson
    {
        Task Execute(int personId, PersonDto data);
    }
}
