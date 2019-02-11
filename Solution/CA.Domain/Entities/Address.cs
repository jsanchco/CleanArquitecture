namespace CA.Domain.Entities
{
    #region Using

    using System.ComponentModel.DataAnnotations;

    #endregion

    public class Address : BaseEntity
    {
        public string Street { get; set; }
        public int Number { get; set; }

        public int UserId { get; set; }
        public virtual User User { get; set; }
    }
}
