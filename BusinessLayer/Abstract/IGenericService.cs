using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IGenericService <T>
    {
        void TAdd(T t);
        void TRemove(T t);
        void TUpdate(T t);
        List<T> ListAll();
        List<T> ListAllParameter(int id);
        T TGetById(int id);
    }
}
