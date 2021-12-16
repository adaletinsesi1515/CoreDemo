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
    public class AboutManager : IAboutService
    {
        IAboutDal _aboutDal;

        public AboutManager(IAboutDal aboutDal)
        {
            _aboutDal = aboutDal;
        }

        public About TGetById(int id)
        {
            return _aboutDal.GetById(id);
        }

        public List<About> ListAll()
        {
            return _aboutDal.GetListAll();
        }

        public List<About> ListAllParameter(int id)
        {
            return _aboutDal.GetListAll(x=>x.AboutID == id);
        }

        public void TAdd(About t)
        {
            _aboutDal.Insert(t);
        }

        public void TRemove(About t)
        {
            _aboutDal.Delete(t);
        }

        public void TUpdate(About t)
        {
            _aboutDal.Update(t);
        }
    }
}
