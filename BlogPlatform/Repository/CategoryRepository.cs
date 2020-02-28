using BlogPlatform.Models;
using BlogPlatform.Repository;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace BlogPlatform.Repositories
{
    public class CategoryDBRpository : IRepository<Category>
    {
        PostContext db;
        public CategoryDBRpository(PostContext _db)
        {
            db = _db;
        }
        public void Add(Category category)
        {
            db.Categories.Add(category);
            db.SaveChanges();
        }
        public IEnumerable<Category> GetAll()
        {
            return db.Categories.ToList();
        }
        public Tag Find2(int id)
        {
            var tag = db.Tags.SingleOrDefault(b => b.Id == id);
            return tag;
        }
        public void Update(int id, Category category)
        {
            db.Update(category);
            db.SaveChanges();
        }
        public void Delete(int id)
        {
            var category = Find(id);
            db.Remove(category);
            db.SaveChanges();
        }
        public Tag Find(int id)
        {
            throw new NotImplementedException();
        }
        public void Update(Tag tag)
        {
            throw new NotImplementedException();
        }
        IEnumerable IRepository<Category>.Find(int id)
        {
            throw new NotImplementedException();
        }
        public void Update(Category product)
        {
            throw new NotImplementedException();
        }
        public Category GetById(int id)
        {
            return db.Categories.Single(c => c.Id == id);
        }
        public void Save()
        {
            throw new NotImplementedException();
        }
    }
}





