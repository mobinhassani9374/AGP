﻿using AGP.DataLayer;
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
    [Migration("20180928074850_AccountGame")]
    partial class AccountGame
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.3-rtm-10026")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("AGP.DataLayer.Entities.AccountGame", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime?>("BuyDate");

                    b.Property<int>("BuyState");

                    b.Property<DateTime>("CreateDate");

                    b.Property<string>("Description");

                    b.Property<int>("GameId");

                    b.Property<bool>("IsActive");

                    b.Property<bool>("IsDeActiveByAdmin");

                    b.Property<bool>("IsDone");

                    b.Property<string>("Level");

                    b.Property<decimal>("Price");

                    b.Property<string>("ReasonForCancel");

                    b.Property<string>("ReasonForDeActiveByAdmin");

                    b.Property<DateTime?>("RequestDate");

                    b.Property<int>("State");

                    b.Property<int>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("GameId");

                    b.HasIndex("UserId");

                    b.ToTable("AccountGames");
                });

            modelBuilder.Entity("AGP.DataLayer.Entities.Game", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatDate");

                    b.Property<string>("DisplayName");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Games");
                });

            modelBuilder.Entity("AGP.DataLayer.Entities.ImageGame", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("GameId");

                    b.Property<string>("ImageName");

                    b.HasKey("Id");

                    b.HasIndex("GameId");

                    b.ToTable("ImageGames");
                });

            modelBuilder.Entity("AGP.DataLayer.Entities.LogService", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<TimeSpan>("Elapsed");

                    b.Property<string>("Method")
                        .HasMaxLength(10);

                    b.Property<string>("QueryString");

                    b.Property<string>("RelativePath");

                    b.Property<long?>("RequestContentLength");

                    b.Property<string>("RequestIp");

                    b.Property<long?>("ResponseContentLength");

                    b.Property<int>("StatusCode");

                    b.Property<int?>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("LogServices");
                });

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

            modelBuilder.Entity("AGP.DataLayer.Entities.AccountGame", b =>
                {
                    b.HasOne("AGP.DataLayer.Entities.Game", "Game")
                        .WithMany("AccountGames")
                        .HasForeignKey("GameId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("AGP.DataLayer.Entities.User", "User")
                        .WithMany("AccountGames")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("AGP.DataLayer.Entities.ImageGame", b =>
                {
                    b.HasOne("AGP.DataLayer.Entities.Game", "Game")
                        .WithMany("Images")
                        .HasForeignKey("GameId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("AGP.DataLayer.Entities.LogService", b =>
                {
                    b.HasOne("AGP.DataLayer.Entities.User", "User")
                        .WithMany("LogServices")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
