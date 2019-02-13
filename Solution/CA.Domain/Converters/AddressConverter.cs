namespace CA.Domain.Converters
{
    #region Using

    using System.Collections.Generic;
    using System.Linq;
    using Entities;
    using ViewModels;

    #endregion

    public static class AddressConverter
    {
        public static AddressViewModel Convert(Address address)
        {
            if (address == null)
                return null;

            var addressViewModel = new AddressViewModel
            {
                Id = address.Id,
                AddedDate = address.AddedDate,
                ModifiedDate = address.ModifiedDate,
                IPAddress = address.IPAddress,
                
                Street = address.Street,
                Number = address.Number,
                UserId = address.UserId
            };

            return addressViewModel;
        }

        public static List<AddressViewModel> ConvertList(IEnumerable<Address> addresses)
        {
            return addresses?.Select(user =>
                {
                    var model = new AddressViewModel
                    {
                        Id = user.Id,
                        AddedDate = user.AddedDate,
                        ModifiedDate = user.ModifiedDate,
                        IPAddress = user.IPAddress,

                        Street = user.Street,
                        Number = user.Number,
                        UserId = user.UserId
                    };
                    return model;
                })
                .ToList();
        }
    }
}
