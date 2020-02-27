using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogPlatform.Repository
{
  public  interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        IEnumerable Find(int id);
        T GetById(int id);
        void Add(T item);
        void Update(T item);
        void Delete(int id);
        void Save();
    }
}
