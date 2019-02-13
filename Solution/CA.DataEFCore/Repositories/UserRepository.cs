namespace CA.DataEFCore.Repositories
{
    #region Using

    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using Domain.Entities;
    using CA.Domain.Repositories;
    using Microsoft.EntityFrameworkCore;

    #endregion

    public class UserRepository : IUserRepository
    {
        private readonly EFContext _context;

        public UserRepository(EFContext context)
        {
            _context = context;
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        private async Task<bool> UserExists(int id, CancellationToken ct = default(CancellationToken))
        {
            return await GetByIdAsync(id, ct) != null;
        }

        public async Task<User> Authenticate(string email, string password, CancellationToken ct = default(CancellationToken))
        {
            return await _context.User.FirstOrDefaultAsync(x => x.Email == email && x.Password == password, ct);
        }

        public async Task<List<User>> GetAllAsync(CancellationToken ct = default(CancellationToken))
        {
            return await _context.User.ToListAsync(ct);
        }

        public async Task<User> GetByIdAsync(int id, CancellationToken ct = default(CancellationToken))
        {
            return await _context.User.FirstOrDefaultAsync(x => x.Id == id, ct);
        }

        public async Task<User> AddAsync(User newUser, CancellationToken ct = default(CancellationToken))
        {
            _context.User.Add(newUser);
            await _context.SaveChangesAsync(ct);
            return newUser;
        }

        public async Task<bool> UpdateAsync(User user, CancellationToken ct = default(CancellationToken))
        {
            if (!await UserExists(user.Id, ct))
                return false;

            _context.User.Update(user);
            await _context.SaveChangesAsync(ct);
            return true;
        }

        public async Task<bool> DeleteAsync(int id, CancellationToken ct = default(CancellationToken))
        {
            if (!await UserExists(id, ct))
                return false;

            var toRemove = _context.User.Find(id);
            _context.User.Remove(toRemove);
            await _context.SaveChangesAsync(ct);
            return true;
        }
    }
}
