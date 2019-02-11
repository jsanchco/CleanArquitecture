// ReSharper disable InconsistentNaming
namespace CA.Domain.Supervisor
{
    #region Using

    using Repositories;

    #endregion

    public partial class CASupervisor : ICASupervisor
    {
        private readonly IUserRepository _userRepository;
        private readonly IAddressRepository _addressRepository;
        
        public CASupervisor()
        {
        }

        public CASupervisor(IUserRepository userRepository,
            IAddressRepository addressRepository)
        {
            _userRepository = userRepository;
            _addressRepository = addressRepository;
        }
    }
}
