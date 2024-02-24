﻿using FinancialHub.Auth.Domain.Entities;

namespace FinancialHub.Auth.Domain.Interfaces.Repositories
{
    public interface IUserRepository
    {
        Task<UserEntity?> GetAsync(Guid id);
        Task<UserEntity> CreateAsync(UserEntity user);
        Task<UserEntity> UpdateAsync(UserEntity user);
    }
}
