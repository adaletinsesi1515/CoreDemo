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
    public class AdminManager : IAdminService
    {
        IAdminDal _admindal;

        public AdminManager(IAdminDal admindal)
        {
            _admindal = admindal;
        }

        public List<Admin> ListAll()
        {
            return _admindal.GetListAll();
        }

        public List<Admin> ListAllParameter(int id)
        {
            return _admindal.GetListAll(x=>x.AdminID == id);
        }

        public void TAdd(Admin t)
        {
            _admindal.Insert(t);
        }

        public Admin TGetById(int id)
        {
            return _admindal.GetById(id);
        }

        public void TRemove(Admin t)
        {
            _admindal.Delete(t);
        }

        public void TUpdate(Admin t)
        {
            _admindal.Update(t);
        }
    }
}
