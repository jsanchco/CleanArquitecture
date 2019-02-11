namespace CA.Domain.ViewModels
{
    #region Using

    using System;

    #endregion

    public class BaseEntityViewModel
    {
        public int Id { get; set; }
        public DateTime? AddedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string IPAddress { get; set; }

        #region Constructor

        public BaseEntityViewModel()
        {
            AddedDate = DateTime.Now;
            ModifiedDate = DateTime.Now;
        }

        #endregion
    }
}
