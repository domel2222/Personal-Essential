﻿using Domain.Entities;

namespace Domain.Repositories
{
    public interface IUserRepository
    {
        bool CheckEmail(string email);

        Task<IEnumerable<User>> GetAllActiveUserAsync(CancellationToken cancellationToken = default);

        Task<User> GetUserByIdAsync(Guid id, CancellationToken cancellationToken = default);

        void Insert(User user);

        void Remove(User user);
    }
}