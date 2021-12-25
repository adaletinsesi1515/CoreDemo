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
    public class NotificationManager : INotificationService
    {
        INotificationDal _notificationdal;

        public NotificationManager(INotificationDal notificationdal)
        {
            _notificationdal = notificationdal;
        }

        public List<Notification> ListAll()
        {
            return _notificationdal.GetListAll();
        }

        public List<Notification> ListAllParameter(int id)
        {
            return _notificationdal.GetListAll(x=>x.NotificationID == id);
        }

        public void TAdd(Notification t)
        {
            _notificationdal.Insert(t);
        }

        public Notification TGetById(int id)
        {
            return _notificationdal.GetById(id);
        }

        public void TRemove(Notification t)
        {
            _notificationdal.Delete(t);
        }

        public void TUpdate(Notification t)
        {
            _notificationdal.Update(t);
        }
    }
}
