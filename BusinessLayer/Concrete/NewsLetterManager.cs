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
    public class NewsLetterManager : INewsLetterService
    {
        INewsLetterDal _newsLetterDal;

        public NewsLetterManager(INewsLetterDal newsLetterDal)
        {
            _newsLetterDal = newsLetterDal;
        }

        public NewsLetter TGetById(int id)
        {
            return _newsLetterDal.GetById(id);
        }

        public List<NewsLetter> ListAll()
        {
            return _newsLetterDal.GetListAll();
        }

        public List<NewsLetter> ListAllParameter(int id)
        {
            return _newsLetterDal.GetListAll(x=>x.MailID == id);
        }

        public void TAdd(NewsLetter t)
        {
            _newsLetterDal.Insert(t);
        }

        public void TRemove(NewsLetter t)
        {
            _newsLetterDal.Delete(t);
        }

        public void TUpdate(NewsLetter t)
        {
            _newsLetterDal.Update(t);
        }
    }
}
