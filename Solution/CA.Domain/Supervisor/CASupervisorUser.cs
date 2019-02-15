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
    using System.IdentityModel.Tokens.Jwt;
    using System.Security.Claims;
    using System.Text;
    using Microsoft.IdentityModel.Tokens;

    #endregion

    public partial class CASupervisor
    {
        public async Task<UserViewModel> Authenticate(string email, string password, CancellationToken ct = default(CancellationToken))
        {
            var userViewModel = UserConverter.Convert(await _userRepository.Authenticate(email, password, ct));
            if (userViewModel == null)
                return null;

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, userViewModel.Id.ToString())
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            userViewModel.Token = tokenHandler.WriteToken(token);

            return userViewModel;
        }

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
                BirthDate = newUserViewModel.BirthDate,
                Email = newUserViewModel.Email,
                Password = newUserViewModel.Password
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
            user.Email = userViewModel.Email;
            user.Password = userViewModel.Password;

            return await _userRepository.UpdateAsync(user, ct);
        }

        public async Task<bool> DeleteUserAsync(int id, CancellationToken ct = default(CancellationToken))
        {
            return await _userRepository.DeleteAsync(id, ct);
        }
    }
}
