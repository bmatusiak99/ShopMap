using Microsoft.EntityFrameworkCore;
using Shopify.Api.Entities;

namespace Shopify.Api.Data
{
    public class ShopifyDbContext : DbContext
    {
        public ShopifyDbContext(DbContextOptions<ShopifyDbContext> options) :base(options)
        {
            
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //Products
            //Beauty Category
            modelBuilder.Entity<Product>().HasData(new Product
            {
                Id = 1,
                ProductName = "Glossier - Beauty Kit",
                ProductDescription = "A kit provided by Glossier, containing skin care, hair care and makeup products",
                ProductImageURL = "/Images/Beauty/Beauty1.png",
                ProductPrice = 100,
                ProductQuantity = 100,
                CategoryId = 1

            });
            modelBuilder.Entity<Product>().HasData(new Product
            {
                Id = 2,
                ProductName = "Curology - Skin Care Kit",
                ProductDescription = "A kit provided by Curology, containing skin care products",
                ProductImageURL = "/Images/Beauty/Beauty2.png",
                ProductPrice = 50,
                ProductQuantity = 45,
                CategoryId = 1

            });
            modelBuilder.Entity<Product>().HasData(new Product
            {
                Id = 3,
                ProductName = "Cocooil - Organic Coconut Oil",
                ProductDescription = "A kit provided by Curology, containing skin care products",
                ProductImageURL = "/Images/Beauty/Beauty3.png",
                ProductPrice = 20,
                ProductQuantity = 30,
                CategoryId = 1

            });
            modelBuilder.Entity<Product>().HasData(new Product
            {
                Id = 4,
                ProductName = "Schwarzkopf - Hair Care and Skin Care Kit",
                ProductDescription = "A kit provided by Schwarzkopf, containing skin care and hair care products",
                ProductImageURL = "/Images/Beauty/Beauty4.png",
                ProductPrice = 50,
                ProductQuantity = 60,
                CategoryId = 1

            });
            modelBuilder.Entity<Product>().HasData(new Product
            {
                Id = 5,
                ProductName = "Skin Care Kit",
                ProductDescription = "Skin Care Kit, containing skin care and hair care products",
                ProductImageURL = "/Images/Beauty/Beauty5.png",
                ProductPrice = 30,
                ProductQuantity = 85,
                CategoryId = 1

            });
            //Electronics Category
            modelBuilder.Entity<Product>().HasData(new Product
            {
                Id = 6,
                ProductName = "Air Pods",
                ProductDescription = "Air Pods - in-ear wireless headphones",
                ProductImageURL = "/Images/Electronic/Electronics1.png",
                ProductPrice = 100,
                ProductQuantity = 120,
                CategoryId = 3

            });
            modelBuilder.Entity<Product>().HasData(new Product
            {
                Id = 7,
                ProductName = "On-ear Golden Headphones",
                ProductDescription = "On-ear Golden Headphones - these headphones are not wireless",
                ProductImageURL = "/Images/Electronic/Electronics2.png",
                ProductPrice = 40,
                ProductQuantity = 200,
                CategoryId = 3

            });
            modelBuilder.Entity<Product>().HasData(new Product
            {
                Id = 8,
                ProductName = "On-ear Black Headphones",
                ProductDescription = "On-ear Black Headphones - these headphones are not wireless",
                ProductImageURL = "/Images/Electronic/Electronics3.png",
                ProductPrice = 40,
                ProductQuantity = 300,
                CategoryId = 3

            });
            modelBuilder.Entity<Product>().HasData(new Product
            {
                Id = 9,
                ProductName = "Sennheiser Digital Camera with Tripod",
                ProductDescription = "Sennheiser Digital Camera - High quality digital camera provided by Sennheiser - includes tripod",
                ProductImageURL = "/Images/Electronic/Electronic4.png",
                ProductPrice = 600,
                ProductQuantity = 20,
                CategoryId = 3

            });
            modelBuilder.Entity<Product>().HasData(new Product
            {
                Id = 10,
                ProductName = "Canon Digital Camera",
                ProductDescription = "Canon Digital Camera - High quality digital camera provided by Canon",
                ProductImageURL = "/Images/Electronic/Electronic5.png",
                ProductPrice = 500,
                ProductQuantity = 15,
                CategoryId = 3

            });
            modelBuilder.Entity<Product>().HasData(new Product
            {
                Id = 11,
                ProductName = "Nintendo Gameboy",
                ProductDescription = "Gameboy - Provided by Nintendo",
                ProductImageURL = "/Images/Electronic/technology6.png",
                ProductPrice = 100,
                ProductQuantity = 60,
                CategoryId = 3
            });
            //Furniture Category
            modelBuilder.Entity<Product>().HasData(new Product
            {
                Id = 12,
                ProductName = "Black Leather Office Chair",
                ProductDescription = "Very comfortable black leather office chair",
                ProductImageURL = "/Images/Furniture/Furniture1.png",
                ProductPrice = 50,
                ProductQuantity = 212,
                CategoryId = 2
            });

            modelBuilder.Entity<Product>().HasData(new Product
            {
                Id = 13,
                ProductName = "Pink Leather Office Chair",
                ProductDescription = "Very comfortable pink leather office chair",
                ProductImageURL = "/Images/Furniture/Furniture2.png",
                ProductPrice = 50,
                ProductQuantity = 112,
                CategoryId = 2
            });
            modelBuilder.Entity<Product>().HasData(new Product
            {
                Id = 14,
                ProductName = "Lounge Chair",
                ProductDescription = "Very comfortable lounge chair",
                ProductImageURL = "/Images/Furniture/Furniture3.png",
                ProductPrice = 70,
                ProductQuantity = 90,
                CategoryId = 2
            });
            modelBuilder.Entity<Product>().HasData(new Product
            {
                Id = 15,
                ProductName = "Silver Lounge Chair",
                ProductDescription = "Very comfortable Silver lounge chair",
                ProductImageURL = "/Images/Furniture/Furniture4.png",
                ProductPrice = 120,
                ProductQuantity = 95,
                CategoryId = 2
            });
            modelBuilder.Entity<Product>().HasData(new Product
            {
                Id = 16,
                ProductName = "Porcelain Table Lamp",
                ProductDescription = "White and blue Porcelain Table Lamp",
                ProductImageURL = "/Images/Furniture/Furniture6.png",
                ProductPrice = 15,
                ProductQuantity = 100,
                CategoryId = 2
            });
            modelBuilder.Entity<Product>().HasData(new Product
            {
                Id = 17,
                ProductName = "Office Table Lamp",
                ProductDescription = "Office Table Lamp",
                ProductImageURL = "/Images/Furniture/Furniture7.png",
                ProductPrice = 20,
                ProductQuantity = 73,
                CategoryId = 2
            });
            //Shoes Category
            modelBuilder.Entity<Product>().HasData(new Product
            {
                Id = 18,
                ProductName = "Puma Sneakers",
                ProductDescription = "Comfortable Puma Sneakers in most sizes",
                ProductImageURL = "/Images/Shoes/Shoes1.png",
                ProductPrice = 100,
                ProductQuantity = 50,
                CategoryId = 4
            });
            modelBuilder.Entity<Product>().HasData(new Product
            {
                Id = 19,
                ProductName = "Colorful Trainers",
                ProductDescription = "Colorful trainsers - available in most sizes",
                ProductImageURL = "/Images/Shoes/Shoes2.png",
                ProductPrice = 150,
                ProductQuantity = 60,
                CategoryId = 4
            });
            modelBuilder.Entity<Product>().HasData(new Product
            {
                Id = 20,
                ProductName = "Blue Nike Trainers",
                ProductDescription = "Blue Nike Trainers - available in most sizes",
                ProductImageURL = "/Images/Shoes/Shoes3.png",
                ProductPrice = 200,
                ProductQuantity = 70,
                CategoryId = 4
            });
            modelBuilder.Entity<Product>().HasData(new Product
            {
                Id = 21,
                ProductName = "Colorful Hummel Trainers",
                ProductDescription = "Colorful Hummel Trainers - available in most sizes",
                ProductImageURL = "/Images/Shoes/Shoes4.png",
                ProductPrice = 120,
                ProductQuantity = 120,
                CategoryId = 4
            });
            modelBuilder.Entity<Product>().HasData(new Product
            {
                Id = 22,
                ProductName = "Red Nike Trainers",
                ProductDescription = "Red Nike Trainers - available in most sizes",
                ProductImageURL = "/Images/Shoes/Shoes5.png",
                ProductPrice = 200,
                ProductQuantity = 100,
                CategoryId = 4
            });
            modelBuilder.Entity<Product>().HasData(new Product
            {
                Id = 23,
                ProductName = "Birkenstock Sandles",
                ProductDescription = "Birkenstock Sandles - available in most sizes",
                ProductImageURL = "/Images/Shoes/Shoes6.png",
                ProductPrice = 50,
                ProductQuantity = 150,
                CategoryId = 4
            });

            //Add users
            modelBuilder.Entity<User>().HasData(new User
            {
                Id = Guid.Parse("79e9147f-44e3-4026-8bb6-061ef1cefe4c"),
                FirstName = "Bartosz",
                LastName = "Matusiak",
                Mail = "bartek350z@gmail.com",
                ImageURL = "/Images/Users/Sarah.png",
                Password = "admin",
                RoleId = 2
            });
            modelBuilder.Entity<User>().HasData(new User
            {
                Id = Guid.Parse("3345739f-81df-4e39-8848-85a491fe75e2"),
                FirstName = "Sarah",
                LastName = "Connor",
                Mail = "sarahcon@gmail.com",
                ImageURL = "/Images/Users/Sarah.png",
                Password = "worker",
                RoleId = 1
            });

            //Create Shopping Cart for Users
            modelBuilder.Entity<Cart>().HasData(new Cart
            {
                Id = 1,
                UserId = Guid.Parse("79e9147f-44e3-4026-8bb6-061ef1cefe4c")
                

            });
            modelBuilder.Entity<Cart>().HasData(new Cart
            {
                Id = 2,
                UserId = Guid.Parse("3345739f-81df-4e39-8848-85a491fe75e2")

            });
            //Add Product Categories
            modelBuilder.Entity<ProductCategory>().HasData(new ProductCategory
            {
                Id = 1,
                CategoryName = "Beauty",
                IconCSS = "fas fa-spa"
            });
            modelBuilder.Entity<ProductCategory>().HasData(new ProductCategory
            {
                Id = 2,
                CategoryName = "Furniture",
                IconCSS = "fas fa-couch"
            });
            modelBuilder.Entity<ProductCategory>().HasData(new ProductCategory
            {
                Id = 3,
                CategoryName = "Electronics",
                IconCSS = "fas fa-headphones"
            });
            modelBuilder.Entity<ProductCategory>().HasData(new ProductCategory
            {
                Id = 4,
                CategoryName = "Shoes",
                IconCSS = "fas fa-shoe-prints"
            });
            //Adding shops
            modelBuilder.Entity<Shop>().HasData(new Shop
            {
                Id = 1,
                Name = "Tech-star",
                Description = "Cutting-edge gadgets for gaming and electronics",
                Address = "Żytnia 39",
                City = "Siedlce",
                PostalCode = "08-110",
                PhoneNumber = "123456789"
            });
            modelBuilder.Entity<Shop>().HasData(new Shop
            {
                Id = 2,
                Name = "Radiant Beauty",
                Description = "Luxurious skincare and cosmetics",
                Address = "3 Maja 54",
                City = "Siedlce",
                PostalCode = "08-110",
                PhoneNumber = "987654321",
            });
            modelBuilder.Entity<Shop>().HasData(new Shop
            {
                Id = 3,
                Name = "Home harmony",
                Description = "Furnitures designed for modern living",
                Address = "Józefa Piłsudskiego 74",
                City = "Siedlce",
                PostalCode = "08-110",
                PhoneNumber = "123123123"
            });
        }

        public DbSet<Cart> Carts { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Shop> Shops { get; set; }
    }
}
