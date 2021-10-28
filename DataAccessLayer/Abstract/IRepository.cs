using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IRepository<T>
    {
        //Listele
        List<T> List();

        //Ekle
        void Insert(T p);

        //Sil
        T GeT(Expression<Func<T, bool>> filter);
        void Delete(T p);

        //Güncelle
        void Update(T p);


        List<T> List(Expression<Func<T,bool>> filter);


    }
}
