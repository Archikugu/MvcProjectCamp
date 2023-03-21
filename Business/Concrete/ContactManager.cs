using Business.Abstract;
using DataAccess.Abstract;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete {
    public class ContactManager : IContactService {
        IContactDal _contactDal;

        public ContactManager(IContactDal contactDal) {
            _contactDal = contactDal;
        }

        public void ContactAdd(Contact contact) {
            _contactDal.Insert(contact);
        }

        public void ContactDelete(Contact contact) {
            _contactDal.Delete(contact);
        }

        public void ContactUpdate(Contact contact) {
            _contactDal.Update(contact);
        }

        public Contact GetById(int id) {
            return _contactDal.GetById(x => x.ContactId == id);
        }

        public List<Contact> GetContactList() {
            return _contactDal.GetList();
        }
    }
}
