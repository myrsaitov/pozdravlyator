﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WidePictBoard.Infrastructure.DataAccess;

namespace WidePictBoard.Infrastructure.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    partial class DatabaseContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.3")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ContentTag", b =>
                {
                    b.Property<int>("ContentsId")
                        .HasColumnType("int");

                    b.Property<int>("TagsId")
                        .HasColumnType("int");

                    b.HasKey("ContentsId", "TagsId");

                    b.HasIndex("TagsId");

                    b.ToTable("TagContent");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");

                    b.HasData(
                        new
                        {
                            Id = "d3300ca5-846f-4e6b-ac5f-1d3933115e67",
                            ConcurrencyStamp = "e6e6c8df-8275-471e-91b5-d4333e6e5122",
                            Name = "Admin",
                            NormalizedName = "ADMIN"
                        },
                        new
                        {
                            Id = "185230d2-58d8-4e29-aefd-a257fb82a150",
                            ConcurrencyStamp = "cbdb62a4-023b-4169-aafe-7ab6af4a3a39",
                            Name = "User",
                            NormalizedName = "USER"
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
                            UserId = "98b651ae-c9aa-4731-9996-57352d525f7e",
                            RoleId = "d3300ca5-846f-4e6b-ac5f-1d3933115e67"
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

            modelBuilder.Entity("WidePictBoard.Domain.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ParentCategoryId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("ParentCategoryId");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedAt = new DateTime(2021, 4, 20, 11, 47, 4, 537, DateTimeKind.Utc).AddTicks(9005),
                            IsDeleted = false,
                            Name = "Транспорт"
                        },
                        new
                        {
                            Id = 2,
                            CreatedAt = new DateTime(2021, 4, 20, 11, 47, 4, 537, DateTimeKind.Utc).AddTicks(9790),
                            IsDeleted = false,
                            Name = "Недвижимость"
                        },
                        new
                        {
                            Id = 3,
                            CreatedAt = new DateTime(2021, 4, 20, 11, 47, 4, 537, DateTimeKind.Utc).AddTicks(9794),
                            IsDeleted = false,
                            Name = "Мебель"
                        },
                        new
                        {
                            Id = 4,
                            CreatedAt = new DateTime(2021, 4, 20, 11, 47, 4, 537, DateTimeKind.Utc).AddTicks(9795),
                            IsDeleted = false,
                            Name = "Одежда"
                        },
                        new
                        {
                            Id = 5,
                            CreatedAt = new DateTime(2021, 4, 20, 11, 47, 4, 537, DateTimeKind.Utc).AddTicks(9796),
                            IsDeleted = false,
                            Name = "Бытовая техника"
                        },
                        new
                        {
                            Id = 6,
                            CreatedAt = new DateTime(2021, 4, 20, 11, 47, 4, 537, DateTimeKind.Utc).AddTicks(9797),
                            IsDeleted = false,
                            Name = "Книги"
                        });
                });

            modelBuilder.Entity("WidePictBoard.Domain.Comment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Body")
                        .HasMaxLength(2048)
                        .HasColumnType("nvarchar(2048)");

                    b.Property<int>("ContentId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("OwnerId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int?>("ParentCommentId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("ContentId");

                    b.HasIndex("OwnerId");

                    b.HasIndex("ParentCommentId");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("WidePictBoard.Domain.Content", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Body")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("OwnerId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<decimal>("Price")
                        .HasColumnType("money");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("OwnerId");

                    b.ToTable("Contents");
                });

            modelBuilder.Entity("WidePictBoard.Domain.Tag", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Body")
                        .IsRequired()
                        .HasMaxLength(32)
                        .HasColumnType("nvarchar(32)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Tags");
                });

            modelBuilder.Entity("WidePictBoard.Domain.User", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(100)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("MiddleName")
                        .HasMaxLength(100)
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("DomainUsers");
                });

            modelBuilder.Entity("WidePictBoard.Infrastructure.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

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
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");

                    b.HasData(
                        new
                        {
                            Id = "98b651ae-c9aa-4731-9996-57352d525f7e",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "05ac7b50-96fa-4c91-9240-11730a4c2418",
                            EmailConfirmed = false,
                            LockoutEnabled = false,
                            NormalizedUserName = "ADMIN",
                            PasswordHash = "AQAAAAEAACcQAAAAEIWmywC+T6gCn7NMaTktNQYEruQ+KMqbYajSGUX12nghX+F5ytTpIA+6Co/gRB5KMg==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "91dc2486-36b3-4dc7-880f-12ff3e73b7c8",
                            TwoFactorEnabled = false,
                            UserName = "admin"
                        });
                });

            modelBuilder.Entity("ContentTag", b =>
                {
                    b.HasOne("WidePictBoard.Domain.Content", null)
                        .WithMany()
                        .HasForeignKey("ContentsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WidePictBoard.Domain.Tag", null)
                        .WithMany()
                        .HasForeignKey("TagsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("WidePictBoard.Infrastructure.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("WidePictBoard.Infrastructure.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WidePictBoard.Infrastructure.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("WidePictBoard.Infrastructure.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("WidePictBoard.Domain.Category", b =>
                {
                    b.HasOne("WidePictBoard.Domain.Category", "ParentCategory")
                        .WithMany("ChildCategories")
                        .HasForeignKey("ParentCategoryId");

                    b.Navigation("ParentCategory");
                });

            modelBuilder.Entity("WidePictBoard.Domain.Comment", b =>
                {
                    b.HasOne("WidePictBoard.Domain.Content", "Content")
                        .WithMany("Comments")
                        .HasForeignKey("ContentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WidePictBoard.Domain.User", "Owner")
                        .WithMany()
                        .HasForeignKey("OwnerId");

                    b.HasOne("WidePictBoard.Domain.Comment", "ParentComment")
                        .WithMany()
                        .HasForeignKey("ParentCommentId");

                    b.Navigation("Content");

                    b.Navigation("Owner");

                    b.Navigation("ParentComment");
                });

            modelBuilder.Entity("WidePictBoard.Domain.Content", b =>
                {
                    b.HasOne("WidePictBoard.Domain.Category", "Category")
                        .WithMany("Contents")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WidePictBoard.Domain.User", "Owner")
                        .WithMany()
                        .HasForeignKey("OwnerId");

                    b.Navigation("Category");

                    b.Navigation("Owner");
                });

            modelBuilder.Entity("WidePictBoard.Domain.Category", b =>
                {
                    b.Navigation("ChildCategories");

                    b.Navigation("Contents");
                });

            modelBuilder.Entity("WidePictBoard.Domain.Content", b =>
                {
                    b.Navigation("Comments");
                });
#pragma warning restore 612, 618
        }
    }
}
