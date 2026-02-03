using AutoMapper;
using comunication.requests;
using comunication.responses;
using domain.entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace application
{
    public class AutoMapper:Profile
    {

        public AutoMapper()
        {
            RequestToEntity();
            EntityToResonse();
        }
        private void RequestToEntity()
        {
            CreateMap<PersonDto, PersonEntity>();
            CreateMap<CategoryDto, CategoryEntity>();
            CreateMap<TransactionDto, TransactionEntity>();

        }

        private void EntityToResonse()
        {
            CreateMap<PersonEntity, PersonJsonResponse>();
            CreateMap<CategoryEntity, CategoryJsonResponse>();
            CreateMap<TransactionEntity, TransactionJsonResponse>();

        }
    }
}
