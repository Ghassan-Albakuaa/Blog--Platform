using BlogPlatform.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogPlatform.Repository
{
 public   interface ITag
    {
        List<Tag> GetAll();
        Tag GetById(int Id);
        void Insert(Tag tag);
        void Delete(Tag tag);
    }
}
