﻿// <auto-generated />
using AGP.DataLayer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace AGP.DataLayer.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.3-rtm-10026")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("AGP.DataLayer.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreateDate");

                    b.Property<string>("Email");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasMaxLength(250);

                    b.Property<bool>("IsActive");

                    b.Property<bool>("IsAdmin");

                    b.Property<DateTime?>("LastLogoutDate");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(150);

                    b.Property<string>("SerialNumber")
                        .IsRequired()
                        .HasMaxLength(250);

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.HasIndex("UserName")
                        .IsUnique();

                    b.ToTable("Users");
                });
#pragma warning restore 612, 618
        }
    }
}
