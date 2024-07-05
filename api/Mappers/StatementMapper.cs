using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Statement;
using api.Model;

namespace api.Mappers
{
    public static class StatementMapper
    {
         public static StatementDto ToStatementDto(this Statement statement)
        {
            return new StatementDto
            {
                // UserId = statement.UserId,
                TotalBalance = statement.TotalBalance,
                TotalExpense = statement.TotalExpense,
                TotalIncome = statement.TotalIncome,
                ExpensePercentage = statement.ExpensePercentage
            };
        }
    }
}