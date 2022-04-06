﻿using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using FinancialHub.Domain.Models;
using FinancialHub.Domain.Filters;
using FinancialHub.Domain.Results;

namespace FinancialHub.Domain.Interfaces.Services
{
    public interface ITransactionsService
    {
        Task<ServiceResult<ICollection<TransactionModel>>> GetAllByUserAsync(string userId, TransactionFilter filter);

        Task<ServiceResult<TransactionModel>> CreateAsync(TransactionModel account);

        Task<ServiceResult<TransactionModel>> UpdateAsync(Guid id, TransactionModel account);

        Task<ServiceResult<int>> DeleteAsync(Guid id);
    }
}