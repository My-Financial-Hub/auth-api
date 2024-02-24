﻿using FinancialHub.Auth.Domain.Models;

namespace FinancialHub.Auth.Domain.Interfaces.Providers
{
    public interface IUserProvider
    {
        Task<UserModel?> GetAsync(Guid id);
        Task<UserModel> CreateAsync(UserModel user);
        Task<UserModel> UpdateAsync(UserModel user);
    }
}
