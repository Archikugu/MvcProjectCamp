using Business.Abstract;
using DataAccess.Abstract;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete {
    public class AboutManager : IAboutService {
        IAboutDal _aboutDal;

        public AboutManager(IAboutDal aboutDal) {
            _aboutDal = aboutDal;
        }

        public void AboutAdd(About about) {
            _aboutDal.Insert(about);
        }

        public void AboutDelete(About about) {
            _aboutDal.Delete(about);
        }

        public void AboutUpdate(About about) {
            _aboutDal.Update(about);
        }

        public List<About> GetAboutList() {
            return _aboutDal.GetList();
        }

        public About GetById(int id) {
            return _aboutDal.GetById(x => x.AboutId == id);
        }
    }
}
