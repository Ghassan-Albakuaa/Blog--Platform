using BlogPlatform.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogPlatform.Repository
{
    public class PostTagRepository 
    {
        protected readonly PostContext context;
        protected IPost postRepo;
        protected ITag tagRepo;
        //public PostRepository Post
        //{
        //    get
        //    {
        //        return postRepo = postRepo ?? new PostRepository(context);
        //    }
        //}
        //public TagRepository Tag
        //{
        //    get
        //    {
        //        return tagRepo = tagRepo ?? new TagRepository(context);
        //    }
        //}


        public void Save()
        {
            context.SaveChanges();
        }
    }
}
