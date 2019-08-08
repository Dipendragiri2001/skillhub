using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using SkillHub.Data;

namespace SkillHub.GenericRepository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly ApplicationDbContext _context;
        public GenericRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        
        public bool CheckIfExist(Expression<Func<T, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public void Create(T t)
        {
            _context.Set<T>().Add(t);
            _context.SaveChanges();
        }

       
       

        public List<T> GetAll()
        {
            return _context.Set<T>().ToList();
        }

        public List<T> GetBy(Expression<Func<T, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public T GetSingle(Expression<Func<T, bool>> predicate)
        {
             return _context.Set<T>().FirstOrDefault(predicate);
        }

     

        public void Update(T t)
        {
           _context.Set<T>().Update(t);
           _context.SaveChanges();
        }
         public void Delete(Expression<Func<T, bool>> predicate)
        {
           var s = _context.Set<T>().FirstOrDefault(predicate);
           _context.Set<T>().Remove(s);
           _context.SaveChanges();
        }

       
    }
}