namespace CA.Domain.Entities
{
    #region Using

    using System;
    using System.Collections.Generic;

    #endregion

    public class User : BaseEntity
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }
        public DateTime BirthDate { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Token { get; set; }

        public virtual ICollection<Address> Addresses { get; set; } = new HashSet<Address>();
    }
}
