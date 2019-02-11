namespace CA.API.Configurations
{
    #region Using

    using System.Runtime.InteropServices;
    using Domain.DbInfo;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using DataEFCore;

    #endregion

    public static class ConfigureConnections
    {
        public static IServiceCollection AddConnectionProvider(this IServiceCollection services,
            IConfiguration configuration)
        {
            var connection = string.Empty;
            
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                connection = configuration.GetConnectionString("ChinookDbWindows") ??
                                 "Server=.;Database=Chinook;Trusted_Connection=True;";
            }
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux) || RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
            {
                connection = configuration.GetConnectionString("ChinookDbDocker") ??
                                 "Server=localhost,1433;Database=Chinook;User=sa;Password=Passw0rd;Trusted_Connection=False;";
            }
            
            services.AddDbContextPool<EFContext>(options => options.UseSqlServer(connection));

            services.AddSingleton(new DbInfo(connection));

            return services;
        }
    }
}