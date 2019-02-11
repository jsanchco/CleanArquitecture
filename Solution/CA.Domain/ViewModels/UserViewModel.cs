namespace CA.Domain.ViewModels
{ 
    #region Using

    using System;
    using System.Collections.Generic;

    #endregion

    public class UserViewModel : BaseEntityViewModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }
        public DateTime BirthDate { get; set; }

        public virtual ICollection<AddressViewModel> Addresses { get; set; }
    }
}
