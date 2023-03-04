using DataAccess.Abstract;
using Entity.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.Repositories {
    public class CategoryRepository : ICategoryDal {

        Context context = new Context();
        DbSet<Category> _object;
        public List<Category> categoryList() {
            return _object.ToList();
        }

        public void Delete(Category p) {
            _object.Remove(p);
            context.SaveChanges();
        }

        public void Insert(Category p) {
            _object.Add(p);
            context.SaveChanges();
        }

        public void Update(Category p) {
            context.SaveChanges();
        }
    }
}
