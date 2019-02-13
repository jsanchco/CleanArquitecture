namespace CA.Domain.Converters
{
    #region Using

    using System.Collections.Generic;
    using ViewModels;
    using Entities;
    using System.Linq;

    #endregion

    public static class UserConverter
    {
        public static UserViewModel Convert(User user)
        {
            if (user == null)
                return null;

            var userViewModel = new UserViewModel
            {
                Id = user.Id,
                AddedDate = user.AddedDate,                                           
                ModifiedDate = user.ModifiedDate,
                IPAddress = user.IPAddress,
                Name = user.Name,
                Surname = user.Surname,
                Age = user.Age,
                BirthDate = user.BirthDate,
            };

            return userViewModel;
        }

        public static List<UserViewModel> ConvertList(IEnumerable<User> users)
        {
            return users?.Select(user =>
                {
                    var model = new UserViewModel
                    {
                        Id = user.Id,
                        AddedDate = user.AddedDate,
                        ModifiedDate = user.ModifiedDate,
                        IPAddress = user.IPAddress,
                        Name = user.Name,
                        Surname = user.Surname,
                        Age = user.Age,
                        BirthDate = user.BirthDate,
                    };
                    return model;
                })
                .ToList();
        }
    }
}
