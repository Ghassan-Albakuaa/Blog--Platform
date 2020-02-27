using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlogPlatform.Models;

namespace BlogPlatform.Repository
{
    public class PostRepository : IRepository<Post>
    {
        PostContext db;

        public PostRepository(PostContext db)
        {
            this.db = db;
        }
        public void Add(Post post)
        {
            db.Posts.Add(post);
            db.SaveChanges();
        }
        public object Count()
        {
            return db.Posts.Count();
        }
        public IEnumerable<Post> GetAll()
        {
            return db.Posts.ToList();
        }
        public Post Find2(int id)
        {
            var post = db.Posts.SingleOrDefault(b => b.Id == id);
            return post;
        }
        public void Update(int id, Post post)
        {
            db.Update(post);
            db.SaveChanges();
        }
        public void Delete(int id)
        {
            var post = Find(id);
            db.Remove(post);
            db.SaveChanges();
        }
        public Post Find(int id)
        {
            throw new NotImplementedException();
        }
        public void Update(Post post)
        {
            throw new NotImplementedException();
        }
        IEnumerable IRepository<Post>.Find(int id)
        {
            throw new NotImplementedException();
        }
        public Post GetById(int id)
        {
            throw new NotImplementedException();
        }
        public void Save()
        {
            throw new NotImplementedException();
        }

    }
}
