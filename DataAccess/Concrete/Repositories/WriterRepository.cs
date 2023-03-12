using DataAccess.Abstract;
using Entity.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.Repositories {
    public class WriterRepository : IWriterDal {

        Context context = new Context();
        DbSet<Writer> _object;
        public void Delete(Writer p) {
            throw new NotImplementedException();
        }

        public Writer GetById(Expression<Func<Writer, bool>> filter) {
            throw new NotImplementedException();
        }

        public List<Writer> GetList() {
            throw new NotImplementedException();
        }

        public void Insert(Writer p) {
            throw new NotImplementedException();
        }

        public List<Writer> List(Expression<Func<Writer, bool>> filter) {
            throw new NotImplementedException();
        }

        public void Update(Writer p) {
            throw new NotImplementedException();
        }
    }
}
