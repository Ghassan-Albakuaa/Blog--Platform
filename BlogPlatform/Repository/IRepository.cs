using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogPlatform.Repository
{
    interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        IEnumerable Find(int id);
        T GetById(int id);
        void Add(T product);
        void Update(T product);
        void Delete(int id);
        void Save();
    }
}
