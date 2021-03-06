﻿// <auto-generated />
using System;
using CA.DataEFCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CA.DataEFCore.Migrations
{
    [DbContext(typeof(EFContext))]
    [Migration("20190214154541_FirstMigration")]
    partial class FirstMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.1-servicing-10028")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CA.Domain.Entities.Address", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("AddedDate")
                        .IsRequired();

                    b.Property<string>("IPAddress");

                    b.Property<DateTime?>("ModifiedDate");

                    b.Property<int>("Number");

                    b.Property<string>("Street")
                        .IsRequired();

                    b.Property<int>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId")
                        .HasName("IFK_User_Address");

                    b.ToTable("Address");
                });

            modelBuilder.Entity("CA.Domain.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("AddedDate")
                        .IsRequired();

                    b.Property<int>("Age");

                    b.Property<DateTime>("BirthDate");

                    b.Property<string>("Email");

                    b.Property<string>("IPAddress");

                    b.Property<DateTime?>("ModifiedDate");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<string>("Password");

                    b.Property<string>("Surname");

                    b.HasKey("Id");

                    b.ToTable("User");
                });

            modelBuilder.Entity("CA.Domain.Entities.Address", b =>
                {
                    b.HasOne("CA.Domain.Entities.User", "User")
                        .WithMany("Addresses")
                        .HasForeignKey("UserId")
                        .HasConstraintName("FK__Address__UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
