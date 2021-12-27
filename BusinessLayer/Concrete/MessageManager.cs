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

        public List<Message2> GetInboxListByWriter(int id)
        {
            return _messageDal.GetlistWithMessageByWriter(id);
        }

        public List<Message2> ListAll()
        {
            return _messageDal.GetListAll();
        }

        public List<Message2> ListAllParameter(int id)
        {
            return _messageDal.GetListAll(x=>x.MessageId == id);
        }

        public void TAdd(Message2 t)
        {
            _messageDal.Insert(t);
        }

        public Message2 TGetById(int id)
        {
            return _messageDal.GetById(id);
        }

        public void TRemove(Message2 t)
        {
            _messageDal.Delete(t);
        }

        public void TUpdate(Message2 t)
        {
            _messageDal.Update(t);
        }
    }
}
