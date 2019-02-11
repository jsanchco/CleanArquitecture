namespace CA.DataEFCore.Repositories
{
    #region Using

    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using Domain.Entities;
    using CA.Domain.Repositories;
    using Microsoft.EntityFrameworkCore;
    using System.Linq;

    #endregion

    public class AddressRepository : IAddressRepository
    {
        private readonly EFContext _context;

        public AddressRepository(EFContext context)
        {
            _context = context;
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        private async Task<bool> AddressExists(int id, CancellationToken ct = default(CancellationToken))
        {
            return await GetByIdAsync(id, ct) != null;
        }

        public async Task<List<Address>> GetAllAsync(CancellationToken ct = default(CancellationToken))
        {
            return await _context.Address.ToListAsync(ct);
        }

        public async Task<Address> GetByIdAsync(int id, CancellationToken ct = default(CancellationToken))
        {
            return await _context.Address.FirstOrDefaultAsync(x => x.Id == id, ct);
        }

        public async Task<List<Address>> GetByUserIdAsync(int id, CancellationToken ct = default(CancellationToken))
        {
            return await _context.Address
                .Where(x => x.UserId == id)
                .ToListAsync(ct);
        }

        public async Task<Address> AddAsync(Address newAddress, CancellationToken ct = default(CancellationToken))
        {
            _context.Address.Add(newAddress);
            await _context.SaveChangesAsync(ct);
            return newAddress;
        }

        public async Task<bool> UpdateAsync(Address address, CancellationToken ct = default(CancellationToken))
        {
            if (!await AddressExists(address.Id, ct))
                return false;

            _context.Address.Update(address);
            await _context.SaveChangesAsync(ct);
            return true;
        }

        public async Task<bool> DeleteAsync(int id, CancellationToken ct = default(CancellationToken))
        {
            if (!await AddressExists(id, ct))
                return false;

            var toRemove = _context.Address.Find(id);
            _context.Address.Remove(toRemove);
            await _context.SaveChangesAsync(ct);
            return true;
        }
    }
}
