using application.UseCases.Transactions.Interfaces;
using AutoMapper;
using comunication.responses;
using domain.Repository;
using infra.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace application.UseCases.Transactions
{
    public class GetTransactionsByCategory : IGetTransactionsByCategory
    {
        private readonly ITransactionsRepository _repository;
        private readonly ICategoryRepository _categoryRepository;

        public GetTransactionsByCategory(ITransactionsRepository repository, IMapper mapper, ICategoryRepository categoryRepository)
        {
            _repository = repository;
            _categoryRepository = categoryRepository;
        }
        public async Task<List<TransactionByCategoryJsonResponse>> Execute()
        {
            var groupedTransactions = (await _repository.GetAllTransactions()).GroupBy(x => x.CategoryId);

            List<TransactionByCategoryJsonResponse> finalResponse = new();
            foreach (var group in groupedTransactions)
            {
                float totalRevenues = 0;
                float totalExpenses = 0;
                foreach (var transaction in group)
                {
                    if (transaction.Type == domain.Enums.TransactionTypeEnum.Expense)
                    {
                        totalExpenses += transaction.Value;
                    }
                    else
                    {
                        totalRevenues += transaction.Value;
                    }

                }

                finalResponse.Add(new TransactionByCategoryJsonResponse
                {
                    TotalRevenues = totalRevenues,
                    TotalExpenses = totalExpenses,
                    CategoryId = group.Key,
                    CategoryDescription = (await _categoryRepository.GetCategoryById(group.Key)).Description
                });
            }

            return finalResponse;
        }
    }
}
