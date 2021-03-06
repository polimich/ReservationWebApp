﻿// <auto-generated />
using System;
using API_MP.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace API_MP.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("API_MP.Model.ApplicationRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");

                    b.HasData(
                        new
                        {
                            Id = "96543567-02a1-4cb0-8dcc-a5df3d150ff4",
                            ConcurrencyStamp = "61c16263-f8f9-4c75-8519-caf043e634c1",
                            Name = "Trener",
                            NormalizedName = "TRENER"
                        },
                        new
                        {
                            Id = "2c139fec-776a-453e-adde-62e1d41ab045",
                            ConcurrencyStamp = "44f88cf2-584c-4ef1-bdb4-f03efcc0d85c",
                            Name = "Student",
                            NormalizedName = "STUDENT"
                        });
                });

            modelBuilder.Entity("API_MP.Model.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("WhatITeach")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");

                    b.HasData(
                        new
                        {
                            Id = "1",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "3b7d1a7c-7abf-46af-a708-c0a188672965",
                            Email = "trener@gmail.com",
                            EmailConfirmed = true,
                            FirstName = "Pavel",
                            LastName = "Markovič",
                            LockoutEnabled = false,
                            NormalizedEmail = "TRENER@GMAIL.COM",
                            NormalizedUserName = "TRENER@GMAIL.COM",
                            PasswordHash = "AQAAAAEAACcQAAAAEDivsU7wpgXV33DF7ngjoNR41eL2jYZ+fKv3qkz+9tuwkZip+r5uVbxDm5RSiKG3AQ==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "5d563be7-2e65-421d-93ba-2008ae2b04b3",
                            TwoFactorEnabled = false,
                            UserName = "trener@gmail.com",
                            WhatITeach = "Tenis"
                        },
                        new
                        {
                            Id = "2",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "62613bea-d27a-4271-970b-68169f7de914",
                            Email = "student@gmail.com",
                            EmailConfirmed = true,
                            FirstName = "Michael",
                            LastName = "Polívka",
                            LockoutEnabled = false,
                            NormalizedEmail = "STUDENT@GMAIL.COM",
                            NormalizedUserName = "STUDENT@GMAIL.COM",
                            PasswordHash = "AQAAAAEAACcQAAAAEDSgdgPmZMfLeuRySz1o5CZdZkx0h81Hmq8Ra5bM8Hx6fqV4CiELC/pyllay+295vw==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "1cbedfeb-c06d-4087-9b61-e4cc1aaa99b5",
                            TwoFactorEnabled = false,
                            UserName = "student@gmail.com"
                        });
                });

            modelBuilder.Entity("API_MP.Model.Change", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ChangeType")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("Changes");
                });

            modelBuilder.Entity("API_MP.Model.Hour", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("End")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Person")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Requester")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Start")
                        .HasColumnType("datetime2");

                    b.Property<bool>("isOnetime")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("Hours");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            End = new DateTime(2021, 2, 22, 9, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Tenis",
                            Person = "2",
                            Requester = "1",
                            Start = new DateTime(2021, 2, 22, 8, 0, 0, 0, DateTimeKind.Unspecified),
                            isOnetime = true
                        },
                        new
                        {
                            Id = 2,
                            End = new DateTime(2021, 2, 22, 12, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Tenis",
                            Person = "2",
                            Requester = "1",
                            Start = new DateTime(2021, 2, 22, 11, 0, 0, 0, DateTimeKind.Unspecified),
                            isOnetime = false
                        },
                        new
                        {
                            Id = 3,
                            End = new DateTime(2021, 2, 23, 9, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Tenis",
                            Person = "2",
                            Requester = "1",
                            Start = new DateTime(2021, 2, 23, 8, 0, 0, 0, DateTimeKind.Unspecified),
                            isOnetime = false
                        },
                        new
                        {
                            Id = 4,
                            End = new DateTime(2021, 2, 23, 13, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Tenis",
                            Person = "2",
                            Requester = "1",
                            Start = new DateTime(2021, 2, 23, 12, 0, 0, 0, DateTimeKind.Unspecified),
                            isOnetime = false
                        },
                        new
                        {
                            Id = 5,
                            End = new DateTime(2021, 2, 24, 9, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Tenis",
                            Person = "2",
                            Requester = "1",
                            Start = new DateTime(2021, 2, 24, 8, 0, 0, 0, DateTimeKind.Unspecified),
                            isOnetime = true
                        },
                        new
                        {
                            Id = 6,
                            End = new DateTime(2021, 2, 24, 14, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Tenis",
                            Person = "2",
                            Requester = "1",
                            Start = new DateTime(2021, 2, 24, 13, 0, 0, 0, DateTimeKind.Unspecified),
                            isOnetime = true
                        },
                        new
                        {
                            Id = 7,
                            End = new DateTime(2021, 2, 25, 9, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Tenis",
                            Person = "2",
                            Requester = "1",
                            Start = new DateTime(2021, 2, 25, 8, 0, 0, 0, DateTimeKind.Unspecified),
                            isOnetime = false
                        },
                        new
                        {
                            Id = 8,
                            End = new DateTime(2021, 2, 25, 11, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Tenis",
                            Person = "2",
                            Requester = "1",
                            Start = new DateTime(2021, 2, 25, 10, 0, 0, 0, DateTimeKind.Unspecified),
                            isOnetime = false
                        },
                        new
                        {
                            Id = 9,
                            End = new DateTime(2021, 2, 26, 9, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Tenis",
                            Person = "2",
                            Requester = "1",
                            Start = new DateTime(2021, 2, 26, 8, 0, 0, 0, DateTimeKind.Unspecified),
                            isOnetime = false
                        },
                        new
                        {
                            Id = 10,
                            End = new DateTime(2021, 2, 26, 16, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Tenis",
                            Person = "2",
                            Requester = "1",
                            Start = new DateTime(2021, 2, 26, 15, 0, 0, 0, DateTimeKind.Unspecified),
                            isOnetime = true
                        },
                        new
                        {
                            Id = 19,
                            End = new DateTime(2021, 3, 1, 9, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Tenis",
                            Person = "2",
                            Requester = "1",
                            Start = new DateTime(2021, 3, 1, 8, 0, 0, 0, DateTimeKind.Unspecified),
                            isOnetime = false
                        },
                        new
                        {
                            Id = 20,
                            End = new DateTime(2021, 3, 1, 16, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Tenis",
                            Person = "2",
                            Requester = "1",
                            Start = new DateTime(2021, 3, 1, 15, 0, 0, 0, DateTimeKind.Unspecified),
                            isOnetime = true
                        },
                        new
                        {
                            Id = 11,
                            End = new DateTime(2021, 3, 2, 9, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Tenis",
                            Person = "2",
                            Requester = "1",
                            Start = new DateTime(2021, 3, 2, 8, 0, 0, 0, DateTimeKind.Unspecified),
                            isOnetime = true
                        },
                        new
                        {
                            Id = 12,
                            End = new DateTime(2021, 3, 2, 12, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Tenis",
                            Person = "2",
                            Requester = "1",
                            Start = new DateTime(2021, 3, 2, 11, 0, 0, 0, DateTimeKind.Unspecified),
                            isOnetime = false
                        },
                        new
                        {
                            Id = 13,
                            End = new DateTime(2021, 3, 3, 9, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Tenis",
                            Person = "2",
                            Requester = "1",
                            Start = new DateTime(2021, 3, 3, 8, 0, 0, 0, DateTimeKind.Unspecified),
                            isOnetime = false
                        },
                        new
                        {
                            Id = 14,
                            End = new DateTime(2021, 3, 3, 13, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Tenis",
                            Person = "2",
                            Requester = "1",
                            Start = new DateTime(2021, 3, 3, 12, 0, 0, 0, DateTimeKind.Unspecified),
                            isOnetime = false
                        },
                        new
                        {
                            Id = 15,
                            End = new DateTime(2021, 3, 4, 9, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Tenis",
                            Person = "2",
                            Requester = "1",
                            Start = new DateTime(2021, 3, 4, 8, 0, 0, 0, DateTimeKind.Unspecified),
                            isOnetime = true
                        },
                        new
                        {
                            Id = 16,
                            End = new DateTime(2021, 3, 4, 14, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Tenis",
                            Person = "2",
                            Requester = "1",
                            Start = new DateTime(2021, 3, 4, 13, 0, 0, 0, DateTimeKind.Unspecified),
                            isOnetime = true
                        },
                        new
                        {
                            Id = 17,
                            End = new DateTime(2021, 3, 5, 9, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Tenis",
                            Person = "2",
                            Requester = "1",
                            Start = new DateTime(2021, 3, 5, 8, 0, 0, 0, DateTimeKind.Unspecified),
                            isOnetime = false
                        },
                        new
                        {
                            Id = 18,
                            End = new DateTime(2021, 3, 5, 11, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Tenis",
                            Person = "2",
                            Requester = "1",
                            Start = new DateTime(2021, 3, 5, 10, 0, 0, 0, DateTimeKind.Unspecified),
                            isOnetime = false
                        },
                        new
                        {
                            Id = 29,
                            End = new DateTime(2021, 3, 12, 9, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Tenis",
                            Person = "2",
                            Requester = "1",
                            Start = new DateTime(2021, 3, 12, 8, 0, 0, 0, DateTimeKind.Unspecified),
                            isOnetime = false
                        },
                        new
                        {
                            Id = 30,
                            End = new DateTime(2021, 3, 12, 16, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Tenis",
                            Person = "2",
                            Requester = "1",
                            Start = new DateTime(2021, 3, 12, 15, 0, 0, 0, DateTimeKind.Unspecified),
                            isOnetime = true
                        },
                        new
                        {
                            Id = 21,
                            End = new DateTime(2021, 3, 8, 9, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Tenis",
                            Person = "2",
                            Requester = "1",
                            Start = new DateTime(2021, 3, 8, 8, 0, 0, 0, DateTimeKind.Unspecified),
                            isOnetime = true
                        },
                        new
                        {
                            Id = 22,
                            End = new DateTime(2021, 3, 8, 12, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Tenis",
                            Person = "2",
                            Requester = "1",
                            Start = new DateTime(2021, 3, 8, 11, 0, 0, 0, DateTimeKind.Unspecified),
                            isOnetime = false
                        },
                        new
                        {
                            Id = 23,
                            End = new DateTime(2021, 3, 9, 9, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Tenis",
                            Person = "2",
                            Requester = "1",
                            Start = new DateTime(2021, 3, 9, 8, 0, 0, 0, DateTimeKind.Unspecified),
                            isOnetime = false
                        },
                        new
                        {
                            Id = 24,
                            End = new DateTime(2021, 3, 9, 13, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Tenis",
                            Person = "2",
                            Requester = "1",
                            Start = new DateTime(2021, 3, 9, 12, 0, 0, 0, DateTimeKind.Unspecified),
                            isOnetime = false
                        },
                        new
                        {
                            Id = 25,
                            End = new DateTime(2021, 3, 10, 9, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Tenis",
                            Person = "2",
                            Requester = "1",
                            Start = new DateTime(2021, 3, 10, 8, 0, 0, 0, DateTimeKind.Unspecified),
                            isOnetime = true
                        },
                        new
                        {
                            Id = 26,
                            End = new DateTime(2021, 3, 10, 14, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Tenis",
                            Person = "2",
                            Requester = "1",
                            Start = new DateTime(2021, 3, 10, 13, 0, 0, 0, DateTimeKind.Unspecified),
                            isOnetime = true
                        },
                        new
                        {
                            Id = 27,
                            End = new DateTime(2021, 3, 11, 9, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Tenis",
                            Person = "2",
                            Requester = "1",
                            Start = new DateTime(2021, 3, 11, 8, 0, 0, 0, DateTimeKind.Unspecified),
                            isOnetime = false
                        },
                        new
                        {
                            Id = 28,
                            End = new DateTime(2021, 3, 11, 11, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Tenis",
                            Person = "2",
                            Requester = "1",
                            Start = new DateTime(2021, 3, 11, 10, 0, 0, 0, DateTimeKind.Unspecified),
                            isOnetime = false
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");

                    b.HasData(
                        new
                        {
                            UserId = "1",
                            RoleId = "96543567-02a1-4cb0-8dcc-a5df3d150ff4"
                        },
                        new
                        {
                            UserId = "2",
                            RoleId = "2c139fec-776a-453e-adde-62e1d41ab045"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("API_MP.Model.ApplicationRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("API_MP.Model.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("API_MP.Model.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("API_MP.Model.ApplicationRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("API_MP.Model.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("API_MP.Model.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
