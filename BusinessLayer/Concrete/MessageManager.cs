using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class MessageManager : IMessageService
    {
        IMessageDal _messageDal;

        public MessageManager(IMessageDal messageDal)
        {
            _messageDal = messageDal;
        }

        public List<Message> GetInboxListByWriter(string p)
        {
            return _messageDal.GetListAll(x => x.Receiver == p);
        }

        public List<Message> ListAll()
        {
            return _messageDal.GetListAll();
        }

        public List<Message> ListAllParameter(int id)
        {
            return _messageDal.GetListAll(x=>x.MessageId == id);
        }

        public void TAdd(Message t)
        {
            _messageDal.Insert(t);
        }

        public Message TGetById(int id)
        {
            return _messageDal.GetById(id);
        }

        public void TRemove(Message t)
        {
            _messageDal.Delete(t);
        }

        public void TUpdate(Message t)
        {
            _messageDal.Update(t);
        }
    }
}
