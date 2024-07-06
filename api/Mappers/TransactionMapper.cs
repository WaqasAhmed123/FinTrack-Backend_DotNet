using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Transaction;
using api.Dtos.TransactionDto;
using api.Interfaces;
using api.Model;

namespace api.Mappers
{
    public static class TransactionMapper
    {
        public static async Task<TransactionDto> ToTransactionDto(this Transaction transactionModel
        , ICategoryRepository categoryRepository
        )
        {
            var category = await categoryRepository.GetCategoryNameById(transactionModel.CategoryId);

            return new TransactionDto
            {
                // UserId = userModel.UserId,
                TransactionId = transactionModel.TransactionId,
                Title = transactionModel.Title,
                Date = transactionModel.Date,
                Description = transactionModel.Description,
                // CategoryName = transactionModel.Category?.CategoryName,
                // CategoryName = transactionModel.CategoryId,
                CategoryName = category.CategoryName,
                Amount = transactionModel.Amount,
                IsIncome = transactionModel.IsIncome,
            };
        }

        public static async Task<Transaction> ToTransactionFromCreateDTOAsync(
             this CreateTransactionRequestDto createTransactionRequestDto, ICategoryRepository categoryRepository)
        {
            // Lookup the category by name
            var category = await categoryRepository.GetCategoryIdByName(createTransactionRequestDto.CategoryName);

            // if (category == null)
            // {
            //     // Handle the case where the category is not found
            //     throw new KeyNotFoundException($"Category '{createTransactionRequestDto.CategoryName}' not found.");
            // }

            return new Transaction
            {
                UserId = createTransactionRequestDto.UserId,
                Title = createTransactionRequestDto.Title,
                Date = createTransactionRequestDto.Date,
                Description = createTransactionRequestDto.Description,
                CategoryId = category.CategoryId,
                Amount = createTransactionRequestDto.Amount,
                IsIncome = createTransactionRequestDto.IsIncome,
            };
        }

    }
}