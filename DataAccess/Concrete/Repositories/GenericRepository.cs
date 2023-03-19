using DataAccess.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.Repositories {
    public class GenericRepository<T> : IRepository<T> where T : class {


        public void Delete(T p) {
            using var context = new Context();
            context.Remove(p);
            context.SaveChanges();
        }

        public T GetById(Expression<Func<T, bool>> filter) {
            using var context = new Context();
            return context.Set<T>().SingleOrDefault(filter);

        }

        public List<T> GetList() {
            using var context = new Context();
            return context.Set<T>().ToList();
        }

        public void Insert(T p) {
            using var context = new Context();
            context.Add(p);
            context.SaveChanges();
        }

        public List<T> List(Expression<Func<T, bool>> filter) {
            using var context = new Context();
            return context.Set<T>().Where(filter).ToList();
        }

        public void Update(T p) {
            using var context = new Context();
            context.Update(p);
            context.SaveChanges();
        }
    }
}
