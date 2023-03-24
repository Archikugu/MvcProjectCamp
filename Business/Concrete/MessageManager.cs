using Business.Abstract;
using DataAccess.Abstract;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete {
    public class MessageManager : IMessageService {
        IMessageDal _messageDal;

        public MessageManager(IMessageDal messageDal) {
            _messageDal = messageDal;
        }

        public void MessageAdd(Message message) {
            _messageDal.Insert(message);
        }

        public Message GetById(int id) {
            return _messageDal.GetById(x => x.MessageId == id);
        }

        public List<Message> GetListInbox() {
            return _messageDal.List(x => x.ReceiverMail == "admin@gmail.com");
        }
        public List<Message> GetSendInbox() {
            return _messageDal.List(x => x.SenderMail == "admin@gmail.com");
        }


        public void MessageDelete(Message message) {
            _messageDal.Delete(message);
        }

        public void MessageUpdate(Message message) {
            _messageDal.Update(message);
        }
    }
}
