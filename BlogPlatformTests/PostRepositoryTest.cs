using BlogPlatform.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
namespace BlogPlatform.Tests
{
    public class ProductRepositoryTests
    {
        private PostContext db;
        private PostRepository underTest;
        public ProductRepositoryTests()
        {
            db = new PostContext();
            db.Database.BeginTransaction();
            underTest = new PostRepository(db);
        }
        [Fact]
        public void Count_Starts_At_Zero()
        {
            var db = new PostContext();
            var underTest = new PostRepository(db);
            var count = underTest.Count();
            Assert.Equal(0, count);
        }
    }
}