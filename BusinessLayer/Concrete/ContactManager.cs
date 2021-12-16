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
    public class ContactManager : IContactService
    {
        IContactDal _contactdal;

        public ContactManager(IContactDal contactdal)
        {
            _contactdal = contactdal;
        }

        public Contact TGetById(int id)
        {
            return _contactdal.GetById(id);
        }

        public List<Contact> ListAll()
        {
            return _contactdal.GetListAll();
        }

        public List<Contact> ListAllParameter(int id)
        {
            return _contactdal.GetListAll(x => x.ContactID == id);
        }

        public void TAdd(Contact t)
        {
            _contactdal.Insert(t);
        }

        public void TRemove(Contact t)
        {
            _contactdal.Delete(t);
        }

        public void TUpdate(Contact t)
        {
            _contactdal.Update(t);
        }
    }
}
