namespace CA.Domain.Entities
{
    #region Using

    using System;

    #endregion

    public class BaseEntity
    {
        public int Id { get; set; }
        public DateTime? AddedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string IPAddress { get; set; }

        #region Constructor

        public BaseEntity()
        {
            AddedDate = DateTime.Now;
            ModifiedDate = DateTime.Now;
        }

        #endregion
    }
}
