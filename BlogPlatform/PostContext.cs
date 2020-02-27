using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace BlogPlatform.Models
{
    public class PostDbContext : DbContext
    {
        public PostDbContext()
        {
        }
        public PostDbContext(DbContextOptions<PostDbContext> options) : base(options)
        {
        }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<PostTag> PostsTaqs { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = "Server=(localdb)\\mssqllocaldb;Database=OurPostDb;Trusted_Connection=True;";
            optionsBuilder.UseSqlServer(connectionString)
                          .UseLazyLoadingProxies();
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //   DateTime date = new DateTime();
            string date = DateTime.Now.ToString("dd/MM/yyyy");
            modelBuilder.Entity<Post>().HasData(
                new Post()
                {
                    Id = 1,
                    Title = "BMW",
                    Author = "Jason",
                    Description = "the best",
                    PublishDate = date,
                    CategoryId = 1,
                },
               new Post()
               {
                   Id = 2,
                   Title = "Travel",
                   Author = "Ali",
                   PublishDate = date,
                   Description = "Fun travel spot",
                   CategoryId = 2,
               },
                new Post()
                {
                    Id = 3,
                    Title = "Travel",
                    Author = "Ghassan",
                    PublishDate = date,
                    Description = "I like to travel here",
                    CategoryId = 2,
                }
                );
            modelBuilder.Entity<PostTag>().HasData(
               new PostTag()
               {
                   Id = 1,
                   PostId = 1,
                   TagId = 1
               },
              new PostTag()
              {
                  Id = 2,
                  PostId = 2,
                  TagId = 2
              },
              new PostTag()
              {
                  Id = 3,
                  PostId = 3,
                  TagId = 3
              }
               );
            modelBuilder.Entity<Tag>().HasData(
              new Tag()
              {
                  Id = 1,
                  Name = "Jason"
              },
             new Tag()
             {
                 Id = 2,
                 Name = "ali"
             },
             new Tag()
             {
                 Id = 3,
                 Name = "Ghassan"
             }
              );
            modelBuilder.Entity<Category>().HasData(
                new Category()
                {
                    Id = 1,
                    Name = "Cars",
                },
                  new Category()
                  {
                      Id = 2,
                      Name = "Travel"
                  },
                new Category()
                {
                    Id = 3,
                    Name = "Flowers"
                });
            base.OnModelCreating(modelBuilder);
        }
    }
}