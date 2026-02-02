using comunication.responses;
using domain.entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace application.UseCases.Persons.Interfaces
{
    public interface IListPersons
    {

        Task<List<PersonJsonResponse>> Execute();
    }
}
