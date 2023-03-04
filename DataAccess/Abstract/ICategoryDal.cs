using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract {
    public interface ICategoryDal {
        //Crud
        //Type Name();

        List<Category> categoryList();
        void Insert(Category p);
        void Update(Category p);
        void Delete(Category p);

    }
}
