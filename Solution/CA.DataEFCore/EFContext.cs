// ReSharper disable InconsistentNaming
namespace CA.DataEFCore
{
    #region Using

    using Microsoft.EntityFrameworkCore;
    using System.Threading;
    using Configurations;
    using Domain.Entities;

    #endregion

    public class EFContext : DbContext
    {
        #region Members

        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<Address> Address { get; set; }

        public static long InstanceCount;

        #endregion

        public EFContext(DbContextOptions options) : base(options) => Interlocked.Increment(ref InstanceCount);

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            new UserConfiguration(modelBuilder.Entity<User>());
            new AddressConfiguration(modelBuilder.Entity<Address>());
        }
    }
}
