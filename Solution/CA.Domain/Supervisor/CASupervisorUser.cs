// ReSharper disable InconsistentNaming
namespace CA.Domain.Supervisor
{
    #region Using

    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using ViewModels;
    using Converters;
    using System;
    using Entities;

    #endregion

    public partial class CASupervisor
    {
        public async Task<List<UserViewModel>> GetAllUserAsync(CancellationToken ct = default(CancellationToken))
        {
            return UserConverter.ConvertList(await _userRepository.GetAllAsync(ct));
        }

        public async Task<UserViewModel> GetUserByIdAsync(int id, CancellationToken ct = default(CancellationToken))
        {
            var userViewModel = UserConverter.Convert(await _userRepository.GetByIdAsync(id, ct));
            userViewModel.Addresses = await GetAddressesByUserIdAsync(userViewModel.Id, ct);
            return userViewModel;
        }

        public async Task<UserViewModel> AddUserAsync(UserViewModel newUserViewModel, CancellationToken ct = default(CancellationToken))
        {
            var user = new User
            {
                Id = newUserViewModel.Id,
                AddedDate = DateTime.Now,
                ModifiedDate = null,
                IPAddress = newUserViewModel.IPAddress,

                Name = newUserViewModel.Name,
                Surname = newUserViewModel.Surname,
                Age = newUserViewModel.Age,
                BirthDate = newUserViewModel.BirthDate                
            };

            await _userRepository.AddAsync(user, ct);

            return newUserViewModel;
        }

        public async Task<bool> UpdateUserAsync(UserViewModel userViewModel, CancellationToken ct = default(CancellationToken))
        {
            var user = await _userRepository.GetByIdAsync(userViewModel.Id, ct);

            if (user == null) return false;

            user.ModifiedDate = DateTime.Now;
            user.IPAddress = userViewModel.IPAddress;

            user.Name = userViewModel.Name;
            user.Surname = userViewModel.Surname;
            user.Age = userViewModel.Age;
            user.BirthDate = userViewModel.BirthDate;

            return await _userRepository.UpdateAsync(user, ct);
        }

        public async Task<bool> DeleteUserAsync(int id, CancellationToken ct = default(CancellationToken))
        {
            return await _userRepository.DeleteAsync(id, ct);
        }
    }
}
