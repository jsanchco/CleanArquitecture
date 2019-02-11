namespace CA.DataEFCore.Configurations
{
    #region Using

    using Domain.Entities;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Microsoft.EntityFrameworkCore;

    #endregion

    public class UserConfiguration
    {
        public UserConfiguration(EntityTypeBuilder<User> entity)
        {
            entity.ToTable("User");

            entity.HasKey(x => x.Id);
            entity.Property(x => x.Id).ValueGeneratedOnAdd();

            entity.Property(x => x.AddedDate).IsRequired();
            entity.Property(x => x.Name).IsRequired();
        }
    }
}
