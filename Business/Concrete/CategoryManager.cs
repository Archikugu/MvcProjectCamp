using DataAccess.Concrete.Repositories;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete {
    public class CategoryManager {
        GenericRepository<Category> repository = new GenericRepository<Category>();

        public List<Category> GetAll() {
            return repository.GetList();
        }
        public void Add(Category category) {
            if (category.CategoryName == "" || category.CategoryName.Length <= 3 || category.CategoryDescription == "" || category.CategoryName.Length >= 50) {
                //Hata mesajı 
            }
            else {
                repository.Insert(category);
            }
        }
    }
}
