// ReSharper disable InconsistentNaming

using CA.DataEFCore;
using CA.DataEFCore.Repositories;
using Microsoft.EntityFrameworkCore;

namespace CA.SeedData
{
    #region Using

    using System;
    using System.IO;
    using Microsoft.Extensions.Configuration;

    #endregion

    internal static class Program
    {
        static void Main()
        {
            Console.Clear();
            Console.WriteLine("*****************************");
            Console.WriteLine("*         Seed Data         *");
            Console.WriteLine("*****************************");
            Console.WriteLine("");
            Console.WriteLine("");

            Console.WriteLine("Press any key to start ...");
            Console.ReadKey();

            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            var configuration = builder.Build();

            var typeSeed = configuration["TypeSeed"];
            switch (typeSeed)
            {
                case "1":
                    break;

                default:
                    Console.WriteLine("Error: Seed no contemplated!!!");
                    break;
            }

            Console.WriteLine("Press any key to exit ...");
            Console.ReadKey();
        }

        private static void SeedFromSQL()
        {
            //var options = new DbContextOptions
            ////<EFContext> (options => options.UseSqlServer(connection)
            //var t = new UserRepository(new EFContext(EFContext > (options => options.UseSqlServer(connection)))
        }

        public enum TypeSeed { SQL = 1, Oracle};
    }
}
