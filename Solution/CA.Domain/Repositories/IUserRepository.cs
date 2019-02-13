namespace CA.Domain.Repositories
{
    #region Using

    using System;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using Entities;

    #endregion

    public interface IUserRepository : IDisposable
    {
        Task<User> Authenticate(string email, string password, CancellationToken ct = default(CancellationToken));
        Task<List<User>> GetAllAsync(CancellationToken ct = default(CancellationToken));
        Task<User> GetByIdAsync(int id, CancellationToken ct = default(CancellationToken));        
        Task<User> AddAsync(User newUser, CancellationToken ct = default(CancellationToken));
        Task<bool> UpdateAsync(User user, CancellationToken ct = default(CancellationToken));
        Task<bool> DeleteAsync(int id, CancellationToken ct = default(CancellationToken));
    }
}
