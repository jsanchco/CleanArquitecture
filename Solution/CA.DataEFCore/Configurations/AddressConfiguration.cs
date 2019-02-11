namespace CA.DataEFCore.Configurations
{
    #region Using

    using Domain.Entities;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    #endregion

    public class AddressConfiguration
    {
        public AddressConfiguration(EntityTypeBuilder<Address> entity)
        {
            entity.ToTable("Address");

            entity.HasKey(x => x.Id);
            entity.Property(x => x.AddedDate).IsRequired();
            entity.Property(x => x.Street).IsRequired();

            entity.HasIndex(x => x.UserId).HasName("IFK_User_Address");
            entity.HasOne(u => u.User).WithMany(a => a.Addresses).HasForeignKey(a => a.UserId).HasConstraintName("FK__Address__UserId");
        }
    }
}
