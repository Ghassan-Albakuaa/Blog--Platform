using BlogPlatform.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogPlatform.Repository
{
    public interface IPost
    {
        List<Post> GetAll();
        Post GetById(int Id);
        void Insert(Post post);
        void Delete(Post post);
    }
}
