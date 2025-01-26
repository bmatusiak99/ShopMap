﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Shopify.Api.Data;

#nullable disable

namespace Shopify.Api.Migrations
{
    [DbContext(typeof(ShopifyDbContext))]
    partial class ShopifyDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Shopify.Api.Entities.Cart", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.ToTable("Carts");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            UserId = new Guid("79e9147f-44e3-4026-8bb6-061ef1cefe4c")
                        },
                        new
                        {
                            Id = 2,
                            UserId = new Guid("3345739f-81df-4e39-8848-85a491fe75e2")
                        });
                });

            modelBuilder.Entity("Shopify.Api.Entities.CartItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CartId")
                        .HasColumnType("int");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("CartItems");
                });

            modelBuilder.Entity("Shopify.Api.Entities.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("OrderDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("ShopId")
                        .HasColumnType("int");

                    b.Property<decimal>("TotalPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("Shopify.Api.Entities.OrderPosition", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("OrderId")
                        .HasColumnType("int");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("ProductPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<decimal>("TotalPrice")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.ToTable("OrderPositions");
                });

            modelBuilder.Entity("Shopify.Api.Entities.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("ProductDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProductImageURL")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("ProductPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("ProductQuantity")
                        .HasColumnType("int");

                    b.Property<int?>("ShelfNumber")
                        .HasColumnType("int");

                    b.Property<int?>("ShopId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ShopId");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CategoryId = 1,
                            ProductDescription = "A kit provided by Glossier, containing skin care, hair care and makeup products",
                            ProductImageURL = "/Images/Beauty/Beauty1.png",
                            ProductName = "Glossier - Beauty Kit",
                            ProductPrice = 100m,
                            ProductQuantity = 100
                        },
                        new
                        {
                            Id = 2,
                            CategoryId = 1,
                            ProductDescription = "A kit provided by Curology, containing skin care products",
                            ProductImageURL = "/Images/Beauty/Beauty2.png",
                            ProductName = "Curology - Skin Care Kit",
                            ProductPrice = 50m,
                            ProductQuantity = 45
                        },
                        new
                        {
                            Id = 3,
                            CategoryId = 1,
                            ProductDescription = "A kit provided by Curology, containing skin care products",
                            ProductImageURL = "/Images/Beauty/Beauty3.png",
                            ProductName = "Cocooil - Organic Coconut Oil",
                            ProductPrice = 20m,
                            ProductQuantity = 30
                        },
                        new
                        {
                            Id = 4,
                            CategoryId = 1,
                            ProductDescription = "A kit provided by Schwarzkopf, containing skin care and hair care products",
                            ProductImageURL = "/Images/Beauty/Beauty4.png",
                            ProductName = "Schwarzkopf - Hair Care and Skin Care Kit",
                            ProductPrice = 50m,
                            ProductQuantity = 60
                        },
                        new
                        {
                            Id = 5,
                            CategoryId = 1,
                            ProductDescription = "Skin Care Kit, containing skin care and hair care products",
                            ProductImageURL = "/Images/Beauty/Beauty5.png",
                            ProductName = "Skin Care Kit",
                            ProductPrice = 30m,
                            ProductQuantity = 85
                        },
                        new
                        {
                            Id = 6,
                            CategoryId = 3,
                            ProductDescription = "Air Pods - in-ear wireless headphones",
                            ProductImageURL = "/Images/Electronic/Electronics1.png",
                            ProductName = "Air Pods",
                            ProductPrice = 100m,
                            ProductQuantity = 120
                        },
                        new
                        {
                            Id = 7,
                            CategoryId = 3,
                            ProductDescription = "On-ear Golden Headphones - these headphones are not wireless",
                            ProductImageURL = "/Images/Electronic/Electronics2.png",
                            ProductName = "On-ear Golden Headphones",
                            ProductPrice = 40m,
                            ProductQuantity = 200
                        },
                        new
                        {
                            Id = 8,
                            CategoryId = 3,
                            ProductDescription = "On-ear Black Headphones - these headphones are not wireless",
                            ProductImageURL = "/Images/Electronic/Electronics3.png",
                            ProductName = "On-ear Black Headphones",
                            ProductPrice = 40m,
                            ProductQuantity = 300
                        },
                        new
                        {
                            Id = 9,
                            CategoryId = 3,
                            ProductDescription = "Sennheiser Digital Camera - High quality digital camera provided by Sennheiser - includes tripod",
                            ProductImageURL = "/Images/Electronic/Electronic4.png",
                            ProductName = "Sennheiser Digital Camera with Tripod",
                            ProductPrice = 600m,
                            ProductQuantity = 20
                        },
                        new
                        {
                            Id = 10,
                            CategoryId = 3,
                            ProductDescription = "Canon Digital Camera - High quality digital camera provided by Canon",
                            ProductImageURL = "/Images/Electronic/Electronic5.png",
                            ProductName = "Canon Digital Camera",
                            ProductPrice = 500m,
                            ProductQuantity = 15
                        },
                        new
                        {
                            Id = 11,
                            CategoryId = 3,
                            ProductDescription = "Gameboy - Provided by Nintendo",
                            ProductImageURL = "/Images/Electronic/technology6.png",
                            ProductName = "Nintendo Gameboy",
                            ProductPrice = 100m,
                            ProductQuantity = 60
                        },
                        new
                        {
                            Id = 12,
                            CategoryId = 2,
                            ProductDescription = "Very comfortable black leather office chair",
                            ProductImageURL = "/Images/Furniture/Furniture1.png",
                            ProductName = "Black Leather Office Chair",
                            ProductPrice = 50m,
                            ProductQuantity = 212
                        },
                        new
                        {
                            Id = 13,
                            CategoryId = 2,
                            ProductDescription = "Very comfortable pink leather office chair",
                            ProductImageURL = "/Images/Furniture/Furniture2.png",
                            ProductName = "Pink Leather Office Chair",
                            ProductPrice = 50m,
                            ProductQuantity = 112
                        },
                        new
                        {
                            Id = 14,
                            CategoryId = 2,
                            ProductDescription = "Very comfortable lounge chair",
                            ProductImageURL = "/Images/Furniture/Furniture3.png",
                            ProductName = "Lounge Chair",
                            ProductPrice = 70m,
                            ProductQuantity = 90
                        },
                        new
                        {
                            Id = 15,
                            CategoryId = 2,
                            ProductDescription = "Very comfortable Silver lounge chair",
                            ProductImageURL = "/Images/Furniture/Furniture4.png",
                            ProductName = "Silver Lounge Chair",
                            ProductPrice = 120m,
                            ProductQuantity = 95
                        },
                        new
                        {
                            Id = 16,
                            CategoryId = 2,
                            ProductDescription = "White and blue Porcelain Table Lamp",
                            ProductImageURL = "/Images/Furniture/Furniture6.png",
                            ProductName = "Porcelain Table Lamp",
                            ProductPrice = 15m,
                            ProductQuantity = 100
                        },
                        new
                        {
                            Id = 17,
                            CategoryId = 2,
                            ProductDescription = "Office Table Lamp",
                            ProductImageURL = "/Images/Furniture/Furniture7.png",
                            ProductName = "Office Table Lamp",
                            ProductPrice = 20m,
                            ProductQuantity = 73
                        },
                        new
                        {
                            Id = 18,
                            CategoryId = 4,
                            ProductDescription = "Comfortable Puma Sneakers in most sizes",
                            ProductImageURL = "/Images/Shoes/Shoes1.png",
                            ProductName = "Puma Sneakers",
                            ProductPrice = 100m,
                            ProductQuantity = 50
                        },
                        new
                        {
                            Id = 19,
                            CategoryId = 4,
                            ProductDescription = "Colorful trainsers - available in most sizes",
                            ProductImageURL = "/Images/Shoes/Shoes2.png",
                            ProductName = "Colorful Trainers",
                            ProductPrice = 150m,
                            ProductQuantity = 60
                        },
                        new
                        {
                            Id = 20,
                            CategoryId = 4,
                            ProductDescription = "Blue Nike Trainers - available in most sizes",
                            ProductImageURL = "/Images/Shoes/Shoes3.png",
                            ProductName = "Blue Nike Trainers",
                            ProductPrice = 200m,
                            ProductQuantity = 70
                        },
                        new
                        {
                            Id = 21,
                            CategoryId = 4,
                            ProductDescription = "Colorful Hummel Trainers - available in most sizes",
                            ProductImageURL = "/Images/Shoes/Shoes4.png",
                            ProductName = "Colorful Hummel Trainers",
                            ProductPrice = 120m,
                            ProductQuantity = 120
                        },
                        new
                        {
                            Id = 22,
                            CategoryId = 4,
                            ProductDescription = "Red Nike Trainers - available in most sizes",
                            ProductImageURL = "/Images/Shoes/Shoes5.png",
                            ProductName = "Red Nike Trainers",
                            ProductPrice = 200m,
                            ProductQuantity = 100
                        },
                        new
                        {
                            Id = 23,
                            CategoryId = 4,
                            ProductDescription = "Birkenstock Sandles - available in most sizes",
                            ProductImageURL = "/Images/Shoes/Shoes6.png",
                            ProductName = "Birkenstock Sandles",
                            ProductPrice = 50m,
                            ProductQuantity = 150
                        });
                });

            modelBuilder.Entity("Shopify.Api.Entities.ProductCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IconCSS")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ProductCategories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CategoryName = "Beauty",
                            IconCSS = "fas fa-spa"
                        },
                        new
                        {
                            Id = 2,
                            CategoryName = "Furniture",
                            IconCSS = "fas fa-couch"
                        },
                        new
                        {
                            Id = 3,
                            CategoryName = "Electronics",
                            IconCSS = "fas fa-headphones"
                        },
                        new
                        {
                            Id = 4,
                            CategoryName = "Shoes",
                            IconCSS = "fas fa-shoe-prints"
                        });
                });

            modelBuilder.Entity("Shopify.Api.Entities.Shop", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PostalCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Shops");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Address = "Żytnia 39",
                            City = "Siedlce",
                            Description = "Cutting-edge gadgets for gaming and electronics",
                            Name = "Tech-star",
                            PhoneNumber = "123456789",
                            PostalCode = "08-110"
                        },
                        new
                        {
                            Id = 2,
                            Address = "3 Maja 54",
                            City = "Siedlce",
                            Description = "Luxurious skincare and cosmetics",
                            Name = "Radiant Beauty",
                            PhoneNumber = "987654321",
                            PostalCode = "08-110"
                        },
                        new
                        {
                            Id = 3,
                            Address = "Józefa Piłsudskiego 74",
                            City = "Siedlce",
                            Description = "Furnitures designed for modern living",
                            Name = "Home harmony",
                            PhoneNumber = "123123123",
                            PostalCode = "08-110"
                        });
                });

            modelBuilder.Entity("Shopify.Api.Entities.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageURL")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Mail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PostalCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = new Guid("79e9147f-44e3-4026-8bb6-061ef1cefe4c"),
                            Address = "Mikłusy 123",
                            City = "Trzebieszów",
                            FirstName = "Bartosz",
                            ImageURL = "/Images/Users/Sarah.png",
                            LastName = "Matusiak",
                            Mail = "bartek350z@gmail.com",
                            Password = "admin",
                            Phone = "123456789",
                            PostalCode = "21-404",
                            RoleId = 2
                        },
                        new
                        {
                            Id = new Guid("3345739f-81df-4e39-8848-85a491fe75e2"),
                            Address = "Sokołowska 110",
                            City = "Siedlce",
                            FirstName = "Sarah",
                            ImageURL = "/Images/Users/Sarah.png",
                            LastName = "Connor",
                            Mail = "sarahcon@gmail.com",
                            Password = "worker",
                            Phone = "123456789",
                            PostalCode = "08-110",
                            RoleId = 1
                        });
                });

            modelBuilder.Entity("Shopify.Api.Entities.OrderPosition", b =>
                {
                    b.HasOne("Shopify.Api.Entities.Order", "Order")
                        .WithMany("OrderPositions")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Order");
                });

            modelBuilder.Entity("Shopify.Api.Entities.Product", b =>
                {
                    b.HasOne("Shopify.Api.Entities.Shop", "Shop")
                        .WithMany("Products")
                        .HasForeignKey("ShopId");

                    b.Navigation("Shop");
                });

            modelBuilder.Entity("Shopify.Api.Entities.Order", b =>
                {
                    b.Navigation("OrderPositions");
                });

            modelBuilder.Entity("Shopify.Api.Entities.Shop", b =>
                {
                    b.Navigation("Products");
                });
#pragma warning restore 612, 618
        }
    }
}
