// ReSharper disable InconsistentNaming
namespace CA.Domain.Supervisor
{
    #region Using

    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using ViewModels;

    #endregion

    public interface ICASupervisor
    {
        #region Address

        Task<List<AddressViewModel>> GetAllAddressAsync(CancellationToken ct = default(CancellationToken));
        Task<AddressViewModel> GetAddressByIdAsync(int id, CancellationToken ct = default(CancellationToken));
        Task<List<AddressViewModel>> GetAddressesByUserIdAsync(int id, CancellationToken ct = default(CancellationToken));
        Task<AddressViewModel> AddAddressAsync(AddressViewModel newAddressViewModel, CancellationToken ct = default(CancellationToken));
        Task<bool> UpdateAddressAsync(AddressViewModel addressViewModel, CancellationToken ct = default(CancellationToken));
        Task<bool> DeleteAddressAsync(int id, CancellationToken ct = default(CancellationToken));

        #endregion

        #region User

        Task<List<UserViewModel>> GetAllUserAsync(CancellationToken ct = default(CancellationToken));
        Task<UserViewModel> GetUserByIdAsync(int id, CancellationToken ct = default(CancellationToken));
        Task<UserViewModel> AddUserAsync(UserViewModel newUserViewModel, CancellationToken ct = default(CancellationToken));
        Task<bool> UpdateUserAsync(UserViewModel userViewModel, CancellationToken ct = default(CancellationToken));
        Task<bool> DeleteUserAsync(int id, CancellationToken ct = default(CancellationToken));

        #endregion
    }
}
