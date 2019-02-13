namespace CA.Domain.ViewModels
{
    #region Using

    #endregion

    public class AddressViewModel : BaseEntityViewModel
    {
        public string Street { get; set; }
        public int Number { get; set; }
        public int UserId { get; set; }
        public string UserName { get; set; }
        public virtual UserViewModel User { get; set; }
    }
}
